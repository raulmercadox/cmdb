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
    public class ResponsableController : BaseController
    {
        //
        // GET: /Responsable/

        public ActionResult Index()
        {
            try
            {
                ResponsableView av = new ResponsableView();
                av.Responsable = new Responsable();
                av.Responsables = new List<Responsable>();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ResponsableView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(ResponsableView rv)
        {
            try
            {
                string nombreResponsable = Request.Form["txtNombreResponsable"];

                ResponsableRepository ar = new ResponsableRepository();
                List<Responsable> responsables = ar.Listar(nombreResponsable);

                rv.Responsable = new Responsable();
                rv.Responsable.Nombre = nombreResponsable;
                rv.Responsables = responsables;

                string mensaje = "";
                if (responsables.Count == 0)
                {
                    mensaje = "No existen gerencias para el criterio de búsqueda";
                }
                rv.Mensaje = mensaje;

                return View(rv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                ResponsableView av = new ResponsableView();
                av.Responsable = new Responsable();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ResponsableView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(ResponsableView responsableView)
        {
            try
            {
                string nombreResponsable = Request.Form["txtNombreResponsable"];

                #region Verificar is ya existe el nombre del responsable
                ResponsableRepository rr = new ResponsableRepository();
                Responsable r = rr.Obtener(nombreResponsable.Trim());
                if (r != null)
                {
                    responsableView.Responsable.Nombre = nombreResponsable;
                    return View("Nuevo", responsableView);
                }
                else
                {
                    r = new Responsable();
                    r.Nombre = nombreResponsable;
                    r = rr.Actualizar(r);
                    if (r.Id == 0)
                    {
                        responsableView.Mensaje = "Hubo un error al crear la gerencia";
                        return View("Crear", responsableView);
                    }
                    //proyectoView.Proyecto = p;
                }
                #endregion
                ResponsableView rv = new ResponsableView();
                rv.Responsable = r;
                rv.Mensaje = "Gerencia creada";
                return View("Crear", rv);
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
                ResponsableView rv = new ResponsableView();
                rv.Mensaje = "";
                ResponsableRepository ar = new ResponsableRepository();
                Responsable r = ar.Obtener(int.Parse(id));
                ProyectoRepository pr = new ProyectoRepository();
                r.Proyectos = pr.Listar(String.Empty, String.Empty, String.Empty, String.Empty, ' ', r.Id,false,String.Empty,0);
                rv.Responsable = r;
                return View("Obtener", rv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ResponsableView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(ResponsableView responsableView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreResponsable = Request.Form["txtNombreResponsable"];

                Responsable r = new Responsable();
                r.Id = int.Parse(id);
                r.Nombre = nombreResponsable;

                ResponsableRepository rr = new ResponsableRepository();

                r = rr.Actualizar(r);
                if (r.Id == 0)
                {
                    responsableView.Mensaje = "Hubo un error al actualizar la gerencia";
                    return View("Crear", responsableView);
                }

                ResponsableView pp = new ResponsableView();
                pp.Mensaje = "Gerencia Actualizada";
                pp.Responsable = r;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

    }
}
