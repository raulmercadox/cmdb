using CMDBApplication.Models;
using CMDBApplication.Repository;
using CMDBApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMDBApplication.Controllers
{
    public class FormatoController : BaseController
    {
        //
        // GET: /Formatos/

        public ActionResult Listar()
        {
            string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);

            FormatoView fv = new FormatoView();
            fv.Usuario = usuario;

            FormatoRepository fr = new FormatoRepository();
            List<Formato> formatos = fr.Listar("");
            fv.Formatos = formatos;
            
            return View(fv);
        }

        public FileResult ObtenerArchivo(string id)
        {
            FormatoRepository fr = new FormatoRepository();            
            Formato formato = fr.ObtenerArchivo(int.Parse(id));
            return File(formato.Archivo.Contenido, System.Net.Mime.MediaTypeNames.Application.Octet, formato.Archivo.Nombre);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                FormatoView av = new FormatoView();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new FormatoView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(FormatoView formatoView)
        {
            try
            {
                string nombreFormato = Request.Files[0].FileName;
                string descripcionFormato = Request.Form["txtDescripcionFormato"];
                string nombreCorto = nombreFormato.Trim().Substring(nombreFormato.Trim().LastIndexOf('\\') + 1);
                string version = Request.Form["txtVersion"];
                string codigo = Request.Form["txtCodigo"];
                string carpetaBase = Request.Form["txtCarpetaBase"];

                #region Verificar is ya existe el nombre del formato
                FormatoRepository fr = new FormatoRepository();
                
                Formato f = fr.Obtener(nombreCorto);
                if (f.Id > 0)
                {
                    formatoView.Formato.Archivo.Nombre = nombreFormato;
                    formatoView.Mensaje = "El nombre del formato ya existe.";
                }
                else
                {
                    f = new Formato();
                    f.Archivo.Nombre = nombreCorto;
                    f.Archivo.Contenido = new byte[Request.Files[0].ContentLength];
                    Request.Files[0].InputStream.Read(f.Archivo.Contenido, 0, f.Archivo.Contenido.Length);
                    f.Descripcion = descripcionFormato;
                    f.Codigo = codigo;
                    f.Version = version;
                    f.CarpetaBase = carpetaBase;
                    f = fr.Actualizar(f);
                    if (f.Id == 0)
                    {
                        formatoView.Mensaje = "Hubo un error al crear el formato.";
                    }
                    else {
                        formatoView.Mensaje = "Formato creado satisfactoriamente.";
                    }
                }
                return View("Crear", formatoView);
                #endregion
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Obtener(string id)
        {
            try
            {
                FormatoView fv = new FormatoView();
                fv.Mensaje = "";
                FormatoRepository fr = new FormatoRepository();
                Formato f = fr.Obtener(int.Parse(id));
                fv.Formato = f;
                return View("Obtener", fv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(AmbienteView ambienteView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreFormato = Request.Form["txtNombreFormato"];
                var codigo = Request.Form["txtCodigo"];
                var version = Request.Form["txtVersion"];
                var carpetaBase = Request.Form["txtCarpetaBase"];
                
                Formato f = new Formato();
                f.Id = int.Parse(id);
                f.Descripcion = Request.Form["txtDescripcionFormato"];

                if (Request.Files.Count > 0 && Request.Files[0].ContentLength>0)
                {
                    nombreFormato = Request.Files[0].FileName.Substring(Request.Files[0].FileName.LastIndexOf('\\') + 1);
                    f.Archivo.Contenido = new byte[Request.Files[0].ContentLength];
                    Request.Files[0].InputStream.Read(f.Archivo.Contenido, 0, f.Archivo.Contenido.Length);
                }
                f.Archivo.Nombre = nombreFormato;
                f.Codigo = codigo;
                f.Version = version;
                f.CarpetaBase = carpetaBase;
                
                FormatoRepository fr = new FormatoRepository();

                f = fr.Actualizar(f);
                if (f.Id == 0)
                {
                    ambienteView.Mensaje = "Hubo un error al actualizar el formulario";
                    return View("Actualizar", ambienteView);
                }

                FormatoView fv = new FormatoView();
                fv.Mensaje = "Formulario Actualizado";
                fv.Formato = f;
                return View("Obtener", fv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new FormatoView { Mensaje = ex.Message });
            }
        }

        public ActionResult Eliminar(string id)
        {
            try
            {
                FormatoRepository fr = new FormatoRepository();
                bool rsta = fr.Eliminar(int.Parse(id));
                string mensaje = String.Empty;
                if (rsta)
                {
                    mensaje = "Se eliminó el formulario satisfactoriamente.";
                }
                else
                {
                    mensaje = "Hubo un error al eliminar el formulario";
                }
                return View("Mensaje", new FormatoView { Mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return View("Mensaje", new FormatoView { Mensaje = ex.Message });
            }
        }

    }
}
