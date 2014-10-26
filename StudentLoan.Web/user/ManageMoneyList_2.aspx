<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ManageMoneyList_2.aspx.cs" Inherits="StudentLoan.Web.user.ManageMoneyList_2" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Import Namespace="StudentLoan.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财记录</title>
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.datepickers').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li><a href="ManageMoneyList.aspx">待支付</a></li>
                <li class="active"><a href="javascript:;">转入</a></li>
                <li><a href="ManageMoneyList_3.aspx">转出</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="text-center form-inline">
                <div style="margin: 0 0 20px">
                    <span>交易时间：</span>
                    <asp:TextBox ID="txtStartTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="起始日期" />
                    <span>- </span>
                    <asp:TextBox ID="txtEndTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="结束日期" />

                    <button id="btnQuery" runat="server" class="btn btn-primary" type="button" onserverclick="btnSearch_Click">查询</button>
                </div>
            </div>

            <div class="item">

                <StudentLoan:RepeaterPlus ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>编号</th>
                                    <th>交易时间</th>
                                    <th>交易类型</th>
                                    <th>方案名称</th>
                                    <th>投资期限</th>
                                    <th>理财金额</th>
                                    <th>状态</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("BuyID")%></td>
                            <td><%#Eval("CreateTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                            <td><%#Eval("ProductName")%></td>
                            <td><%#Eval("SchemeName")%></td>
                            <td><%#Eval("Period")%>个月</td>
                            <td><%#Eval("Amount").Convert<decimal>().ToString("C")%></td>
                            <td><%# this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
                            <td>
                                <asp:Literal ID="objLiteral" runat="server"></asp:Literal></td>

                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="8">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </StudentLoan:RepeaterPlus>
            </div>


            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>

        </div>

    </div>
</asp:Content>
