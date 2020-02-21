<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AplicacionView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Aplicaciones</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoAplicacion" id="frmCatalogoAplicacion" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtNombre" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombre" id="txtNombre" class="form-control" value="<%=Model.Aplicacion.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtRutaSVN" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ruta SVN:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtRutaSVN" id="txtRutaSVN" class="form-control" value="<%=Model.Aplicacion.RutaSVN %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtHerramienta" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Herramienta:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtHerramienta" id="txtHerramienta" class="form-control" value="<%=Model.Aplicacion.Herramienta %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtVersion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Version:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtVersion" id="txtVersion" class="form-control" value="<%=Model.Aplicacion.Version %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboEstado" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Estado:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboEstado" name="cboEstado">
                            <option value="D">Desarrollo</option>
                            <option value="T">Test</option>
                            <option value="P">Produccion</option>
                            <option value="A" selected>Todos</option>
                        </select>
                    </div>
                </div>
            </form>

            
        </div>
        <div class="panel-footer">
            <div class="row">
                <div class="col-xs-12">
                    <input type="button" class="btn btn-primary" name="btnConsultarAplicacion" id="btnConsultarAplicacion" value="Consultar" />
                </div>
            </div>
        </div>
    </div>
    <%if (Model.Aplicaciones.Count > 0)
              {%>
            <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Ruta SVN</th>
                            <th>Herramienta</th>
                            <th>Version</th>
                            <th>Estado</th>
                            <th>Proyecto</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (Aplicacion p in Model.Aplicaciones)
                           {
                        %>
                        <tr>
                            <td><%=p.Nombre %></td>
                            <td><%=p.RutaSVN %></td>
                            <td><%=p.Herramienta %></td>
                            <td><%=p.Version %></td>
                            <td><%=p.DescripcionEstado %></td>
                            <td><%=p.Proyecto.Nombre %></td>
                        </tr>
                        <%}%>
                    </tbody>
                </table>
            </div>
            <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
