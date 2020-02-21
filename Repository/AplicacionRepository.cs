using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace CMDBApplication.Repository
{
    public class AplicacionRepository : Repository
    {
        public AplicacionRepository()
        {
        }

        public AplicacionRepository(string cadcon)
            : base(cadcon)
        {
        }

        public List<Aplicacion> Listar(string nombre, string ruta, string herramienta, string version, char estado)
        {
            List<Aplicacion> aplicaciones = new List<Aplicacion>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarAplicacion", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
            cmd.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar, 100)).Value = ruta;
            cmd.Parameters.Add(new SqlParameter("@herramienta", SqlDbType.VarChar, 50)).Value = herramienta;
            cmd.Parameters.Add(new SqlParameter("@version", SqlDbType.VarChar, 50)).Value = version;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Char, 1)).Value = estado;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Aplicacion p = new Aplicacion();
                    p.Nombre = sdr["nombre"].ToString();
                    p.RutaSVN = sdr["ruta"].ToString();
                    p.Herramienta = sdr["herramienta"].ToString();
                    p.Version = sdr["version"].ToString();
                    p.Estado = Convert.ToChar(sdr["estado"]);
                    p.Proyecto.Nombre = sdr["nombreproyecto"].ToString();
                    aplicaciones.Add(p);
                }
                sdr.Close();
                return aplicaciones;
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
