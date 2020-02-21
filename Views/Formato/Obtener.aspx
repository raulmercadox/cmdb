<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.FormatoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Formato</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosFormato" id="frmDatosFormato" method="post" action="<%=Url.Content("~/Formato/Actualizar") %>" enctype="multipart/form-data" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Formato.Id %>" />                
                <div class="form-group">
                    <input type="hidden" name="txtNombreFormato" id="txtNombreFormato" value='<%=Model.Formato.Archivo.Nombre %>' /> 
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <a href='<%=Url.Content("~/Formato/ObtenerArchivo/"+Model.Formato.Id) %>'><%=Model.Formato.Archivo.Nombre %></a>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Reemplazar Archivo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input name="txtArchivoFormato" id="txtArchivoFormato" type="file" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Descripcion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtDescripcionFormato" id="txtDescripcionFormato" class="form-control" maxlength="400" rows="5"><%=Model.Formato.Descripcion %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input name="txtCodigo" id="txtCodigo" class="form-control" maxlength="20" value="<%=Model.Formato.Codigo %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Versión:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input name="txtVersion" id="txtVersion" class="form-control" maxlength="30" value="<%=Model.Formato.Version %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Carpeta Base:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input name="txtCarpetaBase" id="txtCarpetaBase" class="form-control" maxlength="50" value="<%=Model.Formato.CarpetaBase %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarFormato" id="btnActualizarFormato" value="Actualizar" />
            <input type="button" class="btn btn-primary" name="btnEliminarFormato" id="btnEliminarFormato" value="Eliminar"/>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
