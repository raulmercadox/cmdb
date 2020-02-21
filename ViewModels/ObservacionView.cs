using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ObservacionView:ViewModel
    {
        public Observacion Observacion { get; set; }
        public List<Observacion> Observaciones { get; set; }

        public ObservacionView()
            : base()
        {
            Observacion = new Observacion();
            Observaciones = new List<Observacion>();
        }
    }
}