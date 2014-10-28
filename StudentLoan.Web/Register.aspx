<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudentLoan.Web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>注册</title>
    <script src="../js/jquery.cityselect.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#bank_area").citySelect(
                {
                    url: "/js/city.min.js"
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap">

        <div class="register">
            <div class="register-form">

                <p class="c-blue">一步注册  轻松贷款</p>

                <div class="reg-step">
                    <div class="step-left">
                        <div class="icon">
                            <h4>1</h4>
                        </div>
                        <p>注册</p>
                    </div>
                    <div class="step-center">
                        <p class="line"></p>
                    </div>
                    <div class="step-right right-outdated">
                        <div class="icon">
                            <h4>3</h4>
                        </div>
                        <p>完成</p>
                    </div>
                </div>

                <h2>注册学子易贷账户</h2>

                <p>注册学子易贷即可贷款了，同学们还等什么？</p>

                <div class="form-horizontal">

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>用户名：</label>

                        <div class="controls text-left">
                            <asp:TextBox ID="txtUserName" runat="server" class="input-large span7" type="text" placeholder="昵称、中文、数字、字母组合" />
                        </div>
                    </div>



                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>密码：</label>

                        <div class="controls text-left">
                            <asp:TextBox ID="txtPassword" runat="server" class="input-large span7" type="password" placeholder="输入密码，长度8-16位，至少包含数字和字母" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>再次输入密码：</label>

                        <div class="controls text-left">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" class="input-large span7" type="password" placeholder="再次输入密码" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>提现密码：</label>

                        <div class="controls text-left">
                            <asp:TextBox  ID="txtDrawMoneyPassword" runat="server" TextMode="Password" class="input-large span7" type="text" placeholder="输入提现密码，长度8-16位，至少包含数字和字母" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>邮箱：</label>

                        <div class="controls text-left">
                            <asp:TextBox ID="txtEmail" runat="server" class="input-large span7" type="text" placeholder="有效邮箱，例如 test.@163.com" />
                        </div>
                    </div>                    

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>所在地区：</label>

                        <div class="controls text-left" id="bank_area">
                            <select id="ddlProvince" name="ddlProvince" class="prov span2"></select>
                            <select id="ddlCity" name="ddlCity" class="city span2" disabled="disabled"></select>
                            <select id="ddlDist" class="dist span3" name="ddlDist" disabled="disabled"></select>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label"><span class="c-red">* </span>籍贯：</label>

                        <div class="controls text-left">
                            <asp:TextBox ID="txtAddress" runat="server" class="input-large span7" type="text" placeholder="户籍地址" />
                        </div>
                    </div>

                    <div class="control-group check-code">
                        <label class="control-label"><span class="c-red">* </span>验证码：</label>
                        <div class="controls text-left">
                            <asp:TextBox ID="txtValidateCode" runat="server" class="input-large span5" type="text" placeholder="输入验证码" />
                            <a class="check-a" href="javascript:;">
                                <img src="tools/validate_code.ashx" onclick="this.src='tools/validate_code.ashx?token='+Math.random();" width="100" height="40" alt="" />
                            </a>
                        </div>
                    </div>

                    <div class="control-group">
                        <div class="controls text-left">
                            <label class="checkbox">
                                <asp:CheckBox ID="ckbAgreement" Checked="true" runat="server" />
                                我已阅读并同意<a href="RegProvision.aspx"><span class="c-blue"> 学子易贷平台用户使用协议</span></a>
                            </label>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls text-left">
                            <p class="w526">
                                <button id="btnRegister" runat="server" type="submit" class="btn btn-primary btn-large btn-block" onserverclick="btnRegister_Click">立即注册</button>
                            </p>
                        </div>

                    </div>

                    <div class="control-group">
                        <div class="controls text-center">
                            <p class="w526">已有账号点此<a class="c-blue" href="login.aspx">登录</a></p>
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>
</asp:Content>
