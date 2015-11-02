using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using etgarPlus.Classes;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace etgarPlus
{
    public class AccessoriesDAL
    {
        // public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public AccessoriesDAL()
        {
            //s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            //con = new SqlConnection(s); 
           
            sb = new MySqlConnectionStringBuilder();
            sb.Server = "cea766ee-d14f-4cde-9659-a53500832f5d.mysql.sequelizer.com";
            sb.UserID = "qgdrzcnrgssnqeml";
            sb.Password = "vTYDtKuwUGF6a6QZQ4rPcKGqRgGTXZgzzmZHGudb3T5vHHQrcZWSZVyTmHUndJF3";
            sb.Database = "dbcea766eed14f4cde9659a53500832f5d";
            try
            {
                con = new MySqlConnection(sb.ToString());
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            
        }

        public List<Accessories> GetAllAccessories()
        {
            con.Open();
            string sqlString = "select * from Accessories";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public void AddNewAccessory(int Id, string MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            con.Open();

            con.Close();
        }

        public void UpdateAccessory(int Id, string MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            con.Open();

            con.Close();
        }

        public void DeleteAccessory(int Id, string Name)
        {
            con.Open();
            string sqlString = @"DELETE FROM Accessories a where a.Id = " + Id + "AND a.Name = " + Name + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Accessories> SortByCategory(int Category)
        {
            con.Open();
            string sqlString = "select * from Accessories a group by a.MainCategoryID";///////////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> SortBySubCategory(int sub)
        {
            con.Open();
            string sqlString = "select * from Accessories";///////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> Between2Prices(int LevelPrice, int minPrice, int maxPrice)
        {
            con.Open();
            string sqlString = "select * from Accessories";/////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryByCategory(int CategoryID)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.CategoryID = " + CategoryID + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryBySubCategory(int SubCategoryID)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.SubCategoryID = " + SubCategoryID + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryByName(string Name)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.Name = " + Name + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        internal List<Accessories> SortBySubCategory()
        {
            throw new NotImplementedException();
        }

        internal List<Accessories> SortByCategory()
        {
            throw new NotImplementedException();
        }
    }
}