using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudBDJob
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
        public Instancia Instancia { get; set; }
        public Esquema Esquema { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public TipoAccionBD TipoAccionBD { get; set; }
        public string EjecucionInicial { get; set; }
        public string Intervalo { get; set; }
        public string InformacionAdicional { get; set; }
        public int NumeroArchivo { get; set; }
    }
}