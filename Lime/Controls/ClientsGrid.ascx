<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientsGrid.ascx.cs" Inherits="Lime.Controls.ClientsGrid" %>

    <telerik:RadAjaxManager ID="ClientsGridAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ClientsRadGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ClientsRadGrid" LoadingPanelID="ClientsAjaxLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="ClientsAjaxLoadingPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>
    
    <telerik:RadGrid
        Skin="Silk" 

        
        ID="ClientsRadGrid" 
        runat="server" 
        OnNeedDataSource="ClientsRadGrid_NeedDataSource"
        OnItemDataBound="ClientsRadGrid_ItemDataBound"
        AllowFilteringByColumn="True" 
        AllowSorting="True" 
        CellSpacing="0" 
        Culture="ru-RU" 
        GridLines="None" 
        AllowPaging="True" 
        AutoGenerateColumns="False"
        EnableHeaderContextFilterMenu="true" 
        EnableHeaderContextMenu="true"
        ShowGroupPanel="True">
        
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>


        <MasterTableView Width="100%" ShowFooter="True">

            <Columns>
                
                <telerik:GridBoundColumn 
                    UniqueName="FullName" 
                    DataField="FullName" 
                    HeaderText="ФИО">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn 
                    UniqueName="Code"
                    DataField="Code" 
                    HeaderText="ИНН">
                </telerik:GridBoundColumn>

                <telerik:GridDropDownColumn
                    UniqueName="Gender"
                    HeaderText="Пол"
                    ListTextField="Name"
                    ListValueField="Id"
                    DropDownControlType="DropDownList"
                    DataField="Gender">
                </telerik:GridDropDownColumn>
                
                <%--<telerik:GridDropDownColumn
                    UniqueName="Gender" 
                    DataField="Gender" 
                    HeaderText="Пол"
                    ListTextField="genderName" 
                    ListValueField="genderId"
                    DropDownControlType="RadComboBox">
                </telerik:GridDropDownColumn>
                --%>
                <%--<telerik:GridDropDownColumn 
                    UniqueName="ddlQuantity"
                    ListTextField="Quantity" 
                    ListValueField="Quantity"
                    ListDataMember="Orders" 
                    DataField="Quantity" 
                    HeaderText="Quantities in stock"
                    DropDownControlType="RadComboBox">
                </telerik:GridDropDownColumn>--%>

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

        </MasterTableView>
    </telerik:RadGrid>





