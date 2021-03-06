﻿<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="StudentLoan.Web.user.Withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 会员提现</title>

    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/jquery.cityselect.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#bank_area").citySelect(
                {
                    url: "/js/city.min.js"
                });

            $("#form1").Validform({
                tiptype: 3
            });

            $("#<%=txtWithdrawMoney.ClientID%>").val(" ");
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

                    <h3>选择银行卡</h3>

                    <asp:Repeater ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <div class="p20">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <label class="border-radius select-bank-cards">
                                <asp:Literal ID="litBankID" runat="server"></asp:Literal>

                                <span class="bank-name">
                                    <asp:Literal runat="server" ID="objLiteral"></asp:Literal>
                                </span>
                                <span>卡号：<%#Eval("BankCardNo") %></span></label>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>

                <div class="item">
                    <div class="control-group">
                        <label class="control-label">账户余额：</label>

                        <div class="controls">
                            <asp:Label ID="lblAmount" runat="server" Style="line-height: 30px;">0元</asp:Label>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">提现金额：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtWithdrawMoney" runat="server" autocomplete="off" placeholder="请填写提现金额..."
                                datatype="/^\d+$/" sucmsg="提现金额验证通过！" tips="请填写充值金额" nullmsg="提现金额不能为空" errormsg="提现金额填写错误" />
                            元
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">提现密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtDrawMoneyPassword" autocomplete="off" runat="server" TextMode="Password" placeholder="请填写提现密码..." datatype="*" />
                            <a href="FindWithDrawPassword.aspx">忘记密码？</a>
                        </div>
                    </div>

                    <div class="control-group">

                        <div class="controls">
                            <p>
                                <button id="btnWithdraw" runat="server" onserverclick="btnWithdraw_ServerClick" class="btn btn-large btn-primary" type="button">确 定</button>
                            </p>
                        </div>
                    </div>

                </div>


            </div>
        </div>
    </div>
</asp:Content>
