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
    public class ServidorRepository : Repository
    {
        public ServidorRepository() { }
        public ServidorRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Servidor Obtener(int id)
        {
            Servidor p = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerServidorPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Servidor();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Ip = sdr["ip"].ToString();
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    p.Descripcion = sdr["descripcion"].ToString();
                    //p.Ambiente.Nombre = sdr["ambientenombre"].ToString();
                }
                sdr.Close();
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

        public Servidor Obtener(string ip)
        {
            Servidor p = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerServidor", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar, 15)).Value = ip;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Servidor();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Ip = sdr["ip"].ToString();
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    p.Descripcion = sdr["descripcion"].ToString();
                    //p.Ambiente.Nombre = sdr["ambientenombre"].ToString();
                }
                sdr.Close();
                if (p != null)
                {
                    cmd.CommandText = "dbo.usp_ListarInstanciaPorServidor";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ServidorId", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    p.Instancias = new List<Instancia>();
                    while (sdr.Read())
                    {
                        Instancia app = new Instancia();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        p.Instancias.Add(app);
                    }
                    sdr.Close();
                }
                
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

        public Servidor Actualizar(Servidor p)
        {
            string procedure = p.Id == 0 ? "dbo.usp_CrearServidor" : "dbo.usp_ActualizarServidor";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (p.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = p.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@ipservidor", SqlDbType.VarChar, 30)).Value = p.Ip;
            cmd.Parameters.Add(new SqlParameter("@nombreservidor", SqlDbType.VarChar, 70)).Value = p.Nombre;
            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.VarChar, 50)).Value = p.Ambiente.Id;
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = p.Descripcion;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;

                foreach (var usuario in p.Usuarios)
                {
                    cmd.Parameters.Clear();
                    if (usuario.Id == 0 && !usuario.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_InsertarServidorUsuario";
                        cmd.Parameters.Add(new SqlParameter("@ServidorId", SqlDbType.Int)).Value = p.Id;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100)).Value = usuario.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@Clave", SqlDbType.VarChar, 100)).Value = usuario.Clave;
                        int idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                        usuario.Id = idUsuario;
                    }
                    else if (usuario.Id != 0 && usuario.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_EliminarServidorUsuario";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = usuario.Id;
                        cmd.ExecuteNonQuery();
                    }
                    else if (usuario.Id != 0 && !usuario.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_ActualizarServidorUsuario";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = usuario.Id;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100)).Value = usuario.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@Clave", SqlDbType.VarChar, 100)).Value = usuario.Clave;
                        cmd.ExecuteNonQuery();
                    }
                }
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

        public List<Servidor> Listar(string ipServidor, string nombreServidor, int ambienteId, string descripcion="")
        {
            List<Servidor> Servidors = new List<Servidor>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarServidor", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ipservidor", SqlDbType.VarChar, 15)).Value = ipServidor;
            cmd.Parameters.Add(new SqlParameter("@nombreservidor", SqlDbType.VarChar, 50)).Value = nombreServidor;
            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = descripcion;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Servidor p = new Servidor();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Ip = sdr["ip"].ToString();
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    p.Ambiente.Nombre = sdr["ambientenombre"].ToString();
                    p.Descripcion = sdr["descripcion"].ToString();
                    Servidors.Add(p);
                }
                sdr.Close();
                return Servidors;
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

        public List<Usuario> ListarUsuario(Servidor servidor)
        {
            try
            {
                var usuarios = new List<Usuario>();
                var cmd = new SqlCommand("dbo.usp_ListarServidorUsuario", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@servidorId", SqlDbType.Int)).Value = servidor.Id ;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(sdr["Id"]);
                    usuario.Nombre = sdr["Nombre"].ToString();
                    usuario.Clave = sdr["Clave"].ToString();
                    usuarios.Add(usuario);
                }
                sdr.Close();
                return usuarios;
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
    }
}
