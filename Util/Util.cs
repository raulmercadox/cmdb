using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CMDBApplication.Models;
using System.Net.Mail;
using System.Configuration;
using CMDBApplication.Repository;
using System.Text;
using System.Net;
using System.Web.Security;
using System.Diagnostics;


namespace CMDBApplication.Util
{
    public class Util
    {
        public static void EnviarCorreo(Solicitud[] solicitudes, string asunto, string cuerpo, bool incluirSolicitante, bool incluirAnalistaDes, bool incluirAnalistaTest, bool incluirCopiados,
            bool incluirRMs, bool incluirCMs, bool incluirEjecutores, bool incluirAdicional)
        {
            try
            {
                SistemaRepository sr = new SistemaRepository();
                SmtpClient client = new SmtpClient();
                string correoCMS = sr.Obtener().CorreoCMS;
                MailAddress maDesde = new MailAddress(correoCMS, "Configuration Management System");
                UsuarioRepository ur = new UsuarioRepository();

                MailAddressCollection mailsTo = new MailAddressCollection();
                MailAddressCollection mailsCc = new MailAddressCollection();
                MailAddressCollection mailsBcc = new MailAddressCollection();

                if (incluirRMs)
                {
                    List<Usuario> rms = ur.Listar(String.Empty, String.Empty, false, false, false, false, true, false,false);
                    foreach (Usuario rm in rms)
                    {
                        if (!String.IsNullOrEmpty(rm.Correo))
                            mailsBcc = IncluirCorreo(new MailAddress(rm.Correo), mailsBcc);
                    }
                }

                if (incluirCMs)
                {
                    List<Usuario> cms = ur.Listar(String.Empty, String.Empty, false, false, false, true, false, false,false);
                    foreach (Usuario cm in cms)
                    {
                        if (!String.IsNullOrEmpty(cm.Correo))
                            mailsBcc = IncluirCorreo(new MailAddress(cm.Correo), mailsBcc);
                    }
                }

                foreach (Solicitud s in solicitudes) {
                    if (incluirSolicitante)
                    {
                        if (!String.IsNullOrEmpty(s.Solicitante.Correo))
                            mailsCc = IncluirCorreo(new MailAddress(s.Solicitante.Correo), mailsCc);
                    }
                    if (incluirAnalistaDes)
                    {
                        if (!String.IsNullOrEmpty(s.AnalistaDesarrollo))
                            mailsCc = IncluirCorreo(new MailAddress(s.AnalistaDesarrollo), mailsCc);
                    }
                    if (incluirAnalistaTest)
                    {
                        Area[] areas = Util.ObtenerAreas(s);
                        bool enviarAnalista = false;
                        foreach (Area area in areas)
                        {
                            if (area.Correos.Count == 0 && area.Id>0)
                            {
                                enviarAnalista = true;
                                break;
                            }
                        }
                        if (!String.IsNullOrEmpty(s.AnalistaTestProd))
                        {
                            if (enviarAnalista)
                                mailsTo = IncluirCorreo(new MailAddress(s.AnalistaTestProd), mailsTo);
                            else
                                mailsCc = IncluirCorreo(new MailAddress(s.AnalistaTestProd), mailsCc);
                        }
                    }
                    if (incluirCopiados)
                    {
                        string[] copiados = s.CopiarA.Split(new char[] { ';' });
                        foreach (string copia in copiados)
                        {
                            if (!String.IsNullOrEmpty(copia))
                                mailsCc = IncluirCorreo(new MailAddress(copia), mailsCc);
                        }
                    }
                    if (incluirEjecutores)
                    {
                        MailAddressCollection correos = ObtenerCorreoEjecutores(s);
                        foreach (MailAddress correo in correos)
                        {
                            mailsTo = IncluirCorreo(correo, mailsTo);
                        }
                    }
                    if (s.Ambiente.EnvioPrimeraSolicitud && Util.EsPrimerEnvio(s))
                    {
                        string[] correos = sr.Obtener().PrimeraSolicitud.Split(new char[] { ';' });
                        foreach (string correo in correos)
                        {
                            if (!String.IsNullOrEmpty(correo))
                            {
                                mailsBcc = IncluirCorreo(new MailAddress(correo), mailsBcc);
                            }
                        }
                    }
                    #region Se incluyen correos configurados a nivel de proyecto
                    var pr = new ProyectoRepository();
                    var proyectocorreos = pr.ListarCorreo(s.Proyecto);
                    foreach (var cor in proyectocorreos)
                    {
                        mailsCc = IncluirCorreo(new MailAddress(cor.Direccion), mailsCc);
                    }
                    #endregion
                }
                if (incluirAdicional)
                {
                    if (solicitudes.Count() > 0)
                    {
                        Ambiente ambiente = solicitudes[0].Ambiente;
                        AmbienteRepository ar = new AmbienteRepository();
                        List<Correo> correos = ar.ListarCorreos(ambiente.Id);
                        foreach (Correo correo in correos)
                        {
                            if (!String.IsNullOrEmpty(correo.Direccion))
                            {
                                mailsBcc = IncluirCorreo(new MailAddress(correo.Direccion), mailsBcc);
                            }
                        }
                    }
                }

                MailMessage mm = new MailMessage();
                mm.From = maDesde;
                mm.ReplyToList.Add(sr.Obtener().ResponderA);
                foreach (MailAddress mail in mailsTo)
                {
                    mm.To.Add(mail);
                }

                foreach (MailAddress mail in mailsCc)
                {
                    mm.CC.Add(mail);
                }
                foreach (MailAddress mail in mailsBcc)
                {
                    mm.Bcc.Add(mail);
                }

                

                mm.Subject = asunto;
                mm.Body = cuerpo;
                mm.IsBodyHtml = true;
                if (solicitudes.Count() == 1 && solicitudes[0].Emergente)
                {
                    mm.Priority = MailPriority.High;
                }
                client.Send(mm);
            }
            catch
            {
                throw;
            }
        }

