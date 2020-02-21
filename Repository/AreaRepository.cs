using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMDBApplication.Repository
{
    public class AreaRepository : Repository
    {
        public AreaRepository()
        {
        }

        public AreaRepository(string cadcon)
            : base(cadcon)
        {
        }

        public List<Area> Listar(string nombre)
        {
            List<Area> areas = new List<Area>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarArea", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Area a = new Area();
                    a.Id = Convert.ToInt32(sdr["Id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Color = sdr["color"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                    areas.Add(a);
                }
                sdr.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@AreaId", SqlDbType.Int));
                cmd.CommandText = "dbo.usp_ListarCorreo";
                foreach(Area a in areas)
                {
                    cmd.Parameters["@AreaId"].Value = a.Id;
                    this.Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        a.Correos.Add(new Correo { Id = Convert.ToInt32(sdr["id"]), Direccion = sdr["Correo"].ToString() });
                    }
                    sdr.Close();
                }
                return areas;
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

        public Area Obtener(int id)
        {
            Area a = new Area();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerArea", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Area();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Color = sdr["color"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                }
                sdr.Close();
                if (a != null)
                {
                    cmd.CommandText = "dbo.usp_ListarCorreo";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AreaId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Correo correo = new Correo();
                        correo.Id = Convert.ToInt32(sdr["Id"]);
                        correo.Direccion = sdr["Correo"].ToString();
                        a.Correos.Add(correo);
                    }
                    sdr.Close();
                }                
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

        public Area Obtener(string nombre)
        {
            Area a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerAreaPorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Area();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Color = sdr["color"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                }
                sdr.Close();
                if (a != null)
                {
                    cmd.CommandText = "dbo.usp_ListarCorreo";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AreaId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Correo correo = new Correo();
                        correo.Id = Convert.ToInt32(sdr["Id"]);
                        correo.Direccion = sdr["Correo"].ToString();
                        a.Correos.Add(correo);
                    }
                    sdr.Close();
                }                
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

        public Area Actualizar(Area a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_CrearArea" : "dbo.usp_ActualizarArea";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;                
            }

            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = a.Nombre;
            cmd.Parameters.Add(new SqlParameter("@color", SqlDbType.VarChar, 50)).Value = a.Color;
            cmd.Parameters.Add(new SqlParameter("@abreviatura", SqlDbType.VarChar, 10)).Value = a.Abreviatura;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                a.Id = id;

                // Actualizar correos
                foreach (Correo correo in a.Correos)
                {
                    cmd.Parameters.Clear();
                    if (correo.Id == 0 && !correo.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_InsertarCorreo";
                        cmd.Parameters.Add(new SqlParameter("@AreaId", SqlDbType.Int)).Value = a.Id;
                        cmd.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                        int idCorreo = Convert.ToInt32(cmd.ExecuteScalar());
                        correo.Id = idCorreo;
                    }
                    else if (correo.Id != 0 && correo.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_EliminarCorreo";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = correo.Id;
                        cmd.ExecuteNonQuery();
                    }
                    else if (correo.Id != 0 && !correo.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_ActualizarCorreo";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = correo.Id;
                        cmd.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                        cmd.ExecuteNonQuery();
                    }
                }
                Conexion.Close();
                a.Correos.RemoveAll(x => x.Eliminar);
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
