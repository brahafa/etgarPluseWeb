using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Logic;
using etgarPlus.Classes;
namespace etgarPlus.Pages
{
    public partial class AccountPage : System.Web.UI.Page
    {
        private Client client;
        private ClientBL clientBL;
        public CityBL cityBL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                clientBL = new ClientBL();
                cityBL = new CityBL();
                client = clientBL.getClientByEmail(Session["Email"].ToString());
                Email.Value = client.email;
                pass.Value = client.password;
                contactName.Value = client.contactName;
                NameC.Value = client.name;
                address.Value = client.address;
                city.Value = cityBL.getCityById(client.cityID);
                zipCode.Value = client.zipCode.ToString();
                phone.Value = client.phone;
                contactPhone.Value = client.contactPhone;
                openTime.Value = client.openTime;
                status.Value = client.status.ToString();
            }
        }
        protected void save(object sender, EventArgs e)
        {
           
            clientBL.UpdateClient(client.id, NameC.Value, contactName.Value, address.Value, Convert.ToInt32(city.Value),
            Convert.ToInt32(zipCode.Value), phone.Value, contactPhone.Value, openTime.Value, 3, Email.Value, pass.Value, Convert.ToInt32(status.Value));
            Session["Email"] = Email.Value;
            if (Session["Manager"] != null)
            {
                Response.Redirect("~/Pages/ManagerPage");
            }
            else
            {
                Response.Redirect("~/Pages/AccountPage");
            }
        }
    }
}