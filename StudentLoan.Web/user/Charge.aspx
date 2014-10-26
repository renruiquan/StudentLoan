<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="StudentLoan.Web.user.Charge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户充值</title>
    <script type="text/javascript">
        $(function () {
            $(".bank").on("click", function () {
                $(this).addClass("active").siblings().removeClass("active");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="javascript:;">账户日志</a></li>
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

                        <p>@ 请注意您的银行卡充值限制，以免造成不便。</p>

                        <p>@ 如归充值金额没有及时到账，请和客服联系。</p>

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

                    <p>单笔充值金额必须≥10元（只能有两位小数，如：100.12），<a href="javascript:;">各大银行每日充值限额</a></p>

                    <p class="w240">
                        <asp:TextBox ID="Amount" runat="server" class="input input-block input-large" type="text"
                            placeholder="请填写充值金额..." />
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
