using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ClientsRadGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                var genders = db.Genders;




                ClientsRadGrid.DataSource = db.Persons;

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
            } 
        }
    }
}