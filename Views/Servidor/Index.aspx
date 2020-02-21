<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ServidorView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Servidores</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoServidor" id="frmCatalogoServidor" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtIpServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">IP:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtIpServidor" id="txtIpServidor" class="form-control" value="<%=Model.Servidor.Ip %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombreServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreServidor" id="txtNombreServidor" class="form-control" value="<%=Model.Servidor.Nombre %>"/>
                    </div>
                </div>                
                <div class="form-group">
                    <label for="txtDescripcion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Descripción:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtDescripcion" id="txtDescripcion" class="form-control" rows="5"><%=Model.Servidor.Descripcion %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbienteServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbienteServidor" name="cboAmbienteServidor">
                        <% foreach (Ambiente ambiente in Model.Ambientes)
                           {
                               if (Model.Servidor.Ambiente!=null && ambiente.Id == Model.Servidor.Ambiente.Id)
                               {%>                    
                       
                            <option value="<%=ambiente.Id %>" selected="selected"><%=ambiente.Nombre%></option>
                        <%}
                               else { %>
                                   <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                               <%}
                           }%>
                        </select>
                    </div>
                </div>
            </form>
            
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarServidor" id="btnConsultarServidor" value="Consultar" />
            <a class="btn btn-link" href="<%=Url.Content("~/Servidor/Crear") %>">Crear Servidor</a>
        </div>
    </div>
    <%if (Model.Servidores.Count > 0){%>
                    <div class="table-responsive">
                            <table class="table table-bordered table-condensed table-hover">
                    <thead>
                    <tr><th>IP</th><th>Nombre</th><th>Ambiente</th><th>Descripción</th></tr>
                    </thead>
                    <tbody>                      
               <% foreach (Servidor p in Model.Servidores)
                {
                    string ruta = Url.Content("~/Servidor/Obtener/"+p.Ip);%>
                    
                  <tr><td><a href="<%=ruta %>"><%=p.Ip %></a></td><td><%=p.Nombre %></td><td><%=p.Ambiente.Nombre %></td><td><%=p.Descripcion %></td></tr>  
                <%}%>
                    </tbody>
                    </table>
                </div>
            <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
