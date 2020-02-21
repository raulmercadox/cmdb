using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudPBArchivos
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Orden { get; set; }
        public string GrupoDesarrollo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string ServidorOrigen { get; set; }
        public string RutaOrigen { get; set; }
        public string ServidorDestino { get; set; }
        public string NombreArchivo { get; set; }
        public string Accion { get; set; }
        public string InformacionAdicional { get; set; }
    }
}