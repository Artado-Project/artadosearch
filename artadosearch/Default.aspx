 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ErrorPage="~/404.aspx"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="text.css" rel="stylesheet" media="screen"/>
    <link href="bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
        <link rel="shortcut icon" href="/Icons/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="apple-touch-icon" href="/Icons/apple-touch-icon.png"/>
    <link rel="apple-touch-startup-image" href="/Icons/apple-touch-icon.png"/>
    <link rel="icon" sizes="192x192" href="/Icons/android-chrome-192x192.png"/>
    <meta name="theme-color" content="#517BBA"/>
    <link rel="search" type="application/opensearchdescription+xml" title="Artado Search" href="/opensearch.xml"/>
    <meta name="apple-mobile-web-app-capable" content="yes"/>
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent"/>
    <link rel="manifest" href="js/manifest.json"/>
<meta name="application-name" content="Artado Search"/>
    <meta name="description" content="Artado Search - Anonymous and secure search engine" />
<meta name="keywords" content="arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, sade, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, türkiye" />
       <title>Artado Search</title>
</head>
<body style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">

         <!--Arda Tahtacı tarafından tasarlanmış,programlanmış ve yayınlanmıştır.-->

         <div style="width:800px" class="container">
        </div>

        <div id="arama" class="orta">
            <img alt="" class="auto-style1" src="Icons/artado_searchv2.png"  />

            <asp:Panel ID="Panel1" runat="server" CssClass="arama" BorderStyle="Outset">
            <asp:TextBox ID="arama_çubugu" placeholder="<%$Resources:Default, Arama_çubuğu %>" runat="server" TextMode="Search"  BorderStyle="None" autofocus AutoCompleteType="Search" MaxLength="100" ValidateRequestMode="Disabled"></asp:TextBox>
         <asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
         <asp:ImageButton ID="Voice" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/voice-search.png" Width="19px"  BorderStyle="None" OnClick="Voice_Click"/>
         <asp:ImageButton ID="Command" runat="server" Height="35px" CssClass="Button1" ImageUrl="~/com_icon.png" Width="40px"  BorderStyle="None" OnClick="Command_Click" />
                </asp:Panel>

            <asp:Panel ID="komutlar" runat="server" CssClass="komutlar">
                <h5 style="font-size:small; font-style:italic; color:#517BBA; float:left;">Özel Komutlarla arama</h5>
                <br />

                <!--DuckDuckGo Arama Komut-->
                <div class="komut1">  
                    <asp:ImageButton ID="ImageButton3" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="DDG-icon_256x256.png" OnClick="ImageButton3_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text=".ddg" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="DuckDuckGo" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>
               
                <!--Google Arama Komut-->
                <div class="komut2"> 
                    <asp:ImageButton ID="ImageButton4" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="178-1783296_g-transparent-circle-google-logo.png" OnClick="ImageButton4_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" Text=".g" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label15" runat="server" Text="Google Search" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                <!--Youtube Arama Komut-->
                <div class="komut2"> 
                    <asp:ImageButton ID="ImageButton5" runat="server" style="width:40px; height:30px; float:left; outline:none;" ImageUrl="1024px-YouTube_full-color_icon_(2017).png" OnClick="ImageButton5_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label16" runat="server" Text=".yt" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label17" runat="server" Text="Youtube" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                <!--Instagram Arama Komut-->
                <div class="komut1"> 
                    <asp:ImageButton ID="ImageButton6" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="instagram-icon-png-file-instagram-icon-png-599.png" OnClick="ImageButton6_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label18" runat="server" Text=".i" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label19" runat="server" Text="Instagram" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                <!--Reddit Arama Komut-->
                <div class="komut2"> 
                    <asp:ImageButton ID="ImageButton7" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="2018_social_media_popular_app_logo_reddit-512.png" OnClick="ImageButton7_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label20" runat="server" Text=".r" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label21" runat="server" Text="Reddit" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                <!--Ekşi Sözlük Arama Komut-->
                <div class="komut1"> 
                    <asp:ImageButton ID="ImageButton8" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="ilogo_fbv2.png" OnClick="ImageButton8_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label22" runat="server" Text=".eksi" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label23" runat="server" Text="Ekşi Sözlük" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                 <!--Twitter Arama Komut-->
                <div class="komut2"> 
                    <asp:ImageButton ID="ImageButton9" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="image%20(1).png" OnClick="ImageButton9_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label24" runat="server" Text=".t" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label25" runat="server" Text="Twitter" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                 <!--Wikipedia Arama Komut-->
                <div class="komut1"> 
                    <asp:ImageButton ID="ImageButton10" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="1200px-Wikipedia-logo-v2.svg.png" OnClick="ImageButton10_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label26" runat="server" Text=".wiki" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label27" runat="server" Text="Wikipedia Search" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                 <!--Yaay Arama Komut-->
                <div class="komut2"> 
                    <asp:ImageButton ID="ImageButton11" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="unnamed.png" OnClick="ImageButton11_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label28" runat="server" Text=".y" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label29" runat="server" Text="Yaay" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>

                 <!--Quora Arama Komut-->
                <div class="komut1"> 
                    <asp:ImageButton ID="ImageButton12" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="185976.png" OnClick="ImageButton12_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label30" runat="server" Text=".q" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                <asp:Label ID="Label31" runat="server" Text="Quora" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" CssClass="asistan" BorderStyle="Outset">
                <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, altmetin %>" ForeColor="#517BBA" Font-Size="Small" Font-Bold="true"></asp:Label>
            </asp:Panel>

            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/burger_icon.png" CssClass="ayarlar" OnClick="ImageButton1_Click"/>
            <asp:Button ID="Button3" runat="server" Text="<%$Resources:Default, Destek %>"  CssClass="destek" ForeColor="Black" BackColor="Transparent" BorderStyle="None" OnClick="Button3_Click"/>
            <asp:Button ID="Button4" runat="server" Text="<%$Resources:Default, arama %>"  CssClass="search_engine" ForeColor="Black" BackColor="Transparent" BorderStyle="None" OnClick="Button4_Click" />


            <asp:Panel ID="Kontrol" runat="server" CssClass="kontrol" BorderStyle="Outset" BackColor="black">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat" OnClick="ImageButton2_Click"/>
                <asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, Kontrol %>" ForeColor="#517BBA" ></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Tema %>" ForeColor="#517BBA"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                 <asp:ListItem Text="<%$Resources:Default, Klasik %>" Value="Klasik"></asp:ListItem>
                 <asp:ListItem Text="<%$Resources:Default, Modern %>" Value="Modern"></asp:ListItem>
                 <asp:ListItem Text="<%$Resources:Default, Karanlık %>" Value="Karanlık"></asp:ListItem>
                 <asp:ListItem Text="<%$Resources:Default, Sanatçı %>" Value="Sanatçı"></asp:ListItem>
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
            <a href="/AddResult"><asp:Label ID="Label3" runat="server" Text="<%$Resources:Default, Sonuç %>" ></asp:Label></a>
                <br />
                <br />
            <a href="/About"><asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Hakkımızda %>"></asp:Label></a>
                <br />
                <br />
            <a href="/Contact"><asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, İletişim %>"></asp:Label></a>
                <br />
                <br />
            <a href="/Manifest"><asp:Label ID="Manifest" runat="server" Text="<%$Resources:Default, Manifesto %>"></asp:Label></a>
                <br />
                <br />
            <a href="/Blog"><asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Blog %>"></asp:Label></a>
                <br />
                <br />
            <a href="/Newspaper"><asp:Label ID="Label9" runat="server" Text="<%$Resources:Default, Gazete %>"></asp:Label></a>
                <br />
                <br />
            <a href="/Updates"><asp:Label ID="Label11" runat="server" Text="<%$Resources:Default, Güncelleme %>"></asp:Label></a>
            </asp:Panel>
         </div>
    </form>
</body>
</html>
