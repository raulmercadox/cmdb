<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Cambio de Clave</h3>
        </div>
        <div class="panel-body">
            <form name="frmCambiarClave" id="frmCambiarClave" method="post" class="form-horizontal">
                <input type="hidden" id="id" name="id" value="<%=Model.Usuario.Id %>" />
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="text" disabled value="<%=Model.Usuario.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="text" disabled value="<%=Model.Usuario.Correo %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nueva Clave:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="password" name="txtClave" id="txtClave" />
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCambiarClave" id="btnCambiarClave" value="Cambiar Clave" />
        </div>
    </div>
</asp:Content>
