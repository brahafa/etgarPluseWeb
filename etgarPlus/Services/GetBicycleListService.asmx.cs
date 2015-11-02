using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using etgarPlus.Classes;
using etgarPlus.Logic;
namespace etgarPlus.Services
{
    /// <summary>
    /// Summary description for GetBicycleListService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetBicycleListService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Bicycles> getAllBike()
        {
            BicycleBL bicyclBL = new BicycleBL();
            List<Bicycles> list = new List<Bicycles>();
            list = bicyclBL.getAllBike();
            
            return list;
        }
    }
}
