<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Content/jquery/js/jquery.js" type="text/javascript"></script>
    <script src="/Content/jquery/js/jquery-ui-min.js" type="text/javascript"></script>
    <link href="/Content/jquery/css/ui-lightness/jquery-ui-custom.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="/Content/css/screen.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="/Content/css/print.css" type="text/css" media="print" />
    <!--[if lt IE 8]><link rel="stylesheet" href="Contentcss/css/ie.css" type="text/css" media="screen, projection"/><![endif]-->
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="">
        <div class="" id="searchpanel">
            <div class="" id="querytime">
                <asp:TextBox runat="server" ID="tbxBegin"></asp:TextBox>
                <asp:TextBox runat="server" ID="tbxEnd"></asp:TextBox>
            </div>
            <div class="clear " id="clerkname">
            </div>
            <div class="clear ">
                <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" />
            </div>
        </div>
        <div class="clear" id="searchresult">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
