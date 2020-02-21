using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class ObservacionRepository:Repository
    {
        public ObservacionRepository()
            : base()
        {

        }

        public ObservacionRepository(string cadcon)
            : base(cadcon)
        {
        }

        public List<Observacion> Listar(string nombre)
        {
            List<Observacion> Observacions = new List<Observacion>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarObservacion", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Observacion a = new Observacion();
                    a.Id = Convert.ToInt32(sdr["Id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    Observacions.Add(a);
                }
                sdr.Close();                
                return Observacions;
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

        public Observacion Obtener(int id)
        {
            Observacion a = new Observacion();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerObservacion", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Observacion();
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

        public Observacion Obtener(string nombre)
        {
            Observacion a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerObservacionPorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Observacion();
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

        public Observacion Actualizar(Observacion a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_CrearObservacion" : "dbo.usp_ActualizarObservacion";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = a.Nombre;

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