<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ProyectoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Listar Objetos</h3>
        </div>
        <div class="panel-body">
            <h4>Lista de proyectos cuyas solicitudes tienen fecha de reversion pero que aún no se han regularizado.</h4>

            <%if (Model.Proyectos.Count==0){ %>
            <div class="alert alert-info">No existen proyectos pendientes de reversión.</div>
            <%} else{%>
            <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                    <thead>
                        <tr><th>Codigo</th><th>Nombre</th></tr>
                    </thead>
                    <tbody>
                        <%foreach(Proyecto proy in Model.Proyectos){ %>
                        <tr><td><a href="<%=Url.Content("~/Proyecto/Obtener/"+proy.Codigo) %>"><%=proy.Codigo %></a></td><td><%=proy.Nombre %></td></tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
