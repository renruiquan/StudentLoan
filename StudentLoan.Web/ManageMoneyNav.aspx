<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMoneyNav.aspx.cs" Inherits="StudentLoan.Web.ManageMoneyNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
        $(function () {
            $("#ManageMoneyNav").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="h60 bbc"></div>

<div class="container-wrap">

    <div class="cornucopia">

        <div class="less-to-multi">

            <div class="wrapper">

                <div class="shadow">
                    <div class="ima"></div>
                </div>

                <div class="disc">
                    <h3>聚少成多  <span> 完成50%</span></h3>

                    <div class="btn-toolbar">
                        <div class="b-group">
                            <span>保证计划：本息保障计划 </span>
                            <span class="c-blue">利率：8%</span>
                            <span>额度：100+</span>
                            <span>投资期限：1-3个月</span>
                        </div>
                    </div>

                    <p class="c-gray">大众型投资，100元起投，投资者只需投入小额度资金便可享受X%的年化收益率，即使投入资金有限，
                        也可享受高出银行X倍的收益。小投资，高收益，聚沙成塔、积少成多，何乐而不为？</p>

                </div>

                <div class="invest">
                    <button class="btn btn-large btn-primary" type="button">投资</button>
                </div>
            </div>
        </div>

        <div class="money-drawing">
            <div class="wrapper">

                <div class="shadow">
                    <div class="ima"></div>
                </div>

                <div class="disc">
                    <h3>招财进宝<span> 完成50%</span></h3>

                    <div class="btn-toolbar">
                        <div class="b-group">
                            <span>保证计划：本息保障计划 </span>
                            <span class="c-blue">利率：8%</span>
                            <span>额度：3000+</span>
                            <span>投资期限：4-6个月</span>
                        </div>
                    </div>

                    <p class="c-gray">招财进宝是聚宝盆平台推出的一款专业、安全、稳定的理财产品，专为有短中期投资理念的投资人群量
                        身打造。 3000元起投，10%的年化收益率，稳定无风险，让投资者坐享其成！</p>

                </div>

                <div class="invest">
                    <button class="btn btn-large btn-primary" type="button">投资</button>
                </div>
            </div>

        </div>

        <div class="top-full">
            <div class="wrapper">

                <div class="shadow">
                    <div class="ima"></div>
                </div>

                <div class="disc">
                    <h3>盆满脖满<span> 完成70%</span></h3>

                    <div class="btn-toolbar">
                        <div class="b-group">
                            <span>保证计划：本息保障计划 </span>
                            <span class="c-blue">利率：12%</span>
                            <span>额度：10000+</span>
                            <span>投资期限：7-12个月</span>
                        </div>
                    </div>

                    <p class="c-gray">10000元起投，12%年化收益率，银行定期存款收益的四倍，让投资者的收益大副提升，收利息收到盆
                        满钵满。无风险高收益，你还在等什么？</p>

                </div>

                <div class="invest">
                    <button class="btn btn-large btn-primary" type="button">投资</button>
                </div>
            </div>

        </div>

    </div>

    <div class="wrapper">

        <div class="shadow-text"></div>

        <div class="ptb20">

            <h3>常见问题</h3>

            <p>1：投资成功后，何时开始计息？ </p>

            <p>投资成功，次日计息。投资者将在未来的每个月按时收到当月投资收益，直至投资周期结束收回全部收益及投资本金。
            </p>

            <p> 2：如何计算投资收益？</p>

            <p>投资收益=投资本金 * 预期年化收益率 / 12 * 投资期限；或使用网站首页左侧漂浮框中的【收益计算器】计算。
            </p>

            <p>3：如何知道自己投资到期获得收益？</p>

            <p>登陆会员中心-查看理财记录即可得知；或登陆会员中心到期会发送站内信用户及时查看。</p>

            <p>4：能提前转出资金吗？</p>

            <p>可以，但是如果投资40天，我们只算第一个月的利息费用。</p>


        </div>
    </div>

</div>

</asp:Content>
