using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudOSB11gConfigRepository:Repository
    {
        public SolicitudOSB11gConfigRepository()
        {
        }

        public SolicitudOSB11gConfigRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarAdaptadores(SolicitudOSB11gConfigAdaptadores adap)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigAdaptadores", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = adap.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = adap.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = adap.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = adap.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = adap.Accion;
            cmd.Parameters.Add(new SqlParameter("@JNDI", SqlDbType.VarChar,100)).Value = adap.JNDIName;
            cmd.Parameters.Add(new SqlParameter("@DataSourceName", SqlDbType.VarChar, 50)).Value = adap.DataSourceName;
            cmd.Parameters.Add(new SqlParameter("@ConnectionInitial", SqlDbType.VarChar, 50)).Value = adap.ConnectionInitial;
            cmd.Parameters.Add(new SqlParameter("@ConnectionMaximum", SqlDbType.VarChar, 50)).Value = adap.ConnectionMaximum;
            cmd.Parameters.Add(new SqlParameter("@ConnectionMinimum", SqlDbType.VarChar, 50)).Value = adap.ConnectionMinimum;

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

        public void InsertarCab(SolicitudOSB11gConfigCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigCab", this.Conexion);
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

        public void InsertarCarpetaArchivo(SolicitudOSB11gConfigCarpetaArchivo carpetaArchivo)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigCarpetaArchivo", this.Conexion);
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

        public void InsertarCertificado(SolicitudOSB11gConfigCertificados certificado)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigCertificados", this.Conexion);
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

        public void InsertarColas(SolicitudOSB11gConfigColas colas)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigColas", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = colas.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = colas.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = colas.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = colas.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = colas.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = colas.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 50)).Value = colas.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@JNDIName", SqlDbType.VarChar, 100)).Value = colas.JNDIName;
            cmd.Parameters.Add(new SqlParameter("@Template", SqlDbType.VarChar, 50)).Value = colas.Template;
            cmd.Parameters.Add(new SqlParameter("@SubDeployment", SqlDbType.VarChar, 50)).Value = colas.SubDeployment;
            cmd.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 50)).Value = colas.Target;
            cmd.Parameters.Add(new SqlParameter("@RedeliveryOverride", SqlDbType.VarChar, 50)).Value = colas.RedeliveryOverride;
            cmd.Parameters.Add(new SqlParameter("@RedeliveryLimit", SqlDbType.VarChar, 50)).Value = colas.RedeliveryLimit;
            cmd.Parameters.Add(new SqlParameter("@ExpirationPolicy", SqlDbType.VarChar, 50)).Value = colas.ExpirationPolicy;
            cmd.Parameters.Add(new SqlParameter("@ErrorDestination", SqlDbType.VarChar, 50)).Value = colas.ErrorDestination;
            cmd.Parameters.Add(new SqlParameter("@Observacion", SqlDbType.VarChar, 100)).Value = colas.Observacion;
            cmd.Parameters.Add(new SqlParameter("@ModuloJMS", SqlDbType.VarChar, 50)).Value = colas.ModuloJMS;
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

        public void InsertarDataSource(SolicitudOSB11gConfigDataSource dataSource)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gConfigDataSource", this.Conexion);
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
            cmd.Parameters.Add(new SqlParameter("@testconnections", SqlDbType.VarChar, 50)).Value = dataSource.TestConnections;
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

        public void InsertarServerCluster(SolicitudOSB11gConfigServerCluster serverCluster)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gConfigServer", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = serverCluster.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = serverCluster.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = serverCluster.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = serverCluster.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = serverCluster.Accion;
            cmd.Parameters.Add(new SqlParameter("@servercluster", SqlDbType.VarChar, 50)).Value = serverCluster.ServerCluster;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = serverCluster.Nombre;
            cmd.Parameters.Add(new SqlParameter("@servidor", SqlDbType.VarChar, 50)).Value = serverCluster.Servidor;
            cmd.Parameters.Add(new SqlParameter("@parametro", SqlDbType.VarChar, 50)).Value = serverCluster.Parametro;
            cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.VarChar, 50)).Value = serverCluster.Valor;
            cmd.Parameters.Add(new SqlParameter("@detalles", SqlDbType.VarChar, 50)).Value = serverCluster.Detalles;
            cmd.Parameters.Add(new SqlParameter("@puerto", SqlDbType.VarChar, 50)).Value = serverCluster.Puerto;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudOSB11gConfigCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gconfigCarpetaArchivo";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gConfigCertificados";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gConfigColas";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gConfigDataSource";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gConfigServerCluster";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudOSB11gConfigAdaptadores";
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