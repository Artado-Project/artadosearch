<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="Topluluk_Servisler_Mail_Mail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Mail.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Mail - Sade, güvenli ve gizliliğinize saygılı</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <img src="../../../AdsızMail1.png" class="image" />
            <asp:Button ID="Button1" runat="server" Text="Artado Search" class="button" OnClick="Button1_Click" BorderStyle="None"/>
            <asp:Button ID="Button2" runat="server" Text="Hakkında" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol" class="button2" OnClick="Button3_Click" BorderStyle="None"/>
        </div>

        <div class="içerik">
            <h1>Sade,güvenli ve gizliliğinize saygılı</h1>
        </div>
        <h1 class="txt" style="font-size:50px;">Çok Yakında!</h1>
    </form>
</body>
</html>
