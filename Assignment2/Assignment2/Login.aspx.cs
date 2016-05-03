using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("currentPage");
            control.InnerHtml = "Login";
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            TextBox AdminPass = (TextBox)Login1.FindControl("APassword");
            String adminPass = AdminPass.Text;
            bool Authenticated = false;
            Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);
            if(Authenticated){
                AuthenticateService.AlgonquinCollegeUser username = (AuthenticateService.AlgonquinCollegeUser)Session["User"];
                Assign2Entities db = new Assign2Entities();
                int searchForUser = (from user in db.Users where user.Username == username.UserName select user).Count();
                if(searchForUser == 0){
                    var newUser = new User();
                    newUser.FirstName = username.FirstName;
                    newUser.LastName = username.LastName;
                    if(adminPass.Equals("12345")){
                        newUser.Admin = true;
                    }
                    else
                    {
                        newUser.Admin = false;
                    }
                    
                    newUser.Username = username.UserName;
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    var getUser = (from user in db.Users where user.Username == username.UserName select user).FirstOrDefault();
                    if (adminPass.Equals("12345"))
                    {
                        getUser.Admin = true;
                    }
                    else
                    {
                        getUser.Admin = false;
                    }
                    db.SaveChanges();
                }
            }
            e.Authenticated = Authenticated;

        }

        private bool SiteSpecificAuthenticationMethod(string Username, string Password)
        {
            AuthenticateService.AuthenticateServiceSoapClient client = new AuthenticateService.AuthenticateServiceSoapClient();
            AuthenticateService.AlgonquinCollegeUser user = client.AuthenticateUser(Username,Password);
            if (user != null)
            {
                Session["User"] = user;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}