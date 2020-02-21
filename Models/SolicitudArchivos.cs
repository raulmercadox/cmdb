using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudArchivo
    {
        public string SarID { get; set; }
        public Area Area { get; set; }
        public List<Archivo> Archivos { get; set; }

        public SolicitudArchivo()
        {
            SarID = String.Empty;
            Area = new Area();
            Archivos = new List<Archivo>();
        }
    }
}