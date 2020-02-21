using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAConfigInstanciasJ2EE
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string PuertoRMI { get; set; }
        public string MaximumHeap { get; set; }
        public string InitialHeap { get; set; }
        public string OpcionesAdicionales { get; set; }
    }
}