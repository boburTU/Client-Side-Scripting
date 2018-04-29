using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Home
    {

        public int MLS_NUM { get; set; }
        public string description { get; set; }
        public int numOfBedrooms { get; set; }
        public int numOfBathrooms { get; set; }
        public double size { get; set; }
        public double price { get; set; }
        public string imageURL { get; set; }
        public string currentStatus { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }

        public Home() {
            this.address_1 = "";
            this.address_2 = "";
            this.city = "";
            this.state = "";
            this.zipcode = 0;
            this.currentStatus = "";
            this.description = "";
            this.imageURL = "";
            this.MLS_NUM = 0;
            this.numOfBathrooms = 0;
            this.numOfBedrooms = 0;
            this.price = 0.0;
            this.size = 0.0;
        }

    }
}
