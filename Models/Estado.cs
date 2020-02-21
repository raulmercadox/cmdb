using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool EnviarCorreo { get; set; }
        public bool Satisfactorio { get; set; }
        public bool Pendiente { get; set; }
    }
}