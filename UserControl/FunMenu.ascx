<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FunMenu.ascx.cs" Inherits="UserControl_FunMenu" %>
<div class="intromenu">
    <div class="intromenu_title">农家娱乐</div>
    <ul>
        <asp:DataList ID="dlstFunMenu" runat="server">
            <ItemTemplate>
                <li><a href="Fun_Search.aspx?id=<%#Eval("ImgTypeID") %>" target="_self"><Img src="Images/news_before.jpg" alt="" />&nbsp;<%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>