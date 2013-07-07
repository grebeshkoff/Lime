using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lime.Data.Source;
using Telerik.Web.UI;
using Parameter = Lime.Data.Source.Parameter;

namespace Lime.Controls
{
    public partial class ParameterListEditor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        public void ForceBinding()
        {
            ForceBinding(ViewState["PersonId"] != null ? Int32.Parse(ViewState["PersonId"].ToString()) : 0);
        }

        public void ForceBinding(int personId)
        {
            using (var db = new LimeDataBase(HttpContext.Current))
            {
                var person = db.GetPersonById(personId);
                if (person != null)
                {
                    ViewState["PersonId"] = personId;
                    FullNameLabel.Text = person.FullName;
                    CodeLabel.Text = person.Code;
                    GenderImage.ImageUrl = person.GenderImageUrl();
                    var paramList = db.GetParametersByPerson(person);
                    if (paramList.Any())
                    {
                        ParametersGrid.DataSource = paramList;
                    }
                    else
                    {
                        ParametersGrid.DataSource = new List<Parameter>();
                    }
                    ParametersGrid.DataBind();
                }
            }
        }

        protected void ParametersGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (ViewState["PersonId"] != null)
            {
                using (var db = new LimeDataBase(HttpContext.Current))
                {
                    var person = db.GetPersonById((int)ViewState["PersonId"]);
                    var paramList = db.GetParametersByPerson(person);
                    if (paramList.Any())
                    {
                        ParametersGrid.DataSource = paramList;
                    }
                    else
                    {
                        ParametersGrid.DataSource = new List<Parameter>();
                    }
                }
            }
        }

        protected void ParametersGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
            {
                //var editedItem = e.Item as GridEditableItem;
                //var editMan = editedItem.EditManager;
                //var editor = editMan.GetColumnEditor("ParameterType");

            }
        }

        protected void ParametersGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void ParamTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = sender as DropDownList;
            var list = type.Parent.FindControl("AddParamLable");
            var label = type.Parent.FindControl("AddParamListBox");
            var text = type.Parent.FindControl("AddParamTextBox");
            var add = type.Parent.FindControl("AddValueButton");
            var delete = type.Parent.FindControl("DeleteValueButton");

            if (type.SelectedValue == "Text")
            {
                list.Visible = false;
                label.Visible = false;
                text.Visible = false;
                add.Visible = false;
                delete.Visible = false;
            }
            else
            {
                list.Visible = true;
                label.Visible = true;
                text.Visible = true;
                add.Visible = true;
                delete.Visible = true;
            }
        }

        protected void ParametersGrid_InsertCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void AddValueButton_Click(object sender, EventArgs e)
        {
            var btn = sender as RadButton;
            var newValue = btn.Parent.FindControl("AddParamTextBox") as RadTextBox;
            var list = btn.Parent.FindControl("AddParamListBox") as RadListBox;
            list.Items.Add(new RadListBoxItem(newValue.Text));
            newValue.Text = "";
        }

        protected void DeleteValueButton_Click(object sender, EventArgs e)
        {
            var btn = sender as RadButton;
            var list = btn.Parent.FindControl("AddParamListBox") as RadListBox;
            list.Items.Remove(list.SelectedItem);
        }
    }
}