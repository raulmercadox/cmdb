using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDBApplication.Models
{
    public class Sistema
    {
        public int Id { get; set; }
        public string PrimeraSolicitud { get; set; }
        public string OracleDBUExtractConexion { get; set; }
        public Estado Estado { get; set; }
        public string CarpetaTrabajo { get; set; }
        public string CorreoCMS { get; set; }
        public string ResponderA { get; set; }
        public string CopiarExcelA { get; set; }
        public string FolderPre { get; set; }
        public string FolderDML { get; set; }
        public string MensajeCrearSolicitud { get; set; }
    }
}