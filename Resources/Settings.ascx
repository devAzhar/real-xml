<%@ Control Language="C#" AutoEventWireup="false" Inherits="DotNetNuke.Modules.MaggieDixon.Settings"
    CodeBehind="Settings.ascx.cs" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>
<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead">
    <a href="" class="dnnSectionExpanded">
        <%#LocalizeString("BasicSettings")%></a></h2>
<fieldset>
    <div class="dnnFormItem">
        <%--<dnn:Label ID="lblSetting1" runat="server" Text="Xml File Path"/> --%>
        <asp:Label runat="server" ID="lblSetting" Text="Load Buy/Rent XML :"></asp:Label>
        <asp:RadioButtonList runat="server" ID="rbtListXml">
            <asp:ListItem Text="Buy" Value="Buy"></asp:ListItem>
            <asp:ListItem Text="Rent" Value="Rent"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label runat="server" ID="Label1" Text="Buy Page Link :"></asp:Label>
        <asp:TextBox runat="server" ID="txtBuyLink"></asp:TextBox>
        <br />
        <asp:Label runat="server" ID="Label2" Text="Rent Page Link :"></asp:Label>
        <asp:TextBox runat="server" ID="txtRentLink"></asp:TextBox>
        <br />
        <asp:Label runat="server" ID="Label3" Text="Buy Contact Email :"></asp:Label>
        <asp:TextBox runat="server" ID="txtBuyContactEmail"></asp:TextBox>
        <br />
        <asp:Label runat="server" ID="Label4" Text="Rent Contact Email :"></asp:Label>
        <asp:TextBox runat="server" ID="txtRentContactEmail"></asp:TextBox>
        <br />
    </div>
    <%--<div class="dnnFormItem">
            <dnn:label ID="lblSetting2" runat="server" />
            <asp:TextBox ID="txtSetting2" runat="server" />
        </div>--%>
</fieldset>
