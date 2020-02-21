using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class ProyectoView : ViewModel
    {
        public Proyecto Proyecto { get; set; }
        public List<Ambiente> Ambientes { get; set; }
        public List<Responsable> Responsables { get; set; }
        public List<ObjetoBD> ObjetosBD { get; set; }
        public List<SolicitudBDCampo> Campos { get; set; }
        public List<SolicitudBDPermisoDBU> PermisosDBU { get; set; }
        public List<SolicitudBDJob> Jobs { get; set; }
        public List<SolicitudBDConfiguracion> Configuraciones { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public Ambiente Ambiente { get; set; }
        public int TipoFormulario { get; set; }
        public bool ProyectoMarcado { get; set; }
        public bool SolicitudMarcada { get; set; }
        public List<TipoProyecto> TipoProyectos { get; set; }

        public ProyectoView()
            : base()
        {
            Proyecto = new Proyecto();
        }
    }
}
