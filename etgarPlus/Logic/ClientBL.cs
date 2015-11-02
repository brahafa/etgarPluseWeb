using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class ClientBL
    {
        public static ClientDAL clientDAL;
        List<Classes.Client> ClientList;

        public ClientBL()
        {
            clientDAL = new ClientDAL();
        }
        public void AddNewClient(int Id ,string Name, string ContactName, string Address, int CityID, int ZipCode,string Phone, string ContactPhone, string OpenTime, int LevelPrice,
            String Email, String Password, int Status){
                clientDAL.AddNewClient(Id, Name, ContactName, Address, CityID, ZipCode, Phone, ContactPhone, OpenTime, LevelPrice, Email, Password, Status);
        }
        public void UpdateClient(int Id, string Name, string ContactName, string Address, int CityID, int ZipCode, string Phone, string ContactPhone, string OpenTime, int LevelPrice,
            String Email, String Password, int Status){
                clientDAL.UpdateClient(Id, Name, ContactName, Address, CityID, ZipCode, Phone, ContactPhone, OpenTime, LevelPrice, Email, Password, Status);
        }
        public void DeleteClient(string Name)
        {
            clientDAL.DeleteClient(Name);
        }
        public Boolean EmailAlreadyExists(String email)
        {
           return clientDAL.EmailAlreadyExists(email);
        }
        
              public int getMaxId()
        {
           return clientDAL.maxIdClient()+1;

        }
        public List<Classes.Client> GetAllClient()
        {
            return (clientDAL.GetAllClient());
        }
        public List<Classes.Client> SortClientByName()
        {
            return (clientDAL.SortClientByName());
        }
        public List<Classes.Client> SortClientByContactName()
        {
            return (clientDAL.SortClientByContactName());
        }

        public List<Classes.Client> SearchByName(string Name)
        {
            return (clientDAL.SearchByName(Name));
        }
        public List<Classes.Client> SearchByContactName(string ContactName)
        {
            return (clientDAL.SearchByContactName(ContactName));
        }
        public string getEmailByName(string Name)
        {
            return (clientDAL.getEmailByName(Name));
        }
        public int verifiedClientByEmailANDPassword(String eMail, String Password)
        {
            return clientDAL.getClientByEmailANDPassword(eMail, Password);
        }
        public Classes.Client getClientByEmail(String eMail)
        {
            return clientDAL.getClientByEmail(eMail);
        }

        public List<Classes.Client> getNewClient()
        {
            return clientDAL.getNewClient();
        }
        public Boolean updateLevel(int id, int level)
        {
            if (clientDAL.updateLevel(id, level))
                return true;
            return false;
        }
    }
}