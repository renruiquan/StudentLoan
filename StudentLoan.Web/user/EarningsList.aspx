<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="EarningsList.aspx.cs" Inherits="StudentLoan.Web.user.EarningsList" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>聚宝盆管理 - 我的收益</title>
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
                <li class="active"><a href="javascript:;">我的收益</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="text-center mb20 rows-3">
                <div>
                    <h4>累计收益：<%=this.TotalAmount.ToString("C") %>元</h4>
                </div>
                <div>
                    <h4></h4>
                </div>
            </div>

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
                                    <th>收益日期</th>
                                    <th>产品名称</th>
                                    <th>方案名称</th>
                                    <th>金额</th>
                                    <th>信息</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="5">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("CreateTime")%></td>
                                <td><%#Eval("ProductName") %></td>
                                <td><%#Eval("SchemeName") %></td>
                                <td><%#Convert.ToDouble(Eval("Amount")).ToString("C") %></td>
                                <td><%#Eval("Type").ToString() =="1"?"收益":"亏损" %></td>
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
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="8" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>

        </div>

    </div>

</asp:Content>
