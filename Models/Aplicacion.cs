using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Aplicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RutaSVN { get; set; }
        public string Herramienta { get; set; }
        public string Version { get; set; }
        public char Estado { get; set; }
        public bool Eliminar { get; set; }

        public Proyecto Proyecto { get; set; }

        public string DescripcionEstado
        {
            get
            {
                if (Estado == 'D')
                    return "Desarrollo";
                else if (Estado == 'T')
                    return "Test";
                else if (Estado == 'P')
                    return "Produccion";
                else
                    return "";
            }
        }

        public Aplicacion()
        {
            Id = 0;
            Nombre = "";
            RutaSVN = "";
            Herramienta = "";
            Version = "";
            Estado = ' ';
            Eliminar = false;
            Proyecto = new Proyecto();
        }
    }
}