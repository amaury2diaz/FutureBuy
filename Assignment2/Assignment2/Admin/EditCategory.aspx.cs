using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2.Admin
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Edit Category";
            if (!IsPostBack)
            {
                int categoryId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["id"]));
                Assign2Entities db = new Assign2Entities();
                String getCategoryName = (from category in db.Categories where category.Id == categoryId select category.Name).FirstOrDefault();
                addBox.Text = getCategoryName;
            }
            

        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["id"]));
            Assign2Entities db = new Assign2Entities();
            var categoryToUpdate = (from category in db.Categories where category.Id == categoryId select category).FirstOrDefault();
            categoryToUpdate.Name = addBox.Text;
            
            db.SaveChanges();
            Response.Redirect("~/Admin/Default.aspx");
        }
    }
}