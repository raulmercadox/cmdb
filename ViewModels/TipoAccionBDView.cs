using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class TipoAccionBDView:ViewModel
    {
        public TipoAccionBD TipoAccionBD { get; set; }
        public List<TipoAccionBD> TipoAccionBDs { get; set; }

        public TipoAccionBDView()
            : base()
        {
            TipoAccionBD = new TipoAccionBD();
            TipoAccionBDs = new List<TipoAccionBD>();
        }
    }
}