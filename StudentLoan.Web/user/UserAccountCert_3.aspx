<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_3.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 必要信用认证</title>
    <script src="../js/jquery.uploadify.js"></script>
    <script type="text/javascript">
        $(function () {
            var target = $(".uploadify-button");
            target.each(function () {
                var typeId = $(this).attr("typeId");
                var _for = $(this).attr("for");
                $(this).uploadify({
                    swf: '../uploadify.swf',
                    uploader: '../tools/upload_cert.ashx?type=' + typeId + '&userId=<%=base.GetUserModel().UserId%>',
                    width: 212,
                    buttonText: "上传并预览",
                    fileTypeExts: '*.gif; *.jpg;*.jpeg; *.png',
                    fileSizeLimit: '500KB',
                    buttonClass: 'btn mt5 btn-primary',
                    onUploadSuccess: function (file, data, response) {

                        var json_data = $.parseJSON(data);
                        if (json_data.result == "true") {
                            $("#" + _for).attr("src", json_data.url);
                        } else {
                            alert("上传失败");
                        }

                    }
                });
            });

        });
    </script>
    <style type="text/css">
        .uploadify-queue-item {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="UserAccountCert.aspx">信用分数表</a></li>
                <li><a href="UserAccountCert_2.aspx">基本信息认证</a></li>
                <li class="active"><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li><a href="UserAccountCert_4.aspx">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered">
                    <caption>身份证认证</caption>
                    <thead>
                        <tr>
                            <th>照片角度/场景</th>
                            <th>预览/上传</th>
                            <th>示例</th>
                            <th>要求</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>手持身份证照片</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgIdentityCard" runat="server" Width="237" Height="168" ClientIDMode="Static" ImageUrl="../css/img/admin/identity_default.jpg" />
                                    <input id="btnUploadIdentityCard_1" typeid="0" for="imgIdentityCard" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.五官可见</p>

                                <p>2.证件全部信息无遮拦</p>

                                <p>3.完整漏出双手手臂</p>
                            </td>
                        </tr>
                        <tr>
                            <td>身份证正面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgIdentityCard2" runat="server" Width="237" Height="168" ClientIDMode="Static" ImageUrl="../css/img/admin/identity_front.jpg" />
                                    <input id="btnUploadIdentityCard_2" typeid="1" for="imgIdentityCard2" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_front_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                            </td>
                        </tr>
                         <tr>
                            <td>身份证背面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="btnUploadIdentityCard3" runat="server" Width="237" Height="168" ClientIDMode="Static" ImageUrl="../css/img/admin/parents_back.jpg" />
                                    <input id="btnUploadIdentityCard_3" typeid="17" for="imgIdentityCard3" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_back.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>学生证认证</caption>
                    <thead>
                        <tr>
                            <th>照片角度/场景</th>
                            <th>预览/上传</th>
                            <th>示例</th>
                            <th>要求</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>学生证正面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgStudentId_1" runat="server" Width="237" Height="168" ClientIDMode="Static" ImageUrl="../css/img/admin/student_front.jpg" />
                                    <input id="btnUploadStudentId_1" typeid="2" for="imgStudentId_1" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/student_front_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                            </td>
                        </tr>
                        <tr>
                            <td>学生证内容</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgStudentId_2" runat="server" Width="237" Height="168" ClientIDMode="Static" ImageUrl="../css/img/admin/student_content.jpg" />
                                    <input id="btnUploadStudentId_2" typeid="3" for="imgStudentId_2" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/student_content_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="item">
                <div class="w400 ptb20 auto">
                    <p class="text-center">
                        警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                    </p>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
