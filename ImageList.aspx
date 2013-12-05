<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageList.aspx.cs" Inherits="ImageList" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/IntroMenu.ascx" TagName="IntroMenu" TagPrefix="uc4" %>
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
                <uc4:IntroMenu ID="intromenu1" runat="server" />
                <uc3:ContactUs ID="contactus1" runat="server" />
            </div>
            <div class="farmintro_right">
                <div class="farmintro_right_title">您目前的位置：<a href="Index.aspx" target="_self">首页</a>><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <asp:DataList ID="dlstImg" runat="server" width="100%" RepeatColumns="3" 
                            onitemdatabound="dlstImg_ItemDataBound">
                            <ItemTemplate>
                                <div class="house_area">
                                    <a href="Image_Detail.aspx?id=<%#Eval("ImgID") %>" target="_self"><asp:Image ID="img" runat="server" ImageUrl='<%#Eval("ImgUrl") %>' Width="190px" Height="150px" /></a>
                                    <div class="house_area_text"><a href="Image_Detail.aspx?id=<%#Eval("ImgID") %>" target="_self"><%#Eval("ImgName") %></a></div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <Webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                         LastPageText="尾页" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" 
                            AlwaysShow="true" UrlPaging="true" PageSize="9" 
                            onpagechanged="AspNetPager1_PageChanged"></Webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <uc2:Bottom ID="bottom1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
