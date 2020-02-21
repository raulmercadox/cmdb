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
    public class TipoAccionBDController : BaseController
    {
        //
        // GET: /TipoAccionBD/

        public ActionResult Index()
        {
            try
            {
                TipoAccionBDView TipoAccionBDView = new TipoAccionBDView();
                return View(TipoAccionBDView);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(TipoAccionBDView av)
        {
            try
            {
                string nombreTipoAccionBD = Request.Form["txtNombreTipoAccionBD"];

                TipoAccionBDRepository pr = new TipoAccionBDRepository();
                List<TipoAccionBD> TipoAccionBDs = pr.Listar(nombreTipoAccionBD);

                av.TipoAccionBD = new TipoAccionBD();
                av.TipoAccionBD.Nombre = nombreTipoAccionBD;
                av.TipoAccionBDs = TipoAccionBDs;

                string mensaje = "";
                if (TipoAccionBDs.Count == 0)
                {
                    mensaje = "No existen Tipos de Objeto de BD para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                TipoAccionBDView pv = new TipoAccionBDView();
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(TipoAccionBDView TipoAccionBDView)
        {
            try
            {
                string nombreTipoAccionBD = Request.Form["txtNombreTipoAccionBD"];

                #region Verificar is ya existe el código del TipoAccionBD
                TipoAccionBDRepository ar = new TipoAccionBDRepository();
                TipoAccionBD a = ar.Obtener(nombreTipoAccionBD);
                if (a != null)
                {
                    TipoAccionBDView.TipoAccionBD.Nombre = nombreTipoAccionBD;
                    TipoAccionBDView.Mensaje = "El código del Tipo de Objeto de BD ya existe";
                    return View("Crear", TipoAccionBDView);
                }
                else
                {
                    a = new TipoAccionBD();
                    a.Nombre = nombreTipoAccionBD;
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        TipoAccionBDView.Mensaje = "Hubo un error al crear el TipoAccionBD";
                        return View("Crear", TipoAccionBDView);
                    }
                }
                #endregion
                TipoAccionBDView pp = new TipoAccionBDView();
                pp.Mensaje = "Tipo de Objeto de BD Creada";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                TipoAccionBDView pv = new TipoAccionBDView();
                pv.Mensaje = "";
                TipoAccionBDRepository pr = new TipoAccionBDRepository();
                TipoAccionBD a = pr.Obtener(int.Parse(id));
                pv.TipoAccionBD = a;
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(TipoAccionBDView TipoAccionBDView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreTipoAccionBD = Request.Form["txtNombreTipoAccionBD"];

                TipoAccionBD a = new TipoAccionBD();
                a.Id = int.Parse(id);
                a.Nombre = nombreTipoAccionBD;

                TipoAccionBDRepository pr = new TipoAccionBDRepository();

                a = pr.Actualizar(a);
                if (a.Id == 0)
                {
                    TipoAccionBDView.Mensaje = "Hubo un error al crear la TipoAccionBD";
                    return View("Crear", TipoAccionBDView);
                }

                TipoAccionBDView pp = new TipoAccionBDView();
                pp.Mensaje = "Tipo de Objeto de BD Actualizada";
                pp.TipoAccionBD = a;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoAccionBDView { Mensaje = ex.Message });
            }
        }

    }
}
