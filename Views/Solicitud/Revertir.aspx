<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Revertir Solicitud</h3>
        </div>
        <div class="panel-body">
            <form name="frmRevertirSolicitud" id="frmRevertirSolicitud" method="post" class="form-horizontal">
                <div class="row">
                    <label for="txtNumeroSolicitud" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">N° Solicitud:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input name="txtNumeroSolicitud" id="txtNumeroSolicitud" class="form-control" />
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" name="btnRevertirSolicitud" id="btnRevertirSolicitud" value="Revertir" class="btn btn-primary" />
        </div>
    </div>
    <%if(!String.IsNullOrEmpty(Model.Mensaje)){ %>
        <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>