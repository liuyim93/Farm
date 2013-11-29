<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_NewsManage.aspx.cs" Inherits="Admin_Admin_NewsManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th>文章管理</th>
            </tr>
            <tr>
                <td colspan="4" width="700px">
                    <asp:GridView ID="gvwNewsManage" runat="server" AutoGenerateColumns="false" 
                        Width="100%" onrowcommand="gvwNewsManage_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                    <asp:Label ID="lblNewsTitle" runat="server"><%#Eval("Title") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="文章类型">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnType" runat="server" Text='<%#Eval("NewsTypeID") %>' CommandName="type" CommandArgument='<%#Eval("NewsTypeID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发布人">
                                <ItemTemplate>
                                    <asp:Label ID="lblAuthor" runat="server"><%#Eval("Author") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="浏览量">
                                <ItemTemplate>
                                    <asp:Label ID="lblClickNum" runat="server"><%#Eval("ClickNum") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发布时间">
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" runat="server"><%#Eval("LoadTime") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href='Admin_AddNews.aspx?id=<%#Eval("NewsID") %>'>修改</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>               
            </tr>
            <tr>
                <td><asp:CheckBox ID="chkSelectAll" runat="server" Text="全选/反选" 
                        oncheckedchanged="chkSelectAll_CheckedChanged" />&nbsp;&nbsp;<asp:Button 
                        ID="btnDelSelect" runat="server" Text="删除所选" onclick="btnDelSelect_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
