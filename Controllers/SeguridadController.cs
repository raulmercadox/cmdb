using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Repository;
using System.Web.Security;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using Utilitarios;
using System.Text;

namespace CMDBApplication.Controllers
{
    public class SeguridadController : BaseController
    {
        //
        // GET: /Seguridad/

        public ActionResult Ingresar()
        {
            try
            {
                ViewData["returnUrl"] = Request.QueryString["ReturnUrl"];
                return View();
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Ingresar(string returnUrl)
        {
            try
            {
                const string mensaje = "El usuario y/o clave son incorrectos";
                string nombre = Request.Form["txtUsuario"];
                string clave = Request.Form["txtClave"];
                SeguridadRepository repo = new SeguridadRepository();
                Usuario usuario = repo.ObtenerUsuario(nombre);

                if (usuario != null && Encriptador.EncriptarMD5(clave) == usuario.Clave)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuario.Nombre, DateTime.Now, DateTime.Now.AddDays(1),
                        true, usuario.Nombre, FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    Session["estado"] = null;
                    return Redirect(returnUrl);
                }
                else
                {
                    ViewData["mensaje"] = mensaje;
                    ViewData["returnUrl"] = returnUrl;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }

        public ActionResult Salir()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("Mensaje", new HomeView { Mensaje = ex.Message });
            }
        }
    }
}
