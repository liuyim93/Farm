<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_AdviseReplyed.aspx.cs" Inherits="Admin_Admin_AdviseReplyed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_main">
        <asp:GridView ID="gvwAdvise" runat="server" AutoGenerateColumns="false" DataKeyNames="AdviseID" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="留言标题">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="留言时间">
                    <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%#Eval("LoadTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="回复">
                    <ItemTemplate>
                        <asp:Label ID="lblReply" runat="server" Text='<%#Eval("Reply") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href='Admin_AdviseDetail.aspx?id=<%#Eval("AdviseID") %>' target="main">查看详情</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:CheckBox ID="chkSelectAll" runat="server" Text="全选/反选" 
            oncheckedchanged="chkSelectAll_CheckedChanged" AutoPostBack="true" />&nbsp;&nbsp;<asp:Button 
            ID="btnDelSelect" runat="server" Text="删除所选" onclick="btnDelSelect_Click" />
    </div>
    </form>
</body>
</html>
