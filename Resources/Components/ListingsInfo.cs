using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNuke.Modules.MaggieDixon.Components
{
    [Serializable]
    public class ListingsInfo
    {
        public string PropertyID { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int Bedrooms { get; set; }
        public int Ensuites { get; set; }
        public int Bathrooms { get; set; }
        public int Garages { get; set; }
        public string Features { get; set; }
        public string OtherFeatures { get; set; }
        public string LandArea { get; set; }
        public string FloorArea { get; set; }
        public string Images { get; set; }
        public string MainImage { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string DateAvailable { get; set; }
    }
}