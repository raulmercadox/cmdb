<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CMDBApplication.ViewModels.ArchivoView>" %>
<%@ Import Namespace="CMDBApplication.Repository" %>
<%@ Import Namespace="CMDBApplication.Models" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>

<%
Archivo archivo = Model.Archivo;
string cadArchivo = "archivo" + Model.SolicitudId.ToString()+"-"+ Model.Indicador.ToString();
string cadConflicto = "conflicto" + Model.SolicitudId.ToString()+"-"+ Model.Indicador.ToString();

if (!String.IsNullOrEmpty(archivo.Comentario))
{
    if (archivo.Estado || archivo.Comentario.IndexOf("ADVERTENCIA")>=0)
    {
    %> <div id="<%=cadArchivo %>" style="display:none"><%=archivo.Comentario %></div><img data-contenedor="<%=cadArchivo %>" class="puntero mostrarmensaje" title="Click para mas detalles" src='<%=Url.Content("~/img/bug.png")%>'/> <%}
    else
    {
    %> <div id="<%=cadArchivo %>" style="display:none"><%=archivo.Comentario %></div><img data-contenedor="<%=cadArchivo %>" class="puntero mostrarmensaje" title="Click para mas detalles" src='<%=Url.Content("~/img/ok.png")%>'/> <%}
} %> 
<%=archivo.ConflictosBD.Count()>0?"<img data-contenedor='"+cadConflicto+"' class='puntero mostrarmensaje' title='Existen conflictos de objetos de BD. Click para más detalles' src='"+Url.Content("~/img/warning.png")+"'>":"" %>
