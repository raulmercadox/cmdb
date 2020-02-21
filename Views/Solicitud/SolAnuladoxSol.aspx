<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Repository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos de la Solicitud</h3>
        </div>
        <div class="panel-body">
            <div id="dialog-message" title="Informacion" style="font-size:small">
            </div>
            <%=Html.Partial("ListaConflicto") %>
            <form name="frmActualizarSolicitud" id="frmActualizarSolicitud" action="#" class="form-horizontal"> 
                <div class="row">
                    <div class="col-xs-offset-3 col-sm-offset-2 col-md-offset-3 col-lg-offset-2">
                        <%=Html.Partial("InformacionProyecto",Model.Solicitud.Proyecto) %>
                    </div>
                </div>               
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">N° Solicitud:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=String.Concat("S",Model.Solicitud.Id.ToString().PadLeft(6,'0')) %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Ambiente:</label>   
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">                 
                        <a href="<%=Url.Content("~/Ambiente/Obtener/"+Model.Solicitud.Ambiente.Id) %>"><%=Model.Solicitud.Ambiente.Nombre %></a>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Proyecto:</label>       
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <a href='<%=Url.Content("~/Proyecto/Obtener/"+Model.Solicitud.Proyecto.Codigo) %>'><%=Model.Solicitud.Proyecto.Codigo %></a> - <%=Model.Solicitud.Proyecto.Nombre %>  
                    </div>
                </div>                
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Analista Desarrollo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.AnalistaDesarrollo %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Analista Test/Prod:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.AnalistaTestProd %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Copiar A:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.CopiarA %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Fecha Ejecucion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.FechaEjecucion.HasValue?Model.Solicitud.FechaEjecucion.Value.ToString("dd/MM/yyyy"):String.Empty %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Hora Ejecucion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.FechaEjecucion.HasValue?Model.Solicitud.FechaEjecucion.Value.ToString("HH:mm"):String.Empty %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">#RFC:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.RFC %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Emerg./Normal Urgente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.Emergente?"Si":"No" %></span>
                    </div>
                </div>
                <%if (Model.Solicitud.Emergente)
                  { %>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Razón del Emergente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.RazonEmergente%></span>
                    </div>
                </div>
                <%} %>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Regularización:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%=Model.Solicitud.Regularizacion?"Si":"No" %>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Fecha Reversion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.FechaReversion.HasValue?Model.Solicitud.FechaReversion.Value.ToString("dd/MM/yyyy"):String.Empty %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Reversión:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.Reversion?"Si":"No" %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Principal:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.Principal?"Si":"No" %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Adicional:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.Adicional?"Si":"No" %></span>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Estado:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=Model.Solicitud.Estado%></span>
                    </div>
                </div>
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Formularios</a></li>
                        <li role="presentation"><a href="#tabs-2" role="tab" data-toggle="tab">Otros Archivos (<%=Model.Solicitud.Aprobaciones.Count%>)</a></li>    
                        <li role="presentation"><a href="#tabs-3" role="tab" data-toggle="tab">Log</a></li>               
                    </ul>
                    <!-- Nav Panes -->
                    <div class="tab-content">
                        <div id="tabs-1" class="tab-pane active">
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr><th>N° Archivo</th><th>Nombre Archivo</th></tr>
                                </thead>
                        
                                <tbody>
                                <%
                                    string urlBaseArchivo = "~/Home/ObtenerArchivo/S" + Model.Solicitud.Id.ToString().PadLeft(6, '0');
                                    string urlBaseArchivoLog = Url.Content("~/Home/ObtenerArchivoLog/");
                                    Solicitud sol = Model.Solicitud;   
                                    for(var i=1; i<=10; i++)
                                    {
                                        Archivo archivo = i == 1 ? sol.Archivo1 : i == 2 ? sol.Archivo2 : i == 3 ? sol.Archivo3 : i == 4 ? sol.Archivo4 : i == 5 ? sol.Archivo5 : i == 6 ? sol.Archivo6 : i == 7 ? sol.Archivo7 : i == 8 ? sol.Archivo8 : i == 9 ? sol.Archivo9 : sol.Archivo10;
                                        %>
                                        <tr><td>Archivo <%=i %>:</td><td><a href='<%=Url.Content(urlBaseArchivo+"-"+i)%>'><%=archivo.Nombre%></a> <%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %> <%=Html.Partial("ImagenValidacion", new ArchivoView() {Archivo = archivo,Indicador = i,SolicitudId=Model.Solicitud.Id}) %></td></tr>
                                    <%}%>
                                </tbody>
                            </table>
                            </div>
                         </div>
                        <div id="tabs-2" class="tab-pane">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5>Lista de archivos:</h5>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                    <thead><tr><th>Archivo</th></tr></thead>
                                    <tbody>
                                    <%foreach(Archivo archivo in Model.Solicitud.Aprobaciones){ %>
                                        <tr><td><a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+archivo.Id) %>'><%=archivo.Nombre %></a> <span><%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %></span></td></tr>
                                    <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div id="tabs-3" class="tab-pane">
                            <%if(Model.Solicitud.Logs.Count>0){ %>
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr><th>Estado</th><th>Fecha Hora</th><th>Comentario</th><th>Usuario</th></tr>
                                    </thead>
                                    <tbody>
                                        <%foreach (Log log in Model.Solicitud.Logs)
                                          {%>
                                          <tr><td><%=log.Estado %></td><td><%=log.FechaHora.ToString("dd/MM/yyyy HH:mm:ss")%></td><td><%=log.Comentario %> <%
                                              if (!String.IsNullOrEmpty(log.Archivo.Nombre))
                                              {
                                                  string urlArchivoLog = urlBaseArchivoLog + log.Id.ToString();%>
                                                  <a href="<%=urlArchivoLog %>">(Adjunto)</a>
                                              <%}
                                              %></td><td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=log.Usuario}) %></td></tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                            <%} %>                
                        </div>
                    </div>
                </div>
                
            </form>
        </div>
        <div class="panel-footer">

        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %>
        <div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!--[if lt IE 9]><!-->
        <script src="<%=Url.Content("~/js/vendor/excanvas.js")%>"></script>
    <!--<![endif]-->
    <script src="<%=Url.Content("~/js/vendor/flotr2.js")%>"></script>
    <script src="<%=Url.Content("~/js/solicitud.js")%>"></script>
</asp:Content>