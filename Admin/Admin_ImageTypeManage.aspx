﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_ImageTypeManage.aspx.cs" Inherits="Admin_Admin_ImageTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th><asp:Literal ID="ltlTitle" runat="server" Text="添加图片分类"></asp:Literal></th>
                        </tr>
                        <tr>
                            <td>名称</td>
                            <td>内容</td>
                            <td>说明</td>
                        </tr>
                        <tr>
                            <td>分类名称：</td>
                            <td><asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>父分类：</td>
                            <td>
                                <asp:DropDownList ID="drop1" runat="server" 
                                    onselectedindexchanged="drop1_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                <asp:DropDownList ID="drop2" runat="server" Visible="false" 
                                    onselectedindexchanged="drop2_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                <asp:DropDownList ID="drop3" runat="server" Visible="false" 
                                    onselectedindexchanged="drop3_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>可不选</td>
                        </tr>
                        <tr>
                            <td>排序：</td>
                            <td><asp:TextBox ID="txtRank" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>首页显示：</td>
                            <td><asp:CheckBox ID="chkShow" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>说明：</td>
                            <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvwImgType" runat="server" AutoGenerateColumns="false" 
                        Width="100%" DataKeyNames="ImgTypeID" onrowcommand="gvwImgType_RowCommand" 
                        onrowdatabound="gvwImgType_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <asp:Label ID="lblNum" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图片分类">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeName" runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="说明">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="父分类">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%#Eval("ParentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <asp:Label ID="lblRank" runat="server" Text='<%#Eval("Rank") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否显示">
                                <ItemTemplate>
                                    <asp:Label ID="lblShow" runat="server" Text='<%#Eval("IsShow") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChange" runat="server" Text="修改" CommandName="change" CommandArgument='<%#Eval("ImgTypeID") %>'></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" Text="删除" CommandName="del" CommandArgument='<%#Eval("ImgTypeID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>