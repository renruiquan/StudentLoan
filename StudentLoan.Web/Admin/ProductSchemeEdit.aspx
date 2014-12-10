<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSchemeEdit.aspx.cs" Inherits="StudentLoan.Web.Admin.ProductSchemeEdit" %>


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
            $("#<%=txtAmount.ClientID%>").on("blur", function () {
                var amount = $(this).val();
                var part = $("#<%=txtPart.ClientID%>").val();

                $("#<%=txtPrice.ClientID%>").val(Math.round(amount / part));
            });

            $("#<%=txtPart.ClientID%>").on("blur", function () {
                var amount = $("#<%=txtAmount.ClientID%>").val();
                var part = $(this).val();

                $("#<%=txtPrice.ClientID%>").val(Math.round(amount / part));
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container1">

            <div class="location">当前位置：理财管理 -&gt; 更新方案</div>

            <div class="blank10"></div>

            <div class="block">
                <div class="h">
                    <span class="icon-sprite icon-list"></span>
                    <h3>添加理财方案</h3>
                    <div class="bar">
                        <a class="btn-lit" href="ProductSchemeList.aspx"><span>返回</span></a>
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
                                    <th scope="row">方案名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtSchemeName" placeholder="方案名称" runat="server" class="required" /></td>
                                </tr>
                                <tr>
                                    <th scope="row">理财产品：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlProductId" runat="server" class="required" OnTextChanged="ddlProductId_TextChanged" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th scope="row">保障方式：</th>
                                    <td>
                                        <asp:DropDownList ID="ddlPlanType" runat="server" class="required">
                                            <asp:ListItem Value="1"> 本息保障计划 </asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th scope="row">方案最小理财金额：</th>
                                    <td>
                                        <asp:TextBox ID="txtAmount" runat="server" class="required number"></asp:TextBox></td>
                                </tr>

                                <tr class="hide">
                                    <th scope="row">份数：</th>
                                    <td>
                                        <asp:TextBox ID="txtPart" runat="server" Text="1" class="required digits" Enabled="false"></asp:TextBox>(用于后期发起合买使用)</td>
                                </tr>
                                <tr class="hide">
                                    <th scope="row">单价：</th>
                                    <td>
                                        <asp:TextBox ID="txtPrice" runat="server" class="required number" Enabled="false"></asp:TextBox>(用于后期发起合买使用)</td>
                                </tr>
                                <tr class="hide">
                                    <th scope="row">限购份数：</th>
                                    <td>
                                        <asp:TextBox ID="txtLimitPart" runat="server" Text="0" class="required digits" Enabled="false"></asp:TextBox>(用于后期发起合买使用)</td>
                                </tr>
                                 <tr>
                                    <th scope="row">最小理财期限：</th>
                                    <td>
                                        <asp:TextBox ID="txtMinDeadline" runat="server" Text="0" class="required digits"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">最大理财期限：</th>
                                    <td>
                                        <asp:TextBox ID="txtMaxDeadline" runat="server" Text="0" class="required digits"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">益率：</th>
                                    <td>
                                        <asp:TextBox ID="txtMaxYield" runat="server" class="required number ">0</asp:TextBox>
                                        （以修改后的数值为准,默认值为当前理财产品的益率）</td>
                                </tr>
                                <tr>
                                    <th scope="row">购买开始时间：</th>
                                    <td>
                                        <asp:TextBox ID="txtStartTime" runat="server" class="required date" onClick="WdatePicker()"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">购买结束时间：</th>
                                    <td>
                                        <asp:TextBox ID="txtEndTime" runat="server" class="required date" onClick="WdatePicker()"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">方案描述：</th>
                                    <td>
                                        <asp:TextBox ID="txtSchemeDescription" runat="server" TextMode="MultiLine" Rows="8" Columns="80"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">备注：</th>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="8" Columns="80"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th scope="row">&nbsp;</th>
                                    <td>
                                        <asp:Button runat="server" ID="btnSubmit" CssClass="button button-primary" Text="确定" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        </table>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
