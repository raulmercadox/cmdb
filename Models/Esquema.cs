using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Esquema
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Instancia Instancia { get; set; }
        public bool Eliminar { get; set; }

        public Esquema()
        {
            Nombre = String.Empty;
            Instancia = new Instancia();
        }
    }
}
