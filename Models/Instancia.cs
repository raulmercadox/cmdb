using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Instancia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Servidor Servidor { get; set; }
        public Ambiente Ambiente { get; set; }
        public List<Esquema> Esquemas { get; set; }
        public Instancia InstanciaAnterior { get; set; }
        public string RepositorioSubversion { get; set; }

        public Instancia()
        {
            /*Nombre = String.Empty;
            Servidor = new Servidor();
            Ambiente = new Ambiente();
            Esquemas = new List<Esquema>();
            InstanciaAnterior = new Instancia();
            InstanciaPosterior = new Instancia();*/
        }
    }
}
