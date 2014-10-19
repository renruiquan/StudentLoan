<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StudentLoan.Web.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <li><a class="active" href="javascript:;"><i class="ico-note"></i>保障</a></li>
                        <li><a href="Introduction.aspx"><i class="ico-params"></i>公司简介</a></li>
                        <li><a href="Contact.aspx"><i class="ico-note"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-wallet"></i>企业文化</a></li>
                    </ul>
                </div>
            </div>
            <div class="content">

                <div class="cont clear-top">

                    <div class="article">
                        <h3>数据信息安全</h3>

                        <p>
                            学子易贷严格遵守国家的相关法律法规，对用户隐私信息实行全面严格的保护，并采用行业内最先进的加密技术，对用户的个人相关信息、账户收支信息进行高强度的加密处理，不用担心会被不法分子窃取到，以及对交易数据采取专线传输，保证相关信息不会外泄。
                        </p>

                        <h3>风险控制体系</h3>

                        <p>
                            学子易贷会对借款人的基础信息（个人及学校情况）、家庭及室友信息(学生证及室友学生证等)、历史消费记录(支付宝及银行流水账单)、网络痕迹等信息进行分析和核查，同时辅以实地征信或远程实查，确保客户的真实性和准确性；专业审核人员在贷中通过对不同阶段确保审批精准化，并通过学子易贷评分评级系统，确保审批质量标准化；若客户30天内还未还款，将交由第三方专业催收机构进行包括上门等一系列的合法催收工作，直至采取法律手段。
                        </p>

                        <h3>法律法规政策</h3>

                        <p>
                            民间借贷是指自然人之间、自然人与法人之间、自然人与其它组织之间借贷。只要双方当事人具有完全民事行为能力且意见表示真实即可认定有效，因借贷产生的担保或抵押也相应有效，但利率不得超过人民银行规定的相关利率。民间借贷是一种直接融资形式，是民间金融的一种表现形式，民间借贷业的发展是对现今金融体系的补充。《中华人民共和国合同法》第二百一十一条：自然人之间的借款合同对支付利息没有约定或者约定不明确的，视为不支付利息。自然人之间的借款合同约定支付利息的，借款的利率不得违反国家有关限制借款利率的规定。
                        </p>
                    </div>
                </div>

            </div>

        </div>
    </div>
    </div>
</asp:Content>
