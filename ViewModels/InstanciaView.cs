using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class InstanciaView : ViewModel
    {
        public Instancia Instancia { get; set; }
        public List<Instancia> Instancias { get; set; }
        public List<Servidor> Servidores { get; set; }
        public List<Ambiente> Ambientes { get; set; }

        public InstanciaView()
            : base()
        {
            Instancia = new Instancia();
            Instancias = new List<Instancia>();
            Servidores = new List<Servidor>();
            Ambientes = new List<Ambiente>();
        }
    }
}
