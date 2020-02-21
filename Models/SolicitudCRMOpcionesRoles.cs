using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudCRMOpcionesRoles
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string ModuloAplicacion { get; set; }
        public string Nro { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string NpCode { get; set; }
        public string NpLevel { get; set; }
        public string NpModuleId { get; set; }
        public string Accion { get; set; }
    }
}