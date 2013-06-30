<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Lime.Test" %>


<%@ Register src="Controls/UserFormEditor.ascx" tagName="UserFormEditor" tagPrefix="lm" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    

    <lm:UserFormEditor runat="server" ID="UserFormEditor"/>
</asp:Content>

