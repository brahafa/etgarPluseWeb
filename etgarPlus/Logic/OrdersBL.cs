using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class OrdersBL
    {
        OrdersDAL orderDAL;
        List<Classes.Order> orderList;
        public OrdersBL()
        {
            orderDAL = new OrdersDAL();
        }
        public void AddNewOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            orderDAL.AddNewOrder( Id,  ClientID,  ProductID,  Quantity);
        }
        public void UpdateOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            orderDAL.UpdateOrder(Id, ClientID, ProductID, Quantity);
        }
        public void DeleteOrder(int Id)
        {
            orderDAL.DeleteOrder(Id);
        }
        public List<Classes.Order> GetOrderById(int Id)
        {
            return orderDAL.GetOrderById(Id);
        }
        public List<Classes.Order> GetPriceOrder(int Id)
        {
            return orderDAL.GetPriceOrder(Id);
        }
        public List<Classes.Order> GetOrdersByClient(string Name)
        {
            return orderDAL.GetOrdersByClient(Name);
        }
    }
}