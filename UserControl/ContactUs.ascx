<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="UserControl_ContactUs" %>
<div id="contactus">
    <a  href="" target="_self"><img src="Images/contactus.gif" alt="" width="210px" height="80px" /></a>
    <div id="contactus_text">
         <ul>
            <li>联系人：<asp:Label ID="lblLinkman" runat="server"></asp:Label></li>
            <li>电话：<asp:Label ID="lblPhone" runat="server"></asp:Label></li>
            <li>手机：<asp:Label ID="lblMobile" runat="server"></asp:Label></li>
            <li>邮箱：<asp:Label ID="lblEmail" runat="server"></asp:Label></li>
            <li>地址：<asp:Label ID="lblAdress" runat="server"></asp:Label></li>
        </ul>
    </div>   
</div>