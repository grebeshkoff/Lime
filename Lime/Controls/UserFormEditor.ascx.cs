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



        public UserFormEditor()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                //var Person = (from p in db.Persons
                //              where p.Id == 6
                //              select p).First();

                var parameters = (from p in db.Parameters
                                  where p.PersonId == 6
                                  select p);
            
                var table = new Table();


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
                        var list = from vals in db.LookupValues
                                   where vals.ParamterId == param.Id
                                   select new LookupValue()
                                       {
                                           Id = vals.Id, Value = vals.Value
                                       };
                        foreach (var lookupValue in list)
                        {
                            control.Items.Add(new DropDownListItem(lookupValue.Value, lookupValue.Id.ToString()));
                        }
                        
                        control.DataSource = list;
                        controlCell.Controls.Add(control);
                    }
                    row.Cells.Add(controlCell);

                    table.Rows.Add(row);
                }

                Controls.Add(table);
            }

        }
    }
}