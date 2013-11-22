<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Index.aspx.cs" Inherits="Admin_Admin_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<frameset cols="180,*" rows="*" border="0" frameborder="0" framespacing="0">
    <frame name="left" src="Admin_Index_Left.aspx" scrolling="auto" height="100%" />
    <frameset rows="35,*">
        <frame name="top" src="Admin_Index_Top.aspx" scrolling="no" height="100%" />
        <frame name="main" src="Admin_Info.aspx" scrolling="auto" height="100%" />
    </frameset>
    <noframes>
        <body>
            <div>
            </div>
        </body>
    </noframes>
</frameset>
</html>
