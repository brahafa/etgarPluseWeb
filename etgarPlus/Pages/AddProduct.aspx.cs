using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;
using etgarPlus.Classes;
using etgarPlus.Logic;
namespace etgarPlus.Pages
{
    public partial class AddProduct : System.Web.UI.Page
    {
        etgarPlus.Logic.BicycleBL NewBike = new BicycleBL();
        SubCategoryBL subCategoryBL = new SubCategoryBL();
        ProducerBL producerBL = new ProducerBL();
        CategoryBL categoryBl = new CategoryBL();
        SizeBL sizeBL = new SizeBL();
        ColorBL Color_Bl = new ColorBL();
        BicycleBL bicycleBL = new BicycleBL();
        List<Producer> lisProducer;

        List<Category> listCategory;

        List<SubCategory> listSubCategory ;

        List<etgarPlus.Classes.Size> lisSize ;

        List<etgarPlus.Classes.Color> lisColor;

       

        protected void Page_Load(object sender, EventArgs e)
        {  

            List<Producer> lisProducer = producerBL.getAllProducer();
            List<Category> listCategory = categoryBl.getAllCategory();
            List<SubCategory> listSubCategory = subCategoryBL.getAllSubCategory();
            List<etgarPlus.Classes.Size> lisSize = sizeBL.getAllSizes();
            List<etgarPlus.Classes.Color> lisColor = Color_Bl.getAllColor();

            buildSelected();

        }


        public void buildSelected()
        {

           lisProducer = producerBL.getAllProducer();
           listCategory = categoryBl.getAllCategory();
           listSubCategory = subCategoryBL.getAllSubCategory();
           lisSize = sizeBL.getAllSizes();
           lisColor = Color_Bl.getAllColor();


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
        }
        protected void resetButton_Click(object sender, EventArgs e)
        {
            if (selected_producer.Items.Count > 1)
            {
                for (int i = selected_producer.Items.Count - 1; i > 0; i--)
                    selected_producer.Items.Remove(selected_producer.Items[i]);
            }

            if (selected_Category.Items.Count > 1)
            {
                for (int i = selected_Category.Items.Count - 1; i > 0; i--)
                    selected_Category.Items.Remove(selected_Category.Items[i]);
            }

            if (selected_SubCategory.Items.Count > 1)
            {
                for (int i = selected_SubCategory.Items.Count - 1; i > 0; i--)
                    selected_SubCategory.Items.Remove(selected_SubCategory.Items[i]);
            }

            if (selected_Size.Items.Count > 1)
            {
                for (int i = selected_Size.Items.Count - 1; i > 0; i--)
                    selected_Size.Items.Remove(selected_Size.Items[i]);
            }
            if (selected_Color.Items.Count > 1)
            {
                for (int i = selected_Color.Items.Count - 1; i > 0; i--)
                    selected_Color.Items.Remove(selected_Color.Items[i]);
            }

            selected_Color.Value = "-1";
            selected_producer.Value = "-1";
            selected_Size.Value = "-1";
            selected_SubCategory.Value = "-1";
            selected_producer.Value = "-1";
            Model.Value = "";
            RetailPrice.Value = "";
            RegularPrice.Value = "";
            ClubPrice.Value = "";
            Quantity.Value = "";
            FileUpload1.Attributes.Clear();
            Specification.Text = "";

            buildSelected();
        }




        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (RetailPrice.Value.ToString().Equals(""))
            {
                RetailPrice.Value = "0";
            }
            if (ClubPrice.Value.ToString().Equals(""))
            {
                ClubPrice.Value = "0";
            }
            if (RegularPrice.Value.ToString().Equals(""))
            {
                RegularPrice.Value = "0";
            }
            if (Model.Value == null)
            {
                Model.Value = "";
            }
            if (Specification.Text == "")
            {
                Specification.Text = "אין פירוט";
            }
            int catego = Convert.ToInt32(selected_Category.Value);
            int sub_catego = Convert.ToInt32(selected_SubCategory.Value);
            int produc = Convert.ToInt32(selected_producer.Value);
            int color = Convert.ToInt32(selected_Color.Value); int siz = Convert.ToInt32(selected_Size.Value);
            string Specif = Specification.Text;

            //IsMatch
            Boolean isNumber = IsNumeric(Quantity.Value.ToString());
            if (!(isNumber))
            {
                Response.Write("<script language=javascript>alert('הכנס מס שלם לשדה כמות');</script>");

            }

            if (catego == -1 || sub_catego == -1 || Quantity.Value == null || produc == -1 || color == -1 || Specif.Equals(""))
            {
                Response.Write("<script language=javascript>alert('מלא את השדות המסומנים ב-*');</script>");

            }

