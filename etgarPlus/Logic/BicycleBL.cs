using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using etgarPlus.Classes;
namespace etgarPlus.Logic
{
     
    public class BicycleBL
    {
        public static BicycleDAL BicycDAL;
        public static List<Classes.Bicycles> BicyclesList;
       
        public BicycleBL()
        {
            BicycDAL = new BicycleDAL();
        }
        public void AddNewBike(int Id, int MainCategoryId, int SubCategoryId, int Name, int size,
            string Specification, int colorId, Double RetailPrice, Double RegularPrice, Double ClubPrice, int Quantity, String imagePath, String Model)
        {
            BicycDAL.AddNewBike( Id,  MainCategoryId,  SubCategoryId,  Name,  size,
            Specification,  colorId,  RetailPrice,  RegularPrice,  ClubPrice,  Quantity, imagePath, Model);
        }
		//maxIdBike
        public int getMaxId()
        {
            return BicycDAL.maxIdBike() + 1;

        }
        public void updateBicycById(int Id, int MainCategoryId, int SubCategoryId, string Name, int size,
           string Specification, int colorId, float RetailPrice, float RegularPrice, float ClubPrice, int Quantity)
        {
            BicycDAL.updateBikeById(Id, MainCategoryId, SubCategoryId, Name, size,
            Specification, colorId, RetailPrice, RegularPrice, ClubPrice, Quantity);
        }

        public void deleteBicycById(int id)
        {
            BicycDAL.deleteBikeById(id);
        }
        //public List<Bicycles> getBicycle()
        //{
        //    return(BicycDAL.getAllBike());//getAllBic is function name from yaely class
        //}
        public List<Bicycles> SortByName()
        {
            return (BicycDAL.sortBikeByName());
        }
        public List<Bicycles> SortByMainCategory()
        {
            return (BicycDAL.sortBikeByMainCategory());
        }
        public List<Bicycles> SortBySubCategory()
        {
            return (BicycDAL.sortBikeBySubCategory());
        }
        public List<Bicycles> SortBySize()
        {
            return (BicycDAL.sortBikeBySize());
        }
        public List<Bicycles> BetweenBicycSizes(int min, int max)
        {
            return (BicycDAL.getBetweenSizes(min, max));
        }
        public List<Bicycles> BicycByColor(String color)
        {
            return (BicycDAL.getBikeByColor(color));
        }
        public List<Bicycles> Between2Prices(int LevelPrice, int minPrice, int maxPrice)
        {
            return (BicycDAL.getBetweenLevelPrice(LevelPrice,minPrice,maxPrice));
        }
        public List<Bicycles> GetBikeByCategory(String category )
        {
            return BicycDAL.getBikeByMainCategory(category);
        }
        public List<Bicycles> GetBikeByProducer(String producer)
        {
            return BicycDAL.getBikeByName(producer);
        }


        public List<Bicycles> getAllBike()
        {
            return BicycDAL.getAllBike();
        }

        public Bicycles getBicycleById(int Id)
        {
            return (BicycDAL.getBikeById(Id));//getAllBic is function name from yaely class
        }
    }
}