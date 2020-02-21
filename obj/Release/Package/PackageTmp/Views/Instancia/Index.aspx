<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.InstanciaView>" %>

<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Instancias de BD</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoInstancia" id="frmCatalogoInstancia" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtNombreInstancia" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombreInstancia" id="txtNombreInstancia" class="form-control" value="<%=Model.Instancia.Nombre %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboServidor" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Servidor:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboServidor" name="cboServidor">
                            <% foreach (Servidor servidor in Model.Servidores)
                               {
                                   if (Model.Instancia.Servidor != null && servidor.Id == Model.Instancia.Servidor.Id)
                                   {%>

                            <option value="<%=servidor.Id %>" selected="selected"><%=servidor.Ip%> <%=String.IsNullOrEmpty(servidor.Nombre)?"":"(" %><%=servidor.Nombre%><%=String.IsNullOrEmpty(servidor.Nombre)?"":")" %></option>
                            <%}
                                   else
                                   { %>
                            <option value="<%=servidor.Id %>"><%=servidor.Ip%> <%=String.IsNullOrEmpty(servidor.Nombre)?"":"(" %><%=servidor.Nombre%><%=String.IsNullOrEmpty(servidor.Nombre)?"":")" %></option>
                            <%}
                               }%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                            <% foreach (Ambiente ambiente in Model.Ambientes)
                               {
                                   if (Model.Instancia.Ambiente != null && ambiente.Id == Model.Instancia.Ambiente.Id)
                                   {%>

                            <option value="<%=ambiente.Id %>" selected="selected"><%=ambiente.Nombre%></option>
                            <%}
                                   else
                                   { %>
                            <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                            <%}
                               }%>
                        </select>
                    </div>
                </div>
            </form>
           
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarInstancia" id="btnConsultarInstancia" value="Consultar" />
            <a href="<%=Url.Content("~/Instancia/Crear") %>">Crear Instancia</a>
        </div>
    </div>
     <%if (Model.Instancias.Count > 0)
        {%>
        <div class="table-responsive">
            <table class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Servidor</th>
                        <th>Ambiente</th>
                        <th>Instancia Anterior</th>
                        <th>Repositorio Subversion</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (Instancia p in Model.Instancias)
                        {
                            CMDBApplication.Repository.InstanciaRepository ir = new CMDBApplication.Repository.InstanciaRepository();
                            string ruta = Url.Content("~/Instancia/Obtener/" + p.Nombre);
                            string rutaServidor = Url.Content("~/Servidor/Obtener/" + p.Servidor.Ip);
                            string rutaAmbiente = Url.Content("~/Ambiente/Obtener/" + p.Ambiente.Id);
                            Instancia instanciaAnterior = p.InstanciaAnterior != null ? ir.Obtener(p.InstanciaAnterior.Id) : null;                      
                    %>

                    <tr>
                        <td><a href="<%=ruta %>"><%=p.Nombre %></a></td>
                        <td><a href="<%=rutaServidor %>"><%=p.Servidor.Ip %></a> (<%=p.Servidor.Nombre %>)</td>
                        <td><a href="<%=rutaAmbiente %>"><%=p.Ambiente.Nombre %></a></td>
                        <td><%=instanciaAnterior!=null?instanciaAnterior.Nombre:"" %></td>
                        <td><%=p.RepositorioSubversion %></td>
                    </tr>
                    <%}%>
                </tbody>
            </table>
        </div>
    <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
