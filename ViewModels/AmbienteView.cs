using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class AmbienteView : ViewModel
    {
        public Ambiente Ambiente { get; set; }

        public List<Ambiente> Ambientes { get; set; }
        public List<Observacion> Observaciones { get; set; }

        public AmbienteView()
            : base()
        {
            Ambiente = new Ambiente();
            Ambientes = new List<Ambiente>();
        }
    }
}
