<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentLoan.Web.Admin.Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Author" content="kudychen@gmail.com" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.utils.js"></script>
    <link href="jBox/Skins/Green/jbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jBox/jquery.jBox-2.3.min.js"></script>
    <script type="text/javascript" src="js/admin.js"></script>
    <script type="text/javascript">
        // 初始化下面的变量
        Admin.IsIndexPage = true;
        Admin.IndexStartPage = 'welcome.aspx';
        Admin.LogoutUrl = 'login.html';
    </script>
</head>
<body>
    <div id="header">
        <div id="header-logo">
            <img src="images/logo.gif" alt="logo" width="59" height="64" border="0" />
        </div>
        <div id="header-title">学子易贷管理系统</div>
        <div id="header-info">
            <span style="margin-right: 50px; color: #fff;">管理员：<b><%=base.GetAdminInfo().AdminName %></b> 您好，欢迎登陆使用！</span>
            <a href="javascript:Index.Open('welcome.aspx');" style="margin-right: 10px; color: #fff; font-weight: bold;">后台首页</a>
            <a href="javascript:Index.Open('ChangePassword.aspx');" style="margin-right: 10px; color: #fff; font-weight: bold;">修改密码</a>
            <a href="javascript:Admin.Logout();">
                <img src="images/out.gif" class="middle" alt="安全退出" width="46" height="20" border="0" /></a>
        </div>
    </div>
    <!--//#header-->

    <div id="main">
        <div id="left">
            <div id="menu-container">
                <div class="menu-tit">用户管理</div>
                <div class="menu-list">
                    <div class="top-line"></div>
                    <ul class="nav-items">
                        <li><a href="UserList.aspx" target="content">用户列表</a></li>
                        <li><a href="ChargeList.aspx" target="content">充值记录</a></li>
                        <li><a href="DrawMoneyList.aspx" target="content">提现记录</a></li>
                    </ul>
                </div>
                <div class="menu-tit">借款管理</div>
                <div class="menu-list hide">
                    <div class="top-line"></div>
                    <ul class="nav-items">
                        <li><a href="UserLoanApplyList.aspx" target="content">借款记录</a></li>
                    </ul>
                </div>
                <div class="menu-tit">理财管理</div>
                <div class="menu-list hide">
                    <div class="top-line"></div>
                    <ul class="nav-items">
                        <li><a href="ProductSchemeList.aspx" target="content">方案列表</a></li>
                        <li><a href="UserManageMoneyList.aspx" target="content">理财记录</a></li>
                    </ul>
                </div>
                <div class="menu-tit">系统管理</div>
                <div class="menu-list hide">
                    <div class="top-line"></div>
                    <ul class="nav-items">
                        <li><a href="AdminRoleList.aspx" target="content">角色列表</a></li>
                        <li><a href="AdminList.aspx" target="content">管理员列表</a></li>
                        <li><a href="LoginLog.aspx" target="content">登录日志</a></li>
                    </ul>
                </div>
            </div>
            <div id="menu-bottom"></div>
        </div>
        <!--//#left-->
        <div id="right">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="index-table-top-left"></td>
                    <td class="index-table-top-center">
                        <div class="index-table-welcome-left"></div>
                        <div class="index-table-welcome-center" id="index-title">欢迎登录</div>
                        <div class="index-table-welcome-right"></div>
                        <div class="clear"></div>
                    </td>
                    <td class="index-table-top-right"></td>
                </tr>
                <tr>
                    <td class="index-table-middle-left"></td>
                    <td class="index-table-middle-center" valign="top" id="content-container">
                        <div id="loading">
                            <img src="images/loading.gif" alt="loading" border="0" />
                        </div>
                        <script type="text/javascript">
                            Index.OutputIframe();
                        </script>
                    </td>
                    <td class="index-table-middle-right"></td>
                </tr>
                <tr>
                    <td class="index-table-bottom-left"></td>
                    <td class="index-table-bottom-center"></td>
                    <td class="index-table-bottom-right"></td>
                </tr>
            </table>
        </div>
        <!--//#right-->
        <div class="clear"></div>
    </div>
    <!--//#main-->

    <div id="footer">
        <div id="footer-msg">建议使用 Chrome 或其它主流浏览器，分辨率 1024x768 或更高。 | Copyright &copy; 2014-2020 学子易贷 All Rights Reserved.</div>

    </div>
    <!--//#footer-->
</body>

</html>
