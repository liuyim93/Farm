<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_ManageAdmin.aspx.cs" Inherits="Admin_Admin_ManageAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function checkname() {
            var name = document.getElementById('<%=txtAdminName.ClientID %>');
            var msg = document.getElementById('<%=ltlNameStatus.ClientID %>');
            var result = Admin_Admin_ManageAdmin.CheckAdminName(name.value);
            if (result == "0") {
                msg.innerHTML = "该用户名已存在";
                msg.style.color = 'red';
                return false;
            } else {
                msg.innerHTML = "";
                return true;
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">        
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>                        
                        <th>添加管理员</th>                      
                    </tr>
                    <tr>
                        <td>用户名：</td>
                        <td><asp:TextBox ID="txtAdminName" runat="server" onblur="checkname();"></asp:TextBox>&nbsp;&nbsp;<asp:Literal ID="ltlNameStatus" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>密码：</td>
                        <td><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>确认密码：</td>
                        <td><asp:TextBox ID="txtPwdConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>备注：</td>
                        <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>超级管理员</td>
                        <td><asp:CheckBox ID="chkSuper" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <div>
                    <asp:GridView ID="gvwAdminList" runat="server" AutoGenerateColumns='false' 
                        Width="100%" onrowcommand="gvwAdminList_RowCommand" 
                        onrowdatabound="gvwAdminList_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <asp:Label ID="lblNum" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="登录名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("AdminID") %>' Text="删除" OnClientClick='return confirm("确定删除吗？");'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
