<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="StudentLoan.Web.Admin.MainMenu" %>

<!DOCTYPE html>
<!-- Template Name: Rapido - Responsive Admin Template build with Twitter Bootstrap 3.x Version: 1.0 Author: ClipTheme -->
<!--[if IE 8]><html class="ie8" lang="en"><![endif]-->
<!--[if IE 9]><html class="ie9" lang="en"><![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- start: HEAD -->
<head>
    <title>Rapido - Responsive Admin Template</title>
    <!-- start: META -->
    <meta charset="utf-8" />
    <!--[if IE]><meta http-equiv='X-UA-Compatible' content="IE=edge,IE=9,IE=8,chrome=1" /><![endif]-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- end: META -->
    <!-- start: MAIN CSS -->
    <link href='http://fonts.useso.com/css?family=Raleway:400,300,500,600,700,200,100,800' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="../theme/plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../theme/plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../theme/plugins/iCheck/skins/all.css">
    <link rel="stylesheet" href="../theme/plugins/perfect-scrollbar/src/perfect-scrollbar.css">
    <link rel="stylesheet" href="../theme/plugins/animate.css/animate.min.css">
    <!-- end: MAIN CSS -->
    <!-- start: CSS REQUIRED FOR SUBVIEW CONTENTS -->
    <link rel="stylesheet" href="../theme/plugins/owl-carousel/owl-carousel/owl.carousel.css">
    <link rel="stylesheet" href="../theme/plugins/owl-carousel/owl-carousel/owl.theme.css">
    <link rel="stylesheet" href="../theme/plugins/owl-carousel/owl-carousel/owl.transitions.css">
    <link rel="stylesheet" href="../theme/plugins/summernote/dist/summernote.css">
    <link rel="stylesheet" href="../theme/plugins/fullcalendar/fullcalendar/fullcalendar.css">
    <link rel="stylesheet" href="../theme/plugins/toastr/toastr.min.css">
    <link rel="stylesheet" href="../theme/plugins/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="../theme/plugins/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.min.css">
    <link rel="stylesheet" href="../theme/plugins/DataTables/media/css/DT_bootstrap.css">
    <link rel="stylesheet" href="../theme/plugins/bootstrap-fileupload/bootstrap-fileupload.min.css">
    <link rel="stylesheet" href="../theme/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css">
    <!-- end: CSS REQUIRED FOR THIS SUBVIEW CONTENTS-->
    <!-- start: CSS REQUIRED FOR THIS PAGE ONLY -->
    <link href="../theme/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../theme/plugins/slider/css/slider.css">
    <link rel="stylesheet" href="../theme/plugins/jQRangeSlider/css/classic-min.css">
    <!-- end: CSS REQUIRED FOR THIS PAGE ONLY -->
    <!-- start: CORE CSS -->
    <link rel="stylesheet" href="../theme/css/styles.css">
    <link rel="stylesheet" href="../theme/css/styles-responsive.css">
    <link rel="stylesheet" href="../theme/css/plugins.css">
    <link rel="stylesheet" href="../theme/css/themes/theme-default.css" type="text/css" id="skin_color">
    <link rel="stylesheet" href="../theme/css/print.css" type="text/css" media="print" />
    <!-- end: CORE CSS -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- end: HEAD -->
<!-- start: BODY -->
<body>

    <div class="main-wrapper">
        <!-- start: TOPBAR -->
        <header class="topbar navbar navbar-inverse navbar-fixed-top inner">
            <!-- start: TOPBAR CONTAINER -->
            <div class="container">
                <div class="navbar-header">
                    <a class="sb-toggle-left hidden-md hidden-lg" href="#main-navbar">
                        <i class="fa fa-bars"></i>
                    </a>

                </div>
                <div class="topbar-tools">
                    <!-- start: TOP NAVIGATION MENU -->
                    <ul class="nav navbar-right">
                        <!-- start: USER DROPDOWN -->
                        <li class="dropdown current-user">
                            <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" data-close-others="true" href="#">
                                <img src="../theme/images/avatar-1-small.jpg" class="img-circle" alt="">
                                <span class="username hidden-xs">Administrator</span> <i class="fa fa-caret-down "></i>
                            </a>
                            <ul class="dropdown-menu dropdown-dark">
                                <li>
                                    <a href="login_login.html">安全退出
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <!-- end: USER DROPDOWN -->
                    </ul>
                    <!-- end: TOP NAVIGATION MENU -->
                </div>
            </div>
            <!-- end: TOPBAR CONTAINER -->
        </header>
        <!-- end: TOPBAR -->
        <!-- start: PAGESLIDE LEFT -->
        <a class="closedbar inner hidden-sm hidden-xs" href="#"></a>
        <nav id="pageslide-left" class="pageslide inner">
            <div class="navbar-content">
                <!-- start: SIDEBAR -->
                <div class="main-navigation left-wrapper transition-left">
                    <div class="navigation-toggler hidden-sm hidden-xs">
                       
                    </div>
                    <div class="user-profile border-top padding-horizontal-10 block">
                        <div class="inline-block">
                            <img src="../theme/images/avatar-1.jpg" alt="">
                        </div>
                        <div class="inline-block">
                            <h5 class="no-margin">Welcome </h5>
                            <h4 class="no-margin">Administrator </h4>

                        </div>
                    </div>
                    <!-- start: MAIN NAVIGATION MENU -->
                    <ul class="main-navigation-menu">
                        <li class="active">
                            <a href="default.aspx"><i class="fa fa-home"></i><span class="title">首页 </span></a>
                        </li>
                        <li>
                            <a href="javascript:void(0)"><i class="fa fa-user"></i><span class="title">用户管理 </span><i class="icon-arrow"></i></a>
                            <ul class="sub-menu">
                                <li>
                                    <a href="layouts_sidebar_closed.html">
                                        <span class="title">用户列表 </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="layouts_sidebar_not_fixed.html">
                                        <span class="title">充值记录 </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="layouts_boxed_layout.html">
                                        <span class="title">消费记录 </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="layouts_footer_fixed.html">
                                        <span class="title">提现记录 </span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="javascript:void(0)"><i class="fa fa-th-large"></i><span class="title">理财管理 </span><i class="icon-arrow"></i></a>
                            <ul class="sub-menu">
                                <li>
                                    <a href="ProductSchemeList.aspx" target="frame_ifrm">
                                        <span class="title">理财方案</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="table.html" target="frame_ifrm">
                                        <span class="title">理财产品</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="layouts_sidebar_not_fixed.html">
                                        <span class="title">理财记录</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="javascript:void(0)"><i class="fa fa-pencil-square-o"></i><span class="title">借款管理 </span><i class="icon-arrow"></i></a>
                            <ul class="sub-menu">
                                <li>
                                    <a href="UserLoanApplyList.aspx" target="frame_ifrm">
                                        <span class="title">借款记录 </span>
                                    </a>
                                </li>

                            </ul>
                        </li>
                        <li>
                            <a href="javascript:void(0)"><i class="fa fa-cogs"></i><span class="title">系统管理</span><i class="icon-arrow"></i> </a>
                            <ul class="sub-menu">
                                <li>
                                    <a href="login_login.html">
                                        <span class="title">管理员管理 </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="login_login.html?box=register">
                                        <span class="title">登录日志</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <!-- end: MAIN NAVIGATION MENU -->
                </div>
                <!-- end: SIDEBAR -->
            </div>
            <div class="slide-tools">
                <div class="col-xs-6 text-left no-padding">
                    <a class="btn btn-sm status" href="#">Status <i class="fa fa-dot-circle-o text-green"></i><span>Online</span>
                    </a>
                </div>
                <div class="col-xs-6 text-right no-padding">
                    <a class="btn btn-sm log-out text-right" href="login_login.html">
                        <i class="fa fa-power-off"></i>Log Out
                    </a>
                </div>
            </div>
        </nav>
        <!-- end: PAGESLIDE LEFT -->

        <!-- start: MAIN CONTAINER -->
        <div class="main-container inner" style="margin-left: 260px;  margin-top: 36px !important;">
            <!-- start: PAGE -->
            <div class="main-content">
                <iframe id="frame_ifrm" name="frame_ifrm" frameborder="0" width="100%" scrolling="yes" src="about:blank"></iframe>
            </div>
            <!-- end: PAGE -->
        </div>
        <!-- end: MAIN CONTAINER -->
        <!-- start: FOOTER -->
        <footer class="inner">
            <div class="footer-inner">
                <div class="pull-left">
                    2014 &copy; Rapido by cliptheme.
                </div>
                <div class="pull-right">
                    <span class="go-top"><i class="fa fa-chevron-up"></i></span>
                </div>
            </div>
        </footer>
        <!-- end: FOOTER -->
        <!-- start: SUBVIEW SAMPLE CONTENTS -->
        <!-- *** NEW NOTE *** -->
     
        <!-- *** READ NOTE *** -->
        <div id="readNote">
            <div class="barTopSubview">
                <a href="#newNote" class="new-note button-sv"><i class="fa fa-plus"></i>Add new note</a>
            </div>
            <div class="noteWrap col-md-8 col-md-offset-2">
                <div class="panel panel-note">
                    <div class="e-slider owl-carousel owl-theme">
                        <div class="item">
                            <div class="panel-heading">
                                <h3>This is a Note</h3>
                            </div>
                            <div class="panel-body">
                                <div class="note-short-content">
                                    Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam...
                                </div>
                                <div class="note-content">
                                    Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua.
										Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat.
										Quis aute iure reprehenderit in <strong>voluptate velit</strong> esse cillum dolore eu fugiat nulla pariatur.
										<br>
                                    Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
										<br>
                                    Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci v'elit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem.
										<br>
                                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut <strong>aliquid ex ea commodi consequatur?</strong>
                                    <br>
                                    Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur?
										<br>
                                    At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.
										<br>
                                    Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae.
										<br>
                                    Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
                                </div>
                                <div class="note-options pull-right">
                                    <a href="#readNote" class="read-note"><i class="fa fa-chevron-circle-right"></i>Read</a><a href="#" class="delete-note"><i class="fa fa-times"></i> Delete</a>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="avatar-note">
                                    <img src="../theme/images/avatar-2-small.jpg" alt="">
                                </div>
                                <span class="author-note">Nicole Bell</span>
                                <time class="timestamp" title="2014-02-18T00:00:00-05:00">2014-02-18T00:00:00-05:00
                                </time>
                            </div>
                        </div>
                        <div class="item">
                            <div class="panel-heading">
                                <h3>This is the second Note</h3>
                            </div>
                            <div class="panel-body">
                                <div class="note-short-content">
                                    Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Nemo enim ipsam voluptatem, quia voluptas sit...
                                </div>
                                <div class="note-content">
                                    Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
										<br>
                                    Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci v'elit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem.
										<br>
                                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut <strong>aliquid ex ea commodi consequatur?</strong>
                                    <br>
                                    Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur?
										<br>
                                    Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae.
										<br>
                                    Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
                                </div>
                                <div class="note-options pull-right">
                                    <a href="#" class="read-note"><i class="fa fa-chevron-circle-right"></i>Read</a><a href="#" class="delete-note"><i class="fa fa-times"></i> Delete</a>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="avatar-note">
                                    <img src="../theme/images/avatar-3-small.jpg" alt="">
                                </div>
                                <span class="author-note">Steven Thompson</span>
                                <time class="timestamp" title="2014-02-18T00:00:00-05:00">2014-02-18T00:00:00-05:00
                                </time>
                            </div>
                        </div>
                        <div class="item">
                            <div class="panel-heading">
                                <h3>This is yet another Note</h3>
                            </div>
                            <div class="panel-body">
                                <div class="note-short-content">
                                    At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores...
                                </div>
                                <div class="note-content">
                                    At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.
										<br>
                                    Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
										<br>
                                    Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci v'elit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem.
										<br>
                                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut <strong>aliquid ex ea commodi consequatur?</strong>
                                </div>
                                <div class="note-options pull-right">
                                    <a href="#" class="read-note"><i class="fa fa-chevron-circle-right"></i>Read</a><a href="#" class="delete-note"><i class="fa fa-times"></i> Delete</a>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="avatar-note">
                                    <img src="../theme/images/avatar-4-small.jpg" alt="">
                                </div>
                                <span class="author-note">Ella Patterson</span>
                                <time class="timestamp" title="2014-02-18T00:00:00-05:00">2014-02-18T00:00:00-05:00
                                </time>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      
       
      
        <div id="showContributors">
            <div class="barTopSubview">
                <a href="#newContributor" class="new-contributor button-sv"><i class="fa fa-plus"></i>Add new contributor</a>
            </div>
            <div class="noteWrap col-md-10 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div id="contributors">
                            <div class="options-contributors hide">
                                <div class="btn-group">
                                    <button class="btn dropdown-toggle btn-transparent-grey" data-toggle="dropdown">
                                        <i class="fa fa-cog"></i>
                                        <span class="caret"></span>
                                    </button>
                                    <ul role="menu" class="dropdown-menu dropdown-light pull-right">
                                        <li>
                                            <a href="#newContributor" class="show-subviews edit-contributor">
                                                <i class="fa fa-pencil"></i>Edit
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#" class="delete-contributor">
                                                <i class="fa fa-times"></i>Delete
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end: SUBVIEW SAMPLE CONTENTS -->
    </div>
    <!-- start: MAIN JAVASCRIPTS -->
    <!--[if lt IE 9]>
		<script src="../theme/plugins/respond.min.js"></script>
		<script src="../theme/plugins/excanvas.min.js"></script>
		<script type="text/javascript" src="../theme/plugins/jQuery/jquery-1.11.1.min.js"></script>
		<![endif]-->
    <!--[if gte IE 9]><!-->
    <script src="../theme/plugins/jQuery/jquery-2.1.1.min.js"></script>
    <!--<![endif]-->
    <script src="../theme/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="../theme/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="../theme/plugins/blockUI/jquery.blockUI.js"></script>
    <script src="../theme/plugins/iCheck/jquery.icheck.min.js"></script>
    <script src="../theme/plugins/moment/min/moment.min.js"></script>
    <script src="../theme/plugins/perfect-scrollbar/src/jquery.mousewheel.js"></script>
    <script src="../theme/plugins/perfect-scrollbar/src/perfect-scrollbar.js"></script>
    <script src="../theme/plugins/bootbox/bootbox.min.js"></script>
    <script src="../theme/plugins/jquery.scrollTo/jquery.scrollTo.min.js"></script>
    <script src="../theme/plugins/ScrollToFixed/jquery-scrolltofixed-min.js"></script>
    <script src="../theme/plugins/jquery.appear/jquery.appear.js"></script>
    <script src="../theme/plugins/jquery-cookie/jquery.cookie.js"></script>
    <script src="../theme/plugins/velocity/jquery.velocity.min.js"></script>
    <script src="../theme/plugins/TouchSwipe/jquery.touchSwipe.min.js"></script>
    <!-- end: MAIN JAVASCRIPTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR SUBVIEW CONTENTS -->
    <script src="../theme/plugins/owl-carousel/owl-carousel/owl.carousel.js"></script>
    <script src="../theme/plugins/jquery-mockjax/jquery.mockjax.js"></script>
    <script src="../theme/plugins/toastr/toastr.js"></script>
    <script src="../theme/plugins/bootstrap-modal/js/bootstrap-modal.js"></script>
    <script src="../theme/plugins/bootstrap-modal/js/bootstrap-modalmanager.js"></script>
    <script src="../theme/plugins/fullcalendar/fullcalendar/fullcalendar.min.js"></script>
    <script src="../theme/plugins/bootstrap-switch/dist/js/bootstrap-switch.min.js"></script>
    <script src="../theme/plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="../theme/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="../theme/plugins/bootstrap-fileupload/bootstrap-fileupload.min.js"></script>
    <script src="../theme/plugins/DataTables/media/js/jquery.dataTables.min.js"></script>
    <script src="../theme/plugins/DataTables/media/js/DT_bootstrap.js"></script>
    <script src="../theme/plugins/truncate/jquery.truncate.js"></script>
    <script src="../theme/plugins/summernote/dist/summernote.min.js"></script>
    <script src="../theme/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script src="../theme/js/subview.js"></script>
    <script src="../theme/js/subview-examples.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR SUBVIEW CONTENTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="../theme/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="../theme/plugins/jQRangeSlider/jQAllRangeSliders-min.js"></script>
    <script src="../theme/plugins/modernizr/modernizr.js"></script>
    <script src="../theme/plugins/slider/js/bootstrap-slider.js"></script>
    <script src="../theme/plugins/jQuery-Knob/js/jquery.knob.js"></script>
    <script src="../theme/js/ui-sliders.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <!-- start: CORE JAVASCRIPTS  -->
    <script src="../theme/js/main.js"></script>
    <!-- end: CORE JAVASCRIPTS  -->
    <script>
        jQuery(document).ready(function () {
            Main.init();
            SVExamples.init();
            UISliders.init();

            $("iframe").load(function () {
                $(this).height(0); //用于每次刷新时控制IFRAME高度初始化 
                var height = $(".main-content").height() - 4;
                $(this).height(height);
            });
        });

    </script>
</body>
<!-- end: BODY -->
</html>
