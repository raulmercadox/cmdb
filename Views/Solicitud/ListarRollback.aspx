<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Listar rollbacks</h3>
        </div>
        <div class="panel-body">
            <form name="frmListarRollback" id="frmListarRollback" method="post" action="<%=Url.Content("~/Solicitud/ListarRollback") %>" enctype="multipart/form-data" class="form-horizontal">
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                        <% foreach (var ambiente in Model.Ambientes)
                        {%>
                          <option value="<%=ambiente.Id %>" <%=(Model.Ambiente!=null && ambiente.Id==Model.Ambiente.Id)?"selected":"" %>><%=ambiente.Nombre%></option>
                        <%}%>
                        </select>
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaDesde" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Desde:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" name="txtFechaDesde" id="txtFechaDesde" class="form-control fecha" value="<%=Model.FechaDesde.HasValue?Model.FechaDesde.Value.ToString("dd/MM/yyyy"):DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy") %>" readonly="readonly" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaHasta" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hasta:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" name="txtFechaHasta" id="txtFechaHasta" class="form-control fecha" value="<%=Model.FechaHasta.HasValue?Model.FechaHasta.Value.ToString("dd/MM/yyyy"):DateTime.Now.ToString("dd/MM/yyyy") %>" readonly="readonly" />
                     </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnListarRollback" id="btnListarRollback" value="Listar" />
        </div>
    </div>
    <% if (Model.Rollbacks!=null && Model.Rollbacks.Count>0){ %>
    <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr><th>Codigo</th><th>Nombre</th><th>Tipo Proyecto</th><th>Comentario</th><th>Fecha Hora</th><th>Solicitud</th><th>Emergente</th></tr>
                </thead>
                <tbody>
    <%foreach(var rollback in Model.Rollbacks){ %>
        <tr><td><a href='<%=Url.Content("~/Proyecto/Obtener/"+rollback.Codigo)%>'><%=rollback.Codigo %></a></td><td><%=rollback.Nombre %></td><td><%=rollback.TipoProyecto %></td><td><%=rollback.Comentario %></td>
            <td><%=rollback.FechaHora.ToString("dd/MM/yyyy") %></td><td><a href='<%=Url.Content("~/Solicitud/Obtener/S"+rollback.SolicitudId.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S",rollback.SolicitudId.ToString().PadLeft(6,'0')) %></a></td><td><%=rollback.Emergente?"SI":"" %></td></tr>
    <%} %>
          </tbody>
          </table>          
    <%} %>
                    
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
