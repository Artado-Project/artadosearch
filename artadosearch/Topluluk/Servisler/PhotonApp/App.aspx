<%@ Page Language="C#" AutoEventWireup="true" CodeFile="App.aspx.cs" Inherits="Topluluk_Servisler_PhotonApp_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="search" type="application/opensearchdescription+xml" href="https://www.artadosearch.com/opensearch.xml" title="Artado Search"/>
<link href="/AramaSonuc.css" rel="stylesheet" />
<link href="/text.css" rel="stylesheet" media="screen"/>
<link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
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
<link href="https://www.artadosearch.com/" rel="canonical"/>
<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<meta name="keywords" content="arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, sade, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, türkiye" />
<meta name="description" content="Open Source, Private and Anonymous Search Engine" />
<meta property="og:title" content="Artado Search" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artadosearch.com" />
<meta property="og:description" name="description" class="swiftype" content="Open Source, Private and Anonymous Search Engine"/>
<meta name="twitter:card" content="summary_large_image" />
<meta name="twitter:title" content="Artado Search" />
<meta name="twitter:description" content="Open Source, Private and Anonymous Search Engine" />
<meta name="twitter:url" content="https://www.artadosearch.com/" />
<meta name="twitter:image" content="https://www.artadosearch.com/Icons/privacy.jpg" />
<title>Artado Photon - Main Page</title>
</head>
<body id="bdy1" runat="server" style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">
<div id="arama" class="orta"> 
<asp:Panel ID="Panel1" runat="server" BackColor="Transparent">
<asp:Image ID="Image1" src="/Icons/Photon_Banner.png" runat="server" CssClass="auto-style1"/>
<asp:Panel ID="Normal" runat="server" CssClass="arama" BorderStyle="Outset">

    <style>
        @media screen and (min-width: 600px) {            
            #arama_çubugu {
                Height: 29px;
                Width: 510px !important
            }
        }

        @media screen and (min-width: 100px) and (max-width: 600px) {
            #arama_çubugu {
                width: 240px;
                Height: 29px;
            }
        }
    </style>

<asp:TextBox ID="arama_çubugu" type="search" placeholder="<%$Resources:Default, Arama_çubuğu %>" runat="server" TextMode="Search"  BorderStyle="None" autofocus AutoCompleteType="Search" ValidateRequestMode="Disabled"></asp:TextBox>
<asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
</asp:Panel>
</asp:Panel>
<br />
<br />
<asp:Label ID="Label12" runat="server" Text="Label" Font-Size="Small"></asp:Label>
</div>

<asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Icons/burger_icon.png" CssClass="ayarlar" OnClick="ImageButton1_Click"/>
<asp:ImageButton ID="ProfilePic" runat="server" CssClass="login" OnClick="ProfilePic_Click"/>
<asp:Button ID="Button1" runat="server" Text="<%$Resources:Default, Destek %>"  CssClass="destek" ForeColor="Black" BackColor="Transparent" BorderStyle="None" OnClick="Button3_Click"/>
<asp:Button ID="Button2" runat="server" Text="<%$Resources:Default, Oturum %>"  CssClass="login" ForeColor="Black" BackColor="SkyBlue" BorderStyle="None" OnClick="Button2_Click1"/>

