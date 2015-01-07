<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FindWithDrawPassword.aspx.cs" Inherits="StudentLoan.Web.user.FindWithDrawPassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>找回密码</title>

    <link rel="stylesheet" type="text/css" href="/js/Validform/css/Validform.css" />
    <script src="/js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        var wait = 60;
        var flag = true;

        $(function () {

            $("#form1").Validform({
                tiptype: 3,
            });


            $("#txtMobile").attr("ajaxurl", "/tools/validate_find_password.ashx?txtusername="+"<%=base.GetUserModel().UserName%>");

            $("#txtMobile").on("blur", function () {
                $.post("/tools/validate_find_password.ashx", { "param": $(this).val(), "txtusername": "<%=base.GetUserModel().UserName%>" }, function (data, status) {
                    if (status != "success") {
                        alert("手机号码校验失败");
                        return;
                    } else {
                        var result = $.parseJSON(data);
                        var btn = $("#<%=btnSendMessage.ClientID%>");
                        if (result.status == "n" && result.type == "1") {
                            btn.attr("disabled", true);
                        } else {
                            btn.attr("disabled", false);
                        }
                    }
                });
            });
        });

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr class="line" />

    <div class="container-wrap">

        <div class="register">

            <div class="wrapper border-radius bgf">
                <div class="ptb10 bdbc">
                    <h4>找回提现密码</h4>
                </div>

                <div class="register-form find-pwd">

                    <div class="form-horizontal">

                        <div class="control-group">
                            <label class="control-label">
                                <span class="c-red">* </span>
                                发送至手机：</label>

                            <div class="controls text-left">
                                <asp:TextBox ID="txtMobile" ClientIDMode="Static"  runat="server" class="" type="text" placeholder="有效手机号码" datatype="/^1\d{10}$/" />
                                <span class="check-a">
                                    <button id="btnSendMessage" runat="server" type="button" class="btn btn-success" onclick="return time();">发送短信验证码</button>
                                </span>
                            </div>
                        </div>

                        <div class="control-group check-code">
                            <label class="control-label"><span class="c-red">* </span>短信验证码：</label>
                            <div class="controls text-left">
                                <asp:TextBox ID="txtValidatecode" runat="server" class="" datatype="/^[0-9a-zA-Z]{4}$/" type="text" placeholder="请输入您收到的短信验证码" />
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
