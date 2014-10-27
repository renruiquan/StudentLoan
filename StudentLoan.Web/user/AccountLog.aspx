<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="AccountLog.aspx.cs" Inherits="StudentLoan.Web.user.AccountLog" %>

<%@ Import Namespace="StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户日志</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="AccountLog.aspx">账户日志</a></li>
                <li><a href="Charge.aspx">会员充值</a></li>
                <li><a href="ChargeLog.aspx">充值日志</a></li>
                <li><a href="Withdraw.aspx">会员提现</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>资金余额</th>
                            <th>冻结资金</th>
                            <th>可用资金</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <p><%=(this.GetUserModel().Amount + this.TotalLockMoney).Convert<decimal>().ToString("C") %>元</p>
                            </td>
                            <td>
                                <p><%=this.TotalLockMoney.Convert<decimal>().ToString("C") %>元</p>
                            </td>
                            <td>
                                <p><%=this.GetUserModel().Amount.Convert<decimal>().ToString("C") %>元</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

        </div>

    </div>
</asp:Content>
