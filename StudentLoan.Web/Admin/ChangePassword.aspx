<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StudentLoan.Web.Admin.ChangePassword" %>


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
            $("#form1").validate({
                rules: {
                    txtConfirmNewPassword: {
                        required: true,
                        equalTo: "#txtNewPassword"
                    }
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container1">

            <div class="location">当前位置：系统管理 -&gt; 修改密码</div>

            <div class="blank10"></div>

            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>修改密码</h3>
                    <div class="bar">
                        <a class="btn-lit" href="Default.aspx"><span>返回</span></a>
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
                                    <th scope="row">旧密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtOldPassword" placeholder="旧密码" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">新密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtNewPassword" name="txtNewPassword" placeholder="新密码" ClientIDMode="Static" runat="server" class="required" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">确认新密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtConfirmNewPassword" name="txtConfirmNewPassword" placeholder="确认新密码" ClientIDMode="Static" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">&nbsp;</th>
                                    <td>
                                        <asp:Button runat="server" ID="btnSubmit" CssClass="button button-primary" Text="更新" OnClick="btnSubmit_Click" />
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
