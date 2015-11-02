using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Classes
{

    public class Client
    {
        private int _ID;
        private String _Name;
        private String _ContactName;
        private String _Address;
        private int _CityID;
        private int _ZipCode;
        private String _Phone;
        private String _ContactPhone;
        private String _OpenTime;
        private int _LevelPrice;
        private String _Email;
        private String _Password;
        private int _Status;

        public int id { get { return _ID; } set { _ID = value; } }
        public String name { get { return _Name; } set { _Name = value; } }
        public String contactName { get { return _ContactName; } set { _ContactName = value; } }
        public String address { get { return _Address; } set { _Address = value; } }
        public int cityID { get { return _CityID; } set { _CityID = value; } }
        public int zipCode { get { return _ZipCode; } set { _ZipCode = value; } }
        public String phone { get { return _Phone; } set { _Phone = value; } }
        public String contactPhone { get { return _ContactPhone; } set { _ContactPhone = value; } }
        public String openTime { get { return _OpenTime; } set { _OpenTime = value; } }
        public int levelPrice { get { return _LevelPrice; } set { _LevelPrice = value; } }
        public String email { get { return _Email; } set { _Email = value; } }
        public String password { get { return _Password; } set { _Password = value; } }
        public int status { get { return _Status; } set { _Status = value; } }


        public Client(int ID, String Name, String ContactName, String Address, int CityID, int ZipCode,
            String Phone, String ContactPhone, String OpenTime, int LevelPrice, String Email, String Password, int Status)
        {
            _ID = ID;
            _Name = Name;
            _ContactName = ContactName;
            _Address = Address;
            _CityID = CityID;
            _ZipCode = ZipCode;
            _Phone = Phone;
            _ContactPhone = ContactPhone;
            _OpenTime = OpenTime;
            _LevelPrice = LevelPrice;
            _Email = Email;
            _Password = Password;
            _Status = Status;
        }

        public Client()
        {
            // TODO: Complete member initialization
        }
    }
}