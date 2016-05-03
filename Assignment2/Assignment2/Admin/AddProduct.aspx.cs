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
namespace Assignment2.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Add product";

            if (!IsPostBack)
            {
                BindInformation();
            }
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

        protected void createProductButton_Click(object sender, EventArgs e)
        {
            if (pImage.HasFile == false)
            {
                notUploadedError.Text = "Upload an image Please!!";
                return;
            }
                

                // Retrieve storage account from connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve a reference to a container. 
                CloudBlobContainer container = blobClient.GetContainerReference("filestorage");

                // Create the container if it doesn't already exist.
                container.CreateIfNotExists();

                // Retrieve reference to a blob named from the given file
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(pImage.PostedFile.FileName));

                if (blockBlob.Exists())
                    blockBlob.Delete();

                // Create the blob
                using (MemoryStream memoryStream = new MemoryStream(pImage.FileBytes))
                {
                    blockBlob.UploadFromStream(memoryStream);
                }

                // now the file is in the cloud make a note of that in our database so we can pull it later
                var newProduct = new Product();
                newProduct.CategoryId = Convert.ToInt32(categoryList.SelectedValue);
                newProduct.Name = pName.Text;
                newProduct.ShortDescription = pSDescription.Text;
                newProduct.LongDescription = pLDescription.Text;
                newProduct.Price = Math.Round(Convert.ToDecimal(pPrice.Text),2);
                newProduct.SalePrice = Math.Round(Convert.ToDecimal(pSPrice.Text),2);
                if (yes.Checked)
                {
                    newProduct.IsOnSale = true;
                }
                else
                {
                    newProduct.IsOnSale= false;
                }
                newProduct.ImageName = Path.GetFileName(pImage.PostedFile.FileName);

                var db = new Assign2Entities();

                db.Products.Add(newProduct);
                db.SaveChanges();
                notUploadedError.Text = "";
                Response.Redirect("~/Default.aspx");
           
        }

        protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}