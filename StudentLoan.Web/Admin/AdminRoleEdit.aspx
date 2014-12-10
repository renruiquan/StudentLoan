<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRoleEdit.aspx.cs" Inherits="StudentLoan.Web.Admin.AdminRoleEdit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站后台登陆</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="js/jquery.validate.js"></script>
    <script type="text/javascript" src="js/jquery.validate.cn.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form1").validate();
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
    <form id="form1" runat="server">

        <div class="container1">

            <div class="location">当前位置：角色管理 -&gt; 更新角色</div>

            <div class="blank10"></div>

            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>更新角色</h3>
                    <div class="bar">
                        <a class="btn-lit" href="AdminRoleList.aspx"><span>返回</span></a>
                    </div>
                </div>
                <div class="tl corner"></div>
                <div class="tr corner"></div>
                <div class="bl corner"></div>
                <div class="br corner"></div>
                <div class="cnt-wp">
                    <div class="cnt form">
                        <table class="data-form" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <th scope="row">角色名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtAdminRoleName" placeholder="角色名称" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">角色类别：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlRoleType" runat="server">
                                            <asp:ListItem Value="1">超级用户</asp:ListItem>
                                            <asp:ListItem Value="2">系统用户</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">系统级别：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlIsSystem" runat="server">
                                            <asp:ListItem Value="0">否</asp:ListItem>
                                            <asp:ListItem Value="1">是</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">&nbsp;</th>
                                    <td>
                                        <asp:Button runat="server" ID="btnSubmit" CssClass="button button-primary" Text="更新" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="block" style="margin-top: 10px;">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>导航列表</h3>
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
                                        <th>导航ID</th>
                                        <th>标题</th>
                                        <th>链接地址</th>
                                        <th>权限</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("NavID")%></td>
                                    <td><%#Eval("Title")%></td>
                                    <td><%#Eval("LinkUrl")%></td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="objCheckBox" value='<%#Eval("NavId") %>' /></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>


                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
