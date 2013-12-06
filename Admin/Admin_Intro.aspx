<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Intro.aspx.cs" Inherits="Admin_Admin_Intro"
    ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_main">
        <asp:HiddenField ID="hfIntroID" runat="server" />
        <table>
            <tr>
                <td>请选择：
                    <asp:DropDownList ID="dropIntroType" runat="server" OnSelectedIndexChanged="dropIntroType_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </th>
            </tr>
            <tr>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor" runat="server" Width="700px" Height="400px"
                        BasePath="~/fckeditor/">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
