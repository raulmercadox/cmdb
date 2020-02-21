using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class AplicacionView : ViewModel
    {
        public Aplicacion Aplicacion { get; set; }
        public List<Aplicacion> Aplicaciones { get; set; }

        public AplicacionView()
            : base()
        {
            Aplicaciones = new List<Aplicacion>();
            Aplicacion = new Aplicacion();
        }
    }
}
