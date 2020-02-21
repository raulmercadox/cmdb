﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudCRMWPApp
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string RutaOrigen { get; set; }
        public string ServerCluster { get; set; }
        public string Tipo { get; set; }
        public string Aplicacion { get; set; }
        public string Accion { get; set; }
        public string Observacion { get; set; }
        public string ParametroAmbiente { get; set; }
    }
}