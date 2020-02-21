using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudSOAConfigRepository:Repository
    {
        public SolicitudSOAConfigRepository()
        {
        }

        public SolicitudSOAConfigRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudSOAConfigCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigCab", this.Conexion);
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

        public void InsertarInstanciasJ2EE(SolicitudSOAConfigInstanciasJ2EE instanciasJ2EE)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigInstanciasJ2EE", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = instanciasJ2EE.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = instanciasJ2EE.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.Nombre;
            cmd.Parameters.Add(new SqlParameter("@puertormi", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.PuertoRMI;
            cmd.Parameters.Add(new SqlParameter("@maximumheap", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.MaximumHeap;
            cmd.Parameters.Add(new SqlParameter("@initialheap", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.InitialHeap;
            cmd.Parameters.Add(new SqlParameter("@opcionesadicionales", SqlDbType.VarChar, 50)).Value = instanciasJ2EE.OpcionesAdicionales;
            
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

        public void InsertarAdaptadores(SolicitudSOAConfigAdaptadores adaptadores)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAEAR", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = adaptadores.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = adaptadores.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = adaptadores.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = adaptadores.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = adaptadores.Accion;
            cmd.Parameters.Add(new SqlParameter("@jndilocation", SqlDbType.VarChar, 50)).Value = adaptadores.JNDILocation;
            cmd.Parameters.Add(new SqlParameter("@connectionfactory", SqlDbType.VarChar, 50)).Value = adaptadores.ConnectionFactory;
            cmd.Parameters.Add(new SqlParameter("@connectioninterface", SqlDbType.VarChar, 50)).Value = adaptadores.ConnectionInterface;
            cmd.Parameters.Add(new SqlParameter("@atributo", SqlDbType.VarChar, 100)).Value = adaptadores.Atributo;
            cmd.Parameters.Add(new SqlParameter("@opcionesadicionales", SqlDbType.VarChar, 50)).Value = adaptadores.OpcionesAdicionales;

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

        public void InsertarPool(SolicitudSOAConfigPool pool)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigPool", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = pool.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = pool.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = pool.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = pool.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = pool.Accion;
            cmd.Parameters.Add(new SqlParameter("@container", SqlDbType.VarChar, 100)).Value = pool.Container;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = pool.Nombre;
            cmd.Parameters.Add(new SqlParameter("@connectionfactory", SqlDbType.VarChar, 50)).Value = pool.ConnectionFactory;
            cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 50)).Value = pool.URL;
            cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50)).Value = pool.User;
            cmd.Parameters.Add(new SqlParameter("@opciones", SqlDbType.VarChar, 50)).Value = pool.Opciones;

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

        public void InsertarDataSource(SolicitudSOAConfigDataSource datasource)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigDataSource", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = datasource.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = datasource.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = datasource.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = datasource.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = datasource.Accion;
            cmd.Parameters.Add(new SqlParameter("@container", SqlDbType.VarChar, 50)).Value = datasource.Container;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = datasource.Nombre;
            cmd.Parameters.Add(new SqlParameter("@jndilocation", SqlDbType.VarChar, 50)).Value = datasource.JNDILocation;
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = datasource.Tipo;
            cmd.Parameters.Add(new SqlParameter("@connectionpool", SqlDbType.VarChar, 50)).Value = datasource.ConnectionPool;
            cmd.Parameters.Add(new SqlParameter("@opciones", SqlDbType.VarChar, 50)).Value = datasource.Opciones;

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

        public void InsertarArchivos(SolicitudSOAConfigArchivos archivos)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigArchivos", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = archivos.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = archivos.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = archivos.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = archivos.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = archivos.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = archivos.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = archivos.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = archivos.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 50)).Value = archivos.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = archivos.Observacion;
            cmd.Parameters.Add(new SqlParameter("@parametros", SqlDbType.VarChar, 50)).Value = archivos.Parametros;

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

        public void InsertarCertificados(SolicitudSOAConfigCertificados certificados)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudSOAConfigCertificados", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = certificados.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = certificados.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = certificados.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = certificados.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = certificados.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = certificados.Nombre;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = certificados.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@rutadestino", SqlDbType.VarChar, 100)).Value = certificados.RutaDestino;
            cmd.Parameters.Add(new SqlParameter("@servidoresdestino", SqlDbType.VarChar, 100)).Value = certificados.ServidoresDestino;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = certificados.Observacion;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudSOAConfigAdaptadores", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigArchivos";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigCab";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigCertificados";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigDataSource";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigInstanciasJ2EE";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSOAConfigPool";
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