using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using MySql.Data.MySqlClient;

namespace etgarPlus
{
    public class OrdersDAL
    {

        //public string s;
        //public SqlConnection con;
        private MySqlConnection con = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;


        public OrdersDAL()
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
        public void AddNewOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            con.Open();

            con.Close();
        }
        public void UpdateOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            con.Open();

            con.Close();
        }

        public void DeleteOrder(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM Orders o where o.Id = " + Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Order> GetOrderById(int Id)
        {
            con.Open();
            string sqlString = "select * from Orders o where o.Id = "+ Id + ";";
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }

        public List<Order> GetPriceOrder(int Id)
        {
            con.Open();
            string sqlString = "select * from Orders o ;";///////////////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }

        public List<Order> GetOrdersByClient(string Name)
        {
            con.Open();
            string sqlString = "select * from Orders";//////////////////////////////////
            MySqlCommand com = new MySqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (MySqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }
    }
}