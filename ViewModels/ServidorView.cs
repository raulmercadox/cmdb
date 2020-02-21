using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ServidorView : ViewModel
    {
        public Servidor Servidor { get; set; }
        public List<Servidor> Servidores { get; set; }
        public List<Ambiente> Ambientes { get; set; }

        public ServidorView()
            : base()
        {
            Servidor = new Servidor();
            Servidores = new List<Servidor>();
            Ambientes = new List<Ambiente>();
        }
    }
}
