using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ArchivoView:ViewModel
    {
        public Archivo Archivo { get; set; }
        public int Indicador { get; set; }
        public int SolicitudId { get; set; }
    }
}