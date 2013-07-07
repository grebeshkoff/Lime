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
        //private int PersonId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //    ForceBinding();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //ViewState["PersonId"] = 0;
            //if(!IsPostBack)
                
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
            //if (e.Item is GridEditableItem && (e.Item as GridEditableItem).IsInEditMode)
            //{
            //    var editedItem = e.Item as GridEditableItem;
            //    var editMan = editedItem.EditManager;
            //    var editor = editMan.GetColumnEditor("ParameterType") as GridDropDownColumnEditor;
            //    if (editor != null)
            //    {
            //        editor.DataSource = new object[] {"Текст", "Подстановка"};
            //        editor.DataBind();
            //    }
            //}
            if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
            {
                
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

            if (type.SelectedValue == "Text")
            {
                list.Visible = false;
                label.Visible = false;
                text.Visible = false;
            }
            else
            {
                list.Visible = true;
                label.Visible = true;
                text.Visible = true;
            }
        }

        protected void ParametersGrid_InsertCommand(object sender, GridCommandEventArgs e)
        {
            ForceBinding();
            //var gridEditFormItem = e.Item as GridEditFormItem ?? ((GridDataItem)(e.Item)).EditFormItem;
            //if (gridEditFormItem != null)
            //{
            //    var dropDown = gridEditFormItem.FindControl("ParamTypeDropDownList") as DropDownList;
            //    dropDown.SelectedValue = "Text";

            //    var list = gridEditFormItem.FindControl("AddParamLable");
            //    var label = gridEditFormItem.FindControl("AddParamListBox");

                
            //        list.Visible = false;
            //        label.Visible = false;
            //}
        }
    }
}