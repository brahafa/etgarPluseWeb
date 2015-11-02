using etgarPlus.Classes;
using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class ColorBL
    {
        ColorDAL colorDAL;
        public ColorBL()
        {
            colorDAL = new ColorDAL();
        }
	public void AddNeColor(int NewId, string NewColor)
        {
            colorDAL.AddNeColor(NewId, NewColor);
        }
    public void deleteColor(int id)
    {
        colorDAL.deleteBikeByColor(id);
    }
        public int getMaxIdColor()
        {
            return colorDAL.maxIdColor() + 1;

        }
        public List<Color> getAllColor()
        {
            return (colorDAL.getAllColor());
        }
        public string getColorById(int colorId)
        {
            return (colorDAL.GetColor(colorId));
        }
		public int getId(string color)
        {
            return (colorDAL.GetId(color));
        }
    }
}