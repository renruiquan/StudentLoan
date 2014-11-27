<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StudentLoan.Web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>登录</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap mb0">
        <div class="login">
            <div class="login-form">

                <h2>账号登陆</h2>

                <p>美好故事从这里开始·学子易贷</p>
                <div class="control-group">
                    <asp:TextBox ID="txtUserName" class="input-large span6" placeholder="请输入用户名、手机号码、邮箱登录" runat="server" />
                </div>
                <div class="control-group">
                    <asp:TextBox ID="txtPassword" class="input-large span6" TextMode="Password" placeholder="输入密码" runat="server" />
                </div>
                <div class="control-group check-code">
                    <asp:TextBox ID="txtValidateCode" class="input-large span5" placeholder="输入验证码" runat="server" />
                    <a class="check-a" href="javascript:;">
                        <img src="tools/validate_code.ashx" onclick="this.src='tools/validate_code.ashx?token='+Math.random();" width="100" height="40" alt="" />
                    </a>
                </div>
                <div class="control-group">
                    <label class="checkbox">
                        <input type="checkbox" checked>
                        <span class="c-black">记住登录状态 <a href="FindPassword.aspx"><span class="c-blue">忘记密码？</span></a>
                        </span>
                    </label>
                </div>
                <div class="control-group">
                    <button type="submit" class="btn btn-primary btn-large btn-block" runat="server" onserverclick="btnLogin_Click">立即登陆</button>
                </div>
                <div class="control-group">
                    <a class="btn dark-gray btn-large btn-block" href="Register.aspx">注册新账号</a>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
