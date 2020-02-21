<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.InstanciaView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos de la Instancia</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosInstancia" id="frmDatosInstancia" method="post" action="<%=Url.Content("~/Instancia/Actualizar") %>" class="form-horizontal">
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
                               {
                                   if (servidor.Id == Model.Instancia.Servidor.Id)
                                   {%>
                            <option value="<%=servidor.Id %>" selected="selected"><%=servidor.Ip%> <%=String.IsNullOrEmpty(servidor.Nombre)?"":"(" %><%=servidor.Nombre%><%=String.IsNullOrEmpty(servidor.Nombre)?"":")" %></option>
                            <%}
                                   else
                                   { %>
                            <option value="<%=servidor.Id %>"><%=servidor.Ip%> <%=String.IsNullOrEmpty(servidor.Nombre)?"":"(" %><%=servidor.Nombre%><%=String.IsNullOrEmpty(servidor.Nombre)?"":")" %></option>
                            <%}
                               }%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                               {
                                   if (ambiente.Id == Model.Instancia.Ambiente.Id)
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
                <div class="form-group">
                    <label for="cboInstanciaAnt" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Instancia Anterior:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboInstanciaAnt" name="cboInstanciaAnt">
                            <option value="0"></option>
                            <% foreach (Instancia instancia in Model.Instancias)
                               { %>
                            <option value="<%=instancia.Id %>" <%=(Model.Instancia.InstanciaAnterior!=null && Model.Instancia.InstanciaAnterior.Id==instancia.Id)?"selected='selected'":"" %>><%=instancia.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtRepoSubversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Repositorio Subversion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtRepoSubversion" id="txtRepoSubversion" class="form-control" value="<%=Model.Instancia.RepositorioSubversion %>" />
                    </div>
                </div>
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Esquemas</a></li>
                    </ul>
                    <!-- Nav Panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="tabs-1">
                            <div class="table-responsive">
                                <table id="tblEsquemas" class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Nombre</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        int contador = 0;
                                        if (Model.Instancia.Esquemas != null)
                                        {
                                            foreach (Esquema app in Model.Instancia.Esquemas)
                                            {
                                                contador++;
                                    %>
                                    <tr>
                                        <td>
                                            <input type="hidden" name="idesquema<%=contador%>" id="idesquema<%=contador%>" value="<%=app.Id%>" />
                                            <input type="hidden" class="eliminadoesquema" name="eliminadoesquema<%=contador%>" id="eliminadoesquema<%=contador%>" value="0" />
                                            <input type="checkbox" class="esquema" name="<%=contador%>" id="<%=contador%>" />
                                        </td>
                                        <td>
                                            <input class="form-control" type="text" value="<%=app.Nombre%>" name="nombreesquema<%=contador%>" />
                                        </td>
                                    </tr>
                                    <%}
                                        }
                                    %>
                                </tbody>
                                <tfoot>
                                </tfoot>
                            </table>
                            </div>
                            <input type="button" class="btn btn-primary" value="+" id="btnAgregarEsquema" />
                            <input type="button" class="btn btn-primary" value="-" id="btnQuitarEsquema" />
                        </div>
                    
                     </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarInstancia" id="btnActualizarInstancia" value="Actualizar" />
            <input type="button" class="btn btn-primary" name="btnEliminarInstancia" id="btnEliminarInstancia" value="Eliminar" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
