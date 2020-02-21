<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CMDBApplication.ViewModels.SolicitudView>" %>
<%@ Import Namespace="CMDBApplication.Repository" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%
    SolicitudRepository sr = new SolicitudRepository();
    for(int i=1; i<=10; i++)
    {
        Archivo archivo = i == 1 ? Model.Solicitud.Archivo1 : i == 2 ? Model.Solicitud.Archivo2 : i == 3 ? Model.Solicitud.Archivo3 : i == 4 ? Model.Solicitud.Archivo4 : i == 5 ? Model.Solicitud.Archivo5 : i == 6 ?
            Model.Solicitud.Archivo6 : i == 7 ? Model.Solicitud.Archivo7 : i == 8 ? Model.Solicitud.Archivo8 : i == 9 ? Model.Solicitud.Archivo9 : i == 10 ? Model.Solicitud.Archivo10 : null;
        if (archivo != null && archivo.ConflictosBD != null && archivo.ConflictosBD.Count>0)
        {%>
        <div id="conflicto<%=Model.Solicitud.Id.ToString()%>-<%=i%>" style="display:none">
            <div class="table-responsive">
              <table class="table table-bordered table-condensed table-hover">
                <caption>Lista de objetos en conflicto</caption>
                <thead>
                    <tr><th>Proyecto</th><th>N° Solicitud</th><th>Estado</th><th>Instancia</th><th>Esquema</th><th>Tipo de Objeto</th><th>Objeto</th><th>Fecha Hora</th><th>Solicitante</th></tr>
                </thead>
                <tbody>
                <% foreach (ConflictoBD conflictoBD in archivo.ConflictosBD){
                       Solicitud s = sr.Obtener(conflictoBD.SolicitudId);
                       %>
                    <tr><td><%=conflictoBD.Proyecto.Codigo%> - <%=conflictoBD.Proyecto.Nombre%></td><td><%=String.Concat("S",conflictoBD.SolicitudId.ToString().PadLeft(6,'0')) %></td><td><%=conflictoBD.Estado %></td><td><%=conflictoBD.Instancia.Nombre%></td><td><%=conflictoBD.Esquema.Nombre%></td><td><%=conflictoBD.TipoObjetoBD.Nombre%></td><td><%=conflictoBD.NombreObjeto%></td><td><%=conflictoBD.FechaHora.ToString("dd/MM/yyyy HH:mm:ss") %> <%=s.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></td><td><%=s.Solicitante.Nombre %></td></tr>  
                <%}%>
                </tbody>
            </table>
           </div>
        </div>
        <%}
          
        if (archivo!=null && archivo.ConflictosCRMWPApp != null && archivo.ConflictosCRMWPApp.Count>0)
        {%>
        <div id="conflicto<%=Model.Solicitud.Id.ToString()%>-<%=i %>" style="display:none">
            <div class="table-responsive">
              <table class="table table-bordered table-condensed table-hover">
                <caption>Lista de objetos en conflicto</caption>
                <thead>
                    <tr><th>Proyecto</th><th>N° Solciitud</th><th>Estado</th><th>Server/Cluster</th><th>Tipo</th><th>Aplicacion</th><th>Fecha Hora</th><th>Solicitante</th></tr>
                </thead>
                <tbody>
                    <%foreach(ConflictoCRMWPApp conflicto in archivo.ConflictosCRMWPApp){ %>
                    <tr><td><%=conflicto.Proyecto.Codigo %> - <%=conflicto.Proyecto.Nombre%></td><td><%=String.Concat("S",conflicto.Solicitud.Id.ToString().PadLeft(6,'0')) %></td><td><%=conflicto.Solicitud.Estado %></td><td><%=conflicto.ServerCluster %></td><td><%=conflicto.Tipo %></td><td><%=conflicto.Aplicacion %> <%=conflicto.Solicitud.Reversion?"<img src='"+Url.Content("~/img/revert.png")+"' title='Objeto revertido'>":String.Empty %></td></tr>
                    <%} %>
                </tbody>
            </table>
        </div>
            </div>
        <%} %>
  <%}%>