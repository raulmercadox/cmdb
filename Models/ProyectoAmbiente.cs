using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class ProyectoAmbiente
    {
        public int Id { get; set; }
        public Proyecto Proyecto { get; set; }
        public Ambiente Ambiente { get; set; }
        public DateTime FechaPase { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public string CadenaFechaPase
        {
            get
            {
                return FechaPase.ToString("dd/MM/yyyy");
            }
        }
    }
}