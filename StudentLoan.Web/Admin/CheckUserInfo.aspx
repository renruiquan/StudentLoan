<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckUserInfo.aspx.cs" Inherits="StudentLoan.Web.Admin.CheckUserInfo" %>


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
            <div class="location">当前位置：借款管理 -&gt; 借款记录 -&gt; 审核用户</div>

            <div class="blank10"></div>

            <div class="search block">
                <div class="h">
                    <span class="icon-sprite icon-magnifier"></span>
                    <h3>审核用户</h3>
                    <div class="bar">
                        <label><a class="btn-lit btn-middle btn-lit-top" id="btnPass" runat="server" onserverclick="btnPass_ServerClick" href="javascript:void(0)"><span>通过</span></a></label>
                        <label><a class="btn-lit btn-middle btn-lit-top" id="btnRefuse" runat="server" onserverclick="btnRefuse_ServerClick" href="javascript:void(0)"><span>驳回</span></a></label>
                    </div>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt">
                        <div class="search-bar">
                            <div style="margin-right: 5px;">
                                <asp:TextBox ID="txtRefuse" runat="server" TextMode="MultiLine" Rows="5" Style="width: 100%; height: 100%;" placeholder="请输入驳回原因！"></asp:TextBox>
                            </div>
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
                        <asp:Repeater ID="objRepeater" runat="server">
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
                                    <td><%#Eval("UserName") %></td>
                                    <td><%#Eval("ProductName") %></td>
                                    <td><%#Convert.ToDecimal( Eval("LoanMoney")).ToString("C") %></td>
                                    <td><%#Convert.ToDecimal(Eval("AnnualFee")).ToString("P2") %></td>
                                    <td><%#Eval("CreateTime") %></td>
                                    <td><%#Convert.ToDecimal(Eval("ShouldRepayMoney")).ToString("C") %></td>
                                    <td><%#Eval("AlreadyAmortization") %>/<%#Eval("TotalAmortization") %></td>
                                    <td><%#this.GetStatusName(Convert.ToInt32(Eval("Status"))) %></td>

                                    <td><%#this.GetAdminName(Convert.ToInt32(Eval("AdminID"))) %></td>
                                    <td><%#Eval("PassTime") %></td>
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
