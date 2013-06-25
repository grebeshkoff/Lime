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
                var query = from person in db.Persons
                            select new
                            {
                                FullName = person.FullName,
                                Code = person.Code,
                                GenderName = person.Gender.Name
                                
                            };
                
                ClientsRadGrid.DataSource = query;
            }
        }

        protected void ClientsRadGrid_ItemCreated(object sender, GridItemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected void ClientsRadGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                
            }
        }
    }
}