using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using etgarPlus.DAL;
namespace etgarPlus.Logic
{
    public class PriceBL
    {
        PriceDAL priceDal;
        public PriceBL()
        {
            priceDal = new PriceDAL();
        }
        public string getPrice(int colorId)
        {
            return (priceDal.GetPrice(colorId));
        }
    }
}