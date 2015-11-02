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
    public class LevelPriceDAL
    {
        
        //public static string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public LevelPriceDAL()
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
        public List<LevelPrice> getAllLevels()
        {
            con.Open();
            string sqlString = "select * from LevelPriceID";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<LevelPrice> listLevel = new List<LevelPrice>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listLevel.Add(new LevelPrice((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listLevel;
        }
    }

  
}