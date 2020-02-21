using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class ObjetoBD
    {
        public Solicitud Solicitud { get; set; }
        public Instancia Instancia { get; set; }
        public Esquema Esquema { get; set; }
        public TipoObjetoBD TipoObjeto { get; set; }
        public TipoAccionBD TipoAccion { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int NumeroArchivo { get; set; }
        public DateTime FechaHora { get; set; }
        public string InformacionAdicional { get; set; }

        public ObjetoBD()
        {
            Instancia = new Instancia();
            Esquema = new Esquema();
            TipoObjeto = new TipoObjetoBD();
            TipoAccion = new TipoAccionBD();
            Nombre = String.Empty;
            Ruta = String.Empty;
            InformacionAdicional = String.Empty;
        }
    }
}