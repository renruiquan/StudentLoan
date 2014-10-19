<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dinpayQuery.aspx.cs" Inherits="StudentLoan.Web.channel.dinpayQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="order_no" runat="server"></asp:TextBox>
            <asp:Button ID="btn_query" runat="server" Text="查询订单" OnClick="btn_query_Click" />

        </div>

        <div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
