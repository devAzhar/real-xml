using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using DotNetNuke.Modules.MaggieDixon.Components;

namespace DotNetNuke.Modules.MaggieDixon.Data
{
    public class DataService
    {
        #region Private Static Members

        private static readonly DotNetNuke.Data.DataProvider Provider = DotNetNuke.Data.DataProvider.Instance();
        private const string ModuleQualifier = Constants.ModuleName + "_";

        #endregion Private Static Members

        #region Private Static Methods

        private static string GetFullyQualifiedName(string name)
        {
            return ModuleQualifier + name;
        }
        #endregion Private Static Methods

        public static void AddBuyListings(string propertyId, string headline, string description, decimal price, string streetNo, string streetName,
            string suburb, string category, string subCategory, int bedrooms, int ensuites, int bathrooms, int garages, string features,
            string otherFeatures, string landArea, string floorArea, string images, string mainImage, DateTime modifiedDate, string status)
        {
            Provider.ExecuteNonQuery(GetFullyQualifiedName("AddBuyListings"), propertyId, headline, description, price, streetNo, streetName, suburb, category,
                subCategory, bedrooms, ensuites, bathrooms, garages, features, otherFeatures, landArea, floorArea, images, mainImage, modifiedDate, status);
        }

        public static void AddRentListings(string propertyID, string headline, string description, decimal price, string streetNo, string streetName,
            string suburb, string category, string subCategory, int bedrooms, int ensuites, int bathrooms, int garages, string features,
            string images, string mainImage, string dateAvailable, DateTime modifiedDate, string status)
        {
            Provider.ExecuteNonQuery(GetFullyQualifiedName("AddRentListings"), propertyID, headline, description, price, streetNo, streetName, suburb, category,
                subCategory, bedrooms, ensuites, bathrooms, garages, features, images, mainImage, dateAvailable, modifiedDate, status);
        }

        public static IDataReader GetRentListings()
        {
            return Provider.ExecuteReader(GetFullyQualifiedName("GetRentListings"));
        }

        public static IDataReader GetBuyListings()
        {
            return Provider.ExecuteReader(GetFullyQualifiedName("GetBuyListings"));
        }
    }
}