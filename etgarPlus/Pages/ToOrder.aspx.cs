using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Classes;
using etgarPlus.Logic;
using System.Net;
using System.IO;
using System.Globalization;


namespace etgarPlus.Pages
{
    public partial class ToOrder : System.Web.UI.Page
    {
        CategoryBL category = new CategoryBL();
        SubCategoryBL subCategory = new SubCategoryBL();
        ProducerBL producer = new ProducerBL();
        ColorBL color = new ColorBL();
        SizeBL size = new SizeBL();
        ClientBL clientBl = new ClientBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            //ClientBL clientBL = new ClientBL();
            if (Main.listBikeToOrder.Count > 0)
            {
                for (int i = 0; i < Main.listBikeToOrder.Count; i++)
                {
                    TableRow dr = new TableRow();
                    TableCell cell = new TableCell();
                    //שם יצרן
                    cell.Text = producer.GetProducer(Main.listBikeToOrder[i]._Name).ToString();
                    dr.Cells.Add(cell);
                    //cell = new TableCell();
                    //cell.Text = "דגם";
                    //dr.Cells.Add(cell);
                    //קטגוריה ראשית
                    cell = new TableCell();
                    cell.Text = category.getCategoryById(Main.listBikeToOrder[i]._MainCategoryId).ToString();
                    dr.Cells.Add(cell);
                    //קטגוריה משנית
                    cell = new TableCell();
                    cell.Text = subCategory.GetSubCategory(Main.listBikeToOrder[i]._SubCategoryId).ToString();
                    dr.Cells.Add(cell);
                    //מידה
                    cell = new TableCell();
                    cell.Text = size.getSize(Main.listBikeToOrder[i]._size).ToString();
                    dr.Cells.Add(cell);
                    //צבע
                    cell = new TableCell();
                    cell.Text = color.getColorById(Main.listBikeToOrder[i]._colorId).ToString();
                    dr.Cells.Add(cell);
                    //כמות
                    cell = new TableCell();
                    cell.Text = Main.listCountToOrder[i].ToString();
                    dr.Cells.Add(cell);
                    //מחיר לפריט
                    Double price = 0;
                    cell = new TableCell();
                    if (Convert.ToInt32(Session["Level"]) == 1)
                    {
                        price = (Main.listBikeToOrder[i]._RegularPrice * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["sitonai"]));
                    }
                    else if (Convert.ToInt32(Session["Level"]) == 2)
                    {
                        price = (Main.listBikeToOrder[i]._RegularPrice * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["kimonai"]));
                    }
                    else if (Convert.ToInt32(Session["Level"]) == 4)
                    {
                        price = Main.listBikeToOrder[i]._ClubPrice;
                    }
                    else
                    {
                        price = Main.listBikeToOrder[i]._RegularPrice;
                    }
                    cell.Text = price.ToString();
                    dr.Cells.Add(cell);
                    //מחיר כולל
                    cell = new TableCell();
                    cell.Text = (price * Main.listCountToOrder[i]).ToString();
                    dr.Cells.Add(cell);

                    newListBikeTable.Rows.Add(dr);
                }
            }
        }
        protected void cleanOrder_Click(object sender, EventArgs e)
        {
            resetListToOrder();
            Response.Redirect(Request.RawUrl);
        }
        private void sendOrderEmail(string emailTo)
        {
            Client c = clientBl.getClientByEmail(Session["Email"].ToString());
            CityBL cityBl = new CityBL();
            string subject = "מערכת אתגר פלוס - התקבלה הזמנה חדשה";
            string body = "<body dir=\"rtl\"><h3>זוהי הודעה אוטומטית ממערכת אתגר פלוס - להלן פרטי ההזמנה:</h3>";
            body += "<div>שם הלקוח: " + c.contactName + "<br />";
            body += "שם העסק: " + c.name + "<br />";
            body += "טלפון העסק: " + c.phone + "<br />";
            body += "כתובת: " + c.address + ", " + cityBl.getCityById(c.cityID) + ", " + c.zipCode + "<br />";
            body += "שם איש הקשר: " + c.contactName + "<br />";
            body += "טלפון איש הקשר: " + c.contactPhone + "<br />";
            body += "כתובת דואר אלקטרוני: " + c.email + "</div><br /><hr /><br /><div>";

            body += GetRenderResult(newListBikeTable);

            body += "</div></body>";

            Global.sendEmail(subject, body, emailTo);
        }
        public static string GetRenderResult(Control control)
        {
            using (StringWriter sw = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(sw))
                    control.RenderControl(writer);
                sw.WriteLine();
                return sw.ToString();
            }
        }
        private void resetListToOrder()
        {
            Main.listBikeToOrder = new List<Bicycles>();
            Main.listCountToOrder = new List<int>();
            // Response.Redirect(Request.RawUrl);
        }
        protected void sendEmail_Click(object sender, EventArgs e)
        {
            sendOrderEmail(Session["Email"].ToString());
            sendOrderEmail(System.Configuration.ConfigurationManager.AppSettings["Email"]);

            newListBikeDiv.Style.Add("display", "block");
            sendSucsses.Style.Add("display", "block");
            fade.Style.Add("display", "block");
            ///////////////
            resetListToOrder();
        }
    }
}