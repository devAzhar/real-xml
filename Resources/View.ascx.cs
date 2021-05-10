/*
' Copyright (c) 2012  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Globalization;
using System.Web;
using System.Web.Security;
using DotNetNuke.Modules.MaggieDixon.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DotNetNuke.Services.Localization;
using System.Text;
using DotNetNuke.Common;


namespace DotNetNuke.Modules.MaggieDixon
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from MaggieDixonModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : MaggieDixonModuleBase, IActionable
    {
        private string EmailSubject { get; set; }
        

        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            Load += Page_Load;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["view"] == null)
                {
                    Session["view"] = "grid";
                }
                if (!IsPostBack)
                {
                    BindPrice();
                }
                //Response.Write(Globals.NavigateURL(this.TabId) + "<br/>");
                //Response.Write(Request.Url.GetLeftPart(UriPartial.Path) + "<br/>");
              
                FilterXml(false);
                
                if (Session["mmm_Prtidflg"] != null)
                {
                    string strscn = Session["mmm_Prtidflg"].ToString();
                    Session.Remove("mmm_Prtidflg");
                   
                    DisplayDetailView(strscn);
                }
                else if (Request.QueryString["ppid"] != null)
                {
                    string strscn = Request.QueryString["ppid"].ToString ();
                    //Session.Remove("mmm_Prtidflg");
                    
                    DisplayDetailView(strscn);
                
                }

                //if (Session["detail"] != null)
                //{
                //    DisplayDetailView(Session["detail"].ToString());
                //}

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }





        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                {
                    {
                        GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                        EditUrl(), false, SecurityAccessLevel.Edit, true, false
                    }
                };
                return actions;
            }
        }

        #endregion

        private void BindPrice()
        {
            
            
            if (!Settings.Contains("SettingXml")) return;
            if (Settings["SettingXml"].ToString() == "Buy")
            {
                ddlPriceMin.Items.Add(new ListItem("Any", "Any"));
                ddlPriceMin.Items.Add(new ListItem("$100k", "100000"));
                ddlPriceMin.Items.Add(new ListItem("$200k", "200000"));
                ddlPriceMin.Items.Add(new ListItem("$300k", "300000"));
                ddlPriceMin.Items.Add(new ListItem("$500k", "500000"));
                ddlPriceMin.Items.Add(new ListItem("$600k", "600000"));
                ddlPriceMin.Items.Add(new ListItem("$800k", "800000"));
                ddlPriceMin.Items.Add(new ListItem("$1M", "10000000"));
                ddlPriceMin.Items.Add(new ListItem("$1.5M", "15000000"));
                ddlPriceMin.Items.Add(new ListItem("$2M+", "20000000"));

                ddlPriceMax.Items.Add(new ListItem("Any", "Any"));
                ddlPriceMax.Items.Add(new ListItem("$100k", "100000"));
                ddlPriceMax.Items.Add(new ListItem("$200k", "200000"));
                ddlPriceMax.Items.Add(new ListItem("$300k", "300000"));
                ddlPriceMax.Items.Add(new ListItem("$500k", "500000"));
                ddlPriceMax.Items.Add(new ListItem("$600k", "600000"));
                ddlPriceMax.Items.Add(new ListItem("$800k", "800000"));
                ddlPriceMax.Items.Add(new ListItem("$1M", "10000000"));
                ddlPriceMax.Items.Add(new ListItem("$1.5M", "15000000"));
                ddlPriceMax.Items.Add(new ListItem("$2M+", "20000000"));
            }
            else
            {
                ddlPriceMin.Items.Add(new ListItem("Any", "Any"));
                ddlPriceMin.Items.Add(new ListItem("$100", "100"));
                ddlPriceMin.Items.Add(new ListItem("$150", "150"));
                ddlPriceMin.Items.Add(new ListItem("$200", "200"));
                ddlPriceMin.Items.Add(new ListItem("$250", "250"));
                ddlPriceMin.Items.Add(new ListItem("$300", "300"));
                ddlPriceMin.Items.Add(new ListItem("$400", "400"));
                ddlPriceMin.Items.Add(new ListItem("$500", "500"));
                ddlPriceMin.Items.Add(new ListItem("$600", "600"));
                ddlPriceMin.Items.Add(new ListItem("$800", "800"));
                ddlPriceMin.Items.Add(new ListItem("$1k", "1000"));
                ddlPriceMin.Items.Add(new ListItem("$1.5k", "1500"));
                ddlPriceMin.Items.Add(new ListItem("$2.5k+", "2500"));

                ddlPriceMax.Items.Add(new ListItem("Any", "Any"));
                ddlPriceMax.Items.Add(new ListItem("$100", "100"));
                ddlPriceMax.Items.Add(new ListItem("$150", "150"));
                ddlPriceMax.Items.Add(new ListItem("$200", "200"));
                ddlPriceMax.Items.Add(new ListItem("$250", "250"));
                ddlPriceMax.Items.Add(new ListItem("$300", "300"));
                ddlPriceMax.Items.Add(new ListItem("$400", "400"));
                ddlPriceMax.Items.Add(new ListItem("$500", "500"));
                ddlPriceMax.Items.Add(new ListItem("$600", "600"));
                ddlPriceMax.Items.Add(new ListItem("$800", "800"));
                ddlPriceMax.Items.Add(new ListItem("$1k", "1000"));
                ddlPriceMax.Items.Add(new ListItem("$1.5k", "1500"));
                ddlPriceMax.Items.Add(new ListItem("$2.5k+", "2500"));
            }
           
            
            
        }

        private List<ListingsInfo> PropertyList
        {
            get
            {
                var list = (List<ListingsInfo>)(ViewState["PropertyListing"] ??
                    new List<ListingsInfo>());
                ViewState["PropertyListing"] = list;
                return list;
            }
            set
            {
                ViewState["PropertyListing"] = value;
            }
        }

        private void GetListings()
        {
            if (!Settings.Contains("SettingXml")) return;
            PropertyList = Settings["SettingXml"].ToString() == "Rent" ? FeatureController.GetRentListings() : FeatureController.GetBuyListings();
        }

        //List<Propertydetail> ReadXML()
        //{
        //    var property = new List<Propertydetail>();
        //    try
        //    {
        //        //Create an load XML File
        //        var xmlDocument = new XmlDocument();

        //        if (Settings.Contains("SettingXml"))
        //        {
        //            string xmlFilePath;

        //            if (Settings["SettingXml"].ToString() == "Rent")    
        //            {
        //                xmlFilePath = Directory.GetFiles(Server.MapPath("/Portals/" + PortalId + "/XML/Rockend"), "*.xml")[0];


        //                xmlDocument.Load(xmlFilePath);
        //                //Read All XML Nodes
        //                var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
        //                var objprop = new Propertydetail();
        //                while (xmlReader.Read())
        //                {
        //                    if ((xmlReader.NodeType == XmlNodeType.Element))
        //                    {
        //                        switch (xmlReader.Name)
        //                        {
        //                            case "Property":
        //                                objprop.uniqueID = xmlReader.GetAttribute("PropertyID");
        //                                break;
        //                            case "BuildingType":
        //                                objprop.Category = xmlReader.GetAttribute("Type");
        //                                break;
        //                            case "Rent":
        //                                objprop.price = xmlReader.ReadString();
        //                                break;
        //                            case "SalePrice":
        //                                objprop.price = xmlReader.ReadString();
        //                                break;
        //                            case "AdvDescription":
        //                                objprop.description = xmlReader.ReadString();
        //                                break;
        //                            case "StreetNumber":
        //                                objprop.streetNo = xmlReader.ReadString();
        //                                break;
        //                            case "StreetName":
        //                                objprop.streetName = xmlReader.ReadString();
        //                                break;
        //                            case "Suburb":
        //                                objprop.suburb = xmlReader.ReadString();
        //                                break;
        //                            case "Bedrooms":
        //                                objprop.bedrooms = Convert.ToInt32(xmlReader.ReadString());
        //                                break;
        //                            case "Bathrooms":
        //                                objprop.bathrooms = Convert.ToInt32(xmlReader.ReadString());
        //                                break;
        //                            case "AdvHeading":
        //                                objprop.headline = xmlReader.ReadString();
        //                                break;
        //                            case "Image":
        //                                objprop.Images.Add(xmlReader.GetAttribute("FileName"));
        //                                break;
        //                            case "PropertyType":
        //                                objprop.subcategory = xmlReader.GetAttribute("Type");
        //                                break;
        //                            case "Ensuite":
        //                                objprop.ensuites = xmlReader.ReadString();
        //                                break;
        //                            case "Carports":
        //                                objprop.CarParks = xmlReader.ReadString();
        //                                break;
        //                        }

        //                    }
        //                    else if (xmlReader.Name == "Images" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.uniqueID != "")
        //                    {
        //                        objprop.address = objprop.streetNo + " " + objprop.streetName + " " + objprop.suburb;
        //                        property.Add(objprop);
        //                        objprop = new Propertydetail();
        //                    }
        //                }




        //            }
        //            else
        //            {
        //                xmlFilePath = Directory.GetFiles(Server.MapPath("/Portals/" + PortalId + "/XML/RealNZ"), "*.xml")[0];

        //                xmlDocument.Load(xmlFilePath);
        //                //Read All XML Nodes
        //                var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
        //                var objprop = new Propertydetail();
        //                while (xmlReader.Read())
        //                {
        //                    if ((xmlReader.NodeType == XmlNodeType.Element))
        //                    {
        //                        switch (xmlReader.Name)
        //                        {
        //                            case "uniqueID":
        //                                objprop.uniqueID = xmlReader.ReadString();
        //                                break;
        //                            case "residential":
        //                                objprop.Category = "residential";
        //                                objprop.modTime = xmlReader.GetAttribute("modTime");
        //                                objprop.status = xmlReader.GetAttribute("status");
        //                                break;
        //                            case "rural":
        //                                objprop.Category = "rural";
        //                                objprop.modTime = xmlReader.GetAttribute("modTime");
        //                                objprop.status = xmlReader.GetAttribute("status");
        //                                break;
        //                            case "land":
        //                                objprop.Category = "land";
        //                                objprop.modTime = xmlReader.GetAttribute("modTime");
        //                                objprop.status = xmlReader.GetAttribute("status");
        //                                break;
        //                            case "price":
        //                                objprop.price = xmlReader.ReadString();
        //                                break;
        //                            case "description":
        //                                objprop.description = xmlReader.ReadString();
        //                                break;
        //                            case "address":
        //                                objprop.address = xmlReader.ReadString();
        //                                break;
        //                            case "streetNo":
        //                                objprop.streetNo = xmlReader.ReadString();
        //                                break;
        //                            case "streetName":
        //                                objprop.streetName = xmlReader.ReadString();
        //                                break;
        //                            case "suburb":
        //                                objprop.suburb = xmlReader.ReadString();
        //                                break;
        //                            case "bedrooms":
        //                                objprop.bedrooms = Convert.ToInt32(xmlReader.ReadString());
        //                                break;
        //                            case "bathrooms":
        //                                objprop.bathrooms = Convert.ToInt32(xmlReader.ReadString());
        //                                break;
        //                            case "garages":
        //                                objprop.garages = Convert.ToInt32(xmlReader.ReadString());
        //                                break;
        //                            case "headline":
        //                                objprop.headline = xmlReader.ReadString();
        //                                break;
        //                            case "img":
        //                                objprop.Images.Add(xmlReader.GetAttribute("file"));
        //                                if (string.IsNullOrEmpty(objprop.FirstImage))
        //                                    objprop.FirstImage = xmlReader.GetAttribute("file");
        //                                break;
        //                        }

        //                    }
        //                    else if (xmlReader.Name == "images" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.uniqueID != "")
        //                    {
        //                        if (objprop.status == "current")
        //                        property.Add(objprop);
        //                        objprop = new Propertydetail();
        //                    }
        //                }



        //            }



        //        }


        //    }
        //    catch (Exception exc)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, exc);
        //    }
        //    return property;
        //}



        private int FilterXml(bool sort)
        {
            GetListings();
            var allProperties = PropertyList;
            //var allProperties = ReadXML();

            if (ddlCategory.SelectedValue != "0")
            {
                switch (ddlCategory.SelectedValue)
                {
                    case "1":
                        allProperties = allProperties.Where(category => category.Category == "residential").ToList();
                        break;
                    case "2":
                        allProperties = allProperties.Where(category => category.Category == "rural").ToList();
                        break;
                    case "3":
                        allProperties = allProperties.Where(category => category.Category == "land").ToList();
                        break;
                }

            }

            //for filtering Suburbs 
            var allPropertiesAfterSuburbs = new List<ListingsInfo>();
            var count1 = 0;
            if (chkSuburbs.Items[0].Selected)
            {

            }
            else
            {
                var allChecked = chkSuburbs.Items.Cast<ListItem>().Where(i => i.Selected);

                foreach (var li in allChecked)
                {
                    count1++;
                    var li1 = li;

                   // var pd = allProperties.Where(p => li1 != null && p.Suburb == li1.Value);
                    var pd = allProperties.Where(p => li1 != null && p.Suburb.Contains(li1.Value));
                    //allPropertiesAfterSuburbs = pd.ToList();
                    allPropertiesAfterSuburbs.AddRange(pd);
                }
            }

            if (count1 > 0)
            {
                allProperties = allPropertiesAfterSuburbs;
            }
            // End filteting Suburbs


            // Start Filter Price

            if (ddlPriceMin.SelectedValue != "Any" && ddlPriceMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Price >= decimal.Parse(ddlPriceMin.SelectedValue) && p.Price <= decimal.Parse(ddlPriceMax.SelectedValue)).ToList();
            }
            else if (ddlPriceMin.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Price >= decimal.Parse(ddlPriceMin.SelectedValue)).ToList();
            }

            else if (ddlPriceMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Price <= decimal.Parse(ddlPriceMax.SelectedValue)).ToList();
            }

            // End Price


            // Start BedRooms filter

            if (ddlBedRoomsMin.SelectedValue != "Any" && ddlBedroomMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bedrooms >= int.Parse(ddlBedRoomsMin.SelectedValue) && p.Bedrooms <= int.Parse(ddlBedroomMax.SelectedValue)).ToList();
            }
            else if (ddlBedRoomsMin.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bedrooms >= int.Parse(ddlBedRoomsMin.SelectedValue)).ToList();
            }

            else if (ddlBedroomMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bedrooms <= int.Parse(ddlBedroomMax.SelectedValue)).ToList();
            }

            // End bedroom filter


            // Start Bathrrom filter

            if (ddlBathroomMin.SelectedValue != "Any" && ddlBathRoomMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bathrooms >= int.Parse(ddlBathroomMin.SelectedValue) && p.Bathrooms <= int.Parse(ddlBathRoomMax.SelectedValue)).ToList();
            }
            else if (ddlBathroomMin.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bathrooms >= int.Parse(ddlBathroomMin.SelectedValue)).ToList();
            }

            else if (ddlBathRoomMax.SelectedValue != "Any")
            {
                allProperties = allProperties.Where(p => p.Bathrooms <= int.Parse(ddlBathRoomMax.SelectedValue)).ToList();
            }

            // End Bathrrom filter
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                allProperties = allProperties.Where(p => String.Equals(p.PropertyID, txtId.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            // Start keyword filter
            

            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                allProperties = allProperties.Where(p => p.Bathrooms.ToString(CultureInfo.InvariantCulture).ToUpper().Contains(txtsearch.Text.ToUpper()) ||
                    p.Bedrooms.ToString(CultureInfo.InvariantCulture).ToUpper().Contains(txtsearch.Text.ToUpper()) ||
                    p.Category.ToUpper().Contains(txtsearch.Text.ToUpper()) || p.Description.ToUpper().Contains(txtsearch.Text.ToUpper()) ||
                    p.Headline.ToUpper().Contains(txtsearch.Text.ToUpper()) || p.Price.ToString(CultureInfo.InvariantCulture).Contains(txtsearch.Text) ||
                    p.StreetNo.ToUpper().Contains(txtsearch.Text.ToUpper()) || p.StreetName.ToUpper().Contains(txtsearch.Text.ToUpper()) || p.Suburb.ToUpper().Contains(txtsearch.Text.ToUpper()) ||
                    p.PropertyID.ToUpper().Contains(txtsearch.Text.ToUpper())).ToList();
            }
            // End keyword filter
            if (sort)
            {
                switch (ddlSort.SelectedValue)
                {
                    case "1":
                        allProperties = allProperties.OrderByDescending(s => s.ModifiedDate).ToList();
                        break;
                    case "2":
                        allProperties = allProperties.OrderBy(s => s.ModifiedDate).ToList();
                        break;
                    case "3":
                        allProperties = allProperties.OrderByDescending(s => s.Price).ToList();
                        break;
                    case "4":
                        allProperties = allProperties.OrderBy(s => s.Price).ToList();
                        break;
                }
            }
            else
            {
                allProperties = allProperties.OrderByDescending(s => s.ModifiedDate).ToList();
            }

            divListView.Visible = true;
            
            var pds = new PagedDataSource {DataSource = allProperties, AllowPaging = true, PageSize = 9};
            if (HttpContext.Current.Request.UserAgent != null)
            {
                var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
                if (userAgent.Contains("mobi"))
                {
                    dtGridView.RepeatColumns = 1;
                    detailsviewRelated.RepeatColumns = 1;
                    //ListingHolder.Attributes.Add("class", "ListingRigth isMobile");
                    if (userAgent.Contains("ipad") || userAgent.Contains("touch"))
                    {
                        dtGridView.RepeatColumns = 2;
                        detailsviewRelated.RepeatColumns = 3;
                        pds = new PagedDataSource { DataSource = allProperties, AllowPaging = true, PageSize = 10 };
                        ListingHolder.Attributes.Add("class", "ListingRigth");
                    }

                }


            }
            var count = pds.PageCount;
            pds.CurrentPageIndex = CurrentPage;

            if (pds.Count > 0)
            {
                lbtnPrev.Visible = true;
                lbtnNext.Visible = true;
                lbtnFirst.Visible = true;
                lbtnLast.Visible = true;

                lblStatus.Text = @"Page " + Convert.ToString(CurrentPage + 1) + @" of " + Convert.ToString(pds.PageCount);
                lblPage.Text = Convert.ToString(CurrentPage + 1);
            }

            else
            {
                lbtnPrev.Visible = false;
                lbtnNext.Visible = false;
                lbtnFirst.Visible = false;
                lbtnLast.Visible = false;
            }

            lbtnPrev.Enabled = !pds.IsFirstPage;
            lbtnNext.Enabled = !pds.IsLastPage;
            lbtnFirst.Enabled = !pds.IsFirstPage;
            lbtnLast.Enabled = !pds.IsLastPage;

            lblNoRecord.Visible = allProperties.Count == 0;

            if (string.IsNullOrEmpty(Session["view"].ToString()) || Session["view"].ToString() == "list")
            {
                rpt.DataSource = pds;
                rpt.DataBind();
                divGridView.Visible = false;
                divDetailedView.Visible = false;
                return count;
            }
          
            
            divGridView.Visible = true;
            dtGridView.DataSource = pds;
            dtGridView.DataBind();
            divListView.Visible = false;
            divDetailedView.Visible = false;

            return count;
        }


        protected void lbtnPrev_Click(object sender, EventArgs e)
        {

            CurrentPage -= 1;

            FilterXml(false);

        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {

            CurrentPage += 1;

            FilterXml(false);

        }

        protected void lbtnFirst_Click(object sender, EventArgs e)
        {

            CurrentPage = 0;

            FilterXml(false);

        }

        protected void lbtnLast_Click(object sender, EventArgs e)
        {

            CurrentPage = FilterXml(false) - 1;

            FilterXml(false);

        }
        
        protected void FilterXmlUniversId()
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;
            var allProperties = PropertyList;

            // Start Universal id filter

           
            allProperties = allProperties.Where(p => String.Equals(p.PropertyID, txtId.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
           

            lblNoRecord.Visible = allProperties.Count == 0;

            // End Universal id filter

            if (string.IsNullOrEmpty(Session["view"].ToString()) || (string) Session["view"] == "list")
            {
                divListView.Visible = true;
                rpt.DataSource = allProperties;
                rpt.DataBind();
                divGridView.Visible = false;
                divDetailedView.Visible = false;
                
            }
            else
            {
                divGridView.Visible = true;
                dtGridView.DataSource = allProperties;
                dtGridView.DataBind();
                divListView.Visible = false;
                divDetailedView.Visible = false;
            }
        }

        protected void imgbuttonGoBasic_Click1(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            FilterXml(false);
        }

        protected void imgbuttonGoSearchById_Click1(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            FilterXml(false);
            //FilterXmlUniversId();
        }

        protected void btnListView_Click(object sender, ImageClickEventArgs e)
        {
            Session["view"] = "list";
            FilterXml(false);
        }

        protected void btnGridView_Click(object sender, ImageClickEventArgs e)
        {
            Session["view"] = "grid";
            FilterXml(false);
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSort.SelectedValue != "0")
            {
                FilterXml(true);
            }
        }
        //  Constructing  query sting
        public string ConstructQueryStringURL(string target, IEnumerable<KeyValuePair<string, object>> values)
        {
            //A StringBuilder to start building your result
            StringBuilder result = new StringBuilder(target);

            //If there are any parameters
            if (target.Any())
            {
                //Initally append the start of the QueryString
                result.Append("?");

                //Iterate through your pairs and generate the appropriate series of QueryStrings
                foreach (var pair in values)
                {
                    //Appends the value in the following format: {Key}={Value} and prepares the next parameter
                    result.Append(String.Format("{0}={1}&", pair.Key, pair.Value));
                }

                //Trims off the ending ampersand
                return result.ToString().TrimEnd('&');
            }

            //Return the original string
            return result.ToString();
        }

        protected void lnkImageClick_Click(object sender, EventArgs e)
        {
            
            var btnlnk = (LinkButton)sender;
            var ritemlnk = (RepeaterItem)btnlnk.NamingContainer;
            var lblnk = (Label)ritemlnk.FindControl("lblHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemlnk.FindControl("lblHiddenHd");

            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = lblnk.Text;
            

            List<KeyValuePair<string, object>> pair = new List<KeyValuePair<string, object>>();
            pair.Add(new KeyValuePair<string, object>("ppid", lblnk.Text));
            pair.Add(new KeyValuePair<string, object>("PNam", lblhd.Text ));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pair));
            //DisplayDetailView(lblnk.Text);
        }

        protected void btnReadMoreList_Click(object sender, EventArgs e)
        {
            var btnReadlnk = (LinkButton)sender;
            var ritemReadLnk = (RepeaterItem)btnReadlnk.NamingContainer;
            var lb = (Label)ritemReadLnk.FindControl("lblHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemReadLnk.FindControl("lblHiddenHd");

            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = lb.Text;
            
            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>();
            pairs.Add(new KeyValuePair<string, object>("ppid", lb.Text));
            pairs.Add(new KeyValuePair<string, object>("PNam", lblhd.Text));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pairs));
            //            DisplayDetailView(lb.Text);
        }

        protected void lnkImageClickGrid_Click(object sender, EventArgs e)
        {
            var btnGridlnk = (LinkButton)sender;
            var ritemGridlnk = (DataListItem)btnGridlnk.NamingContainer;
            var hdGridPropertyId = (Label)ritemGridlnk.FindControl("lblGridHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemGridlnk.FindControl("lblGridHiddenHd");
            
            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = hdGridPropertyId.Text;

            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>();
            pairs.Add(new KeyValuePair<string, object>("ppid", hdGridPropertyId.Text));
            pairs.Add(new KeyValuePair<string, object>("PNam", lblhd.Text));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pairs));
            //DisplayDetailView(hdGridPropertyId.Value);

            //////////////////////
            //Label lbGridlnk = (Label)ritemGridlnk.FindControl("lblGridHiddenId");
            //DisplayDetailView(lbGridlnk.Text);
        }

        protected void lnkImageClickGridRead_Click(object sender, EventArgs e)
        {
            var btnGridReadlnk = (LinkButton)sender;
            var ritemGridReaqdlnk = (DataListItem)btnGridReadlnk.NamingContainer;
            var hdGridReadPropertyId = (Label)ritemGridReaqdlnk.FindControl("lblGridHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemGridReaqdlnk.FindControl("lblGridHiddenHd");

            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = hdGridReadPropertyId.Text;
            
            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>();
            pairs.Add(new KeyValuePair<string, object>("ppid", hdGridReadPropertyId.Text));
            pairs.Add(new KeyValuePair<string, object>("PNam", lblhd.Text));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pairs));
           // DisplayDetailView(hdGridReadPropertyId.Value);
            //var lbGridReadlnk = (Label)ritemGridReaqdlnk.FindControl("lblGridHiddenId");
            //DisplayDetailView(lbGridReadlnk.Text);
        }

        protected void lnkImageClickSimilar_Click(object sender, EventArgs e)
        {
            var btnSimilarlnk = (LinkButton)sender;
            var ritemSimilarlnk = (DataListItem)btnSimilarlnk.NamingContainer;
            var lbSimilarlnk = (Label)ritemSimilarlnk.FindControl("lblRelatedHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemSimilarlnk.FindControl("lblRelatedHiddenHd");

            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = lbSimilarlnk.Text;
            
            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>();
            pairs.Add(new KeyValuePair<string, object>("ppid", lbSimilarlnk.Text));
            pairs.Add(new KeyValuePair<string, object>("PNam", lblhd.Text));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pairs));
            //DisplayDetailView(lbSimilarlnk.Text);
        }

        protected void lnkImageClickSimilarRead_Click(object sender, EventArgs e)
        {
            var btnSimilarReadlnk = (LinkButton)sender;
            var ritemSimilarReadlnk = (DataListItem)btnSimilarReadlnk.NamingContainer;
            var lbSimilarReadlnk = (Label)ritemSimilarReadlnk.FindControl("lblRelatedHiddenId");
            // BY MMM for qury string
            var lblhd = (Label)ritemSimilarReadlnk.FindControl("lblRelatedHiddenHd");

            string currentUrl = Globals.NavigateURL(this.TabId);
            Session["mmm_Prtidflg"] = lbSimilarReadlnk.Text;
            
            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>();
            pairs.Add(new KeyValuePair<string, object>("ppid", lbSimilarReadlnk.Text));
            pairs.Add(new KeyValuePair<string, object>("PNam", lblhd.Text));
            Response.Redirect(ConstructQueryStringURL(currentUrl, pairs));
            //DisplayDetailView(lbSimilarReadlnk.Text);
        }

      

       

        private int CurrentPage
        {
            get
            {
                var obj = ViewState["_CurrentPage"];
                if (obj == null)
                {
                    return 0;
                }
                return (int)obj;
            }
            set
            {
                ViewState["_CurrentPage"] = value;
            }
        }

        private string DetailStatus { get; set; }

        private void DisplayDetailView(string propertyID)
        {
            if (HttpContext.Current.Request.UserAgent != null)
            {
                var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
                if (userAgent.Contains("mobi"))
                {
                    //dtGridView.RepeatColumns = 1;
                    //detailsviewRelated.RepeatColumns = 1;
                    ListingHolder.Attributes.Add("class", "ListingRigth isMobile");
                    SearchHolder.Visible = false;
                    if (userAgent.Contains("ipad") || userAgent.Contains("touch"))
                    {
                        ListingHolder.Attributes.Add("class", "ListingRigth_ipad");
                    }

                }


            }

            divGridView.Visible = false;
            divListView.Visible = false;
            divDetailedView.Visible = true;

            var propertyDetail = GetPropertyDetail(propertyID);
            if (propertyDetail == null) return;
            lblHeading.Text = propertyDetail.Headline;
            lblAddress.Text = propertyDetail.StreetNo + @" " + propertyDetail.StreetName + @", " + propertyDetail.Suburb;
            lblPrice.Text = String.Format("{0:#,#}", propertyDetail.Price);
            lblBathNoImg.Text = propertyDetail.Bathrooms.ToString(CultureInfo.InvariantCulture);
            lblBesNoImage.Text = propertyDetail.Bedrooms.ToString(CultureInfo.InvariantCulture);
            lblCarNoImg.Text = propertyDetail.Garages.ToString(CultureInfo.InvariantCulture);
            lblId.Text = @"MDWHG-" + propertyDetail.PropertyID;
            EmailSubject = lblId.Text;
            string str = propertyDetail.Description;
           // str = str.Replace("*", "<br>* &nbsp;&nbsp;");
            if (str.IndexOf("*") >= 0)
            {
                str = str.Insert(str.IndexOf("*"), "<ul>");

                str = str.Replace("*", "</li><li>");
                str = str + "</li></ul>";
                
            }
            lblAboutPropery.Text = str;

            

            if (propertyDetail.Features != "")
            {
                var features = propertyDetail.Features.Split(',').ToList();
                rptFeatures.DataSource = features;
                rptFeatures.DataBind();
            }

            else
            {
                lblFeatureTitle.Visible = false;

            }
           
            if (!Settings.Contains("SettingXml")) return;
            if (Settings["SettingXml"].ToString() == "Buy")
            {
                if (propertyDetail.OtherFeatures == "")
                    lblOtherFeaturesTitle.Visible = false;
                else
                {
                    lblOtherFeaturesTitle.Visible = true;
                    lblOtherFeatures.Text = propertyDetail.OtherFeatures;
                }


            }
            else
            {
                lblOtherFeaturesTitle.Visible = false;
            }

            if (!Settings.Contains("SettingXml")) return;
            if (Settings["SettingXml"].ToString() == "Rent")
            {
                if (propertyDetail.DateAvailable == "")
                    lblDateAvailableTitle.Visible = false;
                else
                {
                    lblDateAvailableTitle.Visible = true;
                    lblDateAvailable.Text = propertyDetail.DateAvailable;
                }


            }
            else
            {
                lblDateAvailableTitle.Visible = false;
            }


            lblCategory.Text = propertyDetail.Category;
            lblSubCategory.Text = propertyDetail.SubCategory;
            lblNoOfBedRooms.Text = propertyDetail.Bedrooms.ToString(CultureInfo.InvariantCulture);
            lblNoOfBathrooms.Text = propertyDetail.Bathrooms.ToString(CultureInfo.InvariantCulture);
            lblNoOfEnsuites.Text = propertyDetail.Ensuites.ToString(CultureInfo.InvariantCulture);
            if (lblNoOfEnsuites.Text == "0") { lblNoOfEnsuites.Text = "No"; } else { lblNoOfEnsuites.Text = "Yes"; }
            lblNoOfCarParks.Text = propertyDetail.Garages.ToString(CultureInfo.InvariantCulture);
            if (!Settings.Contains("SettingXml")) return;
            if (Settings["SettingXml"].ToString() == "Buy")
            {
                trFloorArea.Visible = true;
                trLandArea.Visible = true;
                if (propertyDetail.FloorArea == "")
                    trFloorArea.Visible = false;
                else
                {
                    lblFloorArea.Text =  String.Format("{0:F0}", Convert.ToDecimal(propertyDetail.FloorArea));
                }
                if (propertyDetail.LandArea == "")
                    trLandArea.Visible = false;
                else
                {
                    lblLandArea.Text =  String.Format("{0:F0}", Convert.ToDecimal(propertyDetail.LandArea));
                }
                
                
            }
            else
            {
                trFloorArea.Visible = false;
                trLandArea.Visible = false;
            }
          
          
            hdnAddress.Value = lblAddress.Text;
            DetailStatus = propertyDetail.Status;
            var image = propertyDetail.Images.Split(',');
            // By MMM for facebook header
            FbHeader(lblHeading.Text + " ," + lblAddress.Text + " " + lblPrice.Text, lblAboutPropery.Text, image.GetValue(0).ToString ());
            rptImages.DataSource = image.ToList();
            rptImages.DataBind();

            //var relatedProperties = FilterXmlRelated(propertyDetail.Category, propertyDetail.SubCategory);
            decimal maxPrice;
            decimal minPrice;
            if (!Settings.Contains("SettingXml")) return;
            if (Settings["SettingXml"].ToString() == "Buy")
            {
                maxPrice = propertyDetail.Price + 200000;
                minPrice = propertyDetail.Price - 200000;
                if (minPrice < 0)
                    minPrice = 0;
            }
            else
            {
                maxPrice = propertyDetail.Price + 1000;
                minPrice = propertyDetail.Price - 1000;
                if (minPrice < 0)
                    minPrice = 0;
            }
            //GET Above 3 properties & order by acs
            var relatedProperties = PropertyList.Where(p => p.Price >= propertyDetail.Price && p.Price <= maxPrice).ToList();
            relatedProperties = relatedProperties.Where(p => p.PropertyID != propertyDetail.PropertyID).ToList();
            relatedProperties = relatedProperties.OrderBy(s => s.Price).ToList();
            //Get Below 3 properties & order by asc
            var relatedPropertiesBelow = PropertyList.Where(p => p.Price >= minPrice && p.Price <= propertyDetail.Price).ToList();
            relatedPropertiesBelow = relatedPropertiesBelow.Where(p => p.PropertyID != propertyDetail.PropertyID).ToList();
            relatedPropertiesBelow = relatedPropertiesBelow.OrderByDescending(s => s.Price).ToList();
            if (relatedProperties.Count < 3)
            {
                var combinedProperties = relatedProperties.Concat(relatedPropertiesBelow).ToList();
                combinedProperties = combinedProperties.OrderByDescending(s => s.Price).ToList();
                combinedProperties = combinedProperties.Count > 3 ? combinedProperties.GetRange(0, 3) : combinedProperties.ToList();
              
                detailsviewRelated.DataSource = combinedProperties.OrderBy(s => s.Price).ToList();
                detailsviewRelated.DataBind();
            }
            else
            {
                
                detailsviewRelated.DataSource = relatedProperties.Count > 3 ? relatedProperties.GetRange(0, 3) : relatedProperties.ToList();
                detailsviewRelated.DataBind();
            }
           
           
            //var relatedProperties = PropertyList.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            //relatedProperties = relatedProperties.Where(p => p.PropertyID != propertyDetail.PropertyID).ToList();
            //relatedProperties = relatedProperties.OrderByDescending(s => s.Price).ToList();
            //detailsviewRelated.DataSource = relatedProperties.Count >= 3 ? relatedProperties.GetRange(0,3) : relatedProperties.ToList();
           
           
        }
        // By MMM for facebook header
        private void FbHeader(string lbl,string desc,string img)
        {
            System.Web.UI.HtmlControls.HtmlMeta tag = new System.Web.UI.HtmlControls.HtmlMeta(), tag1 = new System.Web.UI.HtmlControls.HtmlMeta();
            System.Web.UI.HtmlControls.HtmlMeta tag2 = new System.Web.UI.HtmlControls.HtmlMeta(), tag3 = new System.Web.UI.HtmlControls.HtmlMeta();
            System.Web.UI.HtmlControls.HtmlMeta tag4 = new System.Web.UI.HtmlControls.HtmlMeta(), tag5 = new System.Web.UI.HtmlControls.HtmlMeta();
            tag.Name = "og:title"; tag.Content = lbl; Page.Header.Controls.Add(tag);
            tag1.Name = "og:type"; tag1.Content = " Website"; Page.Header.Controls.Add(tag1);
            tag2.Name = "og:url"; tag2.Content = HttpContext.Current.Request.Url.AbsoluteUri; Page.Header.Controls.Add(tag2);
            tag3.Name = "og:image"; tag3.Content = "http://www.maggiedixon.co.nz"+  DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) + img;
                //"http://www.maggiedixon.co.nz"+ PortalSettings.HomeDirectory + img ;
            Page.Header.Controls.Add(tag3);
           // DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent"))
            tag4.Name = "og:site_name"; tag4.Content = "MaggiDixion Property Website"; Page.Header.Controls.Add(tag4);
            tag5.Name = "og:description"; tag5.Content = desc; Page.Header.Controls.Add(tag5);
        }
        private ListingsInfo GetPropertyDetail(string propertyID)
        {
           return PropertyList.FirstOrDefault(p => p.PropertyID == propertyID);
        }

        //public Propertydetail GetPropertyDetails(string uid)
        //{
        //    var property = new List<Propertydetail>();
        //    var xmlDocument = new XmlDocument();
        //    if (Settings.Contains("SettingXml"))
        //    {
        //        string xmlFilePath;

        //        if (Settings["SettingXml"].ToString() == "Rent")
        //        {
        //            xmlFilePath = Directory.GetFiles(Server.MapPath("/Portals/" + PortalId + "/XML/Rockend"), "*.xml")[0];


        //            xmlDocument.Load(xmlFilePath);
        //            //Read All XML Nodes
        //            var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
        //            var objprop = new Propertydetail();
        //            while (xmlReader.Read())
        //            {
        //                if ((xmlReader.NodeType == XmlNodeType.Element))
        //                {
        //                    switch (xmlReader.Name)
        //                    {
        //                        case "Property":
        //                            objprop.uniqueID = xmlReader.GetAttribute("PropertyID");
        //                            break;
        //                        case "BuildingType":
        //                            objprop.Category = xmlReader.GetAttribute("Type");
        //                            break;
        //                        case "Rent":
        //                            objprop.price = xmlReader.ReadString();
        //                            break;
        //                        case "SalePrice":
        //                            objprop.price = xmlReader.ReadString();
        //                            break;
        //                        case "AdvDescription":
        //                            objprop.description = xmlReader.ReadString();
        //                            break;
        //                        case "StreetNumber":
        //                            objprop.streetNo = xmlReader.ReadString();
        //                            break;
        //                        case "StreetName":
        //                            objprop.streetName = xmlReader.ReadString();
        //                            break;
        //                        case "Suburb":
        //                            objprop.suburb = xmlReader.ReadString();
        //                            break;
        //                        case "Bedrooms":
        //                            objprop.bedrooms = Convert.ToInt32(xmlReader.ReadString());
        //                            break;
        //                        case "Bathrooms":
        //                            objprop.bathrooms = Convert.ToInt32(xmlReader.ReadString());
        //                            break;
        //                        case "AdvHeading":
        //                            objprop.headline = xmlReader.ReadString();
        //                            break;
        //                        case "Image":
        //                            objprop.Images.Add(xmlReader.GetAttribute("FileName"));
        //                            break;
        //                        case "PropertyType":
        //                            objprop.subcategory = xmlReader.GetAttribute("Type");
        //                            break;
        //                        case "Ensuite":
        //                            objprop.ensuites = xmlReader.ReadString();
        //                            break;
        //                        case "Carports":
        //                            objprop.CarParks = xmlReader.ReadString();
        //                            break;
        //                    }

        //                }
        //                else if (xmlReader.Name == "Images" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.uniqueID != "")
        //                {
        //                    property.Add(objprop);
        //                    objprop = new Propertydetail();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            xmlFilePath = Directory.GetFiles(Server.MapPath("/Portals/" + PortalId + "/XML/RealNZ"), "*.xml")[0];

        //            xmlDocument.Load(xmlFilePath);
                  
        //            //Read All XML Nodes
        //            var xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
        //            var objprop = new Propertydetail();
        //            while (xmlReader.Read())
        //            {
        //                if ((xmlReader.NodeType == XmlNodeType.Element))
        //                {
        //                    switch (xmlReader.Name)
        //                    {
        //                        case "uniqueID":
        //                            objprop.uniqueID = xmlReader.ReadString();
        //                            break;
        //                        case "residential":
        //                            objprop.Category = "residential";
        //                            objprop.modTime = xmlReader.GetAttribute("modTime");
        //                            objprop.status = xmlReader.GetAttribute("status");
        //                            break;
        //                        case "rural":
        //                            objprop.Category = "rural";
        //                            objprop.modTime = xmlReader.GetAttribute("modTime");
        //                            objprop.status = xmlReader.GetAttribute("status");
        //                            break;
        //                        case "land":
        //                            objprop.Category = "land";
        //                            objprop.modTime = xmlReader.GetAttribute("modTime");
        //                            objprop.status = xmlReader.GetAttribute("status");
        //                            break;
        //                        case "price":
        //                            objprop.price = xmlReader.ReadString();
        //                            break;
        //                        case "description":
        //                            objprop.description = xmlReader.ReadString();
        //                            break;
        //                        case "address":
        //                            objprop.address = xmlReader.ReadString();
        //                            break;
        //                        case "streetNo":
        //                            objprop.streetNo = xmlReader.ReadString();
        //                            break;
        //                        case "streetName":
        //                            objprop.streetName = xmlReader.ReadString();
        //                            break;
        //                        case "suburb":
        //                            objprop.suburb = xmlReader.ReadString();
        //                            break;
        //                        case "bedrooms":
        //                            objprop.bedrooms = Convert.ToInt32(xmlReader.ReadString());
        //                            break;
        //                        case "bathrooms":
        //                            objprop.bathrooms = Convert.ToInt32(xmlReader.ReadString());
        //                            break;
        //                        case "garages":
        //                            objprop.garages = Convert.ToInt32(xmlReader.ReadString());
        //                            break;
        //                        case "headline":
        //                            objprop.headline = xmlReader.ReadString();
        //                            break;
        //                       case "img":
        //                            objprop.Images.Add(xmlReader.GetAttribute("file"));
        //                            break;
        //                        case "category":
        //                            objprop.subcategory = xmlReader.GetAttribute("name");
        //                            break;
        //                        case "ensuite":
        //                            objprop.ensuites = xmlReader.ReadString();
        //                            break;
        //                        case "carports":
        //                            objprop.CarParks = xmlReader.ReadString();
        //                            break;
        //                    }

        //                }
        //                else if (xmlReader.Name == "images" && xmlReader.NodeType == XmlNodeType.EndElement && objprop.uniqueID != "")
        //                {
        //                    if(objprop.status == "current")
        //                    property.Add(objprop);
        //                    objprop = new Propertydetail();
        //                }

        //            }



        //        }
        //    }

        //    var detail = property.FirstOrDefault(p => p.uniqueID == uid);

        //    return detail;
        //}


        //List<ListingsInfo> FilterXmlRelated(string category, string subcategory)
        //{
        //    var allProperties = PropertyList;

        //    // Start keyword filter
        //    allProperties = allProperties.Where(p => p.Category == category || p.SubCategory == subcategory).ToList();
        //    // End keyword filter
        //    return allProperties;

        //}

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtEmail.Text)&& string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtEnquiry.Text))
                return;
            var body = "From: " + txtName.Text + "\n";
            body += "Email: " + txtEmail.Text + "\n";
            body += "Phone: " + txtPhone.Text + "\n";
            body += "Enquiry: " + txtEnquiry.Text + "\n";

            var email = Settings["SettingXml"].ToString() == "Buy" ? Settings["SettingBuyContact"].ToString() : Settings["SettingRentContact"].ToString();

          //  SendMail(txtName.Text, email, "", "", EmailSubject, body);
            try
            {
                 DotNetNuke.Services.Mail.Mail.SendEmail(txtEmail.Text, email, EmailSubject, body);
                  lbloutmsg.Text = " Thank you for your query. We will contact you soon.Thank you";
                  lbloutmsg.Visible = true;
            }
            catch (Exception ex)
            {
                lbloutmsg.Text = " Sorry! There is some error please try later";
                lbloutmsg.Visible = true;
            }
            
        }


        protected void SendMail(string strFrom, string strTo, string strCC, string strBCC, string strSubject, string strBody)
        {


            var hostSettings = Entities.Controllers.HostController.Instance.GetSettingsDictionary();

            /*** Set the SMTP server details ***/
            var strSMTP = hostSettings["SMTPServer"];

            /*** This is the actual built in function from DNN Framework. ***/
            Services.Mail.Mail.SendMail(strFrom, strTo, strCC, strBCC, Services.Mail.MailPriority.Normal, strSubject, Services.Mail.MailFormat.Html, System.Text.Encoding.UTF8, strBody, "",
            strSMTP, hostSettings["SMTPAuthentication"], hostSettings["SMTPUsername"], hostSettings["SMTPPassword"]);
        }


        protected void chkSuburbs_SelectedIndexChanged(object sender, EventArgs e)
        {

            var chk = (CheckBox)sender;
            if (chk.Text != @"Select All") return;
            if (chk.Checked)
            {
                foreach (ListItem item in chkSuburbs.Items)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (ListItem item in chkSuburbs.Items)
                {
                    item.Selected = false;
                }
            }
        }

        protected void lnkbtnBuyClick_Click(object sender, EventArgs e)
        {
            if (Settings.Contains("SettingBuyLink"))
            {
                Response.Redirect("~/" + Settings["SettingBuyLink"]);
            }
        }

        protected void lnkbtnRent_Click(object sender, EventArgs e)
        {
            if (Settings.Contains("SettingRentLink"))
            {
                Response.Redirect("~/" + Settings["SettingRentLink"]);
            }
        }

       
        private int _indexFeaturedID = 1;
        private int _indexSoldID = 1;
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var item = e.Item.DataItem as ListingsInfo;

            if (item != null && item.Status == "current")
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop";
            }

            else
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop";

            }
            
           
            //if (item != null && item.Status == "current")
            //{
            //    if (_indexFeaturedID > 6)
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop hide";
            //    else
            //    {
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop";
            //    }
            //    _indexFeaturedID += 1;
            //}
             
            //else
            //{
            //    if (_indexSoldID > 6)
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop hide";
            //    else
            //    {
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop";
            //    }
            //   _indexSoldID += 1;
                
            //}
        }
        private int _dtGridViewFeaturedID = 1;
        private int _dtGridViewSoldID = 1;
        protected void dtGridView_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var item = e.Item.DataItem as ListingsInfo;

            if (item != null && item.Status == "current")
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop";
            }

            else
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop";

            }
            var hdfGridProperyID = (HiddenField)e.Item.FindControl("hdfGridProperyID");
            if (item != null) hdfGridProperyID.Value = item.PropertyID;

            //if (item != null && item.Status == "current")
            //{
            //    if (_dtGridViewFeaturedID > 6)
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop hide";
            //    else
            //    {
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop";
            //    }
            //    _dtGridViewFeaturedID += 1;
            //}

            //else
            //{
            //    if (_dtGridViewSoldID > 6)
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop hide";
            //    else
            //    {
            //        ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop";
            //    }
            //    _dtGridViewSoldID += 1;

            //}
        }

        protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;


            if (DetailStatus == "current")
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_featured_prop";
            }

            else
            {
                ((HtmlGenericControl)(e.Item.FindControl("divTagFeatured"))).Attributes["class"] = "tag_sold_prop";

            }
        }


        protected void btnBackBottom_Click(object sender, EventArgs e)
        {

            divGridView.Visible = true;
            divListView.Visible = false;
            divDetailedView.Visible = false;
            SearchHolder.Visible = true;
        }

        protected void btnBackTop_Click(object sender, EventArgs e)
        {

            divGridView.Visible = true;
            divListView.Visible = false;
            divDetailedView.Visible = false;
            SearchHolder.Visible = true;
        }
    }

    

}
