<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SolicitudView>" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <%
        CMDBApplication.Repository.VentanaRepository vr = new CMDBApplication.Repository.VentanaRepository();
        List<Ventana> ventanas = vr.Listar();
        int horaActual = DateTime.Now.Hour;
        int minutoActual = DateTime.Now.Minute;
        int minutosTotales = horaActual * 60 + minutoActual;
        int horaPase = 0;
        int minutoPase = 0;
        bool esMenor = false;
        foreach (Ventana v in ventanas)
        {
            int minutosVentana = v.Desde.Hour * 60 + v.Desde.Minute;
            if (minutosTotales < minutosVentana)
            {
                esMenor = true;
                horaPase = v.Desde.Hour;
                minutoPase = v.Desde.Minute;
                break;
            }
        }
        if (!esMenor && ventanas.Count>0)
        {
            horaPase = ventanas[0].Desde.Hour;
            minutoPase = ventanas[0].Desde.Minute;
        }
        
        StringBuilder sbHora = new StringBuilder();
        StringBuilder sbMinuto = new StringBuilder();
        sbHora.Append("<option value=''> </option>");
        sbMinuto.Append("<option value=''> </option>");
        for(int i=0;i<=23;i++){
            if (i == horaPase)
            {
                sbHora.Append("<option value='" + i.ToString() + "' selected='selected'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }
            else
            {
                sbHora.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }
        }
        for (int i = 0; i <= 59; i++)
        {
            if (i == minutoPase)
            {
                sbMinuto.Append("<option value='" + i.ToString() + "' selected='selected'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }
            else
            {
                sbMinuto.Append("<option value='" + i.ToString() + "'>" + i.ToString().PadLeft(2, '0') + "</option>");
            }
        }
    %>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Nueva Solicitud</h3>
        </div>
        <div class="panel-body">
            <form name="frmCrearSolicitud" id="frmCrearSolicitud" method="post" action="<%=Url.Content("~/Solicitud/Crear") %>" enctype="multipart/form-data" class="form-horizontal">    
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <select class="form-control" id="cboAmbiente" name="cboAmbiente">
                    <% foreach (Ambiente ambiente in Model.Ambientes)
                       {%>
                          <option value="<%=ambiente.Id %>"><%=ambiente.Nombre%></option>
                      <%}%>
                    </select>
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Proyecto:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" value="<%=Model.Solicitud.Proyecto.Codigo %>" class="form-control codigoproyecto" maxlength="30"/><label id="lblDescripcionProyecto"><%=Model.Solicitud.Proyecto.Nombre %></label>
                         <div id="divAmbientes">
                        <%if (Model.Solicitud.Proyecto != null && Model.Solicitud.Proyecto.Ambientes != null)
                          {
                              foreach (ProyectoAmbiente pa in Model.Solicitud.Proyecto.Ambientes)
                              { %>
                        <input type="hidden" class="proyectoambiente" id="ambiente-<%=pa.Ambiente.Id%>" value="<%=pa.FechaPase.ToString("yyyyMMdd")%>" />
                        <%}
                          } %>
                        </div>
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaDesarrollo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Desarrollo (email):</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="email" name="txtAnalistaDesarrollo" id="txtAnalistaDesarrollo" class="form-control" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtAnalistaTestProd" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Analista Test/Prod (email):</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="email" name="txtAnalistaTestProd" id="txtAnalistaTestProd" class="form-control" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtInteresados" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Copiar a (email1; email2):</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <textarea name="txtInteresados" id="txtInteresados" class="form-control" maxlength="200" rows="5"></textarea>
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtFechaEjecucion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha Ejecucion:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" name="txtFechaEjecucion" id="txtFechaEjecucion" class="form-control fecha" value="<%=DateTime.Now.ToString("dd/MM/yyyy") %>" readonly="readonly" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="cboHora" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Hora Ejecución:</label>
                     <div class="col-xs-6 col-sm-5 col-md-4 col-lg-1">
                        <select class="form-control" id="cboHora" name="cboHora"><%=sbHora.ToString() %></select>
                     </div>
                </div>
                <div class="form-group">
                    <label for="cboMinuto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Minuto Ejecución:</label>
                     <div class="col-xs-6 col-sm-5 col-md-4 col-lg-1">
                        <select class="form-control" id="cboMinuto" name="cboMinuto"><%=sbMinuto.ToString() %></select>
                     </div>
                </div>
                <div class="form-group">
                    <label for="txtRFC" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">#RFC:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" name="txtRFC" id="txtRFC" class="form-control" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="chkEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Emerg./Normal Urgente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkEmergente" id="chkEmergente" aria-label="Emergenca" />
                                Marcar cuando la solicitud sea de emergencia o normal urgente.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group razonemergente" id="#razonemergente">
                    <label for="txtRazonEmergente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Razón del Emergente:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <textarea name="txtRazonEmergente" id="txtRazonEmergente" class="form-control" maxlength="200" rows="5"></textarea>
                     </div>
                </div>
                <div class="form-group">
                    <label for="chkRegularizacion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Regularización:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkRegularizacion" id="chkRegularizacion" aria-label="regularización" />
                                Marcar cuando la solicitud sea de regularización.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group fechareversion">
                    <div class="col-xs-offset-3 col-xs-9 col-sm-offset-2 col-sm-9 col-md-offset-3 col-md-8 col-lg-offset-2 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkFechaReversion" id="chkFechaReversion" aria-label="marca de fecha de reversión"/>
                                Marcar cuando se tenga una fecha de reversión.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group fechareversion">
                     <label for="txtFechaReversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Fecha Reversion:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <input type="text" id="txtFechaReversion" name="txtFechaReversion" class="form-control fecha" readonly="readonly" disabled/>
                     </div>
                </div>
                 <div class="form-group">
                    <label for="chkReversion" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Reversión:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkReversion" id="chkReversion" aria-label="reversión" />
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
                                <input type="checkbox" name="chkPrincipal" id="chkPrincipal" aria-label="principal" />
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
                                <input type="checkbox" name="chkAdicional" id="chkAdicional" aria-label="adicional" />
                                Marcar cuando la solicitud contenga el onceavo formulario o mas.
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtComentario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Comentario:</label>
                     <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                         <textarea name="txtComentario" id="txtComentario" class="form-control" rows="5"></textarea>
                     </div>
                </div>
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#formularios" aria-controls="formularios" role="tab" data-toggle="tab">Formularios</a></li>
                        <li role="presentation"><a href="#aprob" aria-controls="aprob" role="tab"  data-toggle="tab">Otros Archivos</a></li>
                    </ul>

                    <!-- Nav Panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="formularios">
                            <%for(var i=1; i<=10; i++){ %>
                                <div class="form-group">
                                    <label for="txtArchivo<%=i %>" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Formulario <%=i %>: </label>
                                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                        <input type="file" name="txtArchivo<%=i %>" id="txtArchivo<%=i %>" class="form-control archivo formulario"/> 
                                    </div>
                                    
                                </div>
                            <%} %>
                            <div class="form-group">
                                <label class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label"> </label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6"><a id="btnLimpiarFormulario" class="btn btn-primary">Limpiar Formularios</a></div>
                            </div>
                        </div>

                        <div role="tabpanel" class="tab-pane" id="aprob">
                            <div class="row">
                                <div class="col-xs-12"><h5>Especifique aquí archivos que no sean formularios.</h5></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12"><h5>Lista de archivos:</h5></div>
                            </div>
                            <div class="table-responsive">
                                <table id="aprobaciones" class="table table-bordered table-condensed table-hover">
                                    <thead>
                                        <tr>
                                            <th>Reemplazar Archivo</th><th>Archivo Actual</th>
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
                                            <td><input type="hidden" name="nombreaprob<%=contador %>" id="nombreaprob<%=contador %>" value="<%=archivo.Id %>" /><input type="file" name="txtAprobacion<%=contador%>" id="txtAprobacion<%=contador %>" class="form-control" /></td>
                                            <td><a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+archivo.Id) %>'><%=archivo.Nombre %></a></td>
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
                    </div>
                </div>
                
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnCrearSolicitud" id="btnCrearSolicitud" value="Crear" />
        </div>
    </div>
    <%if(!String.IsNullOrEmpty(Model.Sistema.MensajeCrearSolicitud)){ %>
        <div class="alert alert-danger" role="alert"><%=Model.Sistema.MensajeCrearSolicitud %></div>
    <%} %>
    <%if(!String.IsNullOrEmpty(Model.Mensaje)){ %>
        <div class="alert alert-info" role="alert"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
