﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>

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
            <div id="dialog-message" title="Informacion" style="font-size: small">
            </div>
            <%=Html.Partial("ListaConflicto") %>
            <form name="frmActualizarSolicitud" id="frmActualizarSolicitud" method="post" action="<%=Url.Content("~/Solicitud/Actualizar") %>" enctype="multipart/form-data" class="form-horizontal">
                <div class="row">
                    <div class="col-xs-offset-3 col-sm-offset-2 col-md-offset-3 col-lg-offset-2">
                        <%=Html.Partial("InformacionProyecto",Model.Solicitud.Proyecto) %>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">N° Solicitud:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <span><%=String.Concat("S",Model.Solicitud.Id.ToString().PadLeft(6,'0')) %></span>
                        <input type="hidden" name="txtNumeroSolicitud" id="txtNumeroSolicitud" value="<%=String.Concat("S",Model.Solicitud.Id.ToString().PadLeft(6,'0')) %>" />
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="hidden" name="cboAmbiente" value="<%=Model.Solicitud.Ambiente.Id %>" />
                        <a href="<%=Url.Content("~/Ambiente/Obtener/"+Model.Solicitud.Ambiente.Id) %>"><%=Model.Solicitud.Ambiente.Nombre %></a>
                    </div>
                </div>

                <div class="row">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Proyecto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="hidden" name="cboProyecto" value="<%=Model.Solicitud.Proyecto.Id %>" />
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
                <div class="form-group">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Copiar a (email1; email2):</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtInteresados" id="txtInteresados" class="form-control" maxlength="200" rows="5"><%=Model.Solicitud.CopiarA %></textarea>
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
                    <%=Model.Solicitud.RFC %>
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
                <div class="form-group">
                    <label for="cboAcion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Acción:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboAccion" name="cboAccion" class="form-control">
                            <%foreach (string accion in Model.Acciones)
                              { %>
                            <option value="<%=accion%>"><%=accion%></option>
                            <%} %>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="display: none;" id="divTipoObservacion">
                    <label for="cboObservacion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tipo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboObservacion" name="cboObservacion" class="form-control">
                            <option value="0" selected="selected"></option>
                            <%foreach (Observacion observacion in Model.Observaciones)
                              {%>
                            <option value="<%=observacion.Id %>"><%=observacion.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtComentario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Comentario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtComentario" id="txtComentario" class="form-control" rows="5"></textarea>
                    </div>
                </div>
                <div class="form-group" id="evidencia" style="display: none;">
                    <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Adjuntar Archivo:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="file" name="archivoComentario" id="archivoComentario" class="form-control archivo" />
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
                                        <tr>
                                            <th>N° Formulario</th>
                                            <th>Nombre Formulario</th>
                                            <th>Equipo Ejecutor</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%
                                            AreaRepository ar = new AreaRepository();
                                            List<Area> areas = ar.Listar("");
                                            areas.Insert(0, new Area { Id = 0, Nombre = "", Correos = new List<Correo>() });
                                            StringBuilder sb = new StringBuilder();
                                            string[] htmlAreas = new string[10];
                                            string urlBaseArchivo = "~/Home/ObtenerArchivo/S" + Model.Solicitud.Id.ToString().PadLeft(6, '0');
                                            string urlBaseArchivoLog = Url.Content("~/Home/ObtenerArchivoLog/");
                                            Solicitud sol = Model.Solicitud;
                                            for (int i = 1; i <= 10; i++)
                                            {
                                                Area a = i == 1 ? Model.Solicitud.Area1 : i == 2 ? Model.Solicitud.Area2 : i == 3 ? Model.Solicitud.Area3 : i == 4 ? Model.Solicitud.Area4 : i == 5 ? Model.Solicitud.Area5
                                                    : i == 6 ? Model.Solicitud.Area6 : i == 7 ? Model.Solicitud.Area7 : i == 8 ? Model.Solicitud.Area8 : i == 9 ? Model.Solicitud.Area9 : Model.Solicitud.Area10;
                                                sb.Clear();
                                                sb.Append("<select class='form-control' name='cboArchivo" + i + "' id='cboArchivo" + i + "'>");
                                                foreach (Area area in areas)
                                                {
                                                    sb.Append("<option value='" + area.Id + "'" + (a.Id == area.Id ? " selected>" : ">"));
                                                    sb.Append(area.Nombre);
                                                    sb.Append("</option>");
                                                }
                                                sb.Append("</select>");
                                                htmlAreas[i - 1] = sb.ToString();
                                            }

                                            for (var i = 1; i <= 10; i++)
                                            {
                                                Archivo archivo = i == 1 ? sol.Archivo1 : i == 2 ? sol.Archivo2 : i == 3 ? sol.Archivo3 : i == 4 ? sol.Archivo4 : i == 5 ? sol.Archivo5 : i == 6 ? sol.Archivo6 : i == 7 ? sol.Archivo7 : i == 8 ? sol.Archivo8 : i == 9 ? sol.Archivo9 : sol.Archivo10;
                                                %>
                                                <tr>
                                                    <td>Formulario <%=i%>:</td>
                                                    <td>
                                                        <a href='<%=Url.Content(urlBaseArchivo+"-"+i)%>'><%=archivo.Nombre%></a> 
                                                        <%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %> 
                                                        <%=Html.Partial("ImagenValidacion", new ArchivoView() {Archivo = archivo,Indicador = i,SolicitudId=Model.Solicitud.Id}) %>
                                                    </td>
                                                    <%=!String.IsNullOrEmpty(archivo.Nombre) ? "<td>" + htmlAreas[i-1] + "</td>" : "<td></td>"%>
                                                </tr>
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
                                    <thead>
                                        <tr>
                                            <th>Nombre Archivo</th>
                                            <th>Equipo Ejecutor</th>
                                        </tr>                                        
                                    </thead>
                                    <tbody>
                                        <%
                                            var contador = 0;
                                            foreach (Archivo archivo in Model.Solicitud.Aprobaciones)
                                          { 
                                              contador++;
                                              sb.Clear();
                                              %>
                                        <tr>
                                            <td>
                                                <a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+archivo.Id) %>'><%=archivo.Nombre %></a>
                                                <span><%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %> </span>
                                            </td>
                                            <td>
                                                <select class='form-control' name='cboAprobacion<%=contador%>'>
                                                <%
                                                foreach (Area area in areas)
                                                {
                                                    sb.Append("<option value='" + area.Id + "'"+((archivo.Area!=null && archivo.Area.Id==area.Id)?"selected":"")+" >");
                                                    sb.Append(area.Nombre);
                                                    sb.Append("</option>");
                                                } 
                                                %>
                                                <%=sb.ToString() %>
                                                </select>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane" id="tabs-3">
                            <%if (Model.Solicitud.Logs.Count > 0)
                              { %>
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr>
                                            <th>Estado</th>
                                            <th>Fecha Hora</th>
                                            <th>Comentario</th>
                                            <th>Usuario</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%foreach (Log log in Model.Solicitud.Logs)
                                          {%>
                                        <tr>
                                            <td><%=log.Estado %></td>
                                            <td><%=log.FechaHora.ToString("dd/MM/yyyy HH:mm:ss")%></td>
                                            <td><%=log.Comentario %> <%
                                            if (!String.IsNullOrEmpty(log.Archivo.Nombre))
                                            {
                                                string urlArchivoLog = urlBaseArchivoLog + log.Id.ToString();%>
                                                <a href="<%=urlArchivoLog %>">(Adjunto)</a>
                                                <%}
                                                %></td>
                                            <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=log.Usuario}) %></td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                            <%} %>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <%if (Model.Sistema.Estado != null && Model.Solicitud.Estado == Model.Sistema.Estado.Nombre)
                          {%><input type="button" class="btn btn-primary" value="Validar Objetos" id="btnValidarObjetos" data-solicitud="<%=Model.Solicitud.Id %>" />
                        <img id="progreso" style="display: none;" src="<%=Url.Content("~/img/progress.gif") %>" /><%} %>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div id="resultadoValidacion">
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" name="btnRMSolicitadoxSol" id="btnRMSolicitadoxSol" value="Actualizar" class="btn btn-primary" />
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
