<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolInfo.aspx.cs" Inherits="StudentLoan.Web.SchoolInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--就读学校--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="txtUserName" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--校区--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <asp:TextBox type="text" ID="TextBox1" placeholder="用户名  中文、数字、字母组成" runat="server" />
                    (没有分校区可以不填)
                </div>
            </div>
            <%--学校地址--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox2" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--学号--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox7" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--入学年份--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="s">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--学制--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="DropDownList1">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--学历--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:DropDownList runat="server" ID="DropDownList4">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--所在学院--%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox3" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--专业(系) --%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox4" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--班级 --%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox5" placeholder="用户名  中文、数字、字母组成" runat="server" />
                </div>
            </div>
            <%--寝室 --%>
            <div class="control-group">
                <label class="control-label" for="txtUserName"></label>
                <div class="controls">
                    <span>*</span>
                    <asp:TextBox type="text" ID="TextBox6" placeholder="用户名  中文、数字、字母组成" runat="server" />
                    区/栋/楼/号
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
