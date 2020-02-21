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
    public class InstanciaRepository : Repository
    {
        public InstanciaRepository() { }
        public InstanciaRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Instancia Obtener(string nombre)
        {
            Instancia p = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerInstancia", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Instancia();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Servidor = new Servidor();
                    p.Servidor.Id = Convert.ToInt32(sdr["servidorid"]);
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    if (sdr["instanciaanteriorid"] == DBNull.Value)
                    {
                        p.InstanciaAnterior = null;
                    }
                    else
                    {
                        p.InstanciaAnterior = new Instancia();
                        p.InstanciaAnterior.Id = Convert.ToInt32(sdr["instanciaanteriorid"]);
                    }                    
                    p.RepositorioSubversion = sdr["repositoriosubversion"].ToString();
                }
                sdr.Close();
                if (p != null)
                {
                    cmd.CommandText = "dbo.usp_ListarEsquemasPorInstancia";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@InstanciaId", SqlDbType.Int)).Value = p.Id;
                    p.Esquemas = new List<Esquema>();
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Esquema app = new Esquema();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        p.Esquemas.Add(app);
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

        public Instancia Obtener(int id)
        {
            Instancia p = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerInstanciaPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Instancia();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Servidor = new Servidor();
                    p.Servidor.Id = Convert.ToInt32(sdr["servidorid"]);
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    if (sdr["instanciaanteriorid"] == DBNull.Value)
                    {
                        p.InstanciaAnterior = null;
                    }
                    else
                    {
                        p.InstanciaAnterior = new Instancia();
                        p.InstanciaAnterior.Id = Convert.ToInt32(sdr["instanciaanteriorid"]);
                    }
                    p.RepositorioSubversion = sdr["repositoriosubversion"].ToString();
                }
                sdr.Close();
                if (p != null)
                {
                    cmd.CommandText = "dbo.usp_ListarEsquemasPorInstancia";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@InstanciaId", SqlDbType.Int)).Value = p.Id;
                    p.Esquemas = new List<Esquema>();
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Esquema app = new Esquema();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        p.Esquemas.Add(app);
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

        public Instancia Actualizar(Instancia p)
        {
            string procedure = p.Id == 0 ? "dbo.usp_CrearInstancia" : "dbo.usp_ActualizarInstancia";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (p.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = p.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 70)).Value = p.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servidorid", SqlDbType.VarChar, 50)).Value = p.Servidor.Id;
            cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.VarChar, 50)).Value = p.Ambiente.Id;

            if (p.InstanciaAnterior == null)
            {
                cmd.Parameters.Add(new SqlParameter("@instanciaanteriorid", SqlDbType.Int)).Value = null;
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@instanciaanteriorid", SqlDbType.Int)).Value = p.InstanciaAnterior.Id;
            }

            cmd.Parameters.Add(new SqlParameter("@repositoriosubversion", SqlDbType.VarChar, 50)).Value = p.RepositorioSubversion;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;

                // Actualizar esquemas
                if (p.Esquemas != null)
                {
                    foreach (Esquema app in p.Esquemas)
                    {
                        cmd.Parameters.Clear();
                        if (app.Id == 0 && !app.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_InsertarEsquema";
                            cmd.Parameters.Add(new SqlParameter("@InstanciaId", SqlDbType.Int)).Value = p.Id;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = app.Nombre;
                            int idAplicacion = Convert.ToInt32(cmd.ExecuteScalar());
                            app.Id = idAplicacion;
                        }
                        else if (app.Id != 0 && app.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_EliminarEsquema";
                            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = app.Id;
                            cmd.ExecuteNonQuery();
                        }
                        else if (app.Id != 0 && !app.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_ActualizarEsquema";
                            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = app.Id;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = app.Nombre;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                Conexion.Close();
                if (p.Esquemas != null)
                {
                    p.Esquemas.RemoveAll(x => x.Eliminar);
                    p.Esquemas = p.Esquemas.GroupBy(x => x.Nombre).Select(y => y.First()).ToList();
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

        public List<Instancia> Listar(string nombre, int servidorId, int ambienteId)
        {
            List<Instancia> Instancias = new List<Instancia>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarInstancia", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            cmd.Parameters.Add(new SqlParameter("@servidorId", SqlDbType.Int)).Value = servidorId;
            cmd.Parameters.Add(new SqlParameter("@ambienteId", SqlDbType.Int)).Value = ambienteId;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Instancia p = new Instancia();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Nombre = sdr["nombre"].ToString();
                    p.Servidor = new Servidor();
                    p.Servidor.Id = Convert.ToInt32(sdr["servidorid"]);
                    p.Servidor.Nombre = sdr["servidornombre"].ToString();
                    p.Servidor.Ip = sdr["servidorip"].ToString();
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = Convert.ToInt32(sdr["ambienteid"]);
                    p.Ambiente.Nombre = sdr["ambientenombre"].ToString();
                    if (sdr["instanciaanteriorid"] == DBNull.Value)
                    {
                        p.InstanciaAnterior = null;
                    }
                    else
                    {
                        p.InstanciaAnterior = new Instancia();
                        p.InstanciaAnterior.Id = Convert.ToInt32(sdr["instanciaanteriorid"]);
                    }                    
                    p.RepositorioSubversion = sdr["repositoriosubversion"].ToString();
                    Instancias.Add(p);
                }
                sdr.Close();
                return Instancias;
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
            string procedure = "dbo.usp_EliminarInstancia";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
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
    }
}
