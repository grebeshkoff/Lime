<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lime._Default" MasterPageFile="~/Lime.master"%>

<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <div style="height: 100px"></div>
    <asp:Login
        ID="UserLogin" 
        runat="server" 
        CssClass="login-form"
        OnAuthenticate="UserLogin_OnAuthenticate">
    </asp:Login>
    
</asp:Content>
