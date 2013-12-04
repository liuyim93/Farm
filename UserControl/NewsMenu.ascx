<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsMenu.ascx.cs" Inherits="UserControl_NewsMenu" %>
<div class="intromenu">
    <div class="intromenu_title"></div>
    <ul>
        <asp:DataList ID="dlstNewsMenu" runat="server">
            <ItemTemplate>
                <li><a href="News_Search.aspx?id=<%#Eval("NewsTypeID") %>" target="_self"><%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>