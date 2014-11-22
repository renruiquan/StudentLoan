<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ChangeWithDrawPassword.aspx.cs" Inherits="StudentLoan.Web.user.ChangeWithDrawPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        $(function () {
            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    "different": function (gets, obj, curform, regxp) {

                        var checkVal = $.trim($("#" + obj.attr("chekVal")).val());

                        if ((checkVal !== gets) && (gets.length >= 6) && (gets.length <= 18)) {
                            return true;
                        } else {
                            if (checkVal == gets) {
                                $(obj).attr("errormsg", "新密码不能和旧密码相同！");
                            }
                            return false;
                        }

                    }
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">修改提现密码</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="form-horizontal">

                <div class="item">

                    <div id="divOldPassword" runat="server" class="control-group">
                        <label class="control-label">当前密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtOldPassword" CssClass="span5" runat="server" ClientIDMode="Static" TextMode="Password" datatype="*" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">新密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtNewPassword" chekVal="txtOldPassword"  CssClass="span5" runat="server" TextMode="Password" placeholder="6-20个字符，可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" datatype="different" sucmsg="密码验证通过！" tips="6-20个字符，可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" nullmsg="请填写密码！6-18个字符，可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" errormsg="密码必须是6-18个字符！可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">确认密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtConfirmPassword" CssClass="span5" runat="server" TextMode="Password" placeholder="请再次输入你的密码" datatype="*6-18" sucmsg="密码验证通过！" tips="6-20个字符，可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" nullmsg="请填写密码！6-18个字符，可以使用字母数字或符号组合，不建议使用纯数字，纯字母，纯符号！" errormsg="确认密码输入错误！" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w210">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-large btn-block btn-primary" OnClick="btnSubmit_ServerClick" Style="padding: 10px;" Text="确 定"></asp:Button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
