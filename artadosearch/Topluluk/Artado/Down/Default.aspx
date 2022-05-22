<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Topluluk_Artado_Down_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/bootstrap-4.5.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:50px; margin-left:auto; margin-right:auto; text-align:center;">
            <img src="../../../Icons/android-chrome-512x512.png" style="width:300px; height:300px;"/>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Down %>"></asp:Label>
            <br />
            <br />
            <a href="/Forum">Forum</a>
        </div>
    </form>
</body>
</html>
