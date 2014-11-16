<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Introduction.aspx.cs" Inherits="StudentLoan.Web.Introduction" %>

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
									<h3>公司简介</h3>

									<p>集大学生贷款、投资、创业为一体的信息服务平台，致力于为大学生们提供最好的贷款服务。</p>

									<p>国内首家为大学生提供贷款的P2P平台，结合国内大学生的社会信用状况，推出了凭学生证即可享受高效、安全、保密的贷款服务。</p>
									<p>从大学生的角度出发，为他们提供无抵押、无担保的小额信用贷款，从而解决了大学生贷款难题。</p>
									
								</div>
							</div>

							<div class="media">
								<a class="pull-left" href="#">
									<img class="media-object" src="../css/img/admin/about_us_3.jpg" width="180" height="180" />
								</a>

								<div class="media-body">
									<h3>学子易贷意义</h3>

									<p>有资金需求的大学生提供微小额贷款的一种商业模型它的社会价值主要体现在满足大学生资金需求、发展大学生信用体系，以提高社会闲散资金的利用率</p>

									
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
