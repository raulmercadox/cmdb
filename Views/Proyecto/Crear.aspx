<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<ProyectoView>" %>

<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Crear Proyecto</h3>
        </div>
        <div class="panel-body">
            <form name="frmNuevoProyecto" id="frmNuevoProyecto" method="post" action="<%=Url.Content("~/Proyecto/Crear") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Proyecto.Id %>" />
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Código:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" class="form-control" value="<%=Model.Proyecto.Codigo %>" maxlength="30" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombreProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreProyecto" id="txtNombreProyecto" class="form-control" value="<%=Model.Proyecto.Nombre %>" maxlength="100" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPm" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">PM:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtPm" id="txtPm" class="form-control" value="<%=Model.Proyecto.Pm %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPtl" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Lider Calidad:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtPtl" id="txtPtl" class="form-control" value="<%=Model.Proyecto.Ptl %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboResponsable" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Gerencia:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboResponsable" name="cboResponsable" class="form-control"><option value="0"></option>
                            <% if (Model.Responsables != null)
                               {
                                   foreach (Responsable responsable in Model.Responsables)
                                   {%>
                            <option <%=(Model.Proyecto.Responsable!=null && Model.Proyecto.Responsable.Id>0 && Model.Proyecto.Responsable.Id==responsable.Id)?"selected='selected'":String.Empty %> value="<%=responsable.Id %>"><%=responsable.Nombre %></option>
                            <%}
                               }%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboTipoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tipo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboTipoProyecto" name="cboTipoProyecto" class="form-control">
                            <option value="0"></option>
                            <%if (Model.TipoProyectos != null)
                              {
                                  foreach (TipoProyecto tipoProyecto in Model.TipoProyectos)
                                  {%>
                            <option <%=(Model.Proyecto.TipoProyecto!=null && Model.Proyecto.TipoProyecto.Id>0 && Model.Proyecto.TipoProyecto.Id==tipoProyecto.Id)?"selected='selected'":String.Empty %> value="<%=tipoProyecto.Id %>"><%=tipoProyecto.Nombre %></option>
                            <%}
                              } %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-offset-3 col-xs-9 col-sm-offset-2 col-sm-9 col-md-offset-3 col-md-8 col-lg-offset-2 col-lg-6">
                        <input type="checkbox" id="chkMejora" name="chkMejora" <%=Model.Proyecto.Mejora?"checked='checked'":"" %> />
                        Temporal
                    </div>
                </div>
                <div class="form-group impacto" style="display: none;">
                    <label for="txtImpacto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Impacto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea id="txtImpacto" name="txtImpacto" class="form-control" rows="5"><%=Model.Proyecto.Impacto %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoPresupuestal" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Codigo Presupuestal:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoPresupuestal" id="txtCodigoPresupuestal" class="form-control" value="<%=Model.Proyecto.CodigoPresupuestal %>" maxlength="30" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoAlterno" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Codigo Alternativo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoAlterno" id="txtCodigoAlterno" class="form-control" value="<%=Model.Proyecto.CodigoAlterno %>" maxlength="30" />
                    </div>
                </div>
                <%if (Model.Ambientes != null)
                  { %>
                <div class="table-responsive">
                    <table class="table table-bordered table-condensed table-hover">
                        <thead>
                            <tr>
                                <th>Ambiente</th>
                                <th>Fecha de Pase</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%
                          foreach (Ambiente ambiente in Model.Ambientes)
                          { %>
                            <tr>
                                <td data-ambiente="<%=ambiente.Id %>">
                                    <input data-ambiente="<%=ambiente.Nombre %>" type="checkbox" name="chkAmbiente<%=ambiente.Id %>" id="chkAmbiente<%=ambiente.Id %>" class='chkAmbiente <%=ambiente.FechaObligatoria?"obligatorio":String.Empty %>' />
                                    <span <%=ambiente.FechaObligatoria?"style='font-weight:bold;'":String.Empty %>><%=ambiente.Nombre %></span></td>
                                <td>
                                    <input disabled="disabled" readonly="readonly" type="text" class="fecha form-control" name="txtFecha<%=ambiente.Id %>" id="txtFecha<%=ambiente.Id %>" />
                                    <%=ambiente.FechaObligatoria?"<span style='color:red;'>*</span>":String.Empty %></td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
                <%} %>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearProyecto" id="btnCrearProyecto" value="Crear" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
