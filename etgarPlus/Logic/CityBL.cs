using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using etgarPlus.DAL;
using etgarPlus.Classes;
namespace etgarPlus.Logic
{
    public class CityBL
    {
        CityDAL cityDal;
        public CityBL()
        {
            cityDal = new CityDAL();
        }
        public string getCityById(int cityID)
        {
            return (cityDal.GetCity(cityID));
        }
        public List<City> getAllCity()
        {
           return cityDal.getAllCity();
        }
       
    }
}