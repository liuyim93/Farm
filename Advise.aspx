<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Advise.aspx.cs" Inherits="Advise" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/IntroMenu.ascx" TagName="IntroMenu" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>访客留言-金水泊山庄</title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">  
	<uc1:Top ID="top1" runat="server" />
    <div class="farmintro">
      
        <div class="farmintro_content">
            <div class="farmintro_left">
                <uc4:IntroMenu ID="intromenu" runat="server" />
                <uc3:ContactUs ID="contactus" runat="server" />
            </div>
            <div class="farmintro_right">
                <div class="farmintro_right_title">您目前的位置：<a href="Index.aspx" target="_self">首页</a>><a href="Advise.aspx" target="_self">访客留言</a></div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <div class="advise_choice"><a href="Advise.aspx" target="_self">访客留言</a>|<a href="AdviseList.aspx" target="_self">查看留言</a></div>
                        <div>
                            <table class="advise_table">
                                <tr>
                                    <td class="advise_table_left">联系人：</td>
                                    <td><asp:TextBox ID="txtLinkman" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="advise_table_left">联系电话：</td>
                                    <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="advise_table_left">电子邮箱：</td>
                                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="advise_table_left">留言内容：</td>
                                    <td><asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Width="350px" Height="120px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="advise_table_left">验证码：</td>
                                    <td ><asp:TextBox ID="txtCheckCode" runat="server" Width="50px"></asp:TextBox>&nbsp;<img src="Admin/CodeImage.aspx" height="19px" /></td>
                                </tr>
                                <tr>
                                    <td class="advise_table_left"></td>
                                    <td><asp:Button ID="btnSubmit" runat="server" Text="提交留言" 
                                            onclick="btnSubmit_Click" /></td>
                                </tr>
                            </table>
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
