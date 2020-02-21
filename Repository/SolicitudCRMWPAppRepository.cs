using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudCRMWPAppRepository:Repository
    {
        public SolicitudCRMWPAppRepository() { }
        public SolicitudCRMWPAppRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void InsertarCab(SolicitudCRMCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar)).Value = cab.Observacion;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 100)).Value = cab.ServidorDestino;

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
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
        }

        public void Insertar(SolicitudCRMWPApp objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMWPApp", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@NumeroArchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 50)).Value = objetoBD.Responsable;
                cmd.Parameters.Add(new SqlParameter("@AnalistaDesarrollo", SqlDbType.VarChar, 50)).Value = objetoBD.AnalistaDesarrollo;
                cmd.Parameters.Add(new SqlParameter("@RutaOrigen", SqlDbType.VarChar, 200)).Value = objetoBD.RutaOrigen;
                cmd.Parameters.Add(new SqlParameter("@ServerCluster", SqlDbType.VarChar, 50)).Value = objetoBD.ServerCluster;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 50)).Value = objetoBD.Tipo;
                cmd.Parameters.Add(new SqlParameter("@Aplicacion", SqlDbType.VarChar, 50)).Value = objetoBD.Aplicacion;
                cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = objetoBD.Accion;
                cmd.Parameters.Add(new SqlParameter("@Observacion", SqlDbType.VarChar)).Value = objetoBD.Observacion;
                cmd.Parameters.Add(new SqlParameter("@ParametroAmbiente", SqlDbType.VarChar, 50)).Value = objetoBD.ParametroAmbiente;

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
                    this.Conexion.Close();
            }
        }

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudCRMWPApp", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
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
                    this.Conexion.Close();
            }
        }

        public List<SolicitudCRMWPApp> Listar(string nombre) {
            try
            {
                var objetos = new List<SolicitudCRMWPApp>();
                var cmd = new SqlCommand("dbo.usp_ListarCRMApp", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var crmApp = new SolicitudCRMWPApp();
                    crmApp.Solicitud = new Solicitud
                    {
                        Id = Convert.ToInt32(sdr["solicitudId"]),
                        Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]), Nombre = sdr["ambientenombre"].ToString() },
                        Proyecto = new Proyecto { Codigo = sdr["proyectocodigo"].ToString(), Nombre = sdr["proyectonombre"].ToString() },
                        Estado = sdr["Estado"].ToString(),
                        FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"])
                    };
                    if (sdr["fechaejecucion"] == DBNull.Value)
                    {
                        crmApp.Solicitud.FechaEjecucion = null;
                    }
                    else
                    {
                        crmApp.Solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    crmApp.Aplicacion = sdr["Aplicacion"].ToString();
                    objetos.Add(crmApp);
                }
                sdr.Close();
                return objetos;
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