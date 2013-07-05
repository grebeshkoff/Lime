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
    public partial class ParameterListEditor : System.Web.UI.UserControl
    {
        private const int PersonId = 11;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NeedDataSourceParametersListView(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            
        }

        protected void ClientsRadGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var db = new LimeDataBase())
            {
                var person = db.GetPersonById(PersonId);
                ParametersGrid.DataSource = db.GetParameterListByPerson(person);
            }
        }

        protected void ParametersGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            
        }
    }
}