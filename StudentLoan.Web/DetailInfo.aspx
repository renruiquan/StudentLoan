<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailInfo.aspx.cs" Inherits="StudentLoan.Web.DetailInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="js/jquery.cityselect.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#city").citySelect();
            $("#city1").citySelect();
            $('.datepickers').datepicker();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--真实姓名--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName">真实姓名</label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="txtUserName" runat="server" />
                </div>
            </div>
            <%--身份证号码--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">身份证号</label>
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox1" runat="server" />
                </div>
            </div>
            <%--手机号--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">手机号</label>
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox2" runat="server" />
                </div>
            </div>
            <%--性别--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">性别</label>
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="s">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--民族--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">民族</label>
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="DropDownList1">
                        <asp:ListItem Value="汉族">汉族</asp:ListItem>
                        <asp:ListItem Value="蒙古族">蒙古族</asp:ListItem>
                        <asp:ListItem Value="回族">回族</asp:ListItem>
                        <asp:ListItem Value="藏族">藏族</asp:ListItem>
                        <asp:ListItem Value="维吾尔族">维吾尔族</asp:ListItem>
                        <asp:ListItem Value="苗族">苗族</asp:ListItem>
                        <asp:ListItem Value="彝族">彝族</asp:ListItem>
                        <asp:ListItem Value="壮族">壮族</asp:ListItem>
                        <asp:ListItem Value="布依族">布依族</asp:ListItem>
                        <asp:ListItem Value="朝鲜族">朝鲜族</asp:ListItem>
                        <asp:ListItem Value="满族">满族</asp:ListItem>
                        <asp:ListItem Value="侗族">侗族</asp:ListItem>
                        <asp:ListItem Value="瑶族">瑶族</asp:ListItem>
                        <asp:ListItem Value="白族">白族</asp:ListItem>
                        <asp:ListItem Value="土家族">土家族</asp:ListItem>
                        <asp:ListItem Value="哈尼族">哈尼族</asp:ListItem>
                        <asp:ListItem Value="哈萨克族">哈萨克族</asp:ListItem>
                        <asp:ListItem Value="傣族">傣族</asp:ListItem>
                        <asp:ListItem Value="黎族">黎族</asp:ListItem>
                        <asp:ListItem Value="傈僳族">傈僳族</asp:ListItem>
                        <asp:ListItem Value="佤族">佤族</asp:ListItem>
                        <asp:ListItem Value="畲族">畲族</asp:ListItem>
                        <asp:ListItem Value="高山族">高山族</asp:ListItem>
                        <asp:ListItem Value="拉祜族">拉祜族</asp:ListItem>
                        <asp:ListItem Value="水族">水族</asp:ListItem>
                        <asp:ListItem Value="东乡族">东乡族</asp:ListItem>
                        <asp:ListItem Value="纳西族">纳西族</asp:ListItem>
                        <asp:ListItem Value="景颇族">景颇族</asp:ListItem>
                        <asp:ListItem Value="柯尔克孜族">柯尔克孜族</asp:ListItem>
                        <asp:ListItem Value="土族">土族</asp:ListItem>
                        <asp:ListItem Value="达斡尔族">达斡尔族</asp:ListItem>
                        <asp:ListItem Value="仫佬族">仫佬族</asp:ListItem>
                        <asp:ListItem Value="羌族">羌族</asp:ListItem>
                        <asp:ListItem Value="布朗族">布朗族</asp:ListItem>
                        <asp:ListItem Value="撒拉族">撒拉族</asp:ListItem>
                        <asp:ListItem Value="毛难族">毛难族</asp:ListItem>
                        <asp:ListItem Value="仡佬族">仡佬族</asp:ListItem>
                        <asp:ListItem Value="锡伯族">锡伯族</asp:ListItem>
                        <asp:ListItem Value="阿昌族">阿昌族</asp:ListItem>
                        <asp:ListItem Value="普米族">普米族</asp:ListItem>
                        <asp:ListItem Value="塔吉克族">塔吉克族</asp:ListItem>
                        <asp:ListItem Value="怒族">怒族</asp:ListItem>
                        <asp:ListItem Value="乌孜别克族">乌孜别克族</asp:ListItem>
                        <asp:ListItem Value="俄罗斯族">俄罗斯族</asp:ListItem>
                        <asp:ListItem Value="鄂温克族">鄂温克族</asp:ListItem>
                        <asp:ListItem Value="崩龙族">崩龙族</asp:ListItem>
                        <asp:ListItem Value="保安族">保安族</asp:ListItem>
                        <asp:ListItem Value="裕固族">裕固族</asp:ListItem>
                        <asp:ListItem Value="京族">京族</asp:ListItem>
                        <asp:ListItem Value="塔塔尔族">塔塔尔族</asp:ListItem>
                        <asp:ListItem Value="独龙族">独龙族</asp:ListItem>
                        <asp:ListItem Value="鄂伦春族">鄂伦春族</asp:ListItem>
                        <asp:ListItem Value="赫哲族">赫哲族</asp:ListItem>
                        <asp:ListItem Value="门巴族">门巴族</asp:ListItem>
                        <asp:ListItem Value="珞巴族">珞巴族</asp:ListItem>
                        <asp:ListItem Value="基诺族">基诺族</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--出生日期--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">出生日期</label>
                    <span>*</span>
                    <asp:TextBox ID="txtStartTime" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="请选择" />
                    <label for="txtStartTime"><span class="add-on" style="margin-right: 20px;"></span></label>
                </div>
            </div>
            <%--现住址--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">现住址</label>
                    <span>*</span>
                    <div id="city1">
                        <select class="prov"></select>
                        <select class="city" disabled="disabled"></select>
                        <select class="dist" disabled="disabled"></select>
                    </div>
                </div>
            </div>
            <%--保存并继续--%>
            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="btnLogin" runat="server" Text="保存并继续" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
