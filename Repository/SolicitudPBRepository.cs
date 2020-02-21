using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudPBRepository:Repository
    {
        public SolicitudPBRepository()
        {
        }

        public SolicitudPBRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudPBCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudPBCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@aplicacion", SqlDbType.VarChar, 50)).Value = cab.Aplicacion;
            cmd.Parameters.Add(new SqlParameter("@tipopase", SqlDbType.VarChar,50)).Value = cab.TipoPase;
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

        public void InsertarArchivos(SolicitudPBArchivos archivos)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudPBArchivo", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = archivos.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = archivos.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@orden", SqlDbType.VarChar, 50)).Value = archivos.Orden;
            cmd.Parameters.Add(new SqlParameter("@grupodesarrollo", SqlDbType.VarChar, 50)).Value = archivos.GrupoDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = archivos.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = archivos.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@servidororigen", SqlDbType.VarChar, 50)).Value = archivos.ServidorOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = archivos.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 50)).Value = archivos.ServidorDestino;
            cmd.Parameters.Add(new SqlParameter("@nombrearchivo", SqlDbType.VarChar, 50)).Value = archivos.NombreArchivo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = archivos.Accion;
            cmd.Parameters.Add(new SqlParameter("@informacionadicional", SqlDbType.VarChar, 100)).Value = archivos.InformacionAdicional;
            
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

        public void InsertarLibrerias(SolicitudPBLibrerias librerias)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudPBLibrerias", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = librerias.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = librerias.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@orden", SqlDbType.VarChar,50)).Value = librerias.Orden;
            cmd.Parameters.Add(new SqlParameter("@grupodesarrollo", SqlDbType.VarChar, 50)).Value = librerias.GrupoDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = librerias.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = librerias.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@servidor", SqlDbType.VarChar, 50)).Value = librerias.Servidor;
            cmd.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar, 100)).Value = librerias.Ruta;
            cmd.Parameters.Add(new SqlParameter("@libreria", SqlDbType.VarChar, 50)).Value = librerias.Libreria;
            cmd.Parameters.Add(new SqlParameter("@objeto", SqlDbType.VarChar, 50)).Value = librerias.Objeto;
            cmd.Parameters.Add(new SqlParameter("@libreriadestino", SqlDbType.VarChar, 100)).Value = librerias.LibreriaDestino;
            
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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudPBCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudPBArchivos";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudPBLibrerias";
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