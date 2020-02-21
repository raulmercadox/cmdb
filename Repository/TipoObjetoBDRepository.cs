using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class TipoObjetoBDRepository:Repository
    {
        public TipoObjetoBDRepository()
            : base()
        {

        }


        public TipoObjetoBDRepository(string cadcon)
            : base(cadcon)
        {
        }


        public List<TipoObjetoBD> Listar(string nombre)
        {
            List<TipoObjetoBD> TipoObjetoBDs = new List<TipoObjetoBD>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarTipoObjetoBD", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    TipoObjetoBD a = new TipoObjetoBD();
                    a.Id = Convert.ToInt32(sdr["Id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Extension = sdr["extension"].ToString();
                    TipoObjetoBDs.Add(a);
                }
                sdr.Close();                
                return TipoObjetoBDs;
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

        public TipoObjetoBD Obtener(int id)
        {
            TipoObjetoBD a = new TipoObjetoBD();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoObjetoBDPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoObjetoBD();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Extension = sdr["extension"].ToString();
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

        public TipoObjetoBD Obtener(string nombre)
        {
            TipoObjetoBD a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerTipoObjetoBD", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new TipoObjetoBD();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Extension = sdr["extension"].ToString();
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

        public TipoObjetoBD Actualizar(TipoObjetoBD a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_InsertarTipoObjetoBD" : "dbo.usp_ActualizarTipoObjetoBD";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = a.Nombre;
            cmd.Parameters.Add(new SqlParameter("@extension", SqlDbType.VarChar, 20)).Value = a.Extension;

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