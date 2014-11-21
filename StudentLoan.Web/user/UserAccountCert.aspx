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

                        </tr>
                        <tr>
                            <td>信用分数</td>
                            <td>
                                <p>81-100分</p>
                            </td>
                            <td>
                                <p>71-80分</p>
                            </td>
                            <td>
                                <p>61-70分</p>
                            </td>
                            <td>
                                <p>31-60分</p>
                            </td>
                            <td>
                                <p>0-30分</p>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="item">

                <h3>注：信用额度最高为100，基本信息完成后，信用分数为60，当前状态显示未完成时，完成一个加5分；</h3>

                <table class="table table-bordered">
                    <caption>信用总分：<span class="big-num"><%=this.TotalPoint %></span>分</caption>
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
                                <p>
                                    <%
                                        if (!string.IsNullOrEmpty(this.UserModel.TrueName) && !string.IsNullOrEmpty(this.UserModel.IdentityCard) && !string.IsNullOrEmpty(this.UserModel.Mobile)
                                            && !string.IsNullOrEmpty(this.UserModel.Gender) && !string.IsNullOrEmpty(this.UserModel.Nation) && (this.UserModel.Birthday != null || this.UserModel.Birthday != default(DateTime)))
                                        {
                                    %>
                                   已完成 
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    <a href="UserAccountCert_2.aspx">未完成</a>
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                            <td rowspan="3">
                                <p>
                                    <span class="big-num"><%=this.BasePoint%></span>分
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>学校信息（10分）</p>
                            </td>
                            <td>
                                <p>
                                    <% if (this.UserSchoolModel == null)
                                       {
                                    %>
                                    <a href="UserAccountCert_2.aspx">未完成</a>
                                    <%
                                       }
                                       else if (!string.IsNullOrEmpty(this.UserSchoolModel.SchoolName)
                                                && !string.IsNullOrEmpty(this.UserSchoolModel.SchoolAddress) && (this.UserSchoolModel.YearOfAdmission != null || this.UserSchoolModel.YearOfAdmission != default(DateTime))
                                                && this.UserSchoolModel.SchoolSystem > 0 && this.UserSchoolModel.Education > 0 && !string.IsNullOrEmpty(this.UserSchoolModel.Major))
                                       {
                                    %>
                                    已完成
                                    <%
                                       }
                                       else
                                       {
                                    %>
                                    <a href="UserAccountCert_2.aspx">未完成</a>
                                    <%
                                       } %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>家属与同学信息（10分）</p>
                            </td>
                            <td>
                                <p>
                                    <%
                                        if (this.FamilyModel == null || this.StudentModel == null || this.FriendModel == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_2.aspx">未完成</a>
                                    <%
                                        }
                                        else if (!string.IsNullOrEmpty(this.FamilyModel.Name) && !string.IsNullOrEmpty(this.FamilyModel.Relationship) &&
                                                 !string.IsNullOrEmpty(this.FamilyModel.Mobile) &&
                                                 !string.IsNullOrEmpty(this.StudentModel.Name) && !string.IsNullOrEmpty(this.StudentModel.Mobile) &&
                                                 !string.IsNullOrEmpty(this.FriendModel.Name) && !string.IsNullOrEmpty(this.FriendModel.Mobile))
                                        {
                                    %>
                                    已完成
                                    <% 
                                        }
                                        else
                                        {
                                    %>
                                    <a href="UserAccountCert_2.aspx">未完成</a>
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="2">必要信用认证</td>
                            <td>
                                <p>身份证认证（15分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.IdentityCard_2 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_3.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                            <td rowspan="2">
                                <p><span class="big-num"><%=this.MustPoint %></span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>学生证认证（15分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.StudentId2 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_3.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>


                        <tr>
                            <td rowspan="10">可选信用认证</td>
                            <td>
                                <p>学信网截图（2分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.XueXin == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                            <td rowspan="10">
                                <p><span class="big-num"><%=this.OptionalPoint %></span>分</p>

                                <p>（总分满70分即可享受高额贷款服务）</p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>银行卡流水认证（1分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Bank == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>支付宝流水帐单（1分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Alipay == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>手机通话记录清单（1分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Mobile == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>家长身份认证（2分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Parents1 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else if (this.Parents2 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">继续</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>室友学生证（2分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.RoommateStudentId2 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>室友身份证（2分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.RoommateIdentityCard2 == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>自己和家人的户口本（2分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Residencebooklet == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>本人驾驶执照（1分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.DriversLicense == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>在校获奖证明（5分）</p>
                            </td>
                            <td>
                                <p>
                                    <% 
                                        if (this.Awards == null)
                                        {
                                    %>
                                    <a href="UserAccountCert_4.aspx">未完成</a>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                    已完成
                                    <%
                                        }
                                    %>
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="10">学子贷款记录</td>
                            <td>
                                <p>还清笔数（+1分/笔）</p>
                            </td>
                            <td></td>
                            <td>
                                <p><span class="big-num"><%=this.UserLoanPoint %></span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>逾期5天以上扣一分</p>
                            </td>
                            <td></td>
                            <td rowspan="2">
                                <p><span class="big-num"><%=this.BreakContractUserLoan %></span>分</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>超过5天，按照本金*0.5%/天计算</p>
                            </td>
                            <td></td>

                        </tr>
                    </tbody>
                </table>

            </div>

        </div>

    </div>
</asp:Content>
