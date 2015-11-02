using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    public class Producer
    {
         public int _id;
        public string _producer;

        public Producer(int id, string producer)
        {
            // TODO: Complete member initialization
            this._id = id;
            this._producer = producer;
        }
    }
}