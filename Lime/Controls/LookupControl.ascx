<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LookupControl.ascx.cs" Inherits="Lime.Controls.LookupControl" %>
<telerik:RadTextBox ID="LockupValue" runat="server"></telerik:RadTextBox>

<div>
    <telerik:RadListBox ID="LookupList" runat="server"></telerik:RadListBox>
</div>

<div>
    <telerik:RadButton ID="AddValue" runat="server" Text="Add"></telerik:RadButton>
    <telerik:RadButton ID="RemoveValue" runat="server" Text="Delete"></telerik:RadButton>
</div>