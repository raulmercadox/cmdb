using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class TipoProyectoView:ViewModel
    {
        public TipoProyecto TipoProyecto { get; set; }
        public List<TipoProyecto> TipoProyectos { get; set; }
    }
}