using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class RolView : ViewModel
    {
        public Rol Rol { get; set; }
        public List<Rol> Roles { get; set; }

        public RolView()
            : base()
        {
            Rol = new Rol();
            Roles = new List<Rol>();
        }
    }
}
