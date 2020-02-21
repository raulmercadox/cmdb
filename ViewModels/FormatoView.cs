using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class FormatoView:ViewModel
    {
        public List<Formato> Formatos { get; set; }
        public Formato Formato { get; set; }
        public Usuario Usuario { get; set; }
        
        public FormatoView():base()
        {
            Formatos = new List<Formato>();
            Formato = new Formato();
            Usuario = new Usuario();        
        }
    }
}