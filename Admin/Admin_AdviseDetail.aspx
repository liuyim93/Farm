<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_AdviseDetail.aspx.cs" Inherits="Admin_Admin_AdviseDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th>留言信息</th>
            </tr>
            <tr>
                <td>联系人：</td>
                <td><asp:Label ID="lblRealName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>邮箱：</td>
                <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>留言时间：</td>
                <td><asp:Label ID="lblTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>留言标题：</td>
                <td><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>留言内容:</td>
                <td><asp:Label ID="lblDetail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>回复：</td>
                <td><asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="700px" Height="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnBack" runat="server" Text="返回" OnClientClick="javascript:history.go(-1)" />&nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="提交回复" 
                        onclick="btnSubmit_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