            else
            {
                string strNewItem;
                if (color == -2)
                {                  
                    strNewItem = elseColor.Value.ToString();

                    if (strNewItem != null)
                    {
                        Color_Bl.AddNeColor(Color_Bl.getMaxIdColor(), strNewItem);
                        color = Color_Bl.getMaxIdColor()-1;
                    }
                    if (elseColor.Value.Length == 0)
                        Response.Write("<script language=javascript>alert('הוסף צבע חדש');</script>");

                }
                if (catego == -2)
                {
                    strNewItem = elseCategory.Value.ToString();
                    if (strNewItem != null)
                    {
                        categoryBl.AddNeCategory(categoryBl.getMaxIdcategory(), strNewItem);
                        catego = categoryBl.getMaxIdcategory() - 1;
                    }
                    if (elseCategory.Value.Length==0)
                    Response.Write("<script language=javascript>alert('הוסף קטגוריה חדשה');</script>");

                }
                if (sub_catego == -2)
                {
                    strNewItem = elseSubCategory.Value.ToString();
                    if (strNewItem != null)
                    {
                        subCategoryBL.AddNeSubCategory(subCategoryBL.getMaxIdSubcategory(), strNewItem);
                        sub_catego = subCategoryBL.getMaxIdSubcategory() - 1;
                    }
                    if (elseSubCategory.Value.Length == 0)
                        Response.Write("<script language=javascript>alert('הוסף תת קטגוריה חדשה');</script>");

                }
                if (siz == -2)
                {
                    strNewItem = elseSize.Value.ToString();
                    if (strNewItem != null)
                    {
                        sizeBL.AddNeSise(sizeBL.getMaxIdSize(), strNewItem);
                        siz = sizeBL.getMaxIdSize() - 1;
                    }
                    if (elseSize.Value.Length == 0)
                        Response.Write("<script language=javascript>alert(הוסף גודל חדשה');</script>");

                }
                if (produc == -2)
                {
                    strNewItem = elseProducer.Value.ToString();
                    if (strNewItem != null)
                    {
                        producerBL.AddNeproducer(producerBL.getMaxIdProducer(), strNewItem);
                        produc = producerBL.getMaxIdProducer()-1;
                    }
                    if (elseProducer.Value.Length == 0)
                        Response.Write("<script language=javascript>alert('הוסף שם יצרן חדש');</script>");

                }
                 string fileName="";
                 string path="";
                 string fileName2 = "";
                 if (FileUpload1.HasFile)
                 {
                     fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                     path = Server.MapPath("~/images/") + fileName;
                     FileUpload1.PostedFile.SaveAs(path);
                     Console.WriteLine(fileName);
                     fileName2 = Global.uploadImage(path, produc + "_" + DateTime.Now.ToString().Replace("/", "_"));
                 }
                //NewBike.AddNewBike(NewBike.getMaxId(), catego, sub_catego, produc, siz, Specification.Text, color, Convert.ToDouble(RetailPrice.Value), Convert.ToDouble(RegularPrice.Value), Convert.ToDouble(ClubPrice.Value), Convert.ToInt32(Quantity.Value), FileUpload1.FileName, Model.Value);
                NewBike.AddNewBike(NewBike.getMaxId(), catego, sub_catego, produc, siz, Specification.Text, color, Convert.ToDouble(RetailPrice.Value), Convert.ToDouble(RegularPrice.Value), Convert.ToDouble(ClubPrice.Value), Convert.ToInt32(Quantity.Value), fileName2, Model.Value);
                
                resetButton_Click(sender, e);
               // clearSelect();


            }
        }
        
    

        public static bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!(char.IsDigit(c)))
                {
                    return false;
                }
            }

            return true;
        }
        protected void ElseProducer(object sender, EventArgs e)
        {
            RetailPrice.Value = "הצליח";
        }
        protected void UplodeImg_Click(object sender, EventArgs e)
        {




            // lblimg_name.Text = FileUpload1.FileName.ToString();
            /*if (Session["image"] != null)
            {
                img1.ImageUrl = Session["image"].ToString();
            }*/
        }

        protected void Browse_Click(object sender, EventArgs e)
        {
            //// Create an instance of the open file dialog box.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            //openFileDialog1.Multiselect = false;

            //// Call the ShowDialog method to show the dialog box.
            //bool? userClickedOK = openFileDialog1.ShowDialog();

            //// Process input if the user clicked OK.
            //if (userClickedOK == true)
            //{
            //    // Open the selected file to read.
            //    System.IO.Stream fileStream = openFileDialog1.File.OpenRead();

            //    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
            //    {
            //        // Read the first line from the file and write it the textbox.
            //        tbResults.Text = reader.ReadLine();
            //    }
            //    fileStream.Close();
            //}
        }
    }
}