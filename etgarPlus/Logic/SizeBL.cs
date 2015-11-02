using etgarPlus.Classes;
using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class SizeBL
    {
        SizeDAL sizeDAL;
        public SizeBL()
        {
            sizeDAL = new SizeDAL();
        }

        public void AddNeSise(int NewId, string NewSize)
        {
            sizeDAL.AddNeSize(NewId, NewSize);
        }
        public void deleteSize(int id)
        {
            sizeDAL.deleteBikeBySize(id);
        }
        public List<Size> getAllSizes()
        {
            return (sizeDAL.getAllSizes());
        }
        public string getSize(int id)
        {
            return (sizeDAL.GetSize(id));
        }
        public int getMaxIdSize()
        {
            return sizeDAL.maxIdSize() + 1;
        }
    }
}