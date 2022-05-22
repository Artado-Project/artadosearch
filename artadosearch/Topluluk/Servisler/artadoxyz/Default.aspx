<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Topluluk_Servisler_artadoxyz_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Topluluk/Servisler/Home/About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
<link href="bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<link rel="shortcut icon" href="/Icons/favicon.ico" />
<script type="text/javascript" src="/js/default.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta charset="utf-8"/>
<link rel="apple-touch-icon" href="/Icons/apple-touch-icon.png"/>
<link rel="apple-touch-startup-image" href="/Icons/apple-touch-icon.png"/>
<link rel="icon" sizes="192x192" href="/Icons/android-chrome-192x192.png"/>
<meta name="theme-color" content="#517BBA"/>
<link rel="search" type="application/opensearchdescription+xml" title="Artado Search" href="https://www.artadosearch.com/opensearch.xml"/>
<meta name="apple-mobile-web-app-capable" content="yes"/>
<meta name="apple-mobile-web-app-status-bar-style" content="black-translucent"/>
<link rel="manifest" href="js/manifest.json"/>
<link href="https://www.artado.xyz" rel="canonical"/>
<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<meta name="keywords" content="arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, sade, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, tarayıcı, browser, celer" />
<meta name="description" content="Open Source, Private and Anonymous Search Engine" />
<meta property="og:title" content="Artado Search" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artado.xyz" />
<meta property="og:description" name="description" class="swiftype" content="Open Source, Private and Anonymous Search Engine"/>
<meta name="twitter:card" content="summary_large_image" />
<meta name="twitter:title" content="Artado Search" />
<meta name="twitter:description" content="Open Source, Private and Anonymous Search Engine" />
<meta name="twitter:url" content="https://www.artado.xyz" />
<meta name="twitter:image" content="https://www.artadosearch.com/Icons/privacy.jpg" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Software</title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="../../../IMG_074.png" CssClass="image" />
            <br />
            <br />
            <asp:Button ID="Anasayfa" runat="server" Text="Artado Search" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="<%$Resources:Default, Hakkımızda %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="<%$Resources:Default, İletişim %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="<%$Resources:Default, Blog %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="<%$Resources:Default, Destek %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div style="text-align: center; margin-bottom:150px; text-decoration:none;">
            <a href="https://www.artadosearch.com/" style="text-decoration:none;">
                <img src="../../../Icons/android-chrome-512x512.png" class="image"/>
                <h2>Artado Search</h2>
                <h3>Open Source, Private and Customizable Search Engine</h3>
            </a>
            <a href="https://www.artadosearch.com/Celer" style="text-decoration:none;">
                <img src="../../../Icons/Celer/icons/icon.ico" class="image"/>
                <h2>Celer Browser</h2>
                <h3>Private and Open Source Web Browser</h3>
            </a>
        </div>
    </form>
</body>
</html>
