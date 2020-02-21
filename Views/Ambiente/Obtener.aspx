<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AmbienteView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Ambiente</h3>
        </div>
        <div class="panel-body">
            <form class="form-horizontal" name="frmDatosAmbiente" id="frmDatosAmbiente" method="post" action="<%=Url.Content("~/Ambiente/Actualizar") %>">
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
                                <input type="checkbox" name="chkFinal" id="chkFinal" aria-label="Ambiente Final" <%=Model.Ambiente.Final?"checked='checked'":String.Empty %> />
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
                        <select class="form-control" id="cboObservaCalidad" name="cboObservaCalidad" <%=!Model.Ambiente.ApruebaCalidad?"disabled":"" %>>
                        <option value="0" <%=Model.Ambiente.ObservaCalidad.Id==0?"selected":"" %>></option>
                        <%                             
                            foreach (Observacion observacion in Model.Observaciones)
                            {%>
                              <option value="<%=observacion.Id %>" <%=Model.Ambiente.ObservaCalidad.Id==observacion.Id?"selected":"" %>><%=observacion.Nombre %></option>  
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
                                <input type="checkbox" name="chkEnvioPrimeraSolicitud" id="chkEnvioPrimeraSolicitud" <%=Model.Ambiente.EnvioPrimeraSolicitud?"checked":"" %> aria-label="Envio 1ra Solicitud" />
                                Se envía correo de la 1ra solicitud a Calidad.
                            </label>
                        </div>
                    </div>
                </div>
                <div>
                    <!-- Nav tabs -->
                    <ul id="tabsbootstrap" class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#servidores" aria-controls="servidores" role="tab" data-toggle="tab">Servidores</a></li>
                        <li role="presentation"><a href="#instanciasbd" aria-controls="instancias bd" role="tab"  data-toggle="tab">Instancias BD</a></li>
                        <li role="presentation"><a href="#envioejecutor" aria-controls="envio ejecutor" role="tab"  data-toggle="tab">Envío al Ejecutor</a></li>
                    </ul>

                    <!-- Nav panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="servidores">
                            <div class="row">
                            	<div class="col-xs-12">
                                    <%if (Model.Ambiente.Servidores==null || Model.Ambiente.Servidores.Count == 0){%>
                                 <div class="alert alert-danger" role="alert">
                                     <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                     No existen registros
                                 </div>
                            <%}else{ %>   
                                <table id="tblServidores" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr><th>IP</th><th>Nombre</th></tr>
                                    </thead>
                                    <tbody>
                                        <%
                                            int contador = 0;
                                            if (Model.Ambiente.Servidores!=null)
                                            {
                                                foreach (Servidor app in Model.Ambiente.Servidores)
                                                {
                                                    contador++;
                                                    string ruta = Url.Content("~/Servidor/Obtener/" + app.Ip);
                                                %>
                                                  <tr>                                  
                                                  <td><a class="btn btn-link" href="<%=ruta%>"><%=app.Ip %></a></td>
                                                  <td><%=app.Nombre %></td>                                  
                                                  </tr>  
                                                <%}
                                            }
                                        %>
                                    </tbody>
                                </table> 
                            <%} %>
                            	</div>
                            </div>                            
                        </div>
                        <div role="tabpanel" class="tab-pane" id="instanciasbd">
                            <div class="row">
                            	<div class="col-xs-12">
                                    <%if (Model.Ambiente.Instancias==null || Model.Ambiente.Instancias.Count == 0){%>
                                        <div class="alert alert-danger" role="alert">
                                             <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                             No existen registros
                                         </div>
                                    <%}else{ %>
                                        <table id="tblInstancias" class="table table-bordered table-condensed table-hover">
                                            <thead>
                                                <tr><th>Nombre</th><th>Servidor</th></tr>
                                            </thead>
                                            <tbody>
                                                <%
                                                    int contador2 = 0;
                                                    if (Model.Ambiente.Instancias != null)
                                                    {
                                                        foreach (Instancia app in Model.Ambiente.Instancias)
                                                        {
                                                            contador2++;
                                                            string rutaInstancia = Url.Content("~/Instancia/Obtener/" + app.Nombre);
                                                            string rutaServidor = Url.Content("~/Servidor/Obtener/" + app.Servidor.Ip);
                                                    %>
                                                      <tr>                                  
                                                      <td><a class="btn btn-link" href="<%=rutaInstancia%>"><%=app.Nombre%></a></td>
                                                      <td><a class="btn btn-link" href="<%=rutaServidor%>"><%=app.Servidor.Ip%></a> (<%=app.Servidor.Nombre%>)</td>                                  
                                                      </tr>  
                                                    <%}
                                                    }
                                                %>
                                            </tbody>
                                        </table>
                                    <%} %>
                            	</div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="envioejecutor">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5>Especificar los correos que se enviarán con copia oculta cuando se env&iacute;en los pases al ejecutor:</h5>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <table id="tablaCorreos" class="table table-bordered table-condensed table-hover">
                                        <thead>
                                            <tr><th></th><th>Correo</th></tr>
                                        </thead>
                                        <tbody>
                                            <%if(Model.Ambiente.Correos!=null)
                                              {
                                                foreach (Correo correo in Model.Ambiente.Correos)
                                              {%>
                                                <tr><td><input type="checkbox" class='quitarCorreo' id="chkCorreo<%=correo.Id %>" name="chkCorreo<%=correo.Id %>" /></td><td><input type="text" class="correoAmbiente form-control" style="width:100%;" id="txtCorreo<%=correo.Id %>" name="txtCorreo<%=correo.Id %>" value="<%=correo.Direccion %>"/></td></tr>
                                              <%} }%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-xs-12">
                                <input type="button" class="btn btn-primary" id="btnAgregarAmbienteCorreo" name="btnAgregarAmbienteCorreo" value="+"/> <input type="button" class="btn btn-primary" id="btnQuitarAmbienteCorreo" name="btnQuitarAmbienteCorreo" value="-"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarAmbiente" id="btnActualizarAmbiente" value="Actualizar" />
        </div>
    </div>
    <%if(!String.IsNullOrEmpty(Model.Mensaje)){ %>
        <div class="alert alert-info .alert-dismissible" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <%=Model.Mensaje %>
        </div>
    <%} %>
</asp:Content>
