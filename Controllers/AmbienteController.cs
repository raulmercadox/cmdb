using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.ViewModels;
using CMDBApplication.Repository;
using CMDBApplication.Models;

namespace CMDBApplication.Controllers
{
    public class AmbienteController : BaseController
    {
        //
        // GET: /Ambiente/

        public ActionResult Index()
        {
            try
            {
                AmbienteView av = new AmbienteView();
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(AmbienteView av)
        {
            try
            {
                string nombreAmbiente = Request.Form["txtNombreAmbiente"];
                bool fechaObligatoria = Request.Form["chkFechaObligatoria"] == "on";
                bool apruebaCalidad = Request.Form["chkApruebaCalidad"] == "on";
                bool envioPrimeraSolicitud = Request.Form["chkEnvioPrimeraSolicitud"] == "on";

                AmbienteRepository ar = new AmbienteRepository();
                List<Ambiente> ambientes = ar.Listar(nombreAmbiente,fechaObligatoria,apruebaCalidad,envioPrimeraSolicitud);

                av.Ambiente = new Ambiente();
                av.Ambiente.Nombre = nombreAmbiente;
                av.Ambiente.FechaObligatoria = fechaObligatoria;
                av.Ambiente.ApruebaCalidad = apruebaCalidad;
                av.Ambiente.EnvioPrimeraSolicitud = envioPrimeraSolicitud;
                av.Ambientes = ambientes;

                string mensaje = "";
                if (ambientes.Count == 0)
                {
                    mensaje = "No existen Ambientes para el criterio de búsqueda";
                }
                av.Mensaje = mensaje;

                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            try
            {
                ObservacionRepository or = new ObservacionRepository();
                List<Observacion> observaciones = or.Listar(String.Empty);

                AmbienteView av = new AmbienteView();
                av.Observaciones = observaciones;
                return View(av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(AmbienteView ambienteView)
        {
            try
            {
                string nombreAmbiente = Request.Form["txtNombreAmbiente"];
                string abreviatura = Request.Form["txtAbreviatura"];
                int orden = int.Parse(Request.Form["txtOrden"]);
                bool final = Request.Form["chkFinal"] == "on";
                bool fechaObligatoria = Request.Form["chkFechaObligatoria"] == "on";
                bool apruebaCalidad = Request.Form["chkApruebaCalidad"] == "on";
                bool envioPrimeraSolicitud = Request.Form["chkEnvioPrimeraSolicitud"] == "on";
                int observacionId = 0;
                if (Request.Form["cboObservaCalidad"] != null)
                {
                    observacionId = int.Parse(Request.Form["cboObservaCalidad"]);
                }  

                #region Verificar is ya existe el nombre del ambiente
                AmbienteRepository ar = new AmbienteRepository();
                Ambiente a = ar.Obtener(nombreAmbiente.Trim());
                if (a != null)
                {
                    ambienteView.Ambiente.Nombre = nombreAmbiente;
                    return View("Nuevo", ambienteView);
                }
                else
                {
                    a = new Ambiente();
                    a.Nombre = nombreAmbiente;
                    a.Abreviatura = abreviatura;
                    a.Orden = orden;
                    a.Final = final;
                    a.FechaObligatoria = fechaObligatoria;
                    a.ApruebaCalidad = apruebaCalidad;
                    a.EnvioPrimeraSolicitud = envioPrimeraSolicitud;
                    a.ObservaCalidad = new Observacion { Id = observacionId };
                    a = ar.Actualizar(a);
                    if (a.Id == 0)
                    {
                        ambienteView.Mensaje = "Hubo un error al crear el ambiente";
                        return View("Crear", ambienteView);
                    }
                    //proyectoView.Proyecto = p;
                }
                #endregion
                ObservacionRepository or = new ObservacionRepository();
                List<Observacion> observaciones = or.Listar(String.Empty);

                AmbienteView av = new AmbienteView();
                av.Mensaje = "Ambiente Creado";
                av.Observaciones = observaciones;
                return View("Crear", av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        public ActionResult Obtener(string id)
        {
            try
            {
                ObservacionRepository or = new ObservacionRepository();
                List<Observacion> observaciones = or.Listar(String.Empty);
                AmbienteView av = new AmbienteView();
                av.Mensaje = "";
                av.Observaciones = observaciones;
                AmbienteRepository ar = new AmbienteRepository();
                Ambiente a = ar.Obtener(int.Parse(id));
                a.Correos = ar.ListarCorreos(a.Id);
                av.Ambiente = a;
                return View("Obtener", av);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Actualizar(AmbienteView ambienteView)
        {
            try
            {
                string id = Request.Form["txtId"];
                string nombreAmbiente = Request.Form["txtNombreAmbiente"];
                string abreviatura = Request.Form["txtAbreviatura"];
                int orden = int.Parse(Request.Form["txtOrden"]);
                bool final = Request.Form["chkFinal"] == "on";
                bool fechaObligatoria = Request.Form["chkFechaObligatoria"] == "on";
                bool apruebaCalidad = Request.Form["chkApruebaCalidad"] == "on";
                bool envioPrimeraSolicitud = Request.Form["chkEnvioPrimeraSolicitud"] == "on";
                int observacionId = 0;
                if (Request.Form["cboObservaCalidad"] != null)
                {
                    observacionId = int.Parse(Request.Form["cboObservaCalidad"]);
                }                 

                Ambiente a = new Ambiente();
                a.Id = int.Parse(id);
                a.Nombre = nombreAmbiente;
                a.Abreviatura = abreviatura;
                a.Orden = orden;
                a.Final = final;
                a.FechaObligatoria = fechaObligatoria;
                a.ApruebaCalidad = apruebaCalidad;
                a.EnvioPrimeraSolicitud = envioPrimeraSolicitud;
                a.ObservaCalidad = new Observacion { Id = observacionId };

                AmbienteRepository ar = new AmbienteRepository();

                a = ar.Actualizar(a);
                if (a.Id == 0)
                {
                    ambienteView.Mensaje = "Hubo un error al actualizar el ambiente";
                    return View("Crear", ambienteView);
                }

                ar.EliminarCorreos(a.Id);

                foreach (string key in Request.Form.AllKeys)
                {
                    if (key.IndexOf("txtCorreo") >= 0)
                    {
                        // Actualizar Correo
                        int correoId = int.Parse(key.Substring("txtCorreo".Length));
                        Correo correo = new Correo();
                        correo.Direccion = Request.Form["txtCorreo" + correoId.ToString()];
                        correo.Id = correoId;
                        ar.InsertarAmbienteCorreo(correo, a.Id);
                    }
                    if (key.IndexOf("txtNuevoCorreo")>=0)
                    {
                        // Insertar Correo
                        int correoId = int.Parse(key.Substring("txtNuevoCorreo".Length));
                        Correo correo = new Correo();
                        correo.Direccion = Request.Form["txtNuevoCorreo" + correoId.ToString()];
                        correo.Id = 0;
                        ar.InsertarAmbienteCorreo(correo, a.Id);
                    }
                }

                a.Correos = ar.ListarCorreos(a.Id);

                ObservacionRepository or = new ObservacionRepository();
                List<Observacion> observaciones = or.Listar(String.Empty);
                AmbienteView pp = new AmbienteView();
                pp.Mensaje = "Ambiente Actualizado";
                pp.Ambiente = a;
                pp.Observaciones = observaciones;
                return View("Obtener", pp);
            }
            catch (Exception ex)
            {
                return View("Mensaje", new AmbienteView { Mensaje = ex.Message });
            }
        }
    }
}
