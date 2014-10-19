<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="StudentLoan.Web.Admin.welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Author" content="kudychen@gmail.com" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.utils.js"></script>
    <link href="jBox/Skins/Green/jbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jBox/jquery.jBox-2.3.min.js"></script>
    <script type="text/javascript" src="js/admin.js"></script>
    <script type="text/javascript">
        // 只调用最顶的jBox
        if (top.jBox != undefined) {
            window.jBox = top.jBox;
        }

        Index.SetTitle('后台首页');

    </script>
</head>
<body>
    <div class="container">
        <div class="location">当前位置：后台首页</div>

        <table class="hide" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="62" height="55" valign="middle">
                    <img src="images/title.gif" width="54" height="55" alt="" /></td>
                <td valign="top" style="line-height: 20px;">为了账号的安全，如果下面的登录情况不正常，建议您马上<a href="" class="txt-blue">修改密码</a>。
                </td>
            </tr>
        </table>

        <div class="blank10"></div>

        <div class="box">
            <div class="box-title txt-blue-b">您的角色</div>
            <div class="box-content">
                <i><%=base.GetAdminInfo().RoleName %></i>
            </div>
        </div>

        <div class="blank10"></div>

        <div class="box">
            <div class="box-title txt-blue-b">登录情况</div>
            <div class="box-content">
                <i>登录总数：</i><%=this.LoginCount %> 次<br />
                <i>本次登录IP：</i><%=Request.UserHostAddress %><br />
                <i>本次登录时间：</i><%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %><br />
                <i>上次登录IP：</i><%=this.LoginInfo.UserIP %><br />
                <i>上次登录时间：</i><%=this.LoginInfo.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %>
            </div>
        </div>

        <div class="blank10"></div>

        <img src="images/ts.gif" style="margin-bottom: -2px;" width="16" height="16" alt="tip" />
        提示：为了账号的安全，如果上面的登录情况不正常，建议您马上<a href="ChangePassword.aspx">【修改密码】</a>。
    
    <div class="blank10"></div>
        <div class="line"></div>
        <div class="blank10"></div>

        <img src="images/icon-mail.gif" style="margin-bottom: -1px;" width="16" height="11" alt="mail" />
        邮箱：290493463@qq.com<br />
    </div>
</body>
</html>
