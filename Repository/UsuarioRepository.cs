using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CMDBApplication.Repository
{
    public class UsuarioRepository : Repository
    {
        public UsuarioRepository() { }
        public UsuarioRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Usuario Obtener(string nombre)
        {
            Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerUsuario", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 30)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(sdr["id"]);
                    usuario.Nombre = sdr["usuario"].ToString();
                    usuario.Clave = sdr["clave"].ToString();
                    usuario.Correo = sdr["correo"].ToString();
                    usuario.Administrador = Convert.ToBoolean(sdr["administrador"]);
                    usuario.Operador = Convert.ToBoolean(sdr["operador"]);
                    usuario.Lector = Convert.ToBoolean(sdr["lector"]);
                    usuario.CM = Convert.ToBoolean(sdr["CM"]);
                    usuario.RM = Convert.ToBoolean(sdr["RM"]);
                    usuario.Ejecutor = Convert.ToBoolean(sdr["Ejecutor"]);
                    usuario.Test = Convert.ToBoolean(sdr["Test"]);
                    usuario.Celular = sdr["Celular"].ToString();
                    usuario.Anexo = sdr["Anexo"].ToString();
                    usuario.Skype = sdr["Skype"].ToString();
                }
                sdr.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            return usuario;
        }

        public Usuario Obtener(int id)
        {
            Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerUsuarioPorId", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(sdr["id"]);
                    usuario.Nombre = sdr["usuario"].ToString();
                    usuario.Clave = sdr["clave"].ToString();
                    usuario.Correo = sdr["correo"].ToString();
                    usuario.Administrador = Convert.ToBoolean(sdr["administrador"]);
                    usuario.Operador = Convert.ToBoolean(sdr["operador"]);
                    usuario.Lector = Convert.ToBoolean(sdr["lector"]);
                    usuario.CM = Convert.ToBoolean(sdr["CM"]);
                    usuario.RM = Convert.ToBoolean(sdr["RM"]);
                    usuario.Ejecutor = Convert.ToBoolean(sdr["Ejecutor"]);
                    usuario.Test = Convert.ToBoolean(sdr["Test"]);
                    usuario.Celular = sdr["Celular"].ToString();
                    usuario.Anexo = sdr["Anexo"].ToString();
                    usuario.Skype = sdr["Skype"].ToString();
                }
                sdr.Close();
                return usuario;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }

        public Usuario Actualizar(Usuario p)
        {
            string procedure = p.Id == 0 ? "dbo.usp_CrearUsuario" : "dbo.usp_ActualizarUsuario";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (p.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = p.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 30)).Value = p.Nombre;

            if (procedure == "dbo.usp_CrearUsuario")
                cmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 50)).Value = p.Clave;

            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = p.Correo;
            cmd.Parameters.Add(new SqlParameter("@Administrador", SqlDbType.Bit)).Value = p.Administrador;
            cmd.Parameters.Add(new SqlParameter("@Operador", SqlDbType.Bit)).Value = p.Operador;
            cmd.Parameters.Add(new SqlParameter("@Lector", SqlDbType.Bit)).Value = p.Lector;
            cmd.Parameters.Add(new SqlParameter("@CM", SqlDbType.Bit)).Value = p.CM;
            cmd.Parameters.Add(new SqlParameter("@RM", SqlDbType.Bit)).Value = p.RM;
            cmd.Parameters.Add(new SqlParameter("@Ejecutor", SqlDbType.Bit)).Value = p.Ejecutor;
            cmd.Parameters.Add(new SqlParameter("@Test", SqlDbType.Bit)).Value = p.Test;
            
            cmd.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 20)).Value = p.Celular;
            cmd.Parameters.Add(new SqlParameter("@Anexo", SqlDbType.VarChar, 20)).Value = p.Anexo;
            cmd.Parameters.Add(new SqlParameter("@Skype", SqlDbType.VarChar, 50)).Value = p.Skype;
            
            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;

                Conexion.Close();

                return p;
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

        public Usuario ActualizarDatos(Usuario p)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarDatosUsuario", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = p.Id;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = p.Correo;
            cmd.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 20)).Value = p.Celular;
            cmd.Parameters.Add(new SqlParameter("@Anexo", SqlDbType.VarChar, 20)).Value = p.Anexo;
            cmd.Parameters.Add(new SqlParameter("@Skype", SqlDbType.VarChar, 50)).Value = p.Skype;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;

                Conexion.Close();

                return p;
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

        public List<Usuario> Listar(string usuario, string correo, bool administrador, bool operador, bool lector, bool cm, bool rm, bool ejecutor, bool test,string celular="",string anexo="",string skype="")
        {
            List<Usuario> Usuarios = new List<Usuario>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarUsuario", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 30)).Value = usuario;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo;
            cmd.Parameters.Add(new SqlParameter("@administrador", SqlDbType.Bit)).Value = administrador;
            cmd.Parameters.Add(new SqlParameter("@operador", SqlDbType.Bit)).Value = operador;
            cmd.Parameters.Add(new SqlParameter("@lector", SqlDbType.Bit)).Value = lector;
            cmd.Parameters.Add(new SqlParameter("@CM", SqlDbType.Bit)).Value = cm;
            cmd.Parameters.Add(new SqlParameter("@RM", SqlDbType.Bit)).Value = rm;
            cmd.Parameters.Add(new SqlParameter("@Ejecutor", SqlDbType.Bit)).Value = ejecutor;
            cmd.Parameters.Add(new SqlParameter("@Test", SqlDbType.Bit)).Value = test;
            cmd.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 20)).Value = celular;
            cmd.Parameters.Add(new SqlParameter("@Anexo", SqlDbType.VarChar, 20)).Value = anexo;
            cmd.Parameters.Add(new SqlParameter("@Skype", SqlDbType.VarChar, 50)).Value = skype;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Usuario p = new Usuario();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["usuario"].ToString();
                    p.Correo = sdr["correo"].ToString();
                    p.Clave = sdr["clave"].ToString();
                    p.Administrador = Convert.ToBoolean(sdr["administrador"]);
                    p.Operador = Convert.ToBoolean(sdr["operador"]);
                    p.Lector = Convert.ToBoolean(sdr["lector"]);
                    p.CM = Convert.ToBoolean(sdr["CM"]);
                    p.RM = Convert.ToBoolean(sdr["RM"]);
                    p.Ejecutor = Convert.ToBoolean(sdr["Ejecutor"]);
                    p.Test = Convert.ToBoolean(sdr["Test"]);
                    p.Celular = sdr["Celular"].ToString();
                    p.Anexo = sdr["Anexo"].ToString();
                    p.Skype = sdr["Skype"].ToString();
                    Usuarios.Add(p);
                }
                sdr.Close();
                return Usuarios;
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

        public bool CambiarClave(int id, string clave)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_CambiarClave", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuarioid", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 50)).Value = clave;
            int filas = 0;
            try
            {
                this.Conexion.Open();
                filas = cmd.ExecuteNonQuery();
                this.Conexion.Close();
                return filas == 1;
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

        public bool ActualizarToken(int id, string token)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarToken", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                cmd.Parameters.Add(new SqlParameter("@token", SqlDbType.VarChar, 50)).Value = token;
                this.Conexion.Open();
                int registros = cmd.ExecuteNonQuery();
                this.Conexion.Close();
                return registros == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }

        public int ObtenerIdPorToken(string token)
        {
            try
            {
                int id = 0;
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerIdPorToken", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@token", SqlDbType.VarChar, 50)).Value = token;
                this.Conexion.Open();
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    id = Convert.ToInt32(resultado);
                }
                this.Conexion.Close();
                return id;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.Conexion.State == ConnectionState.Open)
                {
                    this.Conexion.Close();
                }
            }
        }
    }
}
