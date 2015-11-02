using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class SizeDAL
    {
        // public static string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public SizeDAL()
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

        public void deleteBikeBySize(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM SizeID WHERE Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Size> getAllSizes()
        {
            con.Open();
            string sqlString = "select * from SizeID";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Classes.Size> listColor = new List<Classes.Size>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listColor.Add(new Classes.Size((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listColor;
        }
		public int maxIdSize()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from SizeID;";
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
        public String GetSize(int ID)
        {
            con.Open();
            string sqlString = "select Size from SizeID p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            String size = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    size = rdr["Size"].ToString();
                }
            }
            con.Close();
            return size;
        }
		public void AddNeSize(int NewId, string NewSize)
        {
            string sqlString = "INSERT INTO SizeID (Id, Size) VALUES (@val1, @val2);";

            using (MySqlCommand comm = new MySqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewSize);
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