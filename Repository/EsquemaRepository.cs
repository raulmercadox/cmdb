using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class EsquemaRepository:Repository
    {
        public EsquemaRepository()
            : base()
        {

        }

        public EsquemaRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Esquema Obtener(int id)
        {
            try
            {
                Esquema esquema = null;
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerEsquemaPorId", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    esquema = new Esquema();
                    esquema.Id = int.Parse(sdr["id"].ToString());
                    esquema.Nombre = sdr["nombre"].ToString();
                    esquema.Instancia = new Instancia() { Id = int.Parse(sdr["instanciaid"].ToString()) };
                }
                sdr.Close();
                return esquema;
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

        public Esquema Obtener(string nombre, int instanciaId)
        {
            try
            {
                Esquema esquema = null;
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerEsquema", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = instanciaId;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    esquema = new Esquema();
                    esquema.Id = int.Parse(sdr["id"].ToString());
                    esquema.Nombre = sdr["nombre"].ToString();
                    esquema.Instancia = new Instancia() { Id = int.Parse(sdr["instanciaid"].ToString()) };
                }
                sdr.Close();
                return esquema;
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

        public List<Esquema> Listar(string nombre)
        {
            try
            {
                List<Esquema> esquemas = new List<Esquema>();
                
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarEsquema", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                this.Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Esquema esquema = new Esquema();
                    esquema = new Esquema();
                    esquema.Id = int.Parse(sdr["id"].ToString());
                    esquema.Nombre = sdr["nombre"].ToString();
                    esquema.Instancia = new Instancia() { Id = int.Parse(sdr["instanciaid"].ToString()) };
                    esquemas.Add(esquema);
                }
                sdr.Close();
                return esquemas;
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

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarObjetosBD", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                this.Conexion.Close();
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

        public void Insertar(ObjetoBD objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarObjetoBD", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;
                cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;
                cmd.Parameters.Add(new SqlParameter("@tipoobjetoid", SqlDbType.Int)).Value = objetoBD.TipoObjeto.Id;
                cmd.Parameters.Add(new SqlParameter("@tipoaccionid", SqlDbType.Int)).Value = objetoBD.TipoAccion.Id;
                cmd.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar, 500)).Value = objetoBD.Ruta;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = objetoBD.Nombre;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                this.Conexion.Close();
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
    }
}