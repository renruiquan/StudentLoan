<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMain.Master" AutoEventWireup="true" CodeBehind="UserMessage.aspx.cs" Inherits="StudentLoan.Web.user.UserMessage" %>

<%@ Register Assembly="StudentLoan.Common" Namespace="StudentLoan.Common.WebControl" TagPrefix="StudentLoan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="StudentLoan.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人信息 - 通知</title>
    <script type="text/javascript">
        $(function () {
            $(".btn-primary").on("click", function () {
                $(this).parents(".border-radius").hide("slow");
                $.post("/tools/delete_user_message.ashx", { "Id": $(this).val() }, function (data, status) {
                    if (status != "success") {
                        alert("操作失败");
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <div class="tabs">

            <ul>
                <li class="active"><a href="javascript:;">通知</a></li>
            </ul>

        </div>

        <div class="cont">

            <div class="item">

                <StudentLoan:RepeaterPlus ID="objRepeater" runat="server">
                    <EmptyDataTemplate>
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td colspan="9">暂无数据</td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class=" border-radius p10 mb10">
                            <div class="media">
                                <a class="pull-left" href="#">
                                    <img class="media-object" data-src="holder.js/64x64" alt="64x64"
                                        src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAABkElEQVR4Xu2YMY6EMAxFEwlKahp6qLn/GajhCDQ0lCCxSlZZZS1ARGSYSLypYCay459vPwY9TdOmXvzRCIADaAFmwItnoGIIQgEoAAWgABR4sQJgEAyCQTAIBl8MAf4MgUEwCAbBIBgEgy9WAAzGwOA8z6rrOrUsi/VSnueqbVtVFIW9d7+ba/97abxYcUIMfdsBfnFN06i+721+V6hflBTG32isOCHFm7VRBZCn64oqy1KN4/hPmKPT33NJSJyvCeDs77eAuTat4QtQ17UahsG2S1VVVhhznWWZ3fu6rn81OMfsxTlrpRARojvAbXbbfh8vtNZKtsaZMM4BV+K4GRNSsFz7MQFMIv+0XWJ5qrLgvfuzOHdF+KgAchDK4vZa40gQU+hVmoQ44rYAJtlVfMle92eAcYY86SOcmjhnRHlcgJCEqa2N4oDUigrZDwLEeBQOUTy1tTgAB/BOkHeCvBNMbTI/uR8oAAWgABSAAk9O3dRyQQEoAAWgABRIbTI/uR8oAAWgABSAAk9O3dRy/QDwoQCf5JU+PwAAAABJRU5ErkJggg=="
                                        style="width: 64px; height: 64px;" />
                                </a>

                                <div class="media-body">
                                    <h5 class="media-heading <%#Eval("Title").ToString()=="材料通过"?"c-green":"c-red" %> "><%#Eval("Title") %></h5>

                                    <p><%#Eval("CreateTime").Convert<DateTime>().ToString("yyyy-MM-dd") %></p>

                                    <p>
                                        <%#Eval("Content") %>
                                    </p>

                                    <p>
                                        <button type="button" id="btnHidn" runat="server" class="btn btn-primary" value='<%#Eval("Id") %>'>删除</button>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>

                </StudentLoan:RepeaterPlus>
            </div>

            <div class="clear mt20"></div>

            <div class="pagination pagination-centered">
                <webdiyer:AspNetPager ID="objAspNetPager" PagingButtonLayoutType="UnorderedList" runat="server" PageSize="10" OnPageChanged="objAspNetPager_PageChanged" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" CustomInfoStyle="" CurrentPageButtonClass="active" AlwaysShow="True" PagingButtonSpacing="0px"></webdiyer:AspNetPager>
            </div>

        </div>

    </div>
</asp:Content>
