<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Index_Top.aspx.cs" Inherits="Admin_Admin_Index_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_top">
    <ul>
        <li><img src="Images/admin_top_close.gif" alt="" title="关闭左边管理导航菜单" /></li>
        <li><a href="Admin_UpdatePwd.aspx" target="main"><img src="Images/admin_top_icon_1.gif" alt="" />&nbsp;修改密码</a></li>
        <li><a href="Admin_AdviseUnReply.aspx" target="main"><img src="Images/edit.gif" alt="" />&nbsp;留言管理</a></li>
        <li><a href="Admin_ManageAdmin.aspx" target="main"><img src="Images/admin_top_icon_5.gif" alt="" />&nbsp;用户管理</a></li>
    </ul>      
    </div>
    </form>
</body>
</html>
