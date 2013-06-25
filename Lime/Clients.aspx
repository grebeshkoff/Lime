<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Lime.Clients" %>
<%@ Register src="Controls/ClientsGrid.ascx" tagName="ClientsGrid" tagPrefix="gd" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <gd:ClientsGrid runat="server"/>
</asp:Content>
