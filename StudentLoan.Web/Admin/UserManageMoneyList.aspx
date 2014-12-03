<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManageMoneyList.aspx.cs" Inherits="StudentLoan.Web.Admin.UserManageMoneyList" %>

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
        <div class="container">
            <div class="location">当前位置：理财管理 -&gt; 理财记录</div>

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
                            <label class="first txt-green">查询类型：</label>

                            <asp:DropDownList ID="ddlQueryType" runat="server">
                                <asp:ListItem Value="1">用户名</asp:ListItem>
                                <asp:ListItem Value="2">方案名称</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtQueryContent" runat="server" CssClass="input-small"></asp:TextBox>

                            <label class="first txt-green">购买日期：</label>

                            <asp:TextBox ID="txtStartTime" onClick="WdatePicker()" runat="server" CssClass="input-small"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtEndTime" runat="server" onClick="WdatePicker()" CssClass="input-small"></asp:TextBox>

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
                    <h3>理财记录列表</h3>
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
                                    <tr>
                                        <th scope="col">理财编号</th>
                                        <th scope="col">用户名</th>
                                        <th scope="col">产品名称</th>
                                        <th scope="col">方案名称</th>
                                        <th scope="col">购买数量</th>
                                        <th scope="col">金额</th>
                                        <th scope="col">订单日期</th>
                                        <th scope="col">支付日期</th>
                                        <th scope="col">状态</th>
                                        <th scope="col">操作</th>

                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="txt40 c"><%#Eval("BuyID")%></td>
                                    <td class="txt40 c"><%#Eval("UserName")%></td>
                                    <td class="txt40 c"><%#Eval("ProductName")%></td>
                                    <td class="txt40 c"><%#Eval("SchemeName")%></td>
                                    <td class="txt40 c"><%#Eval("Count")%></td>
                                    <td class="txt40 c"><%#Eval("Amount")%></td>
                                    <td class="txt40 c"><%#Eval("CreateTime")%></td>
                                    <td class="txt40 c"><%#Eval("PayTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss") =="0001-01-01 00:00:00"?"":Eval("PayTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                    <td class="txt40 c"><%# this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
                                    <td class="txt40 c">
                                        <asp:Literal ID="objLiteral" runat="server"></asp:Literal></td>

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
