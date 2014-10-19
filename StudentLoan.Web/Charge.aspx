<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="StudentLoan.Web.Charge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            订单金额：<asp:TextBox ID="order_amount" runat="server"></asp:TextBox>

            商品名：<asp:TextBox ID="product_name" value="电视机" runat="server"></asp:TextBox>

            银行标识：
	<asp:DropDownList ID="bank_code" Style="width: 150px;" runat="server">
        <asp:ListItem Value="">-请选择-</asp:ListItem>
        <asp:ListItem Value="ABC">农业银行</asp:ListItem>
        <asp:ListItem Value="ICBC">工商银行</asp:ListItem>
        <asp:ListItem Value="CCB">建设银行</asp:ListItem>
        <asp:ListItem Value="BCOM">交通银行</asp:ListItem>
        <asp:ListItem Value="BOC">中国银行</asp:ListItem>
        <asp:ListItem Value="CMB">招商银行</asp:ListItem>
        <asp:ListItem Value="CMBC">民生银行</asp:ListItem>
        <asp:ListItem Value="CEBB">光大银行</asp:ListItem>
        <asp:ListItem Value="CIB">兴业银行</asp:ListItem>
        <asp:ListItem Value="PSBC">邮储银行</asp:ListItem>
        <asp:ListItem Value="SPABANK">平安银行</asp:ListItem>
        <asp:ListItem Value="ECITIC">中信银行</asp:ListItem>
        <asp:ListItem Value="GDB">广发银行</asp:ListItem>
        <asp:ListItem Value="HXB">华夏银行</asp:ListItem>
        <asp:ListItem Value="SPDB">浦发银行</asp:ListItem>
        <asp:ListItem Value="BEA">东亚银行</asp:ListItem>
    </asp:DropDownList>

            <asp:Button ID="Submit" runat="server" Text="智付在线支付" OnClick="Submit_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
