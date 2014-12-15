<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowImages.aspx.cs" Inherits="StudentLoan.Web.Admin.ShowImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>图片展示</title>
    <script src="js/jquery-1.11.1.js"></script>
    <script src="js/jQueryRotate.js"></script>
    <script type="text/javascript">
        $(function () {
            var value = 0
            $("#<%=imgPicture.ClientID%>").rotate({
                bind:
                 {
                     click: function () {
                         value += 90;
                         $(this).rotate({ animateTo: value })
                     }
                 }

            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 80%; margin-left: auto; margin-right: auto; margin-top: 100px;">
            <p style="font-size: 12px;">点击图片可以旋转查看</p>
            <asp:Image ID="imgPicture" runat="server" AlternateText="点击图片可以旋转查看"  />
        </div>
    </form>
</body>
</html>
