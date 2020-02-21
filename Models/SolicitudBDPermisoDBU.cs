using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudBDPermisoDBU
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
        public int NumeroArchivo { get; set; }
        public string UserDBU { get; set; }
        public Instancia Instancia { get; set; }
        public TipoObjetoBD TipoObjetoBD { get; set; }
        public Esquema Esquema { get; set; }
        public string NombreObjeto { get; set; }
        public string Select { get; set; }
        public string Insert { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string Execute { get; set; }
        public DateTime FechaHora { get; set; }
    }
}