        public static MailAddressCollection ObtenerCorreoEjecutores(Solicitud s)
        {
            try
            {
                MailAddressCollection correos = new MailAddressCollection();
                Area[] areas = ObtenerAreas(s);
                foreach (Area area in areas)
                {
                    foreach (Correo correo in area.Correos)
                    {
                        if (!String.IsNullOrEmpty(correo.Direccion))
                            correos.Add(new MailAddress(correo.Direccion));
                    }
                }
                return correos;
            }
            catch
            {
                throw;
            }
        }

        public static Area[] ObtenerAreas(Solicitud s)
        {
            List<Area> areas = new List<Area>();
            for(int i=1; i<=10; i++)
            {
                Area a = ObtenerArea(s, i);
                if (a != null)
                {
                    Area ax = areas.FirstOrDefault(p => p.Nombre == a.Nombre);
                    if (ax == null)
                    {
                        areas.Add(a);
                    }
                }
            }
            return areas.ToArray();
        }

        public static MailAddressCollection IncluirCorreo(MailAddress mail, MailAddressCollection mails)
        {
            try
            {
                bool existe = false;
                foreach (MailAddress m in mails)
                {
                    if (String.Compare(m.Address, mail.Address) == 0)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe && !String.IsNullOrEmpty(mail.Address))
                {
                    mails.Add(mail);
                }

                return mails;
            }
            catch
            {
                throw;
            }
        }

        public static void EnviarCorreo(string urlServidor, Solicitud s, string asunto)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string urlSolicitud = urlServidor + "/Solicitud/Obtener/S" + s.Id.ToString().PadLeft(6, '0');
                sb.Append("Solicitud: <a href='" + urlSolicitud + "'>S" + s.Id.ToString().PadLeft(6, '0') + "</a><br/>");
                sb.Append("Proyecto: " + s.Proyecto.Codigo + " - " + s.Proyecto.Nombre + "<br/>");
                sb.Append("Ambiente: " + s.Ambiente.Nombre + "<br/>");
                sb.Append("Estado Actual: " + s.Estado + "<br/>");
                if (s.Emergente)
                {
                    sb.Append("<span style='background-color:yellow;font-weight:bold;'>Solicitud Emergente</span><br/>");
                    sb.Append("Razon del Emergente: " + s.RazonEmergente + "<br/>");
                }
                sb.Append("<br/>Historial:<br/>");
                sb.Append("<table border='1' style='border-collapse:collapse;width:100%;'>");
                sb.Append("<thead><tr><th>Estado</th><th>Fecha Hora</th><th>Comentario</th><th>Usuario</th></tr></thead>");
                sb.Append("<tbody>");
                foreach (Log log in s.Logs)
                {
                    if (!String.IsNullOrEmpty(log.Archivo.Nombre))
                    {
                        string rutaArchivo = urlServidor + "/Home/ObtenerArchivoLog/" + log.Id;
                        log.Comentario += "(<a href='" + rutaArchivo + "'>Adjunto</a>)";
                    }
                    sb.Append("<tr><td>" + log.Estado + "</td><td>" + log.FechaHora.ToString("dd/MM/yyyy HH:mm:ss") + "</td><td>" + log.Comentario + "</td><td>" + log.Usuario.Nombre + "</td></tr>");
                }
                sb.Append("</tbody>");
                sb.Append("</table>");

