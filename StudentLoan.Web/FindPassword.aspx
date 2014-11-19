﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="StudentLoan.Web.FindPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>找回密码</title>

    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        var wait = 60;
        var flag = true;

        function time() {

            if ($("#<%=txtMobile.ClientID%>").val() == "") {
                this.alert("手机号码不能为空");
                return;
            }

            if (flag) {

                flag = false;
                $.post("/tools/message_send.ashx", { "txtMobile": $("#<%=txtMobile.ClientID%>").val(), "type": "findpassword" }, function (data, status) {
                    if (status != "success") {
                        alert("短信发送失败");
                        return;
                    } else {
                        alert(data);
                    }
                });
            }

            var btn = $("#<%=btnSendMessage.ClientID%>");
            if (wait == 0) {
                btn.removeAttr("disabled");
                btn.text("发送手机验证码");
                wait = 60;
            } else {
                btn.attr("disabled", true);
                btn.text("重新发送(" + wait + ")");
                wait--;
                setTimeout(function () {
                    time()
                },
                1000)
            }
        }

        $("#form1").Validform({
            tiptype: 3,
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr class="line" />

    <div class="container-wrap">

        <div class="register">

            <div class="wrapper border-radius bgf">
                <div class="ptb10 bdbc">
                    <h4>找回登录密码</h4>
                </div>

                <div class="register-form find-pwd">

                    <div class="form-horizontal">

                        <div class="control-group">
                            <label class="control-label"><span class="c-red">* </span>要找回的帐号：</label>

                            <div class="controls text-left">
                                <asp:TextBox ID="txtUserName" runat="server" class="w300" type="text" placeholder="昵称、中文、数字、字母组合" datatype="*" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">
                                <span class="c-red">* </span>
                                发送至手机：</label>

                            <div class="controls text-left">
                                <asp:TextBox ID="txtMobile" runat="server" class="" type="text" placeholder="有效手机号码" datatype="n11" />
                                <span class="check-a">
                                    <button id="btnSendMessage" runat="server" type="button" class="btn btn-success" onclick="return time();">发送短信验证码</button>
                                </span>
                            </div>
                        </div>

                        <div class="control-group check-code">
                            <label class="control-label"><span class="c-red">* </span>短信验证码：</label>
                            <div class="controls text-left">
                                <asp:TextBox ID="txtValidatecode" runat="server" class="" type="text" datatype="*6-18" placeholder="请输入您收到的短信验证码" />
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="controls text-left">
                                <p class="w3">
                                    <button type="button" id="btnFindPassword" runat="server" onserverclick="btnFindPassword_ServerClick" class="btn btn-primary">找回密码</button>
                                </p>
                            </div>

                        </div>


                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
