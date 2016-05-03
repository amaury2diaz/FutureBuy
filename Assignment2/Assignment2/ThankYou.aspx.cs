using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Thank You";
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}