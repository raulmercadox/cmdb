<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.FormatoView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Formato</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoFormato" id="frmNuevoFormato" method="post" action="<%=Url.Content("~/Formato/Crear") %>" enctype="multipart/form-data" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Formato.Id %>" />                
                <div class="form-group">
                    <label for="txtNombreFormato" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Archivo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="file" name="txtNombreFormato" id="txtNombreFormato" class="form-control" />
                    </div>
                </div>                
                <div class="form-group">
                    <label for="txtDescripcionFormato" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Descripcion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtDescripcionFormato" id="txtDescripcionFormato" class="form-control" maxlength="400" rows="5"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigo" id="txtCodigo" class="form-control" maxlength="20"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtVersion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Versión:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtVersion" id="txtVersion" class="form-control" maxlength="30"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtVersion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Carpeta Base:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCarpetaBase" id="txtCarpetaBase" class="form-control" maxlength="50"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearFormato" id="btnCrearFormato" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
