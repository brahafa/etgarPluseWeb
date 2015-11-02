using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{
    public class Order
    {
        private int _Id;
        private int _ClientID;
        private int _ProductID;
        private int _Quantity;

        public Order(int Id, int ClientID, int ProductID, int Quantity)
        {
            _Id = Id;
            _ClientID = ClientID;
            _ProductID = ProductID;
            _Quantity = Quantity;
        }
    }
}