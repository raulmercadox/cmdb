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
    public class InstanciaController : BaseController
    {
        //
        // GET: /Instancia/

        public ActionResult Index()
        {
            try
            {
                InstanciaView pcv = new InstanciaView();

                pcv.Servidores = new ServidorRepository().Listar("", "", 0);
                pcv.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pcv.Ambientes = new AmbienteRepository().Listar("");
                pcv.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(InstanciaView pcv)
        {
            try
            {
                string nombreInstancia = Request.Form["txtNombreInstancia"];
                int servidorId = int.Parse(Request.Form["cboServidor"]);
                int ambienteId = int.Parse(Request.Form["cboAmbiente"]);

                InstanciaRepository pr = new InstanciaRepository();

                List<Instancia> Instancias = pr.Listar(nombreInstancia, servidorId, ambienteId);

                pcv.Instancia = new Instancia();
                pcv.Instancia.Nombre = nombreInstancia;
                pcv.Instancia.Servidor = new ServidorRepository().Obtener(servidorId);
                pcv.Instancia.Ambiente = new AmbienteRepository().Obtener(ambienteId);

                pcv.Servidores = new ServidorRepository().Listar("", "", 0);
                pcv.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pcv.Ambientes = new AmbienteRepository().Listar("");
                pcv.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                pcv.Instancias = Instancias;

                string mensaje = "";
                if (Instancias.Count == 0)
                {
                    mensaje = "No existen Instancias para el criterio de búsqueda";
                }
                pcv.Mensaje = mensaje;

                return View(pcv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                InstanciaView pv = new InstanciaView();

                pv.Servidores = new ServidorRepository().Listar("", "", 0);
                pv.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pv.Ambientes = new AmbienteRepository().Listar("");
                pv.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                pv.Instancias = new InstanciaRepository().Listar("", 0, 0);

                return View(pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(InstanciaView InstanciaView)
        {
            try
            {
                string nombreInstancia = Request.Form["txtNombreInstancia"];
                int servidorId = int.Parse(Request.Form["cboServidor"]);
                int ambienteId = int.Parse(Request.Form["cboAmbiente"]);
                int instanciaAnterior = int.Parse(Request.Form["cboInstanciaAnt"]);
                string repositorioSubversion = Request.Form["txtRepoSubversion"];

                #region Verificar is ya existe el código del Instancia
                InstanciaRepository pr = new InstanciaRepository();
                Instancia p = pr.Obtener(nombreInstancia.Trim());
                if (p != null)
                {
                    InstanciaView.Instancia.Nombre = nombreInstancia;
                    InstanciaView.Instancia.Servidor = new ServidorRepository().Obtener(servidorId);
                    InstanciaView.Instancia.Ambiente = new AmbienteRepository().Obtener(ambienteId);
                    InstanciaView.Mensaje = "El nombre del Instancia ya existe";
                    return View("Crear", InstanciaView);
                }
                else
                {
                    p = new Instancia();
                    p.Nombre = nombreInstancia;
                    p.Ambiente = new Ambiente() { Id = ambienteId };
                    p.Servidor = new Servidor() { Id = servidorId };
                    p.InstanciaAnterior = instanciaAnterior == 0 ? null : new InstanciaRepository().Obtener(instanciaAnterior);                    
                    p.RepositorioSubversion = repositorioSubversion;
                    
                    p = pr.Actualizar(p);
                    if (p.Id == 0)
                    {
                        InstanciaView.Mensaje = "Hubo un error al crear el Instancia";
                        return View("Crear", InstanciaView);
                    }
                }
                #endregion
                InstanciaView pp = new InstanciaView();

                pp.Servidores = new ServidorRepository().Listar("", "", 0);
                pp.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pp.Ambientes = new AmbienteRepository().Listar("");
                pp.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                pp.Mensaje = "Instancia Creada";
                return View("Crear", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                InstanciaView pv = new InstanciaView();
                pv.Mensaje = "";
                InstanciaRepository pr = new InstanciaRepository();

                Instancia p = pr.Obtener(id);
                if (p.InstanciaAnterior!=null)
                    p.InstanciaAnterior = pr.Obtener(p.InstanciaAnterior.Id);

                pv.Instancia = p;

                pv.Servidores = new ServidorRepository().Listar("", "", 0);
                pv.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pv.Ambientes = new AmbienteRepository().Listar("");
                pv.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                pv.Instancias = new InstanciaRepository().Listar("", 0, 0);

                return View("Obtener", pv);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(InstanciaView InstanciaView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreInstancia = Request.Form["txtNombreInstancia"];
                int servidorId = int.Parse(Request.Form["cboServidor"]);
                int ambienteId = int.Parse(Request.Form["cboAmbiente"]);
                int instanciaAnterior = int.Parse(Request.Form["cboInstanciaAnt"]);                
                string repositorioSubversion = Request.Form["txtRepoSubversion"];

                Instancia p = new Instancia();
                p.Id = int.Parse(id);
                p.Nombre = nombreInstancia;
                p.Servidor = new Servidor() { Id = servidorId };
                p.Ambiente = new Ambiente() { Id = ambienteId };
                p.InstanciaAnterior = instanciaAnterior == 0 ? null : new InstanciaRepository().Obtener(instanciaAnterior);                
                p.RepositorioSubversion = repositorioSubversion;

                // Esquemas
                p.Esquemas = new List<Esquema>();
                List<string> nombres = Request.Form.AllKeys.ToList().Where(param => param.Contains("nombreesquema")).ToList();
                foreach (string nombre in nombres)
                {
                    string indice = nombre.Substring("nombreesquema".Length);
                    string nombreEsquema = Request.Form["nombreesquema" + indice];

                    if (!String.IsNullOrEmpty(Request.Form["idesquema" + indice]) || Request.Form["eliminadoesquema" + indice] == "0")
                    {
                        p.Esquemas.Add(new Esquema
                        {
                            Id = String.IsNullOrEmpty(Request.Form["idesquema" + indice]) ? 0 : Convert.ToInt32(Request.Form["idesquema" + indice]),
                            Nombre = nombreEsquema,
                            Eliminar = Request.Form["eliminadoesquema" + indice] == "1"
                        });
                    }
                }

                InstanciaRepository pr = new InstanciaRepository();

                p = pr.Actualizar(p);
                if (p.Id == 0)
                {
                    InstanciaView.Mensaje = "Hubo un error al crear el Instancia";
                    return View("Crear", InstanciaView);
                }

                InstanciaView pp = new InstanciaView();
                pp.Mensaje = "Instancia Actualizada";
                pp.Instancia = p;
                pp.Instancias = new InstanciaRepository().Listar("", 0, 0);

                pp.Servidores = new ServidorRepository().Listar("", "", 0);
                pp.Servidores.Insert(0, new Servidor() { Id = 0, Nombre = "" });

                pp.Ambientes = new AmbienteRepository().Listar("");
                pp.Ambientes.Insert(0, new Ambiente() { Id = 0, Nombre = "" });

                

                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Eliminar(string id)
        {
            try
            {
                //string id = Request.Form["txtId"];
                
                InstanciaRepository pr = new InstanciaRepository();

                bool rsta = pr.Eliminar(int.Parse(id));
                if (!rsta)
                {
                    InstanciaView iv = new InstanciaView();
                    iv.Mensaje = "Hubo un error al eliminar la instancia.";
                    return View("Mensaje", iv);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Mensaje", new InstanciaView { Mensaje = ex.Message });
            }
        }

    }
}
