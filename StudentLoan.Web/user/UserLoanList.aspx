<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserLoanList.aspx.cs" Inherits="StudentLoan.Web.user.UserLoanList" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>雪中送炭 - 借款记录</title>
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.datepickers').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">借款记录</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="text-center form-inline">
                <div style="margin: 0 0 20px;">
                    <span>时间：</span>
                    <asp:TextBox ID="txtStartTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="起始日期" />
                    <span>- </span>
                    <asp:TextBox ID="txtEndTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="结束日期" />
                    <span>借款类型：</span>
                    <asp:DropDownList runat="server" ID="ddlLoanCategory">
                        <asp:ListItem Value="">全部分类</asp:ListItem>
                        <asp:ListItem Value="1">因为爱情（恋爱贷款）</asp:ListItem>
                        <asp:ListItem Value="2">游山玩水（旅游贷款）</asp:ListItem>
                        <asp:ListItem Value="3">时尚达人（购物贷款）</asp:ListItem>
                        <asp:ListItem Value="4">追求自我（娱乐贷款）</asp:ListItem>
                        <asp:ListItem Value="5">急人所急（应急贷款）</asp:ListItem>
                    </asp:DropDownList>
                    <button runat="server" onserverclick="btnSearch_Click" class="btn btn-primary" type="button">查 询</button>
                </div>
            </div>

            <div class="item">
                <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>借款编号</th>
                                    <th>借款金额</th>
                                    <th>年费率</th>
                                    <th>申请时间</th>
                                    <th>应还金额</th>
                                    <th>已还</th>
                                    <th>借款状态</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="8">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("LoanNo") %></td>
                                <td><%#Convert.ToDecimal( Eval("LoanMoney")).ToString("C") %></td>
                                <td><%#Convert.ToDouble(Eval("AnnualFee")).ToString("P2") %></td>
                                <td><%#((DateTime)Eval("CreateTime")).ToString("yyyy-MM-dd") %></td>
                                <td><%#Convert.ToDouble(Eval("ShouldRepayMoney")).ToString("C") %></td>
                                <td><%#Eval("AlreadyAmortization") %>/<%#Eval("TotalAmortization") %>期</td>
                                <td><%# this.GetStatusName(Convert.ToInt32(Eval("Status"))) %></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>

                </StudentLoan:RepeaterPlus>
            </div>

            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="8" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>

        </div>
    </div>

</asp:Content>
