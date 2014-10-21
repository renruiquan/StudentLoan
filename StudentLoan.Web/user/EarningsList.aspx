<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="EarningsList.aspx.cs" Inherits="StudentLoan.Web.user.EarningsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 我的收益</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">已收</a></li>
                <li><a href="javascript:;">未收</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="text-center mb20 rows-3">
                <div>
                    <h4>累计收入：￥0.00</h4>
                </div>
                <div>
                    <h4>截至今日累计收益:￥0.00</h4>
                </div>
            </div>

            <div class="text-center form-inline">
                <div style="margin: 0 0 20px">
                    <span>交易时间：</span>
                    <input class="span3" value="" type="text" />
                    <span>- </span>
                    <input class="span3" value="" type="text" />
                    <button class="btn btn-primary" type="button">导出结果</button>
                </div>
            </div>

            <div class="item">
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>名称</th>
                            <th>购买时间</th>
                            <th>累计收益</th>
                            <th>收入类型</th>
                            <th>明细</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <p>聚宝盆</p>
                            </td>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>￥：500:00</p>
                            </td>
                            <td>
                                <p>高额贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>聚宝盆</p>
                            </td>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>￥：500:00</p>
                            </td>
                            <td>
                                <p>随时贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>聚宝盆</p>
                            </td>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>￥：500:00</p>
                            </td>
                            <td>
                                <p>一般贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
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
