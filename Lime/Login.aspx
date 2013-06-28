<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lime.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Login
        ID="UserLogin" 
        runat="server" 
        CssClass="login-form"
        OnAuthenticate="UserLogin_OnAuthenticate">
    </asp:Login>
</asp:Content>
