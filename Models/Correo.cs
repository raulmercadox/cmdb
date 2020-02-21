using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Correo
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public bool Eliminar { get; set; }
    }
}
