using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SolicitudBDJobRepository:Repository
    {
        public SolicitudBDJobRepository()
        {
        }
        public SolicitudBDJobRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void Insertar(SolicitudBDJob objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarSolicitudBDJob", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;
                cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar,50)).Value = objetoBD.Tipo;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = objetoBD.Nombre;
                cmd.Parameters.Add(new SqlParameter("@tipoaccionbdid", SqlDbType.Int)).Value = objetoBD.TipoAccionBD.Id;
                cmd.Parameters.Add(new SqlParameter("@ejecucioninicial", SqlDbType.VarChar,50)).Value = objetoBD.EjecucionInicial;
                cmd.Parameters.Add(new SqlParameter("@intervalo", SqlDbType.VarChar, 50)).Value = objetoBD.Intervalo;
                cmd.Parameters.Add(new SqlParameter("@informacionadicional", SqlDbType.VarChar, 500)).Value = objetoBD.InformacionAdicional;
                cmd.Parameters.Add(new SqlParameter("@NumeroArchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                this.Conexion.Open();
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

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarSolicitudBDJob", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = numeroArchivo;
                this.Conexion.Open();
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