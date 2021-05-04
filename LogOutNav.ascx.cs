using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Term_Project
{
    public partial class LogoutNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
}