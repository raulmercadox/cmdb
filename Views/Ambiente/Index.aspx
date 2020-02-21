<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.AmbienteView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Catálogo de Ambientes</h3>
        </div>
        <div class="panel-body">
            <form name="frmCatalogoAmbiente" id="frmCatalogoAmbiente" method="post" class="form-horizontal"> 
                <div class="form-group">
                    <label for="txtNombreAmbiente" class="col-xs-2 col-sm-2 col-lg-1 control-label">Nombre:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" class="form-control" placeholder="Nombre del Ambiente" name="txtNombreAmbiente" id="txtNombreAmbiente" value="<%=Model.Ambiente.Nombre %>" autofocus/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkFechaObligatoria" class="col-xs-2 col-sm-2 col-lg-1 control-label">Fecha de Pase:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label><input type="checkbox" name="chkFechaObligatoria" id="chkFechaObligatoria" <%=Model.Ambiente.FechaObligatoria?"checked='checked'":String.Empty %> aria-label="Fecha Obligatoria"/></label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkApruebaCalidad" class="col-xs-2 col-sm-2 col-lg-1 control-label">Aprueba Calidad:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label><input type="checkbox" name="chkApruebaCalidad" id="chkApruebaCalidad" <%=Model.Ambiente.ApruebaCalidad?"checked='checked'":String.Empty %>/></label>
                        </div>
                    </div>
                </div>
                
                <div class="form-group">
                    <label for="chkEnvioPrimeraSolicitud" class="col-xs-2 col-sm-2 col-lg-1 control-label">Envío 1ra Solicitud:</label>
                    <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label><input type="checkbox" name="chkEnvioPrimeraSolicitud" id="chkEnvioPrimeraSolicitud" <%=Model.Ambiente.EnvioPrimeraSolicitud?"checked='checked'":String.Empty %>/></label>
                        </div>
                    </div>
                </div>
            </form>
            

        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnConsultarAmbiente" id="btnConsultarAmbiente" value="Consultar" /> <a class="btn btn-link" href="<%=Url.Content("~/Ambiente/Crear") %>">Crear Ambiente</a>
        </div>
        
    </div>
    <%if(!String.IsNullOrEmpty(Model.Mensaje)){ %>
    <div class="alert alert-info" role="alert"><%=Model.Mensaje %></div>
    <%} %>

                <%if (Model.Ambientes.Count > 0){%>
            <div class="table-responsive">
            <table class="table table-bordered table-condensed table-hover">
            <thead>
            <tr><th>Nombre</th><th>Abreviatura</th><th>Orden</th><th>Final</th><th>Requiere Fecha de Pase</th><th>Aprueba Calidad</th><th>Envio 1ra Solicitud</th></tr>
            </thead>
            <tbody>                      
                <% foreach (Ambiente a in Model.Ambientes)
                {
                    string ruta = Url.Content("~/Ambiente/Obtener/"+a.Id);%>
                    
                    <tr><td><a class="btn btn-link" href="<%=ruta %>"><%=a.Nombre %></a></td><td><%=a.Abreviatura %></td><td><%=a.Orden %></td><td><%=a.Final?"Si":String.Empty %></td><td><%=a.FechaObligatoria?"SI":String.Empty %></td><td><%=a.ApruebaCalidad?"SI":String.Empty %></td><td><%=a.EnvioPrimeraSolicitud?"SI":String.Empty %></td></tr>  
                <%}%>
            </tbody>
            </table>
            </div>
            <%}%>

</asp:Content>
