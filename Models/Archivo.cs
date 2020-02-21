using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Archivo
    {
        public byte[] Contenido { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string ContentType { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; } // 1 -> Error, 0 -> Ok
        public List<ConflictoBD> ConflictosBD { get; set; }
        public List<ConflictoCRMWPApp> ConflictosCRMWPApp { get; set; }
        public Area Area { get; set; }

    }
}
