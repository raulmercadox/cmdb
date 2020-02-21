<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form class="form-signin" name="frmAcceso" id="frmAcceso" action="<%=Url.Content("~/Seguridad/Ingresar")%>" method="post">       
        
        <input type="hidden" id="Hidden1" name="returnUrl" value="<%=ViewData["returnUrl"]%>" />
        <h2 class="form-signin-heading">Acceso</h2>
        <input type="text" class="form-control" name="txtUsuario" placeholder="Ingrese Usuario" required="" autofocus="" id="txtUsuario" />
        <input type="password" class="form-control" id="txtClave" name="txtClave" placeholder="Ingrese Clave" required=""/>      
        <a href='<%=Url.Content("~/Usuario/RecuperarClave") %>'>Olvidé mi clave</a>
        <%if(ViewData["mensaje"]!=null && ViewData["mensaje"].ToString().Trim()!=""){ %>
        <div class="alert alert-danger"><%=ViewData["mensaje"]%></div>
        <%} %>
   
         <button class="btn btn-lg btn-primary btn-block" type="button" name="btnEnviar" id="btnEnviar">Login</button>   
    </form>
    
</asp:Content>
