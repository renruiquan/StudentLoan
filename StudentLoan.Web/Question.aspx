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
                        <li><a href="About.aspx"><i class="ico-lock"></i>安全保障</a></li>
                        <li><a href="Introduction.aspx"><i class="ico-bulb"></i>公司简介</a></li>
                        <li><a href="Contact.aspx"><i class="ico-mail"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-fire"></i>企业文化</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-settings"></i>常见问题</a>
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
                                <p>答：手续费为本金*0.3%/天.</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>2.还款方式有哪些？</b>
                            </p>

                            <div class="answer">
                                <p>答：用户可通过账户余额或网站在线支付还款。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>3.临时身份证可以借款吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：用户不可以使用临时身份证办理借款业务。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>4.网站审核需要多久？</b>
                            </p>

                            <div class="answer">
                                <p>答：正常情况下，一般贷款在工作日2个小时内即可审核通过，高额贷款和随时贷审核时间则需1-2个工作日。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>5.身份证不是自己的，可以吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：不可以，用户必须使用本人身份证方可在学子易贷网办理业务。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>6.学子易贷会当天放款吗？</b>
                            </p>

                            <div class="answer">
                                <p>答：审核通过，1个小时之内我们即放款，用户在自己后台中心提现。审核通过后，学子易贷将在1小时内放款，用户可收到手机短信提醒并可在后台中心查看提现。</p>
                            </div>

                        </li>

                        <li>
                            <p class="ask">
                                <b>7.学子易贷贷款额度如何提高？</b>
                            </p>

                            <div class="answer">
                                <p>答：学子易贷的贷款额度是由用户信用认证界定的，用户可点击用户名下拉菜单选择“我的易贷”→“账户认证”完善资料（资料必须是真实、合法、有效的），用户提交的资料越多，信用等级越高，相应的贷款金额也就越高。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>8.贷款成功后会联系家里人？</b>
                            </p>

                            <div class="answer">
                                <p>答：用户贷款成功后，学子易贷风控中心会根据用户所提供的联系人信息，在必要情况下抽取部分进行核实，但不会提及您的贷款事宜。我们会变向审查，例如：我们是xx培训基地，请问xxx需要报名吗？类似与办理信用卡的电话审查。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>9.贷款是通过什么形式发放？</b>
                            </p>

                            <div class="answer">
                                <p>答：用户的借款申请通过审核后，用户进入“我的易贷”→“充值提现/账户日志”进行提现，随后学子易贷会将用户所申请的贷款足额打入指定账号。</p>
                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>10.网上截图需要注意什么？</b>
                            </p>

                            <div class="answer">
                                <p>答：用户在截图时请注意截图信息的真实性，规范性。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>11.如果在学子易贷贷款1000元，我的银行账户实际到账多少钱？</b>
                            </p>

                            <div class="answer">


                                <p>答：用户账户实际到账金额为1000元，学子易贷放款时不会收取任何手续费。</p>

                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>12.还款后我的信用额度会增加吗？</b>
                            </p>

                            <div class="answer">


                                <p>答：可以增加，每笔贷款准时还款后，用户的信用积分将增加1分，若逾期还款天数超过5天，信用积分将扣除1分。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>13.银行流水如何获取？</b>
                            </p>

                            <div class="answer">

                                <p>
                                    答：请持本人身份证到银行柜台打印，所有银行都会免费打印，打印好后，请告知银行工作人员盖章。用户网上截图也可，但必须能看到持卡人姓名和卡号。持卡人姓名与身份证姓名必须一致，严禁上传别人的银行流水，否则直接封ID。
                                </p>

                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>14.我想放弃借贷，怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>答：如果您的申请未通过，请联系我们的客服人员，并告知您的用户名，我们将会为您取消此项申请，如果借款审核已通过，则借款无法撤销。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>15.借款后能不能提前还清？</b>
                            </p>

                            <div class="answer">

                                <p>答：为了方便客户操作，学子易贷推出了“随时贷”业务，选择此业务的用户可以自行选择还款时间，但若选择其他贷款方式，则需按时足额缴纳服务费用。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>16.我提交的个人资料是否会被泄露？</b>
                            </p>

                            <div class="answer">

                                <p>答：我们有完善的后台安全处理系统，采用先进的加密技术，确保您提交的资料不会被泄露出去。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>17.我在填写学校信息的时候，找不到我们学校怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>答：学子易贷后台收集了全国所有全日制高校信息（大专和本科），只要您是国内全日制高校的学生，就一定能够在列表中找出您所在的学校。</p>
                            </div>
                        </li>
                       
                        <li>
                            <p class="ask">
                                <b>18.可以循环借款吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：只要用户累计借款金额不超过5000元即可。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>19.是否可以修改已提交的借款申请？</b>
                            </p>

                            <div class="answer">

                                <p>答：不可以。用户在提交借款申请后，无法对已发布的借款信息进行修改，请用户在申请借款时务必认真填写各项信息。</p>
                            </div>
                        </li>
                       
                        <li>
                            <p class="ask">
                                <b>20.如果逾期还款，会有什么后果？</b>
                            </p>

                            <div class="answer">

                                <p>
                                   当还款逾期天数小于等于5天，则不需缴纳逾期费用；如若超过5天，每次逾期将扣除用户信用认证1分。常规下，逾期费用计算方式为：逾期费用=本金*0.5%*逾期天数+逾期服务费。若逾期超过15天，学子易贷有权追究借款人的法律责任，由此所产生的所有法律后果和费用（包括但不限于律师费）将由借款人来承担。
                                </p>
                               
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>21.如何充值？</b>
                            </p>

                            <div class="answer">

                                <p>1、点击用户名下拉菜单“我的易贷”→“充值提现/账户日志”，即可进行相应操作；</p>

                                <p>2、在充值页面选择您最方便的充值方式，同时输入充值金额，点击确认后转到第三方支付平台或网银，完成付款；</p>

                                <p>3、付款后请耐心等待浏览器自动跳转到后台页面，若在跳转前关闭了浏览器，则可能会出现充值失败的情况；</p>

                                <p>4、您可以通过“我的易贷”→“充值提现/账户日志”查看充值的金额及历史记录。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>22.如何提现？</b>
                            </p>

                            <div class="answer">

                                <p>点击用户名下拉菜单“我的易贷”→“充值提现/账户日志”，即可进行相应操作。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>23.在申请提现时，如何填写正确的银行卡开户行名称？</b>
                            </p>

                            <div class="answer">
                                <p>
                                  学子易贷收到用户提现申请后，将通过第三方支付台平把提现款项转入用户提供的个人银行账号。如果用户填写的开户行支行名称不正确，资金将无法汇出，因此用户在申请提现时，必须正确详细地填写开户行全称。
                                </p>
                                <P>一般正规的开户行名称格式示例为：XX银行XX市分行XX支行；</P>
                                <p>如果用户不清楚开户行支行名称，可以拨打银行客服电话或者登录发卡银行官方网站进行查询。</p>
                            </div>

                        </li>
                        <li>
                            <p class="ask">
                                <b>24.用户如何更新或修改账户及个人资料？</b>
                            </p>

                            <div class="answer">

                                <p>点击用户名下拉菜单“我的易贷”→“账户信息/个人信息进行”修改并保存相关信息。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>25.忘记密码了怎么办？</b>
                            </p>

                            <div class="answer">

                                <p>用户可以通过已绑定的手机号码找回密码。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>28.如何保障个人账户安全？</b>
                            </p>

                            <div class="answer">

                                <p>1、用户注册时，请不要设置过于简单的密码。学子易贷建议用户选择设置手机绑定功能，使用时注意保密，切勿向任何人透漏密码。</p>

                                <p>2、建议用户定期更改账户密码，并谨慎访问陌生网站和下载软件，确保个人账户安全。</p>
                                
                            </div>
                        </li>

                        <li>
                            <h3 class="text-center">理财常见问答</h3>
                        </li>

                      
                        <li>
                            <p class="ask">
                                <b>1.哪里可以查看获取的投资利息？</b>
                            </p>

                            <div class="answer">

                                <p>答：点击进入“我的易贷”→“聚宝盆管理”→“我的收益”，即可查看理财收益。</p>
                            </div>
                        </li>
                        <li>
                            <p class="ask">
                                <b>2.我在学子易贷理财需要什么手续吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：用户成功注册成为学子易贷网的会员后，根据网站提示完善个人相关资料后便可在学子易贷网上办理理财业务。</p>

                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>3.风控审核指什么？</b>
                            </p>

                            <div class="answer">

                                <p>
                                    答：学子易贷正常的风控审核流程是在保证用户的个人隐私下进行的。风控审核的目的是为了验证贷款人所提供信息的合法性与真实性。其包括网络审核、电话审核、线下审核等。
                                </p>

                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>4.学子易贷网不能用支付宝、财付通等第三方支付平台充值吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：支付宝等第三方支付平台没有为P2P平台开放接口，迄今为止，国内没有任何一家P2P平台可以使用支付宝等第三方支付平台即时到账支付。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>5.我选择学贷网理财有什么好处？</b>
                            </p>

                            <div class="answer">

                                <p>答：高收益，低风险，低门槛，方便快捷易操作，能够为理财人士带来更高更稳定的收益。</p>
                            </div>
                        </li>

                        <li>
                            <p class="ask">
                                <b>6.如用户成功办理理财业务后急需用钱，可以提前支取本金和相应利息吗？</b>
                            </p>

                            <div class="answer">

                                <p>答：可以的，用户可在审核通过后进入“我的易贷”→“聚宝盆管理”→“理财记录”，在转入页面查看交易明细，点击“申请转出”即可提现。用户在申请提前转出时，学子易贷将会收取用户实际收益金额的20%作为提前支取手续费。</p>

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
