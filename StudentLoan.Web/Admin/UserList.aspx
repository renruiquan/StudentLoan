<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="StudentLoan.Web.Admin.UserList" %>

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
    <style type="text/css">
        .avatar {
            padding: 5px;
        }

            .avatar img {
                margin: 0;
                padding: 0;
                width: 50px;
                height: 50px;
                -moz-border-radius: 50px;
                -webkit-border-radius: 50px;
                border-radius: 50px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="container1">
            <div class="location">当前位置：用户管理 -&gt; 用户列表</div>

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
                                <asp:ListItem Value="2">真实姓名</asp:ListItem>
                                <asp:ListItem Value="3">身份证号</asp:ListItem>
                                <asp:ListItem Value="4">手机号码</asp:ListItem>
                                
                            </asp:DropDownList>
                            <asp:TextBox ID="txtQueryContent" runat="server" CssClass="input-small"></asp:TextBox>

                            <label><a class="btn-lit btn-middle btn-lit-top" href="javascript:void(0);" runat="server" onserverclick="btnSearch_Click"><span>搜索</span></a></label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="blank10"></div>
            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>用户列表</h3>

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
                                        <th>用户ID</th>
                                        <th>头像</th>
                                        <th>用户名 / 真实姓名</th>
                                        <th>性别</th>
                                        <th>邮箱</th>
                                        <th>手机号码</th>
                                        <th>身份证号</th>
                                        <th>地区</th>
                                        <th>账户余额</th>
                                        <th>注册时间</th>
                                        <th>注册IP</th>
                                        <th>状态</th>
                                        <th>操作</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="txt40 c"><%#Eval("UserId")%></td>
                                    <td class=" txt40 c avatar">
                                        <img src='<%#Eval("Avatar")%>' alt="" /></td>
                                    <td class="txt80"><%#Eval("UserName")%> / <%#Eval("TrueName")%></td>
                                    <td class="txt40"><%#Eval("Gender")%></td>
                                    <td class="txt40"><%#Eval("Email")%></td>
                                    <td class="txt40"><%#Eval("Mobile")%></td>
                                    <td class="txt40"><%#Eval("IdentityCard")%></td>
                                    <td class="txt80"><%#Eval("Province")%> <%#Eval("City")%></td>
                                    <td class="txt40"><%#Eval("Amount")%></td>
                                    <td class="txt40"><%#Eval("CreateTime")%></td>
                                    <td class="txt40"><%#Eval("RegIP")%></td>
                                    <td class="txt40"><%#this.GetStatusName(Convert.ToInt32(Eval("Status")))%></td>
                                    <td class="icon txt80 tail"><a class="opt" title="编辑" href="UserEdit.aspx?UserId=<%#Eval("UserId") %>"><span class="icon-sprite icon-edit"></span></a><a class="opt" title="锁定用户" onclick="return confirm('确定锁定该用户？')" href='UserList.aspx?Action=Delete&UserId=<%#Eval("UserId") %>'><span class="icon-sprite icon-delete"></span></a></td>
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
