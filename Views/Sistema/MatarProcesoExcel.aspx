<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Matar Proceso Excel</h3>
        </div>
        <div class="panel-body">
            <form name="frmMatarProcesoExcel" id="frmMatarProcesoExcel" method="post" action="<%=Url.Content("~/Sistema/MatarProcesoExcel") %>" enctype="multipart/form-data" class="form-horizontal">
                <p>Si hace click en el botón de abajo, matará todos los procesos Excel corriendo en el servidor.</p>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnMatarProcesoExcel" id="btnMatarProcesoExcel" value="Matar Proceso Excel" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
