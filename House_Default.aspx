<%@ Page Language="C#" AutoEventWireup="true" CodeFile="House_Default.aspx.cs" Inherits="House_Default" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/HouseMenu.ascx" TagName="HouseMenu" TagPrefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="Webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="farmintro">
        <uc1:Top ID="top1" runat="server" />
        <div class="farmintro_content">
            <div class="farmintro_left">
                <uc4:HouseMenu ID="housemenu1" runat="server" />
                <uc3:ContactUs ID="contactus1" runat="server" />
            </div>
            <div class="farmintro_right">
                <div class="farmintro_right_title">您目前的位置：<a href="Index.aspx" target="_self">首页</a>>住宿设施</div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <asp:DataList ID="dlstImage" runat="server" RepeatColumns="5" 
                            onitemdatabound="dlstImage_ItemDataBound" Width="100%">
                            <ItemTemplate>
                                <div class="house_area">
                                    <a href="House_Detail.aspx?id=<%#Eval("ImgID") %>" target="_self"><asp:Image ID="imgHouse" runat="server" ImageUrl='<%#Eval("ImgUrl") %>' Width="188px" Height="150px" /></a>
                                    <div class="house_area_text"><a href="House_Detail.aspx?id=<%#Eval("ImgID") %>" target="_self"><%#Eval("ImgName") %></a></div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <Webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="20" 
                            AlwaysShow="true" LastPageText="尾页"
                         FirstPageText="首页" NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" 
                            UrlPaging="true" onpagechanged="AspNetPager1_PageChanged" CurrentPageButtonClass="cpb">
                        </Webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <div  class="bottom">
            <uc2:Bottom ID="bottom1" runat="server" />
        </div>        
    </div>
    </form>
</body>
</html>
