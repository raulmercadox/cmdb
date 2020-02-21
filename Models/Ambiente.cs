using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Servidor> Servidores { get; set; }
        public List<Instancia> Instancias { get; set; }
        public string Abreviatura { get; set; }
        public bool Final { get; set; }
        public int Orden { get; set; }
        public bool ApruebaCalidad { get; set; }
        public List<Correo> Correos { get; set; }
        public bool FechaObligatoria { get; set; }
        public bool EnvioPrimeraSolicitud { get; set; }
        public Observacion ObservaCalidad { get; set; }

        public Ambiente()
        {
            /*Nombre = String.Empty;
            Servidores = new List<Servidor>();
            Instancias = new List<Instancia>();
            Abreviatura = String.Empty;*/
        }
    }
}
