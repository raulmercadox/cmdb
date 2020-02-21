<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ProyectoView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Certificar Proyecto</h3>
        </div>
        <div class="panel-body">
            <form name="frmCertificarProyecto" id="frmCertificarProyecto" method="post" class="form-horizontal">
                <input type="hidden" id="hdIdProyecto" name="hdIdProyecto" />
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Proyecto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" class="form-control codigoproyecto" maxlength="30"/> 
                        <label id="lblDescripcionProyecto"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                            <option value="0"></option>
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                            {%>
                              <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                            <%}%>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div id="resultadoCertificado">
                            
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
