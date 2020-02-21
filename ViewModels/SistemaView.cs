using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class SistemaView:ViewModel
    {
        public Sistema Sistema { get; set; }
        public List<Estado> Estados { get; set; }
        public List<Ambiente> Ambientes { get; set; }
        public List<Area> Grupos { get; set; }
        public List<Formato> Formatos { get; set; }

        public SistemaView()
            : base()
        {
            
        }
    }
}