using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class SolicitudView : ViewModel
    {
        public Solicitud Solicitud { get; set; }
        public List<Ambiente> Ambientes { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public List<string> Acciones { get; set; }
        public List<Solicitud> Solicitudes { get; set; }
        public List<Observacion> Observaciones { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public DateTime? FechaEjecucionDesde { get; set; }
        public DateTime? FechaEjecucionHasta { get; set; }
        public Sistema Sistema { get; set; }
        public List<Rollback> Rollbacks { get; set; }
        public Ambiente Ambiente { get; set; }

        public SolicitudView()
            : base()
        {
            Solicitud = new Solicitud();
            Ambientes = new List<Ambiente>();
            Proyectos = new List<Proyecto>();
            Acciones = new List<string>();
            Solicitudes = new List<Solicitud>();
        }
    }
}
