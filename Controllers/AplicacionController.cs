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
    public class AplicacionController : BaseController
    {
        //
        // GET: /Aplicacion/

        public ActionResult Index()
        {
            try
            {
                AplicacionView av = new AplicacionView();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AplicacionView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(AplicacionView av)
        {
            try
            {
                string nombre = Request.Form["txtNombre"];
                string ruta = Request.Form["txtRutaSVN"];
                string herramienta = Request.Form["txtHerramienta"];
                string version = Request.Form["txtVersion"];
                char estado = Request.Form["cboEstado"].ToCharArray()[0];

                AplicacionRepository ar = new AplicacionRepository();
                List<Aplicacion> aplicaciones = ar.Listar(nombre, ruta, herramienta, version, estado);

                av.Aplicacion = new Aplicacion();
                av.Aplicacion.Nombre = nombre;
                av.Aplicacion.RutaSVN = ruta;
                av.Aplicacion.Herramienta = herramienta;
                av.Aplicacion.Version = version;
                av.Aplicacion.Estado = estado;
                av.Aplicaciones = aplicaciones;

                string mensaje = "";
                if (aplicaciones.Count == 0)
                {
                    mensaje = "No existen Proyectos para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AplicacionView { Mensaje = ex.Message });
            }
        }

    }
}