<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.InstanciaView>" %>

<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Instancia</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoInstancia" id="frmNuevoInstancia" method="post" action="<%=Url.Content("~/Instancia/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Instancia.Id %>" />
                <div class="form-group">
                    <label for="txtNombreInstancia" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreInstancia" id="txtNombreInstancia" class="form-control" value="<%=Model.Instancia.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Servidor:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboServidor" name="cboServidor">
                            <% foreach (Servidor servidor in Model.Servidores)
                               {%>
                            <option value="<%=servidor.Id %>"><%=servidor.Ip%> <%=String.IsNullOrEmpty(servidor.Nombre)?"":"(" %><%=servidor.Nombre%><%=String.IsNullOrEmpty(servidor.Nombre)?"":")" %></option>
                            <%}%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                               {%>
                            <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                            <%}%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboInstanciaAnt" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Instancia Anterior:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboInstanciaAnt" name="cboInstanciaAnt">
                            <option value="0"></option>
                            <% foreach (Instancia instancia in Model.Instancias)
                               { %>
                            <option value="<%=instancia.Id %>"><%=instancia.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtRepoSubversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Repositorio Subversion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtRepoSubversion" id="txtRepoSubversion" class="form-control" />
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearInstancia" id="btnCrearInstancia" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
