using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class CategoryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Category Details";
            if (!IsPostBack)
                BindInformation();
        }

        private void BindInformation()
        {
            int categoryId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["id"]));
            Assign2Entities db = new Assign2Entities();
            var getProducts = from product in db.Products where product.CategoryId == categoryId select product;
            cProductsGridView.DataSource = getProducts.ToList();
            cProductsGridView.DataBind();
        }
    }
}