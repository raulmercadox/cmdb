<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SistemaView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Sistema</h3>
        </div>
        <div class="panel-body">
            <form name="frmDatosSistema" id="frmDatosSistema" method="post" action="<%=Url.Content("~/Sistema/ActualizarSistema") %>" class="form-horizontal">
                <div>
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tabs-1" role="tab" data-toggle="tab">Creacion de Solicitud</a></li>
                        <li role="presentation"><a href="#tabs-2" role="tab" data-toggle="tab">Oracle</a></li>
                        <li role="presentation"><a href="#tabs-3" role="tab" data-toggle="tab">Validacion de Objetos</a></li>
                        <li role="presentation"><a href="#tabs-4" role="tab" data-toggle="tab">General</a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="tabs-1" role="tabpanel" class="tab-pane active">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Cuando se crea una solicitud cuyo proyecto pasa por primera vez a un ambiente, informar a los siguientes correos BCC (correo1@hp.com;correo2@hp.com):</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <textarea name="txtPrimeraSolicitud" id="txtPrimeraSolicitud" class="form-control" maxlength="400" rows="5"><%=Model.Sistema.PrimeraSolicitud %></textarea>
                                </div>
                            </div>

                        </div>
                        <div id="tabs-2" role="tabpanel" class="tab-pane">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Especificar la cadena de conexion para el extract de los objetos de BD de Oracle:</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <textarea name="txtOracleDBUExtractConexion" id="txtOracleDBUExtractConexion" class="form-control" rows="5"><%=Model.Sistema.OracleDBUExtractConexion %></textarea>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="button" class="btn btn-primary" name="btnComprobarConexion" id="btnComprobarConexion" value="Comprobar Conexión" />
                                    <img id="progreso" style="display: none;" src="<%=Url.Content("~/img/progress.gif") %>" />
                                    <span id="resultadoConexion"></span>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-3" role="tabpanel" class="tab-pane">

                            <div class="form-group">
                                <label for="cboEstado" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Estado boton Validar Objeto:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <select id="cboEstado" name="cboEstado" class="form-control">
                                        <option value="0" <%=(Model.Sistema.Estado!=null && Model.Sistema.Estado.Id==0)?"selected='selected'":String.Empty %>></option>
                                        <% foreach (CMDBApplication.Models.Estado estado in Model.Estados)
                                           { %>
                                        <option value="<%=estado.Id %>" <%=(Model.Sistema.Estado!=null && estado.Id==Model.Sistema.Estado.Id)?"selected='selected'":String.Empty %>><%=estado.Nombre %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtCarpetaTrabajo" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Carpeta de Trabajo:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtCarpetaTrabajo" value="<%=Model.Sistema.CarpetaTrabajo %>" class="form-control" />
                                </div>
                            </div>

                        </div>
                        <div id="tabs-4" role="tabpanel" class="tab-pane">
                            <div class="form-group">
                                <label for="txtCorreoCMS" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Correo CMS:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtCorreoCMS" value="<%=Model.Sistema.CorreoCMS %>" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtResponderA" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Responder a:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtResponderA" value="<%=Model.Sistema.ResponderA %>" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCopiarExcelA" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Copiar Excel a:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtCopiarExcelA" value="<%=Model.Sistema.CopiarExcelA %>" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFolderPre" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Carpeta Pre:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtFolderPre" value="<%=Model.Sistema.FolderPre %>" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFolderDML" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Carpeta DML:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <input type="text" name="txtFolderDML" value="<%=Model.Sistema.FolderDML %>" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtMensajeCrearSolicitud" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Mensaje al Crear Solicitud:</label>
                                <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                                    <textarea class="form-control" name="txtMensajeCrearSolicitud"><%=Model.Sistema.MensajeCrearSolicitud %></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" id="btnActualizarSistema" name="btnActualizarSistema" value="Grabar Cambios" />
        </div>
    </div>
    <%if (!String.IsNullOrEmpty(Model.Mensaje))
      { %><div class="alert alert-info"><%=Model.Mensaje %></div>
    <%} %>
</asp:Content>
