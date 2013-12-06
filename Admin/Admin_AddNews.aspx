<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_AddNews.aspx.cs" Inherits="Admin_Admin_AddNews" %>
<%@Register Assembly="FredCK.FCKEditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
                <th colspan="3">添加文章资讯</th>
            </tr>
            <tr>
                <td class="td_left">标题：</td>
                <td><asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox><asp:HiddenField ID="hfNewsID" runat="server" /></td>
            </tr>
            <tr>
                <td class="td_left">文章类型：</td>
                <td><asp:DropDownList ID="dropNewsType" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="td_left">发表人：</td>
                <td><asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="td_left">点击量：</td>
                <td><asp:TextBox ID="txtClickNum" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4"><FCKeditorV2:FCKeditor ID="fckeditor1" runat="server" Width="798" Height="500" EnableSourceXHTML="true" BasePath="~/fckeditor/"></FCKeditorV2:FCKeditor></td>
            </tr>
            <tr>
                <td class="td_left"></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="确认添加" 
                        onclick="btnSubmit_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
