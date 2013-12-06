<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsMenu.ascx.cs" Inherits="UserControl_NewsMenu" %>
<div class="intromenu">
    <div class="intromenu_title">新闻动态</div>
    <ul>
        <asp:DataList ID="dlstNewsMenu" runat="server" Width="100%">
            <ItemTemplate>
                <li><a href="News_Search.aspx?id=<%#Eval("NewsTypeID") %>" target="_self"><Img src="Images/news_before.jpg" alt="" />&nbsp;<%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>