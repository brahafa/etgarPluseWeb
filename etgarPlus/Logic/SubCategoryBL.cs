using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class SubCategoryBL
    {
          
        SubCategoryDAL subCategoryDAL;
        public SubCategoryBL()
        {
            subCategoryDAL = new SubCategoryDAL();
        }
        public int getMaxIdSubcategory()
        {
            return subCategoryDAL.maxIdSubCategory() + 1;

        }
        public void deleteSubCategort(int id)
        {
            subCategoryDAL.deleteBikeBySubCategory(id);
        }
        public void AddNeSubCategory(int NewId, string NewSubCategory)
        {
            subCategoryDAL.AddNeSubCategory(NewId, NewSubCategory);
        }
          public List<Classes.SubCategory> getAllSubCategory()
        {
            return (subCategoryDAL.getAllSubCategory());
        }
          public string GetSubCategory(int ID)
          {
              return (subCategoryDAL.GetSubCategory(ID));
          }

    }
}