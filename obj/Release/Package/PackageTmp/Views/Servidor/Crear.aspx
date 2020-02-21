<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ServidorView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Servidor</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoServidor" id="frmNuevoServidor" method="post" action="<%=Url.Content("~/Servidor/Crear") %>" class="form-horizontal">
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
                        <textarea name="txtDescripcion" id="txtDescripcion" class="form-control" rows="5"><%=Model.Servidor.Descripcion %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbienteServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbienteServidor" name="cboAmbienteServidor">
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                               {%>
                            <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                            <%}%>
                        </select>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearServidor" id="btnCrearServidor" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
