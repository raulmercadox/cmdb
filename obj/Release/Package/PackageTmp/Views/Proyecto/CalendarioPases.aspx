<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ProyectoView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link rel="stylesheet" href="<%=Url.Content("~/css/fullcalendar.css") %>">
    <link rel="stylesheet" href="<%=Url.Content("~/css/jquery.qtip.css") %>">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Calendario de Pases</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12">
                    <span class="programado">Planificado</span> <span class="ejecutado">Ejecutado</span>
                </div>
            </div>
            <div class="form-group">
                <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente: </label>
                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                    <select id="cboAmbiente" class="form-control">
                        <option value="0"></option>
                        <%foreach(var ambiente in Model.Ambientes){ %>
                            <option value="<%=ambiente.Id %>"><%=ambiente.Nombre %></option>
                        <%} %>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div id="calendar"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
