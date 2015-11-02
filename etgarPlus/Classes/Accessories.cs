using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{

    public class Accessories
    {
        private int _Id;
        private int _MainCategoryID;
        private int _SubCategoryID;
        private String _Name;
        private float _RetailPrice;
        private float _RegularPrice;
        private float _ClubPrice;

        public Accessories(int Id, int MainCategoryID, int SubCategoryID, String Name, float RetailPrice,
            float RegularPrice, float ClubPrice)
        {
            _Id = Id;
            _MainCategoryID = MainCategoryID;
            _SubCategoryID = SubCategoryID;
            _Name = Name;
            _RetailPrice = RetailPrice;
            _RegularPrice = RegularPrice;
            _ClubPrice = ClubPrice;
        }
    }
}