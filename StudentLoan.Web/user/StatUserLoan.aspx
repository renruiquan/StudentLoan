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
                            <td>总借贷额
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?"￥0":this.StatNormalUserLoan.TotalAmount.ToString("C") %>元
                            </td>
                            <td>发布借贷笔数
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?0:this.StatNormalUserLoan.TotalCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>已还本息
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?"￥0":this.StatNormalUserLoan.RepaymentMoney.ToString("C") %>元
                            </td>
                            <td>成功借贷笔数
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?0:this.StatNormalUserLoan.LoanSuccessCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>待还本息
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?"￥0":this.StatNormalUserLoan.WaitMoney.ToString("C") %>元
                            </td>
                            <td>正常还清笔数
                            </td>
                            <td>
                                <%=this.StatNormalUserLoan==null?0:this.StatNormalUserLoan.NormalLoanCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>未还清笔数
                            </td>
                            <td colspan="3">
                                <%=this.StatNormalUserLoan==null?0:this.StatNormalUserLoan.WaitLoanCount %>
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
                            <td>逾期本息
                            </td>
                            <td>
                                <%=this.StatBreakContractUserLoan==null?"￥0":this.StatBreakContractUserLoan.TotalAmount.ToString("C") %>元
                            </td>
                            <td>逾期次数
                            </td>
                            <td>
                                <%=this.StatBreakContractUserLoan==null?0:this.StatBreakContractUserLoan.TotalBreakCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>逾期费用
                            </td>
                            <td>
                                <%=this.StatBreakContractUserLoan==null?"￥0":this.StatBreakContractUserLoan.TotalBreakContract.ToString("C") %>元
                            </td>
                            <td>严重逾期次数
                            </td>
                            <td>
                                <%=this.StatBreakContractUserLoan==null?0:this.StatBreakContractUserLoan.TotalSevereBreakCount %>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

    </div>

</asp:Content>
