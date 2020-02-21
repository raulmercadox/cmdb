<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ServidorView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Servidor</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosServidor" id="frmDatosServidor" method="post" action="<%=Url.Content("~/Servidor/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Servidor.Id %>" />
                <div class="form-group">
                    <label for="txtIpServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">IP:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtIpServidor" id="txtIpServidor" class="form-control" value="<%=Model.Servidor.Ip %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombreServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreServidor" id="txtNombreServidor" class="form-control" value="<%=Model.Servidor.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtDescripcion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Descripción:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea id="txtDescripcion" name="txtDescripcion" class="form-control" rows="5"><%=Model.Servidor.Descripcion %></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <label for="cboAmbienteServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbienteServidor" name="cboAmbienteServidor">
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                               {
                                   if (ambiente.Id == Model.Servidor.Ambiente.Id)
                                   {%>
                            <option value="<%=ambiente.Id %>" selected="selected"><%=ambiente.Nombre%></option>
                            <%}
                               else
                               { %>
                            <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                            <%}
                           }%>
                        </select>
                    </div>
                </div>
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Instancias BD</a></li>
                        <li role="presentation" ><a href="#tabs-2" role="tab" data-toggle="tab">Usuarios</a></li>
                    </ul>
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="tabs-1">
                            <div class="table-responsive">
                                <table id="tblInstancias" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr>
                                            <th>Nombre</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%
                                            int contador = 0;
                                            if (Model.Servidor.Instancias != null)
                                            {
                                                foreach (Instancia app in Model.Servidor.Instancias)
                                                {
                                                    contador++;
                                                    string ruta = Url.Content("~/Instancia/Obtener/" + app.Nombre);
                                        %>
                                        <tr>
                                            <td><a href="<%=ruta %>"><%=app.Nombre %></a></td>
                                        </tr>
                                        <%}
                                    }
                                        %>
                                    </tbody>
                                    <tfoot>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabs-2">
                            <div class="table-responsive">
                                <table id="tblServidorUsuario" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr><%if(Model.UsuarioLogueado.Administrador){%> <th></th> <%}%><th>Usuario</th><th>Clave</th></tr>
                                    </thead>
                                    <tbody>
                                        <%
                                        contador = 0;
                                        if (Model.Servidor.Usuarios != null)
                                        {
                                            foreach (var usuario in Model.Servidor.Usuarios)
                                            {
                                                contador++;                                      
                                        %>
                                        <tr>
                                            <%if (Model.UsuarioLogueado.Administrador)
                                              {%>
                                            <td>
                                                <input type="hidden" class="hdServidorUsuario" name="hdServidorUsuario<%=contador%>" id="hdServidorUsuario<%=contador%>" value="<%=usuario.Id%>" />
                                                <input type="hidden" class="eliminadoServidorUsuario" name="eliminadoServidorUsuario<%=contador%>" id="eliminadoServidorUsuario<%=contador%>" value="0" />
                                                <input <%=!Model.UsuarioLogueado.Administrador ? "readonly" : ""%> type="checkbox" class="checkServidorUsuario" name="servidorUsuario<%=contador%>" id="servidorUsuario<%=contador%>"/>
                                            </td>
                                            <%}%>
                                            <td>
                                                <%if (Model.UsuarioLogueado.Administrador)
                                                  { %>
                                                <input type="text" class="form-control usuario" name="servidorUsuarioNombre<%=contador%>" value="<%=usuario.Nombre%>" />
                                                <%}
                                                  else
                                                  { %>
                                                <%=usuario.Nombre%>
                                                <%} %>
                                            </td>
                                            <td>
                                                <%if (Model.UsuarioLogueado.Administrador)
                                                  { %>
                                                <input type="text" class="form-control clave" name="servidorUsuarioClave<%=contador%>" value="<%=usuario.Clave%>" />
                                                <%}
                                                  else
                                                  { %>
                                                <%=usuario.Clave%>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <%}
                                        } %>
                                    </tbody>
                                    <tfoot>
                                    </tfoot>
                                </table>
                            </div>
                            <%if (Model.Servidor.Usuarios==null || Model.Servidor.Usuarios.Count == 0){%>
                                 <span class="mensaje">No existen registros</span>
                            <%} %>
                          <%if (Model.UsuarioLogueado.Administrador){ %>
                            <input type="button" class="btn btn-primary" value="+" id="btnAgregarServidorUsuario" /> <input type="button" class="btn btn-primary" value="-" id="btnQuitarServidorUsuario" />
                          <%} %>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarServidor" id="btnActualizarServidor" value="Actualizar" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
