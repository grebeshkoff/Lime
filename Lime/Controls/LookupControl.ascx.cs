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
    public partial class LookupControl : System.Web.UI.UserControl
    {
        private int paramId = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                var lookup = from l in db.LookupValues
                             where l.ParamterId == paramId
                             select l;

                foreach (var lookupValue in lookup)
                {
                    LookupList.Items.Add(new RadListBoxItem(lookupValue.Value, lookupValue.Id.ToString()));
                }
            }
        }
    }
}