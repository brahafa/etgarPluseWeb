using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    public class SubCategory
    {
         public int _id;
            public string _subCategory;

            public SubCategory(int id, string subCategory)
            {
                // TODO: Complete member initialization
                this._id = id;
                this._subCategory = subCategory;
            }
    }
}