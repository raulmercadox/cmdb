<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Usuario</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoUsuario" id="frmNuevoUsuario" method="post" action="<%=Url.Content("~/Usuario/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Usuario.Id %>" />
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtUsuarioUsuario" id="txtUsuarioUsuario" class="form-control" value="<%=Model.Usuario.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtClaveUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Clave:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="password" name="txtClaveUsuario" id="txtClaveUsuario" class="form-control" value="<%=Model.Usuario.Clave %>" />
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
                                <input type="checkbox" name="chkAdministradorUsuario" id="chkAdministradorUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkOperadorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Operador:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkOperadorUsuario" id="chkOperadorUsuario" class="rol" checked="checked" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkLectorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Lector:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkLectorUsuario" id="chkLectorUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkCMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">CM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkCMUsuario" id="chkCMUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkRMUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">RM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkRMUsuario" id="chkRMUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEjecutorUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ejecutor:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEjecutorUsuario" id="chkEjecutorUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkTestUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">QA:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkTestUsuario" id="chkTestUsuario" class="rol" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEnviarCorreo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Enviar Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEnviarCorreo" id="chkEnviarCorreo" checked="checked" />
                            </label>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearUsuario" id="btnCrearUsuario" value="Crear" />
        </div>
    </div>
     <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
