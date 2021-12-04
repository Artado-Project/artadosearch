<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Topluluk_Servisler_Beyt_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<link href="main.css" rel="stylesheet" media="screen"/>
<link rel="shortcut icon" href="/Icons/Beyt/favicon.ico" />
<script type="text/javascript" src="/js/default.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta charset="utf-8"/>
<link rel="apple-touch-icon" href="/Icons/Beyt/apple-touch-icon.png"/>
<link rel="apple-touch-startup-image" href="/Icons/Beyt/apple-touch-icon.png"/>
<link rel="icon" sizes="192x192" href="/Icons/Beyt/android-chrome-192x192.png"/>
<meta name="apple-mobile-web-app-capable" content="yes"/>
<meta name="apple-mobile-web-app-status-bar-style" content="black-translucent"/>
<link rel="manifest" href="js/manifest.json"/>
<link href="https://www.artadosearch.com/Beyt" rel="canonical"/>
<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<meta name="keywords" content="mesajlaşma, chat, yerli, artado, yerli mesajlaşma uygulaması, gizlilik, milli, türk yapımı, güvenli, sade, reklamsız, talk, communication, messaging app, privacy, security, türkiye" />
<meta name="description" content="Open Source Messaging App - Communicate without being tracked" />
<meta property="og:title" content="Beyt Messenger" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artadosearch.com/Beyt" />
<meta property="og:description" name="description" class="swiftype" content="Open Source Messaging App - Communicate without being tracked"/>
<title>Beyt Messenger</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="top" class="top">
                <img src="/Icons/Beyt/beyt_icon.png" style="width:60px; height:60px; margin-left:100px; margin-top:20px;"/>
                <asp:ImageButton ID="ProfilePic" runat="server" ImageUrl="/Images/image.png" CssClass="login"/>
            </div>

            <div id="contacts" class="contacts">
                <div id="search" class="search">
                    <asp:TextBox ID="arama_çubugu" type="search" placeholder="" runat="server" TextMode="Search"  BorderStyle="None" AutoCompleteType="Search" ValidateRequestMode="Disabled"></asp:TextBox>
                    <asp:ImageButton ID="SearchButton" runat="server" Height="25px" CssClass="Button1" ImageUrl="~/search.png" Width="25px"  BorderStyle="None"/>
                </div>
                <div class="sad">
                    <img src="../../../polisartalio2.png" style="width:150px; height:100px; margin-bottom:20px;"/><br />
                    <asp:Label ID="sadtxt" runat="server" Text="Hmm Buralarda Kimse Yok Gibi... Neyse ki Artado Yanında!" Font-Italic="true"></asp:Label>
                </div>
            </div>

            <div id="welcome" class="welcome">
                <asp:Label ID="WelcomeTxt" runat="server" Text="Hoşgeldin" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
