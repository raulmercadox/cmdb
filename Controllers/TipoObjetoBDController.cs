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
    public class TipoObjetoBDController : BaseController
    {
        //
        // GET: /TipoObjetoBD/

        public ActionResult Index()
        {
            try
            {
                TipoObjetoBDView tipoObjetoBDView = new TipoObjetoBDView();
                return View(tipoObjetoBDView);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(TipoObjetoBDView av)
        {
            try
            {
                string nombreTipoObjetoBD = Request.Form["txtNombreTipoObjetoBD"];

                TipoObjetoBDRepository pr = new TipoObjetoBDRepository();
                List<TipoObjetoBD> TipoObjetoBDs = pr.Listar(nombreTipoObjetoBD);

                av.TipoObjetoBD = new TipoObjetoBD();
                av.TipoObjetoBD.Nombre = nombreTipoObjetoBD;
                av.TipoObjetoBDs = TipoObjetoBDs;

                string mensaje = "";
                if (TipoObjetoBDs.Count == 0)
                {
                    mensaje = "No existen Tipos de Objeto de BD para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                TipoObjetoBDView pv = new TipoObjetoBDView();
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(TipoObjetoBDView tipoObjetoBDView)
        {
            try
            {
                string nombreTipoObjetoBD = Request.Form["txtNombreTipoObjetoBD"];
                string extension = Request.Form["txtExtension"];

                #region Verificar is ya existe el código del TipoObjetoBD
                TipoObjetoBDRepository ar = new TipoObjetoBDRepository();
                TipoObjetoBD a = ar.Obtener(nombreTipoObjetoBD);
                if (a != null)
                {
                    tipoObjetoBDView.TipoObjetoBD.Nombre = nombreTipoObjetoBD;
                    tipoObjetoBDView.TipoObjetoBD.Extension = extension;
                    tipoObjetoBDView.Mensaje = "El código del Tipo de Objeto de BD ya existe";
                    return View("Crear", tipoObjetoBDView);
                }
                else
                {
                    a = new TipoObjetoBD();
                    a.Nombre = nombreTipoObjetoBD;
                    a.Extension = extension;
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        tipoObjetoBDView.Mensaje = "Hubo un error al crear el TipoObjetoBD";
                        return View("Crear", tipoObjetoBDView);
                    }
                }
                #endregion
                TipoObjetoBDView pp = new TipoObjetoBDView();
                pp.Mensaje = "Tipo de Objeto de BD Creada";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                TipoObjetoBDView pv = new TipoObjetoBDView();
                pv.Mensaje = "";
                TipoObjetoBDRepository pr = new TipoObjetoBDRepository();
                TipoObjetoBD a = pr.Obtener(int.Parse(id));
                pv.TipoObjetoBD = a;
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(TipoObjetoBDView TipoObjetoBDView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreTipoObjetoBD = Request.Form["txtNombreTipoObjetoBD"];
                string extension = Request.Form["txtExtension"];

                TipoObjetoBD a = new TipoObjetoBD();
                a.Id = int.Parse(id);
                a.Nombre = nombreTipoObjetoBD;
                a.Extension = extension;

                TipoObjetoBDRepository pr = new TipoObjetoBDRepository();

                a = pr.Actualizar(a);
                if (a.Id == 0)
                {
                    TipoObjetoBDView.Mensaje = "Hubo un error al crear la TipoObjetoBD";
                    return View("Crear", TipoObjetoBDView);
                }

                TipoObjetoBDView pp = new TipoObjetoBDView();
                pp.Mensaje = "Tipo de Objeto de BD Actualizada";
                pp.TipoObjetoBD = a;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new TipoObjetoBDView { Mensaje = ex.Message });
            }
        }

    }
}
