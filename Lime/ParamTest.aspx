<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="ParamTest.aspx.cs" Inherits="Lime.ParamTest" %>

<%@ Register src="Controls/ParameterFormEditor.ascx" tagName="ParameterFormEditor" tagPrefix="param" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <param:ParameterFormEditor runat="server"/>
</asp:Content>