                string cuerpo = sb.ToString();

                //asunto = asunto + (s.Emergente ? " EMERGENTE" : String.Empty);

                EstadoRepository er = new EstadoRepository();
                List<Estado> estados = er.Listar();
                Estado estado = estados.FirstOrDefault(p => p.Nombre == s.Estado);
                if (estado != null && estado.EnviarCorreo)
                {
                    EnviarCorreo(new Solicitud[] { s }, asunto, cuerpo, true, true, true, true, true, true, false, false);
                }               
            }
            catch
            {
                throw;
            }
        }        

        public static string ObtenerNombreArchivo(Solicitud s, int i)
        {
            string nombreArchivo = String.Empty;
            switch (i)
            {
                case 1:
                    nombreArchivo = s.Archivo1.Nombre;
                    break;
                case 2:
                    nombreArchivo = s.Archivo2.Nombre;
                    break;
                case 3:
                    nombreArchivo = s.Archivo3.Nombre;
                    break;
                case 4:
                    nombreArchivo = s.Archivo4.Nombre;
                    break;
                case 5:
                    nombreArchivo = s.Archivo5.Nombre;
                    break;
                case 6:
                    nombreArchivo = s.Archivo6.Nombre;
                    break;
                case 7:
                    nombreArchivo = s.Archivo7.Nombre;
                    break;
                case 8:
                    nombreArchivo = s.Archivo8.Nombre;
                    break;
                case 9:
                    nombreArchivo = s.Archivo9.Nombre;
                    break;
                case 10:
                    nombreArchivo = s.Archivo10.Nombre;
                    break;
            }
            return nombreArchivo;
        }

        public static Area ObtenerArea(Solicitud s, int i)
        {
            Area area = null;
            switch (i)
            {
                case 1:
                    area = s.Area1;
                    break;
                case 2:
                    area = s.Area2;
                    break;
                case 3:
                    area = s.Area3;
                    break;
                case 4:
                    area = s.Area4;
                    break;
                case 5:
                    area = s.Area5;
                    break;
                case 6:
                    area = s.Area6;
                    break;
                case 7:
                    area = s.Area7;
                    break;
                case 8:
                    area = s.Area8;
                    break;
                case 9:
                    area = s.Area9;
                    break;
                case 10:
                    area = s.Area10;
                    break;
            }
            return area;
        }

        public static bool ExisteArea(Solicitud s)
        {
            bool existeArea = false;
            if (s.Area1.Id > 0) existeArea = true;
            if (s.Area2.Id > 0) existeArea = true;
            if (s.Area3.Id > 0) existeArea = true;
            if (s.Area4.Id > 0) existeArea = true;
            if (s.Area5.Id > 0) existeArea = true;
            if (s.Area6.Id > 0) existeArea = true;
            if (s.Area7.Id > 0) existeArea = true;
            if (s.Area8.Id > 0) existeArea = true;
            if (s.Area9.Id > 0) existeArea = true;
            if (s.Area10.Id > 0) existeArea = true;
            return existeArea;
        }

        /// <summary>
        /// Lista los archivos de una solicitud por cada area. En el caso de areas que no tengan correos 
        /// especificados (Configuraciones), se agrupan los archivos de esta area como un solo Sar ID
        /// </summary>
        /// <param name="s">Solicitd</param>
        /// <returns>Lista de archivos de una solicitud</returns>
        public static List<SolicitudArchivo> ListarArchivos(Solicitud s)
        {
            List<SolicitudArchivo> sas = new List<SolicitudArchivo>();
            Area a = null;
            string nombreArchivo = String.Empty;
            //int j = 0;
            for (int i = 1; i <= 10; i++)
            {
                a = ObtenerArea(s, i);
                nombreArchivo = ObtenerNombreArchivo(s,i);
                if (a.Id > 0 && !String.IsNullOrEmpty(nombreArchivo))
                {
                    //j++;
                    if (a.Correos.Count() > 0)
                    {
                        SolicitudArchivo sa = FabricarSolicitudArchivo(s, a, nombreArchivo, i);
                        sas.Add(sa);
                    }
                    else
                    {
                        // Un pase de configuración, usualmente se adjuntan mas de un archivo
                        // Buscar si ya existe la configuracion en la lista de archivos
                        SolicitudArchivo saBuscado = sas.FirstOrDefault(p => p.Area.Id == a.Id);
                        if (saBuscado != null)
                        {
                            // Si existe, entonces agregar el archivo solamente
                            Archivo archivo = new Archivo();
                            archivo.Nombre = nombreArchivo;
                            archivo.Id = i;
                            saBuscado.Archivos.Add(archivo);
                        }
                        else
                        {
                            saBuscado = FabricarSolicitudArchivo(s, a, nombreArchivo, i);
                            sas.Add(saBuscado);
                        }
                    }
                }
            }
            return sas;
        }

        private static SolicitudArchivo FabricarSolicitudArchivo(Solicitud s, Area a, string nombreArchivo, int i)
        {
            SolicitudArchivo sa = new SolicitudArchivo();
            sa.Area = a;
            sa.SarID = String.Concat(s.Ambiente.Abreviatura, "-", a.Abreviatura, "-", s.Proyecto.Codigo, "-", s.FechaCreacion.ToString("ddMMyy"), "-", i.ToString());
            sa.Archivos = new List<Archivo>();
            Archivo archivo = new Archivo();
            archivo.Nombre = nombreArchivo;
            archivo.Id = i;
            sa.Archivos.Add(archivo);
            return sa;
        }

        public static void ProcesarArchivo(int id,HttpPostedFileBase archivo,int numeroArchivo)
        {
            SistemaRepository sr = new SistemaRepository();
            if (archivo.InputStream.Length > 0)
            {
                string extension = archivo.FileName.Substring(archivo.FileName.LastIndexOf('.') + 1);
                if (extension == "xls" || extension == "xlsx" || extension == "xlsm")
                {
                    string ruta = sr.Obtener().CopiarExcelA;
                    archivo.SaveAs(ruta + "\\S" + id.ToString().PadLeft(6, '0') + "-" + numeroArchivo.ToString() + "." + extension);
                }
            }
        }

        public static void ProcesarArchivo(int id, Archivo archivo, int numeroArchivo)
        {
            SistemaRepository sr = new SistemaRepository();
            if (archivo.Contenido.Length > 0)
            {
                string extension = archivo.Nombre.Substring(archivo.Nombre.LastIndexOf('.') + 1);
                if (extension == "xls" || extension == "xlsx" || extension == "xlsm")
                {
                    string ruta = sr.Obtener().CopiarExcelA;
                    FileStream fs = new FileStream(ruta + "\\S" + id.ToString().PadLeft(6, '0') + "-" + numeroArchivo.ToString() + "." + extension, FileMode.Create, FileAccess.Write);
                    fs.Write(archivo.Contenido, 0, archivo.Contenido.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        public static Solicitud ActualizarSolicitud(DateTime ahora, Usuario usuario, Solicitud s, string rol, List<Archivo> archivos, string cboAccion, string txtInteresados, string cboObservacion, string txtComentario)
        {
            ObservacionRepository observacionRepository = new ObservacionRepository();
            SolicitudRepository solicitudRepository = new SolicitudRepository();
            EventLog.WriteEntry("Util","linea 470");
            if (!String.IsNullOrEmpty(cboAccion))
            {
                var estadoAntiguo = s.Estado;
                s.Estado = solicitudRepository.ObtenerEstado(rol, s.Estado, cboAccion);
                if (String.IsNullOrEmpty(s.Estado))
                {
                    s.Estado = estadoAntiguo;
                }
            }
            EventLog.WriteEntry("Util", "linea 473");
            s.CopiarA = txtInteresados;
            EventLog.WriteEntry("Util", "linea 475");
            if (!String.IsNullOrEmpty(s.Estado) && !String.IsNullOrEmpty(cboAccion))
            {
                Log log = new Log();
                log.Usuario = usuario;
                log.Accion = cboAccion;
                EventLog.WriteEntry("Util", "linea 481");
                if (log.Accion.IndexOf("Observar") >= 0)
                {
                    EventLog.WriteEntry("Util", "linea 484");
                    int observacionId;
                    int.TryParse(cboObservacion, out observacionId);
                    log.Observacion = observacionRepository.Obtener(observacionId);
                    log.Comentario = String.IsNullOrEmpty(txtComentario) ? log.Observacion.Nombre : txtComentario;
                }
                else
                {
                    EventLog.WriteEntry("Util", "linea 492");
                    log.Comentario = txtComentario.Trim();
                }
                if (/*log.Accion.IndexOf("Observar") >= 0 &&*/ archivos.Count>0 && archivos[0].Contenido.Length > 0)
                {
                    EventLog.WriteEntry("Util", "linea 497");
                    log.Archivo = archivos[0];
                }
                else
                {
                    EventLog.WriteEntry("Util", "linea 502");
                    log.Archivo.Nombre = String.Empty;
                    log.Archivo.Contenido = new byte[0];
                }
                log.Estado = s.Estado;
                log.FechaHora = ahora;
                EventLog.WriteEntry("Util", "linea 508");
                s.Logs.Add(log);
            }
            EventLog.WriteEntry("Util", "linea 511");
            s = solicitudRepository.ActualizarOtroSolicitadoxSol(s);
            return s;
        }

        public static DateTime? ConvertirFecha(string fecha,string hora,string minuto)
        {
            try
            {
                DateTime? dFecha = null;
                if (!String.IsNullOrEmpty(fecha))
                {
                    if (fecha.Length != 10)
                    {
                        throw new Exception("Deben de haber 10 caracteres en el formato de fecha (dd/mm/aaaa)");
                    }

                    if (String.Compare(fecha.Substring(2, 1), "/") != 0 || String.Compare(fecha.Substring(5, 1), "/") != 0)
                    {
                        throw new Exception("El separador de fecha debe ser un slash /");
                    }

                    int dia;
                    string sDia = fecha.Substring(0, 2);
                    if (!int.TryParse(sDia, out dia))
                    {
                        throw new Exception("No se puede convertir el dia a número");
                    }
                    if (dia <= 0 || dia > 31)
                    {
                        throw new Exception("El día debe estar entre 1 y 31");
                    }

                    int mes;
                    string sMes = fecha.Substring(3, 2);
                    if (!int.TryParse(sMes, out mes))
                    {
                        throw new Exception("No se puede convertir el mes a número");
                    }
                    if (mes <= 0 || mes > 12)
                    {
                        throw new Exception("El mes debe estar entre 1 y 12");
                    }

                    int anio;
                    string sAnio = fecha.Substring(6, 4);
                    if (!int.TryParse(sAnio, out anio))
                    {
                        throw new Exception("No se puede convertir el año a número");
                    }
                    if (anio <= 0)
                    {
                        throw new Exception("El año debe ser mayor a cero");
                    }

                    if (String.IsNullOrEmpty(hora))
                    {
                        throw new Exception("La hora no puede estar en blanco");
                    }

                    if (String.IsNullOrEmpty(minuto))
                    {
                        throw new Exception("El minuto no puede estar en blanco");
                    }

                    int nHora;
                    if (!int.TryParse(hora, out nHora))
                    {
                        throw new Exception("La hora no es numérico");
                    }

                    int nMinuto;
                    if (!int.TryParse(minuto, out nMinuto))
                    {
                        throw new Exception("El minuto no es numérico");
                    }

                    if (nHora < 0 || nHora > 23)
                    {
                        throw new Exception("La hora debe estar entre 0 y 23 inclusive");
                    }

                    if (nMinuto < 0 || nMinuto > 59)
                    {
                        throw new Exception("El minuto debe estar entre 0 y 59 inclusive");
                    }
                    dFecha = new DateTime(anio, mes, dia, nHora, nMinuto, 0);
                }
                return dFecha;
            }
            catch
            {
                throw;
            }
        }

        public static bool EsPrimerEnvio(Solicitud s)
        {
            try
            {
                SolicitudRepository sr = new SolicitudRepository();
                int ambienteId = s.Ambiente.Id;
                List<Solicitud> solicitudes = sr.Listar(String.Empty, ambienteId, s.Proyecto.Id, String.Empty, String.Empty, false, String.Empty, null, null, String.Empty, String.Empty, false);
                return solicitudes.Count == 1;
            }
            catch
            {
                throw;
            }
        }

        public static string ObtenerDescripcionVentana(List<Solicitud> solicitudes)
        {
            try
            {
                string resultado = String.Empty;
                List<DateTime> fechaHoras = new List<DateTime>();
                DateTime menorFechaHora = new DateTime();
                bool primero = true;
                solicitudes.ForEach(p =>
                {
                    if (p.FechaEjecucion.HasValue)
                    {
                        if (primero)
                        {
                            menorFechaHora = p.FechaEjecucion.Value;
                            primero = false;
                        }
                        else
                        {
                            if (DateTime.Compare(p.FechaEjecucion.Value, menorFechaHora) < 0)
                            {
                                menorFechaHora = p.FechaEjecucion.Value;
                            }
                        }
                        bool existe = false;
                        foreach (DateTime fechaHora in fechaHoras)
                        {
                            if (DateTime.Compare(fechaHora, p.FechaEjecucion.Value) == 0)
                            {
                                existe = true;
                                break;
                            }
                        }
                        if (!existe)
                        {
                            fechaHoras.Add(p.FechaEjecucion.Value);
                        }
                    }
                });
                if (fechaHoras.Count > 1)
                {
                    if (primero)
                        resultado = "normal";
                    else
                    {
                        resultado = menorFechaHora.ToString("dd/MM/yyyy HH:mm");
                    }
                }
                if (fechaHoras.Count == 1)
                {
                    resultado = fechaHoras[0].ToString("dd/MM/yyyy HH:mm");
                }
                if (fechaHoras.Count == 0)
                {
                    resultado = "normal";
                }
                return resultado;
            }
            catch
            {
                throw;
            }
        }

        public static void Descargar(string file,string destino)
        {
            try
            {
                Uri serverUri = new Uri(file);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                if (!Directory.Exists(destino))
                {
                    Directory.CreateDirectory(destino);
                }
                string nombreArchivo = file.Substring(file.LastIndexOf("/") + 1);
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(file));
                //reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(destino+"\\"+nombreArchivo, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
            }
            catch
            {
                throw;
            }
        }

        public static Archivo ObtenerArchivo(Solicitud s,int numeroArchivo){
            Archivo archivo = null;
            switch(numeroArchivo){
                case 1:
                    archivo =  s.Archivo1;
                    break;
                case 2:
                    archivo = s.Archivo2;
                    break;
                case 3:
                    archivo = s.Archivo3;
                    break;
                case 4:
                    archivo = s.Archivo4;
                    break;
                case 5:
                    archivo = s.Archivo5;
                    break;
                case 6:
                    archivo = s.Archivo6;
                    break;
                case 7:
                    archivo = s.Archivo7;
                    break;
                case 8:
                    archivo = s.Archivo8;
                    break;
                case 9:
                    archivo = s.Archivo9;
                    break;
                case 10:
                    archivo = s.Archivo10;
                    break;
            }
            return archivo;
        }

        public static void AsignarArchivo(Solicitud s, int numeroArchivo, Archivo archivo)
        {
            switch (numeroArchivo)
            {
                case 1:
                    s.Archivo1 = archivo;
                    break;
                case 2:
                    s.Archivo2 = archivo;
                    break;
                case 3:
                    s.Archivo3 = archivo;
                    break;
                case 4:
                    s.Archivo4 = archivo;
                    break;
                case 5:
                    s.Archivo4 = archivo;
                    break;
                case 6:
                    s.Archivo4 = archivo;
                    break;
                case 7:
                    s.Archivo4 = archivo;
                    break;
                case 8:
                    s.Archivo4 = archivo;
                    break;
                case 9:
                    s.Archivo4 = archivo;
                    break;
                case 10:
                    s.Archivo4 = archivo;
                    break;
            }
        }

        public static int CastearNumeroSolicitud(string numeroSolicitud)
        {
            if (numeroSolicitud[0] == 'S')
            {
                return int.Parse(numeroSolicitud.Substring(1));
            }
            else
            {
                return int.Parse(numeroSolicitud);
            }
        }

    }

}
