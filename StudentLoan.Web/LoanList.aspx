<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoanList.aspx.cs" Inherits="StudentLoan.Web.LoanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#LoanList").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bgf">
        <div class="container-wrap mb0 bg-cyan">

            <div class="wrapper">

                <div class="class-of">

                    <div class="generic">

                        <div class="class-shadow">
                            <div class="ima"></div>
                        </div>

                        <h2>一般贷</h2>

                        <p class="c-gray">（追求自我，引领潮流）</p>

                        <div class="money">
                            <span class="dollar">￥</span>

                            <h2 class="c-gray">1000-5000</h2>
                        </div>

                        <div class="txt">
                            <h4>申请只需2分钟</h4>

                            <p>审批速度快，资金到账只需2小时。</p>
                            <p>闪电般的速度，</p>
                            <p>为您带来高品质的生活。</p>
                        </div>

                        <p>
                            <button class="mt10 btn btn-large btn-primary" type="button" onclick="return window.location.href='/user/UserLoanApply.aspx?productId=1'">我要借款</button>
                        </p>

                    </div>

                    <div class="diamond">
                        <div class="class-shadow">
                            <div class="ima"></div>
                        </div>

                        <h2>高额贷</h2>

                        <p class="c-gray">（提升自我，助学创业）</p>

                        <div class="money">
                            <span class="dollar">￥</span>

                            <h2 class="c-gray">6000-10000</h2>
                        </div>

                        <div class="txt">
                            <h4>我的未来不等待</h4>

                            <p>动动手指完善资料，</p>
                            <p>审批后4小时内放款，保密高效，</p>
                            <p>借款期限长，注重用户隐私权。</p>
                        </div>

                        <p>
                            <button class="mt10 btn btn-large btn-primary" type="button" onclick="return window.location.href='/user/UserLoanApply.aspx?productId=2'">我要借款</button>
                        </p>
                    </div>

                    <div class="at-any-time">

                        <div class="class-shadow">
                            <div class="ima"></div>
                        </div>

                        <h2>随时贷</h2>

                        <p class="c-gray">（好借好还，时间自由）</p>

                        <div class="money">
                            <span class="dollar">￥</span>

                            <h2 class="c-gray">1000-10000</h2>
                        </div>

                        <div class="txt">
                            <h4>资金在手 还款随我</h4>

                            <p>无须担保抵押，随心贷，随心还，</p>
                            <p>最低收取3元/天服务费，</p>
                            <p>该出手时就出手，还款时间超自由。</p>
                        </div>

                        <p>
                            <button class="mt10 btn btn-large btn-primary" type="button" onclick="return window.location.href='/user/UserLoanApply.aspx?productId=3'">我要借款</button>
                        </p>
                    </div>

                </div>

            </div>
        </div>

        <div class="wrapper">

            <div class="borrow-money-detail">

                <div class="title">
                    <h1>借款细则</h1>

                    <p>一般贷款：从用户交易日期开始30天结算一次利息，用户还款低于30天按天算利息，超过30天，30天算一次利息，剩下按照天数计算，申请期限不得高于90天</p>
                </div>

                <div class="project-wrap">

                    <div class="item green">

                        <h2 class="title">一般贷</h2>

                        <div class="cont">

                            <h4>借款额度</h4>

                            <img src="../css/img/admin/dollar_1000_5000.jpg" alt="" />

                            <div class="limit">
                                <div class="left">
                                    <h4>借款服务费</h4>
                                    <span>0.3%/天</span>
                                </div>
                                <div class="right">
                                    <h4>借款期限</h4>
                                    <span>4个月内</span>
                                </div>
                            </div>

                            <h4>贷款条件</h4>

                        </div>

                        <div class="condition">
                            <p>在校大学生、身份证、学生证、手机服务密码 <span class="c-blue">（必验证）</span></p>
                        </div>

                        <div class="cont">

                            <div class="adv">
                                <span>高效</span>
                                <span>安全</span>
                                <span>保密</span>
                            </div>

                        </div>

                    </div>

                    <div class="item orange">

                        <h2 class="title">高额贷</h2>

                        <div class="cont">

                            <h4>借款额度</h4>

                            <img src="../css/img/admin/dollar_6000_10000.jpg" alt="" />

                            <div class="limit">
                                <div class="left">
                                    <h4>借款服务费</h4>
                                    <span>0.3%/天</span>
                                </div>
                                <div class="right">
                                    <h4>借款期限</h4>
                                    <span>6个月内</span>
                                </div>
                            </div>

                            <h4>贷款条件</h4>

                        </div>

                        <div class="condition">
                            <p>1.在校大学生、身份证、学生证、手机服务密码 <span class="c-blue">（必验证）</span></p>
                            <p>2.其他消费清单、家长身份证、室友身份证、学信网截图、手机近期通话记录截图驾驶证、户口本 <span class="c-blue">（必验证）</span></p>
                        </div>

                        <div class="cont">

                            <div class="adv">
                                <span>高效</span>
                                <span>安全</span>
                                <span>保密</span>
                            </div>

                        </div>

                    </div>

                    <div class="item blue">

                        <h2 class="title">随时贷</h2>

                        <div class="cont">

                            <h4>借款额度</h4>

                            <img src="../css/img/admin/dollar_1000_10000.jpg" alt="" />

                            <div class="limit">
                                <div class="left">
                                    <h4>借款服务费</h4>
                                    <span>0.3%/天</span>
                                </div>
                                <div class="right">
                                    <h4>借款期限</h4>
                                    <span>90天内</span>
                                    <p>(还款期限不受限制)</p>
                                </div>
                            </div>

                            <h4>贷款条件</h4>

                        </div>

                        <div class="condition">
                            <p>根据金额参照前两项情况</p>
                        </div>

                        <div class="cont">

                            <div class="adv">
                                <span>高效</span>
                                <span>安全</span>
                                <span>保密</span>
                            </div>

                        </div>

                    </div>

                </div>

                <div class="clear"></div>

                <div class="item">

                    <table class="borrow-money-table">
                        <tr>
                            <th>还款方式</th>
                            <td>每个月还服务费，最后一期本金、服务费一起归还</td>
                        </tr>
                        <tr>
                            <th>审核期限</th>
                            <td>1-2个工作日</td>
                        </tr>
                        <tr>
                            <th>放款时间</th>
                            <td>经工作人员审核，符合条件后一小时内便可放款，网站后台将实时显示交易状态。具体到账时间，请参照各大银行具体服务时间为准
                            </td>
                        </tr>
                        <tr>
                            <th>借款原则</th>
                            <td>需要先完整填写自己的资料才可以借款 <a class="c-blue" href="user/UserAccountCert.aspx">（完善资料）</a></td>
                        </tr>
                        <tr>
                            <th>还款原则</th>
                            <td>每月收取服务费，到期收取本金与当月服务费</td>
                        </tr>
                    </table>

                </div>

            </div>

        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
