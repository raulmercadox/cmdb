using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class UsuarioView : ViewModel
    {
        public Usuario Usuario { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Rol> Roles { get; set; }

        public UsuarioView()
            : base()
        {
            Usuario = new Usuario();
            Usuarios = new List<Usuario>();
            Roles = new List<Rol>();
        }
    }
}
