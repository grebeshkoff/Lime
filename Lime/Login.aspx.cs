using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lime.Data.Source;

namespace Lime
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserLogin_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            string username = UserLogin.UserName;
            string pwd = UserLogin.Password;

            using (var db = new LimeDataBase())
            {
                var query = (from user in db.Users
                             where user.Name == username
                             select user).First();
                if (query.Password == pwd)
                {
                    Session["UserAuthentication"] = username;
                    Session.Timeout = 1;
                    e.Authenticated = true;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["UserAuthentication"] = "";
                }
            }
        }
    }
}