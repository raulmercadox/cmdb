﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudConfigApp11gRepository:Repository
    {
        public SolicitudConfigApp11gRepository()
        {
        }

        public SolicitudConfigApp11gRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void InsertarCab(SolicitudConfigApp11gCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar)).Value = cab.Observaciones;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 100)).Value = cab.ServidorDestino;

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

        public void InsertarServerCluster(SolicitudConfigApp11gServerCluster serverCluster)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gServerCluster", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = serverCluster.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = serverCluster.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = serverCluster.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = serverCluster.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = serverCluster.Accion;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 100)).Value = serverCluster.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = serverCluster.Nombre;
            cmd.Parameters.Add(new SqlParameter("@destino", SqlDbType.VarChar, 100)).Value = serverCluster.Destino;
            cmd.Parameters.Add(new SqlParameter("@parametros", SqlDbType.VarChar, 100)).Value = serverCluster.Parametros;
            cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.VarChar, 100)).Value = serverCluster.Valor;
            cmd.Parameters.Add(new SqlParameter("@detalles", SqlDbType.VarChar, 100)).Value = serverCluster.Detalles;
            cmd.Parameters.Add(new SqlParameter("@puerto", SqlDbType.VarChar, 100)).Value = serverCluster.Puerto;

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

        public void InsertarDataSource(SolicitudConfigApp11gDatasource dataSource)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gDataSource", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = dataSource.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = dataSource.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = dataSource.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = dataSource.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = dataSource.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = dataSource.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 100)).Value = dataSource.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@jndiname", SqlDbType.VarChar, 100)).Value = dataSource.JNDIName;
            cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 100)).Value = dataSource.URL;
            cmd.Parameters.Add(new SqlParameter("@driverclassname", SqlDbType.VarChar, 100)).Value = dataSource.DriverClassName;
            cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 100)).Value = dataSource.User;
            cmd.Parameters.Add(new SqlParameter("@capacityinitial", SqlDbType.VarChar, 100)).Value = dataSource.CapacityInitial;
            cmd.Parameters.Add(new SqlParameter("@capacitymaximun", SqlDbType.VarChar, 100)).Value = dataSource.CapacityMaximun;
            cmd.Parameters.Add(new SqlParameter("@capacityminimun", SqlDbType.VarChar, 100)).Value = dataSource.CapacityMinimun;
            cmd.Parameters.Add(new SqlParameter("@supportglobal", SqlDbType.VarChar, 100)).Value = dataSource.SupportGlobal;
            cmd.Parameters.Add(new SqlParameter("@statementcache", SqlDbType.VarChar, 100)).Value = dataSource.StatementCache;
            cmd.Parameters.Add(new SqlParameter("@inactiveconnection", SqlDbType.VarChar, 100)).Value = dataSource.InactiveConnection;
            cmd.Parameters.Add(new SqlParameter("@testconnection", SqlDbType.VarChar, 100)).Value = dataSource.TestConnections;
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

        public void InsertarCarpetasArchivos(SolicitudConfigApp11gCarpetasArchivos carpetaArchivo)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gCarpetaArchivo", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = carpetaArchivo.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = carpetaArchivo.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = carpetaArchivo.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = carpetaArchivo.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = carpetaArchivo.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = carpetaArchivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 500)).Value = carpetaArchivo.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 500)).Value = carpetaArchivo.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 500)).Value = carpetaArchivo.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = carpetaArchivo.Observacion;
            cmd.Parameters.Add(new SqlParameter("@tieneparametros", SqlDbType.VarChar, 100)).Value = carpetaArchivo.TieneParametros;
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

        public void InsertarSesionCorreo(SolicitudConfigApp11gSesionCorreo sesionCorreo)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gSesionCorreo", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = sesionCorreo.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = sesionCorreo.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = sesionCorreo.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = sesionCorreo.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = sesionCorreo.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = sesionCorreo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 100)).Value = sesionCorreo.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@jndiname", SqlDbType.VarChar, 100)).Value = sesionCorreo.JNDIName;
            cmd.Parameters.Add(new SqlParameter("@javamailproperties", SqlDbType.VarChar, 100)).Value = sesionCorreo.JavaMailProperties;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = sesionCorreo.Observacion;
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

        public void InsertarCertificado(SolicitudConfigApp11gCertificado certificado)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudConfigApp11gCertificado", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = certificado.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = certificado.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 100)).Value = certificado.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 100)).Value = certificado.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 100)).Value = certificado.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = certificado.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 500)).Value = certificado.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 500)).Value = certificado.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 500)).Value = certificado.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = certificado.Observacion;
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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudConfigApp11gCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudConfigApp11gServerCluster";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudConfigApp11gDataSource";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudConfigApp11gCarpetaArchivo";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudConfigApp11gSesionCorreo";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudConfigApp11gCertificado";
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