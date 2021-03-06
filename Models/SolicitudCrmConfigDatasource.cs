﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class SolicitudCrmConfigDatasource
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public int NumeroArchivo { get; set; }
        public string Responsable { get; set; }
        public string AnalistaDesarrollo { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string ServerCluster { get; set; }
        public string JNDIName { get; set; }
        public string URL { get; set; }
        public string DriverClassName { get; set; }
        public string User { get; set; }
        public string CapacityInitial { get; set; }
        public string CapacityMaximun { get; set; }
        public string CapacityMinimun { get; set; }
        public string SupportGlobal { get; set; }
        public string StatementCache { get; set; }
        public string InactiveConnection { get; set; }
        public string TestConnections { get; set; }
    }
}