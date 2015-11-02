using etgarPlus.Classes;
using etgarPlus.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace etgarPlus.DAL
{
    public class SubCategoryDAL
    {

          //public static string s;
          //public SqlConnection con;

          private MySqlConnection con = null;
          private MySqlConnectionStringBuilder sb = null;
          private MySqlCommand cmd = null;

        public SubCategoryDAL()
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

        public void deleteBikeBySubCategory(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM SubCategoryName WHERE Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        internal List<Classes.SubCategory> getAllSubCategory()
        {
            con.Open();
            string sqlString = "select * from SubCategoryName";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Classes.SubCategory> listSubCategory = new List<Classes.SubCategory>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listSubCategory.Add(new Classes.SubCategory((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listSubCategory;
        }
        public String GetSubCategory(int ID)
        {
            con.Open();
            string sqlString = "select SubCategoryName from SubCategoryName p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            String SubCategory = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    SubCategory = rdr["SubCategoryName"].ToString();
                }
            }
            con.Close();
            return SubCategory;

        }
		public void AddNeSubCategory(int NewId, string NewSubCategory)
        {
            string sqlString = "INSERT INTO SubCategoryName (Id, SubCategoryName) VALUES (@val1, @val2);";

            using (MySqlCommand comm = new MySqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewSubCategory);
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

        public int maxIdSubCategory()
        {

            con.Open();
            string sqlString = "select Max(Id) as Id from SubCategoryName;";
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
    }
}