using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudBDConfiguracion
    {
        public int Int { get; set; }
        public Solicitud Solicitud { get; set; }
        public int NumeroArchivo { get; set; }
        public Instancia Instancia { get; set; }
        public Esquema Esquema { get; set; }
        public string Tabla { get; set; }
        public string Comentario { get; set; }
        public string Archivo { get; set; }
        public string Tipo { get; set; }
    }
}