<asp:Panel ID="Kontrol" runat="server" CssClass="kontrol" BorderStyle="Outset" BackColor="black">
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat" OnClick="ImageButton2_Click"/>
<asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, Kontrol %>" ForeColor="#517BBA" ></asp:Label>
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Tema %>" ForeColor="#517BBA"></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
<asp:ListItem Text="<%$Resources:Default, Klasik %>" Value="Klasik"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Night %>" Value="Night"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Karanlık %>" Value="Dark"></asp:ListItem>                     
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="<%$Resources:Default, Lang %>" ForeColor="#517BBA"></asp:Label>
<asp:DropDownList ID="ddlanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
<asp:ListItem Text="<%$Resources:Default, Türkçe %>" Value="tr-TR"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, İngilizce %>" Value="en-US"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Fransızca %>" Value="fr-FR"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Almanca %>" Value="de-DE"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, AzeriTR %>" Value="en-AU"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, İtalyanca %>" Value="it-IT"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Rusça %>" Value="ru-RU"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Çince %>" Value="zh-CHS"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, İspanyolca %>" Value="es-ES"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Portekizce %>" Value="pt-PT"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Korece %>" Value="ko-KR"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Japonca %>" Value="ja-JP"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Macarca %>" Value="hu-HU"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Bulgarca %>" Value="bg-BG"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Boşnakça %>" Value="en-BZ"></asp:ListItem>
</asp:DropDownList>
<br />
<br />
<a href="/Settings" style="text-decoration:none;"><asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Ayarlar %>"></asp:Label></a>
<br />
<br />
<a href="/AddResult" style="text-decoration:none;"><asp:Label ID="Label3" runat="server" Text="<%$Resources:Default, Sonuç %>"></asp:Label></a>
<br />
<br />
<a href="/About" style="text-decoration:none;"><asp:Label ID="Label24" runat="server" Text="<%$Resources:Default, Hakkımızda %>"></asp:Label></a>
<br />
<br />
<a href="/Manifest" style="text-decoration:none;"><asp:Label ID="Manifest" runat="server" Text="<%$Resources:Default, Manifesto %>"></asp:Label></a>
<br />
<br />
<a href="/Forum" style="text-decoration:none;"><asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Blog %>"></asp:Label></a>
<br />
<br />
<a href="/Photon" style="text-decoration:none;"><asp:Label ID="Label9" runat="server" Text="Artado Photon"></asp:Label></a>
<br />
<br />
<a href="/Updates" style="text-decoration:none;"><asp:Label ID="Label11" runat="server" Text="<%$Resources:Default, Güncelleme %>"></asp:Label></a>
<br />
<br />
<a href="/Privacy" style="text-decoration:none;"><asp:Label ID="Label25" runat="server" Text="<%$Resources:Default, Politika %>"></asp:Label></a>
<br />
<br />
<a href="https://github.com/ardatdev/artadosearch-source" style="text-decoration:none;"><asp:Label ID="Label16" runat="server" Text="Github"></asp:Label></a>
</asp:Panel>

<style>
        @media screen and (min-width: 600px) {            
            .photon_news{
                width:510px !important;
                padding:15px 15px 15px 15px;
                border-top-left-radius: 10px;
                border-top-right-radius: 10px;
                border-bottom-left-radius: 10px;
                border-bottom-right-radius: 10px;
            }

            .news_results{
                width:510px !important;
            }
            
            #news_image{
                width:480px;
                height:100px;
                display:inline
            }
        }

        @media screen and (min-width: 100px) and (max-width: 600px) {
            .photon_news{
                width:300px !important;
                padding:20px 20px 20px 20px;
                border-top-left-radius: 10px;
                border-top-right-radius: 10px;
                border-bottom-left-radius: 10px;
                border-bottom-right-radius: 10px;
            }

            .news_results{
                width:300px !important;
            }

            #news_image{
                width:220px;
                height:100px;
                display:inline
            }
        }
</style>

<div class="news_results" style="margin-left:auto; margin-right:auto">
    <asp:Repeater ID="News_Results" runat="server">
        <ItemTemplate>
            <a href="<%# Eval("Link") %>" rel="nofollow" style="text-decoration:none">
                <div class="photon_news" id="news">
                    <img id="news_image" src='<%# Eval("Image") %>'/><br />
                    <div id="news_text" style="display:inline">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label><br />
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("Date") %>' Font-Size="Small"></asp:Label>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Source") %>' Font-Size="Small" ForeColor="Green"></asp:Label>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
    </form>
</body>
</html>
