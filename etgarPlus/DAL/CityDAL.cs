using etgarPlus.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class CityDAL
    {
        // public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public CityDAL()
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

        public List<City> getAllCity()
        {
            con.Open();
            string sqlString = "select * from CityID";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<City> listCity = new List<City>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listCity.Add(new City((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listCity;
        }

        public String GetCity(int ID)
        {
            con.Open();
            string sqlString = "select Name from CityID p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            String city = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    city = rdr["Name"].ToString();
                }
            }
            con.Close();
            return city;

        }
    }
}