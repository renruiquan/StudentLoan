<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IvoryTower.aspx.cs" Inherits="StudentLoan.Web.IvoryTower" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>学子易贷 - 象牙塔 </title>
    <link rel="stylesheet" type="text/css" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/public.css" />
    <link rel="stylesheet" type="text/css" href="../css/common.css" />
    <link rel="stylesheet" type="text/css" href="../css/icomoon/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/modules/admin/admin.css" />
    <!-- bsie css -->
    <link rel="stylesheet" type="text/css" href="../css/bootstrap/css/ie.css">
    <!--[if lte IE 6]>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap/css/bootstrap.ie6.min.css">
    <![endif]-->
    <script type="text/javascript" src="../css/bootstrap/js/jquery-1.7.2.min.js"></script>
    <script src="js/scroll.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#madeloans").on("mouseover", function () {
                $(this).css("cursor", "pointer");
            }).on("mouseout", function () {
                $(this).css("cursor", "default");
            });

            $("div.list").myScroll({
                speed: 40,  //滚动速度,值越大速度越慢
                rowHeight: 30 //每行的高度
            });
        });
    </script>
</head>

<body>
    <form id="form1" runat="server" style="margin-bottom: 0">
        <div class="top step-top">
            <div class="wrapper">

                 <div class="user-icon">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <span class="icon">
                                <img src='<%=base.GetUserModel()==null?"../css/img/admin/user_no_frame.png":base.GetUserModel().Avatar%>' alt="" /></span>
                            <div class="down-item">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="true"><span style="color:#000;"><%=base.GetUserModel()==null?"<a href='/Login.aspx'>请登录</a>":base.GetUserModel().UserName %></span>
                                    <% if (base.GetUserModel() != null)
                                       {
                                    %>
                                    <span class="caret" style="border-top-color:#000;border-bottom-color:#000"></span>
                                    <%
                                       } %>
                                   
                                </a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="/user/UserAccount.aspx">账户总览</a></li>
                                    <li><a href="/LoginOut.aspx">安全退出</a></li>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </div>
                <ul class="menu fl">
                    <li class="active nav">
                        <a href="javascript:;" class="dropdown-toggle">象牙塔</a>
                    </li>
                    <li class="nav nav-product">
                        <a href="LoanList.aspx" class="dropdown-toggle">雪中送炭</a>
                    </li>
                    <li class="nav nav-case">
                        <a href="ManageMoneyNav.aspx" class="dropdown-toggle">聚宝盆</a>
                    </li>
                    <li class="nav nav-support">
                        <a href="About.aspx" class="dropdown-toggle">关于我们</a>
                    </li>
                </ul>
            </div>
        </div>

        <div class="container-wrap step-wrap">

            <div class="<%=this.StepBackground %>">

                <div class="wrapper">

                    <div class="head-info">

                        <div class="num-wrap">
                            <h3>目前申请人数</h3>

                            <h2 class="num-red"><%=this.GetLoanTotalCount %></h2>

                            <h3 class="click-sent">点击申请</h3>

                            <p><a class="btn btn-danger border-rb5" href="LoanList.aspx">借款</a></p>

                            <p><a class="btn btn-danger border-rb5" href="ManageMoneyNav.aspx">理财</a></p>
                        </div>

                        <div class="right-info">

                            <div class="logo">
                                <img src="../css/img/admin/logo.png" alt="" />
                            </div>

                            <div class="blue-bg">
                                <div class="blue-title made-loans">
                                    <span>
                                        <img src="../css/img/admin/min_user.jpg" alt="" />
                                    </span>

                                    <h3 id="madeloans" onclick="window.location.href='/user/UserAccount.aspx'">我的易贷 made loans</h3>
                                </div>
                            </div>

                            <div class="right-items">
                                <h4>信用积分</h4>

                                <div class="blue-bg">
                                    <div class="blue-title">
                                        <asp:Label ID="lblPoint" runat="server" Text="0"></asp:Label>分
                                    </div>
                                </div>
                            </div>

                            <div class="right-items">
                                <h4>归还时间</h4>

                                <div class="blue-bg">
                                    <div class="blue-title">
                                        <asp:Label ID="lblRepaymentTime" runat="server" Text="---"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="right-items">
                                <h4>归还金额</h4>

                                <div class="blue-bg">
                                    <div class="blue-title">
                                        <asp:Label ID="lblRepaymentMoney" runat="server" Text="0"></asp:Label>元
                                    </div>
                                </div>
                            </div>

                            <div class="right-items">
                                <h4>归还进度</h4>

                                <div class="blue-bg">
                                    <div class="blue-title">
                                        <asp:Label ID="lblAmortization" runat="server" Text="0"></asp:Label>期
                                    </div>
                                </div>
                            </div>
                            <div class="blue-bg">
                                <div class="person">
                                    <div class="blue-title">已申请人名单</div>
                                    <div class="cont list" style="height: 120px; overflow: hidden;">
                                        <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                                            <HeaderTemplate>
                                                <ul>
                                            </HeaderTemplate>
                                            <EmptyDataTemplate>
                                                <ul>
                                                    <li>暂无申请记录</li>
                                                </ul>
                                            </EmptyDataTemplate>
                                            <ItemTemplate>
                                                <li style="border-bottom: 1px solid #d2cdc7; height: 30px; line-height: 30px;"><span style="float: right; line-height: 30px; margin-left: 40px;">已申请<%#Eval("LoanMoney") %>元</span> <%#Eval("SchoolName") %> </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </StudentLoan:RepeaterPlus>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div class="step-icons">

                        <div class="icon-item">
                            <span class="icon lover"></span>

                            <h3>因为爱情</h3>

                            <p>lover</p>
                        </div>

                        <div class="icon-item">
                            <span class="icon travel"></span>

                            <h3>游山玩水</h3>

                            <p>travel</p>
                        </div>


                        <div class="icon-item">
                            <span class="icon fashion"></span>

                            <h3>时尚达人</h3>

                            <p>fashion</p>
                        </div>


                        <div class="icon-item">
                            <span class="icon myself"></span>

                            <h3>追求自我</h3>

                            <p>myself</p>
                        </div>

                        <div class="icon-item">
                            <span class="icon help"></span>

                            <h3>急人所急</h3>

                            <p>help</p>
                        </div>

                    </div>

                    <div class="foot-txt">
                        <h2 class="max">高效 / 安全 / 保密</h2>
                        <p>学子易贷会员所发布展示信息版权归原作者所有。</p>
                        <p>任何商业用途均须联系作者，如未经授权用作他处，作者将保留追究侵权者法律责任的权利。</p>
                        <p>苏ICP备案14046554号</p>
                        <p>工作时间：周一至周五 9:00-17:50</p>
                        <p style="display: none;">
                            <script type="text/javascript">
                                var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
                                document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F6da3d5b62fcd9bb4660cd659e0894d39' type='text/javascript'%3E%3C/script%3E"));
                            </script>
                        </p>
                    </div>

                    <div class="clear"></div>

                </div>
            </div>
        </div>


        <script type="text/javascript" src="../css/bootstrap/js/bootstrap.min.js"></script>
        <!--[if lte IE 6]>
  <!-- bsie js 补丁只在IE6中才执行 -->
        <script type="text/javascript" src="../css/bootstrap/js/bootstrap-ie.js"></script>
        <![endif]-->
    </form>
</body>

</html>
