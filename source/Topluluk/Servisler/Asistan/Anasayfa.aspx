<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Anasayfa.aspx.cs" Inherits="Topluluk_Servisler_Asistan_Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="anasayfa.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Artado Asistan</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <img src="../../../Adsız.png" class="image" />
            <asp:Button ID="Button1" runat="server" Text="Artado Search" class="button" OnClick="Button1_Click" BorderStyle="None"/>
            <asp:Button ID="Button2" runat="server" Text="Hakkında" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol" class="button2" OnClick="Button3_Click" BorderStyle="None"/>
        </div>
    </form>
</body>
</html>
