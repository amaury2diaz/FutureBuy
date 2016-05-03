using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Checkout";
            if (Session["User"] == null || Session["Total"]==null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                totalAmount.Text = (String)Session["Total"];
            }
        }

        protected void proceed_Click(object sender, EventArgs e)
        {
            requirednameBox.Validate();
            requiredNumberBox.Validate();
            requiredEDate.Validate();
            regexNumberBox.Validate();
            if (regexNumberBox.IsValid && requiredEDate.IsValid && requirednameBox.IsValid && requiredNumberBox.IsValid)
            {
                Assign2Entities db = new Assign2Entities();
                AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                var getAllUserProducts = from up in db.Users_Have_Products where up.User.Username == user.UserName select up;
                db.Users_Have_Products.RemoveRange(getAllUserProducts);
                db.SaveChanges();
                Response.Redirect("~/ThankYou.aspx");
            }
            
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}