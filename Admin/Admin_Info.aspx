<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Info.aspx.cs" Inherits="Admin_Admin_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="hfInfoID" runat="server" />
        <table>
            <tr>
                <td>农庄名称：</td>
                <td><asp:TextBox ID="txtFarmName" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>农庄电话：</td>
                <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>手机号码：</td>
                <td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>地址：</td>
                <td><asp:TextBox ID="txtAdress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>联系人：</td>
                <td><asp:TextBox ID="txtLinkman" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>邮箱：</td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="提交" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
