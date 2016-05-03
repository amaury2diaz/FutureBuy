using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Assignment2
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Product Details";
            displayProduct();
        }
        private void displayProduct()
        {
            if (Session["User"] != null)
            {
                addToCartButton.Visible = true;
            }
            else
            {
                addToCartButton.Visible = false;
            }
            
            int productId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["productId"]));

            Assign2Entities db = new Assign2Entities();

            var queryProduct = from product in db.Products where product.ProductId == productId select new { product.Name, product.Price, product.SalePrice, product.ShortDescription, product.LongDescription, product.ImageName, product.IsOnSale };

            foreach (var product in queryProduct)
            {
                pName.InnerHtml = product.Name;
                if (product.IsOnSale)
                {
                    pPrice.InnerHtml = product.SalePrice.ToString();
                }
                else
                {
                    pPrice.InnerHtml = product.Price.ToString();
                }
                
                pSDescription.InnerHtml = product.ShortDescription;
                pLongDescription.Text = product.LongDescription;
                image.ImageUrl = "~/FileHandler.ashx?fileid=" + productId;
            }

            showComments();
        }


        private void showComments()
        {
            int productId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["productId"]));
            Assign2Entities db = new Assign2Entities();
            commentGridView.DataSource = (from comment in db.Comments where comment.Product_Id == productId select new { comment.Content, comment.Published, comment.FName, comment.LName }).ToList();
            commentGridView.DataBind();
        }

        protected void addToCartButton_Click(object sender, EventArgs e)
        {
            String productId = System.Web.HttpUtility.UrlDecode(Request["productId"]);
            Session["ProductID"] = productId;
            Response.Redirect("~/Cart.aspx");
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Write("<script>alert('" + "You cannot comment if you are not logged" + "')</script>");
            }
            else
            {
                AuthenticateService.AlgonquinCollegeUser user = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                int productId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["productId"]));
                Assign2Entities db = new Assign2Entities();
                var newComment = new Comment();
                
                var queryBadWord = from bword in db.Bad_Words select bword.Word;
                newComment.Published = DateTime.Now;

                foreach (string bword in queryBadWord)
                {
                    commentBox.Text = commentBox.Text.Replace(bword, "*******");

                }
                newComment.Content = commentBox.Text;
                newComment.Product_Id = productId;
                newComment.FName = user.FirstName;
                newComment.LName = user.LastName;
                db.Comments.Add(newComment);
                db.SaveChanges();
                commentBox.Text = "";
                showComments();
            }
        }
    }
}