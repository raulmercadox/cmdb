<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.TipoObjetoBDView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Tipos de Objetos de BD</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoTipoObjetoBD" id="frmCatalogoTipoObjetoBD" method="post" class="form-horizontal">                
                <div class="form-group">
                    <label for="txtNombreTipoObjetoBD" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreTipoObjetoBD" id="txtNombreTipoObjetoBD" class="form-control" value="<%=Model.TipoObjetoBD.Nombre %>"/>
                    </div>
                </div>
            </form>
            <%if (Model.TipoObjetoBDs.Count > 0){%>
            <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                    <thead>
                    <tr><th>Nombre</th><th>Extension</th></tr>
                    </thead>
                    <tbody>                      
               <% foreach (TipoObjetoBD p in Model.TipoObjetoBDs)
                {
                    string ruta = Url.Content("~/TipoObjetoBD/Obtener/" + p.Id);%>
                    
                  <tr><td><a href="<%=ruta %>"><%=p.Nombre %></a></td><td><%=p.Extension %></td></tr>
                <%}%>
                    </tbody>
                    </table>
                </div>
            <%}%>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarTipoObjetoBD" id="btnConsultarTipoObjetoBD" value="Consultar" />
            <a class="btn btn-link" href="<%=Url.Content("~/TipoObjetoBD/Crear") %>">Crear Tipo de Objeto de BD</a>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
