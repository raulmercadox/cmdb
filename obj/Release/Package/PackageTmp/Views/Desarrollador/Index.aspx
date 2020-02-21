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
            <form name="frmCatalogoDesarrollador" id="frmCatalogoDesarrollador" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtNombreDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreDesarrollador" id="txtNombreDesarrollador" class="form-control" value="<%=Model.Desarrollador.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCorreoDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCorreoDesarrollador" id="txtCorreoDesarrollador" class="form-control" value="<%=Model.Desarrollador.Correo %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtUsuarioDesarrollador" id="txtUsuarioDesarrollador" class="form-control" value="<%=Model.Desarrollador.Usuario %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtClaveDesarrollador" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Clave:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtClaveDesarrollador" id="txtClaveDesarrollador" class="form-control" value="<%=Model.Desarrollador.Clave %>"/>
                    </div>
                </div>                
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarDesarrollador" id="btnConsultarDesarrollador" value="Consultar" /> 
            <a href="<%=Url.Content("~/Desarrollador/Crear") %>">Crear Desarrollador</a>
        </div>
    </div>
    <%if (Model.Desarrolladores.Count > 0){%>
                    <div class="table-responsive">
                        <table class="table table-bordered table-condensed table-hover">
                            <thead>
                                <tr><th>Nombre</th><th>Correo</th><th>Usuario</th></tr>
                            </thead>
                            <tbody>                      
                               <% foreach (Desarrollador d in Model.Desarrolladores)
                                {
                                    string ruta = Url.Content("~/Desarrollador/Obtener/"+d.Usuario);%>
                    
                                  <tr><td><a href="<%=ruta %>"><%=d.Nombre %></a></td><td><%=d.Correo %></td><td><%=d.Usuario %></td></tr>  
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
