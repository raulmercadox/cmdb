using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudOSB11gConfigAdaptadores
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string JNDIName { get; set; }
        public string DataSourceName { get; set; }
        public string ConnectionInitial { get; set; }
        public string ConnectionMaximum { get; set; }
        public string ConnectionMinimum { get; set; }
    }
}