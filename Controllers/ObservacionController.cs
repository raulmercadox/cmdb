using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using CMDBApplication.Repository;

namespace CMDBApplication.Controllers
{
    public class ObservacionController : BaseController
    {
        //
        // GET: /Observacion/

        public ActionResult Index()
        {
            try
            {
                ObservacionView ObservacionView = new ObservacionView();
                return View(ObservacionView);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(ObservacionView av)
        {
            try
            {
                string nombreObservacion = Request.Form["txtNombreObservacion"];

                ObservacionRepository pr = new ObservacionRepository();
                List<Observacion> Observacions = pr.Listar(nombreObservacion);

                av.Observacion = new Observacion();
                av.Observacion.Nombre = nombreObservacion;
                av.Observaciones = Observacions;

                string mensaje = "";
                if (Observacions.Count == 0)
                {
                    mensaje = "No existen Observaciones para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                ObservacionView pv = new ObservacionView();
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(ObservacionView ObservacionView)
        {
            try
            {
                string nombreObservacion = Request.Form["txtNombreObservacion"];

                #region Verificar is ya existe el código del Observacion
                ObservacionRepository ar = new ObservacionRepository();
                Observacion a = ar.Obtener(nombreObservacion);
                if (a != null)
                {
                    ObservacionView.Observacion.Nombre = nombreObservacion;
                    ObservacionView.Mensaje = "El código del Observacion ya existe";
                    return View("Crear", ObservacionView);
                }
                else
                {
                    a = new Observacion();
                    a.Nombre = nombreObservacion;
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        ObservacionView.Mensaje = "Hubo un error al crear el Observacion";
                        return View("Crear", ObservacionView);
                    }
                }
                #endregion
                ObservacionView pp = new ObservacionView();
                pp.Mensaje = "Observacion Creada";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                ObservacionView pv = new ObservacionView();
                pv.Mensaje = "";
                ObservacionRepository pr = new ObservacionRepository();
                Observacion a = pr.Obtener(int.Parse(id));
                pv.Observacion = a;
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(ObservacionView ObservacionView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreObservacion = Request.Form["txtNombreObservacion"];

                Observacion a = new Observacion();
                a.Id = int.Parse(id);
                a.Nombre = nombreObservacion;

                ObservacionRepository pr = new ObservacionRepository();

                a = pr.Actualizar(a);
                if (a.Id == 0)
                {
                    ObservacionView.Mensaje = "Hubo un error al crear la Observacion";
                    return View("Crear", ObservacionView);
                }

                ObservacionView pp = new ObservacionView();
                pp.Mensaje = "Observacion Actualizada";
                pp.Observacion = a;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ObservacionView { Mensaje = ex.Message });
            }
        }

    }
}
