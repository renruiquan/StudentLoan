<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_2.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.datepickers').datepicker();
            $("#demo1").typeahead();


            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    "idcard": function (gets, obj, curform, datatype) {
                        var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1];
                        var ValideCode = [1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2];
                        if (gets.length == 15) {
                            return isValidityBrithBy15IdCard(gets);
                        } else if (gets.length == 18) {
                            var a_idCard = gets.split("");
                            if (isValidityBrithBy18IdCard(gets) && isTrueValidateCodeBy18IdCard(a_idCard)) {
                                return true;
                            }
                            return false;
                        }
                        return false;
                        function isTrueValidateCodeBy18IdCard(a_idCard) {
                            var sum = 0; // 声明加权求和变量   
                            if (a_idCard[17].toLowerCase() == 'x') {
                                a_idCard[17] = 10;
                            }
                            for (var i = 0; i < 17; i++) {
                                sum += Wi[i] * a_idCard[i];
                            }
                            valCodePosition = sum % 11;
                            if (a_idCard[17] == ValideCode[valCodePosition]) {
                                return true;
                            }
                            return false;
                        }
                        function isValidityBrithBy18IdCard(idCard18) {
                            var year = idCard18.substring(6, 10);
                            var month = idCard18.substring(10, 12);
                            var day = idCard18.substring(12, 14);
                            var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
                            if (temp_date.getFullYear() != parseFloat(year) || temp_date.getMonth() != parseFloat(month) - 1 || temp_date.getDate() != parseFloat(day)) {
                                return false;
                            }
                            return true;
                        }
                        function isValidityBrithBy15IdCard(idCard15) {
                            var year = idCard15.substring(6, 8);
                            var month = idCard15.substring(8, 10);
                            var day = idCard15.substring(10, 12);
                            var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
                            if (temp_date.getYear() != parseFloat(year) || temp_date.getMonth() != parseFloat(month) - 1 || temp_date.getDate() != parseFloat(day)) {
                                return false;
                            }
                            return true;
                        }
                    }
                }
            });
        });
    </script>

    <script type="text/javascript">

        var wait = 300;
        var flag = true;

        function time() {
            if ($("#<%=txtMobile.ClientID%>").val() == "") {
                this.alert("手机号码不能为空");
                return;
            }

            if (flag) {

                flag = false;
                $.post("/tools/message_send.ashx", { "txtMobile": $("#<%=txtMobile.ClientID%>").val(), "type": "CertMobile" }, function (data, status) {
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
                wait = 300;
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
                <li><a href="UserAccountCert.aspx">信用分数表</a></li>
                <li class="active"><a href="UserAccountCert_2.aspx">基本信息认证</a></li>
                <li><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li><a href="UserAccountCert_4.aspx">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="form-horizontal">

                <div class="item">

                    <table>
                        <caption>基本信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 真实姓名：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtTruename" runat="server" class="span5" type="text" placeholder="请输入真实姓名" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 身份证号：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtIdentityCard" runat="server" datatype="*" class="span5" type="text" placeholder="请输入身份证号" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtMobile" runat="server" ajaxurl="/tools/validate_user_mobile.ashx" class="span5" type="text" placeholder="请输入手机号" />
                                            <button id="btnSendMessage" type="button" class="btn btn-info" runat="server" onclick="return time();">获取验证码</button>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">短信验证码：</label>

                                        <div class="controls  text-left">
                                            <asp:TextBox ID="txtValidatecode" runat="server" class="span5" type="text" datatype="*" ajaxurl="/tools/validate_message_send.ashx" placeholder="请输入发送至手机的验证码" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 性别：</label>

                                        <div class="controls text-left">
                                            <asp:DropDownList runat="server" ID="ddlGender">
                                                <asp:ListItem Value="">请选择</asp:ListItem>
                                                <asp:ListItem Value="男">男</asp:ListItem>
                                                <asp:ListItem Value="女">女</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 民族：</label>

                                        <div class="controls text-left">
                                            <asp:DropDownList ID="ddlNation" runat="server">
                                                <asp:ListItem Value="">请选择</asp:ListItem>
                                                <asp:ListItem Text="汉族" Value="汉族" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="阿昌族" Value="阿昌族"></asp:ListItem>
                                                <asp:ListItem Text="白族" Value="白族"></asp:ListItem>
                                                <asp:ListItem Text="保安族" Value="保安族"></asp:ListItem>
                                                <asp:ListItem Text="布朗族" Value="布朗族"></asp:ListItem>
                                                <asp:ListItem Text="布依族" Value="布依族"></asp:ListItem>
                                                <asp:ListItem Text="朝鲜族" Value="朝鲜族"></asp:ListItem>
                                                <asp:ListItem Text="达斡尔族" Value="达斡尔族"></asp:ListItem>
                                                <asp:ListItem Text="傣族" Value="傣族"></asp:ListItem>
                                                <asp:ListItem Text="德昂族" Value="德昂族"></asp:ListItem>
                                                <asp:ListItem Text="侗族" Value="侗族"></asp:ListItem>
                                                <asp:ListItem Text="东乡族" Value="东乡族"></asp:ListItem>
                                                <asp:ListItem Text="独龙族" Value="独龙族"></asp:ListItem>
                                                <asp:ListItem Text="鄂伦春族" Value="鄂伦春族"></asp:ListItem>
                                                <asp:ListItem Text="俄罗斯族" Value="俄罗斯族"></asp:ListItem>
                                                <asp:ListItem Text="鄂温克族" Value="鄂温克族"></asp:ListItem>
                                                <asp:ListItem Text="高山族" Value="高山族"></asp:ListItem>
                                                <asp:ListItem Text="仡佬族" Value="仡佬族"></asp:ListItem>
                                                <asp:ListItem Text="哈尼族" Value="哈尼族"></asp:ListItem>
                                                <asp:ListItem Text="哈萨克族" Value="哈萨克族"></asp:ListItem>
                                                <asp:ListItem Text="赫哲族" Value="赫哲族"></asp:ListItem>
                                                <asp:ListItem Text="回族" Value="回族"></asp:ListItem>
                                                <asp:ListItem Text="基诺族" Value="基诺族"></asp:ListItem>
                                                <asp:ListItem Text="京族" Value="京族"></asp:ListItem>
                                                <asp:ListItem Text="景颇族" Value="景颇族"></asp:ListItem>
                                                <asp:ListItem Text="柯尔克孜族" Value="柯尔克孜族"></asp:ListItem>
                                                <asp:ListItem Text="拉祜族" Value="拉祜族"></asp:ListItem>
                                                <asp:ListItem Text="黎族" Value="黎族"></asp:ListItem>
                                                <asp:ListItem Text="傈僳族" Value="傈僳族"></asp:ListItem>
                                                <asp:ListItem Text="珞巴族" Value="珞巴族"></asp:ListItem>
                                                <asp:ListItem Text="满族" Value="满族"></asp:ListItem>
                                                <asp:ListItem Text="毛南族" Value="毛南族"></asp:ListItem>
                                                <asp:ListItem Text="门巴族" Value="门巴族"></asp:ListItem>
                                                <asp:ListItem Text="蒙古族" Value="蒙古族"></asp:ListItem>
                                                <asp:ListItem Text="苗族" Value="苗族"></asp:ListItem>
                                                <asp:ListItem Text="仫佬族" Value="仫佬族"></asp:ListItem>
                                                <asp:ListItem Text="纳西族" Value="纳西族"></asp:ListItem>
                                                <asp:ListItem Text="怒族" Value="怒族"></asp:ListItem>
                                                <asp:ListItem Text="普米族" Value="普米族"></asp:ListItem>
                                                <asp:ListItem Text="羌族" Value="羌族"></asp:ListItem>
                                                <asp:ListItem Text="撒拉族" Value="撒拉族"></asp:ListItem>
                                                <asp:ListItem Text="畲族" Value="畲族"></asp:ListItem>
                                                <asp:ListItem Text="水族" Value="水族"></asp:ListItem>
                                                <asp:ListItem Text="塔吉克族" Value="塔吉克族"></asp:ListItem>
                                                <asp:ListItem Text="塔塔尔族" Value="塔塔尔族"></asp:ListItem>
                                                <asp:ListItem Text="土族" Value="土族"></asp:ListItem>
                                                <asp:ListItem Text="土家族" Value="土家族"></asp:ListItem>
                                                <asp:ListItem Text="佤族" Value="佤族"></asp:ListItem>
                                                <asp:ListItem Text="锡伯族" Value="锡伯族"></asp:ListItem>
                                                <asp:ListItem Text="乌兹别克族" Value="乌兹别克族"></asp:ListItem>
                                                <asp:ListItem Text="瑶族" Value="瑶族"></asp:ListItem>
                                                <asp:ListItem Text="彝族" Value="彝族"></asp:ListItem>
                                                <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                                                <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                                                <asp:ListItem Text="维吾尔族" Value="维吾尔族"></asp:ListItem>
                                                <asp:ListItem Text="壮族" Value="壮族"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 出生日期：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtBirthday" Style="cursor: pointer" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="请选择" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button id="btnSaveStepOne" onserverclick="btnSaveStepOne_ServerClick" class="mt10 btn btn-large btn-block btn-primary" type="button" runat="server">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>

                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="item">
                    <table>
                        <caption>学校信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>

                                    <%--<p class="mt10">* 学信网系统认证（请输入学信网的账号与密码，以方便我们核对信息，学子易贷保证您的得账户安全及个人隐私）</p>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 账号：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtXuexin" runat="server" class="span5" type="text" placeholder="请输入学信网账号" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 密码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtXuexin_Password" runat="server" class="span5" type="password" placeholder="请输入学信网密码" />
                                        </div>
                                    </div>--%>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 就读学校：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtSchoolName" autocomplete="off" data-provide="typeahead" data-items="10" runat="server" class="span5" type="text" placeholder="请输入学校名称(与学生证上一致)" />
                                        </div>
                                    </div>




                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 学校地址：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtSchoolAdd" runat="server" class="span5" type="text" placeholder="请输入学校地址" />
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 入学日期：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtYearOfAdmission" Style="cursor: pointer" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="请选择" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 学制：</label>

                                        <div class="controls text-left">
                                            <asp:DropDownList runat="server" ID="ddlSchoolSystem">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                                <asp:ListItem Value="3">3年制</asp:ListItem>
                                                <asp:ListItem Value="4">4年制</asp:ListItem>
                                                <asp:ListItem Value="5">5年制</asp:ListItem>
                                                <asp:ListItem Value="6">6年制</asp:ListItem>
                                                <asp:ListItem Value="7">7年制</asp:ListItem>
                                                <asp:ListItem Value="8">8年制</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 学历：</label>

                                        <div class="controls text-left">
                                            <asp:DropDownList runat="server" ID="ddlEducation">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                                <asp:ListItem Value="1">专科</asp:ListItem>
                                                <asp:ListItem Value="2">本科</asp:ListItem>
                                                <asp:ListItem Value="3">硕士（研究生）</asp:ListItem>
                                                <asp:ListItem Value="4">博士</asp:ListItem>
                                                <asp:ListItem Value="5">博士后</asp:ListItem>
                                                <asp:ListItem Value="6">其他</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>




                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span>专业（系）：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtMajor" runat="server" class="span5" type="text" placeholder="请输入专业名称" />
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button id="btnSaveStepTwo" onserverclick="btnSaveStepTwo_ServerClick" runat="server" class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>


                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="item">
                    <table>
                        <caption>联系人信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>

                                    <h3 class="text-left pl20">1.直接亲属联系人</h3>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 姓名：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtRelativeName" runat="server" class="span5" type="text" placeholder="请输入亲属姓名" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 与本人关系：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtRelationtype" runat="server" class="span5" type="text" placeholder="请输入关系" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtRelativeMobile" runat="server" class="span5" type="text" placeholder="请输入亲属手机号码" />
                                        </div>
                                    </div>

                                    <%-- <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 职业：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtRelativeProfession" runat="server" class="span5" type="text" placeholder="请输入亲属职业" />
                                        </div>
                                    </div>--%>


                                    <h3 class="text-left pl20">2.同学（同室）</h3>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 姓名：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtMateName" runat="server" class="span5" type="text" placeholder="请输入同学姓名" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtMateMobile" runat="server" class="span5" type="text" placeholder="请输入同学手机号码" />
                                        </div>
                                    </div>
                                    <h3 class="text-left pl20">3.朋友（必须不是同学）</h3>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 姓名：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtFriendName" runat="server" class="span5" type="text" placeholder="请输入朋友姓名" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-blue">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtFriendMobile" runat="server" class="span5" type="text" placeholder="请输入朋友手机号码" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button id="btnSaveStepFinal" runat="server" onserverclick="btnSaveStepFinal_ServerClick" class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>

                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
