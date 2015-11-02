using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using System.Data.OleDb;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace etgarPlus
{
    public class ClientDAL
    {
        // public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public ClientDAL()
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
        public void AddNewClient(int Id, string Name, string ContactName, string Address, int CityID,
            int ZipCode, string Phone, string ContactPhone, string OpenTime, int LevelPrice, String Email, String Password, int Status)
        {

            string sqlString = "INSERT INTO Client (Id, Name, ContactName, Address, CityID, ZipCode, Phone, ContactPhone, " +
            "OpenTime, LevelPrice, Email, Password, Status) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9," +
            "@val10, @val11, @val12, @val13);";
            using (MySqlCommand comm = new MySqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", Id);
                comm.Parameters.AddWithValue("@val2", Name);
                comm.Parameters.AddWithValue("@val3", ContactName);
                comm.Parameters.AddWithValue("@val4", Address);
                comm.Parameters.AddWithValue("@val5", CityID);
                comm.Parameters.AddWithValue("@val6", ZipCode);
                comm.Parameters.AddWithValue("@val7", Phone);
                comm.Parameters.AddWithValue("@val8", ContactPhone);
                comm.Parameters.AddWithValue("@val9", OpenTime);
                comm.Parameters.AddWithValue("@val10", LevelPrice);
                comm.Parameters.AddWithValue("@val11", Email);
                comm.Parameters.AddWithValue("@val12", Password);
                comm.Parameters.AddWithValue("@val13", Status);

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

            //SqlCommand com = new SqlCommand(sqlString, con);
            //con.Close();
        }
        public void UpdateClient(int Id, string Name, string ContactName, string Address, int CityID,
            int ZipCode, string Phone, string ContactPhone, string OpenTime, int LevelPrice, String Email, String Password, int Status)
        {
            con.Open();

            con.Close();
        }

        public void DeleteClient(string Name)/// name is a key??
        {
            con.Open();
            string sqlString = @"DELETE FROM Client c where c.Name = " + Name + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); com.ExecuteNonQuery();
            con.Close();

        }
        public int maxIdClient()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from Client;";
            MySqlCommand com = new MySqlCommand(sqlString, con); int maxId = 0;
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

        public List<Client> GetAllClient()
        {
            con.Open();
            string sqlString = "select * from Client";
            MySqlCommand com = new MySqlCommand(sqlString, con); List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }

        public List<Client> SearchByName(String Name)
        {
            con.Open();
            string sqlString = "select * from Client c where c.Name = " + Name + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }

        public Boolean EmailAlreadyExists(String email1)
        {
            con.Open();
            string sqlString = "select * from Client c where c.Email = " + email1 + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            if (listClient.Count == 0)
                return false;
            return true;
        }

        public List<Client> SearchByContactName(string ContactName)
        {
            con.Open();
            string sqlString = "select * from Client c where c.ContactName = " + ContactName + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }

        public String getEmailByName(String Name)// contact name or company name???
        {
            con.Open();
            string sqlString = "select * from Client c where ";//////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            MySqlDataReader rdr = com.ExecuteReader();
            con.Close();
            return ((String)rdr[0]).Trim();
        }

        public List<Client> SortClientByName()
        {
            con.Open();
            string sqlString = "select * from Client";///////////////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }

        public List<Client> SortClientByContactName()
        {
            con.Open();
            string sqlString = "select * from Client";/////////////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }

        public int getClientByEmailANDPassword(string eMail, string Password)
        {
            con.Open();
            string sqlString = "select * from Client where Email='" + eMail + "' AND Password='" + Password + "';";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            int c = 0;
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    c = Convert.ToInt32(rdr["LevelPrice"]);
                    break;
                }
            }
            con.Close();
            return c;
        }

        public Client getClientByEmail(string eMail)
        {
            con.Open();
            string sqlString = "select * from Client c where Email='" + eMail + "';";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            Client client = null;
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    client = new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"]));
                    break;
                }
            }
            con.Close();
            return client;
        }

        public List<Client> getNewClient()
        {
            con.Open();
            string sqlString = "select * from Client where Status='" + 1 + "';";
            MySqlCommand com = new MySqlCommand(sqlString, con); 
            List<Client> listClient = new List<Client>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listClient.Add(new Client(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString(), rdr["ContactName"].ToString(), rdr["Address"].ToString(), Convert.ToInt32(rdr["CityID"]), Convert.ToInt32(rdr["ZipCode"]), rdr["Phone"].ToString(), rdr["ContactPhone"].ToString(), rdr["OpenTime"].ToString(), Convert.ToInt32(rdr["LevelPrice"]), rdr["Email"].ToString(), rdr["Password"].ToString(), Convert.ToInt32(rdr["Status"])));
                }
            }
            con.Close();
            return listClient;
        }
        public Boolean updateLevel(int id, int level)
        {
            Debug.WriteLine("try to update");
            con.Open();
            string sqlString = "UPDATE Client SET LevelPrice = " + level + ", Status = 2 WHERE Id=" + (id+1) + ";";
            try
            {
                Debug.WriteLine(sqlString);
                MySqlCommand com = new MySqlCommand(sqlString, con); 
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}