using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class TipoAccionBDRepository:Repository
    {
        public TipoAccionBDRepository()
            : base()
        {

        }

        public TipoAccionBDRepository(string cadcon)
            : base(cadcon)
        {
        }


        public List<TipoAccionBD> Listar(string nombre)
        {
            List<TipoAccionBD> TipoAccionBDs = new List<TipoAccionBD>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarTipoAccionBD", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    TipoAccionBD a = new TipoAccionBD();
                    a.Id = Convert.ToInt32(sdr["Id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    TipoAccionBDs.Add(a);
                }
                sdr.Close();                
                return TipoAccionBDs;
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

        public TipoAccionBD Obtener(int id)
        {
            TipoAccionBD a = new TipoAccionBD();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoAccionBDPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoAccionBD();
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

        public TipoAccionBD Obtener(string nombre)
        {
            TipoAccionBD a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoAccionBD", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoAccionBD();
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

        public TipoAccionBD Actualizar(TipoAccionBD a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_InsertarTipoAccionBD" : "dbo.usp_ActualizarTipoAccionBD";

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