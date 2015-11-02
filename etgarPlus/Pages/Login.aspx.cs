using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using etgarPlus.Models;

namespace etgarPlus.Pages
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterHyperLink.NavigateUrl = "../Pages/RegisterPage";
                //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
                var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
                }
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Logic.ClientBL client = new Logic.ClientBL();
                string user = System.Configuration.ConfigurationManager.AppSettings["ManagerUserName"];
                string password = System.Configuration.ConfigurationManager.AppSettings["ManagerPassword"];
                if (UserName.Text.Equals(user) && Password.Text.Equals(password))
                {
                    Session["Manager"] = "1";
                    Response.Redirect("~/Pages/ManagerPage");
                }
                else
                {
                    // Validate the user password
                    int isValidUser = client.verifiedClientByEmailANDPassword(UserName.Text, Password.Text);
                    if (isValidUser > 0)
                    {
                        Session["Email"] = UserName.Text;
                        Session["Level"] = isValidUser;
                        Response.Redirect("~/Pages/Main");
                    }
                    else
                    {
                        FailureText.Text = "אימייל או סיסמה אינם נכונים";
                        ErrorMessage.Visible = true;
                    }
                }
            }
        }
    }
}