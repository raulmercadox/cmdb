using CMDBApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMDBApplication.Repository
{
    public class FormatoRepository:Repository
    {
        public FormatoRepository() { }
        public FormatoRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Formato Obtener(int id)
        {
            Formato a = new Formato();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerFormato", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Formato();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Archivo.Nombre = sdr["nombre"].ToString();                    
                    a.Descripcion = sdr["descripcion"].ToString();
                    a.Codigo = sdr["codigo"].ToString();
                    a.Version = sdr["version"].ToString();
                    a.CarpetaBase = sdr["carpetabase"].ToString();
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

        public Formato Obtener(string nombre)
        {
            Formato a = new Formato();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerFormatoPorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Formato();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Archivo.Nombre = sdr["nombre"].ToString();
                    a.Descripcion = sdr["descripcion"].ToString();
                    a.Codigo = sdr["codigo"].ToString();
                    a.Version = sdr["version"].ToString();
                    a.CarpetaBase = sdr["carpetabase"].ToString();
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

        public Formato Actualizar(Formato a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_CrearFormato" : "dbo.usp_ActualizarFormato";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;
            }

            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = a.Archivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 100)).Value = a.Descripcion;
            cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 20)).Value = a.Codigo;
            cmd.Parameters.Add(new SqlParameter("@Version", SqlDbType.VarChar, 30)).Value = a.Version;
            cmd.Parameters.Add(new SqlParameter("@CarpetaBase", SqlDbType.VarChar, 50)).Value = a.CarpetaBase;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                a.Id = id;
                Conexion.Close();
                if (a.Archivo.Contenido!=null && a.Archivo.Contenido.Count() > 0)
                {
                    ActualizarArchivo(id, a);
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

        public List<Formato> Listar(string nombre)
        {
            List<Formato> formatos = new List<Formato>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarFormato", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Formato a = new Formato();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Archivo.Nombre = sdr["nombre"].ToString();
                    a.Descripcion = sdr["descripcion"].ToString();
                    a.Codigo = sdr["codigo"].ToString();
                    a.Version = sdr["version"].ToString();
                    a.CarpetaBase = sdr["CarpetaBase"].ToString();
                    formatos.Add(a);
                }
                sdr.Close();
                return formatos;
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

        public Formato ActualizarArchivo(int id, Formato formato)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarArchivoFormato", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("@contenido", SqlDbType.VarBinary)).Value = formato.Archivo.Contenido;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = formato.Archivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 20)).Value = formato.Codigo;
            cmd.Parameters.Add(new SqlParameter("@version", SqlDbType.VarChar, 30)).Value = formato.Version;
            cmd.Parameters.Add(new SqlParameter("@carpetabase", SqlDbType.VarChar, 50)).Value = formato.CarpetaBase;
            try
            {
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                this.Conexion.Close();
                return formato;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                    this.Conexion.Close();
            }
        }

        public Formato ObtenerArchivo(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerArchivoFormato", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Formato formato = new Formato();
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    formato.Archivo.Contenido = (byte[])sdr[0];
                    formato.Archivo.Nombre = sdr[1].ToString();
                    formato.Codigo = sdr["codigo"].ToString();
                    formato.Version = sdr["version"].ToString();
                    formato.CarpetaBase = sdr["carpetabase"].ToString();
                }
                return formato;
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

        public bool Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_EliminarFormato", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;        

            try
            {
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

        public Formato ObtenerPropiedades(string propiedadNombre)
        {
            Formato formato = null;
            var cmd = new SqlCommand("dbo.usp_ObtenerFormatoPorPropiedadNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@propiedadNombre", SqlDbType.VarChar, 20)).Value = propiedadNombre;
            try
            {
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    formato = new Formato
                    {
                        Codigo = sdr["Codigo"].ToString(),
                        Version = sdr["Version"].ToString(),
                        CarpetaBase = sdr["CarpetaBase"].ToString()
                    };
                }
                sdr.Close();
                return formato;
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