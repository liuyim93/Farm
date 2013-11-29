<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_NewsTypeManage.aspx.cs" Inherits="Admin_Admin_NewsTypeManage" %>

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
                <td></td>
                <td>内容</td>
                <td>说明</td>
            </tr>
            <tr>
                <td>类别名称：</td>
                <td><asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>类别说明：</td>
                <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblMsg" runat="server"></asp:Label><asp:HiddenField ID="hfNewsTypeID" runat="server" /></td>
            </tr>
        </table>
        <asp:GridView ID="gvwNewsType" runat="server" AutoGenerateColumns='false' 
            Width="100%" onrowcommand="gvwNewsType_RowCommand" 
            onrowdatabound="gvwNewsType_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <asp:Label ID="lblNum" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类别名称">
                    <ItemTemplate>
                        <asp:Label ID="lblTypeName" runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类别说明">
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server"><%#Eval("Remark") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="change" CommandArgument='<%#Eval("NewsTypeID") %>'>修改</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("NewsTypeID") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
