<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert_2.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>
        <link rel="stylesheet" type="text/css" href="../css/jquery-ui.css"/>
     <script type="text/javascript">
        $(document).ready(function () {
            $('.datepickers').datepicker();
        });
    </script>
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
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 真实姓名：</label>

                                        <div class="controls text-left">
                                             <asp:TextBox ID="txtTruename" runat="server" class="span5" type="text" placeholder="请输入真实姓名" />                                            
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 身份证号：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtIdentityCard" runat="server" class="span5" type="text" placeholder="请输入身份证号" />                                            
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 手机号码：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtMobile" runat="server" class="span5" type="text" placeholder="请输入手机号" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 性别：</label>

                                        <div class="controls text-left">
                                            <asp:DropDownList runat="server" ID="ddlGender">
                                                <asp:ListItem Value="">请选择</asp:ListItem>
                                                <asp:ListItem Value="男">男</asp:ListItem>
                                                <asp:ListItem Value="女">女</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 民族：</label>

                                        <div class="controls text-left">
                                               <asp:DropDownList ID="ddlNation" runat="server">
                                                   <asp:ListItem Value="">请选择</asp:ListItem>
                                                    <asp:ListItem Text="汉族" Value="汉族" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="阿昌族" Value="阿昌族"></asp:ListItem>
                                                    <asp:ListItem Text="白族" Value="白族"></asp:ListItem>
                                                    <asp:ListItem Text="保安族" Value="保安族"></asp:ListItem> 
                                                    <asp:ListItem Text="布朗族" Value="布朗族"></asp:ListItem>
                                                    <asp:ListItem Text="布依族" Value="布依族"></asp:ListItem>
                                                    <asp:ListItem Text="朝鲜族" Value="朝鲜族"></asp:ListItem>
                                                    <asp:ListItem Text="达斡尔族" Value="达斡尔族"></asp:ListItem>
                                                    <asp:ListItem Text="傣族" Value="傣族"></asp:ListItem>
                                                    <asp:ListItem Text="德昂族" Value="德昂族"></asp:ListItem>
                                                    <asp:ListItem Text="侗族" Value="侗族"></asp:ListItem>
                                                    <asp:ListItem Text="东乡族" Value="东乡族"></asp:ListItem>
                                                    <asp:ListItem Text="独龙族" Value="独龙族"></asp:ListItem>
                                                    <asp:ListItem Text="鄂伦春族" Value="鄂伦春族"></asp:ListItem>
                                                    <asp:ListItem Text="俄罗斯族" Value="俄罗斯族"></asp:ListItem>
                                                    <asp:ListItem Text="鄂温克族" Value="鄂温克族"></asp:ListItem>
                                                    <asp:ListItem Text="高山族" Value="高山族"></asp:ListItem>
                                                    <asp:ListItem Text="仡佬族" Value="仡佬族"></asp:ListItem>
                                                    <asp:ListItem Text="哈尼族" Value="哈尼族"></asp:ListItem>
                                                    <asp:ListItem Text="哈萨克族" Value="哈萨克族"></asp:ListItem>
                                                    <asp:ListItem Text="赫哲族" Value="赫哲族"></asp:ListItem>
                                                    <asp:ListItem Text="回族" Value="回族"></asp:ListItem>
                                                    <asp:ListItem Text="基诺族" Value="基诺族"></asp:ListItem>
                                                    <asp:ListItem Text="京族" Value="京族"></asp:ListItem>
                                                    <asp:ListItem Text="景颇族" Value="景颇族"></asp:ListItem>
                                                    <asp:ListItem Text="柯尔克孜族" Value="柯尔克孜族"></asp:ListItem>
                                                    <asp:ListItem Text="拉祜族" Value="拉祜族"></asp:ListItem>
                                                    <asp:ListItem Text="黎族" Value="黎族"></asp:ListItem>
                                                    <asp:ListItem Text="傈僳族" Value="傈僳族"></asp:ListItem>
                                                    <asp:ListItem Text="珞巴族" Value="珞巴族"></asp:ListItem>
                                                    <asp:ListItem Text="满族" Value="满族"></asp:ListItem>
                                                    <asp:ListItem Text="毛南族" Value="毛南族"></asp:ListItem>
                                                    <asp:ListItem Text="门巴族" Value="门巴族"></asp:ListItem>
                                                    <asp:ListItem Text="蒙古族" Value="蒙古族"></asp:ListItem>
                                                    <asp:ListItem Text="苗族" Value="苗族"></asp:ListItem>
                                                    <asp:ListItem Text="仫佬族" Value="仫佬族"></asp:ListItem>
                                                    <asp:ListItem Text="纳西族" Value="纳西族"></asp:ListItem>
                                                    <asp:ListItem Text="怒族" Value="怒族"></asp:ListItem>
                                                    <asp:ListItem Text="普米族" Value="普米族"></asp:ListItem>
                                                    <asp:ListItem Text="羌族" Value="羌族"></asp:ListItem>
                                                    <asp:ListItem Text="撒拉族" Value="撒拉族"></asp:ListItem>
                                                    <asp:ListItem Text="畲族" Value="畲族"></asp:ListItem>
                                                    <asp:ListItem Text="水族" Value="水族"></asp:ListItem>
                                                    <asp:ListItem Text="塔吉克族" Value="塔吉克族"></asp:ListItem>
                                                    <asp:ListItem Text="塔塔尔族" Value="塔塔尔族"></asp:ListItem>
                                                    <asp:ListItem Text="土族" Value="土族"></asp:ListItem>
                                                    <asp:ListItem Text="土家族" Value="土家族"></asp:ListItem>
                                                    <asp:ListItem Text="佤族" Value="佤族"></asp:ListItem>
                                                    <asp:ListItem Text="锡伯族" Value="锡伯族"></asp:ListItem>
                                                    <asp:ListItem Text="乌兹别克族" Value="乌兹别克族"></asp:ListItem>
                                                    <asp:ListItem Text="瑶族" Value="瑶族"></asp:ListItem>
                                                    <asp:ListItem Text="彝族" Value="彝族"></asp:ListItem>
                                                    <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                                                    <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                                                    <asp:ListItem Text="维吾尔族" Value="维吾尔族"></asp:ListItem>
                                                    <asp:ListItem Text="壮族" Value="壮族"></asp:ListItem>
                                         </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><span class="c-red">*</span> 出生日期：</label>

                                        <div class="controls text-left">
                                            <asp:TextBox ID="txtBirthday" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="请选择" />
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
                                                <button id="btnSaveStepOne" onserverclick="btnSaveStepOne_ServerClick"  class ="mt10 btn btn-large btn-block btn-primary" type="button" runat="server" >保存并继续</button>
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
