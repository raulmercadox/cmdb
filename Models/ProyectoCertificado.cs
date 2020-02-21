using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class ProyectoCertificado
    {
        public int Id { get; set; }
        public Proyecto Proyecto { get; set; }
        public Ambiente Ambiente { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Certificado { get; set; }
        public string FechaHoraCadena
        {
            get
            {
                return FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }
    }
}