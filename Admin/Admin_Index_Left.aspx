<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Index_Left.aspx.cs" Inherits="Admin_Admin_Index_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_left">
        <img src="Images/title.gif" alt="" width="160px" height="40px" />
        <div class="admin_index_left_title"><a href="../Index.aspx" target="_blank">网站首页</a>|<a href="Admin_Login.aspx" target="_self">退出</a></div>
        <div class="admin_index_left_area">
            <div class="admin_index_left_title">系统设置</div>
            <ul>
                <li><a href="Admin_Info.aspx" target="main">农庄信息</a></li>
                <li><a href="Admin_Intro.aspx" target="main">农庄简介</a></li>
                <li><a href="Admin_ManageAdmin.aspx" target="main">管理员</a></li>
                <li><a href="Admin_UpdatePwd.aspx" target="main">修改密码</a></li>
            </ul>
        </div>
        <div class="admin_index_left_area">
            <div class="admin_index_left_title">图片管理</div>
            <div>
                <ul>
                    <li><a href="Admin_ImageTypeManage.aspx" target="main">分类管理</a></li>
                    <li><a href="Admin_AddImage.aspx" target="main">图片管理</a></li>
                </ul>
            </div>
        </div>
        <div class="admin_index_left_area">
            <div class="admin_index_left_title">资讯管理</div>
            <div>
                <ul>
                    <li><a href="Admin_NewsTypeManage.aspx" target="main">分类管理</a></li>
                    <li><a href="Admin_AddNews.aspx" target="main">资讯添加</a></li>
                    <li><a href="Admin_NewsManage.aspx" target="main">资讯管理</a></li>
                </ul>
            </div>
        </div>
        <div class="admin_index_left_area">
            <div class="admin_index_left_title">留言管理</div>
            <div>
                <ul>
                    <li><a href="Admin_AdviseUnReply.aspx" target="main">待回复</a></li>
                    <li><a href="Admin_AdviseReplyed.aspx" target="main">已回复</a></li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
