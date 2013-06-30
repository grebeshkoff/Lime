<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="LookupTest.aspx.cs" Inherits="Lime.LookupTest" %>

<%@ Register src="Controls/LookupControl.ascx" tagName="LookupControl" tagPrefix="lookup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <lookup:LookupControl runat="server" />
</asp:Content>
