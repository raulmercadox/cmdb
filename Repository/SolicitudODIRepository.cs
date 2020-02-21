using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class SolicitudODIRepository:Repository
    {
        public SolicitudODIRepository()
        {
        }

        public SolicitudODIRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudODICab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudODICab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;

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

        public void InsertarArchivos(SolicitudODIArchivos archivos)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudODIArchivos", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = archivos.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = archivos.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = archivos.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = archivos.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = archivos.Accion;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = archivos.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 50)).Value = archivos.ServidorDestino;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = archivos.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@nombrearchivo", SqlDbType.VarChar, 50)).Value = archivos.NombreArchivo;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 50)).Value = archivos.Observacion;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudODICab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudODIArchivos";
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