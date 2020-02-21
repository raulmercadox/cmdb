using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudBDPermisoDBURepository:Repository
    {
        public SolicitudBDPermisoDBURepository() { }
        public SolicitudBDPermisoDBURepository(string cadcon)
            : base(cadcon)
        {
        }

        public void Insertar(SolicitudBDPermisoDBU objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitudBDPermisoDBU", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@NumeroArchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;
                cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;
                cmd.Parameters.Add(new SqlParameter("@tipoobjetobdid", SqlDbType.Int)).Value = objetoBD.TipoObjetoBD.Id;
                cmd.Parameters.Add(new SqlParameter("@nombreobjeto", SqlDbType.VarChar, 50)).Value = objetoBD.NombreObjeto;                
                cmd.Parameters.Add(new SqlParameter("@select", SqlDbType.VarChar, 1)).Value = objetoBD.Select;
                cmd.Parameters.Add(new SqlParameter("@insert", SqlDbType.VarChar, 1)).Value = objetoBD.Insert;
                cmd.Parameters.Add(new SqlParameter("@delete", SqlDbType.VarChar, 1)).Value = objetoBD.Delete;
                cmd.Parameters.Add(new SqlParameter("@update", SqlDbType.VarChar, 1)).Value = objetoBD.Update;
                cmd.Parameters.Add(new SqlParameter("@execute", SqlDbType.VarChar, 1)).Value = objetoBD.Execute;
                cmd.Parameters.Add(new SqlParameter("@permisodbu", SqlDbType.VarChar, 50)).Value = objetoBD.UserDBU;
                
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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudBDPermisoDBU", this.Conexion);
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