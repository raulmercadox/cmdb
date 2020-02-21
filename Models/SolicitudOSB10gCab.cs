using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudOSB10gCab
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string CodigoProyecto { get; set; }
        public string Ambiente { get; set; }
        public string ServidorDestino { get; set; }
        public string Observaciones { get; set; }
    }
}