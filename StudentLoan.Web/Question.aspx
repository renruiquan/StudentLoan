<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="StudentLoan.Web.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>关于我们 - 常见问题 </title>
    <script type="text/javascript">
        $(function () {
            $("#About").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr class="line" />

    <div class="container-wrap">

        <div class="wrapper">

            <div class="menu">
                <div class="item">
                    <h2>关于我们</h2>
                    <ul>
                        <li><a href="About.aspx"><i class="ico-note"></i>保障</a></li>
                        <li><a href="Introduction.aspx"><i class="ico-params"></i>公司简介</a></li>
                        <li><a href="Contact.aspx"><i class="ico-note"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-wallet"></i>企业文化</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-wallet"></i>常见问题</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="content">

                <div class="p30 border-radius bgf">

                    <h3 class="text-center">借款人常见问答</h3>

                    <ul id="question_list" class="question">
                        <li>
                            <p class="ask">
                                <b>1.借款收取的手续费是多少？</b>
                            </p>

                            <div class="answer">
                                <p>答：我们只收取服务费，服务费是0.3%/天。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>2.还款方式有哪些？</b>
                            </p>

                            <div class="answer">
                                <p>答：网站在线付款或者提前充值到账户账户余额还款。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>3.临时身份证可以借款吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：临时身份证是不能通过审核的。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>4.网站审核需要多久？</b>
                            </p>

                            <div class="answer">
                                <p>答：一般贷款正常情况下在工作日2个小时之内即可审核通过、高额贷款和随时贷是1-2个工作日。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>5.手机不是自己的，但是自己在用，可以吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：这个是不能通过审核，必须是本人身份证。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>6.学子易贷当天放款吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：审核通过，1个小时之内我们即放款，用户在自己后台中心提现。</p>
                            </div>

                        </li>

                        <li>
                            <p class="ask">
                                <b>7.学子易贷贷款额度如何提高？</b>
                            </p>

                            <div class="answer">
                                <p>答：我们的贷款额度是由信用额度来界定的，在我要贷款一栏中找到信用认证，并提交资料（资料必须是真实、合法、有效的），提交的资料越多，信用额度越高，贷款金额也就越高。 </p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>8.贷款成功后会联系家里人？</b>
                            </p>

                            <div class="answer">
                                <p>答：成功后，我们的风控中心会根据你所提供的联系人信息，抽取部分打电话核实真实性，但不会提及你的贷款事宜，我们会变向审查，例如：我们是xx培训基地，请问xxx需要报名吗？类似与办理信用卡的电话审查。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>9.贷款是通过什么形式拿到手的？</b>
                            </p>

                            <div class="answer">
                                <p>答：审核通过款打到用户的账户里面，用户可以提现到自己银行卡里。</p>
                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>10.网上截图需要注意什么？</b>
                            </p>

                            <div class="answer">
                                <p>答：网上截图需要与身份证上面的姓名一致，需看清楚姓名。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>11.请问在学子易贷贷款1000，到我的银行账户实际多少钱？</b>
                            </p>

                            <div class="answer">


                                <p>答：您提现时，我们不会收取手续费，也就是1000元实际到账1000，以此类推。</p>

                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>12.还款后我的信用额度可以增加吗？</b>
                            </p>

                            <div class="answer">


                                <p>答：是的，可以增加。每笔贷款准时还款后，增加1分，逾期还款扣1分。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>13.银行账单需要怎么弄?</b>
                            </p>

                            <div class="answer">

                                <p>
                                    答：请持本人身份证到银行柜台打印，所有银行都会免费打印，打印好后，请告知银行工作人员盖章。网上截图也可，但必须能看到持卡人姓名和卡号。持卡人姓名跟身份证上姓名必须一致，严禁传别人的银行流水，否则直接封ID。
                                </p>

                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>14.我想放弃借贷，怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>答：如果您的申请未通过，请联系我们的工作客服，并告知您的用户名，我们会竭诚为您服务，如果借款审核已通过，则借款无法撤销。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>15.借款后能不能提前还清？</b>
                            </p>

                            <div class="answer">

                                <p>答：选择随借随贷模式，即可随时还款，无押金费用，0.3%/每天，其他贷款方式提前还款如期缴纳服务费用。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>16.我提交的个人资料会不会泄露出去？</b>
                            </p>

                            <div class="answer">

                                <p>答：我们有高技术含量的后台处理系统，并采取高加密技术，您提交的资料不会被泄露出去。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>17.我在填写学校信息的时候，找不到我们学校怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>答：我们针对学生必须是全日制学校，如果找不到学校那就是学生不是全日制，放心我们后台搜集了全国所有全日制学校（保护大专和本科）。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>18.我的银行流水页数非常多，传6个月太多怎么传？</b>
                            </p>

                            <div class="answer">

                                <p>答：如果你的流水太多，你可以每个月截取一段就行。我们主要是看你的还款来源是不是有保障，是不是稳定，是不是真实。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>19.可以循环借款吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：可以的，比如用户选择一般贷款，我们给出最高的额度5000，不限制次数达到5000就不可以循环借款了，只能借其他类型的贷款。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>20.是否可以修改已提交的借款申请？</b>
                            </p>

                            <div class="answer">

                                <p>答：不可以。在用户发布借款之后，不可以对已发布的借款进行修改。请用户在发布借款时务必认真填写各项信息。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>21.如果审批不通过我的申请资料能否还给我？</b>
                            </p>

                            <div class="answer">

                                <p>答：抱歉，根据行业规范，不能退还。您提交的资料我们会根据行业的要求进行绝对保密。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>22.如果逾期还款，会有什么惩罚？</b>
                            </p>

                            <div class="answer">

                                <p>
                                    答：逾期一次扣除1分，第二天发送逾期提醒短信。如没有归还，第四天发送第二条逾期短信。第五天开始电话联系本人，第10天拨打相关联系人联系方式。第15日发送律师函。（比如15日归还贷款，如没有正常归还则16日发送短信，如还没有归还则19日发送第二条信息。20日电话联系本人。25日联系相关联系人）。
                                </p>

                                <p>a.如果逾期还款，借款人要承担罚息与逾期服务费，并会被记录进个人信用档案。所以学子易贷强烈建议用户避免逾期还款，一旦发生逾期请保持与学子易贷的联系并尽快还清借款。</p>

                                <p>b.学子易贷有权将该借款人的有关信息向媒体、用人单位、公安机关、检察机关、法律机关披露，学子易贷并不因此承担任何责任；</p>

                                <p>c.保留对借款人采取法律措施的权利，由此所产生的所有法律后果和费用（包括但不限于律师费）将由借款人来承担。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>23.如何充值？</b>
                            </p>

                            <div class="answer">

                                <p>1、点击“我的易贷”右上角的“充值”按钮；</p>

                                <p>2、在充值页面选择您最方便的充值方式，同时输入欲充值的金额，点击确认后转到第三方支付平台或网银，完成付款；</p>

                                <p>3、付款后请耐心等待浏览器自动跳转到后台页面，若在跳转前关闭了浏览器，则可能会出现充值失败的情况；</p>

                                <p>4、您可以通过资金记录查看充值的金额及历史记录。 </p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>24.如何提现？</b>
                            </p>

                            <div class="answer">

                                <p>点击“我的易贷”右上角的“提现”，选择或设置提现账户，输入提现金额，即可提交提现申请。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>25.在申请提现时，如何填写正确的银行卡开户行名称？</b>
                            </p>

                            <div class="answer">
                                <p>
                                    学子易贷收到提现申请后，委托第三方支付公司将提现款转入用户提供的个人银行账号。如果用户填写的开户行支行名称不正确，汇款将不能及时顺利到达用户的银行卡。所以请用户在申请取现前，一定要确保自己所填写的开户行支行名称正确。
                                </p>

                                <p>一般的开户行支行名称都是由 xx银行组成的。</p>

                                <p>如：招商银行。</p>

                                <p>如：交通银行。</p>

                                <p>如果用户不清楚开户行支行名称，可以拨打银行客服电话询问或者登录发卡银行官方网站进行查询。</p>

                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>26.如何修改个人资料？</b>
                            </p>

                            <div class="answer">

                                <p>进入“我的易贷”— “个人设置”—“基本资料”，修改并保存相应的信息。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>27.忘记密码了怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>如果您遗忘了密码，您可以通过点击网站首页右上方的“登录”，通过登录窗口中的“忘记密码”通过Email地址或手机、安全问题找回密码。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>28.如何保障密码安全？</b>
                            </p>

                            <div class="answer">

                                <p>1、密码要保密，绑定手机，且定期更改；</p>

                                <p>2、请使用尽量长、复杂的字母数字符号组合以提高密码强度，不要用生日等容易被别人猜中的密码；</p>

                                <p>3、如果使用了密码取回功能，请您及时删除我们发送给您的载有密码的邮件；</p>

                                <p>4、请记住不要与任何人共享您的密码。如果您已经与他人共享了密码，我们强烈建议您尽快更改；</p>

                                <p>5、您可能在不经意间使计算机受到病毒、木马、间谍软件、广告软件的感染，这些软件也可能记录并盗走您的密码！所以，请安装和使用杀毒软件，并请谨慎访问陌生网站和下载软件。</p>
                            </div>
                        </li>

                        <li>
                            <h3 class="text-center">借款人常见问答</h3>
                        </li>

                        <li>
                            <p class="ask">
                                <b>1.理财利息怎么算？</b>
                            </p>

                            <div class="answer">

                                <p>答：利息我们是按日返给理财用户，用户可以进入个人中心理财统计查看 收益金额。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>2.哪里可以查看获取的投资利息？</b>
                            </p>

                            <div class="answer">

                                <p>答：进入会员中心--理财统计--理财中心里面。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>3.我在学子易贷理财需要什么手续吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：填写详细资料，成功注册成为学子易贷网的会员便可在学子易贷网上进行理财。</p>

                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>4.风控审核指什么？</b>
                            </p>

                            <div class="answer">

                                <p>
                                    答：风控审核的目的是为了验证贷款人所提供信息的真实性。包括网络审核、电话审核、线下审核等。电话审核为核心。我们会根据贷款人提供的联系人随机抽取部分打电话核实（不会提及贷款人在学子易贷网贷款的事情）。
                                </p>

                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>5.学子易贷网不能用支付宝、财付通等第三方支付平台充值吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：支付宝等第三方支付平台没有为P2P平台开放接口，全国没有任何一家P2P可以使用支付宝等第三方支付平台即时到账支付。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>6.我选择学贷网理财有什么好处？</b>
                            </p>

                            <div class="answer">

                                <p>答：高收益，低风险，低门槛，电脑操作方便，帮助学生完成学业或者自主创业，公益性强。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>7.投资可以提前取本金出来了吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：可以的，提前现金需审核通过可以进入自己会员中心将收益和本金提现。</p>

                            </div>
                        </li>

                    </ul>


                </div>

            </div>
        </div>

    </div>

    <script>
        (function ($) {
            $(function () {
                $.each($("#question_list .ask"), function () {
                    var nextObj = $(this).next()[0];
                    // 初始值为打开的状态
                    nextObj.opened = 1;
                    $(this).click(function () {
                        var clickNextObj = $(this).next();
                        var nextOpened = clickNextObj[0].opened;
                        if (nextOpened) {
                            clickNextObj.hide();
                            clickNextObj[0].opened = 0;
                        } else {
                            clickNextObj.show();
                            clickNextObj[0].opened = 1;
                        }
                    });
                });
            });
        })(jQuery);
    </script>

</asp:Content>
