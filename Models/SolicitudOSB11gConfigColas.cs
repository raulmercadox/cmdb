using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudOSB11gConfigColas
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string ServerCluster { get; set; }
        public string JNDIName { get; set; }
        public string Template { get; set; }
        public string SubDeployment { get; set; }
        public string Target { get; set; }
        public string RedeliveryOverride { get; set; }
        public string RedeliveryLimit { get; set; }
        public string ExpirationPolicy { get; set; }
        public string ErrorDestination { get; set; }
        public string Observacion { get; set; }
        public string ModuloJMS { get; set; }
    }
}