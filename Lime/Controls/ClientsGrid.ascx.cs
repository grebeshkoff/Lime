using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lime.Data.Source;
using Telerik.Web.UI;

namespace Lime.Controls
{
    public partial class ClientsGrid : System.Web.UI.UserControl
    {
        private void ShowNotification(string text)
        {
            ErrorNotification.Text = text;
            ErrorNotification.Show();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ClientsRadGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                ClientsRadGrid.DataSource = db.Persons.OrderByDescending(person => person.Id);
            }
        }


        protected void ClientsRadGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                if (e.Item is GridDataItem && !e.Item.IsInEditMode)
                {
                    var item = e.Item as GridDataItem;
                    var p = item.DataItem as Person;
                    item["Gender"].Text = db.GetGenderById(p.GenderId).Name;
                }
                if (e.Item is GridEditableItem && (e.Item as GridEditableItem).IsInEditMode)
                {
                    var editedItem = e.Item as GridEditableItem;
                    var editMan = editedItem.EditManager;
                    var editor = editMan.GetColumnEditor("Gender") as GridDropDownColumnEditor;
                    if (editor != null)
                    {
                        editor.DataSource = db.Genders.ToList();
                        editor.DataBind();
                        var person = e.Item.DataItem as Person;
                        if (person != null)
                            editor.SelectedValue = person.GenderId.ToString();
                    }
                }
                if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
                {
                    var editedItem = e.Item as GridEditableItem;
                    var editMan = editedItem.EditManager;
                    var editor = editMan.GetColumnEditor("Gender") as GridDropDownColumnEditor;
                    if (editor != null)
                    {
                        editor.DataSource = db.Genders.ToList();
                        editor.DataBind();
                    }
                }

            } 
        }

        protected void ClientsRadGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                using (var db = new LimeDataBase())
                {
                    var item = (GridDataItem)e.Item;
                    var person = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString();
                    db.DeletePerson(Int32.Parse(person));
                }
            }
            catch (Exception ex)
            {
                ShowNotification(ex.Message);
            }
        }

        protected void ClientsRadGrid_InsertCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var insertedItem = (GridEditFormInsertItem)e.Item;
                var fullName = (insertedItem["FullName"].Controls[0] as TextBox).Text;
                var code = (insertedItem["Code"].Controls[0] as TextBox).Text;
                var gender = (insertedItem["Gender"].Controls[0] as DropDownList).SelectedValue;

                if (code == "" || fullName == "")
                {
                    throw new Exception("Ошибка ввода");
                }

                var person = new Person
                    {
                        FullName = fullName,
                        Code = code,
                        GenderId = Int32.Parse(gender)
                    };

                using (var db = new LimeDataBase())
                {
                    db.AddPerson(person);
                }

            }
            catch (Exception ex)
            {
                ShowNotification(ex.Message);
            }
        }

        protected void ClientsRadGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    var newValues = new ListDictionary();
                    newValues["FullName"] = "";
                    newValues["Code"] = "";
                    newValues["Gender"] = 1;
                    e.Item.OwnerTableView.InsertItem(newValues);
                }
            }
            catch (Exception ex)
            {
                ShowNotification(ex.Message);
            }
        }

        protected void ClientsRadGrid_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editedItem = e.Item as GridEditableItem;
                var personId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString();

                var fullName = (editedItem["FullName"].Controls[0] as TextBox).Text;
                var code = (editedItem["Code"].Controls[0] as TextBox).Text;
                var gender = (editedItem["Gender"].Controls[0] as DropDownList).SelectedValue;

                if (code == "" || fullName == "")
                {
                    throw new Exception("Ошибка ввода");
                }


                var person = new Person
                    {
                        Id = Int32.Parse(personId),
                        FullName = fullName,
                        Code = code,
                        GenderId = Int32.Parse(gender)
                    };

                using (var db = new LimeDataBase())
                {
                    db.UpdatePerson(person);
                }

            }
            catch (Exception ex)
            {
                ShowNotification(ex.Message);
            }
        }
    }
}