<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Usuarios</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoUsuario" id="frmCatalogoUsuario" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtUsuarioUsuario" id="txtUsuarioUsuario" class="form-control" value="<%=Model.Usuario.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCorreoUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCorreoUsuario" id="txtCorreoUsuario" class="form-control" value="<%=Model.Usuario.Correo %>" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="chkAdministradorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Administrador:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkAdministradorUsuario" id="chkAdministradorUsuario" <%=Model.Usuario.Administrador?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkOperadorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Operador:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkOperadorUsuario" id="chkOperadorUsuario" <%=Model.Usuario.Operador?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkLectorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Lector:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkLectorUsuario" id="chkLectorUsuario" <%=Model.Usuario.Lector?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkCMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">CM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkCMUsuario" id="chkCMUsuario" <%=Model.Usuario.CM?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkRMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">RM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkRMUsuario" id="chkRMUsuario" <%=Model.Usuario.RM?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEjecutorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ejecutor:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEjecutorUsuario" id="chkEjecutorUsuario" <%=Model.Usuario.Ejecutor?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkTestUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">QA:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkTestUsuario" id="chkTestUsuario" <%=Model.Usuario.Test?"checked":"" %> />
                            </label>
                        </div>
                    </div>
                </div>
            </form>
            
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarUsuario" id="btnConsultarUsuario" value="Consultar" />
            <%if (Model.UsuarioLogueado.Administrador)
              { %><a class="btn btn-link" href="<%=Url.Content("~/Usuario/Crear") %>">Crear Usuario</a>
            <%} %>
        </div>
    </div>
    <%if (Model.Usuarios.Count > 0)
              {%>
            <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr>
                        <th>Usuario</th>
                        <th>Correo</th>
                        <th>Administrador</th>
                        <th>Operador</th>
                        <th>Lector</th>
                        <th>CM</th>
                        <th>RM</th>
                        <th>Ejecutor</th>
                        <th>QA</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (Usuario d in Model.Usuarios)
                       {
                           string ruta = Url.Content("~/Usuario/Obtener/" + d.Nombre);%>

                    <tr>
                        <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=d}) %></td>
                        <td><%=d.Correo %></td>
                        <td><%=d.Administrador?"Si":"" %></td>
                        <td><%=d.Operador?"Si":"" %></td>
                        <td><%=d.Lector?"Si":"" %></td>
                        <td><%=d.CM?"Si":"" %></td>
                        <td><%=d.RM?"Si":"" %></td>
                        <td><%=d.Ejecutor?"Si":"" %></td>
                        <td><%=d.Test?"Si":"" %></td>
                    </tr>
                    <%}%>
                </tbody>
            </table>
                </div>
            <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %><div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
