<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_4.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <img src="../css/img/admin/search_result.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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

                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

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
                                    <img src="../css/img/admin/card.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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

                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>


            <div class="clear mt20"></div>

            <div class="item">

                <table class="table table-bordered">
                    <caption>网银或者支付宝流水截图</caption>
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
                                    <img src="../css/img/admin/internetbank.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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

                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

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
                                    <img src="../css/img/admin/telephone.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/telephone_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>字迹清晰可见</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

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

                                    <div class="w110 m5 fl">
                                        <img src="../css/img/admin/parents.jpg" alt="" />
                                        <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                    </div>

                                    <div class="w110 m5 fl">
                                        <img src="../css/img/admin/parents.jpg" alt="" />
                                        <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                    </div>

                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_front_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

                            </td>
                        </tr>
                        <tr>
                            <td>父母身份证反面</td>
                            <td class="w260">
                                <div class="m10">

                                    <div class="w110 m5 fl">
                                        <img src="../css/img/admin/parents_back.jpg" alt="" />
                                        <button class="mt10 btn btn-primary" type="button">上传并预览</button>
                                    </div>

                                    <div class="w110 m5 fl">
                                        <img src="../css/img/admin/parents_back.jpg" alt="" />
                                        <button class="mt10 btn btn-primary" type="button">上传并预览</button>
                                    </div>

                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_back.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>

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
                                    <img src="../css/img/admin/identity_default.jpg" alt="" />
                                    <button class="mt10 btn btn-primary" type="button">上传并预览</button>
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
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>身份证正面</td>
                            <td class="w260">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_front.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/identity_front_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
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
                                    <img src="../css/img/admin/student_front.jpg" alt="" />
                                    <button class="mt10 btn btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/student_front_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>学生证内容</td>
                            <td class="w260">
                                <div class="m10">
                                    <img src="../css/img/admin/student_content.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/student_content_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
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
                                    <img src="../css/img/admin/booklet.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/booklet_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>字迹清晰可见</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
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
                                    <img src="../css/img/admin/carbook.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
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
                                    <img src="../css/img/admin/cup.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
                                </div>
                            </td>
                            <td class="w260" style="vertical-align: top;">
                                <div class="m10">
                                    <img src="../css/img/admin/cup_ex.jpg" alt="" />
                                </div>
                            </td>
                            <td>
                                <p>证件上文字清晰可识别</p>
                                <p class="w130 auto">
                                    <button type="submit" class="btn btn-success">保存并继续</button>
                                </p>
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

                    <p class="w400 ptb20 text-center">
                        <button class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                    </p>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
