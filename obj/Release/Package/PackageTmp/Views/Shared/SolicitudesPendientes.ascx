<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CMDBApplication.ViewModels.HomeView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.Repository" %>
<%
    Usuario u = new Usuario();
    HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
    if (cookie != null)
    {
        string nombreUsuario = FormsAuthentication.Decrypt(cookie.Value).UserData;
        if (!String.IsNullOrEmpty(nombreUsuario))
        {
            UsuarioRepository ur = new UsuarioRepository();
            u = ur.Obtener(nombreUsuario);
        }
    }
%>       
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title ">Solicitudes Pendientes de Procesar</h3>
            
       <%=Html.Partial("FiltroAmbiente",Model) %>
    </div>
    <div class="panel-body">
        <div class="table-responsive">
        <table class="table table-bordered table-condensed table-hover">
        <thead>
            <tr><th>Nro. Solicitud</th><th>Fecha y Hora</th><th>Proyecto</th><th>Ambiente</th><th>Solicitante</th><th>Formularios</th><th>Otros Archivos</th><th>Estado</th><th>Fecha Ejecución</th></tr>
        </thead>
        <tbody>
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
      List<Ambiente> ambientesOrdenados = ambientes.OrderBy(p => p.Orden).ToList();
        if (ambientesOrdenados.Count > 0)
      {
          dataAmbiente = ambientesOrdenados[0].Id;
      } %>
    <%foreach (Solicitud s in Model.Pendientes)
        { %>
        <tr <%=s.Emergente?"class='danger'":"" %> data-ambiente="<%=s.Ambiente.Id %>" <%=s.Ambiente.Id!=dataAmbiente?"style='display:none;'":"" %>><%
                string url = Url.Content("~/Home/ObtenerArchivo/S"+s.Id.ToString().PadLeft(6,'0')+"-");%>
            <td><a href='<%=Url.Content("~/Solicitud/Obtener/S"+s.Id.ToString().PadLeft(6,'0')) %>'><%=String.Concat("S",s.Id.ToString().PadLeft(6,'0')) %></a> 
                <%=!String.IsNullOrEmpty(s.RFC)?String.Concat("(",s.RFC,")"):String.Empty %>
                <%=(s.Ambiente.ObservaCalidad.Id!=0 && s.Logs.FirstOrDefault(p=>p.Observacion.Id==s.Ambiente.ObservaCalidad.Id)!=null)?"<span aria-hidden='true' class='glyphicon glyphicon-user' data-toggle='tooltip' data-placement='right' title='Requiere aprobación de Calidad'></span>":"" %>
            </td>
            <td><%=s.FechaCreacion.ToString("dd/MM/yyyy HH:mm") %></td>
            <td><a href="<%=Url.Content("~/Proyecto/Obtener/"+s.Proyecto.Codigo) %>"><%=s.Proyecto.Codigo%></a> <%=s.Proyecto.Nombre%></td>
            <td><a href="<%=Url.Content("~/Ambiente/Obtener/")+s.Ambiente.Id.ToString() %>"><%=s.Ambiente.Nombre %></a></td>
            <td><%=Html.Partial("InformacionUsuario",new UsuarioView{Usuario=s.Solicitante}) %></td>                            
            <td>
            <%if (!String.IsNullOrEmpty(s.Archivo1.Nombre)){ %>
            <a href='<%=String.Concat(url,"1")%>'><%=s.Archivo1.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo2.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"2")%>'><%=s.Archivo2.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo3.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"3")%>'><%=s.Archivo3.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo4.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"4")%>'><%=s.Archivo4.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo5.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"5")%>'><%=s.Archivo5.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo6.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"6")%>'><%=s.Archivo6.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo7.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"7")%>'><%=s.Archivo7.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo8.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"8")%>'><%=s.Archivo8.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo9.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"9")%>'><%=s.Archivo9.Nombre %></a>
            <%} %>
            <%if (!String.IsNullOrEmpty(s.Archivo10.Nombre))
                { %>
            <br />
            <a href='<%=String.Concat(url,"10")%>'><%=s.Archivo10.Nombre %></a>
            <%} %>
            </td>
            <td>
                <%
            foreach (Archivo aprobacion in s.Aprobaciones)
            {%>
                <a href='<%=Url.Content("~/Solicitud/ObtenerAprobacion/"+aprobacion.Id) %>'><%=aprobacion.Nombre %></a><br />
            <%}
                    %>
            </td>
            <td><span <%=(s.Estado=="Enviado_a_CM" && u.CM)?"class='resaltado'":"" %>><%=s.Estado%></span></td>
            <td><%=s.FechaEjecucion.HasValue?s.FechaEjecucion.Value.ToString("dd/MM/yyyy HH:mm:ss"):String.Empty %></td>
        </tr>
    <%} %>
</tbody>
    </table>
        </div>
    </div>
    <div class="panel-footer" id="numSolPendientes">
        <%=Model.Pendientes.Count(p=>p.Ambiente.Id==dataAmbiente)%> Solicitudes
    </div>
</div>

