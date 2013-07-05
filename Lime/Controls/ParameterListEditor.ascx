<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterListEditor.ascx.cs" Inherits="Lime.Controls.ParameterListEditor" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ListViewPanel1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ParametersGridPanel" LoadingPanelID="ParametersAjaxLoadingPanel">
                </telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>
</telerik:RadCodeBlock>

<telerik:RadAjaxLoadingPanel ID="ParametersAjaxLoadingPanel" runat="server">
</telerik:RadAjaxLoadingPanel>
<%--<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecorationZoneID="additional-parameters"/>--%>

<div id="additional-parameters">
    <asp:Panel ID="ParametersGridPanel" runat="server" CssClass="param-table">
    
    <telerik:RadGrid
        Skin="Silk" 
        ID="ParametersGrid" 
        runat="server" 
        OnNeedDataSource="ClientsRadGrid_NeedDataSource"
        OnItemDataBound="ParametersGrid_ItemDataBound"

        AllowFilteringByColumn="False" 
        AllowMultiRowSelection="False"
        
        AllowSorting="False" 
        CellSpacing="0" 
        Culture="ru-RU" 
        GridLines="None" 
        AllowPaging="True" 
        AutoGenerateColumns="False"
        EnableHeaderContextFilterMenu="true" 
        EnableHeaderContextMenu="true"
        EnableAJAX="True">
        
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True"></Selecting>
        </ClientSettings>
        
        <PagerStyle Mode="NextPrev"></PagerStyle>

        <MasterTableView 
            Width="300" 
            GridLines="None" 
            CommandItemDisplay="Top" 
            DataKeyNames="Id" 
            InsertItemDisplay="Top"
            InsertItemPageIndexAction="ShowItemOnFirstPage">

            <Columns>
                <telerik:GridTemplateColumn   
                        UniqueName="ParameterType"
                        DataField="Type"
                        ReadOnly="True">
                        <ItemTemplate>  
                            <asp:Image ID="TypeImage" runat="server" ImageUrl='<%# String.Format("../Theme/Images/ui{0}.png", Eval("Type")) %>'/>  
                        </ItemTemplate>  
                 </telerik:GridTemplateColumn>
                
                <telerik:GridBoundColumn 
                    UniqueName="Id" 
                    DataField="Id" 
                    HeaderText="ИД"
                    ReadOnly="True"
                    Visible="False">
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn 
                    UniqueName="ParameterName" 
                    DataField="Name" 
                    HeaderText="Название параметра">
                </telerik:GridBoundColumn>
                
               <telerik:GridDropDownColumn 
                    UniqueName="ParameterType" 
                    DataField="Type" 
                    HeaderText="Тип параметра"
                    Visible="False">
                </telerik:GridDropDownColumn>

                <telerik:GridEditCommandColumn 
                    UniqueName="EditCommandColumn" 
                    ButtonType="ImageButton">
                </telerik:GridEditCommandColumn>

                <telerik:GridButtonColumn 
                    UniqueName="DeleteColumn" 
                    ButtonType="ImageButton" 
                    CommandName="Delete">
                </telerik:GridButtonColumn>
                
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton">
                </EditColumn>
            </EditFormSettings>

            
            <CommandItemSettings AddNewRecordText="Добавить клиента"></CommandItemSettings>
        </MasterTableView>
        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>
    </telerik:RadGrid>
    
</asp:Panel>
</div>

