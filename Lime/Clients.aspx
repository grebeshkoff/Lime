<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Lime.Clients" %>


<%@ Register src="Controls/UserFormEditor.ascx" tagName="UserFormEditor" tagPrefix="user" %>
<%@ Register src="Controls/ClientsGrid.ascx" tagName="ClientsGrid" tagPrefix="list" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <asp:Table runat="server" ID="MainTable" Width="100%">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="65%">
                <list:ClientsGrid runat="server" ID="MainClientsGridControl"/>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="35%">
                <user:UserFormEditor runat="server" ID="MainUserEditControl"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
