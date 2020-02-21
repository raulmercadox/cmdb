using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class TipoObjetoBDView : ViewModel
    {
        public TipoObjetoBD TipoObjetoBD { get; set; }
        public List<TipoObjetoBD> TipoObjetoBDs { get; set; }

        public TipoObjetoBDView()
            : base()
        {
            TipoObjetoBD = new TipoObjetoBD();
            TipoObjetoBDs = new List<TipoObjetoBD>();
        }
    }
}