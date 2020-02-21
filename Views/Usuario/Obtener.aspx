<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Usuario</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosUsuario" id="frmDatosUsuario" method="post" action="<%=Url.Content("~/Usuario/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Usuario.Id %>" />
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="text" name="txtUsuarioUsuario" id="txtUsuarioUsuario" class="form-control" value="<%=Model.Usuario.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCorreoUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="text" name="txtCorreoUsuario" id="txtCorreoUsuario" class="form-control" value="<%=Model.Usuario.Correo %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCelular" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Celular:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="text" name="txtCelular" id="txtCelular" class="form-control" value="<%=Model.Usuario.Celular %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAnexo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Anexo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="text" name="txtAnexo" id="txtAnexo" class="form-control" value="<%=Model.Usuario.Anexo %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtSkype" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Skype:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="text" name="txtSkype" id="txtSkype" class="form-control" value="<%=Model.Usuario.Skype %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkAdministradorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Administrador:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkAdministradorUsuario" id="chkAdministradorUsuario" <%=Model.Usuario.Administrador?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkOperadorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Operador:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkOperadorUsuario" id="chkOperadorUsuario" <%=Model.Usuario.Operador?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkLectorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Lector:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkLectorUsuario" id="chkLectorUsuario" <%=Model.Usuario.Lector?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkCMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">CM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkCMUsuario" id="chkCMUsuario" <%=Model.Usuario.CM?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkRMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">RM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkRMUsuario" id="chkRMUsuario" <%=Model.Usuario.RM?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEjecutorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ejecutor:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkEjecutorUsuario" id="chkEjecutorUsuario" <%=Model.Usuario.Ejecutor?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkTestUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">QA:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input <%=!Model.UsuarioLogueado.Administrador?"disabled":"" %> type="checkbox" name="chkTestUsuario" id="chkTestUsuario" <%=Model.Usuario.Test?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>

                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Solicitudes</a></li>
                    </ul>
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="tabs-1">
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th>Solicitud</th>
                                        <th>Proyecto</th>
                                        <th>Ambiente</th>
                                        <th>Solicitado</th>
                                        <th>Estado</th>
                                        <th>Fecha de Ejecución</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        foreach (Solicitud s in Model.Usuario.Solicitudes)
                                        {%>
                                    <tr>
                                        <td <%=s.Emergente?"class='danger'":"" %>><a href='<%=Url.Content("~/Solicitud/Obtener/S"+s.Id.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S",s.Id.ToString().PadLeft(6,'0')) %></a></td>
                                        <td <%=s.Emergente?"class='danger'":"" %>><a href="<%=Url.Content("~/Proyecto/Obtener/"+s.Proyecto.Codigo) %>"><%=s.Proyecto.Codigo%></a> - <%=s.Proyecto.Nombre%></td>
                                        <td <%=s.Emergente?"class='danger'":"" %>><a href="<%=Url.Content("~/Ambiente/Obtener/"+s.Ambiente.Id) %>"><%=s.Ambiente.Nombre %></a></td>
                                        <td <%=s.Emergente?"class='danger'":"" %>><%=s.FechaCreacion.ToString("dd/MM/yyyy HH:mm") %></td>
                                        <td <%=s.Emergente?"class='danger'":"" %>><%=s.Estado %></td>
                                        <td <%=s.Emergente?"class='danger'":"" %>><%=s.FechaEjecucion.HasValue?s.FechaEjecucion.Value.ToString("dd/MM/yyyy HH:mm"):"" %></td>
                                    </tr>
                                    <%} %>
                                </tbody>
                            </table>
                            </div>
                            <p><%=Model.Usuario.Solicitudes.Count %> Solicitudes (Se muestran sólo los 100 registros mas recientes)</p>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <% if (Model.UsuarioLogueado.Administrador){ %>
            <input type="button" class="btn btn-primary" name="btnActualizarUsuario" id="btnActualizarUsuario" value="Actualizar" />
            <%}%>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
