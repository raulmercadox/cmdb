using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMDBApplication.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool Administrador { get; set; }
        public bool Operador { get; set; }
        public bool Lector { get; set; }
        public bool CM { get; set; }
        public bool RM { get; set; }
        public bool Ejecutor { get; set; }
        public bool Test { get; set; }
        public string Token { get; set; }
        public string Celular { get; set; }
        public string Anexo { get; set; }
        public string Skype { get; set; }
        public bool Eliminar { get; set; }

        public List<Rol> Roles { get; set; }
        public List<Solicitud> Solicitudes { get; set; }

        public Usuario()
        {
            Nombre = String.Empty;
            Clave = String.Empty;
            Correo = String.Empty;
            Roles = new List<Rol>();
            Solicitudes = new List<Solicitud>();
            Token = String.Empty;
        }
    }
}
