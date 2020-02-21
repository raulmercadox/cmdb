using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Rollback
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string TipoProyecto { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaHora { get; set; }
        public int SolicitudId { get; set; }
        public bool Emergente { get; set; }
    }
}