﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Introduction.aspx.cs" Inherits="StudentLoan.Web.Introduction" %>

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
                        <li><a href="About.aspx"><i class="ico-note"></i>安全保障</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-params"></i>公司简介</a></li>
                        <li><a href="Contact.aspx"><i class="ico-note"></i>联系我们</a></li>
                        <li><a href="Culture.aspx"><i class="ico-wallet"></i>企业文化</a></li>
                        <li><a href="Question.aspx"><i class="ico-wallet"></i>常见问题</a></li>
                    </ul>
                </div>
            </div>

            <div class="content">

                <div class="cont clear-top about-us-bg">

                    <div class="article">

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_us_2.jpg" width="180" height="180" />
                            </a>

                            <div class="media-body">
                                <h3>学子易贷网简介 Introduction</h3>

                                <p>学子易贷网，是集大学生贷款、大学生投资、大学生创业活动为一体的综合性的专业学生信息服务平台，是国内首家专门针对大学生贷款的网站，致力于为大学生们提供最好的贷款咨询服务。学子易贷是首家尝试P2P网络贷款咨询的专业服务机构。</p>

                                <p>学子易贷网结合国内大学生的社会信用状况，推出了凭学生证即可贷款的高效、便捷、安全的服务。学子易贷网从大学生的角度出发，为大学生们提供无抵押、无担保的小额信用贷款，从而解决了大学生贷款难题。</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/about_us_3.jpg" width="180" height="180" />
                            </a>

                            <div class="media-body">
                                <h3>学子易贷意义 Meaning </h3>

                                <p>学子易贷网贷款是一种将非常小额度的贷款聚集起来借贷给有资金需求大学生的一种商业模型。它的社会价值主要体现在满足大学生资金需求、发展大学生信用体系和提高社会闲散资金利用率三个方面：</p>

                                <p>①在中国，银行对个人信用贷款的条件要求很高，大学生从银行系统申请贷款面临很多困难，学子易贷网贷款为需要资金的大学生提供了新的贷款渠道。</p>

                                <p>②学子易贷网贷款主要是以个人信用评价为基础的贷款，它的发展有助于大学生体现自身的信用价值，提高大学生的社会个人信用体系的建设。</p>

                                <p>
                                    ③学子易贷网贷款扩宽了广大理财人投资的渠道，加大了资金的流动，提高了社会闲散资金的使用率，促进了经济的发展。学子易贷贷款服务平台的出现，不仅仅是一个创新的商业模式，它更为缩小社会贫富差距、创造就业、实现经济长期发展、社会和谐作出了重大贡献。
                                </p>
                            </div>
                        </div>


                        <div class="mt20 text-center">
                            <img src="../css/img/admin/about_us_bottom.jpg" width="470" height="165" />
                        </div>


                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
