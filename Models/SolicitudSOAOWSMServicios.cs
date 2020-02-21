using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAOWSMServicios
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Gateway { get; set; }
        public string Servicio { get; set; }
        public string Version { get; set; }
        public string WSDL { get; set; }
        public string PipelineType { get; set; }
        public string PipelineName { get; set; }
        public string Observacion { get; set; }
    }
}