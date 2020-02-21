using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Servidor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public Ambiente Ambiente { get; set; }
        public List<Instancia> Instancias { get; set; }
        public string Descripcion { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Usuario UsuarioLogueado { get; set; }

        public Servidor()
        {
            /*Nombre = String.Empty;
            Ip = String.Empty;
            Ambiente = new Ambiente();
            Instancias = new List<Instancia>();*/
        }
    }
}
