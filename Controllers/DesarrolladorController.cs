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
    public class DesarrolladorController : BaseController
    {
        //
        // GET: /Desarrollador/

        public ActionResult Index()
        {
            try
            {
                DesarrolladorView dcv = new DesarrolladorView();
                return View(dcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(DesarrolladorView dcv)
        {
            try
            {
                string nombreDesarrollador = Request.Form["txtNombreDesarrollador"];
                string correoDesarrollador = Request.Form["txtCorreoDesarrollador"];
                string usuarioDesarrollador = Request.Form["txtUsuarioDesarrollador"];
                string claveDesarrollador = Request.Form["txtClaveDesarrollador"];

                DesarrolladorRepository dr = new DesarrolladorRepository();
                List<Desarrollador> desarrolladores = dr.Listar(usuarioDesarrollador, nombreDesarrollador, correoDesarrollador, claveDesarrollador);

                dcv.Desarrollador = new Desarrollador();
                dcv.Desarrollador.Usuario = usuarioDesarrollador;
                dcv.Desarrollador.Nombre = nombreDesarrollador;
                dcv.Desarrollador.Correo = correoDesarrollador;
                dcv.Desarrollador.Clave = claveDesarrollador;
                dcv.Desarrolladores = desarrolladores;

                string mensaje = "";
                if (desarrolladores.Count == 0)
                {
                    mensaje = "No existen Desarrolladores para el criterio de búsqueda";
                }
                dcv.Mensaje = mensaje;

                return View(dcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                DesarrolladorView dv = new DesarrolladorView();
                return View(dv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(DesarrolladorView desarrolladorView)
        {
            try
            {
                string usuarioDesarrollador = Request.Form["txtUsuarioDesarrollador"];
                string nombreDesarrollador = Request.Form["txtNombreDesarrollador"];
                string correoDesarrollador = Request.Form["txtCorreoDesarrollador"];
                string claveDesarrollador = Request.Form["txtClaveDesarrollador"];

                #region Verificar is ya existe el código del desarrollador
                DesarrolladorRepository dr = new DesarrolladorRepository();
                Desarrollador d = dr.Obtener(usuarioDesarrollador.Trim());
                if (d != null)
                {
                    desarrolladorView.Desarrollador.Usuario = usuarioDesarrollador;
                    desarrolladorView.Desarrollador.Nombre = nombreDesarrollador;
                    desarrolladorView.Desarrollador.Correo = correoDesarrollador;
                    desarrolladorView.Desarrollador.Clave = claveDesarrollador;
                    desarrolladorView.Mensaje = "El código del desarrollador ya existe";
                    return View("Crear", desarrolladorView);
                }
                else
                {
                    d = new Desarrollador();
                    d.Usuario = usuarioDesarrollador;
                    d.Nombre = nombreDesarrollador;
                    d.Correo = correoDesarrollador;
                    d.Clave = claveDesarrollador;
                    d = dr.Actualizar(d);
                    if (d.Id == 0)
                    {
                        desarrolladorView.Mensaje = "Hubo un error al crear el desarrollador";
                        return View("Crear", desarrolladorView);
                    }
                }
                #endregion
                DesarrolladorView pp = new DesarrolladorView();
                pp.Mensaje = "Desarrollador Creado";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                DesarrolladorView dv = new DesarrolladorView();
                dv.Mensaje = "";
                DesarrolladorRepository dr = new DesarrolladorRepository();
                Desarrollador p = dr.Obtener(id);
                dv.Desarrollador = p;
                return View("Obtener", dv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }

        public JsonResult Listar(string id)
        {
            DesarrolladorRepository dr = new DesarrolladorRepository();
            List<Desarrollador> desarrolladores = dr.Listar(id);

            //string resultado = JsonConvert.SerializeObject(desarrolladores);

            return Json(desarrolladores, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(DesarrolladorView desarrolladorView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string usuarioDesarrollador = Request.Form["txtUsuarioDesarrollador"];
                string nombreDesarrollador = Request.Form["txtNombreDesarrollador"];
                string correoDesarrollador = Request.Form["txtCorreoDesarrollador"];
                string claveDesarrollador = Request.Form["txtClaveDesarrollador"];

                Desarrollador d = new Desarrollador();
                d.Id = int.Parse(id);
                d.Usuario = usuarioDesarrollador;
                d.Nombre = nombreDesarrollador;
                d.Correo = correoDesarrollador;
                d.Clave = claveDesarrollador;


                DesarrolladorRepository dr = new DesarrolladorRepository();

                d = dr.Actualizar(d);
                if (d.Id == 0)
                {
                    desarrolladorView.Mensaje = "Hubo un error al crear el desarrollador";
                    return View("Crear", desarrolladorView);
                }

                DesarrolladorView dd = new DesarrolladorView();
                dd.Mensaje = "Desarrollador Actualizado";
                dd.Desarrollador = d;
                return View("Obtener", dd);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new DesarrolladorView { Mensaje = ex.Message });
            }
        }
    }
}
