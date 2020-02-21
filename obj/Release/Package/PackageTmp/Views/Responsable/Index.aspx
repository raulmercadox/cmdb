<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ResponsableView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Gerencias</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoResponsable" id="frmCatalogoResponsable" method="post" class="form-horizontal">                
                <div class="form-group">
                    <label for="txtNombreResponsable" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreResponsable" id="txtNombreResponsable" class="form-control" maxlength="50" value="<%=Model.Responsable.Nombre %>"/>
                    </div>
                </div>                
            </form>
            <%if (Model.Responsables.Count > 0){%>
            <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                <thead>
                <tr><th>Nombre</th></tr>
                </thead>
                <tbody>                      
                <% foreach (Responsable r in Model.Responsables)
                {
                    string ruta = Url.Content("~/Responsable/Obtener/"+r.Id);%>
                    
                    <tr><td><a href="<%=ruta %>"><%=r.Nombre %></a></td></tr>  
                <%}%>
                </tbody>
                </table>
            </div>
            <%}%>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarResponsable" id="btnConsultarResponsable" value="Consultar" />
            <a class="btn btn-link" href="<%=Url.Content("~/Responsable/Crear") %>">Crear Gerencia</a>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %> <div class="alert alert-info"><%=Model.Mensaje %></div> <%} %>

</asp:Content>
