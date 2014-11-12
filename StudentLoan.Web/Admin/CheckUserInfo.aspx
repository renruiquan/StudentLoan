<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckUserInfo.aspx.cs" Inherits="StudentLoan.Web.Admin.CheckUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.utils.js"></script>
    <link href="jBox/Skins/Green/jbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jBox/jquery.jBox-2.3.min.js"></script>

    <script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="container">
            <div class="location">当前位置：借款管理 -&gt; 借款记录 -&gt; 审核用户</div>

            <div class="blank10"></div>

            <div class="search block">
                <div class="h">
                    <span class="icon-sprite icon-magnifier"></span>
                    <h3>审核用户</h3>
                    <div class="bar">
                        <label><a class="btn-lit btn-middle btn-lit-top" id="btnPass" runat="server" onserverclick="btnPass_ServerClick" href="javascript:void(0)"><span>通过</span></a></label>
                        <label><a class="btn-lit btn-middle btn-lit-top" id="btnRefuse" runat="server" onserverclick="btnRefuse_ServerClick" href="javascript:void(0)"><span>驳回</span></a></label>
                    </div>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <div class="search-bar">
                            <div style="margin-right: 5px;">
                                <asp:TextBox ID="txtRefuse" runat="server" TextMode="MultiLine" Rows="5" Style="width: 100%; height: 100%;" placeholder="请输入驳回原因！"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>基本信息</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-form" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <th scope="row">真实姓名：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblTrueName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">身份证号：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblIdentityCard" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">手机号码：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblUserMobile" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">性别：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblGender" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <th scope="row">民族：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblNation" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">出生日期：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblBirthday" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>


            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>学校信息</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-form" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <th scope="row">学信网账号：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblXueXinUserName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">学信网密码：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblXueXinPassword" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">就读学校：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblSchoolName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">学校地址：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblSchoolAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">入学日期：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblYearOfAdmission" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <th scope="row">学制：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblSchoolSystem" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">学历：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblEducation" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">专业（系）</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblMajor" runat="server"></asp:Label>
                                    </td>

                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>联系人</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-form" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <th scope="row">亲属姓名：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblFamilyName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">与本人关系：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblRelationship" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">手机号码：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblFamilyMobile" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">职业：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblProfession" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>

                                    <td colspan="2">
                                        <div style="border-bottom: 1px solid #d9d9d9 !important; margin: 0 20px;"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">室友姓名：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblStudentName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">室友电话：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblStudentMobile" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>

                                    <td colspan="2">
                                        <div style="border-bottom: 1px solid #d9d9d9 !important; margin: 0 20px;"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">朋友姓名：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblFriendName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">朋友电话：</th>
                                    <td>
                                        <asp:Label Text="暂无资料" ID="lblFriendMobile" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>必要信用认证</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <th>身份证正面</th>
                                    <th>身份证背面</th>
                                    <th>学生证背面</th>
                                    <th>学生证背面</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgIdentityCard1" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgIdentityCard2" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgStudentId1" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgStudentId2" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>


            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>可选信用认证（一）</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <th>学信网截图</th>
                                    <th>银行卡流水</th>
                                    <th>支付流水</th>
                                    <th>手机通话详单</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgXueXin" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgBank" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgAlipay" ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgMobile"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>可选信用认证（二）</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <th>家长身份证正面</th>
                                    <th>家长身份证背面</th>
                                    <th>室友手持身份证</th>
                                    <th>室友身份证正面</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgParents1"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgParents2"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgRoommateIdentityCard1"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgRoommateIdentityCard2"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>可选信用认证（三）</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <th>室友学生证正面</th>
                                    <th>室友学生证内空</th>
                                    <th>户口薄内容</th>
                                    <th>行驶证内容</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgRoommateStudentId1"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgRoommateStudentId2"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgResidencebooklet"  ImageAlign="Left" Style="margin: 20px;"/>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgDriversLicense" ImageAlign="Left" Style="margin: 20px;" />
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>可选信用认证（四）</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <th colspan="4">获奖证书</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image runat="server" Width="350" Height="250" ID="imgAwards" ImageAlign="Left" Style="margin: 20px;" />
                                    </td>


                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
