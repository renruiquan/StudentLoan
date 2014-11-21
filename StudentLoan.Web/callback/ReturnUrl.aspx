<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnUrl.aspx.cs" Inherits="StudentLoan.Web.callback.ReturnUrl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="container" style="margin-top: 50px;">
                <div class="orderlistwrapper">
                    <div class="s_content1">
                        <div class="s_content1_header">
                            <h2 style="line-height: 50px; padding: 0 20px;">充值成功</h2>
                        </div>
                        <div class="s_content1_by">
                            <asp:Literal ID="objLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
