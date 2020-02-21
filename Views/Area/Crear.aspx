<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AreaView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Area</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevaArea" id="frmNuevaArea" method="post" action="<%=Url.Content("~/Area/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Area.Id %>" />
                <div class="form-group">
                    <label for="txtNombreArea" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreArea" id="txtNombreArea" class="form-control" value="<%=Model.Area.Nombre %>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAbreviatura" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Abreviatura:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAbreviatura" id="txtAbreviatura" class="form-control" value="<%=Model.Area.Abreviatura %>" maxlength="10"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtColor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Color:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" id="txtColor" name="txtColor" class="form-control" value="<%=Model.Area.Color%>" style="background-color: <%=Model.Area.Color%>;"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <div class="row">
                <div class="col-xs-12"><input type="button" class="btn btn-primary" name="btnCrearArea" id="btnCrearArea" value="Crear" /> </div>
            </div>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
