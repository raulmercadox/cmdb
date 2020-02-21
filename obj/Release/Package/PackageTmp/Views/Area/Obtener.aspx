<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AreaView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Area</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosArea" id="frmDatosArea" method="post" action="<%=Url.Content("~/Area/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Area.Id %>" />
                <div class="form-group">
                    <label for="txtNombreArea" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreArea" id="txtNombreArea" class="form-control" value="<%=Model.Area.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAbreviatura" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Abreviatura:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAbreviatura" id="txtAbreviatura" class="form-control" value="<%=Model.Area.Abreviatura %>" maxlength="10" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtColor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Color:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input class="form-control" type="text" id="txtColor" name="txtColor" value="<%=Model.Area.Color%>" style="background-color: <%=Model.Area.Color%>;" />
                    </div>
                </div>
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Correos</a></li>
                    </ul>
                    <!-- Nav Panes -->
                    <div class="tab-content">
                        <div id="tabs-1" role="tabpanel" class="tab-pane active">
                            <div class="table-responsive">
                                <table id="tblCorreos" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Correo</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%
                                            int contador = 0;
                                            foreach (Correo correo in Model.Area.Correos)
                                            {
                                                contador++;
                                        %>
                                        <tr>
                                            <td>
                                                <input type="hidden" name="hdId<%=contador %>" id="hdId<%=contador %>" value="<%=correo.Id %>" />
                                                <input type="hidden" class="eliminadocorreo" name="eliminadocorreo<%=contador %>" id="eliminadocorreo<%=contador %>" value="0" />
                                                <input type="checkbox" class="correo" name="<%=contador %>" id="<%=contador %>" />
                                            </td>
                                            <td>
                                                <input class="form-control" type="text" value="<%=correo.Direccion %>" style="width: 100%" name="direccioncorreo<%=contador %>" /></td>
                                        </tr>
                                        <%}
                                        %>
                                    </tbody>
                                </table>
                            </div>
                            <%if (Model.Area.Correos.Count == 0)
                                  {%>
                                <div class="alert alert-info">No existen registros</div>
                                <%} %>
                            <div class="row">
                                    <div class="col-xs-12">
                                        <input type="button" class="btn btn-primary" value="+" id="btnAgregarCorreo" />
                                        <input type="button" class="btn btn-primary" value="-" id="btnQuitarCorreo" />
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>

            </form>
        </div>
        <div class="panel-footer">
            <div class="row">
                <div class="col-xs-12">
                    <input type="button" class="btn btn-primary" name="btnActualizarArea" id="btnActualizarArea" value="Actualizar" />
                </div>
            </div>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %>
    <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
