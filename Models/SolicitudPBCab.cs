using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudPBCab
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string CodigoProyecto { get; set; }
        public string Ambiente { get; set; }
        public string Aplicacion { get; set; }
        public string TipoPase { get; set; }
        public string Observaciones { get; set; }
    }
}