using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class SolicitudIXMediationRepository:Repository
    {
        public SolicitudIXMediationRepository()
        {
        }

        public SolicitudIXMediationRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudIXMediationCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudIXMediationCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar)).Value = cab.Observaciones;

            try
            {
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
                    Conexion.Close();
            }
        }

        public void InsertarObjetos(SolicitudIXMediationObjetos objetos)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudIXMediationObjetos", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetos.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = objetos.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@orden", SqlDbType.VarChar, 50)).Value = objetos.Orden;
            cmd.Parameters.Add(new SqlParameter("@directorio", SqlDbType.VarChar, 50)).Value = objetos.Directorio;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = objetos.Nombre;
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = objetos.Tipo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = objetos.Accion;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 50)).Value = objetos.Observacion;

            try
            {
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
                    Conexion.Close();
            }
        }

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudIXMediationCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudIXMediationObjetos";
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