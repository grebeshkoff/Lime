using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lime.Data.Source;
using Telerik.Web.UI;

namespace Lime.Controls
{
    public partial class ParameterFormEditor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                var person = db.GetPersonById(6);
                var parameters = (from p in db.Parameters
                                  where p.PersonId == person.Id
                                  select p);

                FullNameLabel.Text = person.FullName;
                CodeLabel.Text = person.Code;
                GenderImage.ImageUrl = person.GenderImageUrl();


                foreach (var parameter in parameters)
                {
                    var row = new TableRow();

                    var nameCell = new TableCell();
                    nameCell.Controls.Add(new RadTextBox
                            {
                                Text = parameter.Name
                            });
                    row.Cells.Add(nameCell);

                    var typeCell = new TableCell();
                    var typeList = new RadDropDownList();
                    typeList.Items.Add(new DropDownListItem("Текст", ParameterType.Text.ToString()));
                    typeList.Items.Add(new DropDownListItem("Список", ParameterType.Lookup.ToString()));
                    typeList.SelectedValue = parameter.Type.ToString();

                    typeCell.Controls.Add(typeList);
                    row.Cells.Add(typeCell);
                    ParametersTable.Rows.Add(row);
                }
            }
        }

        
    }
}