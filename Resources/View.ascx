<%@ Control Language="C#" Inherits="DotNetNuke.Modules.MaggieDixon.View" AutoEventWireup="false"
    CodeBehind="View.ascx.cs" %>
<%@ Import Namespace="System.Globalization" %>
<script type="text/javascript" src="<%= ModulePath %>/jquery.timers-1.2.js"></script>
<script type="text/javascript" src="<%= ModulePath %>/jquery.easing.1.3.js"></script>

 <link type="text/css" rel="stylesheet" href="<%= ModulePath %>/gv-style.css" />
<script type="text/javascript" src="<%= ModulePath %>/jquery.galleryview-2.1.1-pack.js"></script>


 <link rel="stylesheet" href="<%= ModulePath %>/prettyPhoto.css" type="text/css" media="screen" title="prettyPhoto main stylesheet" charset="utf-8" />
<script src="<%= ModulePath %>/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript" src="<%= ModulePath %>/detectmobilebrowser.js"></script>




<script type="text/javascript">
    //
    function copyHiddenValues() {
        $("[data-copy-val-src]").each(function (index) {
            $o = $(this);
            srcClass = $o.data("copy-val-src");

            if (srcClass) {
                $src = $("." + srcClass);
                $o.val($src.html());
            }
        });
    }

    function copyFieldValues() {
        $("[data-copy-src]").each(function (index) {
            $o = $(this);
            srcClass = $o.data("copy-src");

            if (srcClass) {
                $src = $("." + srcClass);
                $o.html($src.html());
            }
        });
    }

    $(document).ready(function () {
        $('.myCheckBoxList :checkbox').eq(0).change(function () {
            var toggle = this.checked;
            $('.myCheckBoxList :checkbox').attr("checked", toggle);
        });

        copyFieldValues();
        copyHiddenValues();
    });
</script>

<script type="text/javascript">


    $(document).ready(function () {
        if (jQuery.browser.mobile) {
            $('#myGallery').galleryView({
                panel_width: 225,
                panel_height: 165,
                frame_width: 75,
                frame_height: 75,
                fade_panels: false,
                nav_theme: 'itsonline'

            });
        }
        else {
            var ua = navigator.userAgent.toLowerCase();
            var isTablet = ua.indexOf("ipad") > -1;

            if (isTablet) {
                $('#myGallery').galleryView({
                    panel_width: 400,
                    panel_height: 300,
                    frame_width: 75,
                    frame_height: 75,
                    fade_panels: false,
                    nav_theme: 'itsonline'

                });
            }
            else {
                $('#myGallery').galleryView({
                    panel_width: 464,
                    panel_height: 364,
                    frame_width: 75,
                    frame_height: 75,
                    fade_panels: false,
                    nav_theme: 'itsonline'

                });
            }
        }

    });
</script>
 <script type="text/javascript">
     $(document).ready(function () {
         if (jQuery.browser.mobile != true) {
             $("#myGallery a[rel^='prettyPhoto']").prettyPhoto({
                 animation_speed: 'normal'
				  , theme: 'facebook'
				  , slideshow: 3000
				  , autoplay_slideshow: false
				  , social_tools: ''
				  , default_width: 0
				  , default_height: 0
             });
         }

     });
  </script>


