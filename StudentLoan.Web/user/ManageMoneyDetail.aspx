<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="ManageMoneyDetail.aspx.cs" Inherits="StudentLoan.Web.user.ManageMoneyDetail" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 理财明细</title>
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
                <li class="active"><a href="javascript:;">理财明细</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="text-center form-inline">
                <div style="margin: 0 0 20px">
                    <span>交易时间：</span>
                    <asp:TextBox ID="txtStartTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="起始日期" />
                    <span>- </span>
                    <asp:TextBox ID="txtEndTime" runat="server" class="span2 datepickers" value="" type="text" data-date-format="yyyy-mm-dd" placeholder="结束日期" />

                    <button id="btnQuery" runat="server" class="btn btn-primary" type="button" onserverclick="btnQuery_ServerClick">查询</button>
                </div>
            </div>

            <div class="item">
                <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>编号</th>
                                    <th>理财产品</th>
                                    <th>期数</th>
                                    <th>收益金额</th>
                                    <th>收款时间</th>
                                    <th>实际收款时间</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="6">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("EarningsId")%></td>
                                <td><%#Eval("ProductName") %></td>
                                <td><%#Eval("Period") %>期</td>
                                <td><%#Convert.ToDouble(Eval("Interest")).ToString("C") %></td>
                                <td><%#Eval("PayTime")%></td>
                                <td><%#Eval("CreateTime")%></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
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
