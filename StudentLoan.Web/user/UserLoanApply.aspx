<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserLoanApply.aspx.cs" Inherits="StudentLoan.Web.user.UserLoanApply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>雪中送炭 - 申请借款</title>
    <script type="text/javascript">
        $(function () {
            $("#LoanList").addClass("active").siblings().removeClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-wrap writer-form">

        <div class="wrapper">

            <div class="text-center ptb20 w-top-bg">
                <h1>请填写借款申请表单</h1>

                <p>借款需要达到一定信用等级认证，如果不够一定信用等级认证，<a href="javascript:;"><span class="c-blue">请完善资料</span></a></p>

            </div>

            <div class=" bg-rb">


                <div class="form-horizontal">

                    <div class="item">

                        <div class="control-group">
                            <label class="control-label" for="numberSle"><span class="c-red">*</span> 借款金额：</label>

                            <div class="controls text-left">
                                <asp:DropDownList ID="ddlLoanMoney" runat="server"></asp:DropDownList>
                                <span>元 </span>
                            </div>
                        </div>

                        <div class="control-group mt10">
                            <label class="control-label" for="ddlLoanCategory"><span class="c-red">*</span> 借款用途：</label>

                            <div class="controls text-left">

                                <asp:DropDownList runat="server" ID="ddlLoanCategory">
                                    <asp:ListItem Value="1">因为爱情（恋爱贷款）</asp:ListItem>
                                    <asp:ListItem Value="2">游山玩水（旅游贷款）</asp:ListItem>
                                    <asp:ListItem Value="3">时尚达人（购物贷款）</asp:ListItem>
                                    <asp:ListItem Value="4">追求自我（娱乐贷款）</asp:ListItem>
                                    <asp:ListItem Value="5">急人所急（应急贷款）</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="control-group mt10">
                            <label class="control-label" for="ddlLoanTypeId"><span class="c-red">*</span> 借款类型：</label>

                            <div class="controls text-left">

                                <asp:DropDownList runat="server" ID="ddlLoanTypeId">
                                    <asp:ListItem Value="1">一般借款</asp:ListItem>
                                    <asp:ListItem Value="2">紧急借款</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>




                        <div class="control-group">
                            <label class="control-label" for="deadline"><span class="c-red">*</span> 借款期限：</label>

                            <div class="controls text-left">

                                <asp:DropDownList ID="ddlTotalAmortization" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtTotalAmortization" runat="server" Visible="false" placeholder="单位（天）"></asp:TextBox>

                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label"><span class="c-red">*</span> 还款方式：</label>

                            <div class="controls text-left">
                                <p class="mt5">每个月还服务费，最后一期本金、服务费一期归还。</p>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="deadline2"><span class="c-red">*</span> 成交服务费：</label>

                            <div class="controls text-left">
                                <p class="mt5 c-blue">只要申请贷款成功，所有信用等级的服务费0.3%/天,0.9%/月，但信用等级越高贷款的成功性越大。</p>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label"><span class="c-red">*</span> 借款描述：</label>

                            <div class="controls text-left">

                                <asp:TextBox ID="txtLoanDescription" TextMode="MultiLine" placeholder="借款描述,最多500个汉字" runat="server" class="w600" Rows="10"></asp:TextBox>

                                <p class="c-blue mt10">借款描述尽可能具体，详细阐述您借款的用途。真实、诚信、切记弄虚作假</p>

                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label"></label>

                            <div class="controls text-left">
                                <p class="w400 ptb20 text-center">
                                    <button id="btnApply" class="mt10 btn btn-large btn-block btn-primary" type="button" runat="server" onserverclick="btnApply_ServerClick">确定申请</button>
                                </p>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="rb rb2"></div>

            </div>

        </div>

    </div>

</asp:Content>
