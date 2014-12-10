<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_4.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 可选认证</title>
    <script src="../js/jquery.uploadify.js"></script>
    <script type="text/javascript">
        $(function () {
            var target = $(".uploadify-button");
            var fileCount = 0; //上传文件数量
            var number = 0;    //图片编号
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
                    onDialogClose: function (queueData) {
                        fileCount = queueData.filesQueued;
                        number = fileCount;
                    },
                    onUploadSuccess: function (file, data, response) {
                        var json_data = $.parseJSON(data);
                        if (json_data.result == "true") {
                            $("#" + _for).attr("src", json_data.url);
                            if (_for == "imgBank") {

                                $("#imgBank_0").parent().remove();
                                if (number == fileCount) {
                                    $("#CarouselItems").children().removeClass("active");
                                    $("#CarouselItems").append("<div class=\"item active\"><img id=\"imgBank_" + number + "\" style='width:237px;height:168px;' src=\"" + json_data.url + "\" /></div>");
                                } else {
                                    $("#CarouselItems").append("<div class=\"item\"><img id=\"imgBank_" + number + "\" style='width:237px;height:168px;' src=\"" + json_data.url + "\" /></div>");
                                }

                                number--;
                            }
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
                <li><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li class="active"><a href="javascript:;">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered">
                    <caption>学信网截图（学信网网址：<a href="http://www.chsi.com.cn" target="_blank">www.chsi.com.cn</a>）</caption>
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
                            <td>查询结果截图</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgXuexin" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/search_result.jpg" />
                                    <input id="btnUploadXuexin" typeid="4" for="imgXuexin" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/search_result_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.字迹清晰可见</p>

                                <p>2.必须是查询结果截图</p>

                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>银行卡流水（可以去银行拉取）</caption>
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
                            <td>正面</td>
                            <td class="w260">
                                <div class="m10">

                                    <div id="myCarousel" class="carousel slide">

                                        <!-- Carousel items -->
                                        <div id="CarouselItems" class="carousel-inner">
                                            <asp:Literal ID="litBank" runat="server">
                                                
                                            </asp:Literal>
                                        </div>

                                        <!-- Carousel nav -->
                                        <a class="carousel-control left" style="margin-top: 0; text-align: right;" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                                        <a class="carousel-control right" style="margin-top: 0; text-align: right;" href="#myCarousel" data-slide="next">&rsaquo;</a>
                                    </div>
                                    <input id="btnUploadBankPic" typeid="5" for="imgBank" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/card_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.字迹清晰可见</p>

                                <p>2.必须是查询结果截图</p>

                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>


            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>支付宝流水截图</caption>
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
                            <td>全屏</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgAlipay" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/internetbank.jpg" />
                                    <input id="btnUploadAlipay" typeid="6" for="imgAlipay" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/internetbank_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.字迹清晰可见</p>

                                <p>2.必须是查询结果截图</p>
                            </td>
                        </tr>

                    </tbody>
                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>家长身份证认证</caption>
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
                            <td>父母身份证正面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgParents1" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/parents.jpg" />
                                    <input id="btnUploadParents1" typeid="8" for="imgParents1" name="fileData" type="file" class="uploadify-button" />
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
                            <td>父母身份证反面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgParents2" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/parents_back.jpg" />
                                    <input id="btnUploadParents2" typeid="9" for="imgParents2" name="fileData" type="file" class="uploadify-button" />
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
                    <caption>室友身份证认证</caption>
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
                                    <asp:Image ID="imgRoommate1" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/identity_default.jpg" />
                                    <input id="btnUploadRoommate1" typeid="10" for="imgRoommate1" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.五官课件</p>

                                <p>2.证件全部信息无遮拦</p>

                                <p>3.完整漏出双手手臂</p>

                            </td>
                        </tr>
                        <tr>
                            <td>身份证正面</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgRoommate2" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/identity_front.jpg" />
                                    <input id="btnUploadRoommate2" typeid="11" for="imgRoommate2" name="fileData" type="file" class="uploadify-button" />
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
                    </tbody>
                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>室友学生证认证</caption>
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
                                    <asp:Image ID="imgStudentId1" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/student_front.jpg" />
                                    <input id="btnUploadimgStudentId1" typeid="12" for="imgStudentId1" name="fileData" type="file" class="uploadify-button" />
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
                                    <asp:Image ID="imgStudentId2" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/student_content.jpg" />
                                    <input id="btnUploadStudentId2" typeid="13" for="imgStudentId2" name="fileData" type="file" class="uploadify-button" />
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


            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>户口簿（申请人家庭）</caption>
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
                            <td>户口薄内容页</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgResidencebooklet" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/booklet.jpg" />
                                    <input id="btnUploadResidencebooklet" typeid="14" for="imgResidencebooklet" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/booklet_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>字迹清晰可见</p>

                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>


            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>本人行驶证</caption>
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
                            <td>行驶证内容页</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgDriversLicense" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/carbook.jpg" />
                                    <input id="btnUploadDriversLicense" typeid="15" for="imgDriversLicense" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/carbook_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>1.本人手持行驶证照片</p>
                                <p>2.证件上文字清晰可识别</p>

                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>获奖证明</caption>
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
                            <td>获奖证书内容</td>
                            <td class="w260">
                                <div class="m10">
                                    <asp:Image ID="imgAwards" runat="server" ClientIDMode="Static" Width="237" Height="168" ImageUrl="../css/img/admin/cup.jpg" />
                                    <input id="btnUploadAwards" typeid="16" for="imgAwards" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/cup_ex.jpg" alt="" />
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
