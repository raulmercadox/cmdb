using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Models;
using System.Web.Security;
using CMDBApplication.Repository;

namespace CMDBApplication.Controllers
{
    public class BaseController:Controller
    {
        public Usuario ObtenerUsuario()
        {
            string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);
            return usuario;
        }
    }
}