<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserMessage.aspx.cs" Inherits="StudentLoan.Web.user.UserMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 最近消息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">我最近的动态</a></li>
                <li><a href="UserMessage_2.aspx">通知</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>状态</th>
                            <th>时间</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <p>你在学子易贷充值了100元人民币</p>
                            </td>
                            <td>
                                <p>2014-6-15 15:25</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>你在学子易贷充值了100元人民币</p>
                            </td>
                            <td>
                                <p>2014-6-15 15:25</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>你在学子易贷充值了100元人民币</p>
                            </td>
                            <td>
                                <p>2014-6-15 15:25</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>你在学子易贷充值了100元人民币</p>
                            </td>
                            <td>
                                <p>2014-6-15 15:25</p>
                            </td>
                        </tr>
                    </tbody>

                </table>

            </div>

            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <ul>
                    <li><a href="#">«</a></li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#">»</a></li>
                </ul>
            </div>

        </div>

    </div>
</asp:Content>
