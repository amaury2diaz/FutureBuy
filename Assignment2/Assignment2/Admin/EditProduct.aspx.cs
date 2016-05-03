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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Edit product";
            if (!IsPostBack)
            {
                BindInformation();
                int productId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["id"]));
                Assign2Entities db = new Assign2Entities();
                var productQuery = from product in db.Products where product.ProductId == productId select new {product.CategoryId, product.ImageName, product.IsOnSale, product.LongDescription, product.Name, product.Price,product.SalePrice,product.ShortDescription};

                foreach(var product in productQuery){
                    pName.Text = product.Name;
                    pSDescription.Text = product.ShortDescription;
                    pLDescription.Text = product.LongDescription;
                    pPrice.Text = (product.Price).ToString();
                    pSPrice.Text = (product.SalePrice).ToString();
                    if (product.IsOnSale)
                    {
                        yes.Checked = true;
                        no.Checked = false;
                    }
                    else
                    {
                        yes.Checked = false;
                        no.Checked = true;
                    }
                    image.ImageUrl = "~/FileHandler.ashx?fileid=" + productId;
                    categoryList.SelectedValue = product.CategoryId.ToString();

                }
            }
        }

        protected void editProductButton_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(System.Web.HttpUtility.UrlDecode(Request["id"]));
            Assign2Entities db = new Assign2Entities();
            var productToUpdate = (from product in db.Products where product.ProductId == productId select product).FirstOrDefault();
            productToUpdate.Name = pName.Text;
            productToUpdate.ShortDescription = pSDescription.Text;
            productToUpdate.LongDescription = pLDescription.Text;
            productToUpdate.Price = Convert.ToDecimal(pPrice.Text) ;
            productToUpdate.SalePrice = Convert.ToDecimal(pSPrice.Text);
            if (yes.Checked)
            {
                productToUpdate.IsOnSale = true;
                
            }
            else
            {
                productToUpdate.IsOnSale = false;
            }

            if (pImage.HasFile == true)
            {
                // Retrieve storage account from connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve a reference to a container. 
                CloudBlobContainer container = blobClient.GetContainerReference("filestorage");

                // Create the container if it doesn't already exist.
                container.CreateIfNotExists();

                // Retrieve reference to a blob named from the given file
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(pImage.PostedFile.FileName));
                CloudBlockBlob blockBlobToDelete = container.GetBlockBlobReference(productToUpdate.ImageName);

                if (blockBlob.Exists())
                    blockBlob.Delete();
                if (blockBlobToDelete.Exists())
                blockBlobToDelete.Delete();

                // Create the blob
                using (MemoryStream memoryStream = new MemoryStream(pImage.FileBytes))
                {
                    blockBlob.UploadFromStream(memoryStream);
                }
                productToUpdate.ImageName = Path.GetFileName(pImage.PostedFile.FileName);
            }
            productToUpdate.CategoryId = Convert.ToInt32(categoryList.SelectedValue);
            db.SaveChanges();
            Response.Redirect("~/Admin/Default.aspx");
        }

        private void BindInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var categories = db.Categories.OrderBy(bw => bw.Name);
            categoryList.DataSource = categories.ToList();

            categoryList.DataTextField = "Name";
            categoryList.DataValueField = "Id";

            categoryList.DataBind();
        }
    }
}