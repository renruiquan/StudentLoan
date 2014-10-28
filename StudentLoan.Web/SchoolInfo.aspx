<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolInfo.aspx.cs" Inherits="StudentLoan.Web.SchoolInfo" %>

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
</head>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#city").citySelect();
            $("#city1").citySelect();
            $('.datepickers').datepicker();
        });
    </script>
<body>
    <form id="form1" runat="server">
        <div>
            <%--就读学校--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="txtSchoolName" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>          
            <%--学校地址--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="txtSchoolAddress" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--入学年份--%>
            <div class="control-group">
                <div class="controls">
                    <label class="control-label" for="txtUserName">入学年份</label>
                    <span>*</span>
                    <asp:TextBox ID="txtYearOfAdmission" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="请选择" />
                    <label for="txtStartTime"><span class="add-on" style="margin-right: 20px;"></span></label>
                </div>
            </div>
            <%--学制--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="drpSchoolSystem">
                        <asp:ListItem Value="3">3年制</asp:ListItem>
                        <asp:ListItem Value="4">4年制</asp:ListItem>
                        <asp:ListItem Value="5">5年制</asp:ListItem>
                        <asp:ListItem Value="6">6年制</asp:ListItem>
                        <asp:ListItem Value="7">6年制</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--学历--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="drpEducation">
                        <asp:ListItem Value="2">大专</asp:ListItem>
                        <asp:ListItem Value="1">本科</asp:ListItem>
                        <asp:ListItem Value="3">硕士</asp:ListItem>
                        <asp:ListItem Value="4">博士</asp:ListItem>
                        <asp:ListItem Value="5">博士后</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--所在学院--%>
            <div class="control-group">
                <label class="control-label" for="txtBranchSchool"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="txtBranchSchool" placeholder="所在学院" runat="server" />
                </div>
            </div>            
            <%--保存并继续--%>
            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="SaveContinue" runat="server" Text="保存并继续" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
