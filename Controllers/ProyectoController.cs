using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Repository;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using CMDBApplication.Util;
using Newtonsoft.Json;
using System.Web.Security;

namespace CMDBApplication.Controllers
{
    public class ProyectoController : BaseController
    {
        //
        // GET: /Proyecto/

        public ActionResult Index()
        {
            try
            {
                ProyectoView pcv = new ProyectoView();
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                
                pcv.Responsables = rr.Listar(String.Empty);
                pcv.TipoProyectos = tpr.Listar(String.Empty);

                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(ProyectoView pcv)
        {
            try
            {
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                string nombreProyecto = Request.Form["txtNombreProyecto"];
                string pm = Request.Form["txtPm"];
                string ptl = Request.Form["txtPtl"];
                char estado = Request.Form["cboEstadoProyecto"].ToCharArray()[0];
                int responsableId = int.Parse(Request.Form["cboResponsable"]);
                bool mejora = Request.Form["chkMejora"] == "on";
                string impacto = mejora ? Request.Form["txtImpacto"] : String.Empty;
                int tipoProyectoId = int.Parse(Request.Form["cboTipoProyecto"]);
                string txtCodigoPresupuestal = Request.Form["txtCodigoPresupuestal"];
                string txtCodigoAlterno = Request.Form["txtCodigoAlterno"];

                ProyectoRepository pr = new ProyectoRepository();
                List<Proyecto> proyectos = pr.Listar(codigoProyecto, nombreProyecto, pm, ptl, estado, responsableId, mejora, impacto, tipoProyectoId, txtCodigoPresupuestal, txtCodigoAlterno);

                pcv.Proyecto = new Proyecto();
                pcv.Proyecto.Codigo = codigoProyecto;
                pcv.Proyecto.Nombre = nombreProyecto;
                pcv.Proyecto.Pm = pm;
                pcv.Proyecto.Ptl = ptl;
                pcv.Proyecto.Estado = estado;
                pcv.Proyecto.Mejora = mejora;
                pcv.Proyecto.Impacto = impacto;
                pcv.Proyecto.CodigoPresupuestal = txtCodigoPresupuestal;
                pcv.Proyecto.CodigoAlterno = txtCodigoAlterno;
                pcv.Proyectos = proyectos;
                
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();

                pcv.Proyecto.Responsable = rr.Obtener(responsableId);
                pcv.Proyecto.TipoProyecto = tpr.Obtener(tipoProyectoId);

                pcv.Responsables = rr.Listar(String.Empty);
                pcv.TipoProyectos = tpr.Listar(String.Empty);
                string mensaje = "";
                if (proyectos.Count == 0)
                {
                    mensaje = "No existen Proyectos para el criterio de búsqueda";
                }
                pcv.Mensaje = mensaje;

                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                ProyectoView pv = new ProyectoView();
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                AmbienteRepository ar = new AmbienteRepository();
                pv.Responsables = rr.Listar(String.Empty);
                pv.TipoProyectos = tpr.Listar(String.Empty);
                pv.Ambientes = ar.Listar(String.Empty);
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(ProyectoView proyectoView)
        {
            try
            {
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                AmbienteRepository ar = new AmbienteRepository();
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                string nombreProyecto = Request.Form["txtNombreProyecto"];
                string pm = Request.Form["txtPm"];
                string ptl = Request.Form["txtPtl"];
                //string fechaProduccion = Request.Form["txtFechaProdProy"];
                int responsableId = int.Parse(Request.Form["cboResponsable"]);
                bool mejora = Request.Form["chkMejora"] == "on";
                string impacto = mejora ? Request.Form["txtImpacto"] : String.Empty;
                int tipoProyectoId = int.Parse(Request.Form["cboTipoProyecto"]);
                string txtCodigoPresupuestal = Request.Form["txtCodigoPresupuestal"];
                string txtCodigoAlterno = Request.Form["txtCodigoAlterno"];

                List<ProyectoAmbiente> proyectoAmbientes = new List<ProyectoAmbiente>();

                string clave = "chkAmbiente";
                foreach (string key in Request.Form.AllKeys)
                {
                    if (key.IndexOf(clave) >= 0)
                    {
                        int ambienteId = int.Parse(key.Substring(clave.Length));
                        string fechaBruto = Request.Form["txtFecha" + ambienteId.ToString()];
                        int anio = int.Parse(fechaBruto.Substring(6));
                        int mes = int.Parse(fechaBruto.Substring(3, 2));
                        int dia = int.Parse(fechaBruto.Substring(0, 2));
                        DateTime fechaPase = new DateTime(anio, mes, dia);
                        ProyectoAmbiente pa = new ProyectoAmbiente();
                        pa.Ambiente = ar.Obtener(ambienteId);
                        pa.FechaPase = fechaPase;
                        proyectoAmbientes.Add(pa);
                    }
                }

                #region Verificar is ya existe el código del proyecto
                ProyectoRepository pr = new ProyectoRepository();
                Proyecto p = pr.Obtener(codigoProyecto.Trim());
                if (p != null)
                {
                    proyectoView.Proyecto.Codigo = codigoProyecto;
                    proyectoView.Proyecto.Nombre = nombreProyecto;
                    proyectoView.Proyecto.Pm = pm;
                    proyectoView.Proyecto.Ptl = ptl;
                    proyectoView.Proyecto.Mejora = mejora;
                    proyectoView.Proyecto.Impacto = impacto;
                    proyectoView.Proyecto.CodigoPresupuestal = txtCodigoPresupuestal;
                    proyectoView.Proyecto.CodigoAlterno = txtCodigoAlterno;
                    
                    proyectoView.Responsables = rr.Listar(String.Empty);
                    proyectoView.TipoProyectos = tpr.Listar(String.Empty);
                    if (responsableId > 0)
                    {
                        proyectoView.Proyecto.Responsable = new Responsable { Id = responsableId };
                    }
                    if (tipoProyectoId > 0)
                    {
                        proyectoView.Proyecto.TipoProyecto = new TipoProyecto { Id = tipoProyectoId };
                    }
                    proyectoView.Mensaje = "El código del proyecto ya existe";
                    return View("Crear", proyectoView);
                }
                else
                {
                    p = new Proyecto();
                    p.Codigo = codigoProyecto;
                    p.Nombre = nombreProyecto;
                    p.Pm = pm;
                    p.Ptl = ptl;
                    p.Mejora = mejora;
                    p.Impacto = impacto;
                    if (responsableId > 0)
                    {
                        p.Responsable = new Responsable { Id = responsableId };
                    }
                    if (tipoProyectoId > 0)
                    {
                        p.TipoProyecto = new TipoProyecto { Id = tipoProyectoId };
                    }
                    p.CodigoPresupuestal = txtCodigoPresupuestal;
                    p.CodigoAlterno = txtCodigoAlterno;
                    p.Ambientes = proyectoAmbientes;
                    p = pr.Actualizar(p);
                    if (p.Id == 0)
                    {
                        proyectoView.Mensaje = "Hubo un error al crear el proyecto";
                        return View("Crear", proyectoView);
                    }
                }
                #endregion

                ProyectoView pp = new ProyectoView();
                pp.Mensaje = "Proyecto Creado";
                pp.Responsables = rr.Listar(String.Empty);
                pp.TipoProyectos = tpr.Listar(String.Empty);
                pp.Ambientes = ar.Listar(String.Empty);
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                ProyectoRepository pr = new ProyectoRepository();
                SolicitudRepository sr = new SolicitudRepository();
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                AmbienteRepository ar = new AmbienteRepository();

                ProyectoView pv = new ProyectoView();
                pv.UsuarioLogueado = ObtenerUsuario();
                pv.Mensaje = "";
                Proyecto p = pr.Obtener(id);
                pv.Proyecto = p;
                pv.Responsables = rr.Listar(String.Empty);
                pv.TipoProyectos = tpr.Listar(String.Empty);
                p.Solicitudes = sr.ListarPorProyecto(p.Id);
                pv.Ambientes = ar.Listar(String.Empty);
                p.Correos = pr.ListarCorreo(p);
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Test")]
        public ActionResult Actualizar(ProyectoView proyectoView)
        {
            try
            {
                AmbienteRepository ar = new AmbienteRepository();

                string id = Request.Form["txtId"];
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                string nombreProyecto = Request.Form["txtNombreProyecto"];
                string pm = Request.Form["txtPm"];
                string ptl = Request.Form["txtPtl"];
                char estado = Request.Form["cboEstadoProyecto"].ToCharArray()[0];
                //string fechaProduccion = Request.Form["txtFechaProdProy"];
                int responsableId = int.Parse(Request.Form["cboResponsable"]);
                bool mejora = Request.Form["chkMejora"] == "on";
                string impacto = mejora ? Request.Form["txtImpacto"] : String.Empty;
                int tipoProyectoId = int.Parse(Request.Form["cboTipoProyecto"]);
                string txtCodigoPresupuestal = Request.Form["txtCodigoPresupuestal"];
                string txtCodigoAlterno = Request.Form["txtCodigoAlterno"];

                Proyecto p = new Proyecto();
                p.Id = int.Parse(id);
                p.Codigo = codigoProyecto;
                p.Nombre = nombreProyecto;
                p.Pm = pm;
                p.Ptl = ptl;
                p.Estado = estado;
                p.Mejora = mejora;
                p.Impacto = impacto;
                p.CodigoPresupuestal = txtCodigoPresupuestal;
                p.CodigoAlterno = txtCodigoAlterno;
                if (responsableId > 0)
                {
                    p.Responsable = new Responsable { Id = responsableId };
                }
                if (tipoProyectoId > 0)
                {
                    p.TipoProyecto = new TipoProyecto { Id = tipoProyectoId };
                }

                List<ProyectoAmbiente> proyectoAmbientes = new List<ProyectoAmbiente>();

                #region Ambientes
                string clave = "chkAmbiente";
                foreach (string key in Request.Form.AllKeys)
                {
                    if (key.IndexOf(clave) >= 0)
                    {
                        int ambienteId = int.Parse(key.Substring(clave.Length));
                        string fechaBruto = Request.Form["txtFecha" + ambienteId.ToString()];
                        int anio = int.Parse(fechaBruto.Substring(6));
                        int mes = int.Parse(fechaBruto.Substring(3, 2));
                        int dia = int.Parse(fechaBruto.Substring(0, 2));
                        DateTime fechaPase = new DateTime(anio, mes, dia);
                        ProyectoAmbiente pa = new ProyectoAmbiente();
                        pa.Ambiente = ar.Obtener(ambienteId);
                        pa.FechaPase = fechaPase;
                        proyectoAmbientes.Add(pa);
                    }
                }

                p.Ambientes = proyectoAmbientes;
                #endregion

                #region Aplicaciones
                List<string> nombres = Request.Form.AllKeys.ToList().Where(param => param.Contains("nombreapp")).ToList();
                foreach (string nombre in nombres)
                {
                    string indice = nombre.Substring("nombreapp".Length);
                    string nombreAplicacion = Request.Form["nombreapp" + indice];
                    string rutaSvn = Request.Form["svnapp" + indice];
                    string ide = Request.Form["ideapp" + indice];
                    string version = Request.Form["versionapp" + indice];
                    char estadoApp = Request.Form["estadoapp" + indice].ToCharArray()[0];
                    if (!String.IsNullOrEmpty(Request.Form["hdId" + indice]) || Request.Form["eliminadoapp" + indice] == "0")
                    {
                        p.Aplicaciones.Add(new Aplicacion
                        {
                            Id = String.IsNullOrEmpty(Request.Form["hdId" + indice]) ? 0 : Convert.ToInt32(Request.Form["hdId" + indice]),
                            Nombre = nombreAplicacion,
                            RutaSVN = rutaSvn,
                            Herramienta = ide,
                            Version = version,
                            Eliminar = Request.Form["eliminadoapp" + indice] == "1",
                            Estado = estadoApp
                        });
                    }
                }
                #endregion

                #region Desarrolladores
                List<string> idDeses = Request.Form.AllKeys.ToList().Where(param => param.Contains("iddes")).ToList();
                foreach (string idDes in idDeses)
                {
                    string indice = idDes.Substring("iddes".Length);
                    if (!String.IsNullOrEmpty(Request.Form["iddes" + indice]))
                    {
                        if (Request.Form["nuevo" + indice] == "0" || Request.Form["eliminadodes" + indice] == "0")
                        {
                            p.Desarrolladores.Add(new Desarrollador
                            {
                                Id = int.Parse(Request.Form["iddes" + indice]),
                                Usuario = Request.Form["usuariodes" + indice],
                                Correo = Request.Form["correodes" + indice],
                                Nombre = Request.Form["nombredes" + indice],
                                Eliminar = Request.Form["eliminadodes" + indice] == "1"
                            });
                        }
                    }
                }
                #endregion

                #region Correos
                var prefijo = "proyectocorreonombre";
                var correos = Request.Form.AllKeys.ToList().Where(param => param.Contains(prefijo)).ToList();
                foreach (var item in correos)
                {
                    var indice = item.Substring(prefijo.Length);
                    var correo = Request.Form[prefijo + indice];
                    if (!String.IsNullOrEmpty(Request.Form["hdCorreo" + indice]) || Request.Form["eliminadoCorreo" + indice] == "0")
                    {
                        if (p.Correos == null)
                        {
                            p.Correos = new List<Correo>();
                        }
                        p.Correos.Add(new Correo
                        {
                            Id = String.IsNullOrEmpty(Request.Form["hdCorreo" + indice]) ? 0 : Convert.ToInt32(Request.Form["hdCorreo" + indice]),
                            Direccion = correo,
                            Eliminar = Request.Form["eliminadoCorreo" + indice] == "1"
                        });
                    }
                }
                #endregion

                ProyectoRepository pr = new ProyectoRepository();

                p = pr.Actualizar(p);
                if (p.Id == 0)
                {
                    proyectoView.Mensaje = "Hubo un error al actualizar el proyecto";
                    return View("Crear", proyectoView);
                }

                p.Ambientes = proyectoAmbientes;
                ProyectoView pp = new ProyectoView();
                pp.Mensaje = "Proyecto Actualizado";
                pp.Proyecto = p;
                SolicitudRepository sr = new SolicitudRepository();
                pp.Proyecto.Solicitudes = sr.ListarPorProyecto(p.Id);
                pp.UsuarioLogueado = ObtenerUsuario();
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                pp.Responsables = rr.Listar(String.Empty);
                pp.TipoProyectos = tpr.Listar(String.Empty);
                pp.Ambientes = ar.Listar(String.Empty);
                p.Correos = pr.ListarCorreo(p);
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        public JsonResult Listar(string id)
        {
            if (id != null)
            {
                ProyectoRepository pr = new ProyectoRepository();
                List<Proyecto> proyectos = pr.Listar(id, String.Empty, String.Empty, String.Empty, ' ', 0, false, String.Empty,0);
                proyectos.ForEach(p =>
                {
                    p.Ambientes = pr.ListarAmbiente(p);
                });
                //string resultado = JsonConvert.SerializeObject(desarrolladores);

                return Json(proyectos, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null,JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ObjetosPendientes()
        {
            try
            {
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoView pv = new ProyectoView();
                pv.Mensaje = String.Empty;
                pv.Ambientes = ar.Listar(String.Empty);
                pv.ProyectoMarcado = true;
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult ObjetosPendientes(string id)
        {
            try
            {
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoView pv = new ProyectoView();
                SolicitudRepository sr = new SolicitudRepository();
                pv.Mensaje = String.Empty;
                pv.Ambientes = ar.Listar(String.Empty);
                string codigoProyecto = Request.Form["txtCodigoProyecto"];
                int ambienteId = int.Parse(Request.Form["cboAmbiente"]);
                int tipoFormulario = int.Parse(Request.Form["cboTipoFormulario"]);

                //pv.Proyecto = new Proyecto { Codigo = codigoProyecto };
                pv.Ambiente = new Ambiente { Id = ambienteId };
                pv.TipoFormulario = tipoFormulario;
                ProyectoRepository pr = new ProyectoRepository();
                pv.Proyecto = pr.Obtener(codigoProyecto);
                if (pv.Proyecto != null && pv.Proyecto.Id > 0)
                {
                    int proyectoId = pv.Proyecto.Id;


                    //UtilExcel utilExcel = new UtilExcel();
                    if (tipoFormulario == 1) // Base de datos
                    {
                        pv.Campos = pr.ListarCampos(proyectoId, ambienteId);

                        pv.ObjetosBD = pr.ListarObjetoBD(proyectoId, ambienteId);

                        pv.PermisosDBU = pr.ListarPermisosDBU(proyectoId, ambienteId);

                        pv.Jobs = pr.ListarJosb(proyectoId, ambienteId);
                        
                        if (pv.ObjetosBD.Count == 0 && pv.Campos.Count == 0 && pv.PermisosDBU.Count == 0 && pv.Jobs.Count == 0)
                        {
                            pv.Mensaje = "No se encontraron registros";
                        }

                        //app.Quit();
                        //ReleaseObject(app);
                    }
                    else if (tipoFormulario == 2) // Configuraciones
                    {
                        pv.Configuraciones = pr.ListarConfiguraciones(proyectoId, ambienteId);


                        if (pv.Configuraciones.Count == 0)
                        {
                            pv.Mensaje = "No se encontraron registros";
                        }
                    }

                    return View(pv);
                }
                else
                {
                    pv.Mensaje = String.Format("El código de proyecto {0} no existe en el CMS", codigoProyecto);
                    return View("Mensaje", pv);
                }
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ProyectoView { Mensaje = ex.Message });
            }
        }

        public ActionResult ListarReversion()
        {
            try
            {
                ProyectoView pv = new ProyectoView();
                ProyectoRepository pr = new ProyectoRepository();
                List<Proyecto> proyectos = pr.ListarReversion();
                pv.Proyectos = proyectos;
                return View(pv);
            }
            catch (Exception ex)
            {
                ProyectoView pv = new ProyectoView();
                pv.Mensaje = ex.Message;
                return View("Mensaje", pv);
            }
        }

        [HttpGet]
        public ActionResult Certificar()
        {
            try
            {
                ProyectoView pv = new ProyectoView();
                AmbienteRepository ar = new AmbienteRepository();
                pv.Ambientes = ar.Listar("");
                return View(pv);
            }
            catch (Exception ex)
            {
                ProyectoView pv = new ProyectoView();
                pv.Mensaje = ex.Message;
                return View("Mensaje", pv);
            }
        }

        public JsonResult ListarCertificado(string proyectoid,string ambienteid)
        {
            if (!String.IsNullOrEmpty(proyectoid) && !String.IsNullOrEmpty(ambienteid))
            {
                ProyectoRepository pr = new ProyectoRepository();
                List<ProyectoCertificado> proyectoCertificados = pr.ListarCertificado(int.Parse(proyectoid), int.Parse(ambienteid));

                object respuesta = new { certificados = proyectoCertificados };
                
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PonerCertificado(string proyectoid, string ambienteid)
        {
            return AplicarCertificado(proyectoid, ambienteid, true);
        }

        public JsonResult QuitarCertificado(string proyectoid, string ambienteid)
        {
            return AplicarCertificado(proyectoid, ambienteid, false);
        }

        private JsonResult AplicarCertificado(string proyectoid, string ambienteid, bool certificado)
        {
            if (!String.IsNullOrEmpty(proyectoid) && !String.IsNullOrEmpty(ambienteid))
            {
                DateTime fechaHora = DateTime.Now;
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);

                ProyectoRepository pr = new ProyectoRepository();
                pr.ActualizarCertificado(int.Parse(proyectoid), int.Parse(ambienteid), certificado, fechaHora, usuario.Id);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CalendarioPases()
        {
            var pv = new ProyectoView();
            pv.Ambientes = new AmbienteRepository().Listar("");
            return View(pv);
        }

        public JsonResult ObtenerEventos(string start, string end, string ambienteId)
        {
            //var objeto = new { title = "N_SD00039390", start = "2015-07-27", end = "2015-07-27" };
            var fechaDesde = ObtenerFecha(start);
            var fechaHasta = ObtenerFecha(end);
            var pr = new ProyectoRepository();
            var lista = pr.ListarFechaPases(int.Parse(ambienteId), fechaDesde, fechaHasta);
            var objetos = from l in lista
                          select new { title = l.Proyecto.Codigo, start = l.FechaPase.ToString("yyyy-MM-dd"), end = l.FechaPase.ToString("yyyy-MM-dd"),tip=l.Proyecto.Nombre,
                          backgroundColor=(l.TipoEvento==TipoEvento.Programado?"#3A87AD":"#FF724D")};
            //object[] objetos = { objeto, objeto,objeto,objeto,objeto };
            return Json(objetos, JsonRequestBehavior.AllowGet);
            //throw new NotImplementedException();
        }

        private DateTime ObtenerFecha(string fecha)
        {
            var fechaResult = new DateTime(int.Parse(fecha.Substring(0, 4)), int.Parse(fecha.Substring(5, 2)), int.Parse(fecha.Substring(8)));
            return fechaResult;
        }

        public JsonResult listarsol(string id)
        {
            var pr = new ProyectoRepository();
            var solPendientes = pr.ListarPendientes(int.Parse(id));
            return Json(solPendientes,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ReporteValidacion()
        {
            return View();
        }
    }
}
