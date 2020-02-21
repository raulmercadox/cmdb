<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.RolView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


  
    <div id="contenido">
        <h3>Catálogo de Roles</h3>
        <div id="cuerpo">
            <form name="frmCatalogoRol" id="frmCatalogoRol" method="post">
                <div class="filacampos"><span class="etiqueta">Nombre:</span><input type="text" name="txtNombreRol" id="txtNombreRol" class="textoLargo" value="<%=Model.Rol.Nombre %>" /></div>                
                <div class="filacampos"><input type="button" class="btn btn-primary" name="btnConsultarRol" id="btnConsultarRol" value="Consultar" /> <input type="reset" class="btn btn-primary" name="btnLimpiar" id="btnLimpiar" value="Limpiar"/> <a href="<%=Url.Content("~/Rol/Crear") %>">Crear Rol</a></div>                
            </form>
            <span class="mensaje"><%=Model.Mensaje %></span>
            <%if (Model.Roles.Count > 0){%>
                    <table class="tabla">
                    <thead>
                    <tr><th class="textoLargo">Nombre</th></tr>
                    </thead>
                    <tbody>                      
               <% foreach (Rol d in Model.Roles)
                {
                    string ruta = Url.Content("~/Rol/Obtener/"+d.Id.ToString());%>
                    <tr><td><a href="<%=ruta %>"><%=d.Nombre %></a></td></tr>  
                <%}%>
                    </tbody>
                    </table>
            <%}%>
        </div>
    </div>

</asp:Content>
