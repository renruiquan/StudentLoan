<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModifyCert.aspx.cs" Inherits="StudentLoan.Web.user.ModifyCert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>学子易贷 - 更新认证图片</title>
    <style type="text/css">
        .uploadify-queue-item {
            display: none;
        }

        .img-cert {
            width: 290px;
            height: 216px;
        }
    </style>
    <script src="/js/jquery.uploadify.js"></script>
    <script type="text/javascript">
        $(function () {
            var target = $(".uploadify-button");
            $(target).each(function () {
                var typeId = $(this).attr("typeId");
                var _for = $(this).attr("for");
                var temp_siblings = $(this).siblings().children("img");
                var cid = $(this).attr("id");
                $(this).uploadify({
                    swf: '../uploadify.swf',
                    uploader: '../tools/upload_cert.ashx?type=' + typeId + '&userId=<%=base.GetUserModel().UserId%>&cid=' + cid + '&action=edit',
                    width: 274,
                    buttonText: "更新并预览",
                    fileTypeExts: '*.gif; *.jpg;*.jpeg; *.png',
                    fileSizeLimit: '500KB',
                    buttonClass: 'btn mt5 btn-primary',
                    onUploadSuccess: function (file, data, response) {

                        var json_data = $.parseJSON(data);
                        if (json_data.result == "true") {

                            $(temp_siblings).attr("src", json_data.url);
                        } else {
                            alert("上传失败");
                        }

                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="h45" style="line-height: 45px;">
            <h4>更新认证图片</h4>
        </div>
        <ul class="thumbnails">
            <asp:Literal ID="objLiteral" runat="server">

            </asp:Literal>
        </ul>

        <div class="clear"></div>
        <div class="h150"></div>
    </div>
</asp:Content>
