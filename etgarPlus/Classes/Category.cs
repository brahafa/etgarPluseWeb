using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    public class Category
    {
            public int _id;
            public string _category;

            public Category(int id, string category)
            {
                // TODO: Complete member initialization
                this._id = id;
                this._category = category;
            }
        }
    }
