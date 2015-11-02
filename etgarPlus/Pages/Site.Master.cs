using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Classes;
using etgarPlus.Logic;
using System.Net;
namespace etgarPlus.Pages
{
    public partial class SiteMaster : MasterPage
    {
        private Client client;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Manager"] != null)
            {
                registerUser.Style.Add("display", "inline");
                manager.Style.Add("display", "inline");
                loginProp.Style.Add("display", "none");
                userProp.Style.Add("display", "block");

            }
            else if (Session["Email"] != null)
            {
                registerUser.Style.Add("display", "inline");
                loginProp.Style.Add("display", "none");
                userProp.Style.Add("display", "block");

                if (Session["Manager"] != null)
                {
                    manager.Style.Add("display", "inline");
                }
                else
                {
                    ClientBL cBL = new ClientBL();
                    client = cBL.getClientByEmail(Session["Email"].ToString());
                    if (!client.contactName.Equals(""))
                    {
                        Name.InnerText = client.contactName;
                    }
                    else
                    {
                        Name.InnerText = client.name;
                    }
                    manager.Style.Add("display", "none");
                }
            }
            else
            {
                loginProp.Style.Add("display", "inline");
                userProp.Style.Add("display", "none");
                registerUser.Style.Add("display", "none");
                manager.Style.Add("display", "none");
            }
        }

        protected void logOut(object sender, EventArgs e)
        {
            Session.Clear();
            Main.listBikeToOrder = new List<Bicycles>();
            Main.listCountToOrder = new List<int>();
            Response.Redirect("../Pages/Main");
        }
    }
}