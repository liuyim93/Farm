<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_AddImage.aspx.cs" Inherits="Admin_Admin_AddImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th><asp:Label ID="lblTitle" runat="server" Text="添加图片"></asp:Label></th>
                        </tr>
                        <tr>
                            <td>添加到：</td>
                            <td>
                                <asp:DropDownList ID="drop1" runat="server" 
                                    onselectedindexchanged="drop1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="drop2" runat="server" 
                                    onselectedindexchanged="drop2_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="drop3" runat="server" 
                                    onselectedindexchanged="drop3_SelectedIndexChanged1" Visible="false"></asp:DropDownList>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>图片名称：</td>
                            <td><asp:TextBox ID="txtImgName" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>上传图片：</td>
                            <td>
                                <asp:FileUpload ID="fileupload1" runat="server" />&nbsp;&nbsp;
                                <asp:Button ID="btnUpload" runat="server" Text="上传" 
                                    onclick="btnUpload_Click" />
                                <asp:HiddenField ID="hfImgUrl" runat="server" />
                                <asp:HiddenField ID="hfImgID" runat="server" />
                           </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>是否显示：</td>
                            <td><asp:CheckBox ID="chkShow" runat="server" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>备注：</td>
                            <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <asp:DataList ID="dlstImg" runat="server" Width="100%" 
                        onitemcommand="dlstImg_ItemCommand">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td>图片名称</td>
                                    <td>图片类型</td>
                                    <td>图片</td>
                                    <td>备注</td>
                                    <td>是否显示</td>
                                    <td>上传时间</td>
                                    <td>操作</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblImgName" runat="server"><%#Eval("ImgName") %></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblImgType" runat="server" Text='<%#Eval("ImgTypeID") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <img src='<%#Eval("ImgUrl") %>' width="50px" height="50px" border="0" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRemark" runat="server"><%#Eval("Remark") %></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIsShow" runat="server" Text='<%#Eval("IsShow") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTime" runat="server"><%#Eval("LoadTime") %></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="change" CommandArgument='<%#Eval("ImgID") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("ImgID") %>'>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
