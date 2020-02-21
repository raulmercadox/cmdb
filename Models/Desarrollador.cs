using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Desarrollador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool Eliminar { get; set; }

        public List<Proyecto> Proyectos { get; set; }

        public Desarrollador()
        {
            Proyectos = new List<Proyecto>();
        }
    }
}
