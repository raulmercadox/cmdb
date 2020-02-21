using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Responsable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Proyecto> Proyectos { get; set; }
    }
}