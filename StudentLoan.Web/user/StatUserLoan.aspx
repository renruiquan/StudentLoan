<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="StatUserLoan.aspx.cs" Inherits="StudentLoan.Web.user.StatUserLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>雪中送炭 - 借款统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">贷款统计</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered table-striped">
                    <caption>还款统计</caption>
                    <tbody>
                        <tr>
                            <td>
                                <p>总借贷额</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.TotalAmount.ToString("C") %>元</p>
                            </td>
                            <td>
                                <p>发布借贷笔数</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.TotalCount %></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>已还本息</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.RepaymentMoney.ToString("C") %>元</p>
                            </td>
                            <td>
                                <p>成功借贷笔数</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.LoanSuccessCount %></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>待还本息</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.WaitMoney.ToString("C") %>元</p>
                            </td>
                            <td>
                                <p>正常还清笔数</p>
                            </td>
                            <td>
                                <p><%=this.StatNormalUserLoan.NormalLoanCount %></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>未还清笔数</p>
                            </td>
                            <td colspan="3">
                                <p><%=this.StatNormalUserLoan.WaitLoanCount %></p>
                            </td>
                        </tr>

                    </tbody>
                </table>
            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered table-striped">
                    <caption>逾期统计</caption>
                    <tbody>
                        <tr>
                            <td>
                                <p>逾期本息</p>
                            </td>
                            <td>
                                <p><%=this.StatBreakContractUserLoan.TotalAmount.ToString("C") %>元</p>
                            </td>
                            <td>
                                <p>逾期次数</p>
                            </td>
                            <td>
                                <p><%=this.StatBreakContractUserLoan.TotalBreakCount %></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>逾期费用</p>
                            </td>
                            <td>
                                <p><%=this.StatBreakContractUserLoan.TotalBreakContract.ToString("C") %>元</p>
                            </td>
                            <td>
                                <p>严重逾期次数</p>
                            </td>
                            <td>
                                <p><%=this.StatBreakContractUserLoan.TotalSevereBreakCount %></p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

    </div>

</asp:Content>
