using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Assignment2
{
    public partial class Cart : System.Web.UI.Page
    {
        private double totalPrice = 0;
        private int quantityC = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Cart";
            if (!Page.IsPostBack)
            {
                Assign2Entities db = new Assign2Entities();
                AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                var quantity = from q in db.Users_Have_Products where q.User.Username == user.UserName select q.amount;
                if (Session["User"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (Session["ProductID"] != null)
                    {
                        AddProductToBuy();
                        Session["ProductID"] = null;
                    
                    }
                    foreach(int q in quantity){
                        quantityC+=q;
                    }
                    if(quantityC<1){
                        buyNow.Visible = false;
                    }
                    BindInformation();
                    
                }

            }
        }
        private void AddProductToBuy()
        {
            int productId = Convert.ToInt32((String)Session["ProductID"]);
            AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
            Assign2Entities db = new Assign2Entities();
            var searchForProduct = from userproduct in db.Users_Have_Products where userproduct.Product_Id == productId && userproduct.User.Username == user.UserName select userproduct;
            int userID = (from user1 in db.Users where user1.Username == user.UserName select user1.Id).FirstOrDefault();

            if (searchForProduct.Count() == 0)
            {
                var newUserProduct = new Users_Have_Products();
                newUserProduct.Product_Id = productId;
                newUserProduct.User_Id = userID;
                newUserProduct.amount = 1;
                db.Users_Have_Products.Add(newUserProduct);
            }
            else
            {
                searchForProduct.FirstOrDefault().amount += 1;
            }

            db.SaveChanges();
        }
        private void BindInformation()
        {
            AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
            Assign2Entities db = new Assign2Entities();
            var userhasproducts = (from userhp in db.Users_Have_Products where userhp.User.Username == user.UserName select userhp).ToList();
            cartGridView.DataSource = userhasproducts;
            cartGridView.DataBind();
        }

        protected void cartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                System.Web.UI.HtmlControls.HtmlGenericControl price;
                Label quantity;
                price = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Row.Cells[3].Controls[1];
                quantity = (Label)e.Row.Cells[5].Controls[1];
                totalPrice += Convert.ToDouble(price.InnerHtml) * Convert.ToInt32(quantity.Text);
                totalPriceL.Text = totalPrice.ToString();
            }

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int idToDelete = Int32.Parse(deleteButton.CommandArgument);
            AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
            Assign2Entities db = new Assign2Entities();
            var userProduct = (from userproduct in db.Users_Have_Products where userproduct.Product_Id == idToDelete && userproduct.User.Username == user.UserName select userproduct).FirstOrDefault();
            if (userProduct.amount > 1)
            {
                userProduct.amount -= 1;
            }
            else
            {
                db.Users_Have_Products.Remove(userProduct);
            }
            db.SaveChanges();
            System.Web.UI.HtmlControls.HtmlAnchor cartAmount = (System.Web.UI.HtmlControls.HtmlAnchor)Master.FindControl("cart");
            var quantity = from q in db.Users_Have_Products where q.User.Username == user.UserName select q.amount;
            foreach (int q in quantity)
            {
                quantityC += q;
            }
            cartAmount.InnerHtml = "Cart (" + quantityC + ")";
            BindInformation();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            Button addButton = (Button)sender;
            int idToAdd = Int32.Parse(addButton.CommandArgument);
            AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
            Assign2Entities db = new Assign2Entities();
            var userProduct = (from userproduct in db.Users_Have_Products where userproduct.Product_Id == idToAdd && userproduct.User.Username == user.UserName select userproduct).FirstOrDefault();
            userProduct.amount += 1;
            db.SaveChanges();
            System.Web.UI.HtmlControls.HtmlAnchor cartAmount = (System.Web.UI.HtmlControls.HtmlAnchor)Master.FindControl("cart");
            var quantity = from q in db.Users_Have_Products where q.User.Username == user.UserName select q.amount;
            foreach (int q in quantity)
            {
                quantityC += q;
            }
            cartAmount.InnerHtml = "Cart (" + quantityC + ")"; 
            BindInformation();
        }

        protected void buyNow_Click(object sender, EventArgs e)
        {
            Session["Total"] = totalPriceL.Text;
            Response.Redirect("~/Checkout.aspx");

        }

        protected void contShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}