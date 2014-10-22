<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="BindBank.aspx.cs" Inherits="StudentLoan.Web.user.BindBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 银行账户信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">银行账户信息</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="form-horizontal">

                <div class="item">

                    <div class="border-radius p10">

                        <p>
                            注：必须填写实名认证下的银行卡，由于部分银行银行开户信息无法收录或未能及时更新，若您的开户行未在列表中显示，请直接手工录入，申请提现后，银行系统需要1-3个工作日自动校验您填写的开户行支行名称，如果填写不正确会被退款
                                如果您不确定自己的开户行支行名称，建议您在填写前拨打银行卡背面的客户热线咨询；
                        </p>
                        <p>另外，建议您填写完整的<a href="javascript:;">联系方式</a>，以便遇到问题时，工作人员可以及时联系到您。</p>
                    </div>

                    <div class="clear mt20"></div>

                    <div class="control-group">
                        <label class="control-label">真实姓名：</label>

                        <div class="controls">
                            <input class="span5" type="text" placeholder="">
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">登录账号：</label>

                        <div class="controls">
                            <input class="span5" type="text" placeholder="请输入你的注册账号">
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">银行卡类型：</label>

                        <div class="controls">
                            <select>
                                <option value="">请选择...</option>
                                <option value="1">中国工商银行</option>
                            </select>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">银行账户：</label>

                        <div class="controls">
                            <input class="span5" type="text" placeholder="请输入你的银行卡账户">
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">开户行所在省份：</label>

                        <div class="controls">
                            <select>
                                <option value="">请选择...</option>
                                <option value="1">中国工商银行</option>
                            </select>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">开户行所在市：</label>

                        <div class="controls">
                            <select>
                                <option value="">请选择...</option>
                                <option value="1">中国工商银行</option>
                            </select>
                        </div>
                    </div>

                    <!--
                        <div class="control-group">
                            <label class="control-label">查询关键字：</label>

                            <div class="controls">
                                <input class="span5" type="text" placeholder="请输入要查询的关键字">
                                <button type="button" class="btn btn-info">查询</button>
                            </div>
                        </div>
                        -->

                    <div class="control-group">
                        <label class="control-label">开户银行全称：</label>

                        <div class="controls">
                            <select>
                                <option value="">请选择...</option>
                                <option value="1">中国工商银行</option>
                            </select>
                        </div>
                    </div>


                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w220">
                                <button class="btn btn-large btn-block btn-primary" type="button">确 定</button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
