using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ObjetoView:ViewModel
    {
        public string TipoObjeto { get; set; }
        public string NombreObjeto { get; set; }
        public List<ObjetoBD> ObjetosBD { get; set; }
        public List<SolicitudCRMWPApp> CRMApps { get; set; }
    }
}