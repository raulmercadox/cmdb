using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CMDBApplication.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public Ambiente Ambiente { get; set; }
        public Proyecto Proyecto { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string AnalistaTestProd { get; set; }
        public bool Emergente { get; set; }
        public string RazonEmergente { get; set; }
        public Archivo Archivo1 { get; set; }
        public Archivo Archivo2 { get; set; }
        public Archivo Archivo3 { get; set; }
        public Archivo Archivo4 { get; set; }
        public Archivo Archivo5 { get; set; }
        public Archivo Archivo6 { get; set; }
        public Archivo Archivo7 { get; set; }
        public Archivo Archivo8 { get; set; }
        public Archivo Archivo9 { get; set; }
        public Archivo Archivo10 { get; set; }
        public Usuario Solicitante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public Area Area1 { get; set; }
        public Area Area2 { get; set; }
        public Area Area3 { get; set; }
        public Area Area4 { get; set; }
        public Area Area5 { get; set; }
        public Area Area6 { get; set; }
        public Area Area7 { get; set; }
        public Area Area8 { get; set; }
        public Area Area9 { get; set; }
        public Area Area10 { get; set; }
        public List<Log> Logs { get; set; }
        public string CopiarA { get; set; }
        public Ventana Ventana { get; set; }
        public bool EjecutarEmergente { get; set; }
        public string RFC { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public DateTime? FechaReversion { get; set; }
        public bool Reversion { get; set; }
        public bool Principal { get; set; }
        public bool Adicional { get; set; }
        public bool Pendiente { get; set; }
        public bool Satisfactorio { get; set; }
        public bool Regularizacion { get; set; }

        public string Codigo
        {
            /*get
            {
                return Id == 0 ? "" : String.Concat("S", Id.ToString().PadLeft(6, '0'));
            }
            set { }*/
            get;
            set;
        }

        public Solicitud()
        {
            Id = 0;
            Ambiente = new Ambiente();
            Proyecto = new Proyecto();
            AnalistaDesarrollo = String.Empty;
            AnalistaTestProd = String.Empty;
            RazonEmergente = String.Empty;
            Solicitante = new Usuario();
            Estado = "Solicitado_x_Sol";
            Logs = new List<Log>();
            Ventana = null;
            Archivo1 = new Archivo();
            Archivo2 = new Archivo();
            Archivo3 = new Archivo();
            Archivo4 = new Archivo();
            Archivo5 = new Archivo();
            Archivo6 = new Archivo();
            Archivo7 = new Archivo();
            Archivo8 = new Archivo();
            Archivo9 = new Archivo();
            Archivo10 = new Archivo();
            Aprobaciones = new List<Archivo>();
        }

        public List<Archivo> Aprobaciones { get; set; }
    }
}
