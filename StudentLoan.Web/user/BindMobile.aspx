<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="BindMobile.aspx.cs" Inherits="StudentLoan.Web.user.BindMobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 手机绑定</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content">

            <div class="tabs">

                <ul>
                    <li class="active"><a href="javascript:;">手机绑定</a></li>
                </ul>

            </div>

            <div class="cont">

                <div  class="form-horizontal">

                    <div class="item">

                        <div class="control-group">
                            <label class="control-label"></label>
                            <div class="controls">
                                <p>已绑定手机号码：189*****214，如希望绑定其他手机号码，请输入以下信息</p>

                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">手机号码：</label>

                            <div class="controls">
                                <input class="span5" type="text" placeholder="请输入手机号码"/>
                                <button type="button" class="btn btn-info">发送手机验证码</button>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">验证码：</label>

                            <div class="controls">
                                <input class="span5" type="text" placeholder="请输入发送至手机的验证码"/>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">&nbsp;</label>

                            <div class="controls">
                                <p class="w210">
                                    <button class="btn btn-large btn-block btn-primary" type="button">确 定</button>
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
</asp:Content>
