using CMDBApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CMDBApplication.Repository
{
    public class SistemaRepository:Repository
    {
        public SistemaRepository() { }
        public SistemaRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Sistema Obtener()
        {
            try
            {
                Sistema sistema = new Sistema();
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerSistema", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    sistema.Id = Convert.ToInt32(sdr["id"]);
                    sistema.PrimeraSolicitud = sdr["primerasolicitud"].ToString();
                    sistema.OracleDBUExtractConexion = sdr["OracleDBUExtractConexion"].ToString();
                    sistema.CarpetaTrabajo = sdr["carpetatrabajo"].ToString();
                    if (sdr["estadoid"] == DBNull.Value)
                    {
                        sistema.Estado = new Estado { Id = 0 };
                    }
                    else
                    {
                        sistema.Estado = new Estado { Id = Convert.ToInt32(sdr["estadoid"]) };
                    }
                    sistema.CorreoCMS = sdr["correoCMS"].ToString();
                    sistema.ResponderA = sdr["ResponderA"].ToString();
                    sistema.CopiarExcelA = sdr["CopiarExcelA"].ToString();
                    sistema.FolderPre = sdr["FolderPre"].ToString();
                    sistema.FolderDML = sdr["FolderDML"].ToString();
                    sistema.MensajeCrearSolicitud = sdr["MensajeCrearSolicitud"].ToString();
                }
                sdr.Close();
                EstadoRepository er = new EstadoRepository();
                sistema.Estado = er.Obtener(sistema.Estado.Id);
                return sistema;
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

        public void Actualizar(Sistema sistema)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarSistema", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@primerasolicitud", SqlDbType.VarChar)).Value = sistema.PrimeraSolicitud;
                cmd.Parameters.Add(new SqlParameter("@OracleDBUExtractConexion", SqlDbType.VarChar)).Value = sistema.OracleDBUExtractConexion;
                cmd.Parameters.Add(new SqlParameter("@estadoid", SqlDbType.Int)).Value = sistema.Estado.Id;
                cmd.Parameters.Add(new SqlParameter("@carpetatrabajo", SqlDbType.VarChar)).Value = sistema.CarpetaTrabajo;
                cmd.Parameters.Add(new SqlParameter("@correoCMS", SqlDbType.VarChar, 100)).Value = sistema.CorreoCMS;
                cmd.Parameters.Add(new SqlParameter("@ResponderA", SqlDbType.VarChar, 100)).Value = sistema.ResponderA;
                cmd.Parameters.Add(new SqlParameter("@CopiarExcelA", SqlDbType.VarChar, 100)).Value = sistema.CopiarExcelA;
                cmd.Parameters.Add(new SqlParameter("@FolderPre", SqlDbType.VarChar, 100)).Value = sistema.FolderPre;
                cmd.Parameters.Add(new SqlParameter("@FolderDML", SqlDbType.VarChar, 100)).Value = sistema.FolderDML;
                cmd.Parameters.Add(new SqlParameter("@MensajeCrearSolicitud", SqlDbType.VarChar)).Value = sistema.MensajeCrearSolicitud;
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
    }
}