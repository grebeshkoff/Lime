<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LookupControl.ascx.cs" Inherits="Lime.Controls.LookupControl" %>
<telerik:RadTextBox ID="LockupValue" runat="server"></telerik:RadTextBox>


<asp:Table runat="server">
    <asp:TableRow ID="ParamNewText" runat="server">
        
        <asp:TableCell runat="server" Text="Новое значение">
        </asp:TableCell>

        <asp:TableCell runat="server">
            <telerik:RadTextBox ID="ParamNewValue" runat="server"></telerik:RadTextBox>
        </asp:TableCell>

        <asp:TableCell runat="server">
            <telerik:RadButton ID="SaveNewValue" runat="server" Text="Добавить">
                <Icon PrimaryIconCssClass="bnOk"></Icon>
            </telerik:RadButton>
        </asp:TableCell>

    </asp:TableRow>
    <asp:TableRow ID="ParamValues" runat="server">
                <asp:TableCell ID="TableCell1" runat="server" Text="Новое значение">
        </asp:TableCell>

        <asp:TableCell ID="TableCell2" runat="server">
            <telerik:RadTextBox ID="RadTextBox1" runat="server"></telerik:RadTextBox>
        </asp:TableCell>

        <asp:TableCell ID="TableCell3" runat="server">
            <telerik:RadButton ID="RadButton1" runat="server" Text="Добавить">
                <Icon PrimaryIconCssClass="bnOk"></Icon>
            </telerik:RadButton>
        </asp:TableCell>

    </asp:TableRow>
</asp:Table>

<div>
    
</div>

<div>
    <telerik:RadButton ID="AddValue" runat="server" Text="Add"></telerik:RadButton>
    <telerik:RadButton ID="RemoveValue" runat="server" Text="Delete"></telerik:RadButton>
</div>