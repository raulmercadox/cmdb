using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMDBApplication.Repository
{
    public class DesarrolladorRepository : Repository
    {
        public DesarrolladorRepository() { }

        public DesarrolladorRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Desarrollador Obtener(string usuario)
        {
            Desarrollador d = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerDesarrollador", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = usuario;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    d = new Desarrollador();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Usuario = sdr["usuario"].ToString();
                    d.Nombre = sdr["nombre"].ToString();
                    d.Correo = sdr["correo"].ToString();
                    d.Clave = sdr["clave"].ToString();
                }
                sdr.Close();
                if (d != null)
                {
                    cmd.CommandText = "dbo.usp_ListarProyectosPorDesarrollador";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@DesarrolladorId", SqlDbType.Int)).Value = d.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Proyecto proyecto = new Proyecto();
                        proyecto.Id = Convert.ToInt32(sdr["Id"]);
                        proyecto.Nombre = sdr["Nombre"].ToString();
                        proyecto.Codigo = sdr["Codigo"].ToString();
                        proyecto.Pm = sdr["Pm"].ToString();
                        proyecto.Ptl = sdr["Ptl"].ToString();
                        proyecto.Estado = Convert.ToChar(sdr["Estado"]);
                        d.Proyectos.Add(proyecto);
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

        public Desarrollador Actualizar(Desarrollador d)
        {
            string procedure = d.Id == 0 ? "dbo.usp_CrearDesarrollador" : "dbo.usp_ActualizarDesarrollador";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (d.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = d.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = d.Usuario;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = d.Nombre;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = d.Correo;
            cmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 50)).Value = d.Clave;

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

        public List<Desarrollador> Listar(string usuario, string nombre, string correo, string clave)
        {
            List<Desarrollador> desarrolladores = new List<Desarrollador>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarDesarrollador", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = usuario;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 70)).Value = nombre;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 50)).Value = correo;
            cmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 50)).Value = clave;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Desarrollador d = new Desarrollador();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Usuario = sdr["usuario"].ToString();
                    d.Nombre = sdr["nombre"].ToString();
                    d.Correo = sdr["correo"].ToString();
                    d.Clave = sdr["clave"].ToString();
                    desarrolladores.Add(d);
                }
                sdr.Close();
                return desarrolladores;
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

        public List<Desarrollador> Listar(string usuario)
        {
            List<Desarrollador> desarrolladores = new List<Desarrollador>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarDesarrolladorPorUsuario", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = usuario;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Desarrollador d = new Desarrollador();
                    d.Id = Convert.ToInt32(sdr["id"]);
                    d.Usuario = sdr["usuario"].ToString();
                    d.Nombre = sdr["nombre"].ToString();
                    d.Correo = sdr["correo"].ToString();
                    d.Clave = sdr["clave"].ToString();
                    desarrolladores.Add(d);
                }
                sdr.Close();
                return desarrolladores;
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
