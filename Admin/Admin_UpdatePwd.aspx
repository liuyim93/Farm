<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_UpdatePwd.aspx.cs" Inherits="Admin_Admin_UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_main">
        <table width="100%">
            <tr>
                <th colspan="4">修改密码</th>
            </tr>
            <tr>
                <td class="td_left">用户名：</td>
                <td><asp:Label ID="lblAdminName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="td_left">原密码：</td>
                <td><asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">新密码：</td>
                <td><asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">确认密码：</td>
                <td><asp:TextBox ID="txtPwdConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left"></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="确认修改" 
                        onclick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
