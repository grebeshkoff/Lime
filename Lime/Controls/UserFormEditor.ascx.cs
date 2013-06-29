using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Lime.Data.Source;

namespace Lime.Controls
{
    public partial class UserFormEditor : UserControl
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

                if (!parameters.Any())
                {
                    Controls.Add(new Label()
                        {
                            Text = @"Для пользователя не заданы параметры"
                        });
                }

                foreach (var param in parameters)
                {
                    var row  = new TableRow();

                    var lableCell = new TableCell();
                    var controlCell = new TableCell();

                    var lable = new Label {Text = param.Name + @" :"};
                    lableCell.Controls.Add(lable);
                    row.Cells.Add(lableCell);

                    if (param.Type == ParameterType.Text)
                    {
                        var textControl = new RadTextBox();
                        textControl.ID = param.Id.ToString();
                        textControl.Text = param.Value;
                        controlCell.Controls.Add(textControl);
                    }
                    else
                    {
                        var lookupControl = new RadDropDownList();

                        using (var db1 = new LimeDataBase())
                        {
                            var param1 = param;
                            var list = from vals in db1.LookupValues
                                       where vals.ParamterId == param1.Id
                                       select new LookupValue()
                                       {
                                           Id = vals.Id,
                                           Value = vals.Value
                                       };
                            foreach (var lookupValue in list)
                            {
                                lookupControl.Items.Add(new DropDownListItem(lookupValue.Value, lookupValue.Id.ToString()));
                            }
                            lookupControl.SelectedText = param1.Value;
                        }

                        controlCell.Controls.Add(lookupControl);
                    }
                    row.Cells.Add(controlCell);

                    ParameterTable.Rows.Add(row);
                }
            }
        }
    }
}