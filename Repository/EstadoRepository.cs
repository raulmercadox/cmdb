using CMDBApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMDBApplication.Repository
{
    public class EstadoRepository:Repository
    {
        public EstadoRepository() { }
        public EstadoRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Estado Obtener(int id)
        {
            try
            {
                Estado estado = null;
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerEstadoPorId", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    estado = new Estado();
                    estado.Id = id;
                    estado.Nombre = sdr["nombre"].ToString();
                    estado.EnviarCorreo = Convert.ToBoolean(sdr["enviarcorreo"]);
                    estado.Pendiente = Convert.ToBoolean(sdr["pendiente"]);
                    estado.Satisfactorio = Convert.ToBoolean(sdr["satisfactorio"]);
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
                    Conexion.Close();
            }
        }
        public List<Estado> Listar()
        {
            List<Estado> estados = new List<Estado>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarEstado", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;            
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Estado a = new Estado();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.EnviarCorreo = Convert.ToBoolean(sdr["enviarcorreo"]);
                    a.Satisfactorio = Convert.ToBoolean(sdr["satisfactorio"]);
                    a.Pendiente = Convert.ToBoolean(sdr["pendiente"]);
                    estados.Add(a);
                }
                sdr.Close();
                return estados;
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

        public bool Actualizar(Estado e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                if (e.Id > 0)
                {
                    cmd.CommandText = "dbo.usp_ActualizarEstado";
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = e.Id;
                }
                else
                {
                    cmd.CommandText = "dbo.usp_InsertarEstado";
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = e.Nombre;
                }                
                cmd.Parameters.Add(new SqlParameter("@enviarcorreo", SqlDbType.Bit)).Value = e.EnviarCorreo;
                cmd.Parameters.Add(new SqlParameter("@satisfactorio", SqlDbType.Bit)).Value = e.Satisfactorio;
                cmd.Parameters.Add(new SqlParameter("@pendiente", SqlDbType.Bit)).Value = e.Pendiente;
                Conexion.Open();
                int registros = cmd.ExecuteNonQuery();
                Conexion.Close();
                return registros == 1;
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