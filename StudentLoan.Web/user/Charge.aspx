<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="StudentLoan.Web.user.Charge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户充值</title>

    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        $(function () {
            $(".bank").on("click", function () {
                $(this).addClass("active").siblings().removeClass("active");
            });

            $("#form1").attr("target", "_blank");
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
        $(function () {
            $("#form1").attr("onsubmit", "return checksubmit()");

        });

        function checksubmit() {

            var amount = $("#<%=Amount.ClientID%>").val();

            if (amount < 10) {
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="AccountLog.aspx">账户日志</a></li>
                <li class="active"><a href="javascript:;">会员充值</a></li>
                <li><a href="ChargeLog.aspx">充值日志</a></li>
                <li><a href="Withdraw.aspx">会员提现</a></li>
            </ul>

        </div>

        <div>

            <div class="cont">

                <div class="item">

                    <h3>1.温馨提示</h3>

                    <div class="p20 border-radius">

                        <p>1、 请注意您的银行卡充值限制，以免造成不便。</p>

                        <p>2、 如归充值金额没有及时到账，请和客服联系。</p>

                    </div>
                </div>

                <div class="item">

                    <h3>2.通过银行储蓄卡充值</h3>

                    <div class="select-bank">

                        <label class="bank active">
                            <input type="radio" value="ICBC" name="bank" checked="checked" />
                            <img src="../css/img/banks/bank_ICBC.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="ABC" name="bank" />
                            <img src="../css/img/banks/bank_ABC.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="CCB" name="bank" />
                            <img src="../css/img/banks/bank_CCB.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="BCOM" name="bank" />
                            <img src="../css/img/banks/bank_BCOM.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="BOC" name="bank" />
                            <img src="../css/img/banks/bank_BOC.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="CMB" name="bank" />
                            <img src="../css/img/banks/bank_CMB.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="CMBC" name="bank" />
                            <img src="../css/img/banks/bank_CMBC.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="CEBB" name="bank" />
                            <img src="../css/img/banks/bank_CEBB.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="CIB" name="bank" />
                            <img src="../css/img/banks/bank_CIB.jpg" alt="" />
                        </label>
                        <label class="bank">
                            <input type="radio" value="PSBC" name="bank" />
                            <img src="../css/img/banks/bank_PSBC.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="SPABANK" name="bank" />
                            <img src="../css/img/banks/bank_SPABANK.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="ECITIC" name="bank" />
                            <img src="../css/img/banks/bank_ECITIC.jpg" alt="" />
                        </label>
                        <label class="bank">
                            <input type="radio" value="GDB" name="bank" />
                            <img src="../css/img/banks/bank_GDB.jpg" alt="" />
                        </label>

                        <label class="bank">
                            <input type="radio" value="SDB" name="bank" />
                            <img src="../css/img/banks/bank_SDB.jpg" alt="" />
                        </label>
                        <label class="bank">
                            <input type="radio" value="HXB" name="bank" />
                            <img src="../css/img/banks/bank_HXB.jpg" alt="" />
                        </label>
                        <label class="bank">
                            <input type="radio" value="SPDB" name="bank" />
                            <img src="../css/img/banks/bank_SPDB.jpg" alt="" />
                        </label>
                        <label class="bank">
                            <input type="radio" value="BEA" name="bank" />
                            <img src="../css/img/banks/bank_BEA.jpg" alt="" />
                        </label>
                    </div>

                </div>

                <div class="item">
                    <h3>3.填写充值金额</h3>

                    <p>单笔充值金额必须≥10元</p>

                    <p class="w240">
                        <asp:TextBox ID="Amount" runat="server" class="input input-block input-large" type="text"
                            placeholder="请填写充值金额..." datatype="/^[1-9]\d{1,5}$/" sucmsg="充值金额验证通过！" tips="请填写充值金额" nullmsg="充值金额不能为空" errormsg="充值金额填写错误" />
                        元
                    </p>

                    <p class="w210">
                        <button id="btnSubmit" runat="server" class="btn btn-large btn-block btn-primary" type="button" onclick="" onserverclick="btnSubmit_ServerClick">确 定</button>
                    </p>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
