<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TTTTTTTTTTTTTTTTTTTTT.aspx.cs" Inherits="StudentLoan.Web.TTTTTTTTTTTTTTTTTTTTT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="js/jquery.cityselect.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script> 
    <style type="text/css">
        .ui-timepicker-div .ui-widget-header {
            margin-bottom: 8px;
        }

        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
                margin-bottom: -25px;
            }

            .ui-timepicker-div dl dd {
                margin: 0 10px 10px 65px;
            }

        .ui-timepicker-div td {
            font-size: 90%;
        }

        .ui-tpicker-grid-label {
            background: none;
            border: none;
            margin: 0;
            padding: 0;
        }

        .ui_tpicker_hour_label, .ui_tpicker_minute_label, .ui_tpicker_second_label,
        .ui_tpicker_millisec_label, .ui_tpicker_time_label {
            padding-left: 20px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#city").citySelect();
            $('.datepickers').datepicker();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="city">
                <select class="prov"></select>
                <select class="city" disabled="disabled"></select>
                <select class="dist" disabled="disabled"></select>
            </div>
            <div id="2city">
                <select class="prov"></select>
                <select class="city" disabled="disabled"></select>
                <select class="dist" disabled="disabled"></select>
            </div>
            <asp:TextBox ID="txtStartTime" runat="server" class="span2 datepickers" size="16" type="text" data-date-format="yyyy-mm-dd" placeholder="起始日期" />
                <label for="txtStartTime"><span class="add-on" style="margin-right: 20px;"></span></label>
        </div>
    </form>
</body>
</html>
