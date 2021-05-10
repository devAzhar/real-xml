using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;


namespace DotNetNuke.Modules.MaggieDixon.Components
{
    public class XMLUtility
    {

        public static void ReadBuyXML(int portalID, bool isScheduler)
        {
            
            //GET ALL XML FILE 
            var xmlFiles = Directory.GetFiles(Constants.SourceDirectoryXMLBuy(portalID, isScheduler), "*.xml");
            var xmlDocument = new XmlDocument();
           
            foreach (var xmlFile in xmlFiles)
            {
                xmlDocument.Load(xmlFile);
                 //Read All XML Nodes
                if (xmlDocument.DocumentElement == null) continue;
                var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
                var objprop = new ListingsInfo();
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element))
                    {
                        DateTime dateValue;
                        string dateString;
                        switch (xmlReader.Name)
                        {
                            case "uniqueID":
                                objprop.PropertyID = xmlReader.ReadString();
                                break;
                            case "headline":
                                var headLine = xmlReader.ReadString();
                                objprop.Headline = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(headLine.ToLower());
                                break;
                            case "description":
                                objprop.Description = xmlReader.ReadString();
                                break;
                            case "price":
                                objprop.Price = Convert.ToDecimal(xmlReader.ReadString());
                                break;
                            case "commercialRent":
                                objprop.Price = Convert.ToDecimal(xmlReader.ReadString());
                                break;
                            case "streetNo":
                                objprop.StreetNo = xmlReader.ReadString();
                                break;
                            case "streetName":
                                objprop.StreetName = xmlReader.ReadString();
                                break;
                            case "suburb":
                                objprop.Suburb = xmlReader.ReadString();
                                break;
                            case "residential":
                                objprop.Category = "Residential";
                                objprop.SubCategory = "";
                                dateString = xmlReader.GetAttribute("modTime");
                                dateValue = Convert.ToDateTime(dateString.Substring(0,4) + "/" +  dateString.Substring(5,2) + "/" + 
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11,8));
                                objprop.ModifiedDate = dateValue;
                                objprop.Status = xmlReader.GetAttribute("status");
                                break;
                            case "rural":
                                objprop.Category = "Rural";
                                objprop.SubCategory = "";
                                dateString = xmlReader.GetAttribute("modTime");
                                dateValue = Convert.ToDateTime(dateString.Substring(0,4) + "/" +  dateString.Substring(5,2) + "/" + 
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11,8));
                                objprop.ModifiedDate = dateValue;
                                objprop.Status = xmlReader.GetAttribute("status");
                                break;
                            case "land":
                                objprop.Category = "Residential";
                                objprop.SubCategory = "";
                                objprop.Bedrooms = 0;
                                objprop.Ensuites = 0;
                                objprop.Bathrooms = 0;
                                objprop.Garages = 0;
                                objprop.Features = "";
                                objprop.OtherFeatures = "";
                                objprop.LandArea = "";
                                objprop.FloorArea = "";
                                dateString = xmlReader.GetAttribute("modTime");
                                dateValue = Convert.ToDateTime(dateString.Substring(0,4) + "/" +  dateString.Substring(5,2) + "/" + 
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11,8));
                                objprop.ModifiedDate = dateValue;
                                objprop.Status = xmlReader.GetAttribute("status");
                                break;
                            case "business":
                                objprop.Category = "Commercial";
                                objprop.SubCategory = "";
                                objprop.Bedrooms = 0;
                                objprop.Ensuites = 0;
                                objprop.Bathrooms = 0;
                                objprop.Garages = 0;
                                objprop.Features = "";
                                objprop.OtherFeatures = "";
                                objprop.LandArea = "";
                                objprop.FloorArea = "";
                                dateString = xmlReader.GetAttribute("modTime");
                                dateValue = Convert.ToDateTime(dateString.Substring(0, 4) + "/" + dateString.Substring(5, 2) + "/" +
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11, 8));
                                objprop.ModifiedDate = dateValue;
                                objprop.Status = xmlReader.GetAttribute("status");
                                break;
                            case "commercial":
                                objprop.Category = "Commercial";
                                objprop.SubCategory = "";
                                objprop.Bedrooms = 0;
                                objprop.Ensuites = 0;
                                objprop.Bathrooms = 0;
                                objprop.Garages = 0;
                                objprop.Features = "";
                                objprop.OtherFeatures = "";
                                objprop.LandArea = "";
                                objprop.FloorArea = "";
                                dateString = xmlReader.GetAttribute("modTime");
                                dateValue = Convert.ToDateTime(dateString.Substring(0, 4) + "/" + dateString.Substring(5, 2) + "/" +
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11, 8));
                                objprop.ModifiedDate = dateValue;
                                objprop.Status = xmlReader.GetAttribute("status");
                                break;
                            case "category":
                                objprop.SubCategory = xmlReader.ReadString();
                                break;
                            case "landCategory":
                                objprop.Category = xmlReader.GetAttribute("name");
                                break;
                            case "businessSubCategory":
                                objprop.SubCategory = xmlReader.ReadString();
                                break;
                            case "bedrooms":
                                objprop.Bedrooms = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            //case "ensuites":
                            case "ensuite":
                                objprop.Ensuites = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "bathrooms":
                                objprop.Bathrooms = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "garages":
                                objprop.Garages = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "alarmSystem":
                                objprop.Features = Convert.ToInt32(xmlReader.ReadString()) > 0 ? "Alarm" : "";
                                break;
                            case "otherFeatures":
                                objprop.OtherFeatures = xmlReader.ReadString();
                                break; 
                            case "landDetails":
                                xmlReader.MoveToContent();
                                xmlReader.Read();
                                objprop.LandArea = xmlReader.ReadString();
                                break;
                             case "buildingDetails":
                                xmlReader.MoveToContent();
                                xmlReader.Read();
                                objprop.FloorArea = xmlReader.ReadString();
                                break;
                            case "img":
                                if (string.IsNullOrEmpty(objprop.Images))
                                    objprop.Images = xmlReader.GetAttribute("file");
                                else
                                {
                                    objprop.Images += "," + xmlReader.GetAttribute("file");
                                }
                                if (string.IsNullOrEmpty(objprop.MainImage))
                                    objprop.MainImage = xmlReader.GetAttribute("file");
                                break;
                        }
                    }
                    else if (xmlReader.Name == "images" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.PropertyID != "")
                    {
                        //SAVE IT TO SQL
                        FeatureController.AddBuyListings(objprop);
                        objprop = new ListingsInfo();
                    }
                }//END OF WHILE
                //MOVE PROCESSED XML
                MoveProcessedXML(xmlFile, portalID, true, isScheduler);
            }//END OF FOR
        }
        
        public static void ReadBuyMyDXML(int portalID, bool isScheduler)
        {
       
            //GET ALL XML FILE 
            var xmlFiles = Directory.GetFiles(Constants.SourceDirectoryXMLBuyMyDesktop(portalID, isScheduler), "*.xml");
            var doc = new XmlDocument();

            foreach (var xmlFile in xmlFiles)
            {
                doc.Load(xmlFile);
            
            string text = string.Empty;
            XmlNodeList xnl = doc.SelectNodes("/propertyList/residential");
            foreach (XmlNode node in xnl)
            {

                ListingsInfo objinfo = new ListingsInfo();
                objinfo.Category = "Residential";
                string dateString = node.Attributes["modTime"].InnerText.ToString();
                objinfo.ModifiedDate = Convert.ToDateTime(dateString.Substring(0, 4) + "/" + dateString.Substring(5, 2) + "/" +
                                    dateString.Substring(8, 2) + " " + dateString.Substring(11, 5));
                objinfo.Status = node.Attributes["status"].InnerText.ToString();
                
                objinfo.Price = Convert.ToDecimal(node["price"].InnerText.ToString());
                objinfo.Headline = node["headline"].InnerText.ToString();
                objinfo.Description = node["description"].InnerText.ToString();
                objinfo.Category = node["category"].InnerText.ToString();
                objinfo.PropertyID = node["uniqueID"].InnerText.ToString();
                if (node["toilets"] != null)
                { objinfo.Ensuites = int.Parse(node["toilets"].InnerText.ToString()); }
                else
                { objinfo.Ensuites = 0; }

                XmlNodeList xnl2 = node.SelectNodes("address");
                foreach (XmlNode node2 in xnl2)
                {
                    objinfo.StreetNo = node2["streetNumber"].InnerText.ToString();
                    objinfo.StreetName = node2["street"].InnerText.ToString();
                    objinfo.Suburb = node2["suburb"].InnerText.ToString();
                }

                XmlNodeList xnl3 = node.SelectNodes("features");
                foreach (XmlNode node3 in xnl3)
                {
                    objinfo.Bathrooms = Convert.ToInt32(node3["bathrooms"].InnerText.ToString());
                    objinfo.Bedrooms = Convert.ToInt32(node3["bedrooms"].InnerText.ToString());
                    objinfo.Garages = Convert.ToInt32(node3["garages"].InnerText.ToString());
                    objinfo.OtherFeatures = node3["otherFeatures"].InnerText.ToString();  
                }

                XmlNodeList xnl4 = node.SelectNodes("landDetails");
                foreach (XmlNode node4 in xnl4)
                {
                    objinfo.LandArea = node4["area"].InnerText.ToString();
                }

                XmlNodeList xnl5 = node.SelectNodes("buildingDetails");
                foreach (XmlNode node5 in xnl5)
                {
                    objinfo.FloorArea = node5["area"].InnerText.ToString();
                }

                XmlNodeList xnl6 = node.SelectNodes("images/img");
                foreach (XmlNode node6 in xnl6)
                {
                    if (node6.Attributes["id"].InnerText.ToString() == "m")
                    {
                        objinfo.MainImage = node6.Attributes["url"].InnerText.ToString();
                    }

                    if (node6.Attributes["url"] != null)
                    {
                        if (string.IsNullOrEmpty(objinfo.Images))
                        { objinfo.Images = node6.Attributes["url"].InnerText.ToString(); }
                        else
                        {
                            objinfo.Images += "," + node6.Attributes["url"].InnerText.ToString();
                        }
                        
                    }
                   

                }
    
                try{
                    //SAVE IT TO SQL
                FeatureController.AddBuyListings(objinfo);
                   }catch(Exception ex){

                    string dd = ex.ToString();
                    int a = 0;

                }
            }

            MoveProcessedXML(xmlFile, portalID, true, isScheduler);
            }

             
        }
        public static void ReadBuyREAXML(int portalID, bool isScheduler)
        {
            // By MMM as on 01-04-2017 for  Implement REAXML Format for Residential, Land and Rural listing
            //GET ALL XML FILE 
            var xmlFiles = Directory.GetFiles(Constants.SourceDirectoryXMLBuyREAXML(portalID, isScheduler), "*.xml");
            var doc = new XmlDocument();

            foreach (var xmlFile in xmlFiles)
            {
                doc.Load(xmlFile);

                string text = string.Empty;
                string catgry =string.Empty;
                XmlNodeList xnl = doc.SelectNodes("/propertyList/residential");
                if (xnl.Count > 0) { catgry = "Residential"; }
                else 
                {
                    xnl = doc.SelectNodes("/propertyList/land");
                    if (xnl.Count > 0) { catgry = "Land"; }
                    else
                    {
                        xnl = doc.SelectNodes("/propertyList/rural");
                        if (xnl.Count > 0) { catgry = "Rural"; }
                        else
                        { }
                    
                    }
               
                }

                foreach (XmlNode node in xnl)
                {

                    ListingsInfo objinfo = new ListingsInfo();
                    objinfo.Category = catgry;
                    if (catgry == "Residential") { }
                    string dateString = node.Attributes["modTime"].InnerText.ToString();
                    objinfo.ModifiedDate = Convert.ToDateTime(dateString.Substring(0, 4) + "/" + dateString.Substring(5, 2) + "/" +
                                        dateString.Substring(8, 2) + " " + dateString.Substring(11, 5));
                    objinfo.Status = node.Attributes["status"].InnerText.ToString();
                    if (node["priceView"] != null)
                    {
                        objinfo.Price = Convert.ToDecimal(node["priceView"].InnerText.ToString());
                    }
                    else
                    { objinfo.Price = 0; }

                     if (node["headline"] != null)
                    {
                        objinfo.Headline = node["headline"].InnerText.ToString();
                    }
                    else
                     { objinfo.Headline = ""; }

                     if (node["description"] != null)
                    {
                    objinfo.Description = node["description"].InnerText.ToString();
                         }
                    else
                     { objinfo.Description = ""; }

                    if (catgry == "Residential")
                    {
                        if (node["category"] != null)
                        {
                        objinfo.Category = node["category"].InnerText.ToString();
                              }
                    else
                        { objinfo.Category = ""; }
                    }
                    else if (catgry == "Land")
                    {
                        if (node["landCategory"] != null)
                                                        {objinfo.Category = node["landCategory"].InnerText.ToString();
                         }
                    else
                        { objinfo.Category = ""; }
                    }
                    else if (catgry == "Rural")
                    {
                        if (node["ruralCategory"] != null)
                        {
                            objinfo.Category = node["ruralCategory"].InnerText.ToString(); 
                         }
                    else
                        { objinfo.Category = ""; }
                    }
                    if (node["uniqueID"] != null)
                    {
                    objinfo.PropertyID = node["uniqueID"].InnerText.ToString();
                         }
                    else
                    { objinfo.PropertyID = ""; }

                    if (node["ensuite"] != null)
                    { objinfo.Ensuites = int.Parse(node["ensuite"].InnerText.ToString()); }
                    else
                    { objinfo.Ensuites = 0; }

                    if (node["address"] != null)
                    {

                        XmlNodeList xnl2 = node.SelectNodes("address");
                        foreach (XmlNode node2 in xnl2)
                        {
                            objinfo.StreetNo = node2["streetNumber"].InnerText.ToString();
                            objinfo.StreetName = node2["street"].InnerText.ToString();
                            objinfo.Suburb = node2["suburb"].InnerText.ToString();
                        }
                    }
                    else
                    {
                        objinfo.StreetNo = "";
                        objinfo.StreetName = "";
                        objinfo.Suburb = "";
                    }

                    if (node["features"] != null)
                    {

                        XmlNodeList xnl3 = node.SelectNodes("features");
                        foreach (XmlNode node3 in xnl3)
                        {
                            if (catgry != "Land")
                            {
                                objinfo.Bathrooms = Convert.ToInt32(node3["bathrooms"].InnerText.ToString());
                                objinfo.Bedrooms = Convert.ToInt32(node3["bedrooms"].InnerText.ToString());
                                objinfo.Garages = Convert.ToInt32(node3["garages"].InnerText.ToString());
                                objinfo.OtherFeatures = node3["otherFeatures"].InnerText.ToString();
                                objinfo.Ensuites = Convert.ToInt32(node3["ensuite"].InnerText.ToString());
                            }
                            else {
                                objinfo.Bathrooms = 0;
                                objinfo.Bedrooms = 0;
                                objinfo.Garages = 0;
                                objinfo.OtherFeatures = "";
                            }
                        }
                    }
                    else
                    { objinfo.Price = 0; }

                    if (node["landDetails"] != null)
                    {

                        XmlNodeList xnl4 = node.SelectNodes("landDetails");
                        foreach (XmlNode node4 in xnl4)
                        {
                            objinfo.LandArea = node4["area"].InnerText.ToString();
                        }
                    }
                    else
                    { objinfo.LandArea = ""; }

                    if (catgry != "Land")
                    {
                        if (node["buildingDetails"] != null)
                        {
                            XmlNodeList xnl5 = node.SelectNodes("buildingDetails");
                            foreach (XmlNode node5 in xnl5)
                            {
                                objinfo.FloorArea = node5["area"].InnerText.ToString();
                            }
                        }
                        else
                            { objinfo.FloorArea = ""; }

                    }
                    else { objinfo.FloorArea = ""; }

                    if (node["objects"] != null)
                    {

                        XmlNodeList xnl6 = node.SelectNodes("objects/img");
                    foreach (XmlNode node6 in xnl6)
                    {
                        if (node6.Attributes["id"].InnerText.ToString() == "m")
                        {
                            objinfo.MainImage = node6.Attributes["url"].InnerText.ToString();
                            objinfo.MainImage = objinfo.MainImage.Replace("http:", "https:");
                        }

                        if (node6.Attributes["url"] != null)
                        {
                            if (string.IsNullOrEmpty(objinfo.Images))
                            { objinfo.Images = node6.Attributes["url"].InnerText.ToString(); }
                            else
                            {
                                objinfo.Images += "," + node6.Attributes["url"].InnerText.ToString();
                            }
                            objinfo.Images = objinfo.Images.Replace("http:", "https:");

                        }


                    }
                    }
                    else
                    { objinfo.MainImage = ""; objinfo.Images = ""; }

                    try
                    {
                        //SAVE IT TO SQL
                        FeatureController.AddBuyListings(objinfo);
                    }
                    catch (Exception ex)
                    {

                        string dd = ex.ToString();
                        int a = 0;

                    }
                }

                MoveProcessedXML(xmlFile, portalID, true, isScheduler);
            }


        }
        protected static void MoveProcessedXML(string xmlFileName, int portalID, bool isBuy, bool isScheduler)
        {
           var fileName = Path.GetFileName(xmlFileName);
            if (fileName == null) return;
            var destinationFile = Path.Combine(isBuy ? Constants.DestinationDirectoryXMLBuyREAXML(portalID, isScheduler) : Constants.DestinationDirectoryXMLBuyREAXML(portalID, isScheduler), fileName);
            //first, delete target file if exists, as File.Move() does not support overwrite
            if (File.Exists(destinationFile))
            {
                File.Delete(destinationFile);
            }
            File.Move(xmlFileName, destinationFile);
        }

        public static void ReadRentXML(int portalID, bool isScheduler)
        {

            //GET ALL XML FILE 
            var xmlFiles = Directory.GetFiles(Constants.SourceDirectoryXMLRent(portalID, isScheduler), "*.xml");
            var xmlDocument = new XmlDocument();

            foreach (var xmlFile in xmlFiles)
            {
                xmlDocument.Load(xmlFile);
                //Read All XML Nodes
                if (xmlDocument.DocumentElement == null) continue;
                var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
                var objprop = new ListingsInfo();
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element))
                    {
                        switch (xmlReader.Name)
                        {
                            case "Property":
                                objprop.PropertyID = xmlReader.GetAttribute("PropertyID");
                                objprop.Ensuites = 0;
                                objprop.Features = "";
                                break;
                            case "BuildingType":
                                objprop.Category = xmlReader.GetAttribute("Type");
                                break;
                            case "PropertyType":
                                objprop.SubCategory = xmlReader.GetAttribute("Type");
                                break;
                            case "Rent":
                                objprop.Price = Convert.ToDecimal(xmlReader.ReadString());
                                break;
                            case "AdvHeading":
                                var headLine = xmlReader.ReadString();
                                objprop.Headline = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(headLine.ToLower());
                                break;
                            case "AdvDescription":
                                objprop.Description = xmlReader.ReadString();
                                break;
                            case "StreetNumber":
                                objprop.StreetNo = xmlReader.ReadString();
                                break;
                            case "StreetName":
                                objprop.StreetName = xmlReader.ReadString();
                                break;
                            case "Suburb":
                                objprop.Suburb = xmlReader.ReadString();
                                break;
                            case "Bedrooms":
                                objprop.Bedrooms = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "Bathrooms":
                                objprop.Bathrooms = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            //case "Ensuites":
                            case "Ensuite":
                                objprop.Ensuites = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "Garages":     // By MMM  to replace  Carports
                                objprop.Garages = Convert.ToInt32(xmlReader.ReadString());
                                break;
                            case "AirConditioning":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "AirConditioning";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "AirConditioning";
                                }
                                break;
                            case "Alarm":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Alarm";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Alarm";
                                }
                                break;
                            case "Vacuum":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Vacuum";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Vacuum";
                                }
                                break;
                            case "Intercom":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Intercom";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Intercom";
                                }
                                break;
                            case "Pool":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features = type + " Pool";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features += "," + type + " Pool";

                                }
                                break;
                            case "Spa":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features = type + " Spa";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features += "," + type + " Spa";

                                }
                                break;
                            case "TennisCourt":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Tennis Court";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Tennis Court";
                                }
                                break;
                            case "Heating":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features = type + " Heating";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features += "," + type + " Heating";
                                    
                                }
                                break;
                            case "HotWater":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features = type + " Hot Water";
                                    
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features += "," + type + " Hot Water";
                                }
                                break;
                            case "FirePlace":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Fire Place";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Fire Place";
                                }
                                break;
                            case "Furnished":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Furnished";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Furnished";
                                }
                                break;
                            case "Laundry":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features = type + " Laundry";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) <= 0) continue;
                                    var type = xmlReader.GetAttribute("Type");
                                    objprop.Features += "," + type + " Laundry";
                                }
                                break;
                            case "Balcony":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Balcony";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Balcony";
                                }
                                break;
                            case "BuildingSecurity":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Building Security";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Building Security";
                                }
                                break;
                            case "Pets":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    objprop.Features = Convert.ToInt32(xmlReader.ReadString()) > 0 ? "Pets Allowed" : "Pets Not Allowed";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Pets Allowed";
                                    else
                                    {
                                        objprop.Features += "," + "Pets Not Allowed";
                                    }
                                }
                                break;
                            case "CityViews":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "City Views";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "City Views";
                                }
                                break;
                            case "WaterViews":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Water Views";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Water Views";
                                }
                                break;
                            case "DistrictViews":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "District Views";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "District Views";
                                }
                                break;
                            case "NearBeach":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Close to Beach";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Close to Beach";
                                }
                                break;
                            case "NearShops":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Close to Shops";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Close to Shops";
                                }
                                break;
                            case "NearTransport":
                                if (string.IsNullOrEmpty(objprop.Features))
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features = "Close to Transport";
                                }
                                else
                                {
                                    if (Convert.ToInt32(xmlReader.ReadString()) > 0)
                                        objprop.Features += "," + "Close to Transport";
                                }
                                break;

                            case "DateAvailable":
                                objprop.DateAvailable = xmlReader.ReadString();
                                break;
                            case "Image":
                                if (string.IsNullOrEmpty(objprop.Images))
                                    objprop.Images = xmlReader.GetAttribute("FileName");
                                else
                                {
                                    objprop.Images += "," + xmlReader.GetAttribute("FileName");
                                }
                                if (string.IsNullOrEmpty(objprop.MainImage))
                                    objprop.MainImage = xmlReader.GetAttribute("FileName");
                                break;
                            case "UpdateStatus":
                                objprop.Status = xmlReader.GetAttribute("Action");
                                break;
                            case "UpdateTime":
                                objprop.ModifiedDate = Convert.ToDateTime(xmlReader.ReadString());
                                break;
                             
                        }
                    }
                    else if (xmlReader.Name == "Property" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.PropertyID != "")
                    {
                        //SAVE IT TO SQL
                        FeatureController.AddRentListings(objprop);
                        objprop = new ListingsInfo();
                    }
                }//END OF WHILE
                //MOVE PROCESSED XML
                MoveProcessedXML(xmlFile, portalID, false, isScheduler);
            }//END OF FOR
        }

    }
}