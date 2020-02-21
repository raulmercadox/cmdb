using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class SeguridadRepository : Repository
    {
        public SeguridadRepository() { }
        public SeguridadRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Usuario ObtenerUsuario(string nombre)
        {
            Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerUsuario", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 30)).Value = nombre;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(sdr["id"]);
                    usuario.Nombre = sdr["usuario"].ToString();
                    usuario.Clave = sdr["clave"].ToString();
                    usuario.Correo = sdr["correo"].ToString();
                    usuario.Administrador = Convert.ToBoolean(sdr["administrador"]);
                    usuario.Operador = Convert.ToBoolean(sdr["operador"]);
                    usuario.Lector = Convert.ToBoolean(sdr["lector"]);
                    usuario.CM = Convert.ToBoolean(sdr["CM"]);
                    usuario.RM = Convert.ToBoolean(sdr["RM"]);
                    usuario.Ejecutor = Convert.ToBoolean(sdr["Ejecutor"]);
                    usuario.Test = Convert.ToBoolean(sdr["Test"]);
                }
                sdr.Close();
                return usuario;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
        }
    }
}
