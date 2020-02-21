using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudPBLibrerias
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Orden { get; set; }
        public string GrupoDesarrollo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Servidor { get; set; }
        public string Ruta { get; set; }
        public string Libreria { get; set; }
        public string Objeto { get; set; }
        public string LibreriaDestino { get; set; }
    }
}