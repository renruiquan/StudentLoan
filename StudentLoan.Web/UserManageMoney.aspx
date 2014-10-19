<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManageMoney.aspx.cs" Inherits="StudentLoan.Web.UserManageMoney" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购买理财产品</title>
</head>
<body>
    <form id="form1" runat="server" action="UserManageMoneyBuy.aspx" method="post">
        购买份数:<input type="text" name="part" />

        <input type="submit" value="确认购买" />
        <input type="hidden" name="ProductID" value="<%=this.ProductId %>" />
        <input type="hidden" name="ProductSchemeId" value="<%=this.ProductSchemeId %>" />
    </form>
</body>
</html>
