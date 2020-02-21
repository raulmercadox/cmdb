using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class TipoProyectoRepository:Repository
    {
        public TipoProyectoRepository() { }
        public TipoProyectoRepository(string cadcon)
            : base(cadcon)
        {
        }

        public List<TipoProyecto> Listar(string nombre)
        {
            List<TipoProyecto> tipoProyectos = new List<TipoProyecto>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarTipoProyecto", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    TipoProyecto a = new TipoProyecto();
                    a.Id = Convert.ToInt32(sdr["Id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    tipoProyectos.Add(a);
                }
                sdr.Close();
                return tipoProyectos;
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

        public TipoProyecto Obtener(int id)
        {
            TipoProyecto a = new TipoProyecto();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoProyectoPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoProyecto();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                }
                sdr.Close();
                return a;
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

        public TipoProyecto Obtener(string nombre)
        {
            TipoProyecto a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoProyecto", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoProyecto();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                }
                sdr.Close();
                return a;
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

        public TipoProyecto Actualizar(TipoProyecto a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_InsertarTipoProyecto" : "dbo.usp_ActualizarTipoProyecto";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = a.Nombre;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                a.Id = id;
                return a;
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