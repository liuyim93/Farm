<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_AddImage.aspx.cs" Inherits="Admin_Admin_AddImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="admin_index_main">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr>
                            <th colspan="3"><asp:Label ID="lblTitle" runat="server" Text="添加图片"></asp:Label></th>
                        </tr>
                        <tr>
                            <td class="td_left">添加到：</td>
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
                            <td class="td_left">图片名称：</td>
                            <td><asp:TextBox ID="txtImgName" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="td_left">链接地址：</td>
                            <td><asp:TextBox ID="txtLinkUrl" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="td_left">上传图片：</td>
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
                            <td class="td_left">是否显示：</td>
                            <td><asp:CheckBox ID="chkShow" runat="server" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="td_left">首页顶部显示：</td>
                            <td><asp:CheckBox ID="chkTopShow" runat="server" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="td_left">首页底部显示：</td>
                            <td><asp:CheckBox ID="chkBottomShow" runat="server" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="td_left">备注：</td>
                            <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="td_left"></td>
                            <td><asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <asp:DataList ID="dlstImg" runat="server" Width="100%" 
                        onitemcommand="dlstImg_ItemCommand" 
                        onitemdatabound="dlstImg_ItemDataBound">
                        <HeaderTemplate>
                            <table width="100%" align="center">
                                <tr>
                                    <td width="100px" class="addimage_dlstimg_title">图片名称</td>
                                    <td width="100px" class="addimage_dlstimg_title"><asp:LinkButton ID="lbtnShowAll" runat="server" CommandName="showAll">图片类型</asp:LinkButton></td>
                                    <td width="100px" class="addimage_dlstimg_title">图片</td>
                                    <td width="100px" class="addimage_dlstimg_title">备注</td>
                                    <td width="100px" class="addimage_dlstimg_title">是否显示</td>
                                    <td width="100px" class="addimage_dlstimg_title">上传时间</td>
                                    <td width="100px" class="addimage_dlstimg_title">操作</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table width="100%" align="center">
                                <tr>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblImgName" runat="server"><%#Eval("ImgName") %></asp:Label>
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:LinkButton ID="lbtnImgType" runat="server" Text='<%#Eval("ImgTypeID") %>' CommandName="imgType" CommandArgument='<%#Eval("ImgTypeID") %>'></asp:LinkButton>
                                    </td>
                                    <td width="100px" align="center">
                                        <img src='<%#Eval("ImgUrl") %>' width="70px" height="70px" border="0" />
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblRemark" runat="server"><%#Eval("Remark") %></asp:Label>
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblIsShow" runat="server" Text='<%#Eval("IsShow") %>'></asp:Label>
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblTime" runat="server"><%#Eval("LoadTime") %></asp:Label>
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="change" CommandArgument='<%#Eval("ImgID") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("ImgID") %>'>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
