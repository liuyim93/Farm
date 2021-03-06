﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FarmIntro.aspx.cs" Inherits="FarmIntro" %>
<%@ Register Src="UserControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ContactUs.ascx" TagName="ContactUs" TagPrefix="uc3" %>
<%@ Register Src="UserControl/IntroMenu.ascx" TagName="IntroMenu" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>农庄简介-金水泊山庄</title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
	<uc1:Top ID="top1" runat="server" />
    <div class="farmintro">
        
        <div class="farmintro_content">
            <div class="farmintro_left">
                <uc4:IntroMenu ID="intromenu1" runat="server" />                
                <uc3:ContactUs ID="contactus1" runat="server" />
            </div>
            <div class="farmintro_right">
                <div class="farmintro_right_title">您现在的位置：<a href="../Index.aspx" target="_self">首页</a>>农庄简介</div>
                <div class="farmintro_right_content">
                    <div class="farmintro_right_detail">
                        <asp:Label ID="lblFarmIntro" runat="server"></asp:Label>
                    </div>                    
                </div>
            </div>
        </div>
        <div style="width:100%;float:left;">
            <uc2:Bottom ID="bottom1" runat="server" />
        </div>        
    </div>
    </form>
</body>
</html>
