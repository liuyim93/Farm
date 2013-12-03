﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HouseMenu.ascx.cs" Inherits="UserControl_HouseMenu" %>
<div class="intromenu">
    <div class="intromenu_title">住宿设施</div>
    <ul>
        <asp:DataList ID="dlstHouse" runat="server" Width="100%">
            <ItemTemplate>
                <li><a href="" target="_self"><%#Eval("TypeName") %></a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>