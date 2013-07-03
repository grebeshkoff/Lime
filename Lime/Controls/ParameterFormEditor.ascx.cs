using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using Lime.Data.Source;
using Telerik.Web.UI;
using Panel = System.Web.UI.WebControls.Panel;

namespace Lime.Controls
{
    public partial class ParameterFormEditor : System.Web.UI.UserControl
    {
        

        private static readonly Color ErrorColor = Color.LightCoral;
        private static readonly Color NeutralColor = Color.White;
        private static readonly Color SavedColor = Color.YellowGreen;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ForceBinding();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (LookupParameterName.Text != "")
            {
                AddValue.Visible = true;
                DeleteValue.Visible = true;
            }
            else
            {
                AddValue.Visible = false;
                DeleteValue.Visible = false;
            }
        }


        public void ForceBinding()
        {
            ForceBinding(ViewState["PersonId"] != null ? Int32.Parse(ViewState["PersonId"].ToString()) : 0);
        }

        public void ForceBinding(int personId)
        {
            LookupParameterName.BackColor = NeutralColor;
            TextParameterName.BackColor = NeutralColor;
            if (personId == 0)
            {
                AdditionalParameterTable.Visible = false;
                ControlsTable.Visible = false;
                return;
            }
            else
            {
                AdditionalParameterTable.Visible = true;
                ControlsTable.Visible = true;
            }

            ViewState["PersonId"] = personId;
            using (var db = new LimeDataBase())
            {
                var person = db.GetPersonById(personId);
                FullNameLabel.Text = person.FullName;
                CodeLabel.Text = person.Code;
                GenderImage.ImageUrl = person.GenderImageUrl();
                var parameters = db.GetParameterListByPerson(person);
                if (parameters.Count == 0)
                {
                    ViewState["LookupParamId"] = -1;
                    ViewState["TextParamId"] = -1;
                    return;
                }
                var lookupParam = (from p in parameters
                                   where p.Type == ParameterType.Lookup
                                   select p).First();

                var lookupParamValues = (from l in db.LookupValues
                                         where l.ParamterId == lookupParam.Id
                                         select l).ToList();


                var textParam = (from p in parameters
                                 where p.Type == ParameterType.Text
                                 select p).First();

                TextParameterName.Text = textParam.Name;
                LookupParameterName.Text = lookupParam.Name;
                LookupList.Items.Clear();
                foreach (var lv in lookupParamValues)
                {
                    LookupList.Items.Add(new RadListBoxItem(lv.Value, lv.Id.ToString()));
                }

                ViewState["LookupParamId"] = lookupParam.Id;
                ViewState["TextParamId"] = textParam.Id;
            }
        }

        protected void AddValueClick(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LimeDataBase())
                {

                    int paramId=
                        Int32.Parse(ViewState["LookupParamId"].ToString());
                    if (paramId == -1)
                    {
                        LookupParameterName.BackColor = ErrorColor;
                        return;
                    }

                    if (LockupValueText.Text == "")
                    {
                        return;
                    }
                    foreach (RadListBoxItem item in LookupList.Items)
                    {
                        if (item.Text == LockupValueText.Text)
                        {
                            return;
                        }
                    }
                    
                    int newId=db.AddLookupValue(paramId, LockupValueText.Text);
                    LookupList.Items.Add(new RadListBoxItem(LockupValueText.Text, newId.ToString())); 
                }
                LockupValueText.Text = "";
            }
            catch (Exception)
            {


            }

            
        }

        protected void DeleteValueClick(object sender, EventArgs e)
        {
           try
           {
               using (var db = new LimeDataBase())
               {
                   db.DeleteLookupValue(Int32.Parse(LookupList.SelectedItem.Value));
               }
               LookupList.Items.Remove(LookupList.SelectedItem);
           }
           catch (Exception)
           {


           }
        }

        protected void SaveParameterClick(object sender, EventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                
                if (TextParameterName.Text == "")
                {
                    TextParameterName.BackColor = ErrorColor;
                    
                }
                else
                {
                    if (ViewState["TextParamId"].ToString() == "-1")
                    {

                        var param = new Parameter
                            {
                                Name = TextParameterName.Text,
                                PersonId = Int32.Parse(ViewState["PersonId"].ToString()),
                                Type = ParameterType.Text,
                                Value = "NaN"
                            };
                        ViewState["TextParamId"] = db.AddNewParameter(param);
                        TextParameterName.BackColor = SavedColor;
                    }
                    else
                    {
                        int pId = Int32.Parse(ViewState["TextParamId"].ToString());
                        var old = (from p in db.Parameters
                                   where p.Id == pId
                                   select p).First();
                        if(old.Name != TextParameterName.Text)
                        {
                            var param = new Parameter
                            {
                                Id = pId,
                                Name = TextParameterName.Text,
                                PersonId = Int32.Parse(ViewState["PersonId"].ToString()),
                                Type = ParameterType.Text,
                                Value = "NaN"
                            };
                            db.UpdatesExistParameter(param);
                            TextParameterName.BackColor = SavedColor;
                        }
                    }
                }
                if (LookupParameterName.Text == "")
                {
                    LookupParameterName.BackColor = ErrorColor;
                    
                }
                else
                {
                    if (ViewState["LookupParamId"].ToString() == "-1")
                    {

                        var param = new Parameter
                            {
                                Name = LookupParameterName.Text,
                                PersonId = Int32.Parse(ViewState["PersonId"].ToString()),
                                Type = ParameterType.Lookup,
                                Value = "NaN"
                            };
                        ViewState["LookupParamId"] = db.AddNewParameter(param);
                        LookupParameterName.BackColor = SavedColor;
                    }
                    else
                    {
                        int pId = Int32.Parse(ViewState["LookupParamId"].ToString());
                        var old = (from p in db.Parameters
                                   where p.Id == pId
                                   select p).First();
                        if (old.Name != LookupParameterName.Text)
                        {
                            var param = new Parameter
                            {
                                Id = pId,
                                Name = LookupParameterName.Text,
                                PersonId = Int32.Parse(ViewState["PersonId"].ToString()),
                                Type = ParameterType.Lookup,
                                Value = "NaN"
                            };
                            db.UpdatesExistParameter(param);
                            LookupParameterName.BackColor = SavedColor;
                        }
                    }
                }

            }



    }

        protected void CancelButtonClick(object sender, EventArgs e)
        {
            ForceBinding();
        }
    }
}