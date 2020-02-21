using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMDBApplication.Repository
{
    public class SolicitudTomcatRepository: Repository
    {
        public SolicitudTomcatRepository()
        {
        }

        public SolicitudTomcatRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void InsertarCab(SolicitudTomcatCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudTomcatCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
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

        public void InsertarApp(SolicitudTomcatApp app)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudTomcatApp", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = app.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = app.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = app.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = app.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 500)).Value = app.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 500)).Value = app.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100)).Value = app.Tipo;
            cmd.Parameters.Add(new SqlParameter("@aplicacion", SqlDbType.VarChar, 100)).Value = app.Aplicacion;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = app.Accion;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = app.Observacion;
            cmd.Parameters.Add(new SqlParameter("@tieneparametros", SqlDbType.VarChar, 100)).Value = app.TieneParametros;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudTomcatCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudTomcatApp";
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