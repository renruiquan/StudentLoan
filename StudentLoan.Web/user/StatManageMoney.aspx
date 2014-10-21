<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="StatManageMoney.aspx.cs" Inherits="StudentLoan.Web.user.StatManageMoney" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="content">

            <div class="tabs">

                <ul>
                    <li class="active"><a href="javascript:;">理财统计</a></li>
                </ul>

            </div>

            <div class="cont">
                <div class="item">
                    <table class="table table-bordered table-striped">
                        <caption>个人理财统计</caption>
                        <tbody>
                        <tr>
                            <td>
                                <p>总借出金额</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                            <td>
                                <p>总借出笔数</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>已回收本息</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                            <td>
                                <p>已回收笔数</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>待回收本息</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                            <td>
                                <p>待回收笔数</p>
                            </td>
                            <td>
                                <p>￥0.00</p>
                            </td>
                        </tr>
                        </tbody>
                    </table>

                </div>

                <p>* 总结出笔数=已回收笔数(含坏账已垫付) + 待回收笔数 + 历史遗留无垫付坏账笔数</p>

            </div>

        </div>

</asp:Content>
