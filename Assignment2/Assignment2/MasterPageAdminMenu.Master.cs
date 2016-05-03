using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class MasterPageAdminMenu : System.Web.UI.MasterPage
    {
        private int quantityC = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                Assign2Entities db = new Assign2Entities();
                var quantity = from q in db.Users_Have_Products where q.User.Username == user.UserName select q.amount;
                bool adminRights = (from u in db.Users where u.Username == user.UserName select u.Admin).FirstOrDefault();
                foreach (int q in quantity)
                {
                    quantityC += q;
                }
                userID.InnerHtml = user.FirstName + "<span class=\"caret\"></span>";
                buttonlogout.Visible = true;
                loginOrLogout.Visible = false;
                if (adminRights)
                {
                    welcomeAdmin.Visible = true;
                }
                cart.Visible = true;
                cart.InnerHtml = "Cart (" + quantityC + ")"; 
            }
        }

        protected void buttonlogout_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            userID.InnerHtml = "User" + "<span class=\"caret\"></span>";
            buttonlogout.Visible = false;
            loginOrLogout.Visible = true;
            welcomeAdmin.Visible = false;
            cart.Visible = false;
            Response.Redirect("Default.aspx");
        }
    }
}