using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOABPEL
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string RutaOrigen { get; set; }
        public string Dominio { get; set; }
        public string ProyectoBPEL { get; set; }
        public string Observacion { get; set; }
        public string Parametros { get; set; }
    }
}