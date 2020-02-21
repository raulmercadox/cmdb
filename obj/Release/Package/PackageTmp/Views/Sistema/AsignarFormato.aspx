<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<CMDBApplication.ViewModels.SistemaView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Asignar Formatos</h3>
        </div>
        <div class="panel-body">
            <form>
                <div class="form-group">
                    <div class="col-xs-12 col-md-6 col-lg-4">
                        <label for="cboAmbiene" class="control-label">Ambiente:</label>
                        <select id="cboAmbiente" name="cboAmbiente" class="form-control">
                            <%foreach(var item in Model.Ambientes){ %>
                                <option id="<%=item.Id %>"><%=item.Nombre %></option>
                            <%} %>
                        </select>
                    </div>
                </div>
            
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="table-responsive">
                            <table class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr><th>Formato</th><th>Descripción</th><th>Grupo Ejecutor</th></tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in Model.Formatos)
                                      {%>
                                        <tr><td><%=item.Codigo %></td><td><%=item.Descripcion %></td>
                                            <td><select class="form-control"><option value="0"></option><% foreach (var grupo in Model.Grupos)
                                                   {%>
                                                      <option value="<%=grupo.Id %>"><%=grupo.Nombre %></option> 
                                                   <%}%>
                                                </select></td>

                                        </tr>  
                                      <%} %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="panel-footer">
            <input type="button" class="btn btn-primary" name="btnGuardarAsignarFormatos" id="btnGuardarAsignarFormatos" value="Guardar Cambios" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
