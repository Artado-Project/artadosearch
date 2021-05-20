<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail_About.aspx.cs" Inherits="Topluluk_Servisler_Mail_Mail_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Mail_About.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Mail - Hakkında</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <img src="../../../AdsızMail1.png" class="image" />
            <asp:Button ID="Button1" runat="server" Text="Artado Search" class="button" OnClick="Button1_Click" BorderStyle="None"/>
            <asp:Button ID="Button2" runat="server" Text="Hakkında" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol" class="button2" OnClick="Button3_Click"  BorderStyle="None"/>
        </div>

        <div class="içerik">
            <h1>Artado Mail Hakkında</h1>
            <h3>Artado Mail, Artado Software tarafından geliştirilen bir e-posta servisidir. Artado Mail'de güvenli bir şekilde e-posta alıp yollayabilirsiniz. Gayet sade bir arayüze sahiptir. Kullanımı kolaydır. İlk defa e-posta yollayan bir kişi bile Artado Mail'i rahatça kullanabilir. </h3>
        </div>
    </form>
</body>
</html>
