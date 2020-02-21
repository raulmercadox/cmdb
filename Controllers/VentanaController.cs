using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.ViewModels;
using CMDBApplication.Repository;
using CMDBApplication.Models;

namespace CMDBApplication.Controllers
{
    public class VentanaController : BaseController
    {
        //
        // GET: /Ventana/

        public ActionResult Index()
        {
            try
            {
                VentanaView vv = new VentanaView();
                VentanaRepository vr = new VentanaRepository();
                List<Ventana> ventanas = vr.Listar();

                vv.Ventana = new Ventana();
                vv.Ventanas = ventanas;

                string mensaje = "";
                if (ventanas.Count == 0)
                {
                    mensaje = "No existen ventanas de ejecución definidas.";
                }
                vv.Mensaje = mensaje;

                return View(vv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new VentanaView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                VentanaView av = new VentanaView();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new VentanaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(VentanaView ambienteView)
        {
            try
            {
                DateTime desde = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,int.Parse(Request.Form["cboHoraDesde"]),int.Parse(Request.Form["cboMinutoDesde"]),0);
                DateTime? hasta = null;
                if (Request.Form["cboHoraHasta"]!="-1" && Request.Form["cboMinutoHasta"]!="-1")
                    hasta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(Request.Form["cboHoraHasta"]), int.Parse(Request.Form["cboMinutoHasta"]), 0);
                
                #region Verificar is ya existe el nombre del ambiente
                VentanaRepository vr = new VentanaRepository();
                Ventana v = vr.Obtener(desde,hasta);
                if (v != null)
                {
                    // Ya existe
                    ambienteView.Ventana.Desde = desde;
                    ambienteView.Ventana.Hasta = hasta;
                    ambienteView.Mensaje = "Ya existe esta ventana";
                    return View("Crear", ambienteView);
                }
                else
                {
                    // Crear
                    v = new Ventana();
                    v.Desde = desde;
                    v.Hasta = hasta;
                    v = vr.Actualizar(v);
                    if (v.Id == 0)
                    {
                        ambienteView.Mensaje = "Hubo un error al crear el ambiente";
                        return View("Crear", ambienteView);
                    }                    
                }
                #endregion
                VentanaView vv = new VentanaView();
                vv.Mensaje = "Ventana Creada";
                return View("Crear", vv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                VentanaView vv = new VentanaView();
                vv.Mensaje = "";
                VentanaRepository vr = new VentanaRepository();
                Ventana v = vr.Obtener(int.Parse(id));
                vv.Ventana = v;
                return View("Obtener", vv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(VentanaView ventanaView)
        {
            try
            {
                string id = Request.Form["txtId"];
                DateTime desde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(Request.Form["cboHoraDesde"]), int.Parse(Request.Form["cboMinutoDesde"]), 0);
                DateTime? hasta = null;
                if (Request.Form["cboHoraHasta"] != "-1" && Request.Form["cboMinutoHasta"] != "-1")
                    hasta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(Request.Form["cboHoraHasta"]), int.Parse(Request.Form["cboMinutoHasta"]), 0);
                

                Ventana v = new Ventana();
                v.Id = int.Parse(id);
                v.Desde = desde;
                v.Hasta = hasta;

                VentanaRepository vr = new VentanaRepository();

                v = vr.Actualizar(v);
                if (v.Id == 0)
                {
                    ventanaView.Mensaje = "Hubo un error al crear la ventana";
                    return View("Obtener", ventanaView);
                }

                VentanaView vv = new VentanaView();
                vv.Mensaje = "Ventana Actualizada";
                vv.Ventana = v;
                return View("Obtener", vv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new VentanaView { Mensaje = ex.Message });
            }
        }

    }
}
