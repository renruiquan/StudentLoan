<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccountCert.aspx.cs" Inherits="StudentLoan.Web.user.UserAccountCert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户认证</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">信用分数表</a></li>
                <li><a href="UserAccountCert_2.aspx">基本信息认证</a></li>
                <li><a href="UserAccountCert_3.aspx">必要信用认证</a></li>
                <li><a href="UserAccountCert_4.aspx">可选信用认证</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered table-striped">
                    <caption>信用等级以及对应分数</caption>
                    <tbody>
                        <tr>
                            <td>信用等级</td>
                            <td><span class="grade blue">A</span></td>
                            <td><span class="grade green">B</span></td>
                            <td><span class="grade green-two">C</span></td>
                            <td><span class="grade brown">D</span></td>
                            <td><span class="grade orange">E</span></td>
                            <td><span class="grade red">F</span></td>
                            <td><span class="grade pink">G</span></td>
                            <td><span class="grade purple">H</span></td>
                        </tr>
                        <tr>
                            <td>信用分数</td>
                            <td>
                                <p>100分</p>
                            </td>
                            <td>
                                <p>95-100分</p>
                            </td>
                            <td>
                                <p>90-95分</p>
                            </td>
                            <td>
                                <p>85-90分</p>
                            </td>
                            <td>
                                <p>80-85分</p>
                            </td>
                            <td>
                                <p>75-80分</p>
                            </td>
                            <td>
                                <p>70-75分</p>
                            </td>
                            <td>
                                <p>0-70分</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="item">

                <h3>注：信用额度最高为100，基本信息完成后，信用分数为60，当前状态显示未完成时，完成一个加5分；</h3>

                <table class="table table-bordered">
                    <caption>信用总分：<span class="big-num">20</span>分</caption>
                    <thead>
                        <tr>
                            <th></th>
                            <th>项目</th>
                            <th>状态</th>
                            <th>信用分数</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td rowspan="3">基本信息</td>
                            <td>
                                <p>个人详细信息（10分）</p>
                            </td>
                            <td>
                                <p>已完成</p>
                            </td>
                            <td rowspan="3">
                                <p><span class="big-num">30</span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>学校信息（10分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>家属与同学信息（10分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="2">必要信用认证</td>
                            <td>
                                <p>身份证认证（15分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                            <td rowspan="2">
                                <p><span class="big-num">0</span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>学生证认证（15分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>


                        <tr>
                            <td rowspan="10">可选信用认证</td>
                            <td>
                                <p>学信网截图（2分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                            <td rowspan="11">
                                <p><span class="big-num">0</span>分</p>

                                <p>（总分满70分即可享受高额贷款服务）</p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>银行卡流水认证（1分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>支付宝流水帐单（1分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>手机通话记录清单（1分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>家长身份认证（2分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>室友学生证（2分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>室友身份证（2分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>自己和家人的户口本（2分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>本人驾驶执照（1分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>在校获奖证明（5分）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="11">学子贷款记录</td>
                            <td>
                                <p>还清笔数（+1分/笔，加分间隔一天）</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>逾期5天以上扣一分</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                            <td>
                                <p><span class="big-num">0</span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>逾期5天以上逾期费用100/月</p>
                            </td>
                            <td>
                                <p><a href="javascript:;">未完成</a></p>
                            </td>
                            <td>
                                <p><span class="big-num">0</span>分</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

        </div>

    </div>
</asp:Content>
