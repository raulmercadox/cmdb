<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AmbienteView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
         <div class="panel-heading">
             <h3 class="panel-title">Crear Ambiente</h3>
         </div>
         <div class="panel-body">
             <form name="frmNuevoAmbiente" id="frmNuevoAmbiente" method="post" action="<%=Url.Content("~/Ambiente/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Ambiente.Id %>" />   
                 <div class="form-group">
                     <label for="txtNombreAmbiente" class="col-xs-2 col-sm-2 col-lg-1 control-label">Nombre:</label>
                     <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                         <input class="form-control" placeholder="Nombre del Ambiente" type="text" name="txtNombreAmbiente" id="txtNombreAmbiente" value="<%=Model.Ambiente.Nombre %>" autofocus/>
                     </div>
                 </div>
                <div class="form-group">
                    <label for="txtAbreviatura" class="col-xs-2 col-sm-2 col-lg-1 control-label">Abreviatura:</label>
                    <div class="col-xs-7 col-sm-6 col-md-5 col-lg-3">
                        <input class="form-control" placeholder="Abreviatura" type="text" name="txtAbreviatura" id="txtAbreviatura" value="<%=Model.Ambiente.Abreviatura %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkFinal" class="col-xs-2 col-sm-2 col-lg-1 control-label">Final:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFinal" id="chkFinal" aria-label="Ambiente Final" value="<%=Model.Ambiente.Final %>" />
                                Marcar cuando este ambiente es el final (p.ej. producción)
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtOrden" class="col-xs-2 col-sm-2 col-lg-1 control-label">Orden:</label>
                    <div class="col-xs-7 col-sm-6 col-md-5 col-lg-3">
                        <input class="form-control"  type="number" name="txtOrden" id="txtOrden" value="<%=Model.Ambiente.Orden %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkFechaObligatoria" class="col-xs-2 col-sm-2 col-lg-1 control-label">Fecha de Pase:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFechaObligatoria" id="chkFechaObligatoria" <%=Model.Ambiente.FechaObligatoria?"checked='checked'":String.Empty %> aria-label="Fecha de Pase"/> 
                                Los proyectos deberán especificar una fecha de pase para este ambiente.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkApruebaCalidad" class="col-xs-2 col-sm-2 col-lg-1 control-label">Aprueba Calidad:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkApruebaCalidad" id="chkApruebaCalidad" <%=Model.Ambiente.ApruebaCalidad?"checked='checked'":String.Empty %> aria-label="Aprueba Calidad"/>
                                Las primeras solicitudes que sean de este ambiente se observarán si su proyecto no tiene fecha de pase.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboObservaCalidad" class="col-xs-2 col-sm-2 col-lg-1 control-label">Observa Calidad:</label>
                    <div class="col-xs-7 col-sm-6 col-md-5 col-lg-3">
                        <select id="cboObservaCalidad" name="cboObservaCalidad" <%=!Model.Ambiente.ApruebaCalidad?"disabled":"" %> class="form-control">
                            <option value="0"></option>
                            <%                             
                            foreach (Observacion observacion in Model.Observaciones)
                            {%>
                              <option value="<%=observacion.Id %>"><%=observacion.Nombre %></option>  
                            <%}
                            %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEnvioPrimeraSolicitud" class="col-xs-2 col-sm-2 col-lg-1 control-label">Envio 1ra Solicitud:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEnvioPrimeraSolicitud" id="chkEnvioPrimeraSolicitud" <%=Model.Ambiente.EnvioPrimeraSolicitud?"checked='checked'":String.Empty %> aria-label="Envio 1ra Solicitud" />
                                Se envía correo de la 1ra solicitud a Calidad.
                            </label>
                        </div>
                    </div>
                </div>
            </form>
         </div>
         <div class="panel-footer">
             <input type="button" class="btn btn-primary" name="btnCrearAmbiente" id="btnCrearAmbiente" value="Crear" />
         </div>
     </div>
    <%if(!String.IsNullOrEmpty(Model.Mensaje)){ %>
        <div class="alert alert-info" role="alert"><%=Model.Mensaje %></div>
    <%} %>
    
</asp:Content>
