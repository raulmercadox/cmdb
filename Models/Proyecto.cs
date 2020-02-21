using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Pm { get; set; }
        public string Ptl { get; set; }
        public char Estado { get; set; }
        //public DateTime? FechaProd { get; set; }
        public List<Solicitud> Solicitudes { get; set; }
        public Responsable Responsable { get; set; }
        public bool Mejora { get; set; }
        public string Impacto { get; set; }
        public TipoProyecto TipoProyecto { get; set; }
        public string CodigoPresupuestal { get; set; }
        public string CodigoAlterno { get; set; }

        public string DescripcionEstado
        {
            get
            {
                if (Estado == 'E')
                {
                    return "En Ejecución";
                }
                else if (Estado == 'C')
                {
                    return "Cerrado";
                }
                else
                {
                    return "";
                }
            }
        }

        public List<Aplicacion> Aplicaciones { get; set; }
        public List<Desarrollador> Desarrolladores { get; set; }
        public List<ProyectoAmbiente> Ambientes { get; set; }

        public List<Correo> Correos { get; set; }

        public Proyecto()
        {
            Id = 0;
            Codigo = "";
            Nombre = "";
            Pm = "";
            Ptl = "";
            Estado = ' ';
            Aplicaciones = new List<Aplicacion>();
            Desarrolladores = new List<Desarrollador>();
            //FechaProd = null;
        }
    }
}
