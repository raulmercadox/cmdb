using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Repository;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using System.Web.Security;
using System.IO;
using CMDBApplication.Util;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CMDBApplication.Controllers
{
    public class SolicitudController : BaseController
    {
        //
        // GET: /Solicitud/

        [Authorize(Roles = "Operador,RM")]
        public ActionResult Crear()
        {
            try
            {
                SolicitudView sv = new SolicitudView();
                //sv.Proyectos = new ProyectoRepository().Listar("", "", "", "", 'E');
                sv.Ambientes = new AmbienteRepository().Listar("");
                //sv.Proyectos.Insert(0, new Proyecto { Id = 0, Nombre = String.Empty });
                sv.Ambientes.Insert(0, new Ambiente { Id = 0, Nombre = String.Empty });
                sv.Sistema = new SistemaRepository().Obtener();
                return View(sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Operador,RM")]
        [HttpPost]
        public ActionResult Crear(SolicitudView sv)
        {
            try
            {
                DateTime ahora = DateTime.Now;
                int ambienteId = int.Parse(Request.Form["cboAmbiente"]);
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                string analistaDesarrollo = Request.Form["txtAnalistaDesarrollo"];
                string analistaTestProd = Request.Form["txtAnalistaTestProd"];
                bool emergente = Request.Form["chkEmergente"] == "on";
                bool principal = Request.Form["chkPrincipal"] == "on";
                string razonEmergente = Request.Form["txtRazonEmergente"];
                string copiarA = Request.Form["txtInteresados"];
                string comentario = Request.Form["txtComentario"];
                string rfc = Request.Form["txtRFC"];
                DateTime? fechaEjecucion = Util.Util.ConvertirFecha(Request.Form["txtFechaEjecucion"],Request.Form["cboHora"],Request.Form["cboMinuto"]);

                DateTime? fechaReversion = Util.Util.ConvertirFecha(Request.Form["txtFechaReversion"], "00", "00");
                bool reversion = Request.Form["chkReversion"] == "on";
                bool adicional = Request.Form["chkAdicional"] == "on";
                var regularizacion = Request.Form["chkRegularizacion"] == "on";

                HttpFileCollectionBase archivos = Request.Files;

                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                SolicitudRepository sr = new SolicitudRepository();
                UsuarioRepository ur = new UsuarioRepository();

                Solicitud solicitud = new Solicitud();
                solicitud.Ambiente = ar.Obtener(ambienteId);
                solicitud.Proyecto = pr.Obtener(codigoProyecto);
                
                if (solicitud.Proyecto == null)
                {
                    sv.Mensaje = String.Format("El código de proyecto {0} no existe en el CMS", codigoProyecto);
                    return View("Mensaje", sv);
                }
                List<ProyectoCertificado> proyectoCertificados = pr.ListarCertificado(solicitud.Proyecto.Id, ambienteId);
                if (proyectoCertificados.Count > 0)
                {
                    ProyectoCertificado pc = proyectoCertificados[proyectoCertificados.Count - 1];
                    if (pc.Certificado)
                    {
                        sv.Mensaje = String.Format("El proyecto ha sido certificado por {0} el {1}, lo cual significa que ya no se pueden hacer pases a {2}.", pc.Usuario.Nombre, pc.FechaHoraCadena,solicitud.Ambiente.Nombre);
                        return View("Mensaje", sv);
                    }
                }
                
                solicitud.AnalistaDesarrollo = analistaDesarrollo;
                solicitud.AnalistaTestProd = analistaTestProd;
                solicitud.CopiarA = copiarA;
                solicitud.Emergente = emergente;
                solicitud.RazonEmergente = razonEmergente;
                solicitud.Principal = principal;
                solicitud.RFC = rfc;
                solicitud.FechaEjecucion = fechaEjecucion;
                solicitud.Adicional = adicional;
                solicitud.Regularizacion = regularizacion;

                if (solicitud.Proyecto.Mejora)
                    solicitud.FechaReversion = fechaReversion;

                solicitud.Reversion = reversion;

                for (var i = 1; i <= 10; i++)
                {
                    var archivo = CMDBApplication.Util.Util.ObtenerArchivo(solicitud,i);
                    archivo.Contenido = new byte[archivos[i - 1].InputStream.Length];
                    archivos[i - 1].InputStream.Read(archivo.Contenido, 0, archivo.Contenido.Length);
                    archivo.Nombre = archivos[i - 1].FileName.Substring(archivos[i - 1].FileName.LastIndexOf('\\') + 1);
                    if (!String.IsNullOrEmpty(archivo.Nombre))
                    {
                        var extension = archivo.Nombre.Substring(archivo.Nombre.LastIndexOf('.') + 1);
                        if (extension.Length < 3 || extension.Substring(0, 3) != "xls")
                        {
                            sv.Mensaje = "El formulario " + archivo.Nombre + " no es un formato de Excel válido. Solo están permitidos formularios de Excel.";
                            return View("Mensaje", sv);
                        }
                    }
                    if (archivo.Contenido.Count() > 0)
                        archivo.Fecha = ahora;
                    else
                        archivo.Fecha = null;

                    //Util.Util.AsignarArchivo(solicitud, i, archivo);
                }

                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);

                #region Aprobaciones
                int numeroAprobaciones = Request.Files.Count - 10;
                for (int i = 1; i <= numeroAprobaciones; i++)
                {
                    if (Request.Files[i + 9].InputStream.Length > 0)
                    {
                        Archivo archivo = new Archivo();
                        archivo.Nombre = Request.Files[i + 9].FileName.Substring(archivos[i + 9].FileName.LastIndexOf('\\') + 1);
                        archivo.Contenido = new byte[archivos[i + 9].InputStream.Length];
                        archivos[i + 9].InputStream.Read(archivo.Contenido, 0, archivo.Contenido.Length);
                        archivo.Fecha = ahora;
                        archivo.ContentType = Request.Files[i + 9].ContentType;
                        solicitud.Aprobaciones.Add(archivo);
                    }
                }
                #endregion
               

                solicitud.Solicitante = usuario;
                Log log = new Log();
                log.Estado = "Solicitado_x_Sol";
                log.FechaHora = ahora;
                log.Usuario = usuario;
                log.Accion = "Sol.Solicitar";
                log.Comentario = String.IsNullOrEmpty(comentario) ? (solicitud.Emergente ? razonEmergente : String.Empty) : comentario;

                solicitud.Logs.Add(log);

                solicitud = sr.Insertar(solicitud);

                string urlServidor = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                Util.Util.EnviarCorreo(urlServidor, solicitud, "Solicitud S" + solicitud.Id.ToString().PadLeft(6, '0') + (solicitud.Emergente?" EMERGENTE":"") + " creada.");

                #region Se observa la solicitud si es la primera que vez que pasa a este ambiente
                
                if (solicitud.Ambiente.ApruebaCalidad)
                {
                    bool existe = false;
                    var coincideFecha = false;
                    var fechaSolicitud = solicitud.FechaEjecucion;
                    var fechaProgramada = DateTime.Now;
                    // Se verifica si el proyecto tiene fecha de pase para el ambiente especificado en la solicitud
                    foreach (ProyectoAmbiente proyectoAmbiente in solicitud.Proyecto.Ambientes)
                    {
                        if (solicitud.Ambiente.Id == proyectoAmbiente.Ambiente.Id)
                        {
                            fechaProgramada = proyectoAmbiente.FechaPase;
                            if (fechaSolicitud.HasValue && fechaSolicitud.Value.Year == fechaProgramada.Year && fechaSolicitud.Value.Month == fechaProgramada.Month && fechaSolicitud.Value.Day == fechaProgramada.Day)
                            {
                                coincideFecha = true;
                            }
                            existe = true;
                            break;
                        }
                    }
                    if (!existe || !coincideFecha)
                    {
                        List<Solicitud> solicitudes = sr.Listar(String.Empty, solicitud.Ambiente.Id, solicitud.Proyecto.Id, String.Empty, String.Empty, false, String.Empty, null, null, String.Empty, String.Empty, false, todos:false);
                        if (solicitudes.Count == 1)
                        {
                            solicitud.Estado = "Observado_x_RM";

                            log.Estado = solicitud.Estado;
                            log.FechaHora = DateTime.Now;
                            List<Usuario> usuarios = ur.Listar(String.Empty,String.Empty,true,false,false,false,false,false,false);
                            if (usuarios.Count > 0)
                                log.Usuario = usuarios[0];
                            else
                                log.Usuario = usuario;
                            log.Accion = "RM.Observar";
                            if (!existe)
                            {
                                log.Comentario = "La solicitud no tiene fecha programa de pase por lo que necesita ser aprobado por Calidad";
                            }
                            else
                            {
                                log.Comentario = String.Format("La fecha de pase de la solicutd ({0}) no coincide con la fecha programada ({1}) por lo que necesita ser aprobada por calidad.", fechaSolicitud.Value.ToString("dd/MM/yyyy"), fechaProgramada.ToString("dd/MM/yyyy"));
                            }
                            log.Observacion.Id = solicitud.Ambiente.ObservaCalidad.Id;

                            solicitud.Logs.Clear();
                            solicitud.Logs.Add(log);

                            sr.ActualizarSolSolicitadoxSol(solicitud);
                            solicitud = sr.Obtener(solicitud.Id);
                            Util.Util.EnviarCorreo(urlServidor, solicitud, "Solicitud S" + solicitud.Id.ToString().PadLeft(6, '0') + " " +(solicitud.Emergente ? " EMERGENTE" : String.Empty) + solicitud.Estado);
                        }
                    }
                }
                #endregion

                #region Enviar al Validador
                for (int i = 0; i < 10;i++ )
                {
                    HttpPostedFileBase hpf = archivos[i];
                    Util.Util.ProcesarArchivo(solicitud.Id, hpf, i+1);
                }
                #endregion

                return RedirectToAction("Obtener", new { id = "S" + solicitud.Id.ToString().PadLeft(6, '0'), mensaje="Solicitud creada." });
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Operador,CM,RM,Ejecutor")]
        public ActionResult Actualizar(SolicitudView sv)
        {
            try
            {
                DateTime ahora = DateTime.Now;
                StringBuilder sb = new StringBuilder();
                SolicitudRepository sr = new SolicitudRepository();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                ObservacionRepository or = new ObservacionRepository();
                SistemaRepository ss = new SistemaRepository();

                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);

                string id = Request.Form["txtNumeroSolicitud"];
                Solicitud s = sr.Obtener(int.Parse(id.Substring(1)));
                string estadoAnterior = s.Estado;
                s.Logs.Clear();
                string rol = usuario.Operador ? "Operador" : usuario.CM ? "CM" : usuario.RM ? "RM" : usuario.Ejecutor ? "Ejecutor" : String.Empty;
                HttpFileCollectionBase archivos = Request.Files;

                if (
                    (usuario.Operador && (String.Compare(s.Estado, "Solicitado_x_Sol") == 0
                    || String.Compare(s.Estado, "Corregido_x_Sol") == 0
                    || String.Compare(s.Estado, "Enviado_a_CM") == 0
                    || String.Compare(s.Estado, "Aprobado_x_CM") == 0
                    || String.Compare(s.Estado, "Aprobado_x_RM") == 0
                    || String.Compare(s.Estado, "Ejecutado_x_Ejec") == 0))
                    )
                {
                    string cboAccion = Request.Form["cboAccion"];
                    string txtInteresados = Request.Form["txtInteresados"];
                    string cboObservacion = Request.Form["cboObservacion"];
                    string txtComentario = Request.Form["txtComentario"];

                    #region Se existe archivo de evidencia por la observación, se agrega
                    List<Archivo> listaArchivos = new List<Archivo>();
                    for (int i = 0; i < archivos.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(archivos[i].FileName))
                        {
                            Archivo arc = new Archivo();
                            string nombreBruto = archivos[i].FileName;
                            arc.Nombre = nombreBruto.Substring(nombreBruto.LastIndexOf('\\') + 1);
                            arc.Contenido = new byte[archivos[i].InputStream.Length];
                            archivos[i].InputStream.Read(arc.Contenido, 0, arc.Contenido.Length);
                            listaArchivos.Add(arc);
                        }
                    }
                    #endregion

                    s = Util.Util.ActualizarSolicitud(ahora, usuario, s, rol, listaArchivos, cboAccion, txtInteresados, cboObservacion, txtComentario);

                }
                else if (
                    (usuario.RM && (String.Compare(s.Estado, "Ejecutado_x_Ejec") == 0 
                    || String.Compare(s.Estado,"Enviado_a_Ejec")==0
                    || String.Compare(s.Estado,"Rollback_Solicitado_x_RM")==0
                    || String.Compare(s.Estado, "Solicitado_x_Sol") == 0
                    || String.Compare(s.Estado, "Corregido_x_Sol") == 0 
                    ))
                    ||
                    (usuario.CM && String.Compare(s.Estado, "Enviado_a_CM") == 0)
                    ||
                    (usuario.Ejecutor && (String.Compare(s.Estado, "Enviado_a_Ejec") == 0 || String.Compare(s.Estado,"Rollback_Solicitado_x_RM")==0))
                    )
                {
                    string cboAccion = Request.Form["cboAccion"];
                    string txtInteresados = Request.Form["txtInteresados"];
                    string cboObservacion = Request.Form["cboObservacion"];
                    string txtComentario = Request.Form["txtComentario"];

                    List<Archivo> listaArchivos = new List<Archivo>();
                    for (int i = 0; i < archivos.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(archivos[i].FileName))
                        {
                            Archivo arc = new Archivo();
                            string nombreBruto = archivos[i].FileName;
                            arc.Nombre = nombreBruto.Substring(nombreBruto.LastIndexOf('\\') + 1);
                            arc.Contenido = new byte[archivos[i].InputStream.Length];
                            archivos[i].InputStream.Read(arc.Contenido, 0, arc.Contenido.Length);
                            listaArchivos.Add(arc);
                        }
                    }
                    s = Util.Util.ActualizarSolicitud(ahora, usuario, s, rol, listaArchivos, cboAccion, txtInteresados, cboObservacion, txtComentario);

                }
                else if (
                    (usuario.Operador && (String.Compare(s.Estado, "Observado_x_RM") == 0 
                    || String.Compare(s.Estado, "Observado_x_CM") == 0
                    || String.Compare(s.Estado, "Pase_Observado_x_Sol") == 0 
                    || String.Compare(s.Estado, "Observado_x_Ejec") == 0 
                    || String.Compare(s.Estado,"Pase_Observado_x_Ejec")==0 
                    ))
                    ||
                    (usuario.RM && (String.Compare(s.Estado,"Observado_x_RM")==0
                    || String.Compare(s.Estado,"Observado_x_CM")==0
                    || String.Compare(s.Estado, "Pase_Observado_x_Sol") == 0 
                    || String.Compare(s.Estado, "Observado_x_Ejec") == 0 
                    || String.Compare(s.Estado,"Pase_Observado_x_Ejec")==0
                    ))
                    )
                {
                    string cboAccion = Request.Form["cboAccion"];
                    string cboAmbiente = Request.Form["cboAmbiente"];
                    string txtAnalistaDesarrollo = Request.Form["txtAnalistaDesarrollo"];
                    string txtAnalistaTestProd = Request.Form["txtAnalistaTestProd"];
                    string chkEmergente = Request.Form["chkEmergente"];
                    string chkPrincipal = Request.Form["chkPrincipal"];
                    string txtCodigoProyecto = Request.Form["txtCodigoProyecto"];
                    string txtRazonEmergente = Request.Form["txtRazonEmergente"];
                    string txtInteresados = Request.Form["txtInteresados"];
                    string cboObservacion = Request.Form["cboObservacion"];
                    string txtComentario = Request.Form["txtComentario"];
                    string rfc = Request.Form["txtRFC"];
                    DateTime? fechaEjecucion = Util.Util.ConvertirFecha(Request.Form["txtFechaEjecucion"],Request.Form["cboHora"],Request.Form["cboMinuto"]);
                    string chkAdicional = Request.Form["chkAdicional"];
                    string chkRegularizacion = Request.Form["chkRegularizacion"];
                    DateTime? fechaReversion = Util.Util.ConvertirFecha(Request.Form["txtFechaReversion"], "00", "00");
                    bool reversion = Request.Form["chkReversion"] == "on";

                    ObservacionRepository observacionRepository = new ObservacionRepository();
                    SolicitudRepository solicitudRepository = new SolicitudRepository();
                    if (!String.IsNullOrEmpty(cboAccion))
                        s.Estado = solicitudRepository.ObtenerEstado(rol, s.Estado, cboAccion);

                    s.Ambiente = ar.Obtener(Convert.ToInt32(cboAmbiente));
                    s.AnalistaDesarrollo = txtAnalistaDesarrollo;
                    s.AnalistaTestProd = txtAnalistaTestProd;
                    s.Emergente = chkEmergente == "on";
                    s.Principal = chkPrincipal == "on";
                    s.Adicional = chkAdicional == "on";
                    s.Regularizacion = chkRegularizacion == "on";
                    string codigoProyecto = txtCodigoProyecto;
                    s.Proyecto = pr.Obtener(codigoProyecto);
                    s.RFC = rfc;
                    s.FechaEjecucion = fechaEjecucion;
                    s.FechaReversion = fechaReversion;
                    s.Reversion = reversion;

                    if (s.Proyecto == null)
                    {
                        sv.Mensaje = String.Format("El código de proyecto {0} no existe en el CMS", codigoProyecto);
                        return View("Mensaje", sv);
                    }
                    s.RazonEmergente = s.Emergente ? txtRazonEmergente : "";
                    s.CopiarA = txtInteresados;
                    if (!String.IsNullOrEmpty(s.Estado) && !String.IsNullOrEmpty(cboAccion))
                    {
                        Log log = new Log();
                        log.Usuario = usuario;
                        log.Accion = cboAccion;
                        if (log.Accion.IndexOf("Observar") >= 0)
                        {
                            int observacionId;
                            int.TryParse(cboObservacion, out observacionId);
                            log.Observacion = observacionRepository.Obtener(observacionId);
                            log.Comentario = String.IsNullOrEmpty(txtComentario) ? log.Observacion.Nombre : txtComentario;
                        }
                        else
                        {
                            log.Comentario = txtComentario.Trim();
                        }
                        
                        if (/*log.Accion.IndexOf("Observar") >= 0 &&*/ archivos[0].InputStream.Length > 0)
                        {
                            string nombreBruto = archivos[0].FileName;
                            log.Archivo.Nombre = nombreBruto.Substring(nombreBruto.LastIndexOf('\\') + 1);
                            log.Archivo.Contenido = new byte[archivos[0].InputStream.Length];
                            archivos[0].InputStream.Read(log.Archivo.Contenido, 0, log.Archivo.Contenido.Length);
                        }
                        else
                        {
                            log.Archivo.Nombre = String.Empty;
                            log.Archivo.Contenido = new byte[0];
                        }
                        log.Estado = s.Estado;
                        log.FechaHora = ahora;
                        s.Logs.Add(log);
                    }
                    s = solicitudRepository.ActualizarSolObservadoxRM(s);

                    #region Actualizar Archivos
                    ObjetoBDRepository obdr = new ObjetoBDRepository();
                    SolicitudBDJobRepository sbdjr = new SolicitudBDJobRepository();
                    SolicitudBDPermisoDBURepository sbdpdbur = new SolicitudBDPermisoDBURepository();
                    SolicitudBDCampoRepository campoRepo = new SolicitudBDCampoRepository();
                    SolicitudBDConfiguracionRepository configRepo = new SolicitudBDConfiguracionRepository();
                    SolicitudCRMWPAppRepository crmwebApp = new SolicitudCRMWPAppRepository();
                    /*var tomcat = new SolicitudTomcatRepository();
                    var android = new SolicitudAndroidRepository();
                    var app11g = new SolicitudApp11gRepository();
                    var configApp11g = new SolicitudConfigApp11gRepository();
                    var crmconfig = new SolicitudCRMConfigRepository();*/

                    if (!String.IsNullOrEmpty(s.Estado) && !String.IsNullOrEmpty(Request.Form["cboAccion"]))
                    {
                        Archivo archivo = new Archivo();
                        for (int i = 1; i <= 10; i++)
                        {
                            if (!String.IsNullOrEmpty(Request.Form["nombrearch" + i.ToString()]))
                            {
                                if (archivos[i].InputStream.Length > 0)
                                {
                                    // El archivo ha sido subido
                                    archivo.Nombre = Request.Form["nombrearch" + i];
                                    archivo.Contenido = new byte[archivos[i].InputStream.Length];
                                    archivo.Fecha = ahora;
                                    archivos[i].InputStream.Read(archivo.Contenido, 0, archivo.Contenido.Length);
                                    sr.ActualizarArchivo(s.Id, i, archivo);

                                    // Se elimina objetos de BD si los hay
                                    obdr.EliminarObjetos(s.Id, i);
                                    sbdjr.EliminarObjetos(s.Id, i);
                                    sbdpdbur.EliminarObjetos(s.Id, i);
                                    campoRepo.EliminarObjetos(s.Id, i);
                                    configRepo.EliminarObjetos(s.Id, i);
                                    crmwebApp.EliminarObjetos(s.Id, i);

                                    sr.EliminarInfoFormulario(s.Id, i);
                                    /*tomcat.EliminarObjetos(s.Id, i);
                                    android.EliminarObjetos(s.Id, i);
                                    app11g.EliminarObjetos(s.Id, i);
                                    configApp11g.EliminarObjetos(s.Id, i);
                                    crmconfig.EliminarObjetos(s.Id, i);*/

                                    if (Request.Form["cboAccion"].IndexOf("Corregir") >= 0)
                                    {
                                        Util.Util.ProcesarArchivo(s.Id, archivos[i], i);
                                    }
                                }
                                else
                                {
                                    // Obtener el archivo de la base de datos
                                    obdr.EliminarObjetos(s.Id, i);
                                    sbdjr.EliminarObjetos(s.Id, i);
                                    sbdpdbur.EliminarObjetos(s.Id, i);
                                    campoRepo.EliminarObjetos(s.Id, i);
                                    configRepo.EliminarObjetos(s.Id, i);
                                    crmwebApp.EliminarObjetos(s.Id, i);

                                    sr.EliminarInfoFormulario(s.Id, i);
                                    /*tomcat.EliminarObjetos(s.Id, i);
                                    android.EliminarObjetos(s.Id, i);
                                    app11g.EliminarObjetos(s.Id, i);
                                    configApp11g.EliminarObjetos(s.Id, i);
                                    crmconfig.EliminarObjetos(s.Id, i);*/

                                    Archivo archivoGuardado = sr.ObtenerArchivo(s.Id, i);
                                    sr.ActualizarComentario(s.Id, i, String.Empty, false);
                                    if (Request.Form["cboAccion"].IndexOf("Corregir") >= 0)
                                    {
                                        Util.Util.ProcesarArchivo(s.Id, archivoGuardado, i);
                                    }
                                }
                            }
                            else
                            {
                                // Se elimina el archivo
                                string nombreArchivo = Util.Util.ObtenerNombreArchivo(s, i);
                                if (!String.IsNullOrEmpty(nombreArchivo))
                                {
                                    archivo.Nombre = String.Empty;
                                    archivo.Contenido = new byte[0];
                                    sr.ActualizarArchivo(s.Id, i, archivo);

                                    obdr.EliminarObjetos(s.Id, i);
                                    sbdjr.EliminarObjetos(s.Id, i);
                                    sbdpdbur.EliminarObjetos(s.Id, i);
                                    campoRepo.EliminarObjetos(s.Id, i);
                                    configRepo.EliminarObjetos(s.Id, i);
                                    crmwebApp.EliminarObjetos(s.Id, i);

                                    sr.EliminarInfoFormulario(s.Id, i);
                                    /*tomcat.EliminarObjetos(s.Id, i);
                                    android.EliminarObjetos(s.Id, i);
                                    app11g.EliminarObjetos(s.Id, i);
                                    configApp11g.EliminarObjetos(s.Id, i);
                                    crmconfig.EliminarObjetos(s.Id, i);*/
                                }
                            }
                        }
                    }                    
                    #endregion

                    #region Actualizar Aprobaciones
                    int numeroAprobaciones = Request.Files.Count - 11;
                    for (int i = 1; i <= numeroAprobaciones; i++)
                    {
                        var valorAprobado = Request.Form["nombreaprob" + i.ToString()];
                        if (!valorAprobado.Contains("eliminado"))
                        {
                            if (Request.Files[i + 10].InputStream.Length > 0)
                            {
                                Archivo aprobacion = new Archivo();
                                aprobacion.Nombre = Request.Files[i + 10].FileName.Substring(archivos[i + 10].FileName.LastIndexOf('\\') + 1);
                                aprobacion.Contenido = new byte[archivos[i + 10].InputStream.Length];
                                aprobacion.ContentType = Request.Files[i + 10].ContentType;
                                aprobacion.Fecha = ahora;
                                archivos[i + 10].InputStream.Read(aprobacion.Contenido, 0, aprobacion.Contenido.Length);
                                // Actualizar
                                aprobacion.Id = int.Parse(Request.Form["nombreaprob" + i]);
                                sr.ActualizarAprobacion(aprobacion, s.Id);
                            }
                        }
                        else
                        {
                            // Se elimina la aprobación
                            var aprobacionId = int.Parse(valorAprobado.Split(new char[] { '-' })[0]);
                            sr.EliminarAprobacion(aprobacionId);
                        }
                    }                    
                    #endregion
                }
                else if (usuario.RM && (String.Compare(s.Estado, "Aprobado_x_CM") == 0 || String.Compare(s.Estado, "Aprobado_x_RM") == 0
                    ))
                {
                    if (!String.IsNullOrEmpty(Request.Form["cboAccion"]))
                        s.Estado = sr.ObtenerEstado(rol, s.Estado, Request.Form["cboAccion"]);

                    s.CopiarA = Request.Form["txtInteresados"];

                    int areaArchivo1 = Request.Form["cboArchivo1"] != null ? Convert.ToInt32(Request.Form["cboArchivo1"]) : 0;
                    int areaArchivo2 = Request.Form["cboArchivo2"] != null ? Convert.ToInt32(Request.Form["cboArchivo2"]) : 0;
                    int areaArchivo3 = Request.Form["cboArchivo3"] != null ? Convert.ToInt32(Request.Form["cboArchivo3"]) : 0;
                    int areaArchivo4 = Request.Form["cboArchivo4"] != null ? Convert.ToInt32(Request.Form["cboArchivo4"]) : 0;
                    int areaArchivo5 = Request.Form["cboArchivo5"] != null ? Convert.ToInt32(Request.Form["cboArchivo5"]) : 0;
                    int areaArchivo6 = Request.Form["cboArchivo6"] != null ? Convert.ToInt32(Request.Form["cboArchivo6"]) : 0;
                    int areaArchivo7 = Request.Form["cboArchivo7"] != null ? Convert.ToInt32(Request.Form["cboArchivo7"]) : 0;
                    int areaArchivo8 = Request.Form["cboArchivo8"] != null ? Convert.ToInt32(Request.Form["cboArchivo8"]) : 0;
                    int areaArchivo9 = Request.Form["cboArchivo9"] != null ? Convert.ToInt32(Request.Form["cboArchivo9"]) : 0;
                    int areaArchivo10 = Request.Form["cboArchivo10"] != null ? Convert.ToInt32(Request.Form["cboArchivo10"]) : 0;

                    s.Area1 = new Area { Id = areaArchivo1 };
                    s.Area2 = new Area { Id = areaArchivo2 };
                    s.Area3 = new Area { Id = areaArchivo3 };
                    s.Area4 = new Area { Id = areaArchivo4 };
                    s.Area5 = new Area { Id = areaArchivo5 };
                    s.Area6 = new Area { Id = areaArchivo6 };
                    s.Area7 = new Area { Id = areaArchivo7 };
                    s.Area8 = new Area { Id = areaArchivo8 };
                    s.Area9 = new Area { Id = areaArchivo9 };
                    s.Area10 = new Area { Id = areaArchivo10 };

                    var i = 0;
                    foreach (var aprobacion in s.Aprobaciones)
                    {
                        i++;
                        var nombreControl = "cboAprobacion" + i;
                        var areaId = Request.Form[nombreControl];
                        if (!String.IsNullOrEmpty(areaId))
                        {
                            if (aprobacion.Area == null)
                            {
                                aprobacion.Area = new Area { Id = areaId == null ? 0 : int.Parse(areaId) };
                            }
                            else
                            {
                                aprobacion.Area.Id = int.Parse(areaId);
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(s.Estado) && !String.IsNullOrEmpty(Request.Form["cboAccion"]))
                    {
                        Log log = new Log();
                        log.Usuario = usuario;
                        log.Accion = Request.Form["cboAccion"];
                        if (log.Accion.IndexOf("Observar") >= 0)
                        {
                            int observacionId;
                            int.TryParse(Request.Form["cboObservacion"], out observacionId);
                            log.Observacion = or.Obtener(observacionId);
                            log.Comentario = String.IsNullOrEmpty(Request.Form["txtComentario"]) ? log.Observacion.Nombre : Request.Form["txtComentario"];
                        }
                        else
                        {
                            log.Comentario = Request.Form["txtComentario"].Trim();
                        }
                        if (/*log.Accion.IndexOf("Observar") >= 0 &&*/ archivos[archivos.Count - 1].InputStream.Length > 0)
                        {
                            string nombreBruto = archivos[archivos.Count - 1].FileName;
                            log.Archivo.Nombre = nombreBruto.Substring(nombreBruto.LastIndexOf('\\') + 1);
                            log.Archivo.Contenido = new byte[archivos[archivos.Count - 1].InputStream.Length];
                            archivos[0].InputStream.Read(log.Archivo.Contenido, 0, log.Archivo.Contenido.Length);
                        }
                        else
                        {
                            log.Archivo.Nombre = String.Empty;
                            log.Archivo.Contenido = new byte[0];
                        }
                        log.Estado = s.Estado;
                        log.FechaHora = ahora;
                        s.Logs.Add(log);
                    }
                    s = sr.ActualizarRMSolicitadoxSol(s);
                }
                s = sr.Obtener(s.Id);
                if (String.Compare(estadoAnterior, "Aprobado_x_RM") != 0 && String.Compare(s.Estado, "Aprobado_x_RM") == 0)
                {
                    #region Habilitar los objetos en la carpeta de pase
                    string folderPre = ss.Obtener().FolderPre;
                    string folderDML = ss.Obtener().FolderDML;

                    string rutaBase = String.Concat(folderPre, "\\S", s.Id.ToString().PadLeft(6, '0'), "\\", s.Proyecto.Codigo);
                    if (Directory.Exists(rutaBase))
                    {
                        string[] archivosFisicos = Directory.GetFiles(rutaBase, "*.*", SearchOption.AllDirectories);
                        foreach (string archivo in archivosFisicos)
                        {
                            int indiceUltimoBackSlah = archivo.LastIndexOf('\\');
                            string archivoSolo = archivo.Substring(indiceUltimoBackSlah + 1);
                            string rutaRestanteIncluidoArchivo = archivo.Substring(rutaBase.Length + 1);
                            string rutaRestanteSinArchivo = rutaRestanteIncluidoArchivo.Substring(0, rutaRestanteIncluidoArchivo.LastIndexOf('\\'));
                            if (!String.IsNullOrEmpty(rutaRestanteSinArchivo))
                            {
                                rutaRestanteSinArchivo = "\\" + rutaRestanteSinArchivo;
                            }
                            string folderDestino = String.Concat(folderDML, "\\", s.Ambiente.Nombre, "\\", s.Proyecto.Codigo, rutaRestanteSinArchivo);
                            string archivoDestino = String.Concat(folderDestino, "\\", archivoSolo);
                            if (!Directory.Exists(folderDestino))
                            {
                                Directory.CreateDirectory(folderDestino);
                            }
                            System.IO.File.Copy(archivo, archivoDestino, true);
                        }
                    }
                    #endregion
                }
                string urlServidor = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                Util.Util.EnviarCorreo(urlServidor, s, "Solicitud S" + s.Id.ToString().PadLeft(6, '0') + " " + (s.Emergente ? "EMERGENTE " : "") + s.Estado);
                return RedirectToAction("Obtener", new { id = "S" + s.Id.ToString().PadLeft(6, '0'), mensaje="Solicitud Actualizada" });

                //return ObtenerProcesado(s, "Solicitud Actualizada");
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id,string mensaje)
        {
            try
            {
                SolicitudRepository sr = new SolicitudRepository();
                Solicitud s = sr.Obtener(int.Parse(id.Substring(1)));
                return ObtenerProcesado(s, mensaje);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        public ActionResult ObtenerProcesado(Solicitud s, string mensaje)
        {
            try
            {
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                SolicitudRepository sr = new SolicitudRepository();
                ObservacionRepository or = new ObservacionRepository();
                SistemaRepository ss = new SistemaRepository();

                SolicitudView sv = new SolicitudView();
                sv.Solicitud = s;
                sv.Ambientes = ar.Listar("");
                //sv.Proyectos = pr.Listar("", "", "", "", 'E');
                sv.Observaciones = or.Listar("");
                sv.Acciones = sr.ListarAccciones(usuario, s.Estado);
                sv.Acciones.Insert(0, "");
                sv.Mensaje = mensaje;
                sv.Sistema = ss.Obtener();

                if (usuario.RM && (String.Compare(s.Estado, "Aprobado_x_RM") == 0 
                    ))
                    return View("RMSolicitadoxSol", sv);

                else if (usuario.RM && (String.Compare(s.Estado, "Observado_x_RM") == 0 || String.Compare(s.Estado, "Observado_x_CM") == 0
                    || String.Compare(s.Estado, "Observado_x_Ejec") == 0 || String.Compare(s.Estado, "Pase_Observado_x_Sol") == 0 || String.Compare(s.Estado, "Pase_Observado_x_Ejec") == 0))
                    return View("SolObservadoxRM", sv);

                else if (usuario.RM && (String.Compare(s.Estado, "Ejecutado_x_Ejec") == 0
                    || String.Compare(s.Estado, "Enviado_a_Ejec") == 0
                    || String.Compare(s.Estado, "Rollback_Solicitado_x_RM") == 0 || String.Compare(s.Estado, "Enviado_a_CM") == 0
                    || String.Compare(s.Estado, "Aprobado_x_CM") == 0
                    ))
                    return View("OtroSolicitadoxSol", sv);

                else if (usuario.RM && (String.Compare(s.Estado, "Corregido_x_Sol")==0
                    || String.Compare(s.Estado,"Solicitado_x_Sol")==0
                    
                    ))
                    return View("SolSolicitadoxSol", sv);

                else if (usuario.Operador && (String.Compare(s.Estado, "Solicitado_x_Sol") == 0 || String.Compare(s.Estado, "Aprobado_x_CM") == 0
                    || String.Compare(s.Estado, "Aprobado_x_RM") == 0 || String.Compare(s.Estado, "Corregido_x_Sol") == 0
                    || String.Compare(s.Estado, "Enviado_a_CM") == 0 || String.Compare(s.Estado, "Ejecutado_x_Ejec") == 0))
                    return View("SolSolicitadoxSol", sv);

                else if (usuario.Operador && (String.Compare(s.Estado, "Observado_x_RM") == 0 || String.Compare(s.Estado, "Observado_x_CM") == 0
                    || String.Compare(s.Estado, "Observado_x_Ejec") == 0 || String.Compare(s.Estado, "Pase_Observado_x_Ejec") == 0))
                    return View("SolObservadoxRM", sv);

                else if (usuario.CM && String.Compare(s.Estado, "Enviado_a_CM") == 0)
                    return View("OtroSolicitadoxSol", sv);

                else if (usuario.Ejecutor && (String.Compare(s.Estado, "Enviado_a_Ejec") == 0 || String.Compare(s.Estado, "Rollback_Solicitado_x_RM") == 0))
                    return View("OtroSolicitadoxSol", sv);

                else
                    return View("SolAnuladoxSol", sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [Authorize]
        public ActionResult Buscar()
        {
            try
            {
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                SolicitudView sv = new SolicitudView();
                sv.Ambientes = ar.Listar("");
                sv.Ambientes.Insert(0, new Ambiente { Id = 0, Nombre = String.Empty });
                return View(sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Buscar(string id)
        {
            try
            {
                string codigo = Request.Form["txtCodigoSolicitud"];
                int ambiente = int.Parse(Request.Form["cboAmbiente"]);
                ProyectoRepository pr = new ProyectoRepository();
                int proyecto = 0;
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                string rfc = Request.Form["txtRfc"];
                string solicitante = Request.Form["txtSolicitante"];
                SolicitudView sv = new SolicitudView();
                if (!String.IsNullOrEmpty(codigoProyecto))
                {
                    Proyecto pro = pr.Obtener(codigoProyecto);
                    if (pro != null)
                    {
                        proyecto = pro.Id;
                    }
                    else
                    {
                        sv.Mensaje = String.Format("El código del proyecto {0} no existe en el CMS", codigoProyecto);
                        return View("Mensaje", sv);
                    }
                }
                string analistaDes = Request.Form["txtAnalistaDesarrollo"];
                string analistaTest = Request.Form["txtAnalistaTestProd"];
                bool emergente = Request.Form["chkEmergente"] == "on";
                bool principal = Request.Form["chkPrincipal"] == "on";
                bool adicional = Request.Form["chkAdicional"] == "on";
                string razonEmergente = Request.Form["txtRazonEmergente"];
                DateTime? fechaDesde = null;
                DateTime? fechaHasta = null;
                DateTime? fechaEjecucionDesde = null;
                DateTime? fechaEjecucionHasta = null;
                if (Request.Form["chkFechas"]=="on"){
                    string sFechaDesde = Request.Form["txtFechaDesde"];
                    string sFechaHasta = Request.Form["txtFechaHasta"];
                    fechaDesde = new DateTime(int.Parse(sFechaDesde.Substring(6)),int.Parse(sFechaDesde.Substring(3, 2)), int.Parse(sFechaDesde.Substring(0, 2)));
                    fechaHasta = new DateTime(int.Parse(sFechaHasta.Substring(6)), int.Parse(sFechaHasta.Substring(3, 2)), int.Parse(sFechaHasta.Substring(0, 2)));
                }

                if (Request.Form["chkFechaEjecucion"] == "on")
                {
                    string sFechaDesde = Request.Form["txtFechaEjecucionDesde"];
                    string sFechaHasta = Request.Form["txtFechaEjecucionHasta"];
                    fechaEjecucionDesde = new DateTime(int.Parse(sFechaDesde.Substring(6)), int.Parse(sFechaDesde.Substring(3, 2)), int.Parse(sFechaDesde.Substring(0, 2)));
                    fechaEjecucionHasta = new DateTime(int.Parse(sFechaHasta.Substring(6)), int.Parse(sFechaHasta.Substring(3, 2)), int.Parse(sFechaHasta.Substring(0, 2)));
                }

                AmbienteRepository ar = new AmbienteRepository();
                SolicitudRepository sr = new SolicitudRepository();
                
                List<Solicitud> solicitudes = sr.Listar(codigo, ambiente, proyecto, analistaDes, analistaTest, emergente, razonEmergente, fechaDesde, fechaHasta,rfc,solicitante,principal,adicional,
                    true,fechaEjecucionDesde,fechaEjecucionHasta);
                
                sv.Solicitud.Codigo = codigo;
                sv.Solicitud.Ambiente = ar.Obtener(ambiente);
                sv.Solicitud.Proyecto = pr.Obtener(proyecto);
                sv.Solicitud.AnalistaDesarrollo = analistaDes;
                sv.Solicitud.AnalistaTestProd = analistaTest;
                sv.Solicitud.Emergente = emergente;
                sv.Solicitud.RazonEmergente = razonEmergente;
                sv.Solicitud.Principal = principal;
                sv.Solicitud.Adicional = adicional;
                sv.Solicitud.RFC = rfc;
                sv.Solicitud.Solicitante = new Usuario() { Nombre = solicitante };
                sv.FechaDesde = fechaDesde;
                sv.FechaHasta = fechaHasta;
                sv.FechaEjecucionDesde = fechaEjecucionDesde;
                sv.FechaEjecucionHasta = fechaEjecucionHasta;
                sv.Ambientes = ar.Listar("");
                
                sv.Ambientes.Insert(0, new Ambiente { Id = 0, Nombre = String.Empty });
                
                sv.Solicitudes = solicitudes;
                if (sv.Solicitudes.Count == 100)
                {
                    sv.Mensaje = "Se muestran solo 100 registros por cuestiones de performance, por favor especifique un criterio de búsqueda mas fino.";
                }
                else if (sv.Solicitudes.Count == 0)
                {
                    sv.Mensaje = "No existen solicitudes para el criterio de búsqueda especificado.";
                }
                else
                {
                    sv.Mensaje = String.Format("{0} registros encontrados", sv.Solicitudes.Count.ToString());
                }
                return View(sv);
            }
            catch (Exception ex)
            {
                HomeView hv = new HomeView();
                hv.Mensaje = ex.Message;
                return View("Mensaje", hv);
            }
        }

        [HttpGet]
        [Authorize(Roles="Administrador")]
        public ActionResult Revertir()
        {
            var sv = new SolicitudView();

            return View(sv);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Revertir(SolicitudView sv)
        {
            try
            {
                var sr = new SolicitudRepository();
                var numeroSolicitud = Util.Util.CastearNumeroSolicitud(Request.Form["txtNumeroSolicitud"]);
                var estado = sr.ObtenerEstado(numeroSolicitud);
                if (!estado.Pendiente)
                {
                    // Si no es pendiente, significa que es un estado final, por lo tanto se puede revertir.
                    sr.Revertir(numeroSolicitud);
                    sv.Mensaje = "Se revirtió la solicitud satisfactoriamente";
                }
                else
                {
                    // No se puede revertir
                    sv.Mensaje = "La solicitud no se puede revertir debido a que su estado puede ser cambiado por el CMS.";
                }
                return View("Mensaje", sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ListarRollback()
        {
            try
            {
                var sv = new SolicitudView();
                var ar = new AmbienteRepository();
                sv.Ambientes = ar.Listar("");
                return View(sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult ListarRollback(string id)
        {
            try
            {
                var ambienteId = Request.Form["cboAmbiente"];
                var fechaDesde = Request.Form["txtFechaDesde"];
                var fechaHasta = Request.Form["txtFechaHasta"];

                var sr = new SolicitudRepository();
                var rollbacks = sr.ListarRollback(int.Parse(ambienteId), Utilitarios.Fecha.Convertir(fechaDesde), Utilitarios.Fecha.Convertir(fechaHasta));
                var sv = new SolicitudView();
                var ar = new AmbienteRepository();
                sv.Ambientes = ar.Listar("");
                sv.Rollbacks = rollbacks;
                sv.Ambiente = new Ambiente { Id = int.Parse(ambienteId) };
                sv.FechaDesde = Utilitarios.Fecha.Convertir(fechaDesde);
                sv.FechaHasta = Utilitarios.Fecha.Convertir(fechaHasta);

                return View(sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SolicitudView { Mensaje = ex.Message });
            }
        }

        public FileResult ObtenerAprobacion(string id)
        {
            SolicitudRepository sr = new SolicitudRepository();

            Archivo archivo = sr.ObtenerAprobacion(int.Parse(id));
            return File(archivo.Contenido, String.IsNullOrEmpty(archivo.ContentType)?System.Net.Mime.MediaTypeNames.Application.Octet:archivo.ContentType, archivo.Nombre);
        }

        public JsonResult ValidarObjeto(string id)
        {
            OracleConnection con = null;
            try
            {
                #region Se valida objetos de BD
                SolicitudRepository solicitudRepository = new SolicitudRepository();
                Solicitud s = solicitudRepository.Obtener(int.Parse(id));
                // Obtener los objetos de BD que se van a validar
                string comando = String.Empty;
                string resultado = String.Empty;
                ObjetoBDRepository bdRepo = new ObjetoBDRepository();
                TipoObjetoBDRepository tobr = new TipoObjetoBDRepository();
                List<ObjetoBD> objetoBDs = bdRepo.Listar(int.Parse(id));
                SistemaRepository sr = new SistemaRepository();
                con = new OracleConnection(sr.Obtener().OracleDBUExtractConexion);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                con.Open();
                // inserta la lista de objetos a ser extraidos
                foreach (ObjetoBD objetoBD in objetoBDs)
                {
                    comando = String.Format("insert into mycsys.dump_metadata_load (dbsource, object_owner, object_type, object_name) values ('{0}','{1}','{2}','{3}')",
                        objetoBD.Instancia.Nombre, objetoBD.Esquema.Nombre, objetoBD.TipoObjeto.Nombre, objetoBD.Nombre.Substring(0, objetoBD.Nombre.LastIndexOf('.')));
                    cmd.CommandText = comando;
                    cmd.ExecuteNonQuery();
                }

                // Realiza el Extract
                comando = "mycsys.spi_request_ddl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = comando;
                cmd.Parameters.Add("as_justificacion", OracleDbType.Varchar2).Value = id;
                cmd.ExecuteNonQuery();

                // Obtiene la ruta del ftp donde se encuentran los objetos extraidos
                comando = "select * from mycsys.vw_extract_ddl_log";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.CommandText = comando;
                OracleDataReader odr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (odr.Read())
                {
                    resultado = odr[3].ToString();
                    resultado = resultado.Substring(0, resultado.IndexOf("Justificacion"));
                    resultado = resultado.Substring(0, resultado.Length - 1);
                }
                odr.Close();

                // Descarga los objetos en la carpeta de Extracts
                List<object> objetosDiferentes = new List<object>();
                //List<ObjetoBD> objetosDiferentes = new List<ObjetoBD>();
                foreach (ObjetoBD objetoBD in objetoBDs)
                {
                    TipoObjetoBD tobd = tobr.Obtener(objetoBD.TipoObjeto.Id);
                    string rutaArchivo = resultado + "/" + objetoBD.Instancia.Nombre + "/" + objetoBD.Esquema.Nombre + "/" + objetoBD.Nombre.Substring(0, objetoBD.Nombre.LastIndexOf('.')) + "." + tobd.Extension;
                    string destino = sr.Obtener().CarpetaTrabajo + "\\" + s.Proyecto.Codigo +"\\" + objetoBD.Instancia.Nombre + "\\" + objetoBD.Esquema.Nombre;
                    Utilitarios.Archivo.Descargar(rutaArchivo, destino);

                    // Se compara el archivo descargado con el archivo de la carpeta de pase
                    string rutaArchivoExtract = destino + "\\" + rutaArchivo.Substring(rutaArchivo.LastIndexOf("/") + 1);
                    string rutaArchivoPase = sr.Obtener().FolderDML + "\\" + s.Ambiente.Nombre + "\\" + s.Proyecto.Codigo + "\\" + objetoBD.Instancia.Nombre +
                        "\\" + objetoBD.Esquema.Nombre + "\\" + objetoBD.Nombre;

                    string archivoBrutoExtract = Utilitarios.Archivo.LeerArchivoTexto(rutaArchivoExtract);
                    string archivoBrutoPase = Utilitarios.Archivo.LeerArchivoTexto(rutaArchivoPase);

                    string archivoExtract = Utilitarios.Oracle.PlancharArchivo(rutaArchivoExtract);
                    string archivoPase = Utilitarios.Oracle.PlancharArchivo(rutaArchivoPase);
                    if (String.Compare(archivoExtract, archivoPase) != 0)
                    {
                        //string objetoDif = objetoBD.Instancia.Nombre + "." + objetoBD.Esquema.Nombre + "." + objetoBD.Nombre;
                        objetosDiferentes.Add(new { Instancia = objetoBD.Instancia.Nombre, Esquema = objetoBD.Esquema.Nombre, Nombre = objetoBD.Nombre.Substring(0, objetoBD.Nombre.LastIndexOf('.')),
                                                    ArchivoExtract = archivoBrutoExtract,
                                                    ArchivoPase = archivoBrutoPase });
                    }
                }
                #endregion

                object objeto = new { Mensaje = String.Empty, Objetos = objetosDiferentes };
                return Json(objeto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                object objeto = new { Mensaje = ex.Message };
                return Json(objeto, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                if (con!=null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
