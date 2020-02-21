using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Models;
using CMDBApplication.Repository;
using CMDBApplication.ViewModels;
using System.Web.Security;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace CMDBApplication.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);

                HomeView hv = new HomeView();
                SolicitudRepository sr = new SolicitudRepository();
                VentanaRepository vr = new VentanaRepository();
                hv.Pendientes = sr.ListarPendientesCM();
                string nombreVista = "Index";
                if (User.IsInRole("RM"))
                {
                    hv.Pendientes = sr.ListarPendientesRM();
                    hv.Aprobados = sr.ListarAprobadosRM();
                    hv.Ventanas = vr.Listar();
                    
                    nombreVista = "IndexRM";
                }
                if (User.IsInRole("CM"))
                {
                    hv.Pendientes = sr.ListarPendientesCM();
                    nombreVista = "IndexCM";
                }
                if (User.IsInRole("Operador"))
                {
                    hv.Pendientes = sr.ListarPendientesOperador(usuario.Id);
                    nombreVista = "IndexOperador";
                }
                if (User.IsInRole("Ejecutor"))
                {
                    hv.Pendientes = sr.ListarPendientesEjecutor(usuario.Id);
                    nombreVista = "IndexEjecutor";
                }
                return View(nombreVista, hv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        public FileResult ObtenerArchivo(string id)
        {
            SolicitudRepository sr = new SolicitudRepository();
            string[] partes = id.Split(new char[] { '-' });
            int solicitudId = int.Parse(partes[0].Substring(1));
            int numArchivo = int.Parse(partes[1]);
            Archivo archivo = sr.ObtenerArchivo(solicitudId, numArchivo);
            return File(archivo.Contenido, System.Net.Mime.MediaTypeNames.Application.Octet, archivo.Nombre);
        }

        public FileResult ObtenerArchivoLog(string id)
        {
            SolicitudRepository sr = new SolicitudRepository();
            Archivo archivo = sr.ObtenerArchivoLog(int.Parse(id));
            return File(archivo.Contenido, System.Net.Mime.MediaTypeNames.Application.Octet, archivo.Nombre);
        }

        [HttpPost]
        [Authorize(Roles = "RM")]
        public ActionResult EnviarEjecutor(string id)
        {
            try
            {
                SolicitudRepository sr = new SolicitudRepository();
                string estadoInicial = "Aprobado_x_RM";
                string accionSiguiente = "RM.Enviar_Ejec";
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                string codigoPase = String.Empty;
                string responsableEjecucion = String.Empty;
                
                Usuario ux = new UsuarioRepository().Obtener(nombreUsuario);
                int ventanaId = int.Parse(Request.Form["cboVentana"]);

                AreaRepository ar = new AreaRepository();
                List<Area> areas = ar.Listar("");
                
                string[] keys = Request.Form.AllKeys;
                int solicitudId;
                AmbienteRepository ambienteRepository = new AmbienteRepository();

                List<Solicitud> solicitudes = new List<Solicitud>();
                List<Ambiente> ambientes = new List<Ambiente>();

                #region Validar si se están marcando solicitudes de regularización
                var listaReg = new List<string>();
                foreach (var key in keys)
                {
                    if (String.Compare(key.Substring(0, 3), "chk") == 0 && String.Compare(key, "chkTodos") != 0)
                    {
                        if (String.Compare(Request.Form[key], "on") == 0)
                        {
                            solicitudId = int.Parse(key.Substring(3));
                            var s = sr.Obtener(solicitudId);
                            if (s.Regularizacion)
                            {
                                listaReg.Add("S" + s.Id.ToString().PadLeft(6, '0'));
                            }
                        }
                    }
                }
                if (listaReg.Count() > 0)
                {
                    var sbMensaje = new StringBuilder();
                    sbMensaje.Append("<p>No se pueden enviar al ejecutor las siguientes solicitudes de regularizacion</p>");
                    sbMensaje.Append("<ul>");
                    foreach (var item in listaReg)
                    {
                        sbMensaje.Append("<li>" + item + "</li>");
                    }
                    sbMensaje.Append("</ul>");
                    var hv = new HomeView();
                    hv.Mensaje = sbMensaje.ToString();
                    return View("Mensaje", hv);
                }
                #endregion

                #region Validar si existen areas asignadas a las solicitudes marcadas para enviar
                StringBuilder ambienteEnviar = new StringBuilder();
                StringBuilder validacion = new StringBuilder();
                validacion.Append("<p>Las siguientes solicitudes no tienen asignados en sus formularios los ejecutores</p>");
                validacion.Append("<ul>");
                bool areasVacias = false;
                
                foreach (string key in keys)
                {
                    if (String.Compare(key.Substring(0, 3), "chk") == 0 && String.Compare(key, "chkTodos") != 0 && String.Compare(Request.Form[key], "on") == 0)
                    {
                        solicitudId = int.Parse(key.Substring(3));
                        Solicitud s = sr.Obtener(solicitudId);
                        s.Ambiente = ambienteRepository.Obtener(s.Ambiente.Id);
                        if (!ambientes.Exists(p => p.Id == s.Ambiente.Id))
                        {
                            ambientes.Add(s.Ambiente);
                            ambienteEnviar.Append(s.Ambiente.Nombre);
                            ambienteEnviar.Append(",");
                        }
                        if (!Util.Util.ExisteArea(s))
                        {
                            areasVacias = true;
                            validacion.Append("<li>S" + s.Id.ToString().PadLeft(6, '0') + "</li>");
                        }
                    }
                }
                validacion.Append("</ul>");
                if (areasVacias)
                {
                    HomeView hv = new HomeView();
                    hv.Mensaje = validacion.ToString();
                    return View("Mensaje", hv);
                }
                #endregion
                string listaAmbientes = ambienteEnviar.ToString().Substring(0, ambienteEnviar.ToString().Length - 1);

                string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1' style='border-collapse:collapse;width:100%;font-family:Arial;font-size:12px;'>");
                sb.Append("<thead>");
                sb.Append("<tr><th style='background-color:#002060;color:#ffffff;'>AMBIENTE</th><th style='background-color:#002060;color:#ffffff;'>SOLICITUD</th><th style='background-color:#002060;color:#ffffff;'>RESPONSABLE DE EJECUCION</th><th style='background-color:#002060;color:#ffffff;'>ANALISTA DESARROLLO</th><th style='background-color:#002060;color:#ffffff;'>PROYECTO</th><th style='background-color:#002060;color:#ffffff;'>FORMULARIO</th></tr>");
                sb.Append("</thead>");
                sb.Append("<tbody>");

                foreach (string key in keys)
                {
                    if (String.Compare(key.Substring(0, 3), "chk") == 0 && String.Compare(key, "chkTodos") != 0)
                    {
                        if (String.Compare(Request.Form[key], "on") == 0)
                        {
                            
                            solicitudId = int.Parse(key.Substring(3));
                            Solicitud s = sr.Obtener(solicitudId);

                            solicitudes.Add(s);
                            List<SolicitudArchivo> solicitudesArchivo = Util.Util.ListarArchivos(s);
                            string solicitudRFC = (s.Ambiente.Final && !String.IsNullOrEmpty(s.RFC)) ? s.RFC : String.Concat("S", s.Id.ToString().PadLeft(6, '0'));
                            foreach (SolicitudArchivo sa in solicitudesArchivo)
                            {
                                if (sa.Area.Correos.Count() > 0)
                                    responsableEjecucion = sa.Area.Nombre;
                                else
                                    responsableEjecucion = s.AnalistaTestProd;

                                
                                //sb.Append("<tr><td>" + s.Ambiente.Nombre + "</td><td>S" + s.Id.ToString().PadLeft(6, '0') + "</td><td>" + sa.SarID + "</td><td style='background-color:" + sa.Area.Color + ";'>" + responsableEjecucion + "</td><td>" + s.AnalistaDesarrollo + "</td><td>" + s.Proyecto.Codigo + "</td>");
                                sb.Append("<tr><td>" + s.Ambiente.Nombre + "</td><td>" + solicitudRFC + "</td><td style='background-color:" + sa.Area.Color + ";'>" + responsableEjecucion + "</td><td>" + s.AnalistaDesarrollo + "</td><td>" + s.Proyecto.Codigo + " - " + s.Proyecto.Nombre + "</td>");
                                sb.Append("<td>");
                                foreach (Archivo archivo in sa.Archivos)
                                {
                                    sb.Append("<a href='" + url + "/Home/ObtenerArchivo/S" + s.Id.ToString().PadLeft(6, '0') + "-" + archivo.Id.ToString() + "'>" + archivo.Nombre + "</a><br/>");
                                }
                                sb.Append("</td></tr>");
                            }
                            foreach (var otros in s.Aprobaciones)
                            {
                                if (otros.Area != null && otros.Area.Id != 0)
                                {
                                    sb.Append("<tr><td>" + s.Ambiente.Nombre + "</td><td>" + solicitudRFC + "</td><td style='background-color:" + otros.Area.Color + ";'>" + responsableEjecucion + "</td><td>" + s.AnalistaDesarrollo + "</td><td>" + s.Proyecto.Codigo + " - " + s.Proyecto.Nombre + "</td>");
                                    sb.Append("<td>");
                                    sb.Append("<a href='" + url + "/Solicitud/ObtenerAprobacion/" + otros.Id.ToString() + "'>" + otros.Nombre + "</a><br/>");
                                    sb.Append("</td></tr>");
                                }
                            }
                            
                            string estado = sr.ObtenerEstado("RM", estadoInicial, accionSiguiente);

                            s.Estado = estado;
                            if (ventanaId == 0)
                            {
                                s.Ventana = null;
                                s.EjecutarEmergente = false;
                            }
                            else if (ventanaId == -1)
                            {
                                s.Ventana = null;
                                s.EjecutarEmergente = true;
                            }
                            else if (ventanaId > 0)
                            {
                                s.Ventana = new VentanaRepository().Obtener(ventanaId);
                                s.EjecutarEmergente = false;
                            }
                            else
                            {
                                s.Ventana = null;
                                s.EjecutarEmergente = false;
                            }

                            Log log = new Log();
                            log.Usuario = ux;
                            log.Accion = accionSiguiente;
                            log.Comentario = "Se envía a los ejecutores";
                            log.Estado = s.Estado;
                            log.FechaHora = DateTime.Now;
                            s.Logs.Add(log);

                            sr.ActualizarRMSolicitadoxSol(s);
                            s.Logs = s.Logs.OrderByDescending(p => p.FechaHora).ToList();
                            EstadoRepository er = new EstadoRepository();
                            List<Estado> estados = er.Listar();
                            Estado estadoX = estados.FirstOrDefault(p => p.Nombre == s.Estado);
                            if (estadoX != null && estadoX.EnviarCorreo)
                            {
                                Util.Util.EnviarCorreo(url, s, "Solicitud S" + s.Id.ToString().PadLeft(6, '0') + (s.Emergente ? " EMERGENTE/Normal Urgente " : " ") + s.Estado);
                            }
                        }
                    }
                }

                sb.Append("</tbody>");
                sb.Append("</table>");

                string ventana = String.Empty;
                if (ventanaId == -1)
                {
                    ventana = "Emergente";
                }
                else if (ventanaId > 0)
                {
                    VentanaRepository vr = new VentanaRepository();
                    Ventana vv = vr.Obtener(ventanaId);
                    string horaHasta = String.Empty;
                    if (vv.Hasta.HasValue)
                    {
                        horaHasta = " - " + vv.Hasta.Value.ToString("HH:mm");
                    }
                    ventana = String.Concat("Normal a horas ", vv.Desde.ToString("HH:mm"), horaHasta);
                }
                else
                {
                    ventana = Util.Util.ObtenerDescripcionVentana(solicitudes);
                }
                StringBuilder sbPrevio = new StringBuilder();
                var mensajeEnvio = Request.Form["txtMensajeEnvio"];
                sbPrevio.Append(mensajeEnvio);
                //sbPrevio.Append("Estimados<br/><br/>");
                //sbPrevio.Append("Se envía la relación de pases a ejecutarse en la ventana: " + ventana + "<br/><br/>");
                var asunto = Request.Form["txtAsunto"];
                /*StringBuilder sb2 = new StringBuilder();
                sb2.Append("Pases a ejecutar");
                sb2.Append(" Ventana: " + ventana);
                sb2.Append(" - Ambiente: " + listaAmbientes.ToUpper());
                */
                Util.Util.EnviarCorreo(solicitudes.ToArray(), asunto, sbPrevio.ToString()+sb.ToString(), true, true, true, true, true, true, true, true);
                
                return View("Mensaje", new HomeView { Mensaje = "Se envió el correo a los ejecutores" } );
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }            
        }

        [Authorize(Roles="Administrador")]
        public ActionResult ConfigurarCorreo()
        {
            try
            {
                EstadoRepository er = new EstadoRepository();
                List<Estado> estados = er.Listar();
                EstadoView ev = new EstadoView();
                ev.Estados = estados;
                return View("ConfigurarCorreo", ev);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }       
        }

        [Authorize(Roles="Administrador")]
        [HttpPost]
        public ActionResult ConfigurarCorreo(string id)
        {
            try
            {
                Estado e = new Estado();
                EstadoRepository er = new EstadoRepository();
                List<Estado> estadosantes = er.Listar();
                estadosantes.ForEach(p =>
                {
                    p.EnviarCorreo = false;
                    p.Satisfactorio = false;
                    p.Pendiente = false;
                });
                foreach (string key in Request.Form.AllKeys)
                {
                    string parte1 = key.Split(new char[] { '-' })[0];
                    e.Nombre = key.Split(new char[] { '-' })[1];
                    if (String.Compare(parte1,"Correo")==0)
                    {
                        // Enviar Correo
                        if (estadosantes.Exists(p => p.Nombre == e.Nombre))
                        {
                            int indice = estadosantes.FindIndex(p => p.Nombre == e.Nombre);
                            estadosantes[indice].EnviarCorreo = true;
                        }
                    }
                    else if (String.Compare(parte1,"Satisfactorio")==0)
                    {
                        // Estados Finales OK
                        if (estadosantes.Exists(p => p.Nombre == e.Nombre))
                        {
                            int indice = estadosantes.FindIndex(p => p.Nombre == e.Nombre);
                            estadosantes[indice].Satisfactorio = true;
                        }
                    }
                    else if (String.Compare(parte1, "Pendiente") == 0)
                    {
                        // Estados pendientes no anulados
                        if (estadosantes.Exists(p => p.Nombre == e.Nombre))
                        {
                            int indice = estadosantes.FindIndex(p => p.Nombre == e.Nombre);
                            estadosantes[indice].Pendiente = true;
                        }
                    }
                }
                estadosantes.ForEach(p =>
                {
                    er.Actualizar(p);
                });
                EstadoView ev = new EstadoView();
                List<Estado> estados = er.Listar();
                ev.Estados = estados;
                return View("ConfigurarCorreo", ev);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        public JsonResult ComprobarConexion(string id)
        {
            try
            {
                /*SistemaRepository sr = new SistemaRepository();
                Sistema sistema = sr.Obtener();*/

                OracleConnection con = new OracleConnection(id);                               
                con.Open();
                
                con.Close();

                object objeto = new { Mensaje = "ok" };
                return Json(objeto, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                object objeto = new { Mensaje = ex.Message };
                return Json(objeto, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Mensaje()
        {
            HomeView hv = new HomeView();
            hv.Mensaje = String.Empty;
            return View("Mensaje", hv);
        }
        
        
    }
}