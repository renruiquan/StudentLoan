<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="BindBank.aspx.cs" Inherits="StudentLoan.Web.user.BindBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 银行账户信息</title>
    <script src="../js/jquery.cityselect.js"></script>

    <link rel="stylesheet" type="text/css" href="../js/Validform/css/Validform.css" />
    <script src="../js/Validform/js/Validform_v5.3.2_min.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript">
        $(function () {
            $("#bank_area").citySelect(
                {
                    url: "/js/city.min.js"
                });

            $("#form1").Validform({
                tiptype: 3,
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

                    <div class="alert alert-error">
                        <strong>友情提示!</strong> 绑定的银行卡卡主姓名，必须和本站的真实姓名相同，否则无法完成提款操作！
                    </div>
                    <asp:Repeater ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <div>
                                <h3>已绑定银行卡：</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <label class="border-radius select-bank-cards">
                                <span class="bank-name">
                                    <asp:Literal runat="server" ID="objLiteral"></asp:Literal>
                                </span>
                                <span>卡号：<%#Eval("BankCardNo") %></span>
                            </label>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <div class="border-radius p10">

                        <p>
                            注：必须填写实名认证下的银行卡，由于部分银行银行开户信息无法收录或未能及时更新，若您的开户行未在列表中显示，请直接手工录入，申请提现后，银行系统需要1-3个工作日自动校验您填写的开户行支行名称，如果填写不正确会被退款
                                如果您不确定自己的开户行支行名称，建议您在填写前拨打银行卡背面的客户热线咨询；
                        </p>
                        <p>另外，建议您填写完整的联系方式，以便遇到问题时，工作人员可以及时联系到您。</p>
                    </div>

                    <div class="clear mt20"></div>

                    <div class="control-group">
                        <label class="control-label">开户行所在地区：</label>

                        <div class="controls" id="bank_area">
                            <select id="ddlProvince" name="ddlProvince" class="prov span2" datatype="*"></select>
                            <select id="ddlCity" name="ddlCity" disabled="disabled" class="city span3"></select>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">银行卡类型：</label>

                        <div class="controls">
                            <asp:DropDownList ID="ddlBankTypeList" CssClass="span5" runat="server" datatype="*">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">开户银行全称：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="span5" placeholder="请输入你的开户行名称" datatype="*"></asp:TextBox>
                        </div>
                    </div>



                    <div class="control-group">
                        <label class="control-label">银行卡卡号：</label>

                        <div class="controls">
                            <asp:TextBox ID="txtBankCard" runat="server" CssClass="span5" placeholder="请输入你的银行卡卡号" datatype="n"></asp:TextBox>
                        </div>
                    </div>


                    <div class="control-group">
                        <label class="control-label">&nbsp;</label>

                        <div class="controls">
                            <p class="w220">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-large btn-block btn-primary" Style="padding: 10px;" OnClick="btnSubmit_ServerClick" type="button" Text="添加绑定"></asp:Button>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
