<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoanList.aspx.cs" Inherits="StudentLoan.Web.LoanList" %>
<%@ OutputCache  Duration="18000" VaryByParam="*"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#LoanList").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap mb0 bg-cyan">

    <div class="wrapper">

        <div class="class-of">

            <div class="generic">

                <div class="class-shadow">
                    <div class="ima"></div>
                </div>

                <h2>一般贷</h2>

                <p class="c-gray">（资金需求不大，吃喝玩乐）</p>

                <div class="money">
                    <span class="dollar">￥</span>

                    <h2 class="c-gray">1000-5000</h2>
                </div>

                <div class="txt">
                    <h4>快速、容易</h4>

                    <p>申请只需2分钟</p>

                    <p>闪电审批2个小时资金到账</p>

                    <p>短期借款无压力</p>
                </div>

                <p>
                    <button class="mt10 btn btn-large btn-primary" type="button">我要借款</button>
                </p>

            </div>

            <div class="diamond">
                <div class="class-shadow">
                    <div class="ima"></div>
                </div>

                <h2>高额贷</h2>

                <p>（提升自我、助学创业）</p>

                <div class="money">
                    <span class="dollar">￥</span>

                    <h2 class="c-gray">6000-10000</h2>
                </div>

                <div class="txt">
                    <h4>我的未来不等待</h4>

                    <p>借款期限可达最长6个月</p>

                    <p>资料齐全4个小时放款</p>

                    <p>保密用户信息隐私</p>
                </div>

                <p>
                    <button class="mt10 btn btn-large btn-primary" type="button">我要借款</button>
                </p>
            </div>

            <div class="at-any-time">

                <div class="class-shadow">
                    <div class="ima"></div>
                </div>

                <h2>随时贷</h2>

                <p>（好借好还、还款时间自由）</p>

                <div class="money">
                    <span class="dollar">￥</span>

                    <h2 class="c-gray">1000-5000</h2>
                </div>

                <div class="txt">
                    <h4>资金在手 还款随我</h4>

                    <p>还款期限灵活，时间不受限制</p>

                    <p>按天收取最低3元服务费</p>

                    <p>无其他费用无押金</p>
                </div>

                <p>
                    <button class="mt10 btn btn-large btn-primary" type="button">我要借款</button>
                </p>
            </div>

        </div>

    </div>
</div>

<div class="wrapper">

    <div class="content wbb">
        <div class="item">
            <table class="table table-bordered table-striped">
                <caption>
                   <h3>借款细则表</h3>
                   <p>一般贷款.从用户交易日期开始30天结算一次利息，用户还款低于30天按天算利息，超过30天，30天算一次利息，剩下按照天数计算，申请期限不得高于90天</p>
                </caption>
                <thead>
                <tr>
                    <th class="w150"></th>
                    <th>一般贷</th>
                    <th>高额贷</th>
                    <th>随时贷</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>借款额度</td>
                    <td><p>1000-5000元</p></td>
                    <td><p>6000-10000元</p></td>
                    <td><p>1000-10000元</p></td>
                </tr>
                <tr>
                    <td>借款费率</td>
                    <td><p>9%/月</p></td>
                    <td><p>9%/月</p></td>
                    <td><p>0.3%/天</p></td>
                </tr>
                <tr>
                    <td>借款期限</td>
                    <td><p>4个月内</p></td>
                    <td><p>半年内</p></td>
                    <td><p>0.3%/天</p></td>
                </tr>
                <tr>
                    <td>还款方式</td>
                    <td colspan="3"><p>每个月还服务费，最后一期本金、服务费一起归还</p></td>

                </tr>
                <tr>
                    <td>审核期限</td>
                    <td colspan="3"><p>1-2个工作日</p></td>
                </tr>
                <tr>
                    <td>放款时间</td>
                    <td colspan="3"><p>经工作人员审核，符合条件后一小时内便可放款，网站后台将实时显示易情况。具体到账时间，请参照各大银行具体服务时间为准</p></td>
                </tr>
                <tr>
                    <td>借款原则</td>
                    <td colspan="3"><p>需要先填写完整自己的资料才可以借款(<a href="javascript:;">完善资料</a>）</p></td>
                </tr>
                <tr>
                    <td><p></p>还款原则</td>
                    <td colspan="3"><p>每月收取服务费，到期收取本金与当月服务费。</p></td>
                </tr>
                <tr>
                    <td>贷款条件</td>
                    <td><p>在校大学生、身份证、学生证、</p>
                        <p>手机服务密码（<a href="javascript:;">必验证</a>）</p>
                    </td>
                    <td>
                        <p>1.在校大学生、身份证、学生证、手机服务密码（<a href="javascript:;">必验证</a>）</p>
                        <p>2.其他消费清单、家长身份证、室友身份证、学信网截图、手机近期通话记录截图、驾驶证、户口本(<a href="javascript:;">选验证</a>）</p>
                    </td>
                    <td><p>根据金额参照前两项情况</p></td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
</asp:Content>
