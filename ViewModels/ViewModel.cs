using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public abstract class ViewModel
    {
        public string Mensaje { get; set; }

        public Usuario UsuarioLogueado { get; set; }

        public ViewModel()
        {
            Mensaje = String.Empty;
        }
    }
}
