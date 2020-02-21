using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ResponsableView:ViewModel
    {
        public Responsable Responsable { get; set; }
        public List<Responsable> Responsables { get; set; }

    }
}