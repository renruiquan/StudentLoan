<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudentLoan.Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/dialog-plus-min.js"></script>
    <link href="css/ui-dialog.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <title></title>
    <style type="text/css">
            a:hover {cursor:pointer;text-decoration:none;}
    </style>
</head>
<body>
    <form class="form-horizontal" runat="server">
    <%--用户名--%>
        <div class="control-group">
            <label class="control-label" for="txtUserName"></label>
            <div class="controls">
                <asp:TextBox type="text" ID="txtUserName" placeholder="用户名  中文、数字、字母组成" runat="server" />
            </div>
        </div>
    <%--手机--%>
        <div class="control-group">
            <label class="control-label" for="txtUserTelephone"></label>
            <div class="controls">
                <asp:TextBox ID="txtUserTelephone" runat="server"  placeholder="请填写有效手机号码" />
            </div>
        </div>
    <%--邮箱--%> 
         <div class="control-group">
            <label class="control-label" for="txtUserEmail"></label>
            <div class="controls">
                <asp:TextBox ID="txtUserEmail" runat="server"  placeholder="请填写有效邮箱" />
            </div>
        </div>
    <%--密码--%>
         <div class="control-group">
            <label class="control-label" for="txtPassword"></label>
            <div class="controls">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="输入密码  长度6-20位，至少包含数字和字母" />
            </div>
        </div>
    <%--确认密码--%>
         <div class="control-group">
            <label class="control-label" for="txtConfirm_Password"></label>
            <div class="controls">
                <asp:TextBox ID="txtConfirm_Password" runat="server" TextMode="Password" placeholder="确认密码" />
            </div>
        </div>
    <%--是否同意协议--%>
        <div class="control-group">
            <label class="control-label" for="txtValidateCode"></label>
            <div class="controls">
                <asp:CheckBox  ID="ckbAgreement" runat="server"/>我已阅读并同意     
                <a>学子易贷平台用户使用协议</a>           
            </div>
        </div>
    <%--注册按钮--%>
        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnLogin" runat="server" Text="注册" OnClick="btnRegister_Click" />
            </div>
        </div>
    <%--已有账号登陆--%>
        <div class="control-group">
            <div class="controls">
                已有账号
                <a href="login.aspx">登陆</a>
            </div>
        </div>
    </form>
</body>
</html>
