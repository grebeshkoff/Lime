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
            ForceRebind();
        }

        public void ForceRebind()
        {
                ForceRebind(ViewState["PersonId"]!=null? Int32.Parse(ViewState["PersonId"].ToString()):0);
        }

        public void ForceRebind(int userId)
        {
            using (var db = new LimeDataBase(HttpContext.Current))
            {
                var paramDictionary = new Dictionary<int, string>();
                if (userId == 0)
                {
                    ControlsTable.Visible = false;
                    return;
                }
                else
                {
                    ControlsTable.Visible = true;
                }


                ViewState["PersonId"] = userId;
                var person = db.GetPersonById(userId);
                var parameters = (from p in db.Parameters
                                  where p.PersonId == person.Id
                                  select p);

                FullNameLabel.Text = person.FullName;
                CodeLabel.Text = person.Code;
                GenderImage.ImageUrl = person.GenderImageUrl();

                if (!parameters.Any())
                {
                    ControlsTable.Visible = false;
                }
                else
                {
                    ControlsTable.Visible = true;
                }

                ParameterTable.Rows.Clear();

                foreach (var param in parameters)
                {
                    var row = new TableRow();

                    var lableCell = new TableCell();
                    var controlCell = new TableCell();

                    var lable = new Label {Text = param.Name + @" :"};
                    lableCell.Controls.Add(lable);
                    row.Cells.Add(lableCell);

                    if (param.Type == ParameterType.Text)
                    {
                        var textControl = new RadTextBox();
                        textControl.ID = "clientparamId" + param.Id;
                        textControl.Text = param.Value;
                        controlCell.Controls.Add(textControl);

                        paramDictionary.Add(param.Id, textControl.ID);
                    }
                    else
                    {
                        var lookupControl = new RadDropDownList();

                        using (var db1 = new LimeDataBase(HttpContext.Current))
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
                                lookupControl.Items.Add(new DropDownListItem(lookupValue.Value,
                                                                             lookupValue.Id.ToString()));
                            }
                            lookupControl.ID = "clientparamId" + param1.Id;
                            if (param1.Value != "NaN")
                                lookupControl.SelectedText = param1.Value;

                            paramDictionary.Add(param1.Id, lookupControl.ID);
                        }

                        controlCell.Controls.Add(lookupControl);
                    }
                    ViewState["ParamDictionary"] = paramDictionary;

                    row.Cells.Add(controlCell);
                    ParameterTable.Rows.Add(row);
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var paramDictionary = ViewState["ParamDictionary"] as Dictionary<int, string>;

            if (paramDictionary != null)
            {
                foreach (var param in paramDictionary)
                {
                    int paramId = param.Key;
                    string paramControl = param.Value;

                    string paramValue = "NaN";
                    
                    var control = ParameterTable.FindControl(paramControl);
                    if (control is RadTextBox)
                    {
                        var tb = control as RadTextBox;
                        paramValue = tb.Text;
                    }
                    else
                    {
                        if (control is RadDropDownList)
                        {
                            var tb = control as RadDropDownList;
                            paramValue = tb.SelectedText;
                        }
                    }
                    using (var db = new LimeDataBase(HttpContext.Current))
                    {
                        db.UpdateParameterValue(paramId, paramValue);
                    }
                    
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ForceRebind();
        }
    }
}