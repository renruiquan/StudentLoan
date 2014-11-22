<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMoneyNav.aspx.cs" Inherits="StudentLoan.Web.ManageMoneyNav" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Import Namespace="StudentLoan.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#ManageMoneyNav").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-wrap">

        <div class="cornucopia">

            <StudentLoan:RepeaterPlus ID="objReapter" runat="server">
                <ItemTemplate>
                    <div class='<%#this.SetClass( Eval("ProductId").Convert<int>(1)) %>'>

                        <div class="wrapper">
                            <div class="shadow">
                                <div class="ima"></div>
                            </div>

                            <div class="disc">
                                <h3><%#Eval("ProductName") %></h3>

                                <div class="btn-toolbar">
                                    <div class="b-group">
                                        <span>保证计划：本息保障计划 </span>
                                        <span class="c-blue">利率：<%#Eval("BaseAnnualFee").Convert<decimal>().ToString("P2") %></span>
                                        <span>额度：<%#Eval("ProductMinMoney").Convert<decimal>().ToString("C") %>+</span>
                                        <span>理财期限：<%#Eval("MinPeriod") %>-<%#Eval("MaxPeriod") %>个月</span>
                                    </div>
                                </div>

                                <p class="c-gray">
                                    <%#Eval("ProductDescription") %>
                                </p>

                            </div>

                            <div class="invest">
                                <button class="btn btn-large btn-primary" type="button" onclick='return window.location.href="/ProductSchemeList.aspx?ProductId=<%#Eval("ProductId") %>"'>理财</button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    暂无数据
                </EmptyDataTemplate>
            </StudentLoan:RepeaterPlus>

        </div>

        <div class="wrapper">

            <div class="shadow-text"></div>

            <div class="ptb20">

                <h3>常见问题</h3>

                <p>1：投资成功后，何时开始计息？ </p>

                <p>利息是按日计算，投资成功，次日计息。投资者将在未来的每日按时收到当日投资收益，直至投资周期结束收回全部收益及投资本金。</p>

                <p>2：如何计算投资收益？</p>

                <p>投资收益=投资本金 * 预期年化收益率 / 12 * 理财期限；</p>

                <p>3：如何知道自己投资到期获得收益？</p>

                <p>登陆会员中心-账户总览可以查出余额或者查看理财管理-我的收益即可得知。</p>

                <p>4：能提前转出资金吗？</p>

                <p>可以申请提前转出，利息按日计算。</p>


            </div>
        </div>

    </div>

</asp:Content>
