<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_2.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="UserAccountCert.aspx">信用分数表</a></li>
                <li class="active"><a href="UserAccountCert_2.aspx">基本信息认证</a></li>
                <li><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li><a href="UserAccountCert_4.aspx">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="form-horizontal">

                <div class="item">

                    <table>
                        <caption>基本信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>
                                    <div class="control-group mt10">
                                        <label class="control-label" for="inputCard"><span class="c-red">*</span> 开户名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" id="inputCard" placeholder="请输入账号...">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="password"><span class="c-red">*</span> 新密码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" id="password" placeholder="请输入密码">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 确认密码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入密码">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 真实姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入真实姓名">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 身份证号：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入身份证号">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 性别：</label>

                                        <div class="controls text-left">
                                            <input type="text" placeholder="请输入性别">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 民族：</label>

                                        <div class="controls text-left">
                                            <input type="text" placeholder="请输入民族">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 出生日期：</label>

                                        <div class="controls text-left">
                                            <input type="text" placeholder="请输入出生日期">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 籍贯：</label>

                                        <div class="controls text-left">
                                            <input type="text" placeholder="请输入籍贯">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>

                                </td>
                                <td class="w260" style="vertical-align: top">
                                    <div class="m10">
                                        <img src="../css/img/admin/user_icon.jpg" alt="" />
                                        <button class="mt10 btn btn-block btn-primary" type="button">
                                            上传头像
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="item">
                    <table>
                        <caption>学校信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>

                                    <p class="mt10">* 学信网系统认证（请输入学信网的账号与密码，以方便我们核对信息，学子易贷保证您的得账户安全及个人隐私）</p>

                                    <div class="control-group">
                                        <label class="control-label">* 账号：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入账号">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 密码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入密码">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 就读学校：</label>

                                        <div class="controls text-left">
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">中国</option>
                                            </select>
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">北京市</option>
                                            </select>
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">朝阳区</option>
                                            </select>
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label">* 校区：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入校区名称">
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label">* 学校地址：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入学校地址">
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label">* 入学年份：</label>

                                        <div class="controls text-left">
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">朝阳区</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 学制：</label>

                                        <div class="controls text-left">
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">朝阳区</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 学历：</label>

                                        <div class="controls text-left">
                                            <select class="span2" name="">
                                                <option value="">请选择...</option>
                                                <option value="">朝阳区</option>
                                            </select>
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label">* 所在学院：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入所在学院">
                                        </div>
                                    </div>


                                    <div class="control-group">
                                        <label class="control-label">专业（系）：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入所在院系">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">班级：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入所在班级">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">寝室：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入所在寝室">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>


                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="item">
                    <table>
                        <caption>联系人信息（蓝色点为必填项）</caption>
                        <tbody>
                            <tr>
                                <td>

                                    <h3 class="text-left pl20">1.直接亲属联系人</h3>

                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 关系：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入关系">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 职业：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入职业">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 工作单位：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入工作单位">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 单位地址：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入单位地址">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 单位电话：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入单位电话">
                                        </div>
                                    </div>

                                    <h3 class="text-left pl20">2.其他亲属联系人</h3>

                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 关系：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入关系">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 职业：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入职业">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">* 居住地址：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入居住地址">
                                        </div>
                                    </div>

                                    <h3 class="text-left pl20">3.同学（同班）</h3>
                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>
                                    <h3 class="text-left pl20">4.同学（同室）</h3>
                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>
                                    <h3 class="text-left pl20">5.朋友1（必须不是同学）</h3>
                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>
                                    <h3 class="text-left pl20">6.朋友2（必须不是现同学）</h3>
                                    <div class="control-group">
                                        <label class="control-label">* 姓名：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入姓名">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">* 手机号码：</label>

                                        <div class="controls text-left">
                                            <input class="span5" type="text" placeholder="请输入手机号码">
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400">
                                                警告：请确保您填写的资料真实有效，所有资料将会严格保密。一旦发现资料有虚假，
                            将会影响您在学子易贷的信用，对以后借款造成影响
                                            </p>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls text-left">
                                            <p class="w400 text-center">
                                                <button class="mt10 btn btn-large btn-block btn-primary" type="button">保存并继续</button>
                                            </p>
                                        </div>
                                    </div>

                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
