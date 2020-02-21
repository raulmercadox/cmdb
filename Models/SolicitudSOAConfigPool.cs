using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAConfigPool
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Container { get; set; }
        public string Nombre { get; set; }
        public string ConnectionFactory { get; set; }
        public string URL { get; set; }
        public string User { get; set; }
        public string Opciones { get; set; }
    }
}