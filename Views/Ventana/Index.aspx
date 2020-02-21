<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.VentanaView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Ventanas de Pase</h3>
        </div>
        <div class="panel-body">        
            <%if (Model.Ventanas.Count > 0){%>
            <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                    <thead>
                    <tr><th>Desde</th><th>Hasta</th></tr>
                    </thead>
                    <tbody>                      
               <% foreach (Ventana v in Model.Ventanas)
                {
                    string ruta = Url.Content("~/Ventana/Obtener/"+v.Id);
                    string horaHasta = String.Empty;
                    if (v.Hasta.HasValue)
                    {
                        horaHasta = v.Hasta.Value.ToString("HH:mm");
                    }
                      %>
                    
                  <tr><td><a href="<%=ruta %>"><%=v.Desde.ToString("HH:mm") %></a></td><td><%=horaHasta %></td></tr>
                <%}%>
                    </tbody>
                    </table>
                </div>
            <%}%>
        </div>
        <div class="panel-footer">
            <a class="btn btn-link" href="<%=Url.Content("~/Ventana/Crear") %>">Crear Ventana</a>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
