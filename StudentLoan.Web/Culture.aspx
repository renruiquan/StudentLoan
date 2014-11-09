<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Culture.aspx.cs" Inherits="StudentLoan.Web.Culture" %>

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
                        <li><a href="Contact.aspx"><i class="ico-note"></i>联系我们</a></li>
                        <li><a class="active" href="javascript:;"><i class="ico-wallet"></i>企业文化</a></li>
                        <li><a href="Question.aspx"><i class="ico-wallet"></i>常见问题</a></li>
                    </ul>
                </div>
            </div>

            <div class="content">

                <div class="cont clear-top about-us-bg">

                    <div class="article">

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/brid.png" width="180" height="180" />
                            </a>
                            <div class="media-body">
                                <h3>敢想敢做，拥抱梦想！</h3>
                                <p>帮助莘莘学子们追寻梦想，是学子易贷网一直以来的奋斗目标。</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/water.png" width="180" height="180" />
                            </a>
                            <div class="media-body">
                                <h3>学子易贷理念</h3>
                                <p>诚信——以真诚之心,行信义之事。</p>
                                <p>拼搏——奋斗无止境，处处是起点。</p>
                                <p>创新——思想创新，体制创新，服务创新。</p>
                                <p>责任——敢想敢做敢担当。</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/tree.png" width="180" height="180" />
                            </a>
                            <div class="media-body">
                                <h3>学子易贷核心价值</h3>
                                <p>专业：专业进取，严谨审慎，精益求精。</p>
                                <p>服务：为大学生提供安全、便捷、高效的服务，在其追求人生价值的道路上提供帮助。</p>
                                <p>目的：帮助更多优秀的大学生人才，推动其个人成长。</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/knocked_active.png" width="180" height="180" />
                            </a>
                            <div class="media-body">
                                <h3>学子易贷服务观</h3>
                                <p>以大学生为根本：我们的主要服务对象为大学生，帮助其进步发展是我们的根本追求。</p>
                                <p>以价值共享为中心：创造最大价值，与客户、社会、员工共享价值是我们的中心。</p>
                                <p>以支持人才发展为目标：支持优秀人才追求梦想、推动个人发展与自我价值的实现是我们的目标。</p>
                            </div>
                        </div>

                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object" src="../css/img/admin/service.png" width="180" height="180" />
                            </a>
                            <div class="media-body">
                                <h3>学子易贷愿景</h3>
                                <p>打造中国最大、最权威、最诚信、最具价值的综合性专业学生信息服务平台。</p>
                                <p>打造一个安全、便捷、高效的互联网大学生金融服务平台。</p>
                            </div>
                        </div>


                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
