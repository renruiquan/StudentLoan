<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ManageMoneyDetail.aspx.cs" Inherits="StudentLoan.Web.user.ManageMoneyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财明细</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">

            <div class="tabs">

                <ul>
                    <li class="active"><a href="javascript:;">理财明细</a></li>
                </ul>

            </div>

            <div class="cont">

                <div class="text-center form-inline">
                    <div style="margin: 0 0 20px">
                        <span>时间：</span>
                        <input class="span2" value="" type="text"/>
                        <span> - </span>
                        <input class="span2" value="" type="text"/>
                        <span>状态：</span>
                        <select>
                            <option value="">请选择</option>
                            <option value="1">已收</option>
                            <option value="2">未收</option>
                        </select>

                        <label class="radio ml20 mr10">
                            <input type="radio" name="status" value="1"> 正常
                        </label>

                        <button class="btn btn-primary" type="button">查 询</button>
                    </div>
                </div>

                <div class="item">
                    <table class="table table-bordered table-striped">
                        <thead>
                        <tr>
                            <th>借款编号/标题</th>
                            <th>理财产品</th>
                            <th>期数</th>
                            <th>收益金额/利息</th>
                            <th>收款时间</th>
                            <th>实际收款时间</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <td>
                                <p>15213595</p>
                            </td>
                            <td>
                                <p>聚少成多</p>
                            </td>
                            <td>
                                <p>12期</p>
                            </td>
                            <td>
                                <p>￥：4000:00</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>15213595</p>
                            </td>
                            <td>
                                <p>招财进宝</p>
                            </td>
                            <td>
                                <p>12期</p>
                            </td>
                            <td>
                                <p>￥：4000:00</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>15213595</p>
                            </td>
                            <td>
                                <p>招财进宝</p>
                            </td>
                            <td>
                                <p>12期</p>
                            </td>
                            <td>
                                <p>￥：4000:00</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
                            </td>
                            <td>
                                <p>2014-08-15  18:12</p>
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
