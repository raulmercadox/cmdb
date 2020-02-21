<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.RolView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     
    <div id="contenido">
        <h3>Datos del Rol</h3>
        <div id="cuerpo">
            <form name="frmDatosRol" id="frmDatosRol" method="post" action="<%=Url.Content("~/Rol/Actualizar") %>">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Rol.Id %>" />
                <div class="filacampos"><span class="etiqueta">Nombre:</span><input type="text" name="txtNombreRol" id="txtNombreRol" class="textoLargo" value="<%=Model.Rol.Nombre %>"/></div>
                <div class="filacampos"><input type="button" class="btn btn-primary" name="btnActualizarRol" id="btnActualizarRol" value="Actualizar" /></div>
                <span class="mensaje"><%=Model.Mensaje %></span>
                
            </form>
        </div>
    </div>
    <div style="clear:both;"></div>

</asp:Content>
