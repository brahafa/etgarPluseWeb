using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class CategoryBL
    {
        CategoryDAL categoryDAL;
        static CategoryDAL c;
         public CategoryBL()
        {
            categoryDAL = new CategoryDAL();
            c = new CategoryDAL();
        }

    public void deleteCategort(int id)
         {
             categoryDAL.deleteBikeByCategory(id);
         }
    public int getMaxIdcategory()
         {
             return categoryDAL.maxIdCategory()+1;

         }
         public void AddNeCategory(int NewId, string NewCategory)
         {
             categoryDAL.AddNeColor(NewId, NewCategory);
         }
          public List<Classes.Category> getAllCategory()
        {
            return (categoryDAL.getAllSizes());
        }
          public string getCategoryById(int categoryId)
          {
              return (categoryDAL.GetCategory(categoryId));
          }
    }
}