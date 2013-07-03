<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Lime.Clients" %>


<%@ Register src="Controls/UserFormEditor.ascx" tagName="UserFormEditor" tagPrefix="user" %>
<%@ Register src="Controls/ClientsGrid.ascx" tagName="ClientsGrid" tagPrefix="list" %>

<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
           
    <telerik:RadAjaxManagerProxy ID="AjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="MainClientsGridControl">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MainClientsGridControl" LoadingPanelID="GridLoadingPanel"/>
                    <telerik:AjaxUpdatedControl ControlID="MainUserEditControl" LoadingPanelID="ControlLoadingPanel"/>
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="MainUserEditControl">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MainUserEditControl" LoadingPanelID="ControlLoadingPanel"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>

    </telerik:RadAjaxManagerProxy>
    
    
    <table width="100%">
        <tr>
            <td style="width: 65%; vertical-align: top;">
                <telerik:RadAjaxLoadingPanel ID="GridLoadingPanel" runat="server" />
                <list:ClientsGrid runat="server" ID ="MainClientsGridControl" />            
            </td >
            <td style="vertical-align: top;">
                <telerik:RadAjaxLoadingPanel ID="ControlLoadingPanel" runat="server" />
                <user:UserFormEditor runat="server" ID="MainUserEditControl" />
            </td>
        </tr>
    </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


