<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.UsuarioView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Recuperar Clave</h3>
        </div>
        <div class="panel-body">
            <form name="frmRecuperarClave" id="frmRecuperarClave" method="post" class="form-horizontal">            
                <div class="form-group">
                    <label for="txtUsuarioUsuario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Usuario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="text" name="txtUsuario" id="txtUsuario" />
                    </div>
                </div>            
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnRecuperarClave" id="btnRecuperarClave" value="Recuperar Clave" />
        </div>
    </div>
</asp:Content>
