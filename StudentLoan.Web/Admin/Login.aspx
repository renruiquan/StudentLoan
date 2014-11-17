<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentLoan.Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Author" content="kudychen@gmail.com" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.utils.js"></script>
    <link href="jBox/Skins/Green/jbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jBox/jquery.jBox-2.3.min.js"></script>
    <script type="text/javascript" src="js/admin.js"></script>
    <script type="text/javascript">
        // 初始化下面的变量
        Admin.IsLoginPage = true;
        Admin.IndexUrl = 'index.html';
        Admin.LoginUrl = 'Login.aspx';
        Admin.VerifyImageUrl = '/tools/validate_code.ashx';
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <table class="login" cellpadding="0" cellspacing="0">
            <!-- top -->
            <tr>
                <td class="login_top">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_title">学子易贷后台管理 V1.0</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <!-- middle -->
            <tr>
                <td class="login_middle_1"></td>
            </tr>
            <tr>
                <td valign="top" class="login_middle_2">
                    <!-- login form -->
                    <table id="login_form" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label">用&nbsp;&nbsp;&nbsp;&nbsp;户：</td>
                            <td>
                                <asp:TextBox ID="UserName" ClientIDMode="Static" CssClass="login_input" size="20" MaxLength="20" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
                            <td>
                                <asp:TextBox ID="Password" ClientIDMode="Static" CssClass="login_input" TextMode="Password" size="20" MaxLength="20" runat="server"></asp:TextBox>
                                <img src="images/lock.gif" width="19" height="18" alt="密码" class="middle" /></td>
                        </tr>
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label">验证码：</td>
                            <td>
                                <asp:TextBox runat="server" type="text" id="txtValidateCode" class="login_input"  size="20" maxlength="4" /></td>
                        </tr>
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label"></td>
                            <td>
                                <img id="verify_image" class="middle hide" align="middle" src="" width="130" height="53" alt="点击刷新" />&nbsp;&nbsp;
                    <a id="refresh_verify_image" class="middle" href="javascript:void(0);">换一张</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label"></td>
                            <td title="请不要在公共电脑上使用此功能！">
                                <input id="rememberMe" type="checkbox" />
                                <label for="rememberMe">两周内自动登录</label></td>
                        </tr>
                        <tr>
                            <td class="login_form_pad"></td>
                            <td class="login_form_label"></td>
                            <td><a id="login_btn" class="btn" href="javascript:void(0);" runat="server" onserverclick="btnLogin_Click"><span>登录</span></a></td>
                        </tr>
                        <tr>
                            <td id="login_auto_height" colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="login_middle_3">
                    <div class="login_welcome"></div>
                </td>
            </tr>
            <!-- bottom -->
            <tr>
                <td class="login-bottom">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="login_form_pad"></td>
                            <td>Copyright &copy; 2005-2012 www.kudystudio.com All Rights Reserved.</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
