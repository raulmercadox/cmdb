using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class SolicitudCRMOpcionesRepository:Repository
    {
        public SolicitudCRMOpcionesRepository()
        {
        }

        public SolicitudCRMOpcionesRepository(string cadcon)
            : base(cadcon)
        {

        }

        public void InsertarCab(SolicitudCRMOpcionesCab cab)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMOpcionesCab", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = cab.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = cab.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@codigoproyecto", SqlDbType.VarChar,50)).Value = cab.CodigoProyecto;
            cmd.Parameters.Add(new SqlParameter("@ambiente", SqlDbType.VarChar, 50)).Value = cab.Ambiente;
            cmd.Parameters.Add(new SqlParameter("@instancia", SqlDbType.VarChar, 50)).Value = cab.Instancia;
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

        public void InsertarRoles(SolicitudCRMOpcionesRoles opciones)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMOpcionesRoles", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = opciones.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = opciones.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = opciones.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = opciones.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@moduloaplicacion", SqlDbType.VarChar, 50)).Value = opciones.ModuloAplicacion;
            cmd.Parameters.Add(new SqlParameter("@nro", SqlDbType.VarChar, 50)).Value = opciones.Nro;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 50)).Value = opciones.Codigo;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = opciones.Nombre;
            cmd.Parameters.Add(new SqlParameter("@npcode", SqlDbType.VarChar, 50)).Value = opciones.NpCode;
            cmd.Parameters.Add(new SqlParameter("@nplevel", SqlDbType.VarChar, 50)).Value = opciones.NpLevel;
            cmd.Parameters.Add(new SqlParameter("@npmoduleid", SqlDbType.VarChar, 50)).Value = opciones.NpModuleId;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = opciones.Accion;

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

        public void InsertarOpciones(SolicitudCRMOpcionesOpciones opciones)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMOpcionesOpciones", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = opciones.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = opciones.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.VarChar, 50)).Value = opciones.Responsable;
            cmd.Parameters.Add(new SqlParameter("@analistadesarrollo", SqlDbType.VarChar, 50)).Value = opciones.AnalistaDesarrollo;
            cmd.Parameters.Add(new SqlParameter("@moduloaplicacion", SqlDbType.VarChar, 50)).Value = opciones.ModuloAplicacion;
            cmd.Parameters.Add(new SqlParameter("@nro", SqlDbType.VarChar, 50)).Value = opciones.Nro;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 50)).Value = opciones.Codigo;
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 50)).Value = opciones.Descripcion;
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50)).Value = opciones.Tipo;
            cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50)).Value = opciones.Title;
            cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 50)).Value = opciones.Url;
            cmd.Parameters.Add(new SqlParameter("@parentid", SqlDbType.VarChar, 50)).Value = opciones.ParenId;
            cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar, 50)).Value = opciones.Accion;
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

        public void InsertarPermisos(SolicitudCRMOpcionesPermisos permisos)
        {
            var cmd = new SqlCommand("dbo.usp_InsertarSolicitudCRMOpcionesPermisos", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = permisos.SolicitudId;
            cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = permisos.NumeroArchivo;
            cmd.Parameters.Add(new SqlParameter("@campo1", SqlDbType.VarChar, 50)).Value = permisos.Campo1;
            cmd.Parameters.Add(new SqlParameter("@campo2", SqlDbType.VarChar, 50)).Value = permisos.Campo2;
            cmd.Parameters.Add(new SqlParameter("@campo3", SqlDbType.VarChar, 50)).Value = permisos.Campo3;
            cmd.Parameters.Add(new SqlParameter("@campo4", SqlDbType.VarChar, 50)).Value = permisos.Campo4;
            cmd.Parameters.Add(new SqlParameter("@campo5", SqlDbType.VarChar, 50)).Value = permisos.Campo5;
            cmd.Parameters.Add(new SqlParameter("@campo6", SqlDbType.VarChar, 50)).Value = permisos.Campo6;
            cmd.Parameters.Add(new SqlParameter("@campo7", SqlDbType.VarChar, 50)).Value = permisos.Campo7;
            cmd.Parameters.Add(new SqlParameter("@campo8", SqlDbType.VarChar, 50)).Value = permisos.Campo8;
            cmd.Parameters.Add(new SqlParameter("@campo9", SqlDbType.VarChar, 50)).Value = permisos.Campo9;
            cmd.Parameters.Add(new SqlParameter("@campo10", SqlDbType.VarChar, 50)).Value = permisos.Campo10;
            cmd.Parameters.Add(new SqlParameter("@campo11", SqlDbType.VarChar, 50)).Value = permisos.Campo11;
            cmd.Parameters.Add(new SqlParameter("@campo12", SqlDbType.VarChar, 50)).Value = permisos.Campo12;
            cmd.Parameters.Add(new SqlParameter("@campo13", SqlDbType.VarChar, 50)).Value = permisos.Campo13;
            cmd.Parameters.Add(new SqlParameter("@campo14", SqlDbType.VarChar, 50)).Value = permisos.Campo14;

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
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudCrmOpcionesCab", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudCrmOpcionesRoles";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudCrmOpcionesOpciones";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "dbo.usp_EliminarSolicitudCrmOpcionesPermisos";
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