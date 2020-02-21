<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="CMDBApplication.Repository" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%
    string rol = String.Empty;
                HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    string nombreUsuario = FormsAuthentication.Decrypt(cookie.Value).UserData;
                    if (!String.IsNullOrEmpty(nombreUsuario))
                    {

                        UsuarioRepository ur = new UsuarioRepository();
                        Usuario u = ur.Obtener(nombreUsuario);
                        
                        if (u.Administrador)
                            rol = "Administrador";
                        if (u.Operador)
                            rol = "Operador";
                        if (u.Lector)
                            rol = "Lector";
                        if (u.CM)
                            rol = "CM";
                        if (u.RM)
                            rol = "RM";
                        if (u.Ejecutor)
                            rol = "Ejecutor";
                        if (u.Test)
                            rol = "Test";
                    }
                }%>

<nav class="navbar navbar-default navbar-fixed-top">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="<%=Url.Content("~")%>"><img title="Hewlett Packard Enterprise" src="<%=Url.Content("~/img/hpe.png") %>" />CMS</a> 
    </div>

    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" >
        <ul class="nav navbar-nav">
                <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Catálogo <span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/Index") %>">Proyectos</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Aplicacion/Index") %>">Aplicaciones</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Desarrollador/Index") %>">Desarrolladores</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Ambiente/Index") %>">Ambientes</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Servidor/Index") %>">Servidores</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Instancia/Index") %>">Instancias BD</a></li>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Usuario/Index") %>">Usuarios</a></li>
                  </ul>
                </li>
                <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Solicitudes <span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <%if (String.Compare(rol,"Operador")==0 || String.Compare(rol,"RM")==0) {%>
                    <li><a href="<%=Url.Content("~/Solicitud/Crear") %>">Nueva Solicitud</a></li>
                    <%} %>
                    <li><a class="opcionmenu" href="<%=Url.Content("~/Solicitud/Buscar") %>">Buscar Solicitud</a></li>
                  </ul>
                </li>
                <%if (String.Compare(rol,"Administrador")==0){%>
                  <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Administracion <span class="caret"></span></a>
                      <ul class="dropdown-menu">
                        <!--<li><a href="<%=Url.Content("~/Rol/Index") %>">Roles</a></li>-->
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Area/Index") %>">Áreas</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Ventana/Index") %>">Ventanas</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Observacion/Index") %>">Observaciones</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Home/ConfigurarCorreo") %>">Estados de Solic.</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/TipoObjetoBD/Index") %>">Tipo de Objeto de BD</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/TipoAccionBD/Index") %>">Tipo de Accion BD</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Responsable/Index") %>">Gerencias</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Sistema/ObtenerSistema") %>">Datos del Sistema</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/TipoProyecto/Index") %>">Tipo Proyecto</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Solicitud/Revertir") %>">Revertir Solicitud</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Sistema/MatarProcesoExcel") %>">Matar Proceso Excel</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Sistema/AsignarFormato") %>">Asignar Formatos</a></li>
                      </ul>
                  </li>
                <%} %>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Utilitarios <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/CalendarioPases") %>">Calendario de Pases</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/ObjetosPendientes")%>">Objetos Pendientes</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Objeto/Buscar") %>">Buscar Objeto</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Formato/Listar") %>">Formatos</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/ListarReversion") %>">Reversión</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Solicitud/ListarRollback") %>">Listar Rollback</a></li>
                        <!--<li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/ReporteValidacion") %>">Reporte Validación</a></li>-->

                        <%if(String.Compare(rol,"Test")==0) { %>
                            <li><a class="opcionmenu" href="<%=Url.Content("~/Proyecto/Certificar") %>">Certificar Proyecto</a></li>
                        <%} %>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Usuario/CambiarClave") %>">Cambiar Clave</a></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Usuario/MisDatos") %>">Mis Datos</a></li>
                        <%if (rol == "RM" || rol == "CM" || rol == "Administrador")
                          { %>
                            <li><a class="opcionmenu" href="<%=Url.Content("~/Sistema/CrearCarpeta") %>">Crear Carpeta Pase</a></li>
                        <%} %>
                        <li role="separator" class="divider"></li>
                        <li><a class="opcionmenu" href="<%=Url.Content("~/Seguridad/Salir") %>">Salir</a></li>
                    </ul>
                </li>
              </ul>
        <ul class="nav navbar-nav navbar-right">
        <li><a href="<%=Url.Content("~/Usuario/MisDatos")%>"> 
            <%
                if (cookie != null)
                {
                    string nombreUsuario = FormsAuthentication.Decrypt(cookie.Value).UserData;
                    if (!String.IsNullOrEmpty(nombreUsuario))
                    {
                        string estado = "";
                        if (Session["estado"] != null)
                        {
                            estado = Session["estado"].ToString();
                        }
                        else
                        {
                            UsuarioRepository ur = new UsuarioRepository();
                            Usuario u = ur.Obtener(nombreUsuario);
                            StringBuilder sb = new StringBuilder();
                            if (u.Administrador)
                                sb.Append("Administrador,");
                            if (u.Operador)
                                sb.Append("Operador,");
                            if (u.Lector)
                                sb.Append("Lector,");
                            if (u.CM)
                                sb.Append("CM,");
                            if (u.RM)
                                sb.Append("RM,");
                            if (u.Ejecutor)
                                sb.Append("Ejecutor,");
                            if (u.Test)
                                sb.Append("Test,");
                            string listaRoles = sb.ToString().Substring(0, sb.Length - 1);
                            estado = String.Concat(nombreUsuario, " (", listaRoles, ")");
                            Session["estado"] = estado;
                        }
                                              
                        %>                
                        <%=estado %>
                    <%}
                }
            %>            
            </a></li>
        </ul>
    </div>
  </div>
</nav>