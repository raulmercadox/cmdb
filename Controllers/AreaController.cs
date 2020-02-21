using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.ViewModels;
using CMDBApplication.Models;
using CMDBApplication.Repository;

namespace CMDBApplication.Controllers
{
    public class AreaController : BaseController
    {
        //
        // GET: /Area/

        public ActionResult Index()
        {
            try
            {
                AreaView areaView = new AreaView();
                return View(areaView);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(AreaView av)
        {
            try
            {
                string nombreArea = Request.Form["txtNombreArea"];

                AreaRepository pr = new AreaRepository();
                List<Area> Areas = pr.Listar(nombreArea);

                av.Area = new Area();
                av.Area.Nombre = nombreArea;
                av.Areas = Areas;

                string mensaje = "";
                if (Areas.Count == 0)
                {
                    mensaje = "No existen Areas para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                AreaView pv = new AreaView();
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(AreaView AreaView)
        {
            try
            {
                string nombreArea = Request.Form["txtNombreArea"];
                string color = Request.Form["txtColor"];
                string abreviatura = Request.Form["txtAbreviatura"];

                #region Verificar is ya existe el código del Area
                AreaRepository ar = new AreaRepository();
                Area a = ar.Obtener(nombreArea);
                if (a != null)
                {
                    AreaView.Area.Nombre = nombreArea;
                    AreaView.Mensaje = "El código del Area ya existe";
                    return View("Crear", AreaView);
                }
                else
                {
                    a = new Area();
                    a.Nombre = nombreArea;
                    a.Color = color;
                    a.Abreviatura = abreviatura;
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        AreaView.Mensaje = "Hubo un error al crear el Area";
                        return View("Crear", AreaView);
                    }
                }
                #endregion
                AreaView pp = new AreaView();
                pp.Mensaje = "Area Creada";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                AreaView pv = new AreaView();
                pv.Mensaje = "";
                AreaRepository pr = new AreaRepository();
                Area a = pr.Obtener(int.Parse(id));
                pv.Area = a;
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(AreaView AreaView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreArea = Request.Form["txtNombreArea"];
                string color = Request.Form["txtColor"];
                string abreviatura = Request.Form["txtAbreviatura"];

                Area a = new Area();
                a.Id = int.Parse(id);
                a.Nombre = nombreArea;
                a.Color = color;
                a.Abreviatura = abreviatura;

                // Correos
                List<string> nombres = Request.Form.AllKeys.ToList().Where(param => param.Contains("direccioncorreo")).ToList();
                foreach (string nombre in nombres)
                {
                    string indice = nombre.Substring("direccioncorreo".Length);
                    string direccionCorreo = Request.Form["direccioncorreo" + indice];
                    if (!String.IsNullOrEmpty(Request.Form["hdId" + indice]) || Request.Form["eliminadocorreo" + indice] == "0")
                    {
                        a.Correos.Add(new Correo
                        {
                            Id = String.IsNullOrEmpty(Request.Form["hdId" + indice]) ? 0 : Convert.ToInt32(Request.Form["hdId" + indice]),
                            Direccion = direccionCorreo,
                            Eliminar = Request.Form["eliminadocorreo" + indice] == "1"
                        });
                    }
                }

                AreaRepository pr = new AreaRepository();

                a = pr.Actualizar(a);
                if (a.Id == 0)
                {
                    AreaView.Mensaje = "Hubo un error al crear el Area";
                    return View("Crear", AreaView);
                }

                AreaView pp = new AreaView();
                pp.Mensaje = "Area Actualizada";
                pp.Area = a;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AreaView { Mensaje = ex.Message });
            }
        }
    }
}
