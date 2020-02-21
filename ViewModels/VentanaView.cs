using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class VentanaView : ViewModel
    {
        public Ventana Ventana { get; set; }
        public List<Ventana> Ventanas { get; set; }

        public VentanaView()
            : base()
        {
            Ventana = new Ventana();
            Ventanas = new List<Ventana>();
        }
    }
}