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
    public class AmbienteRepository : Repository
    {
        public AmbienteRepository()
        {
        }

        public AmbienteRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Ambiente Obtener(int id)
        {
            Ambiente a = new Ambiente();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerAmbiente", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Ambiente();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                    a.Final = Convert.ToBoolean(sdr["final"]);
                    a.Orden = Convert.ToInt32(sdr["orden"]);
                    a.FechaObligatoria = Convert.ToBoolean(sdr["fechaobligatoria"]);
                    a.ApruebaCalidad = Convert.ToBoolean(sdr["apruebacalidad"]);
                    a.EnvioPrimeraSolicitud = Convert.ToBoolean(sdr["envioprimerasolicitud"]);
                    if (sdr["observacionid"] == DBNull.Value)
                    {
                        a.ObservaCalidad = new Observacion { Id = 0 };
                    }
                    else
                    {
                        a.ObservaCalidad = new Observacion { Id = Convert.ToInt32(sdr["observacionid"]) };
                    }
                }
                sdr.Close();
                if (a.Id != 0)
                {
                    a.Servidores = new List<Servidor>();
                    cmd.CommandText = "dbo.usp_ListarServidoresPorAmbiente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AmbienteId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Servidor app = new Servidor();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        app.Ip = sdr["Ip"].ToString();
                        a.Servidores.Add(app);
                    }
                    sdr.Close();
                }                
                if (a.Id != 0)
                {
                    a.Instancias = new List<Instancia>();
                    cmd.CommandText = "dbo.usp_ListarInstanciaPorAmbiente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AmbienteId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Instancia app = new Instancia();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        app.Servidor = new Servidor() { Id = Convert.ToInt32(sdr["servidorid"]), Ip = sdr["ipservidor"].ToString(), Nombre = sdr["nombreservidor"].ToString() };
                        a.Instancias.Add(app);
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

        public Ambiente Obtener(string nombre)
        {
            Ambiente a = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerAmbientePorNombre", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    a = new Ambiente();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                    a.Final = Convert.ToBoolean(sdr["final"]);
                    a.Orden = Convert.ToInt32(sdr["Orden"]);
                    a.FechaObligatoria = Convert.ToBoolean(sdr["fechaobligatoria"]);
                    a.ApruebaCalidad = Convert.ToBoolean(sdr["apruebacalidad"]);
                    a.EnvioPrimeraSolicitud = Convert.ToBoolean(sdr["envioprimerasolicitud"]);
                    if (sdr["observacionid"] == DBNull.Value)
                    {
                        a.ObservaCalidad = new Observacion { Id = 0 };
                    }
                    else
                    {
                        a.ObservaCalidad = new Observacion { Id = Convert.ToInt32(sdr["observacionid"]) };
                    }
                }
                sdr.Close();
                if (a != null)
                {
                    a.Servidores = new List<Servidor>();
                    cmd.CommandText = "dbo.usp_ListarServidoresPorAmbiente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AmbienteId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Servidor app = new Servidor();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        app.Ip = sdr["Ip"].ToString();
                        a.Servidores.Add(app);
                    }
                    sdr.Close();
                }
                if (a != null)
                {
                    a.Instancias = new List<Instancia>();
                    cmd.CommandText = "dbo.usp_ListarInstanciaPorAmbiente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AmbienteId", SqlDbType.Int)).Value = a.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Instancia app = new Instancia();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        a.Instancias.Add(app);
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

        public Ambiente Actualizar(Ambiente a)
        {
            string procedure = a.Id == 0 ? "dbo.usp_CrearAmbiente" : "dbo.usp_ActualizarAmbiente";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (a.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = a.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = a.Nombre;
            cmd.Parameters.Add(new SqlParameter("@abreviatura", SqlDbType.VarChar, 10)).Value = a.Abreviatura;
            cmd.Parameters.Add(new SqlParameter("@final", SqlDbType.Bit)).Value = a.Final;
            cmd.Parameters.Add(new SqlParameter("@orden", SqlDbType.Int)).Value = a.Orden;
            cmd.Parameters.Add(new SqlParameter("@fechaobligatoria", SqlDbType.Bit)).Value = a.FechaObligatoria;
            cmd.Parameters.Add(new SqlParameter("@apruebacalidad", SqlDbType.Bit)).Value = a.ApruebaCalidad;
            cmd.Parameters.Add(new SqlParameter("@envioprimerasolicitud", SqlDbType.Bit)).Value = a.EnvioPrimeraSolicitud;
            cmd.Parameters.Add(new SqlParameter("@observacionid", SqlDbType.Int)).Value = a.ObservaCalidad.Id;

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

        public List<Ambiente> Listar(string nombre,bool fechaObligatoria=false,bool apruebaCalidad=false,bool envioPrimeraSolicitud = false)
        {
            List<Ambiente> ambientes = new List<Ambiente>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarAmbiente", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            cmd.Parameters.Add(new SqlParameter("@fechaobligatoria", SqlDbType.Bit)).Value = fechaObligatoria;
            cmd.Parameters.Add(new SqlParameter("@apruebacalidad", SqlDbType.Bit)).Value = apruebaCalidad;
            cmd.Parameters.Add(new SqlParameter("@envioprimerasolicitud", SqlDbType.Bit)).Value = envioPrimeraSolicitud;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Ambiente a = new Ambiente();
                    a.Id = Convert.ToInt32(sdr["id"]);
                    a.Nombre = sdr["nombre"].ToString();
                    a.Abreviatura = sdr["abreviatura"].ToString();
                    a.Final = Convert.ToBoolean(sdr["final"]);
                    a.Orden = Convert.ToInt32(sdr["orden"]);
                    a.FechaObligatoria = Convert.ToBoolean(sdr["fechaobligatoria"]);
                    a.ApruebaCalidad = Convert.ToBoolean(sdr["apruebacalidad"]);
                    a.EnvioPrimeraSolicitud = Convert.ToBoolean(sdr["envioprimerasolicitud"]);
                    if (sdr["observacionid"] == DBNull.Value)
                    {
                        a.ObservaCalidad = new Observacion { Id = 0 };
                    }
                    else
                    {
                        a.ObservaCalidad = new Observacion { Id = Convert.ToInt32(sdr["observacionid"]) };
                    }
                    ambientes.Add(a);
                }
                sdr.Close();
                return ambientes;
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

        public List<Correo> ListarCorreos(int ambienteId)
        {
            try
            {
                List<Correo> correos = new List<Correo>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarAmbienteCorreo", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Correo correo = new Correo();
                    correo.Id = Convert.ToInt32(sdr["id"]);
                    correo.Direccion = sdr["correo"].ToString();
                    correos.Add(correo);
                }
                sdr.Close();
                return correos;
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

        public void EliminarCorreos(int ambienteId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarAmbienteCorreo", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
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

        public void ActualizarAmbienteCorreo(Correo correo, int ambienteId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarAmbienteCorreo", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = correo.Id;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
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

        public void InsertarAmbienteCorreo(Correo correo, int ambienteId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarAmbienteCorreo", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
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
