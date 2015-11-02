using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Logic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.IO;
namespace etgarPlus.Pages
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        ClientBL clientBL = new ClientBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            etgarPlus.Logic.CityBL cityBL = new etgarPlus.Logic.CityBL();
            List<etgarPlus.Classes.City> listCity = cityBL.getAllCity();

            foreach (etgarPlus.Classes.City c in listCity)
            {
                selected_City.Items.Add(new ListItem(c._city, c._id.ToString()));
            }

        }
        protected void add_new_client(object sender, EventArgs e)
        {
            if (Email.Value.Length == 0 || !(Regex.IsMatch(Email.Value, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")))
            {
                Response.Write("<script language=javascript>alert('כתובת מייל שגוי');</script>");
                return;
            }
            if (clientBL.getClientByEmail(Email.Value) != null)
            {
                Response.Write("<script language=javascript>alert('כתובת מייל קיימת כבר במערכת, אנא הכנס כתובת מייל חדשה');</script>");
                return;
            }
            if (password.Value == "" || contactName.Value == "" || contactPhone.Value == "")
            {
                Response.Write("<script language=javascript>alert('מלא את כל השדות המסומנים ב *');</script>");
                return;

            }
            if (zipCode.Value == "")
            {
                zipCode.Value = "0";
            }
            if (NameC.Value == "")
            {
                NameC.Value = "אין";
            }
            if (address.Value == "")
            {
                address.Value = "אין";
            }
            if (phone.Value == "")
            {
                phone.Value = "אין";
            }
            if (openTime.Value == "")
            {
                openTime.Value = "אין";
            }

            clientBL.AddNewClient(clientBL.getMaxId(), NameC.Value, contactName.Value, address.Value, Convert.ToInt32(selected_City.Value),
            Convert.ToInt32(zipCode.Value), phone.Value, contactPhone.Value, openTime.Value, -1, Email.Value, password.Value, 1);
            Session["Email"] = Email.Value;
            sendEmailToManager();
            sendEmailToClient();
            Response.Redirect("~/Pages/Main");
        }

        private void sendEmailToClient()
        {
            string emailTo = Email.Value;
            string subject = "מערכת אתגר פלוס - אישור הרשמה";
            string body = "<body dir=\"rtl\"><h3>זוהי הודעה אוטומטית ממערכת אתגר פלוס</h3>";
            body += "<p>לנוחיותך מצורפים פרטי ההתחברות.</p>";
            body += "<p>כתובת דואר אלקטרוני: " + Email.Value + "</p>";
            body += "<p>סיסמה: " + password.Value + "</p></body>";
            Global.sendEmail(subject, body, emailTo);
        }
        private void sendEmailToManager()
        {
            string emailTo = System.Configuration.ConfigurationManager.AppSettings["Email"];
            string subject = "מערכת אתגר פלוס - אישור דרגת לקוח חדש";
            string body = "<body dir=\"rtl\"><h3>הודעת מערכת מס: " + clientBL.getMaxId() + "</h3>";
            body += "<p>לקוח חדש נקלט למערכת אנא אשר דרגת תשלום\n ";
            body += "<a href=\"http://localhost:2684/Pages/Login\"> לחץ כאן לקביעת דרגת תשלום</p>";
            body += "<p>שם העסק: " + NameC.Value + "</p>";
            body += "<p>טלפון העסק: " + phone.Value + "</p>";
            body += "<p>כתובת: " + address.Value + ", " + selected_City.Value + ", " + zipCode.Value + "</p>";
            body += "<p>שם איש הקשר: " + contactName.Value + "</p>";
            body += "<p>טלפון איש הקשר: " + contactPhone.Value + "</p>";
            body += "<p>כתובת דואר אלקטרוני: " + Email.Value + "</p></body>";
            Global.sendEmail(subject, body, emailTo);

        }
        
        public object script { get; set; }
    }
}