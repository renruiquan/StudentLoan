<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="StatManageMoney.aspx.cs" Inherits="StudentLoan.Web.user.StatManageMoney" %>

<%@ Import Namespace="StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">理财统计</a></li>
            </ul>

        </div>

        <div class="cont">
            <div class="item">
                <table class="table table-bordered table-striped">
                    <caption>个人理财统计</caption>
                    <tbody>
                        <tr>
                            <td>理财总金额
                            </td>
                            <td><%=this.StatUserManageMoney.TotalAmount.Convert<decimal>().ToString("C") %>
                            </td>
                            <td>理财总次数
                            </td>
                            <td><%=this.StatUserManageMoney.TotalCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>总收益
                            </td>
                            <td><%=this.StatUserManageMoney.TotalInterest.Convert<decimal>().ToString("C") %>
                            </td>
                            <td>总收益次数
                            </td>
                            <td><%=this.StatUserManageMoney.TotalEarningsCount %>
                            </td>
                        </tr>
                        <tr>
                            <td>待收收益
                            </td>
                            <td><%=this.WaitTotalInterest.Convert<decimal>().ToString("C") %>
                            </td>
                            <td>正在理财
                            </td>
                            <td><%=this.WaitTotalCount %>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <p>* 总结出笔数=已回收笔数(含坏账已垫付) + 待回收笔数 + 历史遗留无垫付坏账笔数</p>

        </div>

    </div>

</asp:Content>
