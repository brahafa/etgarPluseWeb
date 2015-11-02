using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    public class LevelPrice
    {
         public int _id;
        public string _level;

        public LevelPrice(int id, string size)
        {
            // TODO: Complete member initialization
            this._id = id;
            this._level = size;
        }
    }
}