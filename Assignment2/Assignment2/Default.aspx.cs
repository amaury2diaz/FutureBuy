using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Default Page";

            if (Session["User"] != null)
            {
                AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                welcomeHeader.InnerHtml = "Welcome " + user.FirstName + " " + user.LastName+" "+ " to the craziest store ever.";
            }
            else
            {
                welcomeHeader.InnerHtml = "Welcome to the craziest store ever.";
            }
            if (!IsPostBack)
                BindInformation();
        }

        private void BindInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var getProducts = from product in db.Products where product.IsOnSale == true select product;
            storeGridView.DataSource = getProducts.ToList();
            storeGridView.DataBind();
        }

        protected void storeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            storeGridView.PageIndex = e.NewPageIndex;
            BindInformation();
        }
    }
}