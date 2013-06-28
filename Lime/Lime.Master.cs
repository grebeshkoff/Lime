using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lime.Data.Source;

namespace Lime
{
    public partial class Lime : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserAuthentication"] = HttpContext.Current.User.ToString();
        }

        protected void UserLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Session["UserAuthentication"] = "";
        }
    }
}