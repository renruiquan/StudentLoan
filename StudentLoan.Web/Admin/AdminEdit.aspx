<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="StudentLoan.Web.Admin.AdminEdit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="js/jquery.validate.js"></script>
    <script type="text/javascript" src="js/jquery.validate.cn.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form1").validate();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">

            <div class="location">当前位置：系统管理 -&gt; 添加管理员</div>

            <div class="blank10"></div>

            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>管理员信息</h3>
                    <div class="bar">
                        <a class="btn-lit" href="AdminList.aspx"><span>返回</span></a>
                    </div>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt form">
                        <table class="data-form" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <th scope="row">角色：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlRoleId" runat="server">
                                            <asp:ListItem Value="1">超级管理员</asp:ListItem>
                                            <asp:ListItem Value="2">系统管理员</asp:ListItem>
                                            <asp:ListItem Value="3">普通管理员</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">登录名：</th>
                                    <td>
                                        <asp:TextBox ID="txtAdminName" placeholder="管理员名称" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtPassword" placeholder="密码" runat="server" class="required" /></td>
                                </tr>

                                <tr>
                                    <th scope="row">真实姓名：</th>
                                    <td>
                                        <asp:TextBox ID="txtRealName" placeholder="真实姓名" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">联系电话：</th>
                                    <td>
                                        <asp:TextBox ID="txtTelephone" placeholder="联系电话" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">邮箱：</th>
                                    <td>
                                        <asp:TextBox ID="txtEmail" placeholder="邮箱" runat="server" class="required email" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">状态：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlIsLock" runat="server">
                                            <asp:ListItem Value="1">启用</asp:ListItem>
                                            <asp:ListItem Value="0">禁用</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th scope="row">&nbsp;</th>
                                    <td>
                                        <asp:Button runat="server" ID="btnSubmit" CssClass="button button-primary" Text="确定" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
