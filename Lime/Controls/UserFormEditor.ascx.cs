using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Lime.Data.Source;
using Parameter = Lime.Data.Source.Parameter;

namespace Lime.Controls
{
    public partial class UserFormEditor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                var parameters = (from p in db.Parameters
                                  where p.PersonId == 4
                                  select p);

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

                    var lable = new Label {Text = param.Name};
                    lableCell.Controls.Add(lable);
                    row.Cells.Add(lableCell);

                    if (param.Type == ParameterType.Text)
                    {
                        var textControl = new RadTextBox();
                        textControl.Text = param.Value;
                        controlCell.Controls.Add(textControl);
                    }
                    else
                    {
                        var control = new RadDropDownList();
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
                                control.Items.Add(new DropDownListItem(lookupValue.Value, lookupValue.Id.ToString()));
                            }
                            control.SelectedText = param1.Value;
                        }

                        controlCell.Controls.Add(control);
                    }
                    row.Cells.Add(controlCell);

                    ParameterTable.Rows.Add(row);
                }
            }
        }
    }
}