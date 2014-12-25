<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserBillList_2.aspx.cs" Inherits="StudentLoan.Web.user.UserBillList_2" %>


<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>我的账单 - 已出账单</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">我的账单</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="tabbable">
                <ul class="nav nav-tabs">
                    <li><a href="UserBillList.aspx">已出账单</a></li>
                    <li class="active"><a href="UserBillList_2.aspx">未出账单</a></li>
                </ul>
                <div class="tab-content">

                    <div class="tab-pane active" id="tab1">
                        <div class="item">
                            <StudentLoan:RepeaterPlus ID="objRepeater1" runat="server" OnItemDataBound="objRepeater1_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>名称</th>
                                                <th>借款编号</th>
                                                <th>期数</th>
                                                <th>账单日期</th>
                                                <th>还款日期</th>
                                                <th>当月还款金额</th>
                                                <th>服务费</th>
                                                <th>逾期罚息</th>
                                                <th>操作</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <EmptyDataTemplate>
                                    <table class="table table-bordered table-striped">
                                        <tbody>
                                            <tr>
                                                <td colspan="9">暂无数据</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td><%#Eval("ProductName")%></td>
                                            <td><%#Eval("LoanNo") %></td>
                                            <td><%#Eval("CurrentAmortization") %>/<%#Eval("TotalAmortization") %>期</td>
                                            <td><%#((DateTime)Eval("RepaymentTime")).ToString("yyyy-MM-dd") %></td>
                                            <td><%#((DateTime)Eval("CreateTime")).ToString("yyyy-MM-dd")=="0001-01-01"?"":((DateTime)Eval("CreateTime")).ToString("yyyy-MM-dd") %></td>
                                            <td><%#Convert.ToInt32(Eval("CurrentAmortization"))==Convert.ToInt32(Eval("TotalAmortization"))?Convert.ToDecimal( Eval("LoanMoney")).ToString("C"):"￥0" %></td>
                                            <td><%#Convert.ToDouble(Eval("Interest")).ToString("C")%></td>
                                            <td><%#Convert.ToDouble(Eval("BreakContract")).ToString("C") %></td>

                                            <td>
                                                <asp:Literal ID="objLiteral" runat="server">还款</asp:Literal>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                            </table>
                                </FooterTemplate>
                            </StudentLoan:RepeaterPlus>
                        </div>

                    </div>

                    <div class="tab-pane" id="tab2">

                        <div class="item">
                        </div>

                    </div>

                </div>
            </div>


            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>

        </div>
    </div>
</asp:Content>
