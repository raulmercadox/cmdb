using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMDBApplication.Models;
using CMDBApplication.ViewModels;
using CMDBApplication.Repository;

namespace CMDBApplication.Controllers
{
    public class ObjetoController : BaseController
    {
        public ActionResult Buscar()
        {
            try
            {
                var objetoView = new ObjetoView();
                return View(objetoView);
            }
            catch (Exception ex)
            {
                var sv = new ObjetoView();
                sv.Mensaje = ex.Message;
                return View("Mensaje", sv);
            }
        }

        [HttpPost]
        public ActionResult BuscarBD()
        {
            try
            {
                var nombreObjeto = Request.Form["txtNombre"];
                var obdr = new ObjetoBDRepository();
                var listaObjetosBD = obdr.Listar(nombreObjeto);
                var objetoView = new ObjetoView();
                objetoView.NombreObjeto = nombreObjeto;
                objetoView.TipoObjeto = "1";
                objetoView.ObjetosBD = listaObjetosBD;
                return View("Buscar", objetoView);
            }
            catch (Exception ex)
            {
                var sv = new ObjetoView();
                sv.Mensaje = ex.Message;
                return View("Mensaje", sv);
            }
        }

        [HttpPost]
        public ActionResult BuscarCRMApp()
        {
            try
            {
                var nombreObjeto = Request.Form["txtNombre"];
                var obdr = new SolicitudCRMWPAppRepository();
                var listaObjetos = obdr.Listar(nombreObjeto);
                var objetoView = new ObjetoView();
                objetoView.NombreObjeto = nombreObjeto;
                objetoView.TipoObjeto = "2";
                objetoView.CRMApps = listaObjetos;
                return View("Buscar", objetoView);
            }
            catch (Exception ex)
            {
                var sv = new ObjetoView();
                sv.Mensaje = ex.Message;
                return View("Mensaje", sv);
            }
        }
    }
}
