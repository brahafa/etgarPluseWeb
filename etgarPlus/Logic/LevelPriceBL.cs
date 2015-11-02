using etgarPlus.Classes;
using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{

    public class LevelPriceBL
    {
        LevelPriceDAL levelPriceDAL;
        public LevelPriceBL()
        {
            levelPriceDAL = new LevelPriceDAL();
        }
        public List<LevelPrice> GetAllLevels()
        {
           return levelPriceDAL.getAllLevels();
        }
    }
}