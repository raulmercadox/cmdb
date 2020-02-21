﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudIXMediationObjetos
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Orden { get; set; }
        public string Directorio { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Accion { get; set; }
        public string Observacion { get; set; }
    }
}