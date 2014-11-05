<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SmsTest.aspx.cs" Inherits="StudentLoan.Web.SmsTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtMobile" runat="server">18601106664</asp:TextBox>
    <asp:TextBox ID="txtContent" runat="server">xxxxxxxxx</asp:TextBox>
    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="发送短信" />
</asp:Content>
