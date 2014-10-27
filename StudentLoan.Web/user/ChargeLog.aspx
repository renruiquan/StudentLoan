<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ChargeLog.aspx.cs" Inherits="StudentLoan.Web.user.ChargeLog" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Import Namespace="StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 充值日志</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="AccountLog.aspx">账户日志</a></li>
                <li><a href="Charge.aspx">会员充值</a></li>
                <li class="active"><a href="javascript:;">充值日志</a></li>
                <li><a href="Withdraw.aspx">会员提现</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <StudentLoan:RepeaterPlus ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>订单号</th>
                                    <th>充值金额</th>
                                    <th>建档日期</th>
                                    <th>支付日期</th>
                                    <th>状态</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("OrderNo")%></td>
                            <td><%#Eval("ChargeMoney").Convert<decimal>().ToString("C")%></td>
                            <td><%#Eval("CreateTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                            <td><%#Eval("PayTime").Convert<DateTime>().ToString("yyyy-MM-dd") =="0001-01-01"?"":Eval("PayTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                            <td><%# this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
                            <td>
                                <asp:Literal ID="objLiteral" runat="server"></asp:Literal></td>

                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="6">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </StudentLoan:RepeaterPlus>

            </div>

            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>
        </div>

    </div>
</asp:Content>
