<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Lime.Clients" %>
<%@ Register src="Controls/ClientsGrid.ascx" tagName="ClientsGrid" tagPrefix="lm" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <lm:ClientsGrid runat="server"/>
</asp:Content>
