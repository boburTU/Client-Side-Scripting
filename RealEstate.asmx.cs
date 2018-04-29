using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;


namespace CIS3344_LAB5
{
    /// <summary>
    /// Summary description for RealEstate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class RealEstate : System.Web.Services.WebService
    {
        
        //testing purposes
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Boolean AddHome(Home home)
        {
            //add home object to database
            //return true if success else return false
            DBConnect objDBConnect = new DBConnect();
            string strSQL = "INSERT INTO Home (MLS_NUM, description, bedrooms, bathrooms, size, price, imageURL, currentStatus, address_1, address_2, city, state, zipcode) "
                            + "VALUES ( '" + home.MLS_NUM + "', '" + home.description + "', '" + home.numOfBedrooms + "', '" + home.numOfBathrooms + "', '" + home.size + "', '" + home.price + "', '" + home.imageURL + "', '" + home.currentStatus + "', '" + home.address_1 + "', '" + home.address_2 + "', '" + home.city + "', '" + home.state + "', '" + home.zipcode + "' )";
            int result = objDBConnect.DoUpdate(strSQL);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public Home GetHomeByMLS(int MLS_NUM)
        {
            DBConnect objDBConnect = new DBConnect();
            Home home = new Home();
            //do something
            string strSQL = "SELECT * FROM Home WHERE MLS_NUM = '" + MLS_NUM + "'";
            int recordCount = 0;
            objDBConnect.GetDataSet(strSQL, out recordCount);

            if (recordCount > 0){
                home.MLS_NUM = Convert.ToInt32(objDBConnect.GetField("MLS_NUM", 0));
                home.description = objDBConnect.GetField("description", 0).ToString();
                home.numOfBedrooms = Convert.ToInt32(objDBConnect.GetField("bedrooms", 0));
                home.numOfBathrooms = Convert.ToInt32(objDBConnect.GetField("bathrooms", 0));
                home.size = Convert.ToDouble(objDBConnect.GetField("size", 0));
                home.price = Convert.ToDouble(objDBConnect.GetField("price", 0));
                home.imageURL = objDBConnect.GetField("imageURL", 0).ToString();
                home.currentStatus = objDBConnect.GetField("currentStatus", 0).ToString();
                home.address_1 = objDBConnect.GetField("address_1", 0).ToString();
                home.address_2 = objDBConnect.GetField("address_2", 0).ToString();
                home.city = objDBConnect.GetField("city", 0).ToString();
                home.state = objDBConnect.GetField("state", 0).ToString();
                home.zipcode = Convert.ToInt32(objDBConnect.GetField("zipcode", 0));
            }
            return home;
        }

        [WebMethod]
        public Boolean ChangeStatus(int MLS_NUM, string newStatus)
        {
            DBConnect objDBConnect = new DBConnect();

            string strSQL = "UPDATE Home SET currentStatus = '"+newStatus+"' WHERE MLS_NUM = "+MLS_NUM+";";
            int result = objDBConnect.DoUpdate(strSQL);
            if (result > 0)
            {
                return true;
            }
            return false;
        }


        [WebMethod]
        public List<Home> GetHomesByPrice (double price)
        {
            int recordCount = 0;
            DBConnect objDBConnect = new DBConnect();
            string strSQL = "SELECT * FROM Home WHERE price <= " + price + ";";
            objDBConnect.GetDataSet(strSQL, out recordCount);
            List<Home> homes = new List<Home>();
            if (recordCount > 0)
            {
                for (int i = 0; i < recordCount; i++)
                {
                    Home home = new Home();
                    home.address_1 = objDBConnect.GetField("address_1", i).ToString();
                    home.address_2 = objDBConnect.GetField("address_2", i).ToString();
                    home.city = objDBConnect.GetField("city", i).ToString();
                    home.state = objDBConnect.GetField("state", i).ToString();
                    home.zipcode = Convert.ToInt32(objDBConnect.GetField("zipcode", i));
                    home.currentStatus = objDBConnect.GetField("currentStatus", i).ToString();
                    home.description = objDBConnect.GetField("description", i).ToString();
                    home.numOfBedrooms = Convert.ToInt32(objDBConnect.GetField("bedrooms", i));
                    home.numOfBathrooms = Convert.ToInt32(objDBConnect.GetField("bathrooms", i));
                    home.size = Convert.ToDouble(objDBConnect.GetField("size", i));
                    home.price = Convert.ToDouble(objDBConnect.GetField("price", i));
                    home.imageURL = objDBConnect.GetField("imageURL", i).ToString();
                    home.MLS_NUM = Convert.ToInt32(objDBConnect.GetField("MLS_NUM", i));
                    homes.Add(home);
                }
            }

            return homes;
        }

        [WebMethod]
        public List<Home> GetHomesByBedBath(int bedrooms, int bathrooms)
        {
            int recordCount = 0;
            DBConnect objDBConnect = new DBConnect();
            string strSQL = "SELECT * FROM Home WHERE bedrooms >= " + bedrooms + " AND bathrooms >= " + bathrooms + ";";
            objDBConnect.GetDataSet(strSQL, out recordCount);
            List<Home> homes = new List<Home>();
            if (recordCount > 0)
            {
                for (int i = 0; i < recordCount; i++)
                {
                    Home home = new Home();
                    home.address_1 = objDBConnect.GetField("address_1", i).ToString();
                    home.address_2 = objDBConnect.GetField("address_2", i).ToString();
                    home.city = objDBConnect.GetField("city", i).ToString();
                    home.state = objDBConnect.GetField("state", i).ToString();
                    home.zipcode = Convert.ToInt32(objDBConnect.GetField("zipcode", i));
                    home.currentStatus = objDBConnect.GetField("currentStatus", i).ToString();
                    home.description = objDBConnect.GetField("description", i).ToString();
                    home.numOfBedrooms = Convert.ToInt32(objDBConnect.GetField("bedrooms", i));
                    home.numOfBathrooms = Convert.ToInt32(objDBConnect.GetField("bathrooms", i));
                    home.size = Convert.ToDouble(objDBConnect.GetField("size", i));
                    home.price = Convert.ToDouble(objDBConnect.GetField("price", i));
                    home.imageURL = objDBConnect.GetField("imageURL", i).ToString();
                    home.MLS_NUM = Convert.ToInt32(objDBConnect.GetField("MLS_NUM", i));
                    homes.Add(home);
                }
            }

            return homes;
        }
    }
}
