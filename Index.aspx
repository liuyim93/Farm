<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.2.6.js" type="text/javascript"/></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Top ID="top1" runat="server" />
        <div class="index_top">
            <div class="index_top_left">
                 <div class="index_top_left_title"><div class="newstitle_more"><a href="" target="_self"><img src="Images/more.gif" alt="" border="0" align="absmiddle" /></a></div></div>
                <div class="index_top_left_content">
                    <asp:DataList ID="dlstNews" runat="server">
                        <ItemTemplate>
                            <div class="dlstnews_area">
                                <a href="" target="_self"><%#Eval("Detail") %></a>
                            <div class="dlstnews_area_time">
                                <asp:Literal ID="ltlTime" runat="server" Text='<%#Eval("LoadTime") %>'></asp:Literal>
                            </div>
                            </div>                            
                        </ItemTemplate>
                    </asp:DataList>
                </div>                      
            </div>
            <div class="index_top_right">
                <div class="index_top_right_title"></div>
                <div class="index_top_right_content">
                    <asp:DataList ID="dlstImage" runat="server">
                        <ItemTemplate>
                            <div class="dlstimage_area">
                                <a href="<%#Eval("LinkUrl") %>" target="_self"><img src="<%#Eval("ImgUrl") %>" width="100px" height="70px" /></a><br />
                                <div class="dlstimage_text"><a href="<%#Eval("LinkUrl") %>" target="_self"><%#Eval("ImgName") %></a></div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="index_middle">
            <div class="index_middle_left">
                <div class="index_middle_left_title"></div>
                <div class="index_middle_left_content">
                    <asp:DataList ID="dlstActivity" runat="server">
                        <ItemTemplate>
                            <div class="dlstnews_area">
                                <a href="" target="_self"><%#Eval("Title") %></a>
                                <div class="dlstnews_time"><%#Eval("LoadTime") %></div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="index_middle_middle">
                <div class="index_middle_middle_title"></div>
                <div class="index_farmintro">
                    <asp:Literal ID="ltlFarmIntro" runat="server"></asp:Literal>
                </div>
            </div>
            <uc3:ContactUs ID="contactus1" runat="server" />
        </div>
        <div class="index_bottom">
            <div class="index_bottom_title"></div>
            <div id="marquee">
                <div style="width:800%;float:left;">
                    <div id="marquee1">
                        <asp:DataList ID="dlstMarquee" runat="server" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <a href="" target="_self"><img src='<%#Eval("ImgUrl") %>' alt="" width="80px" height="80px" border="0" /></a>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div id="marquee2" style="float:left"></div>
                </div>                
            </div>
        </div>        
    </div>
    <script type="text/javascript">
        //文字滚动 
        var speed = 20;
        var tab = document.getElementById("marquee");
        var tab1 = document.getElementById("marquee1");
        var tab2 = document.getElementById("marquee2");
        tab2.innerHTML = tab1.innerHTML;
        function Marquee() {
            if (tab2.offsetWidth - tab.scrollLeft <= 0)
                tab.scrollLeft -= tab1.offsetWidth
            else {
                tab.scrollLeft++;
            }
        }
        var MyMar = setInterval(Marquee, speed);
        tab.onmouseover = function () { clearInterval(MyMar) };
        tab.onmouseout = function () { MyMar = setInterval(Marquee, speed) };
    </script>
    </form>
</body>
</html>
