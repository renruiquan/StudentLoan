<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ManageMoneyList.aspx.cs" Inherits="StudentLoan.Web.user.ManageMoneyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财记录</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">待支付</a></li>
                <li><a href="javascript:;">转入</a></li>
                <li><a href="javascript:;">转出</a></li>
                <li><a href="javascript:;">收益</a></li>
                <li><a href="javascript:;">资金记录</a></li>
            </ul>

        </div>

        <div class="cont">

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
                            <th>交易时间</th>
                            <th>交易类型</th>
                            <th>代付金额</th>
                            <th>交易备注</th>
                            <th>账户余额</th>
                            <th>可用余额</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>一般贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
                            </td>
                            <td>
                                <p>无</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <a href="javascript:;">支付</a>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>高额贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
                            </td>
                            <td>
                                <p>无</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <a href="javascript:;">支付</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>2014-07-07  15:50</p>
                            </td>
                            <td>
                                <p>随时贷</p>
                            </td>
                            <td>
                                <p>￥500</p>
                            </td>
                            <td>
                                <p>无</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <p>￥4,000</p>
                            </td>
                            <td>
                                <a href="javascript:;">支付</a>
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
