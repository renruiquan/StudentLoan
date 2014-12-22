<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="StudentLoan.Web.Contact" %>

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
                        <li><a href="About.aspx"><i class="ico-lock"></i>安全保障</a></li>
                        <li><a href="Introduction.aspx"><i class="ico-bulb"></i>公司简介</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-mail"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-fire"></i>企业文化</a></li>
                        <li><a href="Question.aspx"><i class="ico-settings"></i>常见问题</a></li>
                    </ul>
                </div>
            </div>
            <div class="content">

                <div class="cont clear-top">

                    <div class="article">

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_map.png" width="130" height="130" />
                            </a>

                            <div class="media-body">
                                <h3>财富中心</h3>

                                <p>地址：苏宿工业园区生产力中心电商产业园C座</p>

                                <p>邮编：223800</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_telephone.png" width="130"
                                    height="130" />
                            </a>

                            <div class="media-body">
                                <h3>客服电话</h3>

                                <p>如果您在访问学子易贷（UTL)的过程中有任何疑问请您与学子易贷（UTL)客服人员联系。</p>

                                <p>联系电话：0527-88802678（09:00-17:30）</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_fax.png" width="130" height="130" />
                            </a>

                            <div class="media-body">
                                <h3>传真（Fax)</h3>

                                <p>如果您在访问学子易贷（UTL)的过程中有任何疑问请您与学子易贷（UTL)客服人员联系。</p>

                                <p>联系传真：0527-88802678（09:00-17:30）</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_email.png" width="130" height="130" />
                            </a>

                            <div class="media-body">
                                <h3>业务合作</h3>

                                <p>如果贵公司希望与我们建立商务合作关系，形成优势互补，请将合作意向进行简要描述并发送邮件至：</p>

                                <p>2028600523@qq.com 我们会尽快与您联系</p>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
