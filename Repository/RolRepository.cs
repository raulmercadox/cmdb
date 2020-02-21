using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMDBApplication.Repository
{
    public class RolRepository : Repository
    {
        public RolRepository() { }
        public RolRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Rol Obtener(string id)
        {
            Rol d = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerRol", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = int.Parse(id);
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    d = new Rol();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Nombre = sdr["nombre"].ToString();
                }
                sdr.Close();
                if (d != null)
                {
                    cmd.CommandText = "dbo.usp_ListarUsuarioPorRol";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@RolId", SqlDbType.Int)).Value = d.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Usuario obj = new Usuario();
                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.Nombre = sdr["Usuario"].ToString();
                        obj.Clave = sdr["Clave"].ToString();
                        obj.Administrador = Convert.ToBoolean(sdr["Administrador"]);
                        obj.Operador = Convert.ToBoolean(sdr["Operador"]);
                        obj.Lector = Convert.ToBoolean(sdr["Lector"]);
                        obj.Correo = sdr["Correo"].ToString();
                        d.Usuarios.Add(obj);
                    }
                }
                return d;
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

        public Rol ObtenerPorNombre(string id)
        {
            Rol d = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerRolPorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = id;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    d = new Rol();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Nombre = sdr["nombre"].ToString();
                }
                sdr.Close();
                if (d != null)
                {
                    cmd.CommandText = "dbo.usp_ListarUsuarioPorRol";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@RolId", SqlDbType.Int)).Value = d.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Usuario obj = new Usuario();
                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.Nombre = sdr["Usuario"].ToString();
                        obj.Clave = sdr["Clave"].ToString();
                        obj.Administrador = Convert.ToBoolean(sdr["Administrador"]);
                        obj.Correo = sdr["Correo"].ToString();
                        d.Usuarios.Add(obj);
                    }
                }
                return d;
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

        public Rol Actualizar(Rol d)
        {
            string procedure = d.Id == 0 ? "dbo.usp_CrearRol" : "dbo.usp_ActualizarRol";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (d.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = d.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = d.Nombre;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                d.Id = id;
                Conexion.Close();
                return d;
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

        public List<Rol> Listar(string nombre)
        {
            List<Rol> Roles = new List<Rol>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarRol", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Rol d = new Rol();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Nombre = sdr["nombre"].ToString();
                    Roles.Add(d);
                }
                sdr.Close();
                return Roles;
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

        public List<Rol> ListarPorNombreUsuario(string usuario)
        {
            List<Rol> Roles = new List<Rol>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarRolPorNombreUsuario", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 30)).Value = usuario;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Rol d = new Rol();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Nombre = sdr["nombre"].ToString();
                    Roles.Add(d);
                }
                sdr.Close();
                return Roles;
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
