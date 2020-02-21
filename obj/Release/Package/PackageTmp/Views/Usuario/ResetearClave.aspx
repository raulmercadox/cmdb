<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Cambio de Clave</h3>
        </div>
        <div class="panel-body">
            <form name="frmResetearClave" id="frmResetearClave" method="post" action='<%=Url.Content("~/Usuario/RestaurarClave")%>' class="form-horizontal">
                <input type="hidden" id="token" name="token" value="<%=Model.Usuario.Token %>" />
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" disabled value="<%=Model.Usuario.Nombre %>" class="form-control"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" disabled value="<%=Model.Usuario.Correo %>" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nueva Clave:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control"  type="password" name="txtClave" id="txtClave" />
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnResetearClave" id="btnResetearClave" value="Cambiar Clave" />
        </div>
    </div>
</asp:Content>
