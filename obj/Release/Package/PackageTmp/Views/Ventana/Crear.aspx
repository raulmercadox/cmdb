<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.VentanaView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Ventana de Pase</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevaVentana" id="frmNuevaVentana" method="post" action="<%=Url.Content("~/Ventana/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Ventana.Id %>" />                
                <div class="form-group">
                    <label for="cboHoraDesde" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Desde:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboHoraDesde" name="cboHoraDesde"><%
                                                                                                                              int horaDesde = Model.Ventana.Desde.Hour;
                                                                                                                              int minutoDesde = Model.Ventana.Desde.Minute;
                                                                                                                              int horaHasta = Model.Ventana.Hasta==null?-1:Model.Ventana.Hasta.Value.Hour;
                                                                                                                              int minutoHasta = Model.Ventana.Hasta==null?-1:Model.Ventana.Hasta.Value.Minute;
                                                                                                                              
                                                                                                      for (int i = 0; i <= 23; i++)
                                                                                                      {
                                                                                                          %>
                                                                                                          <option value="<%=i.ToString().PadLeft(2,'0') %>" <%=horaDesde==i?"selected='selected'":"" %>><%=i.ToString().PadLeft(2,'0') %></option>
                                                                                                      <%} %></select>:<select class="form-control" id="cboMinutoDesde" name="cboMinutoDesde"><%
                                                                                                      for (int i = 0; i <= 11; i++)
                                                                                                      {
                                                                                                          int m = i * 5;%>
                                                                                                          <option value="<%=m.ToString().PadLeft(2,'0') %>" <%=minutoDesde==i?"selected='selected'":"" %>><%=m.ToString().PadLeft(2,'0') %></option>
                                                                                                      <%} %></select>

                    </div>
                </div>
                <div class="form-group">
                    <label for="cboHoraHasta" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hasta:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboHoraHasta" name="cboHoraHasta"><option value="-1"></option><%
                                                                                                          for (int i = 0; i <= 23; i++)
                                                                                                          {%>
                                                                                                              <option value="<%=i.ToString().PadLeft(2,'0') %>" <%=horaHasta==i?"selected='selected'":"" %>><%=i.ToString().PadLeft(2,'0') %></option>
                                                                                                          <%} %></select>:<select class="form-control" id="cboMinutoHasta" name="cboMinutoHasta"><option value="-1"></option><%
                                                                                                          for (int i = 0; i <= 11; i++)
                                                                                                          {
                                                                                                              int m = i * 5;%>
                                                                                                              <option value="<%=m.ToString().PadLeft(2,'0') %>" <%=minutoHasta==i?"selected='selected'":"" %>><%=m.ToString().PadLeft(2,'0') %></option>
                                                                                                          <%} %>
                        </select>
                    </div>
                </div>    
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearVentana" id="btnCrearVentana" value="Crear" />
        </div>
    </div>
   <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
