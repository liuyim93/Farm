<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <br><br><br><br><br><br>
    <table width="467" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
   <td width="240"><img src="Images/spacer.gif" width="240" height="1" border="0" alt=""></td>
   <td width="57"><img src="Images/spacer.gif" width="57" height="1" border="0" alt=""></td>
   <td width="163"><img src="Images/spacer.gif" width="163" height="1" border="0" alt=""></td>
   <td width="10"><img src="Images/spacer.gif" width="1" height="1" border="0" alt=""></td>
  </tr>

  <tr>
   <td colspan="3"><img name="未命名1_r1_c1" src="Images/1_r1_c1.jpg" width="460" height="60" border="0" alt=""></td>
  </tr>
  <tr>
   <td rowspan="2" valign="top" background="Images/1_r2_c1.jpg"><table width="240"  border="0" cellspacing="0" cellpadding="0">
     <tr>
       <td width="116" height="26"></td>
       <td colspan="2"><input name="uid" type="text" id="uid" runat="server" style="border: 1px solid #999999;FONT-SIZE: 9pt; height:18;width:108px"></td>
     </tr>
     <tr>
       <td height="23"></td>
       <td colspan="2"><input name="pwd" type="password" id="pwd" runat="server" style="border: 1px solid #999999;FONT-SIZE: 9pt; height:18;width:108px"></td>
     </tr>
     <tr>
       <td height="25"></td>
       <td width="56"><input name="verifycode" runat="server" type=text  id="code" maxLength=4  style="border: 1px solid #999999;FONT-SIZE: 9pt; width: 55px;"></td>
       <td width="68"><img src="CodeImage.aspx" height="19"></td>
     </tr>
   </table></td>
   <td><asp:ImageButton ID="btnLogin" runat="server" BorderStyle="None" ImageUrl="~/Admin/Images/1_r2_c2.jpg" OnClick="btnLogin_Click" ToolTip="登录后台系统" /></td>   
   <td rowspan="2"><img name="未命名1_r2_c3" src="Images/1_r2_c3.jpg" width="163" height="176" border="0" alt=""></td>
  </tr>
  <tr>
   <td><img name="未命名1_r3_c2" src="Images/1_r3_c2.jpg" width="57" height="114" border="0" alt=""></td>
  </tr>
  </table>
    </div>
        <asp:Label ID="labmsg" runat="server"></asp:Label>
    </form>
</body>
</html>
