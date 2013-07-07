<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterListEditor.ascx.cs" Inherits="Lime.Controls.ParameterListEditor" %>
<%@ Import Namespace="Lime.Data.Source" %>
<%--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>--%>
<telerik:RadAjaxManager ID="ParametersRadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ListViewPanel1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ParametersGridPanel" LoadingPanelID="ParametersAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        //function OnClientSelectedIndexChanged(sender, eventArgs) {
        //    alert('!');
        //}
        
    </script>
</telerik:RadCodeBlock>

<telerik:RadAjaxLoadingPanel ID="ParametersAjaxLoadingPanel" runat="server">
</telerik:RadAjaxLoadingPanel>


    <asp:Panel ID="ParametersGridPanel" runat="server">

        <telerik:RadGrid
            Skin="Silk"
            ID="ParametersGrid"
            runat="server"
            
            OnItemDataBound="ParametersGrid_ItemDataBound"
            OnDeleteCommand="ParametersGrid_DeleteCommand"
            OnInsertCommand="ParametersGrid_InsertCommand"
            OnNeedDataSource="ParametersGrid_NeedDataSource"

            AllowFilteringByColumn="False"
            AllowMultiRowSelection="False"
            AllowSorting="False"
            CellSpacing="0"
            Culture="ru-RU"
            GridLines="None"
            AllowPaging="False"
            AutoGenerateColumns="False"
>

            <ClientSettings EnableRowHoverStyle="true">
                <Selecting AllowRowSelect="True"></Selecting>
            </ClientSettings>

            <PagerStyle Mode="NextPrev"></PagerStyle>

            <MasterTableView
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
                            <asp:Image ID="TypeImage" runat="server" ImageUrl='<%# String.Format("../Theme/Images/ui{0}.png", Eval("Type")) %>' />
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
                <EditFormSettings EditFormType="Template">
                    <EditColumn ButtonType="ImageButton">
                    </EditColumn>
                    
                    <FormTemplate>
                        <table>
                            <tr>
                                <td>
                                    Название параментра
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="ParamNameTextBox" Text='<%# Bind("Name") %>' Width="200"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Тип параметра
                                </td>
                                <td>
                                    
                                    <asp:DropDownList 
                                        ID="ParamTypeDropDownList"
                                        AutoPostBack="True"
                                        Width="200" 
                                        runat="server" 
                                        EnableViewState="True"
                                        DataSource='<%# Enum.GetNames(typeof(ParameterType)) %>' 
                                        AppendDataBoundItems="False"
                                        OnSelectedIndexChanged="ParamTypeDropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="AddParamLable" Text="Список значений" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <div>
                                        <telerik:RadListBox 
                                            runat="server" 
                                            ID="AddParamListBox" 
                                            Width="200" 
                                            Height="150" 
                                            Visible="False">
                                        </telerik:RadListBox>
                                    </div>
                                    <div>
                                        <telerik:RadListBox 
                                            runat="server" 
                                            ID="RadListBox1" 
                                            Width="200" 
                                            Height="150" 
                                            Visible="False">
                                        </telerik:RadListBox>
                                    </div>

                                </td>

                            </tr>
                            
                            <tr>
                                <td>
                                <asp:Button ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Добавить" : "Сохранить" %>'
                                    runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                </asp:Button>
                                </td>

                                <td>
                                <asp:Button ID="btnCancel" Text="Отмена" runat="server" CausesValidation="False"
                                    CommandName="Cancel"></asp:Button>
                                </td>    
                            </tr>

                        </table>
                    </FormTemplate>
                </EditFormSettings>


                <CommandItemSettings AddNewRecordText="Добавить параметр"></CommandItemSettings>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
            </ClientSettings>
        </telerik:RadGrid>

    </asp:Panel>
    <asp:Panel runat="server" ID="PersonLegend">
        <asp:Table runat="server" ID="LegendTable" CssClass="user-params">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">Полное имя клиента :</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:Label ID="FullNameLabel" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">ИНН :</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:Label ID="CodeLabel" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TableCell5" runat="server">Пол :</asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">
                    <asp:Image ID="GenderImage" runat="server"></asp:Image>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel> 


