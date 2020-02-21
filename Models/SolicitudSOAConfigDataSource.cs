using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAConfigDataSource
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Container { get; set; }
        public string Nombre { get; set; }
        public string JNDILocation { get; set; }
        public string Tipo { get; set; }
        public string ConnectionPool { get; set; }
        public string Opciones { get; set; }
    }
}