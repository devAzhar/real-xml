using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using DotNetNuke.Common;

namespace DotNetNuke.Modules.MaggieDixon.Components
{
    public class Constants
    {
        public const string ModuleName = "FM_MaggieDixonListings";

        public static string SourceDirectoryXMLBuy(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML/RealNZ") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/RealNZ");
            //return HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/RealNZ");
        }
        public static string SourceDirectoryXMLBuyMyDesktop(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML/MyDesktop") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/MyDesktop");
            //return HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/RealNZ");
        }
        public static string SourceDirectoryXMLBuyREAXML(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML/Rex") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/Rex");
            //return HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/RealNZ");
        }

        public static string SourceDirectoryXMLRent(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML/Rockend") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML/Rockend");
        }

        public static string DestinationDirectoryXMLBuy(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML_Processed/MyDesktop") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML_Processed/MyDesktop");
            //return HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML_Processed/RealNZ");
        }
        public static string DestinationDirectoryXMLBuyREAXML(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML_Processed/Rex") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML_Processed/Rex");
            //return HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML_Processed/RealNZ");
        }

        public static string DestinationDirectoryXMLRent(int portalID, bool isScheduler)
        {
            return isScheduler ? HostingEnvironment.MapPath("~/Portals/" + portalID + "/XML_Processed/Rockend") : HttpContext.Current.Server.MapPath("~/Portals/" + portalID + "/XML_Processed/Rockend");
        }

        public static string ListingImages(int portalID, bool isBuy)
        {
            if (isBuy)
            {
                return ""; 
            }
            return Globals.ApplicationPath + "/Portals/" + portalID + "/ListingImages/Rockend/";
        }
    }

    
}

