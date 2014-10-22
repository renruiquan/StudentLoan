<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StudentLoan.Web.user.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改密码</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">

            <div class="tabs">

                <ul>
                    <li class="active"><a href="javascript:;">修改密码</a></li>
                </ul>

            </div>

            <div class="cont">

                <div action="" class="form-horizontal">

                    <div class="item">

                        <div class="control-group">
                            <label class="control-label">当前密码：</label>

                            <div class="controls">
                                <input class="span5" type="password" value="">
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">新密码：</label>

                            <div class="controls">
                                <input class="span5" type="text" placeholder="密码至少包括数字、字母和符号中的两种">
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">确认密码：</label>

                            <div class="controls">
                                <input class="span5" type="text" placeholder="请再次输入你的密码">
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
