<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserFormEditor.ascx.cs" Inherits="Lime.Controls.UserFormEditor" %>

<asp:Table runat="server" ID="ParameterTable" CssClass="user-params">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Полное имя клиента :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="FullNameLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">ИНН :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="CodeLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Пол :</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Image ID="GenderImage" runat="server" Text=""></asp:Image>
        </asp:TableCell>
    </asp:TableRow>
    <%--<asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell runat="server">
            <telerik:RadButton ID="SaveButton" runat="server" Text="Сохранить">
                <Icon PrimaryIconCssClass="rbOk" PrimaryIconTop="4px" PrimaryIconRight="5px"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <telerik:RadButton ID="CancelButton" runat="server" Text="Отмена">
                <Icon PrimaryIconCssClass="rbCancel" PrimaryIconTop="4px" PrimaryIconRight="5px"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
    </asp:TableRow>--%>
</asp:Table>
