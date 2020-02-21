using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class ConflictoCRMWPApp
    {
        public Proyecto Proyecto { get; set; }
        public Solicitud Solicitud { get; set; }
        public string ServerCluster { get; set; }
        public string Tipo { get; set; }
        public string Aplicacion { get; set; }
        
    }
}