<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="News_Detail" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/NewsMenu.ascx" TagName="NewsMenu" TagPrefix="uc4" %>

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
                <uc4:NewsMenu ID="newsmenu1" runat="server" />
                <uc3:ContactUs ID="contactus1" runat="server" />
            </div>
            <div class="farmintro_right">
                <div class="farmintro_right_title">您目前的位置：<a>首页</a>><asp:HyperLink ID="hlnkTitle" runat="server"></asp:HyperLink>><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <div class="housedetail_title"><asp:Label ID="lblNewsName" runat="server"></asp:Label></div>
                        <div class="housedetail_time">作者：<asp:Literal ID="ltlAuthor" runat="server"></asp:Literal>&nbsp;&nbsp;浏览量：<asp:Literal ID="ltlClickNum" runat="server"></asp:Literal>&nbsp;&nbsp;发布时间：<asp:Literal ID="ltlTime" runat="server"></asp:Literal></div>
                        <div class="housedetail_img">
                            <asp:Label ID="lblNewsDetail" runat="server"></asp:Label>
                        </div>
                        <div>
                            上一篇：<asp:HyperLink ID="hlnkPrev" runat="server"></asp:HyperLink><br />
                            下一篇：<asp:HyperLink ID="hlnkNext" runat="server"></asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="bottom">
            <uc2:Bottom ID="bottom1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
