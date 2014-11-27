<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="StudentLoan.Web.RegSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>注册完成</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap">

        <div class="register">
            <div class="register-form">

                <p class="c-blue">一步注册  轻松贷款</p>

                <div class="reg-step">
                    <div class="step-left left-outdated">
                        <div class="icon">
                            <h4>1</h4>
                        </div>
                        <p>注册</p>
                    </div>
                    <div class="step-center">
                        <p class="line"></p>
                    </div>
                    <div class="step-right ">
                        <div class="icon">
                            <h4>3</h4>
                        </div>
                        <p>完成</p>
                    </div>
                </div>

                <div class="clear"></div>

                <h2>恭喜您完成学子易贷账号注册</h2>

                <p class="mtb10">美好生活，现在开始</p>

                <p class="w526 auto text-center">
                    <a class="btn btn-primary btn-large btn-block" href="/user/UserAccount.aspx">进入我的易贷</a>
                </p>
                <div class="clear"></div>
                <div class="h200"></div>

            </div>

        </div>
    </div>
</asp:Content>
