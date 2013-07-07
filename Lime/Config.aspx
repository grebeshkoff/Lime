<%@ Page Title="" Language="C#" MasterPageFile="~/Lime.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="Lime.Config" %>



<%@ Register src="Controls/ParameterListEditor.ascx" tagName="ParameterListEditor" tagPrefix="param" %>
<%@ Register src="Controls/ClientsGrid.ascx" tagName="ClientsGrid" tagPrefix="list" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PlaceHolderMain">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
           
    <telerik:RadAjaxManagerProxy ID="AjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="MainClientsGridControl">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MainClientsGridControl" LoadingPanelID="GridLoadingPanel"/>
                    <telerik:AjaxUpdatedControl ControlID="MainParamEditControl" LoadingPanelID="ControlLoadingPanel"/>
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="MainParamEditControl">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MainParamEditControl" LoadingPanelID="ControlLoadingPanel"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>

    </telerik:RadAjaxManagerProxy>
    
    
    <table width="100%">
        <tr>
            <td style="width: 65%;vertical-align: top;">
                <telerik:RadAjaxLoadingPanel ID="GridLoadingPanel" runat="server" />
                <list:ClientsGrid runat="server" ID ="MainClientsGridControl" />            
            </td>
            <td style="vertical-align: top;">
                <telerik:RadAjaxLoadingPanel ID="ControlLoadingPanel" runat="server" />
                <param:ParameterListEditor runat="server" ID="MainParamEditControl" />
            </td>
        </tr>
    </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
