using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using etgarPlus.Logic;
using etgarPlus.Classes;
using System.Diagnostics;


namespace etgarPlus.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        // List<etgarPlus.Classes.Bicycles> listBike;
        public BicycleBL bicycleBL;
        public CategoryBL categoryBL;
        public SubCategoryBL subCategoryBL;
        public ProducerBL producerBL;
        public SizeBL sizeBL;
        public ColorBL colorBL;
        public List<etgarPlus.Classes.Bicycles> listBike;// = bicycleBL.getBicycle();

        public static List<Bicycles> listBikeToOrder = new List<Bicycles>();
        public static List<int> listCountToOrder = new List<int>();
        public int tempId;


        public void Page_Load(object sender, EventArgs e)
        {

            bicycleBL = new BicycleBL();
            categoryBL = new CategoryBL();
            subCategoryBL = new SubCategoryBL();
            producerBL = new ProducerBL();
            sizeBL = new SizeBL();
            colorBL = new ColorBL();
            
            if (Session["listBike"] != null)
            {

                listBike = (List<Bicycles>)Session["listBike"];
                // ColorSelector.SelectedValue = Session["listBike"].ToString();
            }
            else
            {
                listBike = bicycleBL.getAllBike();
            }

            List<Producer> listProducer = producerBL.getAllProducer();
            List<Category> listCategory = categoryBL.getAllCategory();
            List<SubCategory> listSubCategory = subCategoryBL.getAllSubCategory();
            List<Size> listSize = sizeBL.getAllSizes();
            List<Color> listColor = colorBL.getAllColor();

            selected_producer.Items.Clear();
            selected_producer.Items.Add(new ListItem("שם היצרן", "-1"));
            foreach (Producer p in listProducer)
            {
                selected_producer.Items.Add(new ListItem(p._producer, p._id.ToString()));
            }
            selected_Category_Main.Items.Clear();
            selected_Category_Main.Items.Add(new ListItem("בחר קטגוריה", "-1"));
            foreach (Category c in listCategory)
            {
                selected_Category_Main.Items.Add(new ListItem(c._category, c._id.ToString()));
            }
            selected_SubCategory_main.Items.Clear();
            selected_SubCategory_main.Items.Add(new ListItem("בחר תת קטגוריה", "-1"));
            foreach (SubCategory s in listSubCategory)
            {
                selected_SubCategory_main.Items.Add(new ListItem(s._subCategory, s._id.ToString()));
            }
            selected_Size.Items.Clear();
            selected_Size.Items.Add(new ListItem("בחר גודל", "-1"));
            foreach (Size si in listSize)
            {
                selected_Size.Items.Add(new ListItem(si._size, si._id.ToString()));
            }
            selected_Color.Items.Clear();
            selected_Color.Items.Add(new ListItem("בחר צבע", "-1"));
            foreach (Color c in listColor)
            {
                selected_Color.Items.Add(new ListItem(c._color, c._id.ToString()));
            }

        }
        //protected void bikeProperties(int bikeId)
        //{
        //    bicycleBL = new etgarPlus.Logic.BicycleBL();
        //    listBike = bicycleBL.getBicycle();
        //    Name.Text = etgarPlus.Logic.ProducerBL.GetProducer(listBike[bikeId]._Name);
        //}
        //bool containsItem = myList.Any(item => item.UniqueProperty == wonderIfItsPresent.UniqueProperty);
        protected void bikeButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(bikeId.Value);
            int i = 0;
            //  listBike = bicycleBL.getBicycle();
            for (; i < listBike.Count; i++)
            {
                if (listBike[i]._Id == Id)
                    break;
            }
            
            Name.Text = producerBL.GetProducer(listBike[i]._Name);
            Image1.ImageUrl = listBike[i]._ImagePath;
            Model.Text = listBike[i]._Model;
            MainCategory.Text = categoryBL.getCategoryById(listBike[i]._MainCategoryId);
            SubCategory.Text = subCategoryBL.GetSubCategory(listBike[i]._SubCategoryId);
            Size.Text = sizeBL.getSize(listBike[i]._size);
            Color.Text = colorBL.getColorById(listBike[i]._colorId);
            Quantity.Text = listBike[i]._Quantity.ToString();
            if (Convert.ToInt32(Session["Level"]) == 1)
            {
                Price.Text = (listBike[i]._RegularPrice * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["sitonai"])).ToString();
            }
            else if (Convert.ToInt32(Session["Level"]) == 2)
            {
                Price.Text = (listBike[i]._RegularPrice * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["kimonai"])).ToString();
            }
            else if (Convert.ToInt32(Session["Level"]) == 4)
            {
                Price.Text = listBike[i]._ClubPrice.ToString();
            }
            else
            {
                Price.Text = listBike[i]._RegularPrice.ToString();
            }
            selectQuantity.Items.Clear();
            selectQuantity.Items.Add(new ListItem("בחר כמות", "-1"));
            for (int j = 1; j <= listBike[i]._Quantity; j++ )
            {

                selectQuantity.Items.Add(new ListItem(j.ToString(), j.ToString()));
            }
            properties.Style.Add("display", "block");
            fade.Style.Add("display", "block");
            addTOBasket.Style.Add("display", "none");
            fade2.Style.Add("display", "none");

        }
        
        protected void search_Click(object sender, EventArgs e)
        {
            listBike = new List<Bicycles>();
            listBike = bicycleBL.getAllBike();

            if (!(selected_Category_Main.Value.Equals("-1")))
            {
                for (int i = 0; i < listBike.Count; i++)
                {
                    if ((listBike[i]._MainCategoryId != Convert.ToInt32(selected_Category_Main.Value)))
                    {
                        listBike.Remove(listBike[i]);
                        i--;
                    }
                }

            }
            if (!(selected_SubCategory_main.Value.Equals("-1")))
            {
                for (int i = 0; i < listBike.Count; i++)
                {
                    if (!(listBike[i]._SubCategoryId == Convert.ToInt32(selected_SubCategory_main.Value)))
                    {
                        listBike.Remove(listBike[i]);
                        i--;
                    }
                }

            }
            if (!(selected_Size.Value.Equals("-1")))
            {
                for (int i = 0; i < listBike.Count; i++)
                {
                    if (!(listBike[i]._size == Convert.ToInt32(selected_Size.Value)))
                    {
                        listBike.Remove(listBike[i]);
                        i--;
                    }
                }
            }
            if (!(selected_producer.Value.Equals("-1")))
            {
                for (int i = 0; i < listBike.Count; i++)
                {
                    if (listBike[i]._Name != Convert.ToInt32(selected_producer.Value))
                    {
                        listBike.Remove(listBike[i]);
                        i--;
                    }
                }
            }
            if (!(selected_Color.Value.Equals("-1")))
            {
                for (int i = 0; i < listBike.Count; i++)
                {
                    if (listBike[i]._colorId != Convert.ToInt32(selected_Color.Value))
                    {
                        listBike.Remove(listBike[i]);
                        i--;
                    }
                }
            }
            try
            {
                if (Convert.ToInt32(ToPriceInput.Value) != 0)
                {
                    for (int i = 0; i < listBike.Count; i++)
                    {
                        if (Convert.ToInt32(FromPriceInput.Value) > listBike[i]._RegularPrice || Convert.ToInt32(ToPriceInput.Value) < listBike[i]._RegularPrice)
                        {
                            listBike.Remove(listBike[i]);
                            i--;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            //for (int i = 0; i < listBike.Count; i++)
            //{
            //    tessst.Items.Add(listBike[i]._Id.ToString());
            //}

            //  ViewState["arrayListInViewState"] = listBike;
            //Page_Load( sender,  e);
            Session["listBike"] = listBike;
            Response.Redirect(Request.RawUrl);

        }
        protected void addToList_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(bikeId.Value);
            int quantity=0;
            try
            {
               quantity = Convert.ToInt32(selectQuantity.Value);
            }
            catch (Exception ex) { return; }
            Bicycles bike = new etgarPlus.Classes.Bicycles();
            bicycleBL = new etgarPlus.Logic.BicycleBL();
            bike = bicycleBL.getBicycleById(Id);
            listBikeToOrder.Add(bike);
            listCountToOrder.Add(quantity);
            addTOBasket.Style.Add("display", "block");
            fade2.Style.Add("display", "block");
        }
    }
}