<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientsGrid.ascx.cs" Inherits="Lime.Controls.ClientsGrid" %>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
            

           </script>
    </telerik:RadCodeBlock>

<%--    <telerik:RadAjaxManager ID="ClientsGridAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ClientsRadGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ClientsRadGrid" LoadingPanelID="ClientsAjaxLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>

    <asp:UpdatePanel ID="NotifikationPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <telerik:RadNotification ID="ErrorNotification" runat="server" Text="Действие завершилось ошибкой!" RenderMode="Lightweight" Position="Center"
                AutoCloseDelay="0" Width="350" Title="Ошибка приложения" EnableRoundedCorners="False" Skin="Silk" ContentIcon="delete" TitleIcon="delete">
            </telerik:RadNotification>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--    <telerik:RadAjaxLoadingPanel ID="ClientsAjaxLoadingPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>--%>
    
    <telerik:RadGrid
        Skin="Silk" 

        
        ID="ClientsRadGrid" 
        runat="server" 
        OnNeedDataSource="ClientsRadGrid_NeedDataSource"
        OnItemDataBound="ClientsRadGrid_ItemDataBound"
        OnDeleteCommand="ClientsRadGrid_DeleteCommand"
        OnInsertCommand="ClientsRadGrid_InsertCommand"
        OnItemCommand="ClientsRadGrid_ItemCommand"
        OnUpdateCommand="ClientsRadGrid_OnUpdateCommand"

        AllowFilteringByColumn="True" 
        AllowMultiRowSelection="False"
        
        AllowSorting="True" 
        CellSpacing="0" 
        Culture="ru-RU" 
        GridLines="None" 
        AllowPaging="True" 
        AutoGenerateColumns="False"
        EnableHeaderContextFilterMenu="true" 
        EnableHeaderContextMenu="true"
        EnableAJAX="True" 
        
        >
        
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True"></Selecting>
        </ClientSettings>
        
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>


        <MasterTableView 
            Width="100%" 
            GridLines="None" 
            CommandItemDisplay="Top" 
            DataKeyNames="Id" 
            InsertItemDisplay="Top"
            InsertItemPageIndexAction="ShowItemOnFirstPage">
            <CommandItemSettings>
                
            </CommandItemSettings>

            <Columns>
                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn">
                </telerik:GridClientSelectColumn>
                
                <%--<telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                <ItemTemplate>
                  <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                    AutoPostBack="True" />
                </ItemTemplate>
                <HeaderTemplate>
                </HeaderTemplate>
              </telerik:GridTemplateColumn>--%>
                
                <telerik:GridBoundColumn 
                    UniqueName="Id" 
                    DataField="Id" 
                    HeaderText="ИД"
                    ReadOnly="True"
                    Visible="False">
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

                <telerik:GridDropDownColumn
                    UniqueName="Gender"
                    HeaderText="Пол"
                    ListTextField="Name"
                    ListValueField="Id"
                    DropDownControlType="DropDownList"
                    DataField="Gender"
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
                
                 <telerik:GridButtonColumn 
                    UniqueName="EditProperty" 
                    ButtonType="ImageButton"
                    ImageUrl="/Theme/Images/next.png" 
                    CommandName="EditProperty">
                </telerik:GridButtonColumn>

            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton">
                </EditColumn>
            </EditFormSettings>

            
            <CommandItemSettings AddNewRecordText="Добавить параметр"></CommandItemSettings>
        </MasterTableView>
        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
           
        </ClientSettings>
    </telerik:RadGrid>





