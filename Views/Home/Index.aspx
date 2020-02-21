<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<HomeView>" %>
<%@ Import Namespace="CMDBApplication.ViewModels" %>
<%@ Import Namespace="CMDBApplication.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
<%=Html.Partial("SolicitudesPendientes",Model) %>      

</asp:Content>
