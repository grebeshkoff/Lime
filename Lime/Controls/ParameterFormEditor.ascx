<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterFormEditor.ascx.cs" Inherits="Lime.Controls.ParameterFormEditor" %>


<asp:Table runat="server" ID="ParameterEditorTable" CssClass="user-params">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Полное имя клиента :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="FullNameLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell  runat="server">ИНН :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="CodeLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Пол :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Image ID="GenderImage" runat="server"></asp:Image>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

<asp:Table runat="server" ID="ParametersTable">
    
</asp:Table>

<asp:Table runat="server" ID="ControlsTable">
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell ID="TableCell1" runat="server" Width="120" HorizontalAlign="Center">
            <telerik:RadButton 
                ID="SaveButton" 
                runat="server" 
                Text="Сохранить"
                Width="100">
                <Icon PrimaryIconCssClass="rbOk"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server"  Width="120" HorizontalAlign="Center">
            <telerik:RadButton 
                ID="CancelButton" 
                runat="server" 
                Text="Отмена"
                Width="100">
                <Icon PrimaryIconCssClass="rbCancel"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>