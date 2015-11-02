using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace etgarPlus.DAL
{
    public class ColorDAL
    {
        // public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public ColorDAL()
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

        public void deleteBikeByColor(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM ColorsID WHERE Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
		public int maxIdColor()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from ColorsID;";
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
        public void AddNeColor(int NewId, string NewColor){
             string sqlString = "INSERT INTO ColorsID (Id, Color) VALUES (@val1, @val2);";

             using (MySqlCommand comm = new MySqlCommand())
             {
                 comm.Connection = con;
                 comm.CommandText = sqlString;
                 comm.Parameters.AddWithValue("@val1", NewId);
                 comm.Parameters.AddWithValue("@val2", NewColor);
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
        public List<Color> getAllColor()
        {
            con.Open();
            string sqlString = "select * from ColorsID";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Color> listColor = new List<Color>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                     listColor.Add(new Color((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listColor;
        }

        public String GetColor(int ID)
        {
            con.Open();
            string sqlString = "select Color from ColorsID p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            String color = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    color = rdr["Color"].ToString();
                }
            }
            con.Close();
            return color;

        }

		public int GetId(string color)
        {
            con.Open();
            string sqlString = "select Id from ColorsId p where p.Color = " + color + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            int id=-1;
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    id = Convert.ToInt32(rdr["Id"]);
                }
            }
            con.Close();
            return id;

        }
    }
}