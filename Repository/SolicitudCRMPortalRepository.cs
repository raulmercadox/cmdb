using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class SolicitudCRMPortalRepository:Repository
    {
        public SolicitudCRMPortalRepository()
        {
        }

        public SolicitudCRMPortalRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudCRMPortalCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMPortalCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@destino", SqlDbType.VarChar, 50)).Value = cab.Destino;
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

        public void InsertarPortal(SolicitudCRMPortalPortal portal)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMPortalPortal", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = portal.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = portal.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = portal.Responsable;
            cmd.Parameters.Add(new SqlParameter("@grupo", SqlDbType.VarChar, 50)).Value = portal.Grupo;
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = portal.Tipo;
            cmd.Parameters.Add(new SqlParameter("@nombreobjeto", SqlDbType.VarChar, 50)).Value = portal.NombreObjeto;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = portal.Accion;
            cmd.Parameters.Add(new SqlParameter("@permisos", SqlDbType.VarChar, 50)).Value = portal.Permisos;
            cmd.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 50)).Value = portal.Observacion;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudCrmPortalCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudCrmPortalPortal";
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