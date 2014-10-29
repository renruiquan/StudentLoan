<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductSchemeList.aspx.cs" Inherits="StudentLoan.Web.ProductSchemeList" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>理财计划精选</title>
    <script type="text/javascript">
        $(function () {
            $("#ManageMoneyNav").addClass("active").siblings().removeClass("active");
        });
    </script>
    <style type="text/css">
        .table td {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-wrap">

        <div class="wrapper">

            <div class="mt50 mb50 p30 border-radius bgf">

                <div class="well well-large">
                    <h4 class="foot-thin">学子易贷投资计划精选</h4>
                </div>

                <div class="item">
                    <StudentLoan:RepeaterPlus ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped td-text-center">
                                <thead>
                                    <tr>
                                        <th>方案名称</th>
                                        <th>产品</th>
                                        <th>保障计划</th>
                                        <th>年收益率</th>
                                        <th>开始时间</th>
                                        <th>截止时间</th>
                                        <th>状态</th>
                                        <th>发布日期</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <EmptyDataTemplate>
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr>
                                        <td colspan="9" style="text-align: center; padding: 50px;">暂无数据</td>
                                    </tr>
                                </tbody>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td><%#Eval("SchemeName")%></td>

                                    <td><%#Eval("ProductName")%></td>
                                    <td><%#Convert.ToInt32(Eval("PlanType"))==1?"本息保障计划":"未知"%></td>
                                    <td><%#Convert.ToDouble( Eval("MaxYield")).ToString("P")%> </td>
                                    <td><%#Eval("StartTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                                    <td><%#Eval("EndTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                                    <td><%#this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
                                    <td><%#Eval("CreateTime").Convert<DateTime>().ToString("yyyy-MM-dd")%></td>
                                    <td>
                                        <asp:Literal ID="objLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>

                    </StudentLoan:RepeaterPlus>


                </div>
            </div>
        </div>
        <div class="clear mt20"></div>

        <div class="pagination pagination-centered">
            <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
        </div>
    </div>

</asp:Content>
