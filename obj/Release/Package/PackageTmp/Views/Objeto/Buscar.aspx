<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.ObjetoView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Búsqueda de Objetos</h3>
        </div>
        <div class="panel-body">
            <form id="frmBuscarObjeto" method="post" class="form-horizontal">
                <div class="form-group">
                    <label for="cboTipoObjeto" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Tipo Objeto:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <select name="cboTipoObjeto" id="cboTipoObjeto" class="form-control">
                            <option value="1" <%=Model.TipoObjeto=="1"?"selected='selected'":"" %>>Objeto BD</option>
                            <option value="2" <%=Model.TipoObjeto=="2"?"selected='selected'":"" %>>CRM Apps</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombre" class="col-xs-3 col-sm-2 col-md-3 col-lg-2 control-label">Nombre:</label>
                    <div class="col-xs-9 col-sm-9 col-md-8 col-lg-6">
                        <input type="text" name="txtNombre" id="txtNombre" class="form-control" value="<%=Model.NombreObjeto %>" />
                    </div>
                </div>                
            </form>
            
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" value="Buscar" id="btnBuscarObjeto" />
        </div>
    </div>
    <%var existe = false; %>
    <%if (Model.ObjetosBD != null && Model.ObjetosBD.Count > 0)
    {
        existe = true;%>
    <%=Html.Partial("ListaObjetos") %>
    <%} %>
    <%if (Model.CRMApps != null && Model.CRMApps.Count > 0)
    {
        existe = true;%>
    <%=Html.Partial("ListaCRMApp") %>
    <%} %>
    <%if (!existe){ %>
    <div class="alert alert-info">No existen registros</div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