<div class="ListingMainHolder" style="width: 100%">

    <div id="SearchHolder" runat="server" class="ListingLeft">
        <div id="property_search_md">
            <p>
                <asp:LinkButton runat="server" ID="lnkbtnBuyClick" CssClass="btnbuy" Style="padding: 9px"
                    Text="BUY" OnClick="lnkbtnBuyClick_Click"></asp:LinkButton>
                &nbsp;
                <asp:LinkButton runat="server" ID="lnkbtnRent" CssClass="btnbuy" Text="RENT" Style="padding: 9px"
                    OnClick="lnkbtnRent_Click"></asp:LinkButton>
            </p>
            <p>
                <span style="color: #616c91"><b>Type of search</b> </span>
                <br>
            </p>
            <div class="select_style">
                <asp:DropDownList runat="server" ID="ddlCategory">
                    <asp:ListItem Text="All categories" Value=""></asp:ListItem>
                    <asp:ListItem Text="Residential" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Rural" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Commericial" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <p>
            </p>
            <p>
                <span style="color: #616c91"><b>Suburbs</b> </span>
                <br />
            </p>
            <div id="property_search_suburbs_box">
                <asp:CheckBoxList runat="server" ID="chkSuburbs" class="myCheckBoxList">
                    <asp:ListItem Text=" Select All" Value="check all"></asp:ListItem>
                    <asp:ListItem Text=" Bream Bay" Value="Bream Bay"></asp:ListItem>
                    <asp:ListItem Text=" Glenbervie" Value="Glenbervie"></asp:ListItem>
                    <asp:ListItem Text=" Hikurangi" Value="Hikurangi"></asp:ListItem>
                    <asp:ListItem Text=" Horahora" Value="Horahora"></asp:ListItem>
                    <asp:ListItem Text=" Kamo" Value="Kamo"></asp:ListItem>
                    <asp:ListItem Text=" Kauri" Value="Kauri"></asp:ListItem>
                    <asp:ListItem Text=" Kensington" Value="Kensington"></asp:ListItem>
                    <asp:ListItem Text=" Langs Beach" Value="Langs Beach"></asp:ListItem>
                    <asp:ListItem Text=" Mairtown" Value="Mairtown"></asp:ListItem>
                    <asp:ListItem Text=" Matapouri" Value="Matapouri"></asp:ListItem>
                    <asp:ListItem Text=" Maunu" Value="Maunu"></asp:ListItem>
                    <asp:ListItem Text=" McLeod Bay" Value="McLeod Bay"></asp:ListItem>
                    <asp:ListItem Text=" Morningside" Value="Morningside"></asp:ListItem>
                    <asp:ListItem Text=" Ngunguru" Value="Ngunguru"></asp:ListItem>
                    <asp:ListItem Text=" Oakleigh" Value="Oakleigh"></asp:ListItem>
                    <asp:ListItem Text=" Oakura Coast" Value="Oakura Coast"></asp:ListItem>
                    <asp:ListItem Text=" One Tree Point" Value="One Tree Point"></asp:ListItem>
                    <asp:ListItem Text=" Onerahi" Value="Onerahi"></asp:ListItem>
                    <asp:ListItem Text=" Otaika" Value="Otaika"></asp:ListItem>
                    <asp:ListItem Text=" Otangarei" Value="Otangarei"></asp:ListItem>
                    <asp:ListItem Text=" Pakotai" Value="Pakotai"></asp:ListItem>
                    <asp:ListItem Text=" Parahaki" Value="Parahaki"></asp:ListItem>
                    <asp:ListItem Text=" Parua Bay" Value="Parua Bay"></asp:ListItem>
                    <asp:ListItem Text=" Pataua" Value="Pataua"></asp:ListItem>
                    <asp:ListItem Text=" Pataua North" Value="Pataua North"></asp:ListItem>
                    <asp:ListItem Text=" Pipiwai" Value="Pipiwai"></asp:ListItem>
                    <asp:ListItem Text=" Port Whangarei" Value="Port Whangarei"></asp:ListItem>
                    <asp:ListItem Text=" Portland" Value="Portland"></asp:ListItem>
                    <asp:ListItem Text=" Raumanga" Value="Raumanga"></asp:ListItem>
                    <asp:ListItem Text=" Regent" Value="Regent"></asp:ListItem>
                    <asp:ListItem Text=" Riverside" Value="Riverside"></asp:ListItem>
                    <asp:ListItem Text=" Ruakaka" Value="Ruakaka"></asp:ListItem>
                    <asp:ListItem Text=" Ruatangata" Value="Ruatangata"></asp:ListItem>
                    <asp:ListItem Text=" Sherwood" Value="Sherwood"></asp:ListItem>
                    <asp:ListItem Text=" Springfield" Value="Springfield"></asp:ListItem>
                    <asp:ListItem Text=" Springs Flat" Value="Springs Flat"></asp:ListItem>
                    <asp:ListItem Text=" Tamaterau" Value="Tamaterau"></asp:ListItem>
                    <asp:ListItem Text=" Three Mile Bush" Value="Three Mile Bush"></asp:ListItem>
                    <asp:ListItem Text=" Tikipunga" Value="Tikipunga"></asp:ListItem>
                    <asp:ListItem Text=" Toetoe" Value="Toetoe"></asp:ListItem>
                    <asp:ListItem Text=" Tutukaka Coast" Value="Tutukaka Coast"></asp:ListItem>
                    <asp:ListItem Text=" Vinetown" Value="Vinetown"></asp:ListItem>
                    <asp:ListItem Text=" Waiotira" Value="Waiotira"></asp:ListItem>
                    <asp:ListItem Text=" Waiotu" Value="Waiotu"></asp:ListItem>
                    <asp:ListItem Text=" Waipu" Value="Waipu"></asp:ListItem>   
                    <asp:ListItem Text=" Waipu Cove" Value="Waipu Cove"></asp:ListItem>
                    <asp:ListItem Text=" Whananaki" Value="Whananaki"></asp:ListItem>
                    <asp:ListItem Text=" Whangarei Area" Value="Whangarei Area"></asp:ListItem>
                    <asp:ListItem Text=" Whangarei Central" Value="Whangarei Central"></asp:ListItem>
                    <asp:ListItem Text=" Whangarei City Surrounds" Value="Whangarei City Surrounds"></asp:ListItem>
                    <asp:ListItem Text=" Whangarei Heads" Value="Whangarei Heads"></asp:ListItem>
                    <asp:ListItem Text=" Whangarei Surrounds" Value="Whangarei Surrounds"></asp:ListItem>
                    <asp:ListItem Text=" Whareora" Value="Whareora"></asp:ListItem> 
                    <asp:ListItem Text=" Whau Valley" Value="Whau Valley"></asp:ListItem>
                    <asp:ListItem Text=" Woodhill - Whangarei" Value="Woodhill - Whangarei"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <p>
            </p>
                   
            <div class="pricerange">
                    <p>
                    <span style="color: #616c91"><b>Price</b> </span>
                    <br />
                </p>
                <div class="select_style2 left">
                    <asp:DropDownList runat="server" ID="ddlPriceMin" CssClass="property_search_range_dropdown">
                                        
                    </asp:DropDownList>
                </div>
                <span> to </span>
                <div class="select_style2 right">
                    <asp:DropDownList runat="server" ID="ddlPriceMax" CssClass="property_search_range_dropdown">
                                        
                    </asp:DropDownList>
                </div>
				
            </div>
                    
                    
            <div class="bedroomrange">
                <p>
                    <span style="color: #616c91"><b>Bedrooms</b></span>
                </p>
                <div class="select_style2 left">
                    <asp:DropDownList runat="server" ID="ddlBedRoomsMin" CssClass="property_search_range_dropdown">
                        <asp:ListItem Text="Any" Value="Any"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <span> to </span>
                <div class="select_style2 right">
                    <asp:DropDownList runat="server" ID="ddlBedroomMax" CssClass="property_search_range_dropdown">
                        <asp:ListItem Text="Any" Value="Any"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="bathroomrange">
                <p>
                <span style="color: #616c91"><b>Bathrooms</b></span>
                </p>
                <div class="select_style2 left">
                    <asp:DropDownList runat="server" ID="ddlBathroomMin" CssClass="property_search_range_dropdown">
                        <asp:ListItem Text="Any" Value="Any"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <span> to </span>
                <div class="select_style2 right">
                    <asp:DropDownList runat="server" ID="ddlBathRoomMax" CssClass="property_search_range_dropdown">
                        <asp:ListItem Text="Any" Value="Any"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                   
            <div class="keywordsholder">
                    <p>
                    <span style="color: #616c91"><b>Keywords</b></span><br />
                </p>
                <asp:TextBox runat="server" ID="txtsearch" CssClass="property_search_text"></asp:TextBox>
                    <asp:ImageButton runat="server" border="0" ID="imgbuttonGoBasic" ImageUrl="images/button_search_go.png"
                                OnClick="imgbuttonGoBasic_Click1" />
            </div>
                   
            <div class="searchPropertyID">
                <p>
                    <span style="color: #616c91"><b>Search or Property ID</b></span><br />
                </p>
                <asp:TextBox runat="server" ID="txtId" CssClass="property_search_text" Style="width: 137px;"></asp:TextBox>
                <asp:ImageButton runat="server" border="0" ID="imgbuttonGoSearchById" ImageUrl="images/button_search_go.png"
                                OnClick="imgbuttonGoSearchById_Click1" />
            </div>
    </div>
    </div>
     <div id="ListingHolder" runat="server" class="ListingRigth">
        <div class="PaginationHolder">
            <div class="viewby hidden-phone">
                <div style="float: left; margin-right: 5px;">
					<span style="color: #57679f; font-size: 11px; font-weight: bold;">VIEW BY: </span>
				</div>
				<div class="pref_icons">
					<asp:ImageButton runat="server" ID="btnListView" ImageUrl="images/listing_ico_oran.png"
						OnClick="btnListView_Click" />
				</div>
				<div class="pref_icons">
					<asp:ImageButton runat="server" ID="btnGridView" ImageUrl="images/gallery_ico_blue.png"
						OnClick="btnGridView_Click" />
				</div>
            </div>
            <div class="backholder_mobile">
                <asp:LinkButton ID="btnBackTop" OnClick="btnBackTop_Click" runat="server">
                    <div class="button_back">
                    </div>
                </asp:LinkButton>
            </div>  
            
            <div style="display: none;">
                &nbsp;|&nbsp;Sort by:&nbsp;
                <asp:DropDownList runat="server" ID="ddlSort" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                        <asp:ListItem Text="Latest listings" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Oldest listings" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Highest Price" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Lowest Price" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
        </div>
              
        <div id="divListView" runat="server">
            <table width="100%" cellspacing="0" cellpadding="2" border="0" class="productListing">
                <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_ItemDataBound">
                    <ItemTemplate>
                        <tr class="productListing-odd">
                            <td class="productListing-data">
                                <div class="prop_list">
                                    <div class="prop_list_inner">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="">
                                            <tbody>
                                                <tr>
                                                    <td width="5%" valign="top">
                                                                
                                                        <div class="prod_list_image_listing">
                                                             <asp:Label runat="server" ID="lblHiddenId" Text='<%# Eval("PropertyID")%>' Visible="false"></asp:Label>
                                                             <asp:Label runat="server" ID="lblHiddenHd" Text='<%# Eval("Headline")%>' Visible="false"></asp:Label>
                                                            <asp:LinkButton runat="server" ID="lnkImageClick" OnClick="lnkImageClick_Click">                                                                    
                                                                <img width="174" height="130" border="0" align="middle" src="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Eval("MainImage") %>" alt=""/>
                                                             </asp:LinkButton>
                                                                <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() == "Buy"))
				                                                    {%>
                                                                                
						                                                <div id="divTagFeatured" runat="server" class="tag_featured_prop">
						                                                </div>
				                                                <% }%>
                                                                        
                                                                       
                                                                  
                                                           
                                                        </div>
                                                    </td>
                                                    <td valign="top">
                                                        <img width="10" height="10" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                    </td>
                                                    <td width="90%" valign="top">
                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <span class="prop_specs_title" style="font-size: 14px;"><b>
                                                                            <%# Eval("Headline")%></b></span><br>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <span class="prop_specs_title" style="font-size: 12px;">
                                                                            <%# Eval("StreetNo")%> <%# Eval("StreetName")%>, <%# Eval("Suburb")%>&nbsp;
                                                                            <span class="prop_price">$<%# String.Format("{0:#,#}", Eval("Price"))%>
                                                                            <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Buy"))
				                                                                {%>
						                                                            pw
				                                                            <% }%>
                                                                                    
                                                                            </span>
                                                                        </span><br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" style="height: 57px" colspan="3">
                                                                        <div class="prod_list_descr">
                                                                            <%# Eval("Description")%>
                                                                        </div>
                                                                        <span class="prop_specs_key">Property&nbsp;ID:&nbsp;MDWHG-<%# Eval("PropertyID")%></span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <table cellspacing="0" cellpadding="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/Bed.png">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <%# Eval("Bedrooms")%>
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bath.png">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <%# Eval("Bathrooms")%>
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/car.png">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                    </td>
                                                                                    <td valign="middle" class="prop_specs">
                                                                                        <%# Eval("Garages")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:LinkButton runat="server" ID="btnReadMoreList" OnClick="btnReadMoreList_Click">                                                                    
                                                                <img border="0" align="middle"
                                                                    src="<%= ModulePath %>/images/readmore_Orange.png"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="productListing-data" colspan="3">
                                <div class="prod_list_div">
                                </div>
                            </td>
                        </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
           
        </div>
        <div id="divGridView" runat="server" visible="false">
            <asp:DataList ID="dtGridView" runat="server" RepeatColumns="3" OnItemDataBound="dtGridView_ItemDataBound">
                <ItemTemplate>
				<div id="map">
                        </div>
                    <div id="header">
                        <div style="width: 170px; margin-left: 6px; margin-top: 6px; height: 33px; overflow: hidden;">
                            <span style="font-size: 14px; display: table-cell; vertical-align: middle;" class="prop_specs_title">
                                <b><%# Eval("Headline")%></b>
                            </span>
                            <span style="height: 33px; display: table-cell; vertical-align: middle;"><br/></span>
                        </div>
                        <div id="Image" style="position: relative;">
                            <asp:Label runat="server" ID="lblGridHiddenId" Text='<%# Eval("PropertyID")%>' Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblGridHiddenHd" Text='<%# Eval("Headline")%>' Visible="false"></asp:Label>
                            <asp:HiddenField ID="hdfGridProperyID" runat="server"/>
                            <asp:LinkButton runat="server" ID="lnkImageClickGrid" OnClick="lnkImageClickGrid_Click">                                                                    
                                <img width="200" height="150" border="0" align="middle" src="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Eval("MainImage") %>" alt=""/>
                            </asp:LinkButton>
                            <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() == "Buy"))
	                            {%>
                                                                                
		                            <div id="divTagFeatured" runat="server" class="tag_featured_prop">
		                            </div>
                            <% }%>
                        </div>
                        <div style="height: auto; width: 100%; float: left;" id="Div2">
                            <div style="margin: 0 0 0 5px !important; width: 100% !important;">
                                <div style="width: 55%; float: left; height: 33px; overflow: hidden">
                                    <span style="font-size: 12px; " class="prop_specs_title">
                                        <%# Eval("StreetNo")%> <%# Eval("StreetName")%>, <%# Eval("Suburb")%>&nbsp;
                                        </span>
                                </div>
                                <div style="float:right;">
                                    <span class="prop_price">$<%# String.Format("{0:#,#}", Eval("Price"))%>
                                           
                                    <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Buy"))
				                        {%>
						                    pw
				                    <% }%>
                                    </span>
                                </div>
                            </div>
                            <div style="font-size: 12px; margin: 5px; margin-right: 10px; margin-left: 5px; width: 210px;
                                height: 50px; overflow: hidden">
                                <%# Eval("Description")%>
                            </div>
                            <span style="font-size: 10px; margin-left: 5px;" class="prop_specs_key">Property ID:
                                MDWHG-
                                <%# Eval("PropertyID")%></span>
                            <div style="margin-left: 5px;" id="tableDiv">
                                <table cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td valign="middle" class="prop_specs">
                                                <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bedgrid.png">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <%# Eval("Bedrooms")%>
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bathgrid.png">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <%# Eval("Bathrooms")%>
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/cargrid.png">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <%# Eval("Garages")%>
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                            </td>
                                            <td valign="middle" class="prop_specs">
                                                <asp:LinkButton runat="server" ID="btnReadMoreGridRead" OnClick="lnkImageClickGridRead_Click">                                                                    
                                                                <img border="0" align="middle"
                                                                    src="<%= ModulePath %>/images/readmoregrid.png"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            
        </div>
        <div runat="server" id="divDetailedView">
            <div id="bckgrd_prod_info_content">
                <div class="detailright">
                    <div class="prod_info_headings">
                        <b><asp:Label runat="server" ID="lblHeading"></asp:Label></b>
                    </div>
                    <div class="prop_specs_title">
                        <asp:Label runat="server" ID="lblAddress" CssClass="lblAddress"></asp:Label>
                        <span class="prop_price">$<asp:Label runat="server" ID="lblPrice" CssClass="lblPrice" ></asp:Label>
                        <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Buy"))
				            {%>
						        pw
				        <% }%>
                        </span>
                    </div>
                    <div class="prop_specs">
                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bedgrid.png">
                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                         <asp:Label runat="server" ID="lblBesNoImage"></asp:Label>
                   
                        <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                          
                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bathgrid.png">
                                                                                           
                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                           
                        <asp:Label runat="server" ID="lblBathNoImg"></asp:Label>
                                                                                           
                        <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                            
                        <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/cargrid.png">
                                                                                           
                        <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                                                           
                        <asp:Label runat="server" ID="lblCarNoImg"></asp:Label>
                         <span class="propertyid">
							Property ID: <asp:Label runat="server" ID="lblId" CssClass="lblId"></asp:Label>
						</span>
						<div class="clear"></div>
                                                                                            
                    </div>
                    <div class="imageholder">
                        <ul id="myGallery" class="gallery clearfix">
                            <asp:Repeater runat="server" ID="rptImages" OnItemDataBound="rptImages_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <img src="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Container.DataItem %>" alt="No Images Found"/>
																					   
									    <div class="panel-content">
										    <center>																			
										    <a href="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Container.DataItem %>" rel="prettyPhoto[gallery1]">
											    <img CssClass="heroimage" src="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Container.DataItem %>" />
										    </a>
										    </center>
                                                <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() == "Buy"))
	                                            {%>
                                                                                
		                                            <div id="divTagFeatured" runat="server" class="tag_featured_prop">
		                                            </div>
                                            <% }%>		
									    </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                                                                           
                        </ul>
                    </div>
                    <div class="detailholder">
                        <p style="padding: 8px 0"><span class="prod_left_heading">About the Property:</span></p>
                        <p><asp:Label runat="server" ID="lblAboutPropery"></asp:Label></p>
                        <asp:Label runat="server" ID="lblFeatureTitle" Text="Features: " Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Repeater runat="server" ID="rptFeatures">
                            <ItemTemplate>
                                    <asp:Label runat="server" ID="lblFeatures" Text="<%# Container.DataItem %>"></asp:Label> <br />
                                </ItemTemplate>
                        </asp:Repeater>
                                                       
                        <asp:Label runat="server" ID="lblOtherFeaturesTitle" Text="Other Features: " Font-Bold="True"></asp:Label>
                        <asp:Label runat="server" ID="lblOtherFeatures"></asp:Label>
                        <br />
                            <asp:Label runat="server" ID="lblDateAvailableTitle" Text="Available From: " Font-Bold="True"></asp:Label>
                        <asp:Label runat="server" ID="lblDateAvailable"></asp:Label>
                        <br /><br />
                    </div>
                    <div class="locationholder">
                        <span class="prod_left_heading">Location:</span>
                        <br />
                        <div id="map">
                        </div>
                    </div>
                </div>
                <div class="propertysummary">
                    <span class="subHeadings">Property Summary</span>
                                
                    <div class="main prod_label">
                        Category: <span class="prod_values">
                            <asp:Label runat="server" ID="lblCategory" CssClass="lblCategory"></asp:Label></span>
                    </div>
                                       
                    <div class="main prod_label">
                        Sub-Categories: <span class="prod_values">
                            <br>
                            <asp:Label runat="server" ID="lblSubCategory" CssClass="lblSubCategory"></asp:Label>
                        </span>
                    </div>
                    <br/>
                    <div class="main prod_label">
                        No. of Bedrooms: <span class="prod_values">
                            <asp:Label runat="server" ID="lblNoOfBedRooms" CssClass="lblNoOfBedRooms"></asp:Label></span>
                      
                    </div>
                                       
                    <div class="main prod_label">
                        Ensuites: <span class="prod_values">
                            <asp:Label runat="server" ID="lblNoOfEnsuites"></asp:Label></span>
                    </div>
                    <div class="main prod_label">
                        No. of Bathrooms: <span class="prod_values">
                            <asp:Label runat="server" ID="lblNoOfBathrooms" CssClass="lblNoOfBathrooms"></asp:Label></span>
                    </div>
                                     
                    <div class="main prod_label">
                        Garages <span class="prod_values">
                            <asp:Label runat="server" ID="lblNoOfCarParks"></asp:Label></span>
                    </div>
                                        
                    <div id="trFloorArea" runat="server">
                        <div class="main prod_label">
                            Floor Area: <span class="prod_values">
                                    <asp:Label runat="server" ID="lblFloorArea"></asp:Label>m<sup>2</sup>
                                        </span>
                        </div>
                    </div>
                    <div id="trLandArea" runat="server">
                        <div class="main prod_label">
                            Land Area: <span class="prod_values">
                                            <asp:Label runat="server" ID="lblLandArea"></asp:Label>m<sup>2</sup>
                                        </span>
                        </div>
                    </div>
                    <br/>
                    <div class="printButton">
                       <a href="javascript:window.print()"><img src="/images/print.gif"><span>Print</span></a>
				    </div>
                    <br />
                    <div class="ContactHolder">
                    
                        <div class="subHeadings">
                        
                            Contact:
                        </div>
                        <div class="main">
                            <b>136 Bank Street, Whangarei<br />
                                Phone: (09) 470 0996  <br />
                                Fax: (09) 430 0997 </b>
						
		
                        </div>
						
						<div class="applybutton1form">
						<br />
						<h3>Is this your new home</h3>
						Click the below button to complete an online application now<br />
						
								<input type="hidden" id="tagid" name="tagid" value="6510">
								<input type="hidden" id="papf_realestateco" name="papf_realestateco" value="Maggie Dixon Real Estate">
								<input type="hidden" id="papf_realestateag" name="papf_realestateag" value="Maggie Dixon Real Estate Rentals">
								<input type="hidden" id="papf_realestatem" name="papf_realestatem" value="rentals@maggiedixon.co.nz">
								<input type="hidden" id="papf_logo" name="papf_logo" value="http://www.maggiedixon.co.nz/portals/180/gfm/footerlogo.png">

								<input type="hidden" id="papf_propid" name="papf_propid" value="" data-copy-val-src="lblId" />
								<input type="hidden" id="papf_propadd" name="papf_propadd" value="" data-copy-val-src="lblAddress"  />
								
								<input type="hidden" id="papf_propsub" name="papf_propsub" value="Whangarei" /> 
								<input type="hidden" id="papf_proppc" name="papf_proppc" value="0110">
								<input type="hidden" id="papf_propstat" name="papf_propstat" value="Northland">
								<input type="hidden" id="papf_available" name="papf_available" value="" data-copy-val-src="lblDateAvailable" />
								<input type="hidden" id="papf_rent" name="papf_rent" value="" data-copy-val-src="lblPrice" /> 
								
								<input type="hidden" id="papf_proptype" name="papf_proptype" value="" data-copy-val-src="lblSubCategory" /> 

								<input type="hidden" id="papf_propnobed" name="papf_propnobed" value="" data-copy-val-src="lblNoOfBedRooms" /> 

								<input type="hidden" id="papf_propnobath" name="papf_propnobath" value="" data-copy-val-src="lblNoOfBathrooms" />

								<input type="hidden" id="papf_propnocar" name="papf_propnocar" value="" data-copy-val-src="lblCarNoImg" /> 

								<input type="image"
											   onClick="this.form.action='https://www.1form.com/au/tenant/application/start';this.form.submit();this.form.target='_blank';"
										src="https://b.cdn1form.com/buttons/default.png" border="0" name="submit" alt="Apply now">
							</div>
						
					</div>					
                        <div class="contactUS">
                        <asp:TextBox runat="server" ID="txtName" placeholder="Name"></asp:TextBox>
                                                        
                        <asp:TextBox runat="server" ID="txtEmail" placeholder="Email"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtPhone" placeholder="Phone"></asp:TextBox>                        
                                                       
                        <asp:TextBox runat="server" ID="txtEnquiry" rows="5" TextMode="MultiLine"></asp:TextBox>
                                                     
                        <br />
                        <asp:Label runat="server" ID="lbloutmsg" Visible ="false"></asp:Label>
                        <div class="button_prod_send">
                            <asp:Button runat="server" ID="btnSendMail" Text="Send" OnClick="btnSendMail_Click"  />
                            
                        </div>
                           </div>                            
                    </div>
                </div>
				<div class="clear"></div>
                <div class="backholder">
                    <asp:LinkButton ID="btnBackBottom" OnClick="btnBackBottom_Click" runat="server">
                   
                        <div class="button_back">
                        </div>
                   
                    </asp:LinkButton>
                   

                </div>  
                <div class="clear"></div>
            </div>
           
            <br />
            <div class="similarProperties">
                <br />
                
                <p id="title_similar_prop">
                    <b>Similar properties you might be interested in </b>
                    </p>
                <asp:DataList ID="detailsviewRelated" runat="server" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="header">
                                <div style="width: 170px; margin-left: 6px; margin-top: 6px; height: 33px; overflow: hidden;">
                                <span style="font-size: 14px; display: table-cell; vertical-align: middle;" class="prop_specs_title">
                                    <b><%# Eval("Headline")%></b>
                                </span>
                                <span style="height: 33px; display: table-cell; vertical-align: middle;"><br/></span>
                            </div>
                            <div id="Image">
                                <asp:Label runat="server" ID="lblRelatedHiddenId" Text='<%# Eval("PropertyID")%>' Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="lblRelatedHiddenHd" Text='<%# Eval("Headline")%>' Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" ID="lnkImageClickSimilar" OnClick="lnkImageClickSimilar_Click">                                                                    
                                    <img width="200" height="150" border="0" align="middle" src="<%= DotNetNuke.Modules.MaggieDixon.Components.Constants.ListingImages(PortalId, !Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Rent")) %><%# Eval("MainImage") %>" alt=""/>
                                    </asp:LinkButton>
									<% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() == "Buy"))
	                            {%>
                                                                                
		                            <div id="divTagFeatured" runat="server" class="tag_featured_prop">
		                            </div>
                            <% }%>
                            </div>
                            <div style="height: auto; width: 100%; float: left;" id="Div2">
                                <div style="margin: 0 0 0 5px !important; width: 100% !important;">
                                        <div style="width: 65%; float: left; height: 33px; overflow: hidden">
                                    <span style="font-size: 12px; width: 100px;" class="prop_specs_title">
                                        <%# Eval("StreetNo")%> <%# Eval("StreetName")%>, <%# Eval("Suburb")%>&nbsp;
                                        </span>
                                </div>
                                <div style="float: right; width: 30%">
                                    <span class="prop_price">$<%# String.Format("{0:#,#}", Eval("Price"))%>
                                           
                                    <% if (!Settings.Contains("SettingXml") || (Settings["SettingXml"].ToString() != "Buy"))
				                        {%>
						                    pw
				                    <% }%>
                                    </span>
                                </div>
                                </div>
                                <div style="font-size: 12px; margin: 5px; margin-right: 10px; margin-left: 5px; width: 210px;
                                    height: 50px; overflow: hidden">
                                    <%# Eval("Description")%>
                                </div>
                                <span style="font-size: 10px; margin-left: 5px;" class="prop_specs_key">Property ID:
                                    MDWHG-
                                    <%# Eval("PropertyID")%></span>
                                <div style="margin-left: 5px;" id="tableDiv">
                                    <table cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td valign="middle" class="prop_specs">
                                                    <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bedgrid.png">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <%# Eval("Bedrooms")%>
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/bathgrid.png">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <%# Eval("Bathrooms")%>
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img border="0" align="middle" alt="" src="<%= ModulePath %>/images/cargrid.png">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="5" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <%# Eval("Garages")%>
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <img width="10" height="1" border="0" alt="" src="<%= ModulePath %>/images/pixel_trans.gif">
                                                </td>
                                                <td valign="middle" class="prop_specs">
                                                    <asp:LinkButton runat="server" ID="btnReadMoreSimilar" OnClick="lnkImageClickSimilarRead_Click">                                                      
                                                                <img border="0" align="middle" 
                                                                    src="<%= ModulePath %>/images/readmoregrid.png"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
				
            </div>
			
        </div>
                <asp:Label runat="server" ID="lblNoRecord" Text="No Records Found." Font-Bold="true"
                    ForeColor="Red" Visible="false"></asp:Label>
		<div class="pagination">
			<p><b>View more listings</b></p>
                <asp:Label ID="lblStatus" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="lbtnFirst" runat="server" CssClass="lnkpage" OnClick="lbtnFirst_Click">First</asp:LinkButton>
                <asp:LinkButton ID="lbtnPrev" runat="server" CssClass="lnkpage" OnClick="lbtnPrev_Click"><</asp:LinkButton>
                <asp:LinkButton ID="lblPage" runat="server" CssClass="lnkpageno" Enabled="false"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" CssClass="lnkpage" OnClick="lbtnNext_Click">></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" CssClass="lnkpage" OnClick="lbtnLast_Click">Last</asp:LinkButton>
            </div>			
       </div>
	   
    <asp:HiddenField ID="hdnAddress" runat="server" />
	
    <div class="clear"></div>
	
</div>
<script type="text/javascript" language="javascript">
    jQuery(document).ready(function ($) {
        jQuery('body,html').animate({ scrollTop: 0 }, 800);

    });
</script>
<!-- Google Maps Code -->
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js">
</script>
<!-- END Google Maps Code -->
<script type="text/javascript">


    $(document).ready(function () {
	
        var address = document.getElementById("<%= hdnAddress.ClientID %>").value;
		address += ' Northland, New Zealand';
		if (address != null && address != "") {
			var map = new google.maps.Map(document.getElementById('map'), {
				mapTypeId: google.maps.MapTypeId.ROADMAP,
				zoom: 6,
				panControl: true,
				zoomControl: true,
				scaleControl: true,
			});

			var geocoder = new google.maps.Geocoder();

			geocoder.geocode({
				'address': address
			},
		   function (results, status) {
			   if (status == google.maps.GeocoderStatus.OK) {
				   new google.maps.Marker({
					   position: results[0].geometry.location,
					   map: map
				   });
				   map.setCenter(results[0].geometry.location);
				   map.setZoom(15);
			   }
		   });
		}
    });
</script>



