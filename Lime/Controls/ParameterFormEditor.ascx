<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterFormEditor.ascx.cs" Inherits="Lime.Controls.ParameterFormEditor" %>

<asp:Table runat="server" ID="ParameterEditorTable" CssClass="user-params">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server" Width="200">Полное имя клиента :</asp:TableCell>
        <asp:TableCell runat="server" Width="200">
            <asp:Label ID="FullNameLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell  runat="server" Width="200">ИНН :</asp:TableCell>
        <asp:TableCell runat="server" Width="200">
            <asp:Label ID="CodeLabel" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server" Width="200">Пол :</asp:TableCell>
        <asp:TableCell runat="server" Width="200">
            <asp:Image ID="GenderImage" runat="server"></asp:Image>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>


<telerik:RadFormDecorator ID="parametersFormDecorator" runat="server" DecorationZoneID="parametersForm"/>
<div id="parametersForm">
<asp:UpdatePanel runat="server">
    
    <ContentTemplate>
        <asp:Table runat="server" ID="AdditionalParameterTable">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Width="200">
                    <asp:Label ID="Label1" runat="server" Text="Текстовый параметр:"></asp:Label>
                </asp:TableCell>
                
                

                <asp:TableCell runat="server">
                    <telerik:RadTextBox runat="server" ID="TextParameterName" Width="200" CssClass="no-error-data"></telerik:RadTextBox>
                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell3" runat="server" Width="200">
                    <asp:Label runat="server" Text="Параметр выбора:" ></asp:Label>
                </asp:TableCell>

                <asp:TableCell ID="TableCell4" runat="server" VerticalAlign="Top">
                    <div>
                        <telerik:RadTextBox runat="server" ID="LookupParameterName" Width="200" CssClass="no-error-data"></telerik:RadTextBox>
                    </div>
       
                    <div>
                        <telerik:RadTextBox ID="LockupValueText" runat="server" Width="200"></telerik:RadTextBox>
                        <telerik:RadButton 
                            ID="AddValue" 
                            runat="server" 
                            Text=" + " 
                            Width="30"
                            OnClick="AddValueClick">
                        </telerik:RadButton>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                </asp:TableCell>
                <asp:TableCell>
                    <div>
                        <telerik:RadListBox ID="LookupList" runat="server" Width="200" Height="170" SelectionMode="Single" >
                        </telerik:RadListBox>
                        <telerik:RadButton 
                            ID="DeleteValue" 
                            runat="server" 
                            Text=" - " 
                            Width="30"
                            OnClick="DeleteValueClick">
                        </telerik:RadButton>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </ContentTemplate>

</asp:UpdatePanel>


<asp:Table runat="server" ID="ControlsTable">
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell ID="TableCell1" runat="server" Width="120" HorizontalAlign="Center">
            <telerik:RadButton 
                ID="SaveButton" 
                runat="server" 
                Text="Сохранить"
                Width="100"
                OnClick="SaveParameterClick">
                <Icon PrimaryIconCssClass="rbOk"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server"  Width="120" HorizontalAlign="Center">
            <telerik:RadButton 
                ID="CancelButton" 
                runat="server" 
                Text="Отмена"
                Width="100"
                OnClick="CancelButtonClick">
                <Icon PrimaryIconCssClass="rbCancel"></Icon>
            </telerik:RadButton>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</div>