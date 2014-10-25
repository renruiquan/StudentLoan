<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="BindBank.aspx.cs" Inherits="StudentLoan.Web.user.BindBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 银行账户信息</title>
    <script src="../js/jquery.cityselect.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#bank_area").citySelect(
                {
                    url: "/js/city.min.js",
                    prov: "<%=this.BankModel.BankProvince%>", //省份 
                    city: "<%=this.BankModel.BankCity%>", //城市
                });
        });
    </script>
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
                        <label class="control-label">银行卡类型：</label>

                        <div class="controls">
                            <asp:HiddenField ID="hidBankId" runat="server" />
                            <asp:DropDownList ID="ddlBankTypeList" CssClass="span5" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">开户银行全称：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="span5" placeholder="请输入你的开户行名称"></asp:TextBox>
                        </div>
                    </div>



                    <div class="control-group">
                        <label class="control-label">银行账户：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtBankCard" runat="server" CssClass="span5" placeholder="请输入你的银行卡账户"></asp:TextBox>
                        </div>
                    </div>



                    <div class="control-group">
                        <label class="control-label">开户行所在地区：</label>

                        <div class="controls" id="bank_area">
                            <select id="ddlProvince" name="ddlProvince" class="prov span2"></select>省
                            <select id="ddlCity" name="ddlCity" class="city span3"></select>市
                        </div>
                    </div>


                    <div class="control-group">
                        <label class="control-label">真实姓名：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtTrueName" runat="server" CssClass="span5"></asp:TextBox>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w220">
                                <button id="btnSubmit" runat="server" class="btn btn-large btn-block btn-primary" onserverclick="btnSubmit_ServerClick" type="button">确 定</button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
