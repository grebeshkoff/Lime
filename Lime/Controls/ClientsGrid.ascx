<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientsGrid.ascx.cs" Inherits="Lime.Controls.ClientsGrid" %>

<asp:SqlDataSource ID="GendersDataSource" runat="server"
            DataSourceMode="DataReader"
            ConnectionString="<%$ ConnectionStrings:LimeWork %>"
            SelectCommand="SELECT [genderId], [genderName] FROM [genders]"></asp:SqlDataSource>

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
        Width="97%" 
        ID="ClientsRadGrid" 
        runat="server" 
        OnNeedDataSource="ClientsRadGrid_NeedDataSource"
        OnItemDataBound="ClientsRadGrid_ItemDataBound"
        OnItemCreated="ClientsRadGrid_ItemCreated">
        
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>

        <MasterTableView AutoGenerateColumns="false" Width="100%">
            <Columns>
                <%--<telerik:GridDropDownColumn
                    UniqueName="Gender" 
                    DataField="Gender" 
                    HeaderText="Пол"
                    ListTextField="genderName" 
                    ListValueField="genderId"
                    DropDownControlType="DropDownList">
                </telerik:GridDropDownColumn>--%>
                <telerik:GridBoundColumn 
                    UniqueName="GenderName" 
                    DataField="GenderName" 
                    HeaderText="Пол">
                </telerik:GridBoundColumn>

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
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>