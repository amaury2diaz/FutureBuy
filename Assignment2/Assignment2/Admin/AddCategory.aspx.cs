using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2.Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Add Category";
            if (!IsPostBack)
            {
                BindInformation();
            }
        }
        private void BindInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var categories = db.Categories.OrderBy(category => category.Name);
            categoryGridView.DataSource = categories.ToList();
            categoryGridView.DataBind();
        }
        protected void editButton_Click(object sender, EventArgs e)
        {
            Button editButton = (Button)sender;
            String idToEdit = editButton.CommandArgument;
            Response.Redirect("~/Admin/EditCategory.aspx?" +
               "id=" + System.Web.HttpUtility.UrlEncode(idToEdit));

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            var db = new Assign2Entities();
            var newCategory = new Category();
            newCategory.Name = addBox.Text;
            db.Categories.Add(newCategory);
            db.SaveChanges();

            BindInformation();
            addBox.Text = "";
        }
    }
}