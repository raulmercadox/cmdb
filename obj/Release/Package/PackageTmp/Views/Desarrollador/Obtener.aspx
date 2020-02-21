<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.DesarrolladorView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Desarrolladores</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosDesarrollador" id="frmDatosDesarrollador" method="post" action="<%=Url.Content("~/Desarrollador/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Desarrollador.Id %>" />
                <div class="form-group">
                    <label for="txtNombreDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreDesarrollador" id="txtNombreDesarrollador" class="form-control" value="<%=Model.Desarrollador.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtUsuarioDesarrollador" id="txtUsuarioDesarrollador" class="form-control" value="<%=Model.Desarrollador.Usuario %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtClaveDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Clave:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtClaveDesarrollador" id="txtClaveDesarrollador" class="form-control" value="<%=Model.Desarrollador.Clave %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCorreoDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCorreoDesarrollador" id="txtCorreoDesarrollador" class="form-control" value="<%=Model.Desarrollador.Correo %>" />
                    </div>
                </div>

                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Proyectos</a></li>
                    </ul>

                     <!-- Nav Panes -->
                    <div class="tab-content">
                        <div id="tabs-1" role="tabpanel" class="tab-pane active">
                            <div class="table-responsive">
                                <table id="tblProyectos" class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th>Código</th>
                                        <th>Nombre</th>
                                        <th>PM</th>
                                        <th>PTL</th>
                                        <th>Estado</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%                                
                                        foreach (Proyecto proy in Model.Desarrollador.Proyectos)
                                        {
                                            string ruta = Url.Content("~/Proyecto/Obtener/" + proy.Codigo);              
                                    %>
                                    <tr>
                                        <td><a href="<%=ruta %>"><%=proy.Codigo %></a></td>
                                        <td><%=proy.Nombre %></td>
                                        <td><%=proy.Pm %></td>
                                        <td><%=proy.Ptl %></td>
                                        <td><%=proy.DescripcionEstado %></td>
                                    </tr>
                                    <%}
                                    %>
                                </tbody>
                                </table>
                            </div>
                            <%if (Model.Desarrollador.Proyectos.Count == 0)
                              {%>
                            <div class="alert alert-info">No existen registros</div>
                            <%} %>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarDesarrollador" id="btnActualizarDesarrollador" value="Actualizar" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>

</asp:Content>
