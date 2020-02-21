using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class EstadoView:ViewModel
    {
        public Estado Estado { get; set; }
        public List<Estado> Estados { get; set; }
        public string Mensaje { get; set; }

        public EstadoView()
            : base()
        {
            Estado = new Estado();
            Estados = new List<Estado>();
            Mensaje = String.Empty;
        }
    }
}