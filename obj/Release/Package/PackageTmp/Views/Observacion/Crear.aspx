﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ObservacionView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Observación</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevaObservacion" id="frmNuevaObservacion" method="post" action="<%=Url.Content("~/Observacion/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Observacion.Id %>" />                
                <div class="form-group">
                    <label for="txtNombreObservacion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreObservacion" id="txtNombreObservacion" class="form-control" value="<%=Model.Observacion.Nombre %>"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearObservacion" id="btnCrearObservacion" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
