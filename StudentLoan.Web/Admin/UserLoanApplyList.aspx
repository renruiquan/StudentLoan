<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoanApplyList.aspx.cs" Inherits="StudentLoan.Web.Admin.UserLoanApplyList" %>

<%@ Import Namespace="StudentLoan.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.utils.js"></script>
    <link href="jBox/Skins/Green/jbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jBox/jquery.jBox-2.3.min.js"></script>

    <script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            var oldbgcolor;
            $('table.data-table tr:even').addClass('even');
            $('table.data-table tr').mouseover(function () {
                oldbgcolor = $(this).css("background-color");
                $(this).css("background-color", "#CCC")
            }).mouseout(function () {
                $(this).css("background-color", oldbgcolor);
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="container1">
            <div class="location">当前位置：借款管理 -&gt; 借款记录</div>

            <div class="blank10"></div>

            <div class="search block">
                <div class="h">
                    <span class="icon-sprite icon-magnifier"></span>
                    <h3>快速搜索</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <div class="search-bar">
                            <label class="first txt-green">借款类型：</label>

                            <asp:DropDownList runat="server" ID="ddlLoanCategory">
                                <asp:ListItem Value="">选择分类</asp:ListItem>
                                <asp:ListItem Value="1">一般贷</asp:ListItem>
                                <asp:ListItem Value="2">高额贷</asp:ListItem>
                                <asp:ListItem Value="3">随时贷</asp:ListItem>
                            </asp:DropDownList>

                            <label class="first txt-green">查询类型：</label>

                            <asp:DropDownList runat="server" ID="ddlQueryType">
                                <asp:ListItem Value="1" Selected="True">借款人</asp:ListItem>
                                <asp:ListItem Value="2">借款编号</asp:ListItem>
                            </asp:DropDownList>

                            <asp:TextBox ID="txtQueryContent" runat="server" CssClass="input-small"></asp:TextBox>

                            <label class="first txt-green">申请日期：</label>

                            <asp:TextBox ID="txtStartTime" onClick="WdatePicker()" runat="server" CssClass="input-small"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtEndTime" runat="server" onClick="WdatePicker()" CssClass="input-small"></asp:TextBox>

                            <label class="first txt-green">状态：</label>

                            <asp:DropDownList runat="server" ID="ddlStatus">
                                <asp:ListItem Value="">全部状态</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">审核中</asp:ListItem>
                                <asp:ListItem Value="1">已放款</asp:ListItem>
                                <asp:ListItem Value="2">已拒绝</asp:ListItem>
                            </asp:DropDownList>

                            <label><a class="btn-lit btn-middle btn-lit-top" href="javascript:void(0);" runat="server" onserverclick="btnSearch_Click"><span>搜索</span></a></label>
                            <label><a class="btn-lit btn-middle btn-lit-top" href="javascript:void(0);" runat="server" id="btnExport" onserverclick="btnExport_ServerClick"><span>导出数据</span></a></label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>用户借款列表</h3>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <asp:Repeater ID="objRepeater" runat="server" OnItemDataBound="objRepeater_ItemDataBound">
                            <HeaderTemplate>
                                <table class="data-table" width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr class="c">
                                        <th>借款编号</th>
                                        <th>借款人</th>
                                        <th>类型</th>
                                        <th>借款金额</th>
                                        <th>费率</th>
                                        <th>申请时间</th>
                                        <th>应还金额</th>
                                        <th>已还期数/总期数</th>
                                        <th>借款状态</th>
                                        <th>管理员</th>
                                        <th>操作时间</th>
                                        <th>操作</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="c">
                                    <td><%#Eval("LoanNo") %></td>
                                    <td><%#Eval("TrueName") %></td>
                                    <td><%#Eval("ProductName") %></td>
                                    <td><%#Convert.ToDecimal( Eval("LoanMoney")).ToString("C") %></td>
                                    <td><%#Convert.ToDecimal(Eval("AnnualFee")).ToString("P2") %></td>
                                    <td><%#Eval("CreateTime") %></td>
                                    <td><%#Convert.ToDecimal(Eval("ShouldRepayMoney")).ToString("C") %></td>
                                    <td><%#Eval("AlreadyAmortization") %>/<%#Eval("TotalAmortization") %></td>
                                    <td><%#this.GetStatusName(Convert.ToInt32(Eval("Status"))) %></td>

                                    <td><%#this.GetAdminName(Convert.ToInt32(Eval("AdminID"))) %></td>
                                    <td><%#Eval("PassTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss")=="0001-01-01 00:00:00"?"":Eval("PassTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                    <td>
                                        <asp:Literal ID="objLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="pager-bar">
                        <webdiyer:AspNetPager ID="objAspNetPager" CssClass="pages" runat="server" PageSize="20" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" MoreButtonsClass="" CurrentPageButtonClass="cpb" AlwaysShow="True"></webdiyer:AspNetPager>
                    </div>

                </div>
            </div>

        </div>
    </form>
</body>
</html>
