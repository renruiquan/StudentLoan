<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="AvatarUpload.aspx.cs" Inherits="StudentLoan.Web.user.AvatarUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>账户信息 - 头像上传</title>
    <script src="../js/fullAvatarEditor.js"></script>
    <script src="../js/swfobject.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="cont clear-top">
            <div style="width: 630px; margin: 0 auto;">

                <div>
                    <p id="swfContainer">
                    </p>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        swfobject.addDomLoadEvent(function () {

            var swf = new fullAvatarEditor("swfContainer", {
                id: 'swf',
                upload_url: '/tools/upload_avatar.ashx?userId=<%=base.GetUserModel().UserId%>',
                src_upload: 2,
                avatar_sizes: "120*120",
            }, function (msg) {
                switch (msg.code) {
                    case 5:
                        if (msg.type == 0) {
                            window.location.href = "UserAccount.aspx";
                        }
                        break;
                    case 1:
                        alert('头像上传失败，原因：' + json.content.msg);//will output:头像上传失败，原因：上传的原图文件大小超出限值了！
                        break;
                }
            }
            );
        });
    </script>
</asp:Content>
