<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="StudentLoan.Web.Admin.AdminList" %>


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
            <div class="location">当前位置：系统管理 -&gt; 管理员列表</div>

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
                            <label class="first txt-green">管理员名称：</label>

                            <asp:TextBox ID="txtUserName" runat="server" CssClass="input-small"></asp:TextBox>

                            <label><a class="btn-lit btn-middle btn-lit-top" href="javascript:void(0);" runat="server" onserverclick="btnSearch_Click"><span>搜索</span></a></label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>管理员列表</h3>
                    <div class="bar">
                        <a class="btn-lit" href="AdminAdd.aspx"><span>新增</span></a>
                    </div>
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
                                    <tr>
                                        <th scope="col">管理员ID</th>
                                        <th scope="col">角色</th>
                                        <th scope="col">用户名</th>
                                        <th scope="col">真实姓名</th>
                                        <th scope="col">电话</th>
                                        <th scope="col">邮箱</th>
                                        <th scope="col">状态</th>
                                        <th scope="col">建档时间</th>
                                        <th scope="col">操作</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="txt40"><%#Eval("AdminID")%></td>
                                    <td class="txt40"><%#Eval("RoleName")%></td>
                                    <td class="txt40"><%#Eval("AdminName")%></td>
                                    <td class="txt40"><%#Eval("RealName")%></td>
                                    <td class="txt40"><%#Eval("Telephone")%></td>
                                    <td class="txt40"><%#Eval("Email")%></td>
                                    <td class="txt40"><%#this.GetStatusName(Convert.ToInt32(Eval("IsLock")))%></td>
                                    <td class="txt40"><%#Eval("CreateTime")%></td>
                                    <td class="icon txt40 c"><a class="opt" title="编辑" href="AdminEdit.aspx?AdminId=<%#Eval("AdminId") %>"><span class="icon-sprite icon-edit"></span></a><a class="opt" title="删除" onclick="return confirm('删除后不可恢复，确定删除？')" href='AdminList.aspx?Action=Delete&AdminId=<%#Eval("AdminId") %>'><span class="icon-sprite icon-delete"></span></a></td>
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
