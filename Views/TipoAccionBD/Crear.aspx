<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.TipoAccionBDView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Tipo de Accion de BD</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevaTipoAccionBD" id="frmNuevaTipoAccionBD" method="post" action="<%=Url.Content("~/TipoAccionBD/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.TipoAccionBD.Id %>" />                
                <div class="form-group">
                    <label for="txtNombreTipoAccionBD" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreTipoAccionBD" id="txtNombreTipoAccionBD" class="form-control" value="<%=Model.TipoAccionBD.Nombre %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearTipoAccionBD" id="btnCrearTipoAccionBD" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
