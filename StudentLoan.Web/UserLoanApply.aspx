<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoanApply.aspx.cs" Inherits="StudentLoan.Web.UserLoanApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>申请借款</title>
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/dialog-plus-min.js"></script>
    <link href="css/ui-dialog.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />


</head>
<body>
    <form class="form-horizontal" runat="server">
        <div class="control-group">
            <label class="control-label" for="txtLoanTitle">借款标题</label>
            <div class="controls">
                <asp:TextBox type="text" ID="txtLoanTitle" placeholder="借款标题" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlLoanMoney">借款金额</label>
            <div class="controls">
                <asp:DropDownList runat="server" ID="ddlLoanMoney">
                    
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="">服务费</label>
            <div class="controls">
                <label style="padding-top: 5px; color: red;">9% 只要申请贷款成功，所有信用等级的服务费都为9%/月，但信用等级越高贷款的成功性越大</label>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlLoanCategory">借款用途</label>
            <div class="controls">
                <asp:DropDownList runat="server" ID="ddlLoanCategory">
                    <asp:ListItem Value="1">因为爱情（恋爱贷款）</asp:ListItem>
                    <asp:ListItem Value="2">游山玩水（旅游贷款）</asp:ListItem>
                    <asp:ListItem Value="3">时尚达人（购物贷款）</asp:ListItem>
                    <asp:ListItem Value="4">追求自我（娱乐贷款）</asp:ListItem>
                    <asp:ListItem Value="5">急人所急（应急贷款）</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="control-group">
            <label class="control-label" for="ddlLoanTypeId">借款类型</label>
            <div class="controls">
                <asp:DropDownList runat="server" ID="ddlLoanTypeId">
                    <asp:ListItem Value="1">一般借款</asp:ListItem>
                    <asp:ListItem Value="2">紧急借款</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="control-group">
            <label class="control-label" for="ddlTotalAmortization">借款期限</label>
            <div class="controls">
                <asp:DropDownList runat="server" ID="ddlTotalAmortization">
                  
                </asp:DropDownList>
            </div>
        </div>

        <div class="control-group">
            <label class="control-label" for="">还款方式</label>
            <div class="controls">
                <label style="padding-top: 5px;">每个月还服务费，最后一期本金、服务费一起归还</label>
            </div>
        </div>

        <div class="control-group">
            <label class="control-label" for="txtLoanDescription">借款描述</label>
            <div class="controls">
                <asp:TextBox type="text" ID="txtLoanDescription" placeholder="借款描述,最多500个汉字" TextMode="MultiLine" Rows="3" runat="server" />
            </div>
        </div>

        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnApply" runat="server" CssClass="btn btn-primary" Text="提交申请" OnClick="btnApply_Click" />
            </div>
        </div>
    </form>
</body>
</html>
