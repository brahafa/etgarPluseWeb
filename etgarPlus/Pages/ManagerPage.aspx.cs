using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Classes;
using etgarPlus.Logic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Web.Services;
using System.Text.RegularExpressions;
namespace etgarPlus.Pages
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        static etgarPlus.Logic.BicycleBL NewBike = new Logic.BicycleBL();
        static etgarPlus.Logic.SubCategoryBL subCategoryBl = new Logic.SubCategoryBL();
        static etgarPlus.Logic.ProducerBL ProducerBL = new Logic.ProducerBL();
        static etgarPlus.Logic.CategoryBL categorBl = new Logic.CategoryBL();
        static etgarPlus.Logic.SizeBL sizeBl = new Logic.SizeBL();
        static etgarPlus.Logic.ColorBL Color_Bl = new etgarPlus.Logic.ColorBL();
        static etgarPlus.Logic.BicycleBL bikeBl = new etgarPlus.Logic.BicycleBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] == null)
            {
                Response.Redirect("../Pages/Main");
            }
           
            List<etgarPlus.Classes.Bicycles> bikeListCheck;
            etgarPlus.Logic.ProducerBL producerBL = new etgarPlus.Logic.ProducerBL();
            List<etgarPlus.Classes.Producer> lisProducer = producerBL.getAllProducer();

            etgarPlus.Logic.CategoryBL categoryBL = new etgarPlus.Logic.CategoryBL();
            List<etgarPlus.Classes.Category> listCategory = categoryBL.getAllCategory();

            etgarPlus.Logic.SubCategoryBL subCategoryBL = new etgarPlus.Logic.SubCategoryBL();
            List<etgarPlus.Classes.SubCategory> listSubCategory = subCategoryBL.getAllSubCategory();

            etgarPlus.Logic.SizeBL sizeBL = new etgarPlus.Logic.SizeBL();
            List<etgarPlus.Classes.Size> lisSize = sizeBL.getAllSizes();

            etgarPlus.Logic.ColorBL bicycleBL = new etgarPlus.Logic.ColorBL();
            List<etgarPlus.Classes.Color> lisColor = bicycleBL.getAllColor();


            foreach (etgarPlus.Classes.Producer p in lisProducer)
            {
                selected_producer.Items.Add(new ListItem(p._producer, p._id.ToString()));
            }
            selected_producer.Items.Add(new ListItem("אחר", "-2"));
            foreach (etgarPlus.Classes.Category c in listCategory)
            {
                selected_Category.Items.Add(new ListItem(c._category, c._id.ToString()));
            }
            selected_Category.Items.Add(new ListItem("אחר", "-2"));
            foreach (etgarPlus.Classes.SubCategory s in listSubCategory)
            {
                selected_SubCategory.Items.Add(new ListItem(s._subCategory, s._id.ToString()));
            }
            selected_SubCategory.Items.Add(new ListItem("אחר", "-2"));

            foreach (etgarPlus.Classes.Size si in lisSize)

            {
                selected_Size.Items.Add(new ListItem(si._size, si._id.ToString()));

            }
            selected_Size.Items.Add(new ListItem("אחר", "-2"));

            foreach (etgarPlus.Classes.Color c in lisColor)
            {
                selected_Color.Items.Add(new ListItem(c._color, c._id.ToString()));



            }
            selected_Color.Items.Add(new ListItem("אחר", "-2"));

            createTable(1);
            createTable(2);
            createProdTable();
        }

        protected void createProdTable(){
            
                //newClientDiv.Style.Add("display", "none");
                //allClientDiv.Style.Add("display", "none");
                Table table1 = new Table();
                table1 = allProductTable;
                List<Bicycles> BicyclesList = new List<Bicycles>();
                BicycleBL bike = new BicycleBL();
                CategoryBL category = new CategoryBL();
                SubCategoryBL subCategory = new SubCategoryBL();
                ProducerBL producer = new ProducerBL();
                ColorBL color = new ColorBL();
                SizeBL size = new SizeBL();
                BicyclesList = bike.getAllBike();
                for (int i = 0; i < BicyclesList.Count; i++)
                {
                    TableRow dr = new TableRow();
                    TableCell cell = new TableCell();
                    //שם יצרן
                    cell.Text = producer.GetProducer(BicyclesList[i]._Name).ToString();
                    dr.Cells.Add(cell);
                    //cell = new TableCell();
                    //cell.Text = "דגם";
                    //dr.Cells.Add(cell);
                    //קטגוריה ראשית
                    cell = new TableCell();
                    cell.Text = category.getCategoryById(BicyclesList[i]._MainCategoryId).ToString();
                    dr.Cells.Add(cell);
                    //קטגוריה משנית
                    cell = new TableCell();
                    cell.Text = subCategory.GetSubCategory(BicyclesList[i]._SubCategoryId).ToString();
                    dr.Cells.Add(cell);
                    //מידה
                    cell = new TableCell();
                    cell.Text = size.getSize(BicyclesList[i]._size).ToString();
                    dr.Cells.Add(cell);
                    //צבע
                    cell = new TableCell();
                    cell.Text = color.getColorById(BicyclesList[i]._colorId).ToString();
                    dr.Cells.Add(cell);
                    //כמות
                    cell = new TableCell();
                    cell.Text = BicyclesList[i]._Quantity.ToString();
                    dr.Cells.Add(cell);
                    //מחיר
                    cell = new TableCell();
                    cell.Text = BicyclesList[i]._RegularPrice.ToString();
                    dr.Cells.Add(cell);
                    
                    table1.Rows.Add(dr);
                
            }
        }

        protected void createTable(int tabletype)
        {
            ClientBL clientBL = new ClientBL();
            Table table = new Table();
            List<Client> clientList = new List<Client>();
            if (tabletype == 1)
            {
                clientList = clientBL.getNewClient();
                table = newClientTable;
            }
            else if (tabletype == 2)
            {
                clientList = clientBL.GetAllClient();
                table = allClientTable;
            }


            LevelPriceBL levePriceBL = new LevelPriceBL();
            List<LevelPrice> levelList = levePriceBL.GetAllLevels();
            CityBL cityBl = new CityBL();


            for (int i = 0; i < clientList.Count; i++)
            {
                TableRow dr = new TableRow();
                TableCell cell = new TableCell();
                //cell.Text = clientList[i].id.ToString();
                //dr.Cells.Add(cell);
                //cell = new TableCell();
                cell.Text = clientList[i].name;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].phone;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].address;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = cityBl.getCityById(clientList[i].cityID);
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].zipCode.ToString();
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].contactName;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].contactPhone;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].openTime;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].email;
                dr.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = clientList[i].password;
                dr.Cells.Add(cell);
                cell = new TableCell();
                ///dropeDounList for level price///
                DropDownList level = new DropDownList();
                level.ID = "LevelStatus_" + tabletype.ToString()+"_" + i.ToString();
                level.Items.Add(new ListItem("בחר דרגה", "-1"));
                foreach (etgarPlus.Classes.LevelPrice c in levelList)
                {
                    level.Items.Add(new ListItem(c._level, c._id.ToString()));
                }
                if (clientList[i].levelPrice > 0)
                    level.SelectedIndex = clientList[i].levelPrice;
                cell.Controls.Add(level);
                dr.Cells.Add(cell);
                /////////////////////end DropDounList////

                HtmlAnchor statusButton = new HtmlAnchor();
                statusButton.ID = "statusID_" + tabletype.ToString() + "_" + i.ToString();
                statusButton.Attributes.Add("class", "StatusButton");
                statusButton.HRef = "javascript:void(0);";

                cell = new TableCell();
                if (clientList[i].status.ToString().Equals("2"))
                {
                    statusButton.InnerText = "עדכן";
                }
                else if (clientList[i].status.ToString().Equals("1"))
                {
                    statusButton.InnerText = "אישור";
                }

                cell.Controls.Add(statusButton);
                dr.Cells.Add(cell);

                table.Rows.Add(dr);

            }
            //if (tabletype == 1)
            //{
            //    newClientTable = table;
            //}
            //else if (tabletype == 2)
            //{
            //    allClientTable = table;
            //}
        }


        [WebMethod]
        public static string updateLevelAndStatus(string idLevel)
        {
            int id = Convert.ToInt32(idLevel.Split(',')[0]);
            int level = Convert.ToInt32(idLevel.Split(',')[1]);

            ClientBL clientBL = new ClientBL();
            if (clientBL.updateLevel(id, level))
            {
                return "true";
            }
            return "false";
        }
		//UpdateProd_click
        //int produc = Convert.ToInt32(selected_producer.Value);
        [WebMethod]
        public static string updateProd(string param)
        {

            Debug.WriteLine(param);
            if (param != null)
            {
                ProducerBL.AddNeproducer(ProducerBL.getMaxIdProducer(), param);
            }

            return param;
        }

        [WebMethod]
        public static void deleteProd(string param)
        {
            bikeListCheck = bikeBl.getAllBike();
            for (int i = 0; i < bikeListCheck.Count; i++)
            {
                if (bikeListCheck[i]._Name.ToString().Equals(param))
                {
                    // Response.Write("<script language=javascript>alert('השדה שאתה רוצה למחוק בשימוש');</script>");
                    return;
                }
            }
            ProducerBL.deleteProducer(Convert.ToInt32(param));
        }

        [WebMethod]
        public static string updateCategory(string param)
        {

            Debug.WriteLine(param);
            if (param != null)
            {
                categorBl.AddNeCategory(categorBl.getMaxIdcategory(), param);
            }

            return param;
        }

        [WebMethod]
        public static void deleteCategort(string param)
        {
            bikeListCheck = bikeBl.getAllBike();
            for (int i = 0; i < bikeListCheck.Count; i++)
            {
                if (bikeListCheck[i]._MainCategoryId.ToString().Equals(param))
                {
                    // Response.Write("<script language=javascript>alert('השדה שאתה רוצה למחוק בשימוש');</script>");
                    return;
                }
            }
            categorBl.deleteCategort(Convert.ToInt32(param));
        }

        [WebMethod]
        public static string updateSubCategory(string param)
        {

            if (param != null)
            {
                subCategoryBl.AddNeSubCategory(subCategoryBl.getMaxIdSubcategory(), param);
            }

            return param;
        }

        [WebMethod]
        public static void deleteSubCategort(string param)
        {
            bikeListCheck = bikeBl.getAllBike();
            for (int i = 0; i < bikeListCheck.Count; i++)
            {
                if (bikeListCheck[i]._SubCategoryId.ToString().Equals(param))
                {
                   // Response.Write("<script language=javascript>alert('השדה שאתה רוצה למחוק בשימוש');</script>");
                    return;
                }
            }
                subCategoryBl.deleteSubCategort(Convert.ToInt32(param));
        }

        [WebMethod]
        public static string updateSize(string param)
        {

            if (param != null)
            {
                sizeBl.AddNeSise(sizeBl.getMaxIdSize(), param);
            }

            return param;
        }
        [WebMethod]
        public static void deleteSize(string param)
        {
            bikeListCheck = bikeBl.getAllBike();
            for (int i = 0; i < bikeListCheck.Count; i++)
            {
                if (bikeListCheck[i]._size.ToString().Equals(param))
                {
                    // Response.Write("<script language=javascript>alert('השדה שאתה רוצה למחוק בשימוש');</script>");
                    return;
                }
            }
            sizeBl.deleteSize(Convert.ToInt32(param));
        }

        [WebMethod]

        public static string updateColor(string param)
        {

            if (param != null)
            {
                Color_Bl.AddNeColor(Color_Bl.getMaxIdColor(), param);
            }

            return param;
        }
        [WebMethod]
        public static void deleteColor(string param)
        {
            bikeListCheck = bikeBl.getAllBike();
            for (int i = 0; i < bikeListCheck.Count; i++)
            {
                if (bikeListCheck[i]._colorId.ToString().Equals(param))
                {
                    // Response.Write("<script language=javascript>alert('השדה שאתה רוצה למחוק בשימוש');</script>");
                    return;
                }
            }
            Color_Bl.deleteColor(Convert.ToInt32(param));
        }

        public static List<Bicycles> bikeListCheck { get; set; }

    }
}