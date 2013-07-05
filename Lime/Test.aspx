<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Lime.Test" %>

<%@ Register src="Controls/ParameterListEditor.ascx" tagName="UserFormEditor" tagPrefix="param" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
      
        <param:UserFormEditor runat="server" ID="UserFormEditorControl"/>

</asp:Content>
