using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;
using System.IO;
using System.Configuration;
using Microsoft.Azure;

namespace Assignment2.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Admin Home";
            if (!IsPostBack)
            {
                BindProductInformation();
                BindCategoryInformation();
            }

        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Button editButton = (Button)sender;
            String idToEdit = editButton.CommandArgument;
            Response.Redirect("~/Admin/EditCategory.aspx?" +
               "id=" + System.Web.HttpUtility.UrlEncode(idToEdit));
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int idToDelete = Int32.Parse(deleteButton.CommandArgument);
            var db = new Assign2Entities();
            var productToDelete = db.Products.Where(p => p.CategoryId == idToDelete);
            var categoryToDelete = db.Categories.Where(c => c.Id == idToDelete).FirstOrDefault();
            if (productToDelete.Count() > 0)
            {
                foreach (var product in productToDelete)
                {
                    // Retrieve storage account from connection string.
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

                    // Create the blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // Retrieve reference to a previously created container.
                    CloudBlobContainer container = blobClient.GetContainerReference("filestorage");

                    // Retrieve reference to a blob named "myblob.txt".
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(product.ImageName);
                    var commentsToDelete = db.Comments.Where(co => co.Product_Id == product.ProductId);
                    var removeFromCart = db.Users_Have_Products.Where(up => up.Product_Id == product.ProductId);

                    db.Comments.RemoveRange(commentsToDelete);
                    db.Users_Have_Products.RemoveRange(removeFromCart);
                    // Delete the blob.
                    if (blockBlob.Exists())
                    blockBlob.Delete();

                    db.Products.Remove(product);
                }
            }
            db.Categories.Remove(categoryToDelete);
            db.SaveChanges();
            BindProductInformation();
            BindCategoryInformation();
        }

        protected void editpButton_Click(object sender, EventArgs e)
        {
            Button editpButton = (Button)sender;
            String idToEdit = editpButton.CommandArgument;
            Response.Redirect("~/Admin/EditProduct.aspx?" +
               "id=" + System.Web.HttpUtility.UrlEncode(idToEdit));
        }

        protected void deletepButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int idToDelete = Int32.Parse(deleteButton.CommandArgument);
            var db = new Assign2Entities();
            var productToDelete = db.Products.Where(p => p.ProductId == idToDelete).FirstOrDefault();
            var commentsToDelete = db.Comments.Where(co => co.Product_Id == productToDelete.ProductId);
        
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("filestorage");

            // Retrieve reference to a blob named "myblob.txt".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(productToDelete.ImageName);

            // Delete the blob.
            blockBlob.Delete();

            db.Comments.RemoveRange(commentsToDelete);
            db.Products.Remove(productToDelete);

            db.SaveChanges();
            BindProductInformation();
            BindCategoryInformation();
        }

        private void BindProductInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var products = db.Products.OrderBy(pr => pr.Name);

            productsGridView.DataSource = products.ToList();
            productsGridView.DataBind();
        }
        private void BindCategoryInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var categories = db.Categories.OrderBy(cat => cat.Name);
            categoriesGridView.DataSource = categories.ToList();
            categoriesGridView.DataBind();
        }
    }
}