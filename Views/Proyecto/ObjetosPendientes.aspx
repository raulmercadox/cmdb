<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ProyectoView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Objetos Pendientes</h3>
        </div>
        <div class="panel-body">
            <h4>Lista de objetos que aún no han pasado al ambiente posterior</h4>
            <form name="frmListarObjetos" id="frmListarObjetos" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="txtCodigoProyecto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Proyecto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtCodigoProyecto" id="txtCodigoProyecto" value="<%=Model.Proyecto.Codigo %>" class="form-control codigoproyecto" maxlength="30" autofocus/> 
                        <label id="lblDescripcionProyecto"><%=Model.Proyecto.Nombre %></label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboAmbiente" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Ambiente:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboAmbiente" name="cboAmbiente" class="form-control">
                            <%foreach(Ambiente ambiente in Model.Ambientes){ %>
                            <option <%=(Model.Ambiente!=null && Model.Ambiente.Id==ambiente.Id)?"selected='selected'":String.Empty %> value="<%=ambiente.Id %>"><%=ambiente.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cboTipoFormulario" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tipo Formulario:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select id="cboTipoFormulario" name="cboTipoFormulario" class="form-control">
                            <option value="0"></option>
                            <option value="1" <%=Model.TipoFormulario==1?"selected='selected'":String.Empty %>>Objetos BD</option>
                            <option value="2" <%=Model.TipoFormulario==2?"selected='selected'":String.Empty %>>Configuracion BD</option>
                        </select>
                    </div>
                </div>                
             </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnListarObjetos" id="btnListarObjetos" value="Listar Objetos"/>
        </div>
    </div>
    <%if (Model.Campos != null && Model.Campos.Count > 0){%>
        <h4>Campos de Tabla</h4>            
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr><th>Instancia</th><th>Esquema</th><th>Tipo Accion</th><th>Tabla</th><th>Campo</th><th>Tipo</th><th>Solicitud</th><th>Fecha Hora</th></tr>
            </thead>
            <tbody>
                <%foreach (SolicitudBDCampo objetoBD in Model.Campos){%>
                    <tr><td><%=objetoBD.Instancia.Nombre %></td><td><%=objetoBD.Esquema.Nombre %></td><td><%=objetoBD.TipoAccionBD.Nombre %></td><td><%=objetoBD.NombreTabla %></td><td><%=objetoBD.NombreColumna %></td><td><%=objetoBD.Tipo %></td><td><a href="<%=Url.Content("~/Solicitud/Obtener/"+String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0'))) %>"><%=String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0')) %></a></td><td><%=objetoBD.FechaHora.ToString("dd/MM/yyyy HH:mm:ss") %> <%=objetoBD.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></td></tr> 
                <%}%>
            </tbody>
        </table>
        </div>
        <!--<%=Model.Campos.Count %> Registros -->
    <%}%>

    <%if (Model.ObjetosBD != null && Model.ObjetosBD.Count > 0){%>
        <h4>Objetos de BD</h4>
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr><th>Instancia</th><th>Esquema</th><th>Tipo Objeto</th><th>Tipo Accion</th><th>Objeto</th><th>Informacion Adicional</th><th>Solicitud</th><th>Fecha Hora</th></tr>
            </thead>
            <tbody>
            <%foreach (ObjetoBD objetoBD in Model.ObjetosBD){%>
            <tr><td><%=objetoBD.Instancia.Nombre %></td><td><%=objetoBD.Esquema!=null?objetoBD.Esquema.Nombre:"" %></td><td><%=objetoBD.TipoObjeto.Nombre %></td><td><%=objetoBD.TipoAccion.Nombre %></td><td><%=objetoBD.Nombre %></td><td><%=objetoBD.InformacionAdicional %></td><td><a href="<%=Url.Content("~/Solicitud/Obtener/"+String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0'))) %>"><%=String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0')) %></a></td><td><%=objetoBD.FechaHora.ToString("dd/MM/yyyy HH:mm:ss") %> <%=objetoBD.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></td></tr> 
            <%}%>
            </tbody>
        </table>
        </div>
        <!--<%=Model.ObjetosBD.Count %> Registros -->
    <%}%>

    <%if (Model.PermisosDBU != null && Model.PermisosDBU.Count > 0){%>
        <h4>Permisos DBU</h4>
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr><th>User DBU</th><th>Instancia</th><th>Esquema</th><th>Tipo Objeto</th><th>Objeto</th><th>Select</th><th>Insert</th><th>Delete</th><th>Update</th><th>Execute</th><th>Solicitud</th><th>Fecha Hora</th></tr>
            </thead>
            <tbody>
            <%foreach (SolicitudBDPermisoDBU objetoBD in Model.PermisosDBU){%>
            <tr><td><%=objetoBD.UserDBU %></td><td><%=objetoBD.Instancia.Nombre %></td><td><%=objetoBD.Esquema.Nombre %></td><td><%=objetoBD.TipoObjetoBD.Nombre %></td><td><%=objetoBD.NombreObjeto %></td><td><%=objetoBD.Select %></td>
                <td><%=objetoBD.Insert %></td><td><%=objetoBD.Delete %></td><td><%=objetoBD.Update %></td><td><%=objetoBD.Execute %></td><td><a href="<%=Url.Content("~/Solicitud/Obtener/"+String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0'))) %>"><%=String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0')) %></a></td><td><%=objetoBD.FechaHora.ToString("dd/MM/yyyy HH:mm:ss") %> <%=objetoBD.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></td></tr> 
            <%}%>
            </tbody>
        </table>
        </div>
        <!--<%=Model.PermisosDBU.Count %> Registros -->
    <%}%>

    <%if (Model.Jobs != null && Model.Jobs.Count > 0){%>
        <h4>Jobs</h4>
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
            <tr><th>Instancia</th><th>Esquema</th><th>Nombre</th><th>Ejecucion Inicial</th><th>Intervalo</th><th>Informacion Adicional</th><th>Solicitud</th></tr>
            </thead>
            <tbody>
            <%foreach (SolicitudBDJob objetoBD in Model.Jobs){%>
            <tr><td><%=objetoBD.Instancia.Nombre %></td><td><%=objetoBD.Esquema.Nombre %></td><td><%=objetoBD.Nombre %></td><td><%=objetoBD.EjecucionInicial %></td><td><%=objetoBD.Intervalo %></td><td><%=objetoBD.InformacionAdicional %></td><td><a href="<%=Url.Content("~/Solicitud/Obtener/"+String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0'))) %>"><%=String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0')) %> <%=objetoBD.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></a></td></tr> 
            <%}%>
            </tbody>
        </table>
        </div>
        <!--<%=Model.Jobs.Count %> Registros -->
    <%}%>

    <%if (Model.Configuraciones != null && Model.Configuraciones.Count > 0){%>
        <h4>Configuraciones</h4>
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr><th>Instancia</th><th>Esquema</th><th>Tabla</th><th>Comentario</th><th>Archivo</th><th>Tipo</th><th>Solicitud</th></tr>
            </thead>
            <tbody>
                <%foreach (SolicitudBDConfiguracion objetoBD in Model.Configuraciones){%>
                    <tr><td><%=objetoBD.Instancia.Nombre %></td><td><%=objetoBD.Esquema.Nombre %></td><td><%=objetoBD.Tabla %></td><td><%=objetoBD.Comentario %></td><td><%=objetoBD.Archivo %></td><td><%=objetoBD.Tipo %></td><td><a href="<%=Url.Content("~/Solicitud/Obtener/"+String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0'))) %>"><%=String.Concat("S",objetoBD.Solicitud.Id.ToString().PadLeft(6,'0')) %> <%=objetoBD.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></a></td></tr> 
                <%}%>
            </tbody>
        </table>
        </div>
        <!--<%=Model.Configuraciones.Count %> Registros -->
    <%}%>
    <%if (!String.IsNullOrEmpty(Model.Mensaje)){ %><div class="alert alert-info"><%=Model.Mensaje %></div><%} %>
</asp:Content>
