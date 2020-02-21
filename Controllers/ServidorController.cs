using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Repository;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;

namespace CMDBApplication.Controllers
{
    public class ServidorController : BaseController
    {
        //
        // GET: /Servidor/
        public ActionResult Index()
        {
            try
            {
                ServidorView pcv = new ServidorView();
                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                pcv.Ambientes = ambientes;
                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(ServidorView pcv)
        {
            try
            {
                string ipServidor = Request.Form["txtIpServidor"];
                string nombreServidor = Request.Form["txtNombreServidor"];
                int ambienteid = int.Parse(Request.Form["cboAmbienteServidor"]);
                string descripcion = Request.Form["txtDescripcion"];

                ServidorRepository pr = new ServidorRepository();
                List<Servidor> Servidores = pr.Listar(ipServidor, nombreServidor, ambienteid, descripcion);

                pcv.Servidor = new Servidor();
                pcv.Servidor.Ip = ipServidor;
                pcv.Servidor.Nombre = nombreServidor;
                pcv.Servidor.Ambiente = new Ambiente();
                pcv.Servidor.Ambiente.Id = ambienteid;
                pcv.Servidor.Descripcion = descripcion;

                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                pcv.Ambientes = ambientes;

                pcv.Servidores = Servidores;

                string mensaje = "";
                if (Servidores.Count == 0)
                {
                    mensaje = "No existen Servidores para el criterio de búsqueda";
                }
                pcv.Mensaje = mensaje;

                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                ServidorView pv = new ServidorView();

                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                pv.Ambientes = ambientes;

                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(ServidorView ServidorView)
        {
            try
            {
                string ipServidor = Request.Form["txtIpServidor"];
                string nombreServidor = Request.Form["txtNombreServidor"];
                int ambienteid = Request.Form["cboAmbienteServidor"] == null ? 0 : int.Parse(Request.Form["cboAmbienteServidor"]);
                string descripcion = Request.Form["txtDescripcion"];

                #region Verificar is ya existe el IP del Servidor
                ServidorRepository pr = new ServidorRepository();
                Servidor p = pr.Obtener(ipServidor.Trim());
                if (p != null)
                {
                    ServidorView.Servidor.Ip = ipServidor;
                    ServidorView.Servidor.Nombre = nombreServidor;
                    ServidorView.Servidor.Ambiente = new Ambiente();
                    ServidorView.Servidor.Ambiente.Id = ambienteid;
                    ServidorView.Servidor.Descripcion = descripcion;
                    ServidorView.Mensaje = "El IP del Servidor ya existe";
                    return View("Crear", ServidorView);
                }
                else
                {
                    p = new Servidor();
                    p.Ip = ipServidor;
                    p.Nombre = nombreServidor;
                    p.Ambiente = new Ambiente();
                    p.Ambiente.Id = ambienteid;
                    p.Descripcion = descripcion;
                    p = pr.Actualizar(p);
                    if (p.Id == 0)
                    {
                        ServidorView.Mensaje = "Hubo un error al crear el Servidor";
                        return View("Crear", ServidorView);
                    }
                    //ServidorView.Servidor = p;
                }
                #endregion
                ServidorView pp = new ServidorView();
                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                pp.Ambientes = ambientes;
                pp.Mensaje = "Servidor Creado";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                var sv = new ServidorView();
                sv.Mensaje = "";
                var sr = new ServidorRepository();
                Servidor p = sr.Obtener(id);
                sv.Servidor = p;

                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                sv.Ambientes = ambientes;
                sv.UsuarioLogueado = ObtenerUsuario();
                sv.Servidor.Usuarios = sr.ListarUsuario(sv.Servidor);
                return View("Obtener", sv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(ServidorView ServidorView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string ipServidor = Request.Form["txtIpServidor"];
                string nombreServidor = Request.Form["txtNombreServidor"];
                int ambienteid = int.Parse(Request.Form["cboAmbienteServidor"]);
                string descripcion = Request.Form["txtDescripcion"];

                Servidor p = new Servidor();
                p.Id = int.Parse(id);
                p.Ip = ipServidor;
                p.Nombre = nombreServidor;
                p.Descripcion = descripcion;
                p.Ambiente = new Ambiente();
                p.Ambiente.Id = ambienteid;

                #region Usuarios
                var prefijo = "servidorUsuarioNombre";
                var usuarios = Request.Form.AllKeys.ToList().Where(param => param.Contains(prefijo)).ToList();
                foreach (var item in usuarios)
                {
                    var indice = item.Substring(prefijo.Length);
                    var nombre = Request.Form[prefijo + indice];
                    var clave = Request.Form["servidorUsuarioClave" + indice];
                    if (!String.IsNullOrEmpty(Request.Form["hdServidorUsuario" + indice]) || Request.Form["eliminadoServidorUsuario" + indice] == "0")
                    {
                        if (p.Usuarios == null)
                        {
                            p.Usuarios = new List<Usuario>();
                        }
                        p.Usuarios.Add(new Usuario
                        {
                            Id = String.IsNullOrEmpty(Request.Form["hdServidorUsuario" + indice]) ? 0 : Convert.ToInt32(Request.Form["hdServidorUsuario" + indice]),
                            Nombre = nombre,
                            Clave = clave,
                            Eliminar = Request.Form["eliminadoServidorUsuario" + indice] == "1"
                        });
                    }
                }
                #endregion

                ServidorRepository pr = new ServidorRepository();

                p = pr.Actualizar(p);
                if (p.Id == 0)
                {
                    ServidorView.Mensaje = "Hubo un error al crear el Servidor";
                    return View("Nuevo", ServidorView);
                }

                ServidorView pp = new ServidorView();
                pp.Mensaje = "Servidor Actualizado";
                pp.Servidor = p;

                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar("");
                ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = String.Empty });

                pp.Ambientes = ambientes;
                pp.UsuarioLogueado = ObtenerUsuario();
                pp.Servidor.Usuarios = pr.ListarUsuario(pp.Servidor);
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new ServidorView { Mensaje = ex.Message });
            }
        }

    }
}
