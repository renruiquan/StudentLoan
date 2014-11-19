<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="BindMobile.aspx.cs" Inherits="StudentLoan.Web.user.BindMobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 手机绑定</title>

    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        var wait = 60;
        var flag = true;

        function time() {

            if (flag) {

                flag = false;
                $.post("/tools/message_send.ashx", { "txtMobile": $("#txtMobile").val() }, function (data, status) {
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


        $(function () {
            $("#form1").Validform({
                tiptype: 3,
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">手机绑定</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="form-horizontal">

                <div class="item">

                    <div class="control-group">
                        <label class="control-label"></label>
                        <div class="controls">
                            <p>
                                <asp:Literal ID="objLiteral" runat="server"></asp:Literal>
                            </p>

                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">手机号码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtMobile" ClientIDMode="Static" runat="server" class="span5" type="text" placeholder="请输入正确的11位手机号码" datatype="/^1\d{10}$/" />
                            <button id="btnSendMessage" type="button" class="btn btn-info" runat="server" onclick="return time();">发送手机验证码</button>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">验证码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtValidatecode" runat="server" class="span5" type="text" datatype="*" placeholder="请输入发送至手机的验证码" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w210">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_ServerClick" Style="padding: 10px;" CssClass="btn btn-large btn-block btn-primary" Text="确 定"></asp:Button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
