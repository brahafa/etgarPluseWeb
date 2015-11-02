using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    [Serializable]
    public class Bicycles
    {
        public int _Id;
        public int _MainCategoryId;///change the name in DB from _MainCategory to _MainCategoryId
        public int _SubCategoryId;///change the name in DB from _SubCategory to _SubCategoryId
        public int _Name;
        public String _Model;
        public int _size;
        public String _Specification;
        public int _colorId;//change the name in DB from _color to _colorId
        public Double _RetailPrice;
        public Double _RegularPrice;
        public Double _ClubPrice;
        public int _Quantity;
        public String _ImagePath;

        public Bicycles() 
        {
            _Id = -1;
            _MainCategoryId = -1;
            _SubCategoryId = -1;
            _Name = -1;
            _Model = "";
            _size = -1;
            _Specification = "";
            _colorId = -1;
            _RetailPrice = -1;
            _RegularPrice = -1;
            _ClubPrice = -1;
            _Quantity = 0;
            _ImagePath = "../Images/DefaultBicycle.jpg";
        }
        public Bicycles(int Id, int MainCategoryId, int SubCategoryId, int Name, String Model, int size,
            String Specification, int colorId, Double RetailPrice, Double RegularPrice, Double ClubPrice, int Quantity, String imagePath)
        {
            _Id = Id;
            _MainCategoryId = MainCategoryId;
            _SubCategoryId = SubCategoryId;
            _Name = Name;
            _Model = Model;
            _size = size;
            _Specification = Specification;
            _colorId = colorId;
            _RetailPrice = RetailPrice;
            _RegularPrice = RegularPrice;
            _ClubPrice = ClubPrice;
            _Quantity = Quantity;
            if (imagePath.Equals(""))
                _ImagePath = "../Images/DefaultBicycle.jpg";
            else
                _ImagePath = "../Images/"+imagePath;
        }
        public override String ToString()
        {
            return "ID: " + _Id + " Name: " + _Name;
        }
    }
}