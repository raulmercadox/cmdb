<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ResponsableView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos de la Gerencia</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosResponsable" id="frmDatosResponsable" method="post" action="<%=Url.Content("~/Responsable/Actualizar") %>" class="form-horizontal">
                <input type="hidden" name="txtId" id="txtId" value="<%=Model.Responsable.Id %>" />                
                <div class="form-group">
                    <label for="txtNombreResponsable" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreResponsable" id="txtNombreResponsable" maxlength="50" class="form-control" value="<%=Model.Responsable.Nombre %>"/>
                    </div>
                </div>
               
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnActualizarResponsable" id="btnActualizarResponsable" value="Actualizar" />
        </div>
    </div>
     <div>
            <!-- Nav Tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Proyectos</a></li>
            </ul>
            <!-- Nav Panes -->
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="tabs-1">
                    <div class="table-responsive">
                    <table id="tblProyectos" class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr><th>Codigo</th><th>Nombre</th></tr>
                </thead>
                <tbody>
                    <%
                        int contador = 0;
                        if (Model.Responsable.Proyectos!=null)
                        {
                            foreach (Proyecto app in Model.Responsable.Proyectos)
                            {
                                contador++;
                                string ruta = Url.Content("~/Proyecto/Obtener/" + app.Codigo);
                            %>
                                <tr>                                  
                                <td><a href="<%=ruta%>"><%=app.Codigo %></a></td>
                                <td><%=app.Nombre %></td>                                  
                                </tr>  
                            <%}
                        }
                    %>
                </tbody>
                <tfoot>
                </tfoot>                        
            </table>
            </div>
            </div>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %> <div class="alert alert-info"><%=Model.Mensaje %></div> <%} %>
</asp:Content>
