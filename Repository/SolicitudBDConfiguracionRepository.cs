using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudBDConfiguracionRepository:Repository
    {
        public SolicitudBDConfiguracionRepository() { }
        public SolicitudBDConfiguracionRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void Insertar(SolicitudBDConfiguracion objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitudBDConfiguracion", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@NumeroArchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;
                cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;
                cmd.Parameters.Add(new SqlParameter("@tabla", SqlDbType.VarChar, 50)).Value = objetoBD.Tabla;
                cmd.Parameters.Add(new SqlParameter("@comentario", SqlDbType.VarChar)).Value = objetoBD.Comentario;
                cmd.Parameters.Add(new SqlParameter("@archivo", SqlDbType.VarChar, 100)).Value = objetoBD.Archivo;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = objetoBD.Tipo;

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

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudBDConfiguracion", this.Conexion);
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
    }
}