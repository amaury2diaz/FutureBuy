using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2.Admin
{
    public partial class BadWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Bad Words";
            if (!IsPostBack)
            {
                BindInformation();
            }
        }
        private void BindInformation()
        {
            Assign2Entities db = new Assign2Entities();
            var bws = db.Bad_Words.OrderBy(bw => bw.Word);
            bwGridView.DataSource = bws.ToList();
            bwGridView.DataBind();
        }
        
        protected void addButton_Click(object sender, EventArgs e)
        {
            var db = new Assign2Entities();
            var newBW = new Bad_Words();
            newBW.Word = addBox.Text;
            db.Bad_Words.Add(newBW);
            db.SaveChanges();

            BindInformation();
            addBox.Text = "";
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int idToDelete = Int32.Parse(deleteButton.CommandArgument);
            var db = new Assign2Entities();
            var fileToDelete = db.Bad_Words.Where(b => b.BadWordId == idToDelete).FirstOrDefault();
            db.Bad_Words.Remove(fileToDelete);
            db.SaveChanges();

            BindInformation();
        }
    }
}