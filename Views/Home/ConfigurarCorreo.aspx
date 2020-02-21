<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.EstadoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Configurar envio de correos de estados de solicitud</h3>
        </div>
        <div class="panel-body">
            <form name="frmConfigurarCorreo" id="frmConfigurarCorreo" method="post">
                <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                        <thead>
                            <tr><th>Estado</th><th>Enviar Correo</th><th>Pendiente</th><th>Satisfactorio</th></tr>
                        </thead>
                        <tbody>
                            <%foreach(Estado e in Model.Estados){ %>
                            <tr><td><%=e.Nombre %></td>
                                <td><input type="checkbox" name="<%=String.Concat("Correo-",e.Nombre) %>" id="<%=String.Concat("Correo-",e.Nombre) %>" <%=e.EnviarCorreo?"checked='checked'":"" %>/></td>
                                <td><input type="checkbox" name="<%=String.Concat("Pendiente-",e.Nombre) %>" id="<%=String.Concat("Pendiente-",e.Nombre) %>" <%=e.Pendiente?"checked='checked'":"" %> /></td>
                                <td><input type="checkbox" name="<%=String.Concat("Satisfactorio-",e.Nombre) %>" id="<%=String.Concat("Satisfactorio-",e.Nombre) %>" <%=e.Satisfactorio?"checked='checked'":"" %> /></td></tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
            </form>
        </div>   
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConfigurarCorreo" id="btnConfigurarCorreo" value="Actualizar"/>         
        </div>
    </div>
</asp:Content>
