using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class SolicitudOSB11gRepository:Repository
    {
        public SolicitudOSB11gRepository()
        {
        }

        public SolicitudOSB11gRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void InsertarCab(SolicitudOSB11gCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB11gCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar, 50)).Value = cab.CodigoProyecto;
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

        public void InsertarServicios(SolicitudOSB11gServicios servicios)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gServicios", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = servicios.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = servicios.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = servicios.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = servicios.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = servicios.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = servicios.Accion;
            cmd.Parameters.Add(new SqlParameter("@nombrejar", SqlDbType.VarChar, 50)).Value = servicios.NombreJar;
            cmd.Parameters.Add(new SqlParameter("@proyectoservicio", SqlDbType.VarChar, 50)).Value = servicios.ProyectoServicio;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = servicios.Observacion;
            cmd.Parameters.Add(new SqlParameter("@parametrosambiente", SqlDbType.VarChar, 50)).Value = servicios.ParametrosAmbiente;

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

        public void InsertarAplicaciones(SolicitudOSB11gAplicaciones aplicaciones)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudOSB10gServicios", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = aplicaciones.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = aplicaciones.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = aplicaciones.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = aplicaciones.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@rutaorigen", SqlDbType.VarChar, 100)).Value = aplicaciones.RutaOrigen;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = aplicaciones.Accion;
            cmd.Parameters.Add(new SqlParameter("@tipoinstalacion", SqlDbType.VarChar, 50)).Value = aplicaciones.TipoInstalacion;
            cmd.Parameters.Add(new SqlParameter("@aplicacion", SqlDbType.VarChar, 50)).Value = aplicaciones.Aplicacion;
            cmd.Parameters.Add(new SqlParameter("@nombrecluster", SqlDbType.VarChar, 50)).Value = aplicaciones.NombreCluster;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 100)).Value = aplicaciones.Observacion;
            cmd.Parameters.Add(new SqlParameter("@parametrosambiente", SqlDbType.VarChar, 50)).Value = aplicaciones.ParametrosAmbiente;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudOSB11gCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSolicitudOSB11gServicios";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudSolicitudOSB11gAplicaciones";
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