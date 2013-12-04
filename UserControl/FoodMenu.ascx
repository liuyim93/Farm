<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FoodMenu.ascx.cs" Inherits="UserControl_FoodMenu" %>
<div class="intromenu">
    <div class="intromenu_title">农家菜肴</div>
    <ul>
        <asp:DataList ID="dlstFoodMenu" runat="server">
            <ItemTemplate>
                <li><a href="" target="_self"><%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>