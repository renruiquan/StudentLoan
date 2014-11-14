<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="StudentLoan.Web.user.UserAccount" %>


<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>
<%@ Import Namespace="StudentLoan.Common" %>

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

            <div class="item all-view-two">

                <div class="user-info">
                    <div class="media">
                        <a class="pull-left" href="AvatarUpload.aspx">
                            <img src="<%=string.IsNullOrEmpty(this.UserModel.Avatar)==true?"../css/img/admin/balance.png":this.UserModel.Avatar %>" alt="" />
                        </a>

                        <div class="media-body">
                            <h4 class="media-heading"><%=this.UserModel.TrueName %>同学 <span>，欢迎来到个人中心</span></h4>

                            <p class="c-gray">
                                <span>账户名：<%=this.UserModel.UserName %></span>
                                <span>上次登录时间：<%=this.UserLoginLogModel.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %></span>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="my-project">

                    <div class="item balance">
                        <div class="title">
                            <h3>
                                <i>
                                    <img src="../css/img/admin/balance.png" alt="" />
                                </i>
                                账户余额
                            </h3>
                        </div>

                        <div class="number">
                            <strong><%=this.UserModel.Amount.Convert<double>().ToString("C") %></strong><span>元</span>
                        </div>

                        <div class="operation">
                            <a class="btn btn-primary" href="../LoanList.aspx">贷款</a>
                            <a class="btn btn-primary" href="../ManageMoneyNav.aspx">理财</a>
                            <a class="btn btn-primary" href="Charge.aspx">充值</a>
                            <a class="btn btn-primary" href="Withdraw.aspx">提现</a>
                        </div>

                    </div>

                    <div class="item diamond">
                        <div class="title">
                            <h3>
                                <i>
                                    <img src="../css/img/admin/balance2.png" alt="" />
                                </i>
                                聚宝盆
                            </h3>
                        </div>

                        <div class="number">
                            <p><%=this.UserEarningsModel.CreateTime.Month %>月<%=this.UserEarningsModel.CreateTime.Day %>日 收益：<strong><%=this.UserEarningsModel.Amount.Convert<double>().ToString("C") %></strong>元</p>

                            <p>累计收入：<strong><%=this.UserTotalEarnings.Convert<double>().ToString("C") %></strong>元</p>
                        </div>

                        <div class="operation">
                            <a class="btn btn-primary" href="EarningsList.aspx">管理</a>
                        </div>

                    </div>

                    <div class="item integral">
                        <div class="title">
                            <h3>
                                <i>
                                    <img src="../css/img/admin/balance3.png" alt="" />
                                </i>
                                学子易贷积分
                            </h3>
                        </div>

                        <div class="number">
                            <strong><%=base.UserModel.Point %></strong><span>分</span>

                            <p>(积分越高贷款金额越高，选择方式也越多）</p>
                        </div>

                        <div class="operation">
                            <a class="btn btn-primary" href="UserAccountCert.aspx">完善资料</a>
                        </div>

                    </div>

                    <div class="clear"></div>

                </div>


                <div class="">

                    <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped user-table">
                                <caption>最近借款记录</caption>
                                <thead>
                                    <tr>
                                        <th>借款时间</th>
                                        <th>借款金额</th>
                                        <th>还款进度</th>
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
                                    <td>已还<%#Eval("AlreadyAmortization")%>期 / 共<%#Eval("TotalAmortization") %>期</td>
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

            <div class="clear"></div>

        </div>

    </div>
</asp:Content>
