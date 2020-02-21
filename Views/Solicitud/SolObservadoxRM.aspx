<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Repository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     
    <%
        string nombreUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
        Usuario usuario = new UsuarioRepository().Obtener(nombreUsuario);        
        bool esUsuarioSolicitante = usuario.Id == Model.Solicitud.Solicitante.Id;
        bool usuarioObservado = esUsuarioSolicitante && Model.Solicitud.Estado == "Observado_x_RM";
        StringBuilder sbHora = new StringBuilder();
        StringBuilder sbMinuto = new StringBuilder();
        sbHora.Append("<option value=''> </option>");
        sbMinuto.Append("<option value=''> </option>");
        for(int i=0;i<=23;i++){
            if (Model.Solicitud.FechaEjecucion.HasValue)
            {
                if (Model.Solicitud.FechaEjecucion.Value.Hour == i)
                {
                    sbHora.Append("<option selected='selected' value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
                }
                else
                {
                    sbHora.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
                }
            }
            else
            {
                sbHora.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }            
        }
        for (int i = 0; i <= 59; i++)
        {
            if (Model.Solicitud.FechaEjecucion.HasValue)
            {
                if (Model.Solicitud.FechaEjecucion.Value.Minute == i)
                {
                    sbMinuto.Append("<option selected='selected' value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
                }
                else
                {
                    sbMinuto.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
                }
            }
            else
            {
                sbMinuto.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }            
        }
    %>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos de la Solicitud</h3>
        </div>
        <div class="panel-body">
            <div id="dialog-message" title="Informacion" style="font-size:small">
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
                        <%=String.Concat("S", Model.Solicitud.Id.ToString().PadLeft(6, '0'))%>
                        <input type="hidden" name="txtNumeroSolicitud" id="txtNumeroSolicitud" value="<%=String.Concat("S",Model.Solicitud.Id.ToString().PadLeft(6,'0')) %>"/>
                    </div>                    
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label> 
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">                   
                        <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                        <% foreach (Ambiente ambiente in Model.Ambientes)
                           {%>
                              <option value="<%=ambiente.Id %>" <%=Model.Solicitud.Ambiente.Id==ambiente.Id?"Selected='Selected'":"" %>><%=ambiente.Nombre%></option>
                          <%}%>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Proyecto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" value="<%=Model.Solicitud.Proyecto.Codigo %>" class="form-control codigoproyecto" maxlength="30"/> <label id="lblDescripcionProyecto"><%=Model.Solicitud.Proyecto.Nombre %></label>
                        <div id="divAmbientes">
                            <%foreach(ProyectoAmbiente pa in Model.Solicitud.Proyecto.Ambientes){ %>
                            <input type="hidden" class="proyectoambiente" id="ambiente-<%=pa.Ambiente.Id %>" value="<%=pa.FechaPase.ToString("yyyyMMdd") %>" />
                            <%} %>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaDesarrollo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Desarrollo(email):</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAnalistaDesarrollo" id="txtAnalistaDesarrollo" class="form-control" value="<%=Model.Solicitud.AnalistaDesarrollo %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaTestProd" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Test/Prod(email):</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtAnalistaTestProd" id="txtAnalistaTestProd" class="form-control" value="<%=Model.Solicitud.AnalistaTestProd %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtInteresados" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Copiar a(email1;email2):</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtInteresados" id="txtInteresados" class="form-control" maxlength="200" rows="5"><%=Model.Solicitud.CopiarA %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaEjecucion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha Ejecucion:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtFechaEjecucion" id="txtFechaEjecucion" class="form-control fecha" value="<%=Model.Solicitud.FechaEjecucion.HasValue?Model.Solicitud.FechaEjecucion.Value.ToString("dd/MM/yyyy"):String.Empty %>" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboHora" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hora Ejecución:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboHora" name="cboHora" class="form-control"><%=sbHora.ToString() %></select> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboMinuto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Minuto Ejecución:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboMinuto" name="cboMinuto" class="form-control"><%=sbMinuto.ToString() %></select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtRFC" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">#RFC:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtRFC" id="txtRFC" class="form-control"  value="<%=Model.Solicitud.RFC%>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 text-right">Emerg./Normal Urgente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="checkbox" name="chkEmergente" id="chkEmergente"  <%=Model.Solicitud.Emergente?"checked='checked'":"" %> />
                    </div>
                </div>
                <div class="form-group razonemergente" style='display:<%=Model.Solicitud.Emergente?"block":"none"%>;'>
                    <label for="txtRazonEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Razón del Emergente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <textarea name="txtRazonEmergente" id="txtRazonEmergente" class="form-control" maxlength="200" rows="5"><%=Model.Solicitud.RazonEmergente %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkRegularizacion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Regularización:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkRegularizacion" id="chkRegularizacion" <%=Model.Solicitud.Regularizacion?"checked='checked'":"" %> aria-label="regularización" />
                                Marcar cuando la solicitud sea de regularización.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group fechareversion" <%=Model.Solicitud.Proyecto.Mejora?String.Empty:"style='display:none;'" %>>
                    <!--<label for="chkFechaReversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tiene fecha Reversion:</label>-->
                    <div class="col-xs-offset-3 col-xs-9 col-sm-offset-2 col-sm-9 col-md-offset-3 col-md-8 col-lg-offset-2 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFechaReversion" id="chkFechaReversion" <%=Model.Solicitud.FechaReversion.HasValue?"checked='checked'":String.Empty %>/> 
                                Marcar cuando se tenga una fecha de reversión.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group fechareversion" <%=Model.Solicitud.Proyecto.Mejora?String.Empty:"style='display:none;'" %>>
                     <label for="txtFechaReversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha Reversion:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" id="txtFechaReversion" name="txtFechaReversion" class="form-control fecha" readonly="readonly" <%=Model.Solicitud.FechaReversion.HasValue?String.Empty:"disabled='disabled'" %>  value="<%=Model.Solicitud.FechaReversion.HasValue?Model.Solicitud.FechaReversion.Value.ToString("dd/MM/yyyy"):String.Empty %>"/>
                     </div>
                </div>
                <div class="form-group">
                    <label for="chkReversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Reversión:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkReversion" id="chkReversion" <%=Model.Solicitud.Reversion?"checked='checked'":"" %> />
                                Marcar cuando la solicitud esté realizado una reversión de cambios.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkPrincipal" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Principal:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkPrincipal" id="chkPrincipal"  <%=Model.Solicitud.Principal?"checked='checked'":"" %> />
                                Marcar cuando la solicitud represente al pase principal
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkAdicional" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Adicional:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkAdicional" id="chkAdicional"  <%=Model.Solicitud.Adicional?"checked='checked'":"" %> />
                                Marcar cuando la solicitud contenga el onceavo formulario o mas.
                            </label>
                        </div>
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
                        <div role="tabpanel" class="tab-pane active" id="tabs-1">
                            <div class="table-responsive">
                                <table class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr><th>N° Formulario</th><th>Nombre Formulario</th><th>Reemplazar Formulario</th></tr>
                                    </thead>
                                    <tbody>                    
                                    <%
                                    string urlBase = Url.Content("~/Home/ObtenerArchivo/S" + Model.Solicitud.Id.ToString().PadLeft(6, '0'));
                                    string urlBaseArchivoLog = Url.Content("~/Home/ObtenerArchivoLog/");
                                    Solicitud sol = Model.Solicitud;
                                    for (var i = 1; i <= 10; i++)
                                    {
                                        Archivo archivo = i == 1 ? sol.Archivo1 : i == 2 ? sol.Archivo2 : i == 3 ? sol.Archivo3 : i == 4 ? sol.Archivo4 : i == 5 ? sol.Archivo5 : i == 6 ? sol.Archivo6 : i == 7 ? sol.Archivo7 : i == 8 ? sol.Archivo8 : i == 9 ? sol.Archivo9 : sol.Archivo10;
                                        %>
                                        <tr><td>Formulario <%=i %>:<input type="hidden" name="nombrearch<%=i %>" id="nombrearch<%=i %>" value="<%=archivo.Nombre%>" /></td><td><a href='<%=urlBase+"-"+i%>'><%=archivo.Nombre%></a> <span><%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %></span> <%=!String.IsNullOrEmpty(archivo.Nombre) ? "<span id='p"+i+"' class='puntero eliminararchivo'>(Eliminar)</span>" : ""%> <%=Html.Partial("ImagenValidacion", new ArchivoView() {Archivo = archivo,Indicador = i,SolicitudId=Model.Solicitud.Id}) %></td><td><input type='file' name='txtArchivo<%=i %>' id='txtArchivo<%=i %>' class="subearchivo archivo form-control formulario" /></td></tr>
                                    <%}%>
                                    </tbody>
                                 </table>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6"><a id="btnLimpiarFormulario" class="btn btn-primary">Limpiar Formularios</a></div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabs-2">
                            <div class="row">
                                <div class="col-xs-12"><h5>Especifique aquí archivos de correo que representen aprobaciones para el pase solicitado. Esto normalmente aplica para pases emergentes.</h5></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12"><h5>Lista de archivos:</h5></div>
                            </div>
                            <div class="table-responsive">
                                <table id="aprobaciones" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr>
                                            <th>Reemplazar archivo</th><th>Archivo actual</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%
                                            int contador = 0;
                                            foreach (Archivo archivo in Model.Solicitud.Aprobaciones)
                                            {
                                              contador++;
                                        %>
                                        <tr>
                                            <td><input type="hidden" name="nombreaprob<%=contador %>" id="nombreaprob<%=contador %>" value="<%=archivo.Id %>" /><input type="file" name="txtAprobacion<%=contador%>" id="txtAprobacion<%=contador %>" class="subeaprobacion form-control" /></td>
                                            <td>
                                                <a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+archivo.Id) %>'><%=archivo.Nombre %></a>
                                                <span><%=archivo.Fecha.HasValue?"("+archivo.Fecha.Value.ToString("dd/MM/yyyy HH:mm:ss")+")":String.Empty %></span>
                                                <%=!String.IsNullOrEmpty(archivo.Nombre) ? "<span id='o"+contador+"' class='puntero eliminaraprobacion'>(Eliminar)</span>" : ""%>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="button" class="btn btn-primary" name="btnAgregarAprobacion" id="btnAgregarAprobacion" value=" + " />
                                </div>
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
                    <div class="col-xs-offset-3 col-xs-9 col-sm-offset-2 col-sm-9 col-md-offset-3 col-md-8 col-lg-offset-2 col-lg-6">
                        <%if (Model.Sistema.Estado != null && Model.Solicitud.Estado == Model.Sistema.Estado.Nombre)
                          {%><input type="button" class="btn btn-primary" value="Validar Objetos" id="Button1" data-solicitud="<%=Model.Solicitud.Id %>" />
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
            <input type="button" name="btnSolObservadoxRM" id="btnSolObservadoxRM" value="Actualizar" class="btn btn-primary"/>
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %> <div class="alert alert-info"><%=Model.Mensaje %></div> <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!--[if lt IE 9]><!-->
        <script src="<%=Url.Content("~/js/vendor/excanvas.js")%>"></script>
    <!--<![endif]-->
    <script src="<%=Url.Content("~/js/vendor/flotr2.js")%>"></script>
    <script src="<%=Url.Content("~/js/solicitud.js")%>"></script>
</asp:Content>