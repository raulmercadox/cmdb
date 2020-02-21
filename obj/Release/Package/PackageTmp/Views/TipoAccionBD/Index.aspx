<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.TipoAccionBDView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Tipos de Acciones de BD</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoTipoAccionBD" id="frmCatalogoTipoAccionBD" method="post" class="form-horizontal">                
                <div class="form-group">
                    <label for="txtNombreTipoAccionBD" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreTipoAccionBD" id="txtNombreTipoAccionBD" class="form-control" value="<%=Model.TipoAccionBD.Nombre %>"/>
                    </div>
                </div>
            </form>
            
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarTipoAccionBD" id="btnConsultarTipoAccionBD" value="Consultar" />
            <a class="btn btn-link" href="<%=Url.Content("~/TipoAccionBD/Crear") %>">Crear Tipo de Accion de BD</a>
        </div>
    </div>
    <%if (Model.TipoAccionBDs.Count > 0){%>
                    <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                    <thead>
                    <tr><th>Nombre</th></tr>
                    </thead>
                    <tbody>                      
               <% foreach (TipoAccionBD p in Model.TipoAccionBDs)
                {
                    string ruta = Url.Content("~/TipoAccionBD/Obtener/" + p.Id);%>
                    
                  <tr><td><a href="<%=ruta %>"><%=p.Nombre %></a></td></tr>
                <%}%>
                    </tbody>
                    </table>
                    </div>
            <%}%>
   <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
