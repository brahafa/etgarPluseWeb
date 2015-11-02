using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class AccessoriesBL
    {
        public static AccessoriesDAL accessoriesDAL;
        List<Classes.Accessories> accessoriesList;
        public AccessoriesBL()
        {
            accessoriesDAL = new AccessoriesDAL();
        }
        public void AddNewAccessory(int Id, String MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            accessoriesDAL.AddNewAccessory(Id, MainCategoryID, SubCategoryID, Name, RetailPrice, RegularPrice, ClubPrice);
        }
         public void UpdateAccessory(int Id, String MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            accessoriesDAL.UpdateAccessory(Id, MainCategoryID, SubCategoryID, Name, RetailPrice, RegularPrice, ClubPrice);
        }
         public void DeleteAccessory(int Id, String Name)
         {
             accessoriesDAL.DeleteAccessory(Id, Name);
         }
         public List<Classes.Accessories> GetAllAccessories()
        {
            return(accessoriesDAL.GetAllAccessories());
        }
         public List<Classes.Accessories> SortByCategory()
        {
            return (accessoriesDAL.SortByCategory());
        }
         public List<Classes.Accessories> SortBySubCategory()
        {
            return (accessoriesDAL.SortBySubCategory());
        }
         public List<Classes.Accessories> GetAccessoryByCategory(int Category)
        {
            return (accessoriesDAL.GetAccessoryByCategory(Category));
        }
         public List<Classes.Accessories> GetAccessoryBySubCategory(int SubCategory)
        {
            return (accessoriesDAL.GetAccessoryBySubCategory(SubCategory));
        }
         public List<Classes.Accessories> GetAccessoryByName(String Name)
        {
            return (accessoriesDAL.GetAccessoryByName(Name));
        }
         public List<Classes.Accessories> Between2Prices(int LevelPrice, int minPrice, int maxPrice)
        {
            return (accessoriesDAL.Between2Prices(LevelPrice, minPrice, maxPrice));
        }


    }
}