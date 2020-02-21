using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public bool Eliminar { get; set; }

        public Rol()
        {
            Nombre = String.Empty;
            Usuarios = new List<Usuario>();
        }
    }
}