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
    public class RolController : BaseController
    {
        //
        // GET: /Rol/

        public ActionResult Index()
        {
            try
            {
                RolView dcv = new RolView();
                return View(dcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(RolView dcv)
        {
            try
            {
                string nombreRol = Request.Form["txtNombreRol"];

                RolRepository dr = new RolRepository();
                List<Rol> Roles = dr.Listar(nombreRol);

                dcv.Rol = new Rol();
                dcv.Rol.Nombre = nombreRol;
                dcv.Roles = Roles;

                string mensaje = "";
                if (Roles.Count == 0)
                {
                    mensaje = "No existen Roles para el criterio de búsqueda";
                }
                dcv.Mensaje = mensaje;

                return View(dcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                RolView dv = new RolView();
                return View(dv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(RolView RolView)
        {
            try
            {
                string nombreRol = Request.Form["txtNombreRol"];

                #region Verificar is ya existe el código del Rol
                RolRepository dr = new RolRepository();
                Rol d = dr.ObtenerPorNombre(nombreRol.Trim());
                if (d != null)
                {
                    RolView.Rol.Nombre = nombreRol;
                    RolView.Mensaje = "El código del Rol ya existe";
                    return View("Crear", RolView);
                }
                else
                {
                    d = new Rol();
                    d.Nombre = nombreRol;
                    d = dr.Actualizar(d);
                    if (d.Id == 0)
                    {
                        RolView.Mensaje = "Hubo un error al crear el Rol";
                        return View("Crear", RolView);
                    }
                }
                #endregion
                RolView pp = new RolView();
                pp.Mensaje = "Rol Creado";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                RolView dv = new RolView();
                dv.Mensaje = "";
                RolRepository dr = new RolRepository();
                Rol p = dr.Obtener(id);
                dv.Rol = p;
                return View("Obtener", dv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

        public JsonResult Listar(string id)
        {
            RolRepository dr = new RolRepository();
            List<Rol> Roles = dr.Listar(id);

            //string resultado = JsonConvert.SerializeObject(Roles);

            return Json(Roles, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(RolView RolView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string usuarioRol = Request.Form["txtUsuarioRol"];
                string nombreRol = Request.Form["txtNombreRol"];
                string correoRol = Request.Form["txtCorreoRol"];
                string claveRol = Request.Form["txtClaveRol"];

                Rol d = new Rol();
                d.Id = int.Parse(id);
                d.Nombre = nombreRol;

                RolRepository dr = new RolRepository();

                d = dr.Actualizar(d);
                if (d.Id == 0)
                {
                    RolView.Mensaje = "Hubo un error al crear el Rol";
                    return View("Crear", RolView);
                }

                RolView dd = new RolView();
                dd.Mensaje = "Rol Actualizado";
                dd.Rol = d;
                return View("Obtener", dd);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new RolView { Mensaje = ex.Message });
            }
        }

    }
}
