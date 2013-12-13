<%@ Page Language="C#" AutoEventWireup="true" CodeFile="House_Detail.aspx.cs" Inherits="House_Detail" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/HouseMenu.ascx" TagName="HouseMenu" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="ltlBrowserText" runat="server"></asp:Literal></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.2.6.js" type="text/javascript"/></script>
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
                <div class="farmintro_right_title">您目前的位置：<a href="Index.aspx" target="_self">首页</a>><a href="House_Default.aspx" target="_self">住宿设施</a>><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <div class="housedetail_title"><asp:Label ID="lblImgName" runat="server"></asp:Label></div>
                        <div class="housedetail_time">作者：admin&nbsp;&nbsp;发布时间：<asp:Label ID="ltlTime" runat="server"></asp:Label></div>
                        <div class="housedetail_img"><asp:Image ID="img" runat="server" Width="600px" Height="400px" /></div>
                        <div class="imgdetail_remark">
                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
                        </div>
                        <div class="housedetail_page">
                            上一篇：<asp:LinkButton 
                                ID="lbtnPrev" runat="server" onclick="lbtnPrev_Click"></asp:LinkButton><asp:HiddenField ID="hfPrevImgID" runat="server" /><br />
                            下一篇：<asp:LinkButton ID="lbtnNext" runat="server" onclick="lbtnNext_Click"></asp:LinkButton><asp:HiddenField ID="hfNextImgID" runat="server" />
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
