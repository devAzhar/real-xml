using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNuke.Modules.MaggieDixon
{
    public class DataModel
    {

    }

    public class Propertydetail
    {
        

        public Propertydetail()
        {
            Images = new List<string>();
        }
        public string Category { get; set; }
        public string uniqueID { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string streetNo { get; set; }
        public string streetName { get; set; }
        public string suburb { get; set; }
        public string headline { get; set; }

        public int bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int garages { get; set; }

        public string modTime { get; set; }
        public List<string> Images { get; set; }
        public string subcategory { get; set; }
        public string ensuites { get; set; }
        public string CarParks { get; set; }
        public string FirstImage { get; set; }

        public string status { get; set; }
    }
}