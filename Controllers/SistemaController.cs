using CMDBApplication.Models;
using CMDBApplication.Repository;
using CMDBApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;

namespace CMDBApplication.Controllers
{
    public class SistemaController : BaseController
    {
        //
        // GET: /Sistema/

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ActualizarSistema()
        {
            try
            {
                string primeraSolicitud = Request.Form["txtPrimeraSolicitud"];
                string oracleDBUExtractConexion = Request.Form["txtOracleDBUExtractConexion"];
                int estadoId = Convert.ToInt32(Request.Form["cboEstado"]);
                string carpetaTrabajo = Request.Form["txtCarpetaTrabajo"];
                string correoCMS = Request.Form["txtCorreoCMS"];
                string responderA = Request.Form["txtResponderA"];
                string copiarExcelA = Request.Form["txtCopiarExcelA"];
                string folderPre = Request.Form["txtFolderPre"];
                string folderDML = Request.Form["txtFolderDML"];
                string mensajeCrearSolicitud = Request.Form["txtMensajeCrearSolicitud"];

                SistemaView sistemaView = new SistemaView();
                SistemaRepository sr = new SistemaRepository();
                EstadoRepository er = new EstadoRepository();
                List<Estado> estados = er.Listar();

                Sistema sistema = sr.Obtener();
                sistema.PrimeraSolicitud = primeraSolicitud;
                sistema.OracleDBUExtractConexion = oracleDBUExtractConexion;
                sistema.Estado = new Estado { Id = estadoId };
                sistema.CarpetaTrabajo = carpetaTrabajo;
                sistema.CorreoCMS = correoCMS;
                sistema.ResponderA = responderA;
                sistema.CopiarExcelA = copiarExcelA;
                sistema.FolderPre = folderPre;
                sistema.FolderDML = folderDML;
                sistema.MensajeCrearSolicitud = mensajeCrearSolicitud;

                sr.Actualizar(sistema);
                sistemaView.Sistema = sistema;
                sistemaView.Mensaje = "Datos Actualizados";
                sistemaView.Estados = estados;
                return RedirectToAction("ObtenerSistema", new { mensaje = sistemaView.Mensaje });
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult ObtenerSistema(string mensaje)
        {
            try
            {
                SistemaView sistemaView = new SistemaView();
                SistemaRepository sr = new SistemaRepository();
                EstadoRepository er = new EstadoRepository();
                List<Estado> estados = er.Listar();
                Sistema sistema = sr.Obtener();
                sistemaView.Sistema = sistema;
                sistemaView.Mensaje = mensaje;
                sistemaView.Estados = estados;
                return View("ObtenerSistema", sistemaView);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles="Administrador,CM,RM")]
        public ActionResult CrearCarpeta()
        {
            try
            {
                var sv = new SistemaView();
                return View("CrearCarpeta", sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrador,CM,RM")]
        [HttpPost]
        public ActionResult CrearCarpeta(object datos)
        {
            try
            {
                var rutaOrigen = Request.Form["txtRutaOrigen"]; // \\14.240.4.203\Test\N_SD00037823\tomcat\opt\apache-tomcat-7.0.56\webapps
                // Obtener el 3er slash
                var indice = rutaOrigen.IndexOf("\\", 2);
                var rutaRestante = rutaOrigen.Substring(indice);
                var sr = new SistemaRepository();
                var carpeta = sr.Obtener().FolderDML + rutaRestante;
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                    return View("Mensaje", new HomeView { Mensaje = "Se ha creado la carpeta " + rutaOrigen + " en el servidor." });
                }
                else
                {
                    return View("Mensaje", new HomeView { Mensaje = "Ya existe la carpeta " + rutaOrigen + " en el servidor." });
                }
                
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public ActionResult MatarProcesoExcel()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult MatarProcesoExcel(string id)
        {
            try
            {
                var nombreProceso = "EXCEL";
                if (nombreProceso.Trim() != "")
                {
                    foreach (var p in Process.GetProcessesByName("EXCEL"))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                return View("Mensaje", new SistemaView { Mensaje = "El proceso de EXCEL ha sido matado." });
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SistemaView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles="Administrador")]
        [HttpGet]
        public ActionResult AsignarFormato()
        {
            try
            {
                var ar = new AmbienteRepository();
                var ambientes = ar.Listar("");

                var ger = new AreaRepository();
                var grupos = ger.Listar("");

                var fr = new FormatoRepository();
                var formatos = fr.Listar("");

                var sv = new SistemaView();
                sv.Ambientes = ambientes;
                sv.Grupos = grupos;
                sv.Formatos = formatos;

                return View(sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new SistemaView { Mensaje = ex.Message });
            }
        }
    }
}
