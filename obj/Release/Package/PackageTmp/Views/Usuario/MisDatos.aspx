<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Mis Datos</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosUsuario" id="frmDatosUsuario" method="post" class="form-horizontal">
                <%=Html.HiddenFor(x => x.Usuario.Id)%>
                <%=Html.HiddenFor(x=>x.Usuario.Nombre) %>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="text" disabled value="<%=Model.Usuario.Nombre%>" />
                    </div>
                </div>                
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%=Html.TextBoxFor(x => x.Usuario.Correo, new { @class = "form-control" })%>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Celular:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%=Html.TextBoxFor(x => x.Usuario.Celular, new { @class = "form-control" })%>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Anexo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%=Html.TextBoxFor(x => x.Usuario.Anexo, new { @class = "form-control" })%>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Skype:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%=Html.TextBoxFor(x => x.Usuario.Skype, new { @class = "form-control" })%>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="submit" class="btn btn-primary" name="btnActualizarMisDatos" id="btnActualizarMisDatos" value="Actualizar" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %><div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
