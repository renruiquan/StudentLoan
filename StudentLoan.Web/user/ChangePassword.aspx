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

                    <div id="divOldPassword" runat="server" class="control-group">
                        <label class="control-label">当前密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtOldPassword" CssClass="span5" runat="server" TextMode="Password" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">新密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtNewPassword" CssClass="span5" runat="server" TextMode="Password" placeholder="密码至少包括数字、字母两种，最短8位，最长16位" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">确认密码：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtConfirmPassword" CssClass="span5" runat="server" TextMode="Password" placeholder="请再次输入你的密码" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w210">
                                <button id="btnSubmit" runat="server" class="btn btn-large btn-block btn-primary" type="button" onserverclick="btnSubmit_ServerClick">确 定</button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
