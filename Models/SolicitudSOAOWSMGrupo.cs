﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudSOAOWSMGrupo
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
    }
}