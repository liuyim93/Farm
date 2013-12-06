<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Info.aspx.cs" Inherits="Admin_Admin_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_main">
    <asp:HiddenField ID="hfInfoID" runat="server" />
        <table width="100%">
            <tr>
                <td class="td_left">农庄名称：</td>
                <td class="td_middle"><asp:TextBox ID="txtFarmName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">农庄电话：</td>
                <td class="td_middle"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">手机号码：</td>
                <td class="td_middle"><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">地址：</td>
                <td class="td_middle"><asp:TextBox ID="txtAdress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">联系人：</td>
                <td class="td_middle"><asp:TextBox ID="txtLinkman" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">邮箱：</td>
                <td class="td_middle"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left"></td>
                <td class="td_middle"><asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="提交" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
