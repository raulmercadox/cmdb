using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAConfigAdaptadores
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string JNDILocation { get; set; }
        public string ConnectionFactory { get; set; }
        public string ConnectionInterface { get; set; }
        public string Atributo { get; set; }
        public string OpcionesAdicionales { get; set; }
    }
}