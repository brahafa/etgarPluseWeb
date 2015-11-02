using etgarPlus.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class CategoryDAL
    {

        // public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public CategoryDAL()
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

        public void deleteBikeByCategory(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM MainCategoryID WHERE Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Category> getAllSizes()
        {
            con.Open();
            string sqlString = "select * from MainCategoryID";
            MySqlCommand com = new MySqlCommand(sqlString, con); List<Classes.Category> listCategory = new List<Classes.Category>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listCategory.Add(new Classes.Category((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listCategory;
        }
		public int maxIdCategory()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from MainCategoryID;";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            int maxId = 0;
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    maxId = Convert.ToInt32(rdr["Id"]);
                }
            }

            con.Close();
            return maxId;
        }
        public String GetCategory(int ID)
        {
            con.Open();
            string sqlString = "select CategoryName from MainCategoryID p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            String category = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    category = rdr["CategoryName"].ToString();
                }
            }
            con.Close();
            return category;
        }
		public void AddNeColor(int NewId, string NewCategory)
        {
            string sqlString = "INSERT INTO MainCategoryID (Id, CategoryName) VALUES (@val1, @val2);";

            using (MySqlCommand comm = new MySqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewCategory);
                try
                {
                    con.Open();
                    comm.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException e)
                {
                    Debug.WriteLine("error: " + e.Errors);
                }

            }
        }
    }
}