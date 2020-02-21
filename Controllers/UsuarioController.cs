using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Repository;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using System.Web.Security;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using Utilitarios;

namespace CMDBApplication.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                UsuarioView uv = new UsuarioView();
                uv.UsuarioLogueado = ObtenerUsuario();
                return View(uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        private bool EvaluarCheckBox(string nombreCheckBox)
        {
            return (!String.IsNullOrEmpty(Request.Form[nombreCheckBox]) && Request.Form[nombreCheckBox] == "on");
        }

        [HttpPost]
        public ActionResult Index(UsuarioView uv)
        {
            try
            {
                string usuario = Request.Form["txtUsuarioUsuario"];
                string correo = Request.Form["txtCorreoUsuario"];

                bool administrador = EvaluarCheckBox("chkAdministradorUsuario");
                bool operador = EvaluarCheckBox("chkOperadorUsuario");
                bool lector = EvaluarCheckBox("chkLectorUsuario");
                bool cm = EvaluarCheckBox("chkCMUsuario");
                bool rm = EvaluarCheckBox("chkRMUsuario");
                bool ejecutor = EvaluarCheckBox("chkEjecutorUsuario");
                bool test = EvaluarCheckBox("chkTestUsuario");

                UsuarioRepository pr = new UsuarioRepository();
                List<Usuario> Usuarios = pr.Listar(usuario, correo, administrador, operador, lector, cm, rm, ejecutor, test);

                uv.Usuario = new Usuario();
                uv.Usuario.Nombre = usuario;
                uv.Usuario.Correo = correo;
                uv.Usuario.Administrador = administrador;
                uv.Usuario.Operador = operador;
                uv.Usuario.Lector = lector;
                uv.Usuario.CM = cm;
                uv.Usuario.RM = rm;
                uv.Usuario.Ejecutor = ejecutor;
                uv.Usuario.Test = test;
                uv.Usuarios = Usuarios;

                string mensaje = "";
                if (Usuarios.Count == 0)
                {
                    mensaje = "No existen Usuarios para el criterio de búsqueda";
                }
                uv.Mensaje = mensaje;
                uv.UsuarioLogueado = ObtenerUsuario();
                return View(uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                UsuarioView pv = new UsuarioView();                
                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(UsuarioView UsuarioView)
        {
            try
            {
                SistemaRepository sr = new SistemaRepository();
                string usuarioUsuario = Request.Form["txtUsuarioUsuario"];
                string correoUsuario = Request.Form["txtCorreoUsuario"];
                string claveUsuario = Request.Form["txtClaveUsuario"];
                string celular = Request.Form["txtCelular"];
                string anexo = Request.Form["txtAnexo"];
                string skype = Request.Form["txtSkype"];

                bool administrador = EvaluarCheckBox("chkAdministradorUsuario");
                bool operador = EvaluarCheckBox("chkOperadorUsuario");
                bool lector = EvaluarCheckBox("chkLectorUsuario");
                bool cm = EvaluarCheckBox("chkCMUsuario");
                bool rm = EvaluarCheckBox("chkRMUsuario");
                bool ejecutor = EvaluarCheckBox("chkEjecutorUsuario");
                bool test = EvaluarCheckBox("chkTestUsuario");

                #region Verificar is ya existe el código del Usuario
                UsuarioRepository pr = new UsuarioRepository();
                Usuario p = pr.Obtener(usuarioUsuario.Trim());

                if (p != null)
                {
                    UsuarioView.Usuario.Nombre = usuarioUsuario;
                    UsuarioView.Usuario.Correo = correoUsuario;
                    UsuarioView.Usuario.Clave = Encriptador.EncriptarMD5(claveUsuario);
                    UsuarioView.Usuario.Administrador = administrador;
                    UsuarioView.Usuario.Operador = operador;
                    UsuarioView.Usuario.Lector = lector;
                    UsuarioView.Usuario.CM = cm;
                    UsuarioView.Usuario.RM = rm;
                    UsuarioView.Usuario.Ejecutor = ejecutor;
                    UsuarioView.Usuario.Test = test;
                    UsuarioView.Usuario.Celular = celular;
                    UsuarioView.Usuario.Anexo = anexo;
                    UsuarioView.Usuario.Skype = skype;

                    UsuarioView.Mensaje = "El nombre del Usuario ya existe";
                    return View("Crear", UsuarioView);
                }
                else
                {
                    p = new Usuario();
                    p.Nombre = usuarioUsuario;
                    p.Correo = correoUsuario;
                    p.Clave = Encriptador.EncriptarMD5(claveUsuario);
                    p.Administrador = administrador;
                    p.Operador = operador;
                    p.Lector = lector;
                    p.CM = cm;
                    p.RM = rm;
                    p.Ejecutor = ejecutor;
                    p.Test = test;
                    p.Celular = celular;
                    p.Anexo = anexo;
                    p.Skype = skype;

                    p = pr.Actualizar(p);
                    if (p.Id == 0)
                    {
                        UsuarioView.Mensaje = "Hubo un error al crear el Usuario";
                        return View("Crear", UsuarioView);
                    }
                    if (Request.Form["chkEnviarCorreo"] == "on")
                    {
                        SmtpClient client = new SmtpClient();
                        MailMessage mm = new MailMessage();
                        string correoCMS = sr.Obtener().CorreoCMS;
                        mm.From = new MailAddress(correoCMS, "Configuration Management System");
                        mm.To.Add(p.Correo);
                        mm.Subject = "Credenciales de acceso al CMS";
                        mm.IsBodyHtml = true;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<p>Estas son sus credenciales de acceso al CMS</p>");
                        sb.Append("<p>Usuario: " + p.Nombre + "</p>");
                        sb.Append("<p>Clave: " + claveUsuario + "</p>");
                        string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                        sb.Append("<p>Ruta CMS: <a href='" + url + "'>" + url + "</a></p>");
                        mm.Body = sb.ToString();
                        client.Send(mm);
                    }
                }
                #endregion
                UsuarioView pp = new UsuarioView();
                pp.Mensaje = "Usuario Creado";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                UsuarioView pv = new UsuarioView();
                pv.Mensaje = "";
                UsuarioRepository pr = new UsuarioRepository();
                Usuario p = pr.Obtener(id);
                SolicitudRepository sr = new SolicitudRepository();                
                p.Solicitudes = sr.ListarPorSolicitante(p.Id);
                pv.Usuario = p;
                pv.Roles = new RolRepository().Listar("");
                pv.UsuarioLogueado = ObtenerUsuario();
                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(UsuarioView UsuarioView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string usuarioUsuario = Request.Form["txtUsuarioUsuario"];
                string correoUsuario = Request.Form["txtCorreoUsuario"];
                string celular = Request.Form["txtCelular"];
                string anexo = Request.Form["txtAnexo"];
                string skype = Request.Form["txtSkype"];

                bool administrador = EvaluarCheckBox("chkAdministradorUsuario");
                bool operador = EvaluarCheckBox("chkOperadorUsuario");
                bool lector = EvaluarCheckBox("chkLectorUsuario");
                bool cm = EvaluarCheckBox("chkCMUsuario");
                bool rm = EvaluarCheckBox("chkRMUsuario");
                bool ejecutor = EvaluarCheckBox("chkEjecutorUsuario");
                bool test = EvaluarCheckBox("chkTestUsuario");

                Usuario p = new Usuario();
                p.Id = int.Parse(id);
                p.Nombre = usuarioUsuario;
                p.Correo = correoUsuario;
                p.Administrador = administrador;
                p.Operador = operador;
                p.Lector = lector;
                p.CM = cm;
                p.RM = rm;
                p.Ejecutor = ejecutor;
                p.Test = test;
                p.Celular = celular;
                p.Anexo = anexo;
                p.Skype = skype;

                UsuarioRepository pr = new UsuarioRepository();

                p = pr.Actualizar(p);
                if (p.Id == 0)
                {
                    UsuarioView.Mensaje = "Hubo un error al crear el Usuario";
                    return View("Crear", UsuarioView);
                }

                UsuarioView pp = new UsuarioView();
                pp.Mensaje = "Usuario Actualizado";
                pp.Usuario = p;
                SolicitudRepository sr = new SolicitudRepository();
                pp.Usuario.Solicitudes = sr.ListarPorSolicitante(p.Id);
                pp.Roles = new RolRepository().Listar("");
                pp.UsuarioLogueado = ObtenerUsuario();
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }

        }

        [Authorize]
        public ActionResult CambiarClave()
        {
            try
            {
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);
                UsuarioView uv = new UsuarioView();
                uv.Usuario = usuario;

                return View(uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult CambiarClave(string id)
        {
            try
            {
                UsuarioView uv = new UsuarioView();
                int usuarioId = int.Parse(Request.Form["id"]);
                Usuario usuario = ObtenerUsuario();
                if (usuario.Id == usuarioId)
                {
                    string clave = Request.Form["txtClave"];
                    string claveEncriptada = Encriptador.EncriptarMD5(clave);
                    UsuarioRepository ur = new UsuarioRepository();
                    if (ur.CambiarClave(usuarioId, claveEncriptada))
                    {
                        uv.Mensaje = "Se cambió la clave satisfactoriamente.";
                    }
                    else
                    {
                        uv.Mensaje = "Hubo un problema al cambiar la clave.";
                    }
                }
                else
                {
                    uv.Mensaje = "Se ha alterado la página de origen.";
                }
                return View("Mensaje", uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", ex.Message);
            }
        }

        

        public ActionResult RecuperarClave()
        {
            try
            {
                UsuarioView uv = new UsuarioView();
                return View(uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult RecuperarClave(string id)
        {
            try
            {
                SistemaRepository sr = new SistemaRepository();
                UsuarioView uv = new UsuarioView();
                UsuarioRepository ur = new UsuarioRepository();
                string nombreUsuario = Request.Form["txtUsuario"];
                Usuario u = ur.Obtener(nombreUsuario);
                if (u == null)
                {
                    uv.Mensaje = "El usuario especificado no existe en el sistema.";
                }
                else
                {
                    string correo = u.Correo;
                    string token = Guid.NewGuid().ToString();
                    if (ur.ActualizarToken(u.Id, token))
                    {
                        SmtpClient client = new SmtpClient();
                        string correoCMS = sr.Obtener().CorreoCMS;
                        MailAddress maDesde = new MailAddress(correoCMS, "Configuration Management System");
                        MailMessage mm = new MailMessage();
                        mm.From = maDesde;
                        mm.To.Add(u.Correo);
                        mm.Subject = "Recuperación de Clave";
                        mm.IsBodyHtml = true;
                        StringBuilder sb = new StringBuilder();
                        string url = Url.Action("ResetearClave", "Usuario", null, Request.Url.Scheme, null);
                        sb.Append("Para recuperar su clave por favor haga click en el siguiente vínculo<br>");
                        sb.Append("<a href='" + url + "/" + token + "'>Recuperar clave</a>");
                        mm.Body = sb.ToString();
                        client.Send(mm);
                        uv.Mensaje = "Se ha enviado a su correo (" + correo + ") un mensaje de recuperación de clave.";
                    }
                    else
                    {
                        uv.Mensaje = "El usuario especificado no existe en el sistema.";
                    }
                }
                return View("Mensaje", uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", ex.Message);
            }
        }

        public ActionResult ResetearClave(string id)
        {
            try
            {
                UsuarioView uv = new UsuarioView();
                UsuarioRepository ur = new UsuarioRepository();
                int usuarioId = ur.ObtenerIdPorToken(id);
                if (usuarioId > 0)
                {
                    Usuario u = ur.Obtener(usuarioId);
                    u.Token = id;
                    uv.Usuario = u;
                    return View("ResetearClave", uv);
                }
                else
                {
                    uv.Mensaje = "El token utilizado no es válido.";
                    return View("Mensaje", uv);
                }
            }
            catch (Exception ex)
            {
                return View("Mensaje", new UsuarioView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult RestaurarClave(string id)
        {
            try
            {
                UsuarioRepository ur = new UsuarioRepository();
                UsuarioView uv = new UsuarioView();
                string token = Request.Form["token"];
                int usuarioId = ur.ObtenerIdPorToken(token);
                Usuario usuario = ur.Obtener(usuarioId);

                if (usuario != null)
                {
                    string clave = Request.Form["txtClave"];
                    string claveEncriptada = Encriptador.EncriptarMD5(clave);
                    if (ur.CambiarClave(usuarioId, claveEncriptada))
                    {
                        uv.Mensaje = "Se cambió la clave satisfactoriamente.";
                    }
                    else
                    {
                        uv.Mensaje = "Hubo un problema al cambiar la clave.";
                    }
                }
                else
                {
                    uv.Mensaje = "El token no es válido.";
                }
                return View("Mensaje", uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", ex.Message);
            }
        }

        public ActionResult MisDatos()
        {
            try
            {
                UsuarioRepository ur = new UsuarioRepository();
                UsuarioView uv = new UsuarioView();
                string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);
                uv.Usuario = usuario;
                return View("MisDatos", uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MisDatos(UsuarioView uv)
        {
            try
            {
                UsuarioRepository ur = new UsuarioRepository();
                ur.ActualizarDatos(uv.Usuario);
                uv.Mensaje = "Los datos fueron actualizados satisfactoriamente";
                return View("MisDatos", uv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", ex.Message);
            }
        }
    }
}
