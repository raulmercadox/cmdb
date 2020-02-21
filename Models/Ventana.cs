using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Ventana
    {
        public int Id { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }
    }
}