<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrawMoneyList.aspx.cs" Inherits="StudentLoan.Web.Admin.DrawMoneyList" %>

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
            <div class="location">当前位置：用户管理 -&gt; 提现记录</div>

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
                                <asp:ListItem Value="2">银行卡卡号</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtQueryContent" runat="server" CssClass="input-small"></asp:TextBox>

                            <label class="first txt-green">提现日期：</label>

                            <asp:TextBox ID="txtStartTime" onClick="WdatePicker()" runat="server" CssClass="input-small"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtEndTime" runat="server" onClick="WdatePicker()" CssClass="input-small"></asp:TextBox>

                            <label class="first txt-green">状态：</label>

                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Value="">全部</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">审核中</asp:ListItem>
                                <asp:ListItem Value="1">提现失败</asp:ListItem>
                                <asp:ListItem Value="2">提现成功</asp:ListItem>
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
                    <h3>提现记录列表</h3>
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
                                        <th class="txt40 c">提款编号</th>
                                        <th class="txt40 c">用户名/真实姓名</th>
                                          <th class="txt40 c">手机号码</th>
                                        <th class="txt40 c">开户行名称</th>
                                        <th class="txt40 c">银行卡卡号</th>
                                        <th class="txt40 c">开户行地区</th>
                                        <th class="txt40 c">提现金额</th>
                                        <th class="txt40 c">确认金额</th>
                                        <th class="txt40 c">手续费</th>
                                        <th class="txt40 c">申请时间</th>
                                        <th class="txt40 c">通过时间</th>
                                        <th class="txt40 c">打款人</th>
                                        <th class="txt40 c">状态</th>
                                        <th>操作</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("DrawId")%></td>
                                    <td><%#Eval("UserName")%>/<%#Eval("TrueName")%></td>
                                    <td><%#Eval("Mobile")%></td>
                                    <td><%#Eval("BaseBankName")%>-<%#Eval("BankName")%></td>
                                    <td><%#Eval("BankCardNo")%></td>
                                    <td><%#Eval("BankProvince")%> <%#Eval("BankCity")%></td>
                                    <td><%#Eval("DrawMoney")%></td>
                                    <td><%#Eval("ConfirmMoney")%></td>
                                    <td><%#Eval("Fee")%></td>
                                    <td><%#Eval("ApplyTime")%></td>
                                    <td><%#Eval("PassTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss") =="0001-01-01 00:00:00"?"":Eval("PassTime").Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                    <td><%#this.GetAdminName(Convert.ToInt32(Eval("AdminID"))) %></td>
                                    <td><%# this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
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
