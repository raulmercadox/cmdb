using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudBDCampoRepository:Repository
    {
        public SolicitudBDCampoRepository() { }
        public SolicitudBDCampoRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void Insertar(SolicitudBDCampo objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitudBDCampo", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@NumeroArchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;
                cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;
                cmd.Parameters.Add(new SqlParameter("@nombretabla", SqlDbType.VarChar, 50)).Value = objetoBD.NombreTabla;
                cmd.Parameters.Add(new SqlParameter("@tipoaccionbdid", SqlDbType.Int)).Value = objetoBD.TipoAccionBD.Id;
                cmd.Parameters.Add(new SqlParameter("@nombrecolumna", SqlDbType.VarChar, 50)).Value = objetoBD.NombreColumna;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = objetoBD.Tipo;
                cmd.Parameters.Add(new SqlParameter("@comentario", SqlDbType.VarChar, 50)).Value = objetoBD.Comentario;
                cmd.Parameters.Add(new SqlParameter("@notnull", SqlDbType.VarChar, 1)).Value = objetoBD.NotNull;
                cmd.Parameters.Add(new SqlParameter("@defaultvalue", SqlDbType.VarChar, 50)).Value = objetoBD.DefaultValue;
                cmd.Parameters.Add(new SqlParameter("@checkvalue", SqlDbType.VarChar, 50)).Value = objetoBD.CheckValue;
                
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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudBDCampo", this.Conexion);
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