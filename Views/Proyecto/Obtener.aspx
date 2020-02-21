<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ProyectoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link rel="stylesheet" href="<%=Url.Content("~/css/jquery.qtip.css") %>">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Proyecto</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosProyecto" id="frmDatosProyecto" method="post" action="<%=Url.Content("~/Proyecto/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Proyecto.Id %>" />
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" class="form-control" value="<%=Model.Proyecto.Codigo %>" maxlength="30"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombreProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtNombreProyecto" id="txtNombreProyecto" class="form-control" value="<%=Model.Proyecto.Nombre %>" maxlength="100"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPm" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">PM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtPm" id="txtPm" class="form-control" value="<%=Model.Proyecto.Pm %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPtl" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Lider Calidad:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtPtl" id="txtPtl" class="form-control" value="<%=Model.Proyecto.Ptl %>"/>
                    </div>
                </div>  
                <div class="form-group">
                    <label for="txtPtl" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Gerencia:</label>
                    <%if (!Model.UsuarioLogueado.Administrador){ %>
                    <input type="hidden" name="cboResponsable" value="<%=Model.Proyecto.Responsable!=null?Model.Proyecto.Responsable.Id.ToString():"" %>" /><%} %>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                    <select <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> id="cboResponsable" name="cboResponsable" class="form-control">
                        <option value="0"></option>
                        <%foreach (Responsable responsable in Model.Responsables){%>
                        <option <%=(Model.Proyecto.Responsable!=null && Model.Proyecto.Responsable.Id>0 && Model.Proyecto.Responsable.Id==responsable.Id)?"selected='selected'":String.Empty %> value="<%=responsable.Id %>"><%=responsable.Nombre %></option>
                        <%} %>
                    </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboTipoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tipo:</label>
                    <%if (!Model.UsuarioLogueado.Administrador){ %><input type="hidden" name="cboTipoProyecto" value="<%=Model.Proyecto.TipoProyecto.Id.ToString() %>" /><%} %>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> id="cboTipoProyecto" name="cboTipoProyecto" class="form-control">
                            <option value="0"></option>
                            <%foreach (TipoProyecto tipoProyecto in Model.TipoProyectos){%>
                            <option <%=(Model.Proyecto.TipoProyecto!=null && Model.Proyecto.TipoProyecto.Id>0 && Model.Proyecto.TipoProyecto.Id==tipoProyecto.Id)?"selected='selected'":String.Empty %> value="<%=tipoProyecto.Id %>"><%=tipoProyecto.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>   
                <div class="form-group">
                    <label for="cboEstadoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Estado:</label>
                    <%
                        StringBuilder sb = new StringBuilder();
                        if (!Model.UsuarioLogueado.Administrador)
                        {
                            sb.Append("<input type='hidden' name='cboEstadoProyecto' value='" + Model.Proyecto.Estado + "' />");
                        }
                        sb.Append("<div class='col-xs-9 col-sm-9 col-md-8 col-lg-6'><select " + (!Model.UsuarioLogueado.Administrador ? "disabled" : "") + " class='form-control' id='cboEstadoProyecto' name='cboEstadoProyecto'>");
                        sb.Append("<option value='E' "+(Model.Proyecto.Estado=='E'?"selected='selected'":"") + ">En Ejecución</option>");
                        sb.Append("<option value='C' " + (Model.Proyecto.Estado == 'C' ? "selected='selected'" : "") + ">Cerrado</option>");                    
                        sb.Append("</select></div>");
                        Response.Write(sb.ToString());
                     %>
                </div>
                <div class="form-group">
                    <div class="col-xs-offset-3 col-xs-9 col-sm-offset-2 col-sm-9 col-md-offset-3 col-md-8 col-lg-offset-2 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="checkbox" id="chkMejora" name="chkMejora" <%=Model.Proyecto.Mejora?"checked='checked'":"" %> /> 
                        Temporal

                    </div>

                </div>
                <div class="form-group impacto" <%=!Model.Proyecto.Mejora?"style='display:none;'":"" %>>
                    <label for="txtImpacto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Impacto:</label> 
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> id="txtImpacto" name="txtImpacto" class="form-control" rows="2"><%=Model.Proyecto.Impacto %></textarea>
                    </div>
                </div>
                
                <div class="form-group">
                    <label for="txtCodigoPresupuestal" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código Presupuestal:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtCodigoPresupuestal" id="txtCodigoPresupuestal" class="form-control" value="<%=Model.Proyecto.CodigoPresupuestal %>" maxlength="30"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoAlterno" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código Alterno:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" name="txtCodigoAlterno" id="txtCodigoAlterno" class="form-control" value="<%=Model.Proyecto.CodigoAlterno %>" maxlength="30"/>
                    </div>
                </div>   
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Aplicaciones</a></li>
                        <li role="presentation"><a href="#tabs-2" role="tab" data-toggle="tab">Solicitudes</a></li>
                        <li role="presentation"><a href="#tabs-3" role="tab" data-toggle="tab">Desarrolladores</a></li>
                        <li role="presentation"><a href="#tabs-4" role="tab" data-toggle="tab">Ambientes</a></li>
                        <li role="presentation"><a href="#tabs-5" role="tab" data-toggle="tab">Notificación</a></li>
                    </ul>
                    <!-- Nav Panes -->
                    <div class="tab-content">
                      <div role="tabpanel" class="tab-pane active" id="tabs-1">
                          <div class="table-responsive">
                            <table id="tblAplicaciones" class="table table-bordered table-condensed table-hover">
                            <thead>
                                <tr><th></th><th>Nombre</th><th>Ruta SVN</th><th>Herramienta</th><th>Versión</th><th>Estado</th></tr>
                            </thead>
                            <tbody>
                                <%
                                    int contador = 0;
                                    foreach (Aplicacion app in Model.Proyecto.Aplicaciones)
                                    {
                                        contador++;
                                    %>
                                      <tr>
                                      <td>
                                        <input type="hidden" name="hdId<%=contador %>" id="hdId<%=contador %>" value="<%=app.Id %>" />
                                        <input type="hidden" class="eliminadoapp" name="eliminadoapp<%=contador %>" id="eliminadoapp<%=contador %>" value="0" />
                                        <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="checkbox" class="app" name="<%=contador %>" id="<%=contador %>"/>
                                      </td>
                                      <td><input class="form-control" <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" value="<%=app.Nombre %>" name="nombreapp<%=contador %>" /></td>
                                      <td><input class="form-control" <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" value="<%=app.RutaSVN %>" name="svnapp<%=contador %>" /></td>
                                      <td><input class="form-control" <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" value="<%=app.Herramienta %>" name="ideapp<%=contador %>" /></td>
                                      <td><input class="form-control" <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="text" value="<%=app.Version %>" name="versionapp<%=contador %>" /></td>
                                      <td>
                                      <%
                                          sb.Remove(0, sb.Length);
                                          if (!Model.UsuarioLogueado.Administrador)
                                          {
                                              sb.Append("<input type='hidden' name='estadoapp" + contador.ToString() + "' value='" + app.Estado + "'>");
                                          }
                                          sb.Append("<select " + (!Model.UsuarioLogueado.Administrador ? "disabled" : "") + " class='form-control' name='estadoapp" + contador.ToString() + "'>");
                                          sb.Append("<option value='D' "+(app.Estado=='D'?"selected='selected'":"") + ">Desarrollo</option>");
                                          sb.Append("<option value='T' " + (app.Estado == 'T' ? "selected='selected'" : "") + ">Test</option>");
                                          sb.Append("<option value='P' " + (app.Estado == 'P' ? "selected='selected'" : "") + ">Produccion</option>");
                                          sb.Append("</select>");
                                          Response.Write(sb.ToString());
                                        %>
                                      </td>
                                      </tr>  
                                    <%}
                                %>
                            </tbody>
                            <tfoot>
                            </tfoot>                        
                        </table>
                          </div>
                            <%if (Model.Proyecto.Aplicaciones.Count == 0){%>
                                 <span class="mensaje">No existen registros</span>
                            <%} %>
                          <%if (Model.UsuarioLogueado.Administrador){ %>
                            <input type="button" class="btn btn-primary" value="+" id="btnAgregarAplicacion" /> <input type="button" class="btn btn-primary" value="-" id="btnQuitarAplicacion" />
                          <%} %>
                      </div>
                      <div role="tabpanel" class="tab-pane" id="tabs-2">
                        <div class="table-responsive">
                            <table class="table table-bordered table-condensed table-hover">
                                  <thead>
                                      <tr><th>Solicitud</th><th>Ambiente</th><th>Solicitado</th><th>Solicitante</th><th>Estado</th><th>Fecha Ejecución</th></tr>
                                  </thead>
                                  <tbody>
                                      <%
                                          foreach (Solicitud s in Model.Proyecto.Solicitudes)
                                          {%>
                                            <tr <%=s.Emergente?"class='danger'":"" %>>
                                                <td><a href='<%=Url.Content("~/Solicitud/Obtener/S"+s.Id.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S",s.Id.ToString().PadLeft(6,'0')) %></a></td>
                                                <td><a href="<%=Url.Content("~/Ambiente/Obtener/"+s.Ambiente.Id.ToString()) %>"><%=s.Ambiente.Nombre %></a></td>
                                                <td><%=s.FechaCreacion.ToString("dd/MM/yyyy HH:mm") %></td>
                                                <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=s.Solicitante}) %></td>                                        
                                                <td><%=s.Estado %> <%=s.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Solicitud revertida'>":String.Empty %> <%=s.FechaReversion.HasValue?"<img src='"+Url.Content("~/img/clock.png")+"' title='Tiene Fecha Reversion'>":String.Empty %></td>
                                                <td><%=s.FechaEjecucion.HasValue?s.FechaEjecucion.Value.ToString("dd/MM/yyyy HH:mm"):"" %></td>
                                            </tr>  
                                          <%} %>
                                  </tbody>
                              </table>
                          </div>
                        <p><%=Model.Proyecto.Solicitudes.Count %> Solicitudes (Se muestran sólo los 100 registros mas recientes)</p>
                      </div>
                      <div role="tabpanel" class="tab-pane" id="tabs-3">
                        <div class="table-responsive">
                             <table id="tblDesarrolladores" class="table table-bordered table-condensed table-hover">
                            <thead>
                                <tr><th></th><th>Usuario</th><th>Nombre</th><th>Correo</th></tr>
                            </thead>
                            <tbody>
                                <%
                                    contador = 0;
                                    foreach (Desarrollador des in Model.Proyecto.Desarrolladores)
                                    {
                                        contador++;
                                        string ruta = Url.Content("~/Desarrollador/Obtener/" + des.Usuario);
                                    %>
                                      <tr>
                                      <td>
                                        <input type="hidden" class="iddes" name="iddes<%=contador %>" id="iddes<%=contador %>" value="<%=des.Id %>" />
                                        <input type="hidden" class="eliminado" name="eliminadodes<%=contador %>" id="eliminadodes<%=contador %>" value="0" />
                                        <input type="hidden" class="nuevo" name="nuevo<%=contador %>" id="nuevo<%=contador %>" value="0" />
                                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" class="des" name="<%=contador %>" id="<%=contador %>"/>
                                      </td>
                                      <td><input type="hidden" name="usuariodes<%=contador %>" value="<%=des.Usuario %>"/><a href="<%=ruta %>"><span class="usuariodes"><%=des.Usuario %></span></a></td>
                                      <td><input type="hidden" class="nombredes" name="nombredes<%=contador %>" value="<%=des.Nombre %>" /><span class="nombredes"><%=des.Nombre %></span></td>                                                                    
                                      <td><input type="hidden" class="correodes" name="correodes<%=contador %>" value="<%=des.Correo %>" /><span class="correodes"><%=des.Correo %></span></td>
                                      </tr>  
                                    <%}
                                %>
                            </tbody>
                            <tfoot>
                            </tfoot>                        
                        </table>
                        </div>
                        
                          <%if (Model.UsuarioLogueado.Administrador){ %>
                        <input type="button" class="btn btn-primary" value="+" id="btnAgregarDesarrollador" /> <input type="button" class="btn btn-primary" value="-" id="btnQuitarDesarrollador" />
                          <%} %>
                      </div>
                      <div role="tabpanel" class="tab-pane" id="tabs-4">
                        <div class="table-responsive">
                            <table id="tblAmbientes" class="table table-bordered table-condensed table-hover">
                                <thead>
                                <tr><th>Ambiente</th><th>Fecha de Pase</th></tr>
                                </thead>
                                <tbody>
                                    <%
                                        if (Model.Ambientes != null)
                                        {
                                            foreach (Ambiente ambiente in Model.Ambientes)
                                            {
                                                DateTime? fechaPase = null;
                                                foreach (ProyectoAmbiente pa in Model.Proyecto.Ambientes)
                                                {
                                                    if (pa.Ambiente.Id == ambiente.Id)
                                                    {
                                                        fechaPase = pa.FechaPase;
                                                        break;
                                                    }
                                                }%>
                        
                                    <tr>
                                        <td data-ambiente="<%=ambiente.Id%>">
                                            <input <%=!Model.UsuarioLogueado.Administrador && !Model.UsuarioLogueado.Test?"disabled":"" %> data-ambiente="<%=ambiente.Nombre%>" type="checkbox" name="chkAmbiente<%=ambiente.Id%>" id="chkAmbiente<%=ambiente.Id%>" class='chkAmbiente <%=ambiente.FechaObligatoria ? "obligatorio" : String.Empty%>' <%=fechaPase.HasValue ? "checked='checked'" : String.Empty%> /> 
                                            <span <%=ambiente.FechaObligatoria ? "style='font-weight:bold;'" : String.Empty%>><%=ambiente.Nombre%></span>
                                        </td>
                                        <td><input <%=(!fechaPase.HasValue || (!Model.UsuarioLogueado.Administrador && !Model.UsuarioLogueado.Test))?"disabled='disabled'":String.Empty %> readonly="readonly" type="text" class="fecha form-control" name="txtFecha<%=ambiente.Id%>" id="txtFecha<%=ambiente.Id%>" value="<%=fechaPase.HasValue ? fechaPase.Value.ToString("dd/MM/yyyy") : String.Empty%>"/> <%=ambiente.FechaObligatoria ? "<span style='color:red;'>*</span>" : String.Empty%></td>
                                    </tr>
                                    <%}
                                        } %>
                                </tbody>
                            </table>
                        </div>
                       </div>
                        <div class="tab-pane" id="tabs-5">
                            <div class="table-responsive">
                                <table id="tblNotificacion" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr><%if(Model.UsuarioLogueado.Administrador){%> <th></th> <%}%><th>Correo</th></tr>
                                    </thead>
                                    <tbody>
                                        <%
                                        contador = 0;
                                        if (Model.Proyecto.Correos != null){
                                        foreach (var correo in Model.Proyecto.Correos)
                                        {      
                                            contador++;                                      
                                        %>
                                        <tr><%if(Model.UsuarioLogueado.Administrador){%>
                                            <td>
                                                <input type="hidden" class="hdCorreo" name="hdCorreo<%=contador %>" id="hdCorreo<%=contador %>" value="<%=correo.Id %>" />
                                                <input type="hidden" class="eliminadoCorreo" name="eliminadoCorreo<%=contador %>" id="eliminadoCorreo<%=contador %>" value="0" />
                                                <input <%=!Model.UsuarioLogueado.Administrador?"readonly":"" %> type="checkbox" class="checkCorreo" name="proyectocorreo<%=contador %>" id="proyectocorreo<%=contador %>"/>
                                            </td>
                                            <%}%>
                                            <td>
                                                <%if(Model.UsuarioLogueado.Administrador){ %>
                                                <input type="email" class="form-control correo" name="proyectocorreonombre<%=contador %>" id="proyectocorreonombre<%=contador %>" value="<%=correo.Direccion %>" />
                                                <%}else{ %>
                                                <%=correo.Direccion %>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <%} }%>
                                    </tbody>
                                </table>
                            </div>
                            <%if (Model.Proyecto.Correos==null || Model.Proyecto.Correos.Count == 0){%>
                                 <span class="mensaje">No existen registros</span>
                            <%} %>
                          <%if (Model.UsuarioLogueado.Administrador){ %>
                            <input type="button" class="btn btn-primary" value="+" id="btnAgregarProyectoCorreo" /> <input type="button" class="btn btn-primary" value="-" id="btnQuitarProyectoCorreo" />
                          <%} %>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <% if (Model.UsuarioLogueado.Administrador || Model.UsuarioLogueado.Test) { %><input type="button" class="btn btn-primary" name="btnActualizarProyecto" id="btnActualizarProyecto" value="Actualizar" /> <%} %>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %> <div class="alert alert-info"><%=Model.Mensaje %></div> <%} %>
</asp:Content>
