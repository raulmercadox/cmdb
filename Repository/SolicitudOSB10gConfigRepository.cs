using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudOSB10gConfigRepository:Repository
    {
        public SolicitudOSB10gConfigRepository()
        {
        }

        public SolicitudOSB10gConfigRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudOSB10gConfigCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@servidordestino", SqlDbType.VarChar, 100)).Value = cab.ServidorDestino;
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

        public void InsertarCarpetaArchivo(SolicitudOSB10gConfigCarpetaArchivo carpetaArchivo)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigCarpetaArchivo", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = carpetaArchivo.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = carpetaArchivo.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = carpetaArchivo.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = carpetaArchivo.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = carpetaArchivo.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = carpetaArchivo.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = carpetaArchivo.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = carpetaArchivo.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 100)).Value = carpetaArchivo.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = carpetaArchivo.Observacion;
            cmd.Parameters.Add(new SqlParameter("@ParametrosAmbiente", SqlDbType.VarChar, 50)).Value = carpetaArchivo.ParametrosAmbiente;
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

        public void InsertarCertificado(SolicitudOSB10gConfigCertificados certificado)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigCertificados", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = certificado.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = certificado.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = certificado.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = certificado.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = certificado.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = certificado.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = certificado.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = certificado.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 100)).Value = certificado.ServidoresDestino;
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

        public void InsertarDataSource(SolicitudOSB10gConfigDataSource dataSource)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigDataSource", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = dataSource.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = dataSource.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = dataSource.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = dataSource.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = dataSource.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = dataSource.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 100)).Value = dataSource.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@jndiname", SqlDbType.VarChar, 50)).Value = dataSource.JNDIName;
            cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 100)).Value = dataSource.URL;
            cmd.Parameters.Add(new SqlParameter("@driverclassname", SqlDbType.VarChar, 50)).Value = dataSource.DriverClassName;
            cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50)).Value = dataSource.User;
            cmd.Parameters.Add(new SqlParameter("@capacityinitial", SqlDbType.VarChar, 50)).Value = dataSource.CapacityInitial;
            cmd.Parameters.Add(new SqlParameter("@capacitymaximum", SqlDbType.VarChar, 50)).Value = dataSource.CapacityMaximum;
            cmd.Parameters.Add(new SqlParameter("@capacityminimum", SqlDbType.VarChar, 50)).Value = dataSource.CapacityMinimum;
            cmd.Parameters.Add(new SqlParameter("@supportglobal", SqlDbType.VarChar, 50)).Value = dataSource.SupportGlobal;
            cmd.Parameters.Add(new SqlParameter("@statementcache", SqlDbType.VarChar, 50)).Value = dataSource.StatementCache;
            cmd.Parameters.Add(new SqlParameter("@inactiveconnection", SqlDbType.VarChar, 50)).Value = dataSource.InactiveConnection;
            cmd.Parameters.Add(new SqlParameter("@testconnection", SqlDbType.VarChar, 50)).Value = dataSource.TestConnections;
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

        public void InsertarServerCluster(SolicitudOSB10gConfigServer server)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigServer", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = server.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = server.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = server.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = server.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = server.Accion;
            cmd.Parameters.Add(new SqlParameter("@parametro", SqlDbType.VarChar, 50)).Value = server.Parametro;
            cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.VarChar, 50)).Value = server.Valor;
            cmd.Parameters.Add(new SqlParameter("@detalles", SqlDbType.VarChar, 50)).Value = server.Detalles;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudOSB10gConfigCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB10gConfigCarpetaArchivo";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB10gConfigCertificados";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB10gConfigDataSource";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB10gConfigServer";
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