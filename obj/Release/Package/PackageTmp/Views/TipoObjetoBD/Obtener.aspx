<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.TipoObjetoBDView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Tipo de Objeto de BD</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosTipoObjetoBD" id="frmDatosTipoObjetoBD" method="post" action="<%=Url.Content("~/TipoObjetoBD/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.TipoObjetoBD.Id %>" />
                <div class="form-group">
                    <label for="txtNombreTipoObjetoBD" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreTipoObjetoBD" id="txtNombreTipoObjetoBD" class="form-control" value="<%=Model.TipoObjetoBD.Nombre %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtExtension" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Extension:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtExtension" id="txtExtension" class="form-control" value="<%=Model.TipoObjetoBD.Extension %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarTipoObjetoBD" id="btnActualizarTipoObjetoBD" value="Actualizar" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
