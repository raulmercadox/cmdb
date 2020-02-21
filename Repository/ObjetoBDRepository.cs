using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMDBApplication.Models;

namespace CMDBApplication.Repository
{
    public class ObjetoBDRepository:Repository
    {
        public ObjetoBDRepository()
            : base()
        {
        }

        public ObjetoBDRepository(string cadcon)
            : base(cadcon)
        {
        }

        public void EliminarObjetos(int solicitudId, int numeroArchivo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_EliminarObjetosBD", this.Conexion);
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

        public void Insertar(ObjetoBD objetoBD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertarObjetoBD", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = objetoBD.Solicitud.Id;
                cmd.Parameters.Add(new SqlParameter("@instanciaid", SqlDbType.Int)).Value = objetoBD.Instancia.Id;

                if (objetoBD.Esquema==null)
                    cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = null;
                else
                    cmd.Parameters.Add(new SqlParameter("@esquemaid", SqlDbType.Int)).Value = objetoBD.Esquema.Id;

                cmd.Parameters.Add(new SqlParameter("@tipoobjetoid", SqlDbType.Int)).Value = objetoBD.TipoObjeto.Id;
                cmd.Parameters.Add(new SqlParameter("@tipoaccionid", SqlDbType.Int)).Value = objetoBD.TipoAccion.Id;
                cmd.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar, 500)).Value = objetoBD.Ruta;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = objetoBD.Nombre;
                cmd.Parameters.Add(new SqlParameter("@numeroarchivo", SqlDbType.Int)).Value = objetoBD.NumeroArchivo;
                cmd.Parameters.Add(new SqlParameter("@informacionadicional", SqlDbType.VarChar)).Value = objetoBD.InformacionAdicional;
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

        public List<ObjetoBD> Listar(int solicitudId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository tobdr = new TipoObjetoBDRepository();

                List<ObjetoBD> objetoBDs = new List<ObjetoBD>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarObjetoBDxSolicitud", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@solicitudid", SqlDbType.Int)).Value = solicitudId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(sdr.Read())
                {
                    ObjetoBD objetoBD = new ObjetoBD();
                    objetoBD.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]) };
                    objetoBD.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]) };
                    objetoBD.TipoObjeto = new TipoObjetoBD { Id = Convert.ToInt32(sdr["tipoobjetobdid"]) };
                    objetoBD.TipoAccion = new TipoAccionBD { Id = Convert.ToInt32(sdr["tipoaccionbdid"]) };
                    objetoBD.Nombre = sdr["objetobd"].ToString();
                    objetoBDs.Add(objetoBD);
                }
                sdr.Close();
                foreach (ObjetoBD objetoBD in objetoBDs)
                {
                    objetoBD.Instancia = ir.Obtener(objetoBD.Instancia.Id);
                    objetoBD.Esquema = er.Obtener(objetoBD.Esquema.Id);
                    objetoBD.TipoObjeto = tobdr.Obtener(objetoBD.TipoObjeto.Id);
                }
                return objetoBDs;
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

        public List<ObjetoBD> Listar(string nombre)
        {
            try
            {
                var ir = new InstanciaRepository();
                var er = new EsquemaRepository();
                var tobdr = new TipoObjetoBDRepository();
                var tabdr = new TipoAccionBDRepository();
                var sr = new SolicitudRepository();

                var objetosBD = new List<ObjetoBD>();
                var cmd = new SqlCommand("dbo.usp_ListarObjetoBDPorNombre", this.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var objetoBD = new ObjetoBD();
                    objetoBD.Instancia = new Instancia {Id=Convert.ToInt32(sdr["instanciaId"]),Nombre = sdr["instancianombre"].ToString() };
                    objetoBD.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]),Nombre=sdr["esquemanombre"].ToString() };
                    objetoBD.TipoObjeto = new TipoObjetoBD { Id = Convert.ToInt32(sdr["tipoobjetobdid"]),Nombre=sdr["tipoobjetonombre"].ToString() };
                    objetoBD.TipoAccion = new TipoAccionBD { Id = Convert.ToInt32(sdr["tipoaccionbdid"]),Nombre=sdr["tipoaccionnombre"].ToString() };
                    objetoBD.Solicitud = new Solicitud
                    {
                        Id = Convert.ToInt32(sdr["solicitudid"]),
                        Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]), Nombre = sdr["ambientenombre"].ToString() },
                        Proyecto = new Proyecto { Codigo = sdr["proyectocodigo"].ToString(), Nombre=sdr["proyectonombre"].ToString()},
                        Estado = sdr["estado"].ToString(),
                        FechaCreacion = Convert.ToDateTime(sdr["fechacreacion"])
                    };
                    if (sdr["fechaejecucion"] == DBNull.Value)
                    {
                        objetoBD.Solicitud.FechaEjecucion = null;
                    }
                    else
                    {
                        objetoBD.Solicitud.FechaEjecucion = Convert.ToDateTime(sdr["fechaejecucion"]);
                    }
                    objetoBD.Nombre = sdr["ObjetoBD"].ToString();
                    objetosBD.Add(objetoBD);
                }
                sdr.Close();
                return objetosBD;
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