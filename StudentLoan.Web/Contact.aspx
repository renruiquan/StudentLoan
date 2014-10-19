<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="StudentLoan.Web.Contact" %>
<%@ OutputCache  Duration="18000" VaryByParam="*"%>

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
                        <li><a href="About.aspx"><i class="ico-note"></i>保障</a></li>
                        <li><a href="Introduction.aspx"><i class="ico-params"></i>公司简介</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-note"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-wallet"></i>企业文化</a></li>
                    </ul>
                </div>
            </div>
            <div class="content">

                <div class="cont clear-top">

                    <div class="article">
                        <h3>公司总部</h3>

                        <p>地址：上海市徐汇区肇嘉浜路1033号徐家汇国际大厦19-20层</p>
                        <p>邮编：200030</p>

                        <h3>江苏财富中心</h3>
                        <p>地址：江苏省宿迁市宿城开发区生产力中心C座</p>
                        <p>邮编：223800</p>
                        <p>电话：0527-88802678</p>

                        <h3>客服电话</h3>
                        <p>如果您在访问学子易贷（UTL)的过程中有任何疑问请您与学子易贷（UTL)客服人员联系</p>
                        <p>客服电话：0527-88802678（09.00-17:30）</p>

                        <h3>媒体采访</h3>
                        <p>
                            如果有媒体采访需求，请将您的媒体名称、采访提问、联系方式发送邮件至：<br>
                            <a href="mailto:2419451636@qq.com">2419451636@qq.com</a>我们会尽快与您联系。
                        </p>

                        <h3>商务合作</h3>
                        <p>如果贵公司希望与我们建立商务合作关系，形成优势互补，请将合作意向进行简要描述并发送邮件至：</p>
                        <p><a href="mailto:2419451636@qq.com">2419451636@qq.com</a>我们会尽快与您联系。</p>

                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
