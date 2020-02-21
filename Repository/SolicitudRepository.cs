using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace CMDBApplication.Repository
{
    public class SolicitudRepository : Repository
    {
        public SolicitudRepository() { }
        public SolicitudRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Solicitud Insertar(Solicitud solicitud)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitud", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Solicitante.Id;

            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = solicitud.Ambiente.Id;
            cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = solicitud.Proyecto.Id;
            cmd.Parameters.Add(new SqlParameter("@analistades", SqlDbType.VarChar, 100)).Value = solicitud.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@analistatestprod", SqlDbType.VarChar, 100)).Value = solicitud.AnalistaTestProd;
            cmd.Parameters.Add(new SqlParameter("@copiara", SqlDbType.VarChar, 200)).Value = solicitud.CopiarA;
            cmd.Parameters.Add(new SqlParameter("@emergente", SqlDbType.Bit)).Value = solicitud.Emergente;
            cmd.Parameters.Add(new SqlParameter("@razonemergente", SqlDbType.VarChar, 200)).Value = solicitud.RazonEmergente;

            cmd.Parameters.Add(new SqlParameter("@Archivo1", SqlDbType.VarBinary)).Value = solicitud.Archivo1.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo2", SqlDbType.VarBinary)).Value = solicitud.Archivo2.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo3", SqlDbType.VarBinary)).Value = solicitud.Archivo3.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo4", SqlDbType.VarBinary)).Value = solicitud.Archivo4.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo5", SqlDbType.VarBinary)).Value = solicitud.Archivo5.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo6", SqlDbType.VarBinary)).Value = solicitud.Archivo6.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo7", SqlDbType.VarBinary)).Value = solicitud.Archivo7.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo8", SqlDbType.VarBinary)).Value = solicitud.Archivo8.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo9", SqlDbType.VarBinary)).Value = solicitud.Archivo9.Contenido;
            cmd.Parameters.Add(new SqlParameter("@Archivo10", SqlDbType.VarBinary)).Value = solicitud.Archivo10.Contenido;

            cmd.Parameters.Add(new SqlParameter("@NombreArchivo1", SqlDbType.VarChar, 100)).Value = solicitud.Archivo1.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo2", SqlDbType.VarChar, 100)).Value = solicitud.Archivo2.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo3", SqlDbType.VarChar, 100)).Value = solicitud.Archivo3.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo4", SqlDbType.VarChar, 100)).Value = solicitud.Archivo4.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo5", SqlDbType.VarChar, 100)).Value = solicitud.Archivo5.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo6", SqlDbType.VarChar, 100)).Value = solicitud.Archivo6.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo7", SqlDbType.VarChar, 100)).Value = solicitud.Archivo7.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo8", SqlDbType.VarChar, 100)).Value = solicitud.Archivo8.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo9", SqlDbType.VarChar, 100)).Value = solicitud.Archivo9.Nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArchivo10", SqlDbType.VarChar, 100)).Value = solicitud.Archivo10.Nombre;

            cmd.Parameters.Add(new SqlParameter("@FechaArchivo1", SqlDbType.DateTime)).Value = solicitud.Archivo1.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo2", SqlDbType.DateTime)).Value = solicitud.Archivo2.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo3", SqlDbType.DateTime)).Value = solicitud.Archivo3.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo4", SqlDbType.DateTime)).Value = solicitud.Archivo4.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo5", SqlDbType.DateTime)).Value = solicitud.Archivo5.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo6", SqlDbType.DateTime)).Value = solicitud.Archivo6.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo7", SqlDbType.DateTime)).Value = solicitud.Archivo7.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo8", SqlDbType.DateTime)).Value = solicitud.Archivo8.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo9", SqlDbType.DateTime)).Value = solicitud.Archivo9.Fecha;
            cmd.Parameters.Add(new SqlParameter("@FechaArchivo10", SqlDbType.DateTime)).Value = solicitud.Archivo10.Fecha;

            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = solicitud.Estado;
            cmd.Parameters.Add(new SqlParameter("@rfc", SqlDbType.VarChar, 10)).Value = solicitud.RFC;

            if (solicitud.FechaEjecucion.HasValue)
                cmd.Parameters.Add(new SqlParameter("@fechaejecucion", SqlDbType.DateTime)).Value = solicitud.FechaEjecucion.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@fechaejecucion", SqlDbType.DateTime)).Value = null;

            if (solicitud.FechaReversion.HasValue)
                cmd.Parameters.Add(new SqlParameter("@fechareversion", SqlDbType.DateTime)).Value = solicitud.FechaReversion.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@fechareversion", SqlDbType.DateTime)).Value = null;

            cmd.Parameters.Add(new SqlParameter("@reversion", SqlDbType.Bit)).Value = solicitud.Reversion;

            cmd.Parameters.Add(new SqlParameter("@principal", SqlDbType.Bit)).Value = solicitud.Principal;
            cmd.Parameters.Add(new SqlParameter("@adicional", SqlDbType.Bit)).Value = solicitud.Adicional;

            cmd.Parameters.Add(new SqlParameter("@regularizacion", SqlDbType.Bit)).Value = solicitud.Regularizacion;

            int id = 0;
            try
            {
                this.Conexion.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                if (solicitud.Logs.Count > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudLog";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Accion;
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Estado;
                    cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Logs[0].Usuario.Id;
                    cmd.Parameters.Add(new SqlParameter("@FechaHora", SqlDbType.DateTime)).Value = solicitud.Logs[0].FechaHora;
                    cmd.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar)).Value = solicitud.Logs[0].Comentario;
                    if (solicitud.Logs[0].Observacion.Id > 0)
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = solicitud.Logs[0].Observacion.Id;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = null;
                    cmd.ExecuteNonQuery();
                }
                foreach (Archivo archivo in solicitud.Aprobaciones)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudAprobacion";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 100)).Value = archivo.Nombre;                    
                    cmd.Parameters.Add(new SqlParameter("@Contenido", SqlDbType.VarBinary)).Value = archivo.Contenido;
                    cmd.Parameters.Add(new SqlParameter("@fechahora", SqlDbType.DateTime)).Value = archivo.Fecha.Value;
                    cmd.Parameters.Add(new SqlParameter("@contenttype", SqlDbType.VarChar)).Value = archivo.ContentType;
                    cmd.ExecuteNonQuery();
                }
                this.Conexion.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            solicitud.Id = id;
            return solicitud;
        }

        public Solicitud ActualizarSolSolicitadoxSol(Solicitud solicitud)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarSolSolicitadoxSol", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = solicitud.Id;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = solicitud.Estado;
            cmd.Parameters.Add(new SqlParameter("@copiara", SqlDbType.VarChar, 200)).Value = solicitud.CopiarA;
            int id = 0;
            try
            {
                this.Conexion.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                if (solicitud.Logs.Count > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudLog";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Accion;
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Estado;
                    cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Logs[0].Usuario.Id;
                    cmd.Parameters.Add(new SqlParameter("@FechaHora", SqlDbType.DateTime)).Value = solicitud.Logs[0].FechaHora;
                    cmd.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar)).Value = solicitud.Logs[0].Comentario;
                    if (solicitud.Logs[0].Observacion.Id > 0)
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = solicitud.Logs[0].Observacion.Id;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = null;
                    cmd.Parameters.Add(new SqlParameter("@Archivo", SqlDbType.VarBinary)).Value = solicitud.Logs[0].Archivo.Contenido;
                    cmd.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar,100)).Value = solicitud.Logs[0].Archivo.Nombre;

                    cmd.ExecuteNonQuery();
                }
                this.Conexion.Close();
                solicitud.Id = id;
                return solicitud;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public Solicitud ActualizarOtroSolicitadoxSol(Solicitud solicitud)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarSolSolicitadoxSol", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = solicitud.Id;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = solicitud.Estado;
            cmd.Parameters.Add(new SqlParameter("@copiara", SqlDbType.VarChar, 200)).Value = solicitud.CopiarA;
            int id = 0;
            try
            {
                this.Conexion.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                if (solicitud.Logs.Count > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudLog";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Accion;
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Estado;
                    cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Logs[0].Usuario.Id;
                    cmd.Parameters.Add(new SqlParameter("@FechaHora", SqlDbType.DateTime)).Value = solicitud.Logs[0].FechaHora;
                    cmd.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar)).Value = solicitud.Logs[0].Comentario;
                    if (solicitud.Logs[0].Observacion.Id > 0)
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = solicitud.Logs[0].Observacion.Id;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = null;
                    cmd.Parameters.Add(new SqlParameter("@Archivo", SqlDbType.VarBinary)).Value = solicitud.Logs[0].Archivo.Contenido;
                    cmd.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 100)).Value = solicitud.Logs[0].Archivo.Nombre;

                    cmd.ExecuteNonQuery();
                }
                this.Conexion.Close();
                solicitud.Id = id;
                return solicitud;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public Solicitud ActualizarRMSolicitadoxSol(Solicitud solicitud)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarRMSolicitadoxSol", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = solicitud.Id;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = solicitud.Estado;
            cmd.Parameters.Add(new SqlParameter("@Area1", SqlDbType.Int)).Value = solicitud.Area1.Id;
            cmd.Parameters.Add(new SqlParameter("@Area2", SqlDbType.Int)).Value = solicitud.Area2.Id;
            cmd.Parameters.Add(new SqlParameter("@Area3", SqlDbType.Int)).Value = solicitud.Area3.Id;
            cmd.Parameters.Add(new SqlParameter("@Area4", SqlDbType.Int)).Value = solicitud.Area4.Id;
            cmd.Parameters.Add(new SqlParameter("@Area5", SqlDbType.Int)).Value = solicitud.Area5.Id;
            cmd.Parameters.Add(new SqlParameter("@Area6", SqlDbType.Int)).Value = solicitud.Area6.Id;
            cmd.Parameters.Add(new SqlParameter("@Area7", SqlDbType.Int)).Value = solicitud.Area7.Id;
            cmd.Parameters.Add(new SqlParameter("@Area8", SqlDbType.Int)).Value = solicitud.Area8.Id;
            cmd.Parameters.Add(new SqlParameter("@Area9", SqlDbType.Int)).Value = solicitud.Area9.Id;
            cmd.Parameters.Add(new SqlParameter("@Area10", SqlDbType.Int)).Value = solicitud.Area10.Id;
            cmd.Parameters.Add(new SqlParameter("@copiara", SqlDbType.VarChar, 200)).Value = solicitud.CopiarA;
            if (solicitud.Ventana == null)
                cmd.Parameters.Add(new SqlParameter("@ventanaid", SqlDbType.Int)).Value = null;
            else
                cmd.Parameters.Add(new SqlParameter("@ventanaid", SqlDbType.Int)).Value = solicitud.Ventana.Id;
            cmd.Parameters.Add(new SqlParameter("@ejecutaremergente", SqlDbType.Bit)).Value = solicitud.EjecutarEmergente;

            int id = 0;
            try
            {
                this.Conexion.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                int tamano = solicitud.Logs.Count;
                if (tamano > 0)
                {                    
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudLog";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = solicitud.Logs[tamano-1].Accion;
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 50)).Value = solicitud.Logs[tamano - 1].Estado;
                    cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Logs[tamano - 1].Usuario.Id;
                    cmd.Parameters.Add(new SqlParameter("@FechaHora", SqlDbType.DateTime)).Value = solicitud.Logs[tamano - 1].FechaHora;
                    cmd.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar)).Value = solicitud.Logs[tamano - 1].Comentario;
                    if (solicitud.Logs[0].Observacion.Id > 0)
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = solicitud.Logs[0].Observacion.Id;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = null;
                    cmd.Parameters.Add(new SqlParameter("@Archivo", SqlDbType.VarBinary)).Value = solicitud.Logs[0].Archivo.Contenido;
                    cmd.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 100)).Value = solicitud.Logs[0].Archivo.Nombre;
                    cmd.ExecuteNonQuery();
                }
                
                solicitud.Id = id;

                cmd.CommandText = "dbo.usp_ActualizarSolicitudAprobacion";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@aprobacionid", SqlDbType.Int);
                cmd.Parameters.Add("@areaid", SqlDbType.Int);
                cmd.Parameters.Add("@fechahora", SqlDbType.DateTime);
                cmd.Parameters.Add("@contenttype", SqlDbType.VarChar);
                foreach (var aprobacion in solicitud.Aprobaciones)
                {
                    cmd.Parameters["@aprobacionid"].Value = aprobacion.Id;
                    cmd.Parameters["@areaid"].Value = aprobacion.Area==null?0:aprobacion.Area.Id;
                    cmd.Parameters["@fechahora"].Value = aprobacion.Fecha;
                    cmd.Parameters["@contenttype"].Value = aprobacion.ContentType;
                    
                    cmd.ExecuteNonQuery();
                }
                this.Conexion.Close();
                return solicitud;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public Solicitud ActualizarSolObservadoxRM(Solicitud solicitud)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarSolObservadoxRM", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = solicitud.Id;

            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = solicitud.Ambiente.Id;
            cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = solicitud.Proyecto.Id;
            cmd.Parameters.Add(new SqlParameter("@analistades", SqlDbType.VarChar, 100)).Value = solicitud.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@analistatestprod", SqlDbType.VarChar, 100)).Value = solicitud.AnalistaTestProd;
            cmd.Parameters.Add(new SqlParameter("@copiara", SqlDbType.VarChar, 200)).Value = solicitud.CopiarA;
            cmd.Parameters.Add(new SqlParameter("@emergente", SqlDbType.Bit)).Value = solicitud.Emergente;
            cmd.Parameters.Add(new SqlParameter("@razonemergente", SqlDbType.VarChar, 200)).Value = solicitud.RazonEmergente;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = solicitud.Estado;

            if (solicitud.FechaEjecucion.HasValue)
                cmd.Parameters.Add(new SqlParameter("@fechaejecucion", SqlDbType.DateTime)).Value = solicitud.FechaEjecucion.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@fechaejecucion", SqlDbType.DateTime)).Value = null;

            if (solicitud.FechaReversion.HasValue)
                cmd.Parameters.Add(new SqlParameter("@fechareversion", SqlDbType.DateTime)).Value = solicitud.FechaReversion.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@fechareversion", SqlDbType.DateTime)).Value = null;

            cmd.Parameters.Add(new SqlParameter("@reversion", SqlDbType.Bit)).Value = solicitud.Reversion;

            cmd.Parameters.Add(new SqlParameter("@rfc", SqlDbType.VarChar, 10)).Value = solicitud.RFC;
            cmd.Parameters.Add(new SqlParameter("@principal", SqlDbType.Bit)).Value = solicitud.Principal;
            cmd.Parameters.Add(new SqlParameter("@adicional", SqlDbType.Bit)).Value = solicitud.Adicional;
            cmd.Parameters.Add(new SqlParameter("@regularizacion", SqlDbType.Bit)).Value = solicitud.Regularizacion;

            int id = 0;
            try
            {
                this.Conexion.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                if (solicitud.Logs.Count > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.usp_InsertarSolicitudLog";
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Accion;
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 50)).Value = solicitud.Logs[0].Estado;
                    cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = solicitud.Logs[0].Usuario.Id;
                    cmd.Parameters.Add(new SqlParameter("@FechaHora", SqlDbType.DateTime)).Value = solicitud.Logs[0].FechaHora;
                    cmd.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar)).Value = solicitud.Logs[0].Comentario;
                    if (solicitud.Logs[0].Observacion.Id > 0)
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = solicitud.Logs[0].Observacion.Id;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ObservacionId", SqlDbType.Int)).Value = null;
                    cmd.Parameters.Add(new SqlParameter("@Archivo", SqlDbType.VarBinary)).Value = solicitud.Logs[0].Archivo.Contenido;
                    cmd.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 100)).Value = solicitud.Logs[0].Archivo.Nombre;

                    cmd.ExecuteNonQuery();
                }
                this.Conexion.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            solicitud.Id = id;
            return solicitud;
        }

        public List<Solicitud> ListarPendientesRM()
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesIngresadas", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    
                    solicitudes.Add(solicitud);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Aprobaciones = ListarAprobaciones(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Solicitud> ListarAprobadosRM()
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesAprobadasRM", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    if (sdr["Area1"] != DBNull.Value)
                    {
                        solicitud.Area1 = new Area { Id = Convert.ToInt32(sdr["Area1"]) };
                    }
                    if (sdr["Area2"] != DBNull.Value)
                    {
                        solicitud.Area2 = new Area { Id = Convert.ToInt32(sdr["Area2"]) };
                    }
                    if (sdr["Area3"] != DBNull.Value)
                    {
                        solicitud.Area3 = new Area { Id = Convert.ToInt32(sdr["Area3"]) };
                    }
                    if (sdr["Area4"] != DBNull.Value)
                    {
                        solicitud.Area4 = new Area { Id = Convert.ToInt32(sdr["Area4"]) };
                    }
                    if (sdr["Area5"] != DBNull.Value)
                    {
                        solicitud.Area5 = new Area { Id = Convert.ToInt32(sdr["Area5"]) };
                    }
                    if (sdr["Area6"] != DBNull.Value)
                    {
                        solicitud.Area6 = new Area { Id = Convert.ToInt32(sdr["Area6"]) };
                    }
                    if (sdr["Area7"] != DBNull.Value)
                    {
                        solicitud.Area7 = new Area { Id = Convert.ToInt32(sdr["Area7"]) };
                    }
                    if (sdr["Area8"] != DBNull.Value)
                    {
                        solicitud.Area8 = new Area { Id = Convert.ToInt32(sdr["Area8"]) };
                    }
                    if (sdr["Area9"] != DBNull.Value)
                    {
                        solicitud.Area9 = new Area { Id = Convert.ToInt32(sdr["Area9"]) };
                    }
                    if (sdr["Area10"] != DBNull.Value)
                    {
                        solicitud.Area10 = new Area { Id = Convert.ToInt32(sdr["Area10"]) };
                    }
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitudes.Add(solicitud);
                    
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Aprobaciones = ListarAprobaciones(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Solicitud> ListarPendientesOperador(int usuarioId)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesEnviadas", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = usuarioId;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };    
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitudes.Add(solicitud);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Aprobaciones = ListarAprobaciones(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Solicitud> ListarPendientesCM()
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesPendientesCM", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Solicitud s = new Solicitud();
                    s.Id = Convert.ToInt32(sdr["id"]);
                    s.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    s.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    s.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    s.AnalistaDesarrollo = sdr["analistades"].ToString();
                    s.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    s.CopiarA = sdr["copiara"].ToString();
                    s.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    s.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    s.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    s.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    s.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    s.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    s.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    s.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    s.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    s.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    s.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    s.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    s.RazonEmergente = sdr["RazonEmergente"].ToString();
                    s.Estado = sdr["Estado"].ToString();
                    s.Principal = Convert.ToBoolean(sdr["principal"]);
                    s.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        s.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        s.FechaEjecucion = null;
                    }
                    solicitudes.Add(s);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Aprobaciones = ListarAprobaciones(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Solicitud> ListarPendientesEjecutor(int usuarioId)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesPendientesEjecutor", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = usuarioId;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitudes.Add(solicitud);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Aprobaciones = ListarAprobaciones(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public Solicitud Obtener(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerSolicitud", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            Solicitud solicitud = null;
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    solicitud = new Solicitud();
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiarA"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    if (sdr["fechaejecucion"] == System.DBNull.Value)
                        solicitud.FechaEjecucion = null;
                    else
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);

                    if (sdr["fechareversion"] == System.DBNull.Value)
                    {
                        solicitud.FechaReversion = null;
                    }
                    else
                    {
                        solicitud.FechaReversion = Convert.ToDateTime(sdr["fechareversion"]);
                    }
                    solicitud.Reversion = Convert.ToBoolean(sdr["reversion"]);

                    solicitud.RFC = sdr["rfc"].ToString();
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);

                    #region Nombres de Archivos
                    solicitud.Archivo1.Nombre = sdr["NombreArchivo1"].ToString();
                    solicitud.Archivo2.Nombre = sdr["NombreArchivo2"].ToString();
                    solicitud.Archivo3.Nombre = sdr["NombreArchivo3"].ToString();
                    solicitud.Archivo4.Nombre = sdr["NombreArchivo4"].ToString();
                    solicitud.Archivo5.Nombre = sdr["NombreArchivo5"].ToString();
                    solicitud.Archivo6.Nombre = sdr["NombreArchivo6"].ToString();
                    solicitud.Archivo7.Nombre = sdr["NombreArchivo7"].ToString();
                    solicitud.Archivo8.Nombre = sdr["NombreArchivo8"].ToString();
                    solicitud.Archivo9.Nombre = sdr["NombreArchivo9"].ToString();
                    solicitud.Archivo10.Nombre = sdr["NombreArchivo10"].ToString();
                    #endregion

                    #region Areas
                    solicitud.Area1 = new Area { Id = sdr["Area1"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area1"]) };
                    solicitud.Area2 = new Area { Id = sdr["Area2"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area2"]) };
                    solicitud.Area3 = new Area { Id = sdr["Area3"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area3"]) };
                    solicitud.Area4 = new Area { Id = sdr["Area4"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area4"]) };
                    solicitud.Area5 = new Area { Id = sdr["Area5"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area5"]) };
                    solicitud.Area6 = new Area { Id = sdr["Area6"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area6"]) };
                    solicitud.Area7 = new Area { Id = sdr["Area7"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area7"]) };
                    solicitud.Area8 = new Area { Id = sdr["Area8"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area8"]) };
                    solicitud.Area9 = new Area { Id = sdr["Area9"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area9"]) };
                    solicitud.Area10 = new Area { Id = sdr["Area10"] == System.DBNull.Value ? 0 : Convert.ToInt32(sdr["Area10"]) };
                    #endregion

                    #region Fechas
                    if (sdr["FechaArchivo1"] == DBNull.Value)
                        solicitud.Archivo1.Fecha =null;
                    else
                        solicitud.Archivo1.Fecha = Convert.ToDateTime(sdr["FechaArchivo1"]);

                    if (sdr["FechaArchivo2"] == DBNull.Value)
                        solicitud.Archivo2.Fecha = null;
                    else
                        solicitud.Archivo2.Fecha = Convert.ToDateTime(sdr["FechaArchivo2"]);

                    if (sdr["FechaArchivo3"] == DBNull.Value)
                        solicitud.Archivo3.Fecha = null;
                    else
                        solicitud.Archivo3.Fecha = Convert.ToDateTime(sdr["FechaArchivo3"]);

                    if (sdr["FechaArchivo4"] == DBNull.Value)
                        solicitud.Archivo4.Fecha = null;
                    else
                        solicitud.Archivo4.Fecha = Convert.ToDateTime(sdr["FechaArchivo4"]);

                    if (sdr["FechaArchivo5"] == DBNull.Value)
                        solicitud.Archivo5.Fecha = null;
                    else
                        solicitud.Archivo5.Fecha = Convert.ToDateTime(sdr["FechaArchivo5"]);

                    if (sdr["FechaArchivo6"] == DBNull.Value)
                        solicitud.Archivo6.Fecha = null;
                    else
                        solicitud.Archivo6.Fecha = Convert.ToDateTime(sdr["FechaArchivo6"]);

                    if (sdr["FechaArchivo7"] == DBNull.Value)
                        solicitud.Archivo7.Fecha = null;
                    else
                        solicitud.Archivo7.Fecha = Convert.ToDateTime(sdr["FechaArchivo7"]);

                    if (sdr["FechaArchivo8"] == DBNull.Value)
                        solicitud.Archivo8.Fecha = null;
                    else
                        solicitud.Archivo8.Fecha = Convert.ToDateTime(sdr["FechaArchivo8"]);

                    if (sdr["FechaArchivo9"] == DBNull.Value)
                        solicitud.Archivo9.Fecha = null;
                    else
                        solicitud.Archivo9.Fecha = Convert.ToDateTime(sdr["FechaArchivo9"]);

                    if (sdr["FechaArchivo10"] == DBNull.Value)
                        solicitud.Archivo10.Fecha = null;
                    else
                        solicitud.Archivo10.Fecha = Convert.ToDateTime(sdr["FechaArchivo10"]);
                    #endregion

                    #region Comentarios
                    solicitud.Archivo1.Comentario = sdr["comentario1"].ToString();
                    solicitud.Archivo2.Comentario = sdr["comentario2"].ToString();
                    solicitud.Archivo3.Comentario = sdr["comentario3"].ToString();
                    solicitud.Archivo4.Comentario = sdr["comentario4"].ToString();
                    solicitud.Archivo5.Comentario = sdr["comentario5"].ToString();
                    solicitud.Archivo6.Comentario = sdr["comentario6"].ToString();
                    solicitud.Archivo7.Comentario = sdr["comentario7"].ToString();
                    solicitud.Archivo8.Comentario = sdr["comentario8"].ToString();
                    solicitud.Archivo9.Comentario = sdr["comentario9"].ToString();
                    solicitud.Archivo10.Comentario = sdr["comentario10"].ToString();
                    #endregion

                    #region Estados
                    solicitud.Archivo1.Estado = Convert.ToBoolean(sdr["estado1"]);
                    solicitud.Archivo2.Estado = Convert.ToBoolean(sdr["estado2"]);
                    solicitud.Archivo3.Estado = Convert.ToBoolean(sdr["estado3"]);
                    solicitud.Archivo4.Estado = Convert.ToBoolean(sdr["estado4"]);
                    solicitud.Archivo5.Estado = Convert.ToBoolean(sdr["estado5"]);
                    solicitud.Archivo6.Estado = Convert.ToBoolean(sdr["estado6"]);
                    solicitud.Archivo7.Estado = Convert.ToBoolean(sdr["estado7"]);
                    solicitud.Archivo8.Estado = Convert.ToBoolean(sdr["estado8"]);
                    solicitud.Archivo9.Estado = Convert.ToBoolean(sdr["estado9"]);
                    solicitud.Archivo10.Estado = Convert.ToBoolean(sdr["estado10"]);
                    #endregion

                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Ventana = sdr["Ventanaid"] == DBNull.Value ? null : new Ventana { Id = Convert.ToInt32(sdr["ventanaid"]) };
                    solicitud.EjecutarEmergente = Convert.ToBoolean(sdr["ejecutaremergente"]);
                    solicitud.Adicional = Convert.ToBoolean(sdr["adicional"]);
                    solicitud.Regularizacion = Convert.ToBoolean(sdr["regularizacion"]);
                }
                sdr.Close();
                if (solicitud != null)
                {
                    AmbienteRepository ar = new AmbienteRepository();
                    ProyectoRepository pr = new ProyectoRepository();
                    AreaRepository arear = new AreaRepository();
                    UsuarioRepository ur = new UsuarioRepository();
                    VentanaRepository vr = new VentanaRepository();
                    solicitud.Proyecto = pr.Obtener(solicitud.Proyecto.Id);
                    solicitud.Ambiente = ar.Obtener(solicitud.Ambiente.Id);
                    solicitud.Area1 = arear.Obtener(solicitud.Area1.Id);
                    solicitud.Area2 = arear.Obtener(solicitud.Area2.Id);
                    solicitud.Area3 = arear.Obtener(solicitud.Area3.Id);
                    solicitud.Area4 = arear.Obtener(solicitud.Area4.Id);
                    solicitud.Area5 = arear.Obtener(solicitud.Area5.Id);
                    solicitud.Area6 = arear.Obtener(solicitud.Area6.Id);
                    solicitud.Area7 = arear.Obtener(solicitud.Area7.Id);
                    solicitud.Area8 = arear.Obtener(solicitud.Area8.Id);
                    solicitud.Area9 = arear.Obtener(solicitud.Area9.Id);
                    solicitud.Area10 = arear.Obtener(solicitud.Area10.Id);
                    solicitud.Solicitante = ur.Obtener(solicitud.Solicitante.Id);
                    solicitud.Ventana = solicitud.Ventana != null ? vr.Obtener(solicitud.Ventana.Id) : null;
                    solicitud.Proyecto.Ambientes = pr.ListarAmbiente(solicitud.Proyecto);
                }
                if (solicitud != null)
                {
                    cmd.CommandText = "dbo.usp_ListarLog";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = solicitud.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Log log = new Log();
                        log.Id = Convert.ToInt32(sdr["Id"]);
                        log.Accion = sdr["Accion"].ToString();
                        log.Estado = sdr["Estado"].ToString();
                        log.Usuario = new Usuario { Id = Convert.ToInt32(sdr["UsuarioId"]) };
                        log.FechaHora = Convert.ToDateTime(sdr["FechaHora"]);
                        log.Comentario = sdr["Comentario"].ToString();
                        log.Archivo.Nombre = sdr["NombreArchivo"].ToString();
                        if (sdr["ObservacionId"] != DBNull.Value)
                        {
                            log.Observacion = new Observacion { Id = Convert.ToInt32(sdr["ObservacionId"]) };
                        }                        
                        solicitud.Logs.Add(log);
                    }
                    sdr.Close();
                    cmd.CommandText = "dbo.usp_ListarSolicitudAprobacion";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = solicitud.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Archivo archivo = new Archivo();
                        archivo.Id = Convert.ToInt32(sdr["id"]);
                        archivo.Nombre = sdr["NombreArchivo"].ToString();
                        if (sdr["AreaId"] != DBNull.Value)
                        {
                            archivo.Area = new Area { Id = Convert.ToInt32(sdr["AreaId"]), Nombre = sdr["AreaNombre"].ToString(),Color=sdr["Color"].ToString() };
                        }
                        else
                        {
                            archivo.Area = null;
                        }
                        if (sdr["FechaHora"] != DBNull.Value)
                        {
                            archivo.Fecha = Convert.ToDateTime(sdr["FechaHora"]);
                        }
                        if (sdr["ContentType"] != DBNull.Value)
                        {
                            archivo.ContentType = sdr["contenttype"].ToString();
                        }                        
                        solicitud.Aprobaciones.Add(archivo);
                    }
                    sdr.Close();
                    UsuarioRepository ur = new UsuarioRepository();
                    foreach (Log log in solicitud.Logs)
                    {
                        log.Usuario = ur.Obtener(log.Usuario.Id);
                    }
                }

                #region Obtener Conflictos de BD por Archivo
                solicitud.Archivo1.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo1.Nombre) ? ListarConflicto(solicitud.Id, 1) : new List<ConflictoBD>();
                solicitud.Archivo2.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo2.Nombre) ? ListarConflicto(solicitud.Id, 2) : new List<ConflictoBD>();
                solicitud.Archivo3.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo3.Nombre) ? ListarConflicto(solicitud.Id, 3) : new List<ConflictoBD>();
                solicitud.Archivo4.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo4.Nombre) ? ListarConflicto(solicitud.Id, 4) : new List<ConflictoBD>();
                solicitud.Archivo5.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo5.Nombre) ? ListarConflicto(solicitud.Id, 5) : new List<ConflictoBD>();
                solicitud.Archivo6.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo6.Nombre) ? ListarConflicto(solicitud.Id, 6) : new List<ConflictoBD>();
                solicitud.Archivo7.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo7.Nombre) ? ListarConflicto(solicitud.Id, 7) : new List<ConflictoBD>();
                solicitud.Archivo8.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo8.Nombre) ? ListarConflicto(solicitud.Id, 8) : new List<ConflictoBD>();
                solicitud.Archivo9.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo9.Nombre) ? ListarConflicto(solicitud.Id, 9) : new List<ConflictoBD>();
                solicitud.Archivo10.ConflictosBD = !String.IsNullOrEmpty(solicitud.Archivo10.Nombre) ? ListarConflicto(solicitud.Id, 10) : new List<ConflictoBD>();                
                #endregion

                return solicitud;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public List<Archivo> ListarAprobaciones(int id)
        {
            try
            {
                List<Archivo> aprobaciones = new List<Archivo>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudAprobacion", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SolicitudId", SqlDbType.Int)).Value = id;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Archivo archivo = new Archivo();
                    archivo.Id = Convert.ToInt32(sdr["id"]);
                    archivo.Nombre = sdr["NombreArchivo"].ToString();
                    if (sdr["AreaId"] != DBNull.Value)
                    {
                        archivo.Area = new Area { Id = Convert.ToInt32(sdr["AreaId"]), Nombre = sdr["AreaNombre"].ToString() };
                    }
                    if (sdr["fechahora"] != DBNull.Value)
                    {
                        archivo.Fecha = Convert.ToDateTime(sdr["fechahora"]);
                    }
                    if (sdr["contenttype"] != DBNull.Value)
                    {
                        archivo.ContentType = sdr["contenttype"].ToString();
                    }
                    aprobaciones.Add(archivo);
                }
                sdr.Close();
                return aprobaciones;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public Archivo ObtenerArchivo(int id, int numArchivo)
        {
            string numeroArchivo = numArchivo.ToString();
            SqlCommand cmd = new SqlCommand(String.Concat("dbo.usp_ObtenerArchivo" , numArchivo), this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("@numArchivo", SqlDbType.Int)).Value = numArchivo;
            try
            {
                Archivo archivo = new Archivo();
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    archivo.Contenido = (byte[])sdr[0];
                    archivo.Nombre = sdr[1].ToString();
                }
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public Archivo ObtenerArchivoLog(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerArchivoLog", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Archivo archivo = new Archivo();
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    archivo.Contenido = (byte[])sdr[0];
                    archivo.Nombre = sdr[1].ToString();
                }
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public Archivo ActualizarArchivo(int id, int numArchivo, Archivo archivo)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarArchivo" + numArchivo, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("@archivo", SqlDbType.VarBinary)).Value = archivo.Contenido;
            cmd.Parameters.Add(new SqlParameter("@nombrearchivo", SqlDbType.VarChar, 100)).Value = archivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@fechaarchivo", SqlDbType.DateTime)).Value = archivo.Fecha;
            try
            {
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                this.Conexion.Close();
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }
        }

        public List<string> ListarAccciones(Usuario usuario, string estado)
        {
            List<string> acciones = new List<string>();

            SqlCommand cmd = new SqlCommand("dbo.usp_ListarAcciones", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@rol", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = estado;

            if (usuario.Operador)
            {
                cmd.Parameters["@rol"].Value = "Operador";
                ListarAccionesPorRol(acciones, cmd);
            }
            if (usuario.RM)
            {
                cmd.Parameters["@rol"].Value = "RM";
                ListarAccionesPorRol(acciones, cmd);
            }
            if (usuario.CM)
            {
                cmd.Parameters["@rol"].Value = "CM";
                ListarAccionesPorRol(acciones, cmd);
            }
            if (usuario.Ejecutor)
            {
                cmd.Parameters["@rol"].Value = "Ejecutor";
                ListarAccionesPorRol(acciones, cmd);
            }
            return acciones;
        }

        private void ListarAccionesPorRol(List<string> acciones, SqlCommand cmd)
        {
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    acciones.Add(sdr["Accion"].ToString());
                }
                sdr.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }
        }

        public string ObtenerEstado(string rol, string estado, string accion)
        {
            string nuevoEstado = "";
            EventLog.WriteEntry("SolicitudRepository", "linea 1238");
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerEstado", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            EventLog.WriteEntry("SolicitudRepository.ObtenerEstado", "rol "+rol);
            EventLog.WriteEntry("SolicitudRepository.ObtenerEstado", "estado "+estado);
            EventLog.WriteEntry("SolicitudRepository.ObtenerEstado", "accion " + accion);
            
            cmd.Parameters.Add(new SqlParameter("@rol", SqlDbType.VarChar, 50)).Value = rol;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = estado;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = accion;
            try
            {
                EventLog.WriteEntry("SolicitudRepository", "linea 1258");
                this.Conexion.Open();
                var resultado = cmd.ExecuteScalar();
                EventLog.WriteEntry("SolicitudRepository", "linea 1261");
                if (resultado != null)
                {
                    nuevoEstado = resultado.ToString();
                }                
                this.Conexion.Close();
                return nuevoEstado;
            }
            catch
            {
                EventLog.WriteEntry("SolicitudRepository", "linea 1268");
                throw;
            }
            finally
            {
                EventLog.WriteEntry("SolicitudRepository", "linea 1273");
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public List<Solicitud> Listar(string codigo, int ambiente, int proyecto, string analistaDes, string analistaTest, bool emergente,
            string razonEmergente,DateTime? fechaDesde, DateTime? fechaHasta,string rfc,string solicitante,bool principal,bool adicional=false,bool todos=true,
            DateTime? fechaEjecucionDesde = null,DateTime? fechaEjecucionHasta = null)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitud", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 10)).Value = codigo;
            cmd.Parameters.Add(new SqlParameter("@proyectoId", SqlDbType.Int)).Value = proyecto;
            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambiente;
            cmd.Parameters.Add(new SqlParameter("@analistades", SqlDbType.VarChar, 100)).Value = analistaDes;
            cmd.Parameters.Add(new SqlParameter("@analistatest", SqlDbType.VarChar, 100)).Value = analistaTest;
            cmd.Parameters.Add(new SqlParameter("@emergente", SqlDbType.Bit)).Value = emergente;
            cmd.Parameters.Add(new SqlParameter("@razonemergente", SqlDbType.VarChar, 200)).Value = razonEmergente;
            cmd.Parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.Date)).Value = fechaDesde;
            cmd.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.Date)).Value = fechaHasta;
            cmd.Parameters.Add(new SqlParameter("@rfc", SqlDbType.VarChar, 10)).Value = rfc;
            cmd.Parameters.Add(new SqlParameter("@solicitante", SqlDbType.VarChar, 50)).Value = solicitante;
            cmd.Parameters.Add(new SqlParameter("@principal", SqlDbType.Bit)).Value = principal;
            cmd.Parameters.Add(new SqlParameter("@adicional", SqlDbType.Bit)).Value = adicional;
            cmd.Parameters.Add(new SqlParameter("@todos", SqlDbType.Bit)).Value = todos;
            if (fechaEjecucionDesde!=null)
                cmd.Parameters.Add(new SqlParameter("@fechaEjecucionDesde", SqlDbType.Date)).Value = fechaEjecucionDesde.Value;

            if (fechaEjecucionHasta != null)
                cmd.Parameters.Add(new SqlParameter("@fechaEjecucionHasta", SqlDbType.Date)).Value = fechaEjecucionHasta.Value;

            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    DateTime? fechaHora = null;
                    if (sdr["fechareversion"] != DBNull.Value)
                        fechaHora = Convert.ToDateTime(sdr["fechareversion"]);

                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Reversion = Convert.ToBoolean(sdr["reversion"]);
                    solicitud.FechaReversion = fechaHora;
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitud.Adicional = Convert.ToBoolean(sdr["adicional"]);

                    #region Comentarios
                    solicitud.Archivo1.Comentario = sdr["comentario1"].ToString();
                    solicitud.Archivo2.Comentario = sdr["comentario2"].ToString();
                    solicitud.Archivo3.Comentario = sdr["comentario3"].ToString();
                    solicitud.Archivo4.Comentario = sdr["comentario4"].ToString();
                    solicitud.Archivo5.Comentario = sdr["comentario5"].ToString();
                    solicitud.Archivo6.Comentario = sdr["comentario6"].ToString();
                    solicitud.Archivo7.Comentario = sdr["comentario7"].ToString();
                    solicitud.Archivo8.Comentario = sdr["comentario8"].ToString();
                    solicitud.Archivo9.Comentario = sdr["comentario9"].ToString();
                    solicitud.Archivo10.Comentario = sdr["comentario10"].ToString();
                    #endregion

                    #region Estados
                    solicitud.Archivo1.Estado = Convert.ToBoolean(sdr["estado1"]);
                    solicitud.Archivo2.Estado = Convert.ToBoolean(sdr["estado2"]);
                    solicitud.Archivo3.Estado = Convert.ToBoolean(sdr["estado3"]);
                    solicitud.Archivo4.Estado = Convert.ToBoolean(sdr["estado4"]);
                    solicitud.Archivo5.Estado = Convert.ToBoolean(sdr["estado5"]);
                    solicitud.Archivo6.Estado = Convert.ToBoolean(sdr["estado6"]);
                    solicitud.Archivo7.Estado = Convert.ToBoolean(sdr["estado7"]);
                    solicitud.Archivo8.Estado = Convert.ToBoolean(sdr["estado8"]);
                    solicitud.Archivo9.Estado = Convert.ToBoolean(sdr["estado9"]);
                    solicitud.Archivo10.Estado = Convert.ToBoolean(sdr["estado10"]);
                    #endregion

                    solicitud.Pendiente = Convert.ToBoolean(sdr["pendiente"]);
                    solicitud.Satisfactorio = Convert.ToBoolean(sdr["satisfactorio"]);
                    solicitudes.Add(solicitud);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                    s.Logs = ListarLog(s.Id);
                    s.Archivo1.ConflictosBD = !String.IsNullOrEmpty(s.Archivo1.Nombre) ? ListarConflicto(s.Id, 1) : new List<ConflictoBD>();
                    s.Archivo2.ConflictosBD = !String.IsNullOrEmpty(s.Archivo2.Nombre) ? ListarConflicto(s.Id, 2) : new List<ConflictoBD>();
                    s.Archivo3.ConflictosBD = !String.IsNullOrEmpty(s.Archivo3.Nombre) ? ListarConflicto(s.Id, 3) : new List<ConflictoBD>();
                    s.Archivo4.ConflictosBD = !String.IsNullOrEmpty(s.Archivo4.Nombre) ? ListarConflicto(s.Id, 4) : new List<ConflictoBD>();
                    s.Archivo5.ConflictosBD = !String.IsNullOrEmpty(s.Archivo5.Nombre) ? ListarConflicto(s.Id, 5) : new List<ConflictoBD>();
                    s.Archivo6.ConflictosBD = !String.IsNullOrEmpty(s.Archivo6.Nombre) ? ListarConflicto(s.Id, 6) : new List<ConflictoBD>();
                    s.Archivo7.ConflictosBD = !String.IsNullOrEmpty(s.Archivo7.Nombre) ? ListarConflicto(s.Id, 7) : new List<ConflictoBD>();
                    s.Archivo8.ConflictosBD = !String.IsNullOrEmpty(s.Archivo8.Nombre) ? ListarConflicto(s.Id, 8) : new List<ConflictoBD>();
                    s.Archivo9.ConflictosBD = !String.IsNullOrEmpty(s.Archivo9.Nombre) ? ListarConflicto(s.Id, 9) : new List<ConflictoBD>();
                    s.Archivo10.ConflictosBD = !String.IsNullOrEmpty(s.Archivo10.Nombre) ? ListarConflicto(s.Id, 10) : new List<ConflictoBD>();
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }

        }

        public List<Solicitud> ListarPorSolicitante(int usuarioId)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesPorSolicitante", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)).Value = usuarioId;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    DateTime? fechaHora = null;
                    if (sdr["fechareversion"] != DBNull.Value)
                        fechaHora = Convert.ToDateTime(sdr["fechareversion"]);

                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo { Nombre = sdr["NombreArchivo1"].ToString() };
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Reversion = Convert.ToBoolean(sdr["reversion"]);
                    solicitud.FechaReversion = fechaHora;
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitud.Adicional = Convert.ToBoolean(sdr["adicional"]);
                    solicitudes.Add(solicitud);                    
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Logs = ListarLog(s.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Solicitud> ListarPorProyecto(int proyectoId)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolicitudesPorProyecto", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = proyectoId;
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    DateTime? fechaHora = null;
                    if (sdr["fechareversion"] != DBNull.Value)
                        fechaHora = Convert.ToDateTime(sdr["fechareversion"]);

                    Solicitud solicitud = new Solicitud();
                    
                    solicitud.Id = Convert.ToInt32(sdr["id"]);
                    solicitud.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    solicitud.FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"]);
                    solicitud.Solicitante = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    solicitud.AnalistaDesarrollo = sdr["analistades"].ToString();
                    solicitud.AnalistaTestProd = sdr["analistatestprod"].ToString();
                    solicitud.CopiarA = sdr["copiara"].ToString();
                    solicitud.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    solicitud.Archivo1 = new Archivo{Nombre = sdr["NombreArchivo1"].ToString()};
                    solicitud.Archivo2 = new Archivo { Nombre = sdr["NombreArchivo2"].ToString() };
                    solicitud.Archivo3 = new Archivo { Nombre = sdr["NombreArchivo3"].ToString() };
                    solicitud.Archivo4 = new Archivo { Nombre = sdr["NombreArchivo4"].ToString() };
                    solicitud.Archivo5 = new Archivo { Nombre = sdr["NombreArchivo5"].ToString() };
                    solicitud.Archivo6 = new Archivo { Nombre = sdr["NombreArchivo6"].ToString() };
                    solicitud.Archivo7 = new Archivo { Nombre = sdr["NombreArchivo7"].ToString() };
                    solicitud.Archivo8 = new Archivo { Nombre = sdr["NombreArchivo8"].ToString() };
                    solicitud.Archivo9 = new Archivo { Nombre = sdr["NombreArchivo9"].ToString() };
                    solicitud.Archivo10 = new Archivo { Nombre = sdr["NombreArchivo10"].ToString() };
                    solicitud.Emergente = Convert.ToBoolean(sdr["Emergente"]);
                    solicitud.RazonEmergente = sdr["RazonEmergente"].ToString();
                    solicitud.Estado = sdr["Estado"].ToString();
                    solicitud.Reversion = Convert.ToBoolean(sdr["reversion"]);
                    solicitud.FechaReversion = fechaHora;
                    solicitud.Principal = Convert.ToBoolean(sdr["principal"]);
                    solicitud.RFC = sdr["RFC"].ToString();
                    if (sdr["fechaejecucion"] != DBNull.Value)
                    {
                        solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    else
                    {
                        solicitud.FechaEjecucion = null;
                    }
                    solicitud.Adicional = Convert.ToBoolean(sdr["adicional"]);
                    solicitudes.Add(solicitud);
                }
                sdr.Close();
                AmbienteRepository ar = new AmbienteRepository();
                ProyectoRepository pr = new ProyectoRepository();
                UsuarioRepository ur = new UsuarioRepository();
                foreach (Solicitud s in solicitudes)
                {
                    s.Proyecto = pr.Obtener(s.Proyecto.Id);
                    s.Ambiente = ar.Obtener(s.Ambiente.Id);
                    s.Logs = ListarLog(s.Id);
                    s.Solicitante = ur.Obtener(s.Solicitante.Id);
                }
                return solicitudes;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public Archivo ObtenerAprobacion(int solicitudId, string nombre)
        {
            Archivo archivo = null;
            var cmd = new SqlCommand("dbo.usp_ObtenerArchivoAprobacionPorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {
                this.Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    archivo = new Archivo();
                    archivo.Contenido = (byte[])sdr["Contenido"];
                    archivo.Nombre = sdr["NombreArchivo"].ToString();
                    if (sdr["fechahora"] != DBNull.Value)
                    {
                        archivo.Fecha = Convert.ToDateTime(sdr["fechahora"]);
                    }
                    if (sdr["contenttype"] != DBNull.Value)
                    {
                        archivo.ContentType = sdr["contenttype"].ToString();
                    }
                }
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public Archivo ObtenerAprobacion(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerArchivoAprobacion", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Archivo archivo = new Archivo();
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    archivo.Contenido = (byte[])sdr[0];
                    archivo.Nombre = sdr[1].ToString();
                    if (sdr["fechahora"] != DBNull.Value)
                    {
                        archivo.Fecha = Convert.ToDateTime(sdr["fechahora"]);
                    }
                    if (sdr["contenttype"] != DBNull.Value)
                    {
                        archivo.ContentType = sdr["contenttype"].ToString();
                    }
                }
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public Archivo ActualizarAprobacion(Archivo archivo, int solicitudId)
        {
            string comando = archivo.Id == 0 ? "dbo.usp_InsertarAprobacion" : "dbo.usp_ActualizarAprobacion";
            SqlCommand cmd = new SqlCommand(comando, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            if (archivo.Id > 0)
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = archivo.Id;
            else
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;

            cmd.Parameters.Add(new SqlParameter("@archivo", SqlDbType.VarBinary)).Value = archivo.Contenido;
            cmd.Parameters.Add(new SqlParameter("@nombrearchivo", SqlDbType.VarChar, 100)).Value = archivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@fechahora", SqlDbType.DateTime)).Value = archivo.Fecha;
            cmd.Parameters.Add(new SqlParameter("@contenttype", SqlDbType.VarChar)).Value = archivo.ContentType;
            
            try
            {
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                this.Conexion.Close();
                return archivo;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }
        }

        public void EliminarAprobacion(int aprobacionId)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_EliminarAprobacion", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@aprobacionId", SqlDbType.Int)).Value = aprobacionId;
            try
            {
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }

        }

        public void ActualizarComentario(int solicitudId, int numeroArchivo, string comentario, bool errores)
        {
            try
            {
                string comando = String.Format("dbo.usp_ActualizarSolicitudComentario{0}",numeroArchivo);
                SqlCommand cmd = new SqlCommand(comando, this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@comentario", SqlDbType.VarChar)).Value = comentario;
                cmd.Parameters.Add(new SqlParameter("@errores", SqlDbType.Bit)).Value = errores;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();               
                this.Conexion.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<ConflictoBD> ListarConflicto(int solicitudId, int numeroArchivo)
        {
            try
            {
                ProyectoRepository pr = new ProyectoRepository();
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository to = new TipoObjetoBDRepository();
                List<ConflictoBD> conflictos = new List<ConflictoBD>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarConflictoBD", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    ConflictoBD conflictoBD = new ConflictoBD();

                    conflictoBD.Proyecto = new Proyecto();
                    conflictoBD.Proyecto.Id = Convert.ToInt32(sdr["proyectoid"]);
                    conflictoBD.Proyecto.Codigo = sdr["codigoProyecto"].ToString();
                    conflictoBD.Proyecto.Nombre = sdr["nombreProyecto"].ToString();

                    conflictoBD.Instancia = new Instancia();
                    conflictoBD.Instancia.Id = Convert.ToInt32(sdr["instanciaid"]);
                    conflictoBD.Instancia.Nombre = sdr["nombreInstancia"].ToString();

                    conflictoBD.Esquema = new Esquema();
                    conflictoBD.Esquema.Id = Convert.ToInt32(sdr["esquemaid"]);
                    conflictoBD.Esquema.Nombre = sdr["nombreesquema"].ToString();

                    conflictoBD.TipoObjetoBD = new TipoObjetoBD();
                    conflictoBD.TipoObjetoBD.Id = Convert.ToInt32(sdr["tipoobjetobdid"]);
                    conflictoBD.TipoObjetoBD.Nombre = sdr["nombretipoobjetobd"].ToString();

                    conflictoBD.NombreObjeto = sdr["objetobd"].ToString();

                    conflictoBD.FechaHora = Convert.ToDateTime(sdr["fechahora"]);

                    conflictoBD.SolicitudId = int.Parse(sdr["solicitudid"].ToString());

                    conflictoBD.Estado = sdr["estado"].ToString();

                    conflictos.Add(conflictoBD);
                }
                sdr.Close();
                
                return conflictos;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<ConflictoCRMWPApp> ListarConflictoCRMWPApp(int solicitudId, int numeroArchivo)
        {
            try
            {
                ProyectoRepository pr = new ProyectoRepository();
                SolicitudRepository sr = new SolicitudRepository();
                List<ConflictoCRMWPApp> conflictos = new List<ConflictoCRMWPApp>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarConflictoCRMWPApp", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    ConflictoCRMWPApp conflicto = new ConflictoCRMWPApp();

                    conflicto.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoid"]) };
                    conflicto.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    conflicto.ServerCluster = sdr["servercluster"].ToString();
                    conflicto.Tipo = sdr["tipo"].ToString();
                    conflicto.Aplicacion = sdr["aplicacion"].ToString();

                    conflictos.Add(conflicto);
                }
                sdr.Close();
                conflictos.ForEach(p => {
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                    p.Proyecto = pr.Obtener(p.Proyecto.Id);
                });
                return conflictos;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public List<Log> ListarLog(int solicitudId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarLog", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                List<Log> logs = new List<Log>();
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Log log = new Log();
                    log.Id = Convert.ToInt32(sdr["id"]);
                    log.Accion = sdr["accion"].ToString();
                    log.Estado = sdr["estado"].ToString();
                    log.Usuario = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    log.FechaHora = Convert.ToDateTime(sdr["fechahora"]);
                    log.Comentario = sdr["comentario"].ToString();
                    log.Archivo = new Archivo { Nombre = sdr["nombrearchivo"].ToString() };
                    if (sdr["observacionid"] != DBNull.Value)
                    {
                        log.Observacion = new Observacion { Id = Convert.ToInt32(sdr["observacionid"]) };
                    }
                    logs.Add(log);
                }
                sdr.Close();
                return logs;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public Estado ObtenerEstado(int solicitudId)
        {
            try
            {
                Estado estado = null;
                var cmd = new SqlCommand("dbo.usp_ObtenerSolicitudEstado", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    estado = new Estado
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        Nombre = sdr["nombre"].ToString(),
                        Pendiente = Convert.ToBoolean(sdr["pendiente"]),
                        Satisfactorio = Convert.ToBoolean(sdr["satisfactorio"]),
                        EnviarCorreo = Convert.ToBoolean(sdr["enviarcorreo"])
                    };
                }
                sdr.Close();
                return estado;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public void Revertir(int solicitudId)
        {
            try
            {
                var cmd = new SqlCommand("dbo.usp_RevertirSolicitud", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public List<Rollback> ListarRollback(int ambienteId, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var rollbacks = new List<Rollback>();
                var cmd = new SqlCommand("dbo.usp_ListarRollback", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@desde", SqlDbType.Char, 8)).Value = fechaDesde.ToString("yyyyMMdd");
                cmd.Parameters.Add(new SqlParameter("@hasta", SqlDbType.Char, 8)).Value = fechaHasta.ToString("yyyyMMdd");
                cmd.Parameters.Add(new SqlParameter("@ambienteId", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var rollback = new Rollback
                    {
                        Codigo = sdr["Codigo"].ToString(),
                        Nombre = sdr["Nombre"].ToString(),
                        TipoProyecto = sdr["TipoProyecto"].ToString(),
                        Comentario = sdr["Comentario"].ToString(),
                        FechaHora = Convert.ToDateTime(sdr["FechaHora"]),
                        SolicitudId = Convert.ToInt32(sdr["Id"]),
                        Emergente = Convert.ToBoolean(sdr["Emergente"])
                    };
                    rollbacks.Add(rollback);
                }
                sdr.Close();
                return rollbacks;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public bool GrabarInfoFormulario(int solicitudId, int numeroArchivo, string codigo, string version)
        {
            var cmd = new SqlCommand("dbo.usp_ObtenerInfoFormulario", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@solicitudId", SqlDbType.Int).Value = solicitudId;
            cmd.Parameters.Add("@numeroArchivo", SqlDbType.Int).Value = numeroArchivo;

            try
            {
                Conexion.Open();
                var sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    cmd.CommandText = "dbo.usp_ActualizarInfoFormulario";
                }
                else
                {
                    cmd.CommandText = "dbo.usp_InsertarInfoFormulario";
                }
                sdr.Close();

                cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigo;
                cmd.Parameters.Add("@version", SqlDbType.VarChar, 50).Value = version;

                var resultados = cmd.ExecuteNonQuery();
                Conexion.Close();
                return resultados > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public bool EliminarInfoFormulario(int solicitudId, int numeroArchivo)
        {
            var cmd = new SqlCommand("dbo.usp_EliminarInfoFormulario", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@solicitudId", SqlDbType.Int).Value = solicitudId;
            cmd.Parameters.Add("@numeroArchivo", SqlDbType.Int).Value = numeroArchivo;

            try
            {
                Conexion.Open();
                var resultados = cmd.ExecuteNonQuery();
                Conexion.Close();
                return resultados>0;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }
    }
}
