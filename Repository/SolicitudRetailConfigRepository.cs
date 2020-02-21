using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudRetailConfigRepository:Repository
    {
        public SolicitudRetailConfigRepository()
        {
        }

        public SolicitudRetailConfigRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudRetailConfigCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudRetailConfigCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 50)).Value = cab.ServidorDestino;
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

        public void InsertarDetalle(SolicitudRetailConfigDetalle detalle)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudRetailConfigDetalle", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = detalle.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = detalle.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = detalle.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = detalle.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = detalle.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = detalle.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = detalle.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = detalle.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 100)).Value = detalle.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = detalle.Observacion;
            cmd.Parameters.Add(new SqlParameter("@parametros", SqlDbType.VarChar, 50)).Value = detalle.ParametrosAmbiente;
            
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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudRetailConfigCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudRetailConfigDetalle";
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