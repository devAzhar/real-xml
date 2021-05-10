/*
' Copyright (c) 2012 DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using System.Linq;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using DotNetNuke.Modules.MaggieDixon.Data;

namespace DotNetNuke.Modules.MaggieDixon.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for MaggieDixon
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {

        public static void AddBuyListings(ListingsInfo buyListings)
        {
            DataService.AddBuyListings(buyListings.PropertyID, buyListings.Headline, buyListings.Description, buyListings.Price, buyListings.StreetNo,
                buyListings.StreetName, buyListings.Suburb, buyListings.Category, buyListings.SubCategory, buyListings.Bedrooms, buyListings.Ensuites,
                buyListings.Bathrooms, buyListings.Garages, buyListings.Features, buyListings.OtherFeatures, buyListings.LandArea,buyListings.FloorArea,
                buyListings.Images, buyListings.MainImage, buyListings.ModifiedDate, buyListings.Status);
        }

        public static void AddRentListings(ListingsInfo rentListings)
        {
            DataService.AddRentListings(rentListings.PropertyID, rentListings.Headline, rentListings.Description, rentListings.Price, rentListings.StreetNo,
                rentListings.StreetName, rentListings.Suburb, rentListings.Category, rentListings.SubCategory, rentListings.Bedrooms, rentListings.Ensuites,
                rentListings.Bathrooms, rentListings.Garages, rentListings.Features, rentListings.Images, rentListings.MainImage, rentListings.DateAvailable,
                rentListings.ModifiedDate, rentListings.Status);
        }


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<MaggieDixonInfo> colMaggieDixons = GetMaggieDixons(ModuleID);
        //if (colMaggieDixons.Count != 0)
        //{
        //    strXML += "<MaggieDixons>";

        //    foreach (MaggieDixonInfo objMaggieDixon in colMaggieDixons)
        //    {
        //        strXML += "<MaggieDixon>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objMaggieDixon.Content) + "</content>";
        //        strXML += "</MaggieDixon>";
        //    }
        //    strXML += "</MaggieDixons>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlMaggieDixons = DotNetNuke.Common.Globals.GetContent(Content, "MaggieDixons");
        //foreach (XmlNode xmlMaggieDixon in xmlMaggieDixons.SelectNodes("MaggieDixon"))
        //{
        //    MaggieDixonInfo objMaggieDixon = new MaggieDixonInfo();
        //    objMaggieDixon.ModuleId = ModuleID;
        //    objMaggieDixon.Content = xmlMaggieDixon.SelectSingleNode("content").InnerText;
        //    objMaggieDixon.CreatedByUser = UserID;
        //    AddMaggieDixon(objMaggieDixon);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<MaggieDixonInfo> colMaggieDixons = GetMaggieDixons(ModInfo.ModuleID);

        //foreach (MaggieDixonInfo objMaggieDixon in colMaggieDixons)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objMaggieDixon.Content, objMaggieDixon.CreatedByUser, objMaggieDixon.CreatedDate, ModInfo.ModuleID, objMaggieDixon.ItemId.ToString(), objMaggieDixon.Content, "ItemId=" + objMaggieDixon.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

        public static List<ListingsInfo> GetRentListings()
        {
            return CBO.FillCollection<ListingsInfo>(DataService.GetRentListings());
        }

        public static List<ListingsInfo> GetBuyListings()
        {
            return CBO.FillCollection<ListingsInfo>(DataService.GetBuyListings());
        }
    }

}
