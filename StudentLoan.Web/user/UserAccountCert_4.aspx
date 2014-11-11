<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_4.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 可选认证</title>
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
                <li><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li class="active"><a href="javascript:;">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered">
                    <caption>学贷网截图（学信网网址：<a href="javascript:;">www.chsi.com.cn</a>）</caption>
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
                                    <img id="imgXuexin" style="width: 237px; height: 168px;" src='<%=this.XueXin==null?"../css/img/admin/search_result.jpg":this.XueXin.Images %>' alt="" />
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
                                    <img id="imgBank" style="width: 237px; height: 168px;" src='<%=this.Bank==null?"../css/img/admin/card.jpg":this.Bank.Images %>' alt="" />
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
                                    <img id="imgAlipay" style="width: 237px; height: 168px;" src='<%=this.Alipay==null?"../css/img/admin/internetbank.jpg":this.Alipay.Images %>' alt="" />
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
                    <caption>手机通话记录清单</caption>
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
                                    <img id="imgMobile" style="width: 237px; height: 168px;" src='<%=this.Mobile==null?"../css/img/admin/telephone.jpg":this.Mobile.Images %>' alt="" />
                                    <input id="btnUploadMobile" typeid="7" for="imgMobile" name="fileData" type="file" class="uploadify-button" />
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/telephone_ex.jpg" alt="" />
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

                                    <img id="imgParents1" style="width: 237px; height: 168px;" src='<%=this.Parents1==null?"../css/img/admin/parents.jpg":this.Parents1.Images %>' alt="" />
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
                                    <img id="imgParents2" style="width: 237px; height: 168px;" src='<%=this.Parents2==null?"../css/img/admin/parents_back.jpg":this.Parents2.Images %>' alt="" />
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
                                    <img id="imgRoommate1" style="width: 237px; height: 168px;" src='<%=this.Roommate1==null?"../css/img/admin/identity_default.jpg":this.Roommate1.Images %>' alt="" />
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
                                    <img id="imgRoommate2" style="width: 237px; height: 168px;" src='<%=this.Roommate2 ==null?"../css/img/admin/identity_front.jpg":this.Roommate2.Images %>' alt="" />
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
                                    <img id="imgStudentId1" style="width: 237px; height: 168px;" src='<%=this.StudentId1==null?"../css/img/admin/student_front.jpg":this.StudentId1.Images %>' alt="" />
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
                                    <img id="imgStudentId2" style="width: 237px; height: 168px;" src='<%=this.StudentId2==null?"../css/img/admin/student_content.jpg":this.StudentId2.Images %>' alt="" />
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
                                    <img id="imgResidencebooklet" style="width: 237px; height: 168px;" src='<%=this.Residencebooklet==null?"../css/img/admin/booklet.jpg":this.Residencebooklet.Images %>' alt="" />
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
                                    <img id="imgDriversLicense" style="width: 237px; height: 168px;" src='<%=this.DriversLicense==null?"../css/img/admin/carbook.jpg":this.DriversLicense.Images %>' alt="" />
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
                                    <img id="imgAwards" style="width: 237px; height: 168px;" src='<%=this.Awards==null?"../css/img/admin/cup.jpg":this.Awards.Images %>' alt="" />
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
