using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudBDCampo
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
        public int NumeroArchivo { get; set; }
        public Instancia Instancia { get; set; }
        public Esquema Esquema { get; set; }
        public string NombreTabla { get; set; }
        public TipoAccionBD TipoAccionBD { get; set; }
        public string NombreColumna { get; set; }
        public string Tipo { get; set; }
        public string Comentario { get; set; }
        public string NotNull { get; set; }
        public string DefaultValue { get; set; }
        public string CheckValue { get; set; }
        public DateTime FechaHora { get; set; }
    }
}