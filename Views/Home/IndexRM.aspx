<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.HomeView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
     
        <%=Html.Partial("SolicitudesPendientes",Model) %>
        <%int dataAmbiente = 0;
          List<Ambiente> ambientes = new List<Ambiente>();
          if (Model.Pendientes != null)
          {
              foreach (Solicitud s in Model.Pendientes)
              {
                  if (!ambientes.Exists(p => p.Id == s.Ambiente.Id))
                  {
                      ambientes.Add(s.Ambiente);
                  }
              }
          }
          if (Model.Aprobados != null)
          {
              foreach (Solicitud s in Model.Aprobados)
              {
                  if (!ambientes.Exists(p => p.Id == s.Ambiente.Id))
                  {
                      ambientes.Add(s.Ambiente);
                  }
              }
          }
          string resultado = String.Empty;
          List<Ambiente> ambientesOrdenados = ambientes.OrderBy(p => p.Orden).ToList();
          if (ambientesOrdenados.Count > 0)
          {
              dataAmbiente = ambientesOrdenados[0].Id;
          }
          int cantidadAprobados = Model.Aprobados.Count(p => p.Ambiente.Id == dataAmbiente);
                      %>
        <%if (Model.Aprobados.Count > 0)
          { %>
        <div class="panel panel-default seccionAprobados" <%=cantidadAprobados==0?"style='display:none;'":"" %>>
            <div class="panel-heading">
                <h3 class="panel-title">Solicitudes para enviar al Ejecutor</h3>
            </div>
            <div class="panel-body">
               <form name="frmEnviarEjecutor" id="frmEnviarEjecutor" method="post" action='<%=Url.Content("~/Home/EnviarEjecutor") %>'>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12">
                            <label for="cboVentana">Ventana de Ejecución:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                            <select id="cboVentana" name="cboVentana" class="form-control"><option value="0"></option><%
                            foreach (Ventana v in Model.Ventanas)
                            {
                            string ventanaHasta = String.Empty;
                            if (v.Hasta.HasValue)
                            {
                                ventanaHasta = " - " + v.Hasta.Value.ToString("HH:mm");
                            }%>
                                <option value="<%=v.Id %>"><%=String.Concat(v.Desde.ToString("HH:mm"),ventanaHasta)%></option>
                            <%} %>
                        <option value="-1">Emergente</option>
                        <!--<option value="-2">Fecha y Hora de la Solicitud</option>-->
                            </select>
                        </div>
                     </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <label for="txtAsunto">Asunto:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                            <input type="text" name="txtAsunto" id="txtAsunto" class="form-control" value="" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <label for="txtMensajeEnvio">Mensaje de envío:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-9 col-md-8 col-lg-6">
                            <textarea name="txtMensajeEnvio" id="txtMensajeEnvio" class="form-control" maxlength="200" rows="5"></textarea>
                        </div>
                    </div>
                   </div>
                <div class="table-responsive">
                <table class="table table-bordered table-condensed table-hover">
                    <thead>
                        <tr><th></th><th>Nro. Solicitud</th><th>Fecha y Hora</th><th>Proyecto</th><th>Ambiente</th><th>Solicitante</th><th>Formularios</th><th>Otros Archivos</th><th>Estado</th><th>Fecha Ejecucion</th></tr>
                    </thead>
                    <tbody>
                    
                        <%foreach (Solicitud s in Model.Aprobados)
                          { %>
                          <tr <%=s.Emergente?"class='danger'":"" %> data-aprobado="1" data-ambiente="<%=s.Ambiente.Id %>" <%=s.Ambiente.Id!=dataAmbiente?"style='display:none;'":"" %>><%
                string url = Url.Content("~/Home/ObtenerArchivo/S" + s.Id.ToString().PadLeft(6, '0') + "-");%>
                                  <td><input type="checkbox" data-ambiente="<%=s.Ambiente.Id %>" class="solaprobada" name="chk<%=s.Id.ToString() %>" id="chk<%=s.Id.ToString() %>" /></td>
                                <td>
                                <a href='<%=Url.Content("~/Solicitud/Obtener/S"+s.Id.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S", s.Id.ToString().PadLeft(6, '0'))%></a>   
                                <%=!String.IsNullOrEmpty(s.RFC)?String.Concat("(",s.RFC,")"):String.Empty %>
                                <%=(s.Ambiente.ObservaCalidad.Id!=0 && s.Logs.FirstOrDefault(p=>p.Observacion.Id==s.Ambiente.ObservaCalidad.Id)!=null)?"<span class='glyphicon glyphicon-user' aria-hidden='true' data-toggle='tooltip' data-placement='right' title='Requiere aprobación de calidad'></span>":"" %>                         
                                </td>
                                <td><%=s.FechaCreacion.ToString("dd/MM/yyyy HH:mm")%></td>
                                <td><a href="<%=Url.Content("~/Proyecto/Obtener/"+s.Proyecto.Codigo) %>"><%=s.Proyecto.Codigo%></a> <%=s.Proyecto.Nombre%></td>
                                <td><a href="<%=Url.Content("~/Ambiente/Obtener/")+s.Ambiente.Id.ToString() %>"> <%=s.Ambiente.Nombre %></a></td>
                                <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=s.Solicitante}) %></td>
                                <td>
                                    <%for(var i=1; i<=10; i++){
                                          var archivo = i == 1 ? s.Archivo1 : i == 2 ? s.Archivo2 : i == 3 ? s.Archivo3 : i == 4 ? s.Archivo4 : i == 5 ? s.Archivo5 : i == 6 ? s.Archivo6 : i == 7 ? s.Archivo7 : i == 8 ? s.Archivo8 : i == 9 ? s.Archivo9 : s.Archivo10;
                                          var area = i == 1 ? s.Area1 : i == 2 ? s.Area2 : i == 3 ? s.Area3 : i == 4 ? s.Area4 : i == 5 ? s.Area5 : i == 6 ? s.Area6 : i == 7 ? s.Area7 : i == 8 ? s.Area8 : i == 9 ? s.Area9 : s.Area10;
                                          %>
                                        
                                        <%if (!String.IsNullOrEmpty(archivo.Nombre))
                                        { %>                        
                                        <%if (area==null){ %>
                                        <del>
                                        <%} %>
                                        <a href='<%=String.Concat(url,i)%>'><%=archivo.Nombre%></a>
                                        <%if (area==null){ %>
                                        </del>
                                        <%} %>
                                        <br />
                                        <%}%>
                                        
                                    <%} %>
                              </td>
                              <td>
                                  <%
                              foreach (Archivo aprobacion in s.Aprobaciones)
                              {%>
                                  <%if(aprobacion.Area==null) {%>
                                  <del>
                                  <%} %>
                                  <a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+aprobacion.Id) %>'><%=aprobacion.Nombre %></a>
                                  <%if(aprobacion.Area==null) {%>
                                  </del>
                                  <%} %>
                                      <br />
                              <%}
                                       %>
                              </td>
                              <td><%=s.Estado%></td>
                              <td><%=s.FechaEjecucion.HasValue?s.FechaEjecucion.Value.ToString("dd/MM/yyyy HH:mm:ss"):String.Empty %></td>
                          </tr>
                        <%} %>
                    </tbody>
                </table>
                </div>
                </form>
            </div>
            <div class="panel-footer">
                <input type="button" class="btn btn-primary" name="btnEnviarEjecutor" id="btnEnviarEjecutor" value="Enviar al ejecutor"/>
            </div>
        </div>
        <%} %>
    </asp:Content>
