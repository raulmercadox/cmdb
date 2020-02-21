<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Solicitudes</h3>
        </div>
        <div class="panel-body">
            <div id="dialog-message" title="Informacion" style="font-size:small">
            </div>
            <form name="frmCatalogoSolicitud" id="frmCatalogoSolicitud" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtCodigoSolicitud" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoSolicitud" id="txtCodigoSolicitud" class="form-control" value="<%=Model.Solicitud.Codigo %>" />
                    </div>
                </div>                
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                        <% foreach (Ambiente ambiente in Model.Ambientes)
                           {%>
                              <option value="<%=ambiente.Id %>" <%=ambiente.Id==Model.Solicitud.Ambiente.Id?"selected='selected'":"" %>><%=ambiente.Nombre%></option>
                          <%}%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Proyecto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" value="<%=Model.Solicitud.Proyecto.Codigo %>" class="form-control codigoproyecto" maxlength="30"/> 
                        <label id="lblDescripcionProyecto"><%=Model.Solicitud.Proyecto.Nombre %></label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtSolicitante" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Solicitante:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtSolicitante" id="txtSolicitante" class="form-control" value="<%=Model.Solicitud.Solicitante.Nombre %>" maxlength="30" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaDesarrollo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Desarrollo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAnalistaDesarrollo" id="txtAnalistaDesarrollo" class="form-control" value="<%=Model.Solicitud.AnalistaDesarrollo %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaTestProd" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Test/Prod:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAnalistaTestProd" id="txtAnalistaTestProd" class="form-control" value="<%=Model.Solicitud.AnalistaTestProd %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtRfc" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">RFC:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtRfc" id="txtRfc" class="form-control" value="<%=Model.Solicitud.RFC %>" maxlength="10"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Emergente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEmergente" id="chkEmergente" <%=Model.Solicitud.Emergente?"checked":"" %> />
                                Marcar cuando la solicitud sea emergente
                            </label>
                        </div>
                    </div>
                </div>      
                <div class="form-group razonemergente" <%=!Model.Solicitud.Emergente?"style='display:none;'":"" %>>
                    <label for="txtRazonEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Razón del Emergente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtRazonEmergente" id="txtRazonEmergente" class="form-control" maxlength="200" rows="5"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkFechas" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha de Solicitud:</label> 
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFechas" id="chkFechas" <%=Model.FechaDesde.HasValue?"checked=":"" %>/> 
                                Marcar cuando se necesite especificar un rango de fechas del registro de la solicitud.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaDesde" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Desde:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtFechaDesde" id="txtFechaDesde" class="fecha form-control" <%=Model.FechaDesde.HasValue?"":"disabled" %> value="<%=Model.FechaDesde.HasValue?Model.FechaDesde.Value.ToString("dd/MM/yyyy"):"" %>"/> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaHasta" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hasta:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtFechaHasta" id="txtFechaHasta" class="fecha form-control" <%=Model.FechaDesde.HasValue?"":"disabled" %> value="<%=Model.FechaHasta.HasValue?Model.FechaHasta.Value.ToString("dd/MM/yyyy"):"" %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkPrincipal" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Principal:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkPrincipal" id="chkPrincipal" <%=Model.Solicitud.Principal?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkAdicional" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Adicional:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkAdicional" id="chkAdicional" <%=Model.Solicitud.Adicional?"checked='checked'":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkFechas" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha de Ejecución:</label> 
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFechaEjecucion" id="chkFechaEjecucion" <%=Model.FechaEjecucionDesde.HasValue?"checked=":"" %>/> 
                                Marcar cuando se necesite especificar un rango de fechas de la ejecución de la solicitud.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaEjecucionDesde" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Desde:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtFechaEjecucionDesde" id="txtFechaEjecucionDesde" class="fecha form-control" <%=Model.FechaEjecucionDesde.HasValue?"":"disabled" %> value="<%=Model.FechaEjecucionDesde.HasValue?Model.FechaEjecucionDesde.Value.ToString("dd/MM/yyyy"):"" %>"/> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaEjecucionHasta" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hasta:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtFechaEjecucionHasta" id="txtFechaEjecucionHasta" class="fecha form-control" <%=Model.FechaEjecucionDesde.HasValue?"":"disabled" %> value="<%=Model.FechaEjecucionHasta.HasValue?Model.FechaEjecucionHasta.Value.ToString("dd/MM/yyyy"):"" %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarSolicitud" id="btnConsultarSolicitud" value="Consultar" />
        </div>
    </div>
    <%if (Model.Solicitudes.Count > 0){%>
                    <%foreach(Solicitud s in Model.Solicitudes){ %>
                    <%=Html.Partial("ListaConflicto", new SolicitudView {Solicitud=s })%>
                    <%} %>
                <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr><th>Nro. Solicitud</th><th>Fecha y Hora</th><th>Proyecto</th><th>Ambiente</th><th>Solicitante</th><th>Archivos</th><th>Estado</th></tr>
                </thead>
                <tbody>
                    
                    <%foreach (Solicitud s in Model.Solicitudes)
                      { %>
                      <tr <%=s.Emergente?"class='danger'":"" %>><% string url = Url.Content("~/Home/ObtenerArchivo/S"+s.Id.ToString().PadLeft(6,'0')+"-");%>
                            <td>
                                
                                <a href='<%=Url.Content("~/Solicitud/Obtener/S"+s.Id.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S",s.Id.ToString().PadLeft(6,'0')) %></a>                            
                            </td>
                            <td><%=s.FechaCreacion.ToString("dd/MM/yyyy HH:mm") %></td>
                            <td><a href="<%=Url.Content("~/Proyecto/Obtener/"+s.Proyecto.Codigo) %>"><%=s.Proyecto.Codigo %></a> - <%=s.Proyecto.Nombre %></td>
                            <td><a href="<%=Url.Content("~/Ambiente/Obtener/"+s.Ambiente.Id) %>"><%=s.Ambiente.Nombre %></a></td>
                            <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=s.Solicitante}) %></td>
                            <td>
                                <%for (var i = 1; i <= 10; i++)
                                  {
                                      Archivo archivo = i == 1 ? s.Archivo1 : i == 2 ? s.Archivo2 : i == 3 ? s.Archivo3 : i == 4 ? s.Archivo4 : i == 5 ? s.Archivo5 : i == 6 ?
                                      s.Archivo6 : i == 7 ? s.Archivo7 : i == 8 ? s.Archivo8 : i == 9 ? s.Archivo9 : i == 10 ? s.Archivo10 : null;
                                      %>
                                        <%if (!String.IsNullOrEmpty(archivo.Nombre)){ %>  
                                        <div class="archivo">                      
                                        <a href='<%=String.Concat(url,i.ToString())%>'><%=archivo.Nombre %></a> <%=Html.Partial("ImagenValidacion", new ArchivoView() {Archivo = archivo,Indicador = i,SolicitudId=s.Id}) %>
                                        </div>
                                        <%} %>
                                        
                                 <% } %>
                          </td>
                          <td><%=s.Estado%> <%=s.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Solicitud revertida'>":String.Empty %> <%=s.FechaReversion.HasValue?"<img src='"+Url.Content("~/img/clock.png")+"' title='Tiene Fecha Reversion'>":String.Empty %></td>
                      </tr>
                    <%} %>
                </tbody>
                </table>
                </div>
            <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
