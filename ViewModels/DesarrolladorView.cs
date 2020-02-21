using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class DesarrolladorView : ViewModel
    {
        public Desarrollador Desarrollador { get; set; }
        public List<Desarrollador> Desarrolladores { get; set; }

        public DesarrolladorView()
            : base()
        {
            Desarrollador = new Desarrollador();
            Desarrolladores = new List<Desarrollador>();
        }
    }
}
