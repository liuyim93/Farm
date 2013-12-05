<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdviseList.aspx.cs" Inherits="AdviseList" %>
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
                <div class="farmintro_right_title">您目前的位置：<a href="Index.aspx" target="_self">首页</a>><a href="Advise.aspx" target="_self">访客留言</a></div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <div class="advise_choice"><a href="Advise.aspx" target="_self">访客留言</a>|<a href="AdviseList.aspx" target="_self">查看留言</a></div>
                        <div class="advise_content">
                            <asp:DataList ID="dlstAdvise" runat="server" Width="100%">
                                <ItemTemplate>
                                    <div class="advise_area">
                                        <div class="advise_area_top">
                                            <div class="advise_area_time">留言日期：<asp:Literal ID="ltlTime" runat="server" Text='<%#Eval("LoadTime") %>'></asp:Literal></div>
                                            留言人：<asp:Label ID="lblRealName" runat="server" Text='<%#Eval("RealName") %>'></asp:Label>
                                        </div>
                                        <div class="advise_area_detail">留言内容：<asp:Label ID="lblDetail" runat="server" Text='<%#Eval("Detail") %>'></asp:Label></div>
                                        <div class="advise_area_reply">回复：<asp:Label ID="lblReply" runat="server" Text='<%#Eval("Reply") %>'></asp:Label></div>
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
        </div>
        <div class="bottom">
            <uc2:Bottom ID="bottom1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
