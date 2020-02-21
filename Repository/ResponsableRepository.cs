using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class ResponsableRepository:Repository
    {
        public ResponsableRepository() { }
        public ResponsableRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Responsable Obtener(int id)
        {
            Responsable a = new Responsable();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerResponsable", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Responsable();
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

        public Responsable Obtener(string nombre)
        {
            Responsable r = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerResponsablePorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    r = new Responsable();
                    r.Id = Convert.ToInt32(sdr["id"]);
                    r.Nombre = sdr["nombre"].ToString();
                }
                sdr.Close();
                return r;
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

        public Responsable Actualizar(Responsable a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_CrearResponsable" : "dbo.usp_ActualizarResponsable";

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
                Conexion.Close();
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

        public List<Responsable> Listar(string nombre)
        {
            List<Responsable> responsables = new List<Responsable>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarResponsable", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Responsable a = new Responsable();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();                    
                    responsables.Add(a);
                }
                sdr.Close();
                return responsables;
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