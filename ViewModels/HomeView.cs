using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class HomeView : ViewModel
    {
        public List<Solicitud> Ingresados { get; set; }
        public List<Solicitud> Enviados { get; set; }
        public List<Solicitud> Pendientes { get; set; }
        public List<Solicitud> Aprobados { get; set; }
        public List<Ventana> Ventanas { get; set; }


        public HomeView()
            : base()
        {
            Pendientes = new List<Solicitud>();
            Ingresados = new List<Solicitud>();
            Enviados = new List<Solicitud>();
            Ventanas = new List<Ventana>();
        }
    }
}
