<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="UserManageMoney.aspx.cs" Inherits="StudentLoan.Web.user.UserManageMoney" %>

<%@ Import Namespace=" StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆 - 确认理财</title>
    <script src="../js/jquery-1.11.0.min.js"></script>
    <script src="../Admin/js/jquery.validate.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#ddlPeriod").on("change", function () {
                var dateNow = new Date();
                var dataTemp = AddMonths(dateNow, parseInt($(this).val(), 10));
                $("#EndTime").text(dataTemp);
            });
        });

        function AddMonths(datetime, month) {
            var tempDate = new Date(datetime);
            tempDate.setMonth(tempDate.getMonth() + month);
            var m = tempDate.getMonth() + 1;
            var d = tempDate.getDate();

            if (m < 10) {
                m = "0" + m;
            }
            if (d < 10) {
                d = "0" + d;
            }
            return tempDate.getFullYear() + '-' + m + '-' + d;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap">

        <div class="wrapper">

            <div class="mt50 mb50 p30 border-radius bgf">


                <div class="well well-large">
                    <h3>学子易贷精选理财计划 - <%=this.SchemeModel.SchemeName %></h3>

                    <p>本息保障计划 预期年收益率<span class="c-orange"><%=this.SchemeModel.MaxYield.ToString("P2") %></span></p>

                    <p class="c-orange">学子易贷精选理财计划将优先于学子易贷散投用户，根据分散投资原则进行投资</p>
                </div>

                <div class="item">

                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>
                                    <p>计划详情</p>
                                </th>
                                <th>
                                    <p></p>
                                </th>
                                <td>
                                    <p>购买</p>
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <p>理财产品</p>
                                </td>
                                <td>
                                    <p><%=this.SchemeModel.ProductName %></p>
                                </td>
                                <td rowspan="7" style="background-color: transparent;">
                                    <p>
                                        <label>
                                            您当前账户余额：
                                    <%=this.UserModel.Amount.Convert<decimal>().ToString("C") %>
                                            元
                                        </label>
                                    </p>
                                    <p>
                                        <label>
                                            请输入购买金额：
                                    <asp:TextBox ID="PurchaseMoney" runat="server" />
                                            元
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Blue"></asp:Label>
                                        </label>
                                    </p>

                                    <p>
                                        <label>
                                            请选择购买期限：
                                    <asp:DropDownList ID="ddlPeriod" ClientIDMode="Static" runat="server">
                                    </asp:DropDownList>
                                        </label>
                                    </p>
                                    <p>
                                        <span class="empty-txt"></span>
                                        <button id="btnConfirmBuy" runat="server" onserverclick="btnConfirmBuy_ServerClick" class="btn btn-primary" data-toggle="modal">确认购买</button>
                                    </p>
                                    <p class="f12"><span class="empty-txt"></span>如果账户不足请点击 <a class="c-blue f12" href="Charge.aspx">充值</a></p>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <p>计划简介</p>
                                </td>
                                <td>
                                    <p><%=this.SchemeModel.SchemeDescription %></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>年化收益率</p>
                                </td>
                                <td>
                                    <p><%=this.SchemeModel.MaxYield.ToString("P2") %></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>收益说明</p>
                                </td>
                                <td>
                                    <p>每日返还利息</p>
                                </td>
                            </tr>
                            <tr>
                                <td>理财开始时间</td>
                                <td><span id="StartTime"><%=DateTime.Now.ToString("yyyy-MM-dd") %></span> </td>
                            </tr>
                            <tr>
                                <td>理财结束时间
                                </td>
                                <td><span id="EndTime"><%=DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd") %></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
