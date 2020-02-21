using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Formato
    {
        public int Id { get; set; }
        public Archivo Archivo { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Version { get; set; }
        public string CarpetaBase { get; set; }

        public Formato()
        {
            Archivo = new Archivo();
            Descripcion = String.Empty;
        }
    }
}