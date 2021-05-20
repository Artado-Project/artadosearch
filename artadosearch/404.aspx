<%@ Page Language="C#" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="Icons/favicon.ico" />
    <link href="404.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Upss! Bir şeyler yanlış gitti!</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="orta">
             <img src="Icons/artado_searchv2.png" class="auto-style1"/>
        <p></p>
        </div>
        <img src="üzgün-artalio.png" class="image"/>

        <div class="labeldiv">
            <asp:Label ID="Label1" runat="server" Text="Upss! Bir şeyler yanlış gitti!" Font-Bold="True" Font-Size="Larger" ForeColor="White"  ></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Size sunduğumuz servisde aksaklık yaşattığımız için özür dileriz. Var olmayan bir sayfaya uğradınız veya Artado Search kısa süreli bir çöküntü yaşadı. Eğer ikinci şık ise şu anda bu sorun ile ilgileniyoruzdur. Sizde bu sorunu şimdilik gidermek için şunları yapabilirsiniz:" Font-Bold="true" Font-Size="Larger" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="-Ana sayfaya dönmeyi deneyebilirsiniz." Font-Bold="true" Font-Size="Larger" ForeColor="White" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label" runat="server" Text="-Eğer arama sorgunuzun başında semboller varsa kaldırın." Font-Bold="true" Font-Size="Larger" ForeColor="White" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="-Sorununuz hala çözülmediyse bizimle iletişime geçin." Font-Bold="true" Font-Size="Larger" ForeColor="White"></asp:Label>
        </div>
    </form>
</body>
</html>
