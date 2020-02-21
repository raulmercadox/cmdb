using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMDBApplication.Repository
{
    public class ProyectoRepository : Repository
    {
        public ProyectoRepository() { }
        public ProyectoRepository(string cadcon)
            : base(cadcon)
        {
        }

        public Proyecto Obtener(int id)
        {
            Proyecto p = new Proyecto();
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerProyectoPorId", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Proyecto();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Codigo = sdr["codigo"].ToString();
                    p.Nombre = sdr["nombre"].ToString();
                    p.Pm = sdr["pm"].ToString();
                    p.Ptl = sdr["ptl"].ToString();
                    p.Estado = Convert.ToChar(sdr["estado"]);
                    /*if (sdr["fechaprod"] == DBNull.Value)
                    {
                        p.FechaProd = null;
                    }
                    else
                    {
                        p.FechaProd = Convert.ToDateTime(sdr["fechaprod"]);
                    }*/
                    if (sdr["responsableid"] != DBNull.Value)
                    {
                        p.Responsable = new Responsable { Id = Convert.ToInt32(sdr["responsableid"]) };
                    }
                    if (sdr["tipoproyectoid"] == DBNull.Value)
                    {
                        p.TipoProyecto = null;
                    }
                    else
                    {
                        p.TipoProyecto = new TipoProyecto { Id = Convert.ToInt32(sdr["tipoproyectoid"]) };
                    }
                    p.Mejora = Convert.ToBoolean(sdr["mejora"]);
                    p.Impacto = sdr["impacto"].ToString();
                    p.CodigoPresupuestal = sdr["codigopresupuestal"].ToString();
                    p.CodigoAlterno = sdr["codigoalterno"].ToString();
                }
                sdr.Close();
                if (p.Responsable != null)
                {
                    ResponsableRepository rr = new ResponsableRepository();
                    p.Responsable = rr.Obtener(p.Responsable.Id);
                }
                if (p.TipoProyecto != null)
                {
                    TipoProyectoRepository tpr = new TipoProyectoRepository();
                    p.TipoProyecto = tpr.Obtener(p.TipoProyecto.Id);
                }
                if (p.Id != 0)
                {
                    cmd.CommandText = "dbo.usp_ListaAplicaciones";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Aplicacion app = new Aplicacion();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        app.RutaSVN = sdr["RutaSVN"].ToString();
                        app.Herramienta = sdr["Herramienta"].ToString();
                        app.Version = sdr["Version"].ToString();
                        app.Estado = Convert.ToChar(sdr["Estado"]);
                        p.Aplicaciones.Add(app);
                    }
                    sdr.Close();
                }
                
                if (p.Id != 0)
                {
                    cmd.CommandText = "dbo.usp_ListarDesarrolladorPorProyecto";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Desarrollador des = new Desarrollador();
                        des.Id = Convert.ToInt32(sdr["Id"]);
                        des.Usuario = sdr["Usuario"].ToString();
                        des.Clave = sdr["Clave"].ToString();
                        des.Nombre = sdr["Nombre"].ToString();
                        des.Correo = sdr["Correo"].ToString();
                        p.Desarrolladores.Add(des);
                    }
                    sdr.Close();
                }
                
                return p;
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

        public Proyecto Obtener(string codigo)
        {
            Proyecto p = null;
            SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerProyecto", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 30)).Value = codigo;
            try
            {

                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    p = new Proyecto();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Codigo = sdr["codigo"].ToString();
                    p.Nombre = sdr["nombre"].ToString();
                    p.Pm = sdr["pm"].ToString();
                    p.Ptl = sdr["ptl"].ToString();
                    p.Estado = Convert.ToChar(sdr["estado"]);
                    if (sdr["responsableid"] != DBNull.Value)
                    {
                        p.Responsable = new Responsable { Id = Convert.ToInt32(sdr["responsableid"]) };
                    }
                    if (sdr["tipoproyectoid"] == DBNull.Value)
                    {
                        p.TipoProyecto = null;
                    }
                    else
                    {
                        p.TipoProyecto = new TipoProyecto { Id = Convert.ToInt32(sdr["tipoproyectoid"]) };
                    }
                    p.Mejora = Convert.ToBoolean(sdr["mejora"]);
                    p.Impacto = sdr["impacto"].ToString();
                    p.CodigoPresupuestal = sdr["codigopresupuestal"].ToString();
                    p.CodigoAlterno = sdr["codigoalterno"].ToString();
                }
                sdr.Close();
                if (p!=null && p.Responsable != null)
                {
                    ResponsableRepository rr = new ResponsableRepository();
                    p.Responsable = rr.Obtener(p.Responsable.Id);
                }
                if (p!=null && p.TipoProyecto != null)
                {
                    TipoProyectoRepository tpr = new TipoProyectoRepository();
                    p.TipoProyecto = tpr.Obtener(p.TipoProyecto.Id);
                }
                if (p != null)
                {
                    cmd.CommandText = "dbo.usp_ListaAplicaciones";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Aplicacion app = new Aplicacion();
                        app.Id = Convert.ToInt32(sdr["Id"]);
                        app.Nombre = sdr["Nombre"].ToString();
                        app.RutaSVN = sdr["RutaSVN"].ToString();
                        app.Herramienta = sdr["Herramienta"].ToString();
                        app.Version = sdr["Version"].ToString();
                        app.Estado = Convert.ToChar(sdr["Estado"]);
                        p.Aplicaciones.Add(app);
                    }
                    sdr.Close();
                }
                
                if (p != null)
                {
                    cmd.CommandText = "dbo.usp_ListarDesarrolladorPorProyecto";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        Desarrollador des = new Desarrollador();
                        des.Id = Convert.ToInt32(sdr["Id"]);
                        des.Usuario = sdr["Usuario"].ToString();
                        des.Clave = sdr["Clave"].ToString();
                        des.Nombre = sdr["Nombre"].ToString();
                        des.Correo = sdr["Correo"].ToString();
                        p.Desarrolladores.Add(des);
                    }
                    sdr.Close();
                }

                if (p != null)
                {
                    p.Ambientes = new List<ProyectoAmbiente>();
                    cmd.CommandText = "dbo.usp_ListarProyectoAmbiente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = p.Id;
                    Conexion.Open();
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sdr.Read())
                    {
                        ProyectoAmbiente pa = new ProyectoAmbiente();
                        pa.Id = Convert.ToInt32(sdr["id"]);
                        pa.Proyecto = new Proyecto { Id = p.Id };
                        pa.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                        pa.FechaPase = Convert.ToDateTime(sdr["fechapase"]);
                        p.Ambientes.Add(pa);
                    }
                    sdr.Close();

                    AmbienteRepository ar = new AmbienteRepository();
                    foreach (ProyectoAmbiente pa in p.Ambientes)
                    {
                        pa.Ambiente = ar.Obtener(pa.Ambiente.Id);
                    }
                }
                return p;
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

        public List<ProyectoAmbiente> ListarAmbiente(Proyecto p)
        {
            try
            {
                List<ProyectoAmbiente> ambientes = new List<ProyectoAmbiente>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarProyectoAmbiente", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = p.Id;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    ProyectoAmbiente pa = new ProyectoAmbiente();
                    pa.Id = Convert.ToInt32(sdr["id"]);
                    pa.Proyecto = new Proyecto { Id = p.Id };
                    pa.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    pa.FechaPase = Convert.ToDateTime(sdr["fechapase"]);
                    ambientes.Add(pa);
                }
                sdr.Close();

                AmbienteRepository ar = new AmbienteRepository();
                foreach (ProyectoAmbiente pa in ambientes)
                {
                    pa.Ambiente = ar.Obtener(pa.Ambiente.Id);
                }

                return ambientes;
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

        public List<Correo> ListarCorreo(Proyecto p)
        {
            try
            {
                var correos = new List<Correo>();
                var cmd = new SqlCommand("dbo.usp_ListarProyectoCorreo", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = p.Id;
                Conexion.Open();
                var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var correo = new Correo();
                    correo.Id = Convert.ToInt32(sdr["Id"]);
                    correo.Direccion = sdr["Correo"].ToString();
                    correos.Add(correo);
                }
                sdr.Close();
                return correos;
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

        public ProyectoAmbiente ObtenerAmbiente(int proyectoId, int ambienteid)
        {
            try
            {
                ProyectoAmbiente pa = null;
                AmbienteRepository ar = new AmbienteRepository();
                SqlCommand cmd = new SqlCommand("dbo.usp_ObtenerProyectoAmbiente", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteid;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    pa = new ProyectoAmbiente();
                    pa.Id = Convert.ToInt32(sdr["id"]);
                    pa.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["proyectoId"])};
                    pa.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    pa.FechaPase = Convert.ToDateTime(sdr["fechapase"]);
                }
                sdr.Close();
                if (pa != null)
                {
                    pa.Proyecto = Obtener(pa.Proyecto.Id);
                    pa.Ambiente = ar.Obtener(pa.Ambiente.Id);
                }
                return pa;
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

        public Proyecto Actualizar(Proyecto p)
        {
            string procedure = p.Id == 0 ? "dbo.usp_CrearProyecto" : "dbo.usp_ActualizarProyecto";

            SqlCommand cmd = new SqlCommand(procedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (p.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = p.Id;
            }
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 30)).Value = p.Codigo;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = p.Nombre;
            cmd.Parameters.Add(new SqlParameter("@pm", SqlDbType.VarChar, 50)).Value = p.Pm;
            cmd.Parameters.Add(new SqlParameter("@ptl", SqlDbType.VarChar, 50)).Value = p.Ptl;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Char, 1)).Value = p.Id == 0 ? 'E' : p.Estado; // Se crea por defecto en etapa de Ejecución
            cmd.Parameters.Add(new SqlParameter("@fechaprod", SqlDbType.DateTime)).Value = null;
            cmd.Parameters.Add(new SqlParameter("@mejora", SqlDbType.Bit)).Value = p.Mejora;
            cmd.Parameters.Add(new SqlParameter("@impacto", SqlDbType.VarChar)).Value = p.Impacto;
            cmd.Parameters.Add(new SqlParameter("@codigopresupuestal", SqlDbType.VarChar, 30)).Value = p.CodigoPresupuestal;
            cmd.Parameters.Add(new SqlParameter("@codigoalterno", SqlDbType.VarChar, 30)).Value = p.CodigoAlterno;
            if (p.Responsable != null && p.Responsable.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@responsableid", SqlDbType.Int)).Value = p.Responsable.Id;
            }
            if (p.TipoProyecto != null && p.TipoProyecto.Id > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@tipoproyectoid", SqlDbType.Int)).Value = p.TipoProyecto.Id;
            }

            try
            {
                Conexion.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;

                #region Actualizar aplicaciones
                foreach (Aplicacion app in p.Aplicaciones)
                {
                    cmd.Parameters.Clear();
                    if (app.Id == 0 && !app.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_InsertarAplicacion";
                        cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = app.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@RutaSVN", SqlDbType.VarChar, 100)).Value = app.RutaSVN;
                        cmd.Parameters.Add(new SqlParameter("@Herramienta", SqlDbType.VarChar, 50)).Value = app.Herramienta;
                        cmd.Parameters.Add(new SqlParameter("@Version", SqlDbType.VarChar, 50)).Value = app.Version;
                        cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char, 1)).Value = app.Estado;
                        int idAplicacion = Convert.ToInt32(cmd.ExecuteScalar());
                        app.Id = idAplicacion;
                    }
                    else if (app.Id != 0 && app.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_EliminarAplicacion";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = app.Id;
                        cmd.ExecuteNonQuery();
                    }
                    else if (app.Id != 0 && !app.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_ActualizarAplicacion";
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = app.Id;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = app.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@RutaSVN", SqlDbType.VarChar, 100)).Value = app.RutaSVN;
                        cmd.Parameters.Add(new SqlParameter("@Herramienta", SqlDbType.VarChar, 50)).Value = app.Herramienta;
                        cmd.Parameters.Add(new SqlParameter("@Version", SqlDbType.VarChar, 50)).Value = app.Version;
                        cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char, 1)).Value = app.Estado;
                        cmd.ExecuteNonQuery();
                    }
                }
                #endregion

                #region Actualizar Correos
                if (p.Correos != null)
                {
                    foreach (var correo in p.Correos)
                    {
                        cmd.Parameters.Clear();
                        if (correo.Id == 0 && !correo.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_InsertarProyectoCorreo";
                            cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                            cmd.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                            var idCorreo = Convert.ToInt32(cmd.ExecuteScalar());
                            correo.Id = idCorreo;
                        }
                        else if (correo.Id != 0 && correo.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_EliminarProyectoCorreo";
                            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = correo.Id;
                            cmd.ExecuteNonQuery();
                        }
                        else if (correo.Id != 0 && !correo.Eliminar)
                        {
                            cmd.CommandText = "dbo.usp_ActualizarProyectoCorreo";
                            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = correo.Id;
                            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo.Direccion;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                #endregion

                // Actualizar desarrolladores
                foreach (Desarrollador des in p.Desarrolladores)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ProyectoId", SqlDbType.Int)).Value = p.Id;
                    cmd.Parameters.Add(new SqlParameter("@DesarrolladorId", SqlDbType.Int)).Value = des.Id;
                    if (des.Eliminar)
                    {
                        cmd.CommandText = "dbo.usp_EliminarDesarrolladorDeProyecto";
                    }
                    else
                    {
                        cmd.CommandText = "dbo.usp_ActualizarProyectoDesarrollador";
                    }
                    cmd.ExecuteNonQuery();
                }

                // Eliminar Ambientes
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = p.Id;
                cmd.CommandText = "dbo.usp_EliminarProyectoAmbiente";
                cmd.ExecuteNonQuery();

                // Insertar Ambientes
                foreach (ProyectoAmbiente pa in p.Ambientes)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = p.Id;
                    cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = pa.Ambiente.Id;
                    cmd.Parameters.Add(new SqlParameter("@fechapase", SqlDbType.DateTime)).Value = pa.FechaPase;
                    cmd.CommandText = "dbo.usp_InsertarProyectoAmbiente";
                    cmd.ExecuteNonQuery();
                }

                Conexion.Close();
                p.Aplicaciones.RemoveAll(x => x.Eliminar);
                p.Desarrolladores.RemoveAll(x => x.Eliminar);
                p.Desarrolladores = p.Desarrolladores.GroupBy(x => x.Usuario).Select(y => y.First()).ToList();
                return p;
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

        public List<Proyecto> Listar(string codigo, string nombre, string pm, string ptl, char estado, int responsableId, bool mejora, string impacto,int tipoproyectoid,string codigoPresupuestal="",string codigoAlterno="")
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            SqlCommand cmd = new SqlCommand("dbo.usp_ListarProyecto", this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 30)).Value = codigo;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 100)).Value = nombre;
            cmd.Parameters.Add(new SqlParameter("@pm", SqlDbType.VarChar, 50)).Value = pm;
            cmd.Parameters.Add(new SqlParameter("@ptl", SqlDbType.VarChar, 50)).Value = ptl;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Char, 1)).Value = estado;
            cmd.Parameters.Add(new SqlParameter("@responsableid", SqlDbType.Int)).Value = responsableId;
            cmd.Parameters.Add(new SqlParameter("@mejora", SqlDbType.Bit)).Value = mejora;
            cmd.Parameters.Add(new SqlParameter("@impacto", SqlDbType.VarChar)).Value = impacto;
            cmd.Parameters.Add(new SqlParameter("@tipoproyectoid", SqlDbType.Int)).Value = tipoproyectoid;
            cmd.Parameters.Add(new SqlParameter("@codigopresupuestal", SqlDbType.VarChar, 10)).Value = codigoPresupuestal;
            cmd.Parameters.Add(new SqlParameter("@codigoalterno", SqlDbType.VarChar, 30)).Value = codigoAlterno;
            try
            {
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Proyecto p = new Proyecto();
                    p.Id = Convert.ToInt32(sdr["id"]);
                    p.Codigo = sdr["codigo"].ToString();
                    p.Nombre = sdr["nombre"].ToString();
                    p.Pm = sdr["pm"].ToString();
                    p.Ptl = sdr["ptl"].ToString();
                    p.Estado = Convert.ToChar(sdr["estado"]);
                    /*if (sdr["fechaprod"] == DBNull.Value)
                    {
                        p.FechaProd = null;
                    }
                    else
                    {
                        p.FechaProd = Convert.ToDateTime(sdr["fechaprod"]);
                    }*/
                    if (sdr["responsableid"] != DBNull.Value)
                    {
                        p.Responsable = new Responsable { Id = Convert.ToInt32(sdr["responsableid"]) };
                    }
                    if (sdr["tipoproyectoid"] != DBNull.Value)
                    {
                        p.TipoProyecto = new TipoProyecto { Id = Convert.ToInt32(sdr["tipoproyectoid"]) };
                    }
                    p.Mejora = Convert.ToBoolean(sdr["mejora"]);
                    p.Impacto = sdr["impacto"].ToString();
                    p.CodigoPresupuestal = sdr["codigopresupuestal"].ToString();
                    p.CodigoAlterno = sdr["codigoalterno"].ToString();
                    proyectos.Add(p);
                }
                sdr.Close();
                ResponsableRepository rr = new ResponsableRepository();
                TipoProyectoRepository tpr = new TipoProyectoRepository();
                proyectos.ForEach(p =>
                {
                    if (p.Responsable != null)
                    {
                        p.Responsable = rr.Obtener(p.Responsable.Id);
                    }
                    if (p.TipoProyecto != null)
                    {
                        p.TipoProyecto = tpr.Obtener(p.TipoProyecto.Id);
                    }
                });
                return proyectos;
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

        public List<ObjetoBD> ListarObjetoBD(int proyectoId, int ambienteId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository tobr = new TipoObjetoBDRepository();
                TipoAccionBDRepository tabr = new TipoAccionBDRepository();
                SolicitudRepository sr = new SolicitudRepository();

                List<ObjetoBD> objetosBD = new List<ObjetoBD>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarObjetoBD", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    ObjetoBD objetoBD = new ObjetoBD();
                    objetoBD.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]), Nombre=sdr["InstanciaNombre"].ToString() };
                    objetoBD.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]), Nombre=sdr["EsquemaNombre"].ToString() };
                    objetoBD.TipoObjeto = new TipoObjetoBD { Id = Convert.ToInt32(sdr["tipoobjetobdid"]), Nombre=sdr["TipoObjeto"].ToString() };
                    objetoBD.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    objetoBD.TipoAccion = new TipoAccionBD { Id = Convert.ToInt32(sdr["tipoaccionbdid"]), Nombre=sdr["TipoAccion"].ToString() };
                    objetoBD.Nombre = sdr["nombre"].ToString();
                    objetoBD.FechaHora = Convert.ToDateTime(sdr["fechahora"]);
                    objetoBD.InformacionAdicional = sdr["informacionadicional"].ToString();
                    //objetoBD.Ruta = sdr["ruta"].ToString();
                    objetosBD.Add(objetoBD);
                }
                sdr.Close();
                /*
                objetosBD.ForEach(p =>
                {
                    p.Instancia = ir.Obtener(p.Instancia.Id);
                    p.Esquema = er.Obtener(p.Esquema.Id);
                    p.TipoObjeto = tobr.Obtener(p.TipoObjeto.Id);                    
                    p.TipoAccion = tabr.Obtener(p.TipoAccion.Id);
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                });
                */
                /*List<ObjetoBD> listaDepurada = new List<ObjetoBD>();

                string instancia = String.Empty;
                string esquema = String.Empty;
                string tipoObjeto = String.Empty;
                string tipoAccion = String.Empty;
                string nombreObjeto = String.Empty;

                foreach (ObjetoBD objeto in objetosBD)
                {
                    // Si el objeto actual es diferente del objeto anterior
                    if (objeto.Instancia.Nombre != instancia || objeto.Esquema.Nombre != esquema || objeto.TipoObjeto.Nombre != tipoObjeto || objeto.TipoAccion.Nombre != tipoAccion
                        || objeto.Nombre != nombreObjeto)
                    {
                        listaDepurada.Add(objeto);

                        instancia = objeto.Instancia.Nombre;
                        esquema = objeto.Esquema.Nombre;
                        tipoObjeto = objeto.TipoObjeto.Nombre;
                        tipoAccion = objeto.TipoAccion.Nombre;
                        nombreObjeto = objeto.Nombre;
                    }
                }
                return listaDepurada;*/
                return objetosBD;
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

        internal List<SolicitudBDCampo> ListarCampos(int proyectoId, int ambienteId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoAccionBDRepository tabr = new TipoAccionBDRepository();
                SolicitudRepository sr = new SolicitudRepository();
                List<SolicitudBDCampo> listaCampos = new List<SolicitudBDCampo>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarCampos", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    SolicitudBDCampo campo = new SolicitudBDCampo();
                    campo.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]), Nombre=sdr["InstanciaNombre"].ToString() };
                    campo.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]), Nombre=sdr["EsquemaNombre"].ToString() };
                    campo.TipoAccionBD = new TipoAccionBD { Id = Convert.ToInt32(sdr["tipoaccionbdid"]), Nombre=sdr["TipoAccion"].ToString()};
                    campo.NombreTabla = sdr["nombretabla"].ToString();
                    campo.NombreColumna = sdr["nombrecolumna"].ToString();
                    campo.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    campo.FechaHora = Convert.ToDateTime(sdr["fechahora"]);
                    campo.Tipo = sdr["tipo"].ToString();
                    listaCampos.Add(campo);
                }
                sdr.Close();
                /*listaCampos.ForEach(p =>
                {
                    p.Instancia = ir.Obtener(p.Instancia.Id);
                    p.Esquema = er.Obtener(p.Esquema.Id);
                    p.TipoAccionBD = tabr.Obtener(p.TipoAccionBD.Id);
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                });
                */
                return listaCampos;
                //throw new NotImplementedException();
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

        internal List<SolicitudBDPermisoDBU> ListarPermisosDBU(int proyectoId, int ambienteId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository tr = new TipoObjetoBDRepository();
                SolicitudRepository sr = new SolicitudRepository();
                List<SolicitudBDPermisoDBU> listaCampos = new List<SolicitudBDPermisoDBU>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarPermisosDBU", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    SolicitudBDPermisoDBU campo = new SolicitudBDPermisoDBU();
                    campo.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]) };
                    campo.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]) };
                    campo.TipoObjetoBD = new TipoObjetoBD { Id = Convert.ToInt32(sdr["tipoobjetobdid"]) };
                    campo.NombreObjeto = sdr["nombreobjeto"].ToString();
                    campo.UserDBU = sdr["permisodbu"].ToString();
                    campo.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    campo.Select = sdr["select"].ToString();
                    campo.Insert = sdr["insert"].ToString();
                    campo.Delete = sdr["delete"].ToString();
                    campo.Update = sdr["update"].ToString();
                    campo.Execute = sdr["execute"].ToString();
                    campo.FechaHora = Convert.ToDateTime(sdr["fechahora"]);
                    listaCampos.Add(campo);
                }
                sdr.Close();
                listaCampos.ForEach(p =>
                {
                    p.Instancia = ir.Obtener(p.Instancia.Id);
                    p.Esquema = er.Obtener(p.Esquema.Id);
                    p.TipoObjetoBD = tr.Obtener(p.TipoObjetoBD.Id);
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                });
                return listaCampos;
                //throw new NotImplementedException();
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

        internal List<SolicitudBDJob> ListarJosb(int proyectoId, int ambienteId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository tr = new TipoObjetoBDRepository();
                SolicitudRepository sr = new SolicitudRepository();
                List<SolicitudBDJob> listaCampos = new List<SolicitudBDJob>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarJob", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    SolicitudBDJob campo = new SolicitudBDJob();
                    campo.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]) };
                    campo.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]) };
                    campo.Nombre = sdr["nombre"].ToString();
                    campo.EjecucionInicial = sdr["ejecucioninicial"].ToString();
                    campo.InformacionAdicional = sdr["informacionadicional"].ToString();
                    campo.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    campo.Intervalo = sdr["intervalo"].ToString();
                    campo.Tipo = sdr["tipo"].ToString();
                    listaCampos.Add(campo);
                }
                sdr.Close();
                listaCampos.ForEach(p =>
                {
                    p.Instancia = ir.Obtener(p.Instancia.Id);
                    p.Esquema = er.Obtener(p.Esquema.Id);
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                });
                return listaCampos;
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

        internal List<SolicitudBDConfiguracion> ListarConfiguraciones(int proyectoId, int ambienteId)
        {
            try
            {
                InstanciaRepository ir = new InstanciaRepository();
                EsquemaRepository er = new EsquemaRepository();
                TipoObjetoBDRepository tr = new TipoObjetoBDRepository();
                SolicitudRepository sr = new SolicitudRepository();
                List<SolicitudBDConfiguracion> listaCampos = new List<SolicitudBDConfiguracion>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarConfiguracion", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    SolicitudBDConfiguracion campo = new SolicitudBDConfiguracion();
                    campo.Instancia = new Instancia { Id = Convert.ToInt32(sdr["instanciaid"]) };
                    campo.Esquema = new Esquema { Id = Convert.ToInt32(sdr["esquemaid"]) };
                    campo.Tabla = sdr["tabla"].ToString();
                    campo.Comentario = sdr["comentario"].ToString();
                    campo.Archivo = sdr["archivo"].ToString();
                    campo.Solicitud = new Solicitud { Id = Convert.ToInt32(sdr["solicitudid"]) };
                    campo.Tipo = sdr["tipo"].ToString();
                    listaCampos.Add(campo);
                }
                sdr.Close();
                listaCampos.ForEach(p =>
                {
                    p.Instancia = ir.Obtener(p.Instancia.Id);
                    p.Esquema = er.Obtener(p.Esquema.Id);
                    p.Solicitud = sr.Obtener(p.Solicitud.Id);
                });
                return listaCampos;
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

        internal List<Proyecto> ListarReversion()
        {
            try
            {
                List<Proyecto> proyectos = new List<Proyecto>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarReversion", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    Proyecto proyecto = new Proyecto();
                    proyecto.Id = Convert.ToInt32(sdr["proyectoid"]);
                    proyecto.Codigo = sdr["codigo"].ToString();
                    proyecto.Nombre = sdr["nombre"].ToString();
                    proyectos.Add(proyecto);
                }
                sdr.Close();
                return proyectos;
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

        public List<ProyectoCertificado> ListarCertificado(int proyectoId, int ambienteId)
        {
            try
            {
                ProyectoRepository pr = new ProyectoRepository();
                AmbienteRepository ar = new AmbienteRepository();
                UsuarioRepository ur = new UsuarioRepository();

                List<ProyectoCertificado> proyectoCertificados = new List<ProyectoCertificado>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarCertificado", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoId", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteId", SqlDbType.Int)).Value = ambienteId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    ProyectoCertificado pc = new ProyectoCertificado();
                    pc.Proyecto = new Proyecto { Id = Convert.ToInt32(sdr["id"]) };
                    pc.Ambiente = new Ambiente { Id = Convert.ToInt32(sdr["ambienteid"]) };
                    pc.Usuario = new Usuario { Id = Convert.ToInt32(sdr["usuarioid"]) };
                    pc.FechaHora = Convert.ToDateTime(sdr["fechahora"]);
                    pc.Certificado = Convert.ToBoolean(sdr["certificado"]);
                    proyectoCertificados.Add(pc);
                }
                proyectoCertificados.ForEach(p =>
                {
                    p.Proyecto = pr.Obtener(p.Proyecto.Id);
                    p.Ambiente = ar.Obtener(p.Ambiente.Id);
                    p.Usuario = ur.Obtener(p.Usuario.Id);
                });
                return proyectoCertificados;
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

        public void ActualizarCertificado(int proyectoId, int ambienteId, bool certificado, DateTime fechaHora, int usuarioId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_ActualizarCertificado", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                cmd.Parameters.Add(new SqlParameter("@certificado", SqlDbType.Bit)).Value = certificado;
                cmd.Parameters.Add(new SqlParameter("@fechahora", SqlDbType.DateTime)).Value = fechaHora;
                cmd.Parameters.Add(new SqlParameter("@usuarioId", SqlDbType.Int)).Value = usuarioId;
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
                {
                    Conexion.Close();
                }
            }
        }

        public List<ProyectoAmbiente> ListarFechaPases(int ambienteId, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var proyectoAmbientes = new List<ProyectoAmbiente>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarCalendarioPases", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ambienteid", SqlDbType.Int)).Value = ambienteId;
                cmd.Parameters.Add(new SqlParameter("@fechadesde", SqlDbType.DateTime)).Value = fechaDesde;
                cmd.Parameters.Add(new SqlParameter("@fechahasta", SqlDbType.DateTime)).Value = fechaHasta;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var proyectoAmbiente = new ProyectoAmbiente();
                    proyectoAmbiente.Ambiente = new Ambiente() { Id = ambienteId };
                    proyectoAmbiente.FechaPase = Convert.ToDateTime(sdr["fechaPase"]);
                    proyectoAmbiente.Proyecto = new Proyecto() { Id = Convert.ToInt32(sdr["proyectoid"]), Codigo = sdr["proyectoCodigo"].ToString(), Nombre = sdr["proyectonombre"].ToString() };
                    proyectoAmbiente.TipoEvento = (sdr["tipo"].ToString() == "Programado" ? TipoEvento.Programado : TipoEvento.Ejecutado);
                    proyectoAmbientes.Add(proyectoAmbiente);
                }
                sdr.Close();
                return proyectoAmbientes;
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

        public List<SolicitudPendiente> ListarPendientes(int proyectoId)
        {
            try
            {
                var solicitudesPendientes = new List<SolicitudPendiente>();
                SqlCommand cmd = new SqlCommand("dbo.usp_ListarSolPendientes", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@proyectoid", SqlDbType.Int)).Value = proyectoId;
                Conexion.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    var solicitudPendiente = new SolicitudPendiente();
                    solicitudPendiente.Ambiente = sdr["abreviatura"].ToString();
                    solicitudPendiente.Cantidad = Convert.ToInt32(sdr["total"]);
                    solicitudesPendientes.Add(solicitudPendiente);
                }
                sdr.Close();
                return solicitudesPendientes;
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
