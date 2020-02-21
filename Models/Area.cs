using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Correo> Correos { get; set; }
        public string Color { get; set; }
        public string Abreviatura { get; set; }

        public Area()
        {
            Nombre = String.Empty;
            Color = "rgb(255,255,255)";
            Correos = new List<Correo>();
            Abreviatura = String.Empty;
        }
    }
}
