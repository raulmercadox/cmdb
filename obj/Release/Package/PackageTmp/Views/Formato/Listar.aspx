<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.FormatoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.Repository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Formatos</h3>
        </div>
        <div class="panel-body">
            <%if (Model.Formatos.Count > 0){%>
            <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                        <thead>
                        <tr><%=Model.Usuario.Administrador?"<th></th>":String.Empty %><th>Nombre</th><th>Descripción</th></tr>
                        </thead>
                        <tbody>
                           <% foreach (Formato p in Model.Formatos)
                            {
                                string ruta = Url.Content("~/Formato/Obtener/"+p.Id);%>
                    
                              <tr><%=Model.Usuario.Administrador?String.Concat("<td><a href='",ruta,"'>Editar</a></td>"):String.Empty %><td><a href='<%=Url.Content("~/Formato/ObtenerArchivo/"+p.Id) %>'><%=p.Archivo.Nombre %></a></td><td><%=p.Descripcion %></td></tr>
                            <%}%>
                        </tbody>
                        <tfoot>
                            <tr><td colspan='<%=Model.Usuario.Administrador?"3":"2"%>'><%=Model.Formatos.Count %> Formatos</td></tr>
                        </tfoot>
                    </table>
            <%}%>
            </div>
        </div>
        <div class="panel-footer">
            <% if (Model.Usuario.Administrador){ %>
                <a href="<%=Url.Content("~/Formato/Crear") %>">Nuevo Formato</a>
            <%} %>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
