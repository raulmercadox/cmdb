<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AreaView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Áreas</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoArea" id="frmCatalogoArea" method="post" class="form-horizontal">                
                <div class="form-group">
                    <label for="txtNombreArea" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreArea" id="txtNombreArea" class="form-control" value="<%=Model.Area.Nombre %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <div class="row">
                <div class="col-xs-12">
                    <input type="button" class="btn btn-primary" name="btnConsultarArea" id="btnConsultarArea" value="Consultar" /> 
                    <a class="btn btn-link" href="<%=Url.Content("~/Area/Crear") %>">Crear Area</a>
                </div>
            </div>
        </div>
    </div>
    <%if (Model.Areas.Count > 0){%>
    <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
            <tr><th>Nombre</th><th>Color</th><th>Abreviatura</th></tr>
            </thead>
            <tbody>                      
                <% foreach (Area p in Model.Areas)
                {
                    string ruta = Url.Content("~/Area/Obtener/" + p.Id);%>
                    
                    <tr><td><a href="<%=ruta %>"><%=p.Nombre %></a></td><td style="background-color:<%=p.Color%>;"></td><td><%=p.Abreviatura %></td></tr>
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
