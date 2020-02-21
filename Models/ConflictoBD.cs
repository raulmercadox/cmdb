using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class ConflictoBD
    {
        public Proyecto Proyecto { get; set; }
        public Instancia Instancia { get; set; }
        public Esquema Esquema { get; set; }
        public TipoObjetoBD TipoObjetoBD { get; set; }
        public string NombreObjeto { get; set; }
        public DateTime FechaHora { get; set; }
        public int SolicitudId { get; set; }
        public string Estado { get; set; }
    }
}