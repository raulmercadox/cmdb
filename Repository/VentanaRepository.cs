using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CMDBApplication.Repository
{
    public class VentanaRepository:Repository
    {
        public VentanaRepository() { }
        public VentanaRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Ventana Obtener(DateTime desde, DateTime? hasta)
        {
            Ventana v = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerVentanaPorRango", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@desde", SqlDbType.DateTime)).Value = desde;
            cmd.Parameters.Add(new SqlParameter("@hasta", SqlDbType.DateTime)).Value = hasta;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    v = new Ventana();
                    v.Id = Convert.ToInt32(sdr["id"]);
                    v.Desde = Convert.ToDateTime(sdr["desde"]);
                    if (sdr["hasta"] == DBNull.Value)
                        v.Hasta = null;
                    else
                        v.Hasta = Convert.ToDateTime(sdr["hasta"]);
                    
                }
                sdr.Close();
                return v;
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

        public Ventana Obtener(int id)
        {
            Ventana v = new Ventana();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerVentanaPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    v = new Ventana();
                    v.Id = Convert.ToInt32(sdr["id"]);
                    v.Desde = Convert.ToDateTime(sdr["desde"]);
                    if (sdr["hasta"] == DBNull.Value)
                        v.Hasta = null;
                    else
                        v.Hasta = Convert.ToDateTime(sdr["hasta"]);
                    
                }
                sdr.Close();
                return v;
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

        public Ventana Actualizar(Ventana v)
        {
            string procedure = v.Id == 0 ? "dbo.usp_CrearVentana" : "dbo.usp_ActualizarVentana";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (v.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = v.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@desde", SqlDbType.DateTime)).Value = v.Desde;
            cmd.Parameters.Add(new SqlParameter("@hasta", SqlDbType.DateTime)).Value = v.Hasta;

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                v.Id = id;
                Conexion.Close();
                return v;
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

        public List<Ventana> Listar()
        {
            List<Ventana> ventanas = new List<Ventana>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarVentana", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Ventana v = new Ventana();
                    v.Id = Convert.ToInt32(sdr["id"]);
                    v.Desde = Convert.ToDateTime(sdr["desde"]);
                    if (sdr["hasta"] == DBNull.Value)
                        v.Hasta = null;
                    else
                        v.Hasta = Convert.ToDateTime(sdr["hasta"]);
                    
                    ventanas.Add(v);
                }
                sdr.Close();
                return ventanas;
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
    }
}