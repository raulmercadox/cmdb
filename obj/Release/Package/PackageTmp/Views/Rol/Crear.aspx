<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.RolView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Rol</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoRol" id="frmNuevoRol" method="post" action="<%=Url.Content("~/Rol/Crear") %>">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Rol.Id %>" />
                <div class="filacampos"><span class="etiqueta">Nombre:</span><input type="text" name="txtNombreRol" id="txtNombreRol" class="textoLargo" value="<%=Model.Rol.Nombre %>"/></div>                
                <div class="filacampos"><input type="button" class="btn btn-primary" name="btnCrearRol" id="btnCrearRol" value="Crear" /> <input type="reset" class="btn btn-primary" name="btnLimpiar" id="btnLimpiar" value="Limpiar"/></div>
                <span class="mensaje"><%=Model.Mensaje %></span>
            </form>
        </div>
    </div>

</asp:Content>
