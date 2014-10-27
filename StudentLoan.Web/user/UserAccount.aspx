<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="StudentLoan.Web.user.UserAccount" %>


<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户总览</title>
    <style type="text/css">
        .cursor {
            color: #FFF !important;
            font-size: 14px !important;
            text-decoration: none !important;
            font-family: '微软雅黑' !important;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#loan").on("click", function () {
                window.location.href = "/LoanList.aspx";
                $(this).addClass("cursor");
            });

            $("#managemoney").on("click", function () {
                window.location.href = "/ManageMoneyNav.aspx";
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="cont clear-top">

            <div class="item all-view">

                <div class="all-left">


                    <div class="user-img">

                        <div class="img">
                            <img width="300" height="236" src="<%=base.GetUserModel().Avatar %>" alt="" />
                        </div>

                        <p class="name">
                            <%=base.GetUserModel().UserName  %>
                        </p>

                    </div>

                    <p class="tc">
                        <span id="loan" class="grade orange"><a href="../LoanList.aspx" class="cursor">贷款</a></span>
                        <span id="managemoney" class="grade green"><a href="../ManageMoneyNav.aspx" class="cursor">理财</a></span>

                    </p>

                </div>

                <div class="all-right">

                    <form class="bs-docs-example">

                        <fieldset>
                            <h3>1.累计信用积分情况</h3>
                            <input class="span6" type="text" placeholder="0分">
                            <span class="help-block">赶快完善资料</span>
                        </fieldset>

                        <fieldset>
                            <h3>2.申请贷款金额</h3>
                            <input class="span6" type="text" placeholder="00.00元">
                        </fieldset>

                        <p class="w460">
                            <button class="mt10 btn btn-large btn-block btn-primary" type="button">点击提现</button>
                        </p>

                        <fieldset>
                            <h3>3.申请理财金额</h3>
                            <input class="span6" type="text" placeholder="00.00元">
                        </fieldset>

                        <p class="w460">
                            <button class="mt10 btn btn-large btn-block btn-primary" type="button">点击充值</button>
                        </p>


                    </form>

                    <div class="w460">

                        <h3>4.借贷表</h3>

                        <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>借款时间</th>
                                            <th>借款金额</th>
                                            <th>还款日期</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <EmptyDataTemplate>
                                <table class="table table-bordered table-striped">
                                    <tbody>
                                        <tr>
                                            <td colspan="3">暂无数据</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td><%#((DateTime)Eval("CreateTime")).ToString("yyyy-MM-dd") %></td>
                                        <td><%#Convert.ToDecimal( Eval("LoanMoney")).ToString("C") %></td>
                                        <td><%#((DateTime)Eval("RepaymentTime")).ToString("yyyy-MM-dd")=="0001-01-01"?"完成还款":((DateTime)Eval("RepaymentTime")).ToString("yyyy-MM-dd") %></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>

                        </StudentLoan:RepeaterPlus>

                        <div class="pagination pagination-centered">
                            <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
                        </div>

                    </div>


                </div>

            </div>

            <div class="clear"></div>

        </div>

    </div>
</asp:Content>
