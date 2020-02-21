using CMDBApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Models;
using CMDBApplication.Repository;

namespace CMDBApplication.Controllers
{
    public class TipoProyectoController : BaseController
    {
        //
        // GET: /TipoProyecto/

        public ActionResult Index()
        {
            try
            {
                TipoProyectoView vm = new TipoProyectoView();
                vm.TipoProyecto = new TipoProyecto();
                vm.TipoProyectos = new List<TipoProyecto>();

                return View(vm);
            }
            catch (Exception ex)
            {
                TipoProyectoView vm = new TipoProyectoView();
                vm.Mensaje = ex.Message;
                return View("Mensaje", vm);
            }
        }

        [HttpPost]
        public ActionResult Index(TipoProyectoView av)
        {
            try
            {
                string nombreTipoProyecto = Request.Form["txtNombreTipoProyecto"];

                TipoProyectoRepository pr = new TipoProyectoRepository();
                List<TipoProyecto> TipoProyectos = pr.Listar(nombreTipoProyecto);

                av.TipoProyecto = new TipoProyecto();
                av.TipoProyecto.Nombre = nombreTipoProyecto;
                av.TipoProyectos = TipoProyectos;

                string mensaje = "";
                if (TipoProyectos.Count == 0)
                {
                    mensaje = "No existen Tipos de Proyecto para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoProyectoView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                TipoProyectoView pv = new TipoProyectoView();
                pv.TipoProyecto = new TipoProyecto();
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(TipoProyectoView TipoProyectoView)
        {
            try
            {
                string nombreTipoProyecto = Request.Form["txtNombreTipoProyecto"];

                #region Verificar is ya existe el código del TipoProyecto
                TipoProyectoRepository ar = new TipoProyectoRepository();
                TipoProyecto a = ar.Obtener(nombreTipoProyecto);
                if (a != null)
                {
                    TipoProyectoView.TipoProyecto.Nombre = nombreTipoProyecto;
                    TipoProyectoView.Mensaje = "El nombre de tipo de proyecto ya existe";
                    return View("Crear", TipoProyectoView);
                }
                else
                {
                    a = new TipoProyecto();
                    a.Nombre = nombreTipoProyecto;
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        TipoProyectoView.Mensaje = "Hubo un error al crear el Tipo de Proyecto";
                        return View("Crear", TipoProyectoView);
                    }
                }
                #endregion
                TipoProyectoView pp = new TipoProyectoView();
                pp.TipoProyecto = a;
                pp.Mensaje = "Tipo de Proyecto creado";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoProyectoView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                TipoProyectoView pv = new TipoProyectoView();
                pv.Mensaje = "";
                TipoProyectoRepository pr = new TipoProyectoRepository();
                TipoProyecto a = pr.Obtener(int.Parse(id));
                pv.TipoProyecto = a;
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoProyectoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(TipoProyectoView TipoProyectoView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreTipoProyecto = Request.Form["txtNombreTipoProyecto"];

                TipoProyecto a = new TipoProyecto();
                a.Id = int.Parse(id);
                a.Nombre = nombreTipoProyecto;

                TipoProyectoRepository pr = new TipoProyectoRepository();

                a = pr.Actualizar(a);
                if (a.Id == 0)
                {
                    TipoProyectoView.Mensaje = "Hubo un error al crear el Tipo de Proyecto";
                    return View("Crear", TipoProyectoView);
                }

                TipoProyectoView pp = new TipoProyectoView();
                pp.Mensaje = "Tipo de Proyecto Actualizado";
                pp.TipoProyecto = a;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoProyectoView { Mensaje = ex.Message });
            }
        }

    }
}
