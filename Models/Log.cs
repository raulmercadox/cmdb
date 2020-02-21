using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Comentario { get; set; }
        public Observacion Observacion { get; set; }
        public Archivo Archivo { get; set; }

        public Log()
        {
            Usuario = new Usuario();
            FechaHora = DateTime.Now;
            Comentario = String.Empty;
            Accion = String.Empty;
            Estado = String.Empty;
            Observacion = new Observacion();
            Archivo = new Archivo();
        }
    }
}
