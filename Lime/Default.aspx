<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lime._Default" MasterPageFile="~/Lime.master"%>


<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    
    <asp:Login ID="Login1" runat="server"></asp:Login>
    
    <asp:LoginName ID="LoginName1" runat="server" />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <asp:LoginView ID="LoginView1" runat="server"></asp:LoginView>
</asp:Content>
