<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="StudentLoan.Web.user.Withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 会员提现</title>
    <script src="../js/jquery.cityselect.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#bank_area").citySelect(
                {
                    url: "/js/city.min.js",
                    prov: "<%=this.BankModel.BankProvince%>", //省份 
                    city: "<%=this.BankModel.BankCity%>", //城市
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="AccountLog.aspx">账户日志</a></li>
                <li><a href="Charge.aspx">会员充值</a></li>
                <li><a href="ChargeLog.aspx">充值日志</a></li>
                <li class="active"><a href="javascript:;">会员提现</a></li>
            </ul>

        </div>

        <div class="form-horizontal">

            <div class="cont">

                <div class="item">

                    <h3>1.温馨提示</h3>

                    <div class="p20 border-radius">

                        <p>@ 请输入您要提现的金额，以及正确无误的银行账号信息。</p>

                        <p>@ 我们将在1个工作日之内，将钱转入您指定的银行账号。</p>

                        <p class="c-blue">
                            @ 重要！！推荐银行（即下拉菜单中可直接选择银行）不需要填写开户行支行信息，不在此列的其他银行则需要填写开户行支行信息。如果
                                您填写的开户行支行不正确，提现交易将无法成功，提现费用不予返还。如果不确定开户行支行名称，可以打电话到当地银行的营业网点查询
                                或者上网查询。
                        </p>

                    </div>
                </div>

                <div class="item">
                    <h3>2.填写提款金额</h3>

                    <p>单笔充值金额必须≥10元（只能有两位小数，如：100.12）</p>

                    <p class="w240">
                        <asp:TextBox runat="server" ID="WithdrawMoney" class="input input-block input-large" type="text"
                            placeholder="只能有两位小数，如：100.12" />
                        元
                    </p>
                </div>

                <div class="item">

                    <h3>3.填写用户开户信息</h3>

                    <div class="control-group">
                        <label class="control-label" for="TrueName">开户名：</label>
                        <div class="controls">
                            <asp:TextBox runat="server" type="text" ID="TrueName" placeholder="请填写真实姓名" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="">选择银行：</label>
                        <div class="controls">
                            <asp:HiddenField ID="hidBankId" runat="server" />
                            <asp:DropDownList ID="ddlBankTypeList" runat="server">
                            </asp:DropDownList>
                            提现时间为一个工作日
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="">开户行所在地：</label>
                        <div class="controls" id="bank_area">
                            <select id="ddlProvince" name="ddlProvince" class="prov span2"></select>
                            <select id="ddlCity" name="ddlCity" class="city span3"></select>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="">银行卡号：</label>
                        <div class="controls">
                            <asp:TextBox ID="txtCardNo" runat="server" class="span5" type="text" value="" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="">确认卡号：</label>
                        <div class="controls">
                            <asp:TextBox ID="txtConfirmCardNo" runat="server" class="span5" type="text" value="" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>
                        <div class="controls">
                            <p class="c-blue">警告：禁止信用卡套现、虚假交易等行为，一经确认，将终止该用户使用</p>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>
                        <div class="controls">
                            <p class="w210">
                                <button id="btnWithdraw" runat="server" onserverclick="btnWithdraw_ServerClick" class="btn btn-large btn-block btn-primary" type="button">申请提现</button>
                            </p>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
