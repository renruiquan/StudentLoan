<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_3.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <img src="../css/img/admin/identity_default.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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
                                    <img src="../css/img/admin/student_front.jpg" alt="" />
                                    <button class="mt10 btn btn-block btn-primary" type="button">上传并预览</button>
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
