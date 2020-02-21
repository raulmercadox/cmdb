<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SistemaView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Carpeta</h3>
        </div>
        <div class="panel-body">
            <form name="frmCrearCarpeta" id="frmCrearCarpeta" method="post" action="<%=Url.Content("~/Sistema/CrearCarpeta") %>" class="form-horizontal">
                <div class="form-group">
                    <label for="txtRutaOrigen" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ruta Origen:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" id="txtRutaOrigen" name="txtRutaOrigen" class="form-control" />
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" id="btnCrearCarpeta" name="btnCrearCarpeta" value="Crear Carpeta" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %><div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
    
