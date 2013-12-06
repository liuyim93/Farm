<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HouseMenu.ascx.cs" Inherits="UserControl_HouseMenu" %>
<div class="intromenu">
    <div class="intromenu_title">住宿设施</div>
    <ul>
        <asp:DataList ID="dlstHouse" runat="server" Width="100%">
            <ItemTemplate>
                <li><a href="House_Search.aspx?typeId=<%#Eval("ImgTypeID") %>" target="_self"><Img src="Images/news_before.jpg" alt="" />&nbsp;<%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>