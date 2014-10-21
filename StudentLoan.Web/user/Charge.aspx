<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="StudentLoan.Web.user.Charge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 账户充值</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">

            <div class="tabs">

                <ul>
                    <li><a href="javascript:;">账户日志</a></li>
                    <li class="active"><a href="javascript:;">会员充值</a></li>
                    <li><a href="javascript:;">充值日志</a></li>
                    <li><a href="javascript:;">会员提现</a></li>
                </ul>

            </div>

            <div>

                <div class="cont">

                    <div class="item">

                        <h3>1.温馨提示</h3>

                        <div class="p20 border-radius">

                            <p>@ 请注意您的银行卡充值限制，以免造成不便。</p>

                            <p>@ 如归充值金额没有及时到账，请和客服联系。</p>

                        </div>
                    </div>

                    <div class="item">

                        <h3>2.通过银行储蓄卡充值</h3>

                        <div class="select-bank">

                            <label class="bank active">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                            <label class="bank">
                                <input type="radio" value="1" name="bank"/>
                                <img src="../css/img/admin/bank_logo.jpg" alt=""/>
                            </label>

                        </div>

                        <div class="item">
                            <h3>通过其他银行储蓄卡充值<span class="c-gray">(充值手续费2元一笔)</span></h3>

                            <p class="w220">
                                <a href="javascript:;" class="btn btn-block btn-primary">使用第三方支付</a></p>

                            <select name="">
                                <option value="">中国农业银行</option>
                                <option value="">中国工商银行</option>
                                <option value="">中国建设银行</option>
                                <option value="">深圳发展银行</option>
                                <option value="">中国邮政银行</option>
                            </select>
                        </div>

                    </div>

                    <div class="item">
                        <h3>3.填写充值金额</h3>

                        <p>单笔充值金额必须≥10元（只能有两位小数，如：100.12），<a href="javascript:;">各大银行每日充值限额</a></p>

                        <p class="w240">
                            <input class="input input-block input-large" type="text"
                                   placeholder="请填写充值金额..."/> 元</p>

                        <p class="w210">
                            <button class="btn btn-large btn-block btn-primary" type="button">确 定</button>
                        </p>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
