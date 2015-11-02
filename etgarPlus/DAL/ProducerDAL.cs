using etgarPlus.Classes;
using etgarPlus.Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class ProducerDAL
    {
        //public static string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public ProducerDAL()
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
        public void deleteBikeByProducer(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM ProducerID WHERE Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Producer> getAllProducer()
        {
            con.Open();
            string sqlString = "select * from ProducerID";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Producer> listProducer = new List<Producer>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listProducer.Add(new Producer((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listProducer;
        }
        public string GetProducer(int ID)
        {
            con.Open();
            string sqlString = "select Producer from ProducerID p where p.Id = " + ID.ToString() + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            string prod = "";
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    prod = rdr["Producer"].ToString();
                }
            }
            con.Close();
            return prod;

        }
internal void AddNeproducer(int NewId, string NewProducer)
        {
            string sqlString = "INSERT INTO ProducerID (Id, Producer) VALUES (@val1, @val2);";

            using (MySqlCommand comm = new MySqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewProducer);
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

        public int maxIdProducer()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from ProducerID;";
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