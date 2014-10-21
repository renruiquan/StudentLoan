<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="StudentLoan.Web.user.UserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户总览</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">

            <div class="cont clear-top">

                <div class="item all-view">

                    <div class="all-left">


                        <div class="user-img">

                            <div class="img">
                                <img src="../css/img/admin/user_head.jpg" alt=""/>
                            </div>

                            <p class="name">
                                张无忌
                            </p>

                        </div>

                        <p class="tc">
                            <span class="grade orange">贷款</span>
                            <span class="grade green">理财</span>

                        </p>

                    </div>

                    <div class="all-right">

                        <form class="bs-docs-example">

                            <fieldset>
                                <h3>1.累计积分情况</h3>
                                <input class="span6" type="text" placeholder="0分">
                                <span class="help-block">赶快完善资料</span>
                            </fieldset>

                            <fieldset>
                                <h3>2.申请贷款金额</h3>
                                <input class="span6" type="text" placeholder="00.00元">
                            </fieldset>

                            <p class="w460">
                                <button class="mt10 btn btn-large btn-block btn-primary" type="button">点击提现</button>
                            </p>

                            <fieldset>
                                <h3>3.申请理财金额</h3>
                                <input class="span6" type="text" placeholder="00.00元">
                            </fieldset>

                            <p class="w460">
                                <button class="mt10 btn btn-large btn-block btn-primary" type="button">点击充值</button>
                            </p>


                        </form>

                        <div class="w460">

                            <h3>4.借贷表</h3>

                            <table class="table table-bordered table-striped">
                                <thead>
                                <tr>
                                    <th>
                                        <div><span class="head-icon lock"></span></div>
                                        <div class="f18">借款时间</div>
                                    </th>
                                    <th>
                                       <div><span class="head-icon dollar"></span></div>
                                       <div class="f18">借款金额</div>
                                    </th>
                                    <th>
                                        <div><span class="head-icon refresh"></span></div>
                                        <div class="f18">还款期限</div>
                                    </th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                    <td>
                                        <p>￥：1000:00元</p>
                                    </td>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                    <td>
                                        <p>￥：1000:00元</p>
                                    </td>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                    <td>
                                        <p>￥：1000:00元</p>
                                    </td>
                                    <td>
                                        <p>2014-16-23</p>
                                    </td>
                                </tr>
                                </tbody>
                            </table>

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

                </div>

                <div class="clear"></div>

            </div>

        </div>
</asp:Content>
