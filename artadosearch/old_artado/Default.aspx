<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ErrorPage="~/404.aspx"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="search" type="application/opensearchdescription+xml" href="https://www.artadosearch.com/opensearch.xml" title="Artado Search"/>
<link href="text.css" rel="stylesheet" media="screen"/>
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
<link href="https://www.artadosearch.com/" rel="canonical"/>
<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<meta name="keywords" content="arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, açık kaynak, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, tarayıcı, browser, celer" />
<meta name="description" content="Open Source, Private and Customizable Search Engine" />
<meta property="og:title" content="Artado Search" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artadosearch.com" />
<meta property="og:description" name="description" class="swiftype" content="Open Source, Private and Anonymous Search Engine"/>
<meta name="twitter:card" content="summary_large_image" />
<meta name="twitter:title" content="Artado Search" />
<meta name="twitter:description" content="Open Source, Private and Anonymous Search Engine" />
<meta name="twitter:url" content="https://www.artadosearch.com/" />
<meta name="twitter:image" content="https://www.artadosearch.com/Icons/privacy.jpg" />
<title>Artado Search</title>
</head>
<body id="bdy1" runat="server" style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
<form id="form1" runat="server">

<!--Arda Tahtacı tarafından tasarlanmış ve programlanmıştır.-->

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="min-height:98%">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="ProfilePic" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
<asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
<asp:AsyncPostBackTrigger ControlID="Command" EventName="Click" />
</Triggers>
<ContentTemplate> 
<div id="arama" class="orta"> 
<asp:Panel ID="Panel1" runat="server" BackColor="Transparent">
<asp:Image ID="Image1" runat="server" CssClass="auto-style1"/>
<asp:Panel ID="Normal" runat="server" CssClass="arama" BorderStyle="Outset" style="margin-top:0px; margin-bottom:10px;">
<asp:TextBox ID="arama_çubugu" type="search" placeholder="<%$Resources:Default, Arama_çubuğu %>" runat="server" TextMode="Search"  BorderStyle="None" autofocus AutoCompleteType="Search" ValidateRequestMode="Disabled"></asp:TextBox>
<asp:ImageButton ID="Search" runat="server" Height="35px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.svg" Width="35px"  BorderStyle="None"/>
</asp:Panel>
</asp:Panel>

<asp:Panel ID="Araçlar" runat="server" CssClass="araçlar" Visible="false">
<h5 style="font-size:small; font-style:italic; color:#517BBA; float:left;">Arama Araçları</h5>
<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat"/>
<br />
<div class="komut2">
<asp:ImageButton ID="Voice" runat="server" Height="30px" style="float:left; outline:none; margin-left:10px; margin-bottom:10px;" ImageUrl="~/voice-search.png" Width="20px"  BorderStyle="None" OnClick="Voice_Click"/>
<asp:Label ID="Label13" runat="server" Text="Sesle Arama" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<div class="komut2"> 
<asp:ImageButton ID="Command" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="~/com_icon.png" BorderStyle="None" OnClick="Command_Click" />
<asp:Label ID="Label14" runat="server" Text="Komutlarla Arama" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<div class="komut2"> 
<asp:ImageButton ID="Visual" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="~/visual-search.png" BorderStyle="None" OnClick="Voice_Click" />
<asp:Label ID="Label15" runat="server" Text="Görsel Arama" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

</asp:Panel>

<asp:Panel ID="komutlar" runat="server" CssClass="komutlar" Visible="false">
<h5 style="font-size:small; font-style:italic; color:#517BBA; float:left;">Özel Komutlarla arama</h5>
<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat"/>
<br />

<!--DuckDuckGo Arama Komut-->
<div class="komut1">  
<asp:ImageButton ID="ImageButton13" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="DDG-icon_256x256.png" OnClick="ImageButton3_Click" />
<asp:Label ID="Label4" runat="server" Text=".ddg" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label32" runat="server" Text="DuckDuckGo" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>
        
<!--Google Arama Komut-->
<div class="komut2"> 
<asp:ImageButton ID="ImageButton14" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="178-1783296_g-transparent-circle-google-logo.png" OnClick="ImageButton4_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label33" runat="server" Text=".g" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label34" runat="server" Text="Google Search" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Youtube Arama Komut-->
<div class="komut2">
<asp:ImageButton ID="ImageButton15" runat="server" style="width:40px; height:30px; float:left; outline:none;" ImageUrl="1024px-YouTube_full-color_icon_(2017).png" OnClick="ImageButton5_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label35" runat="server" Text=".yt" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label36" runat="server" Text="Youtube" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Instagram Arama Komut-->
<div class="komut1"> 
<asp:ImageButton ID="ImageButton16" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="instagram-icon-png-file-instagram-icon-png-599.png" OnClick="ImageButton6_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label37" runat="server" Text=".i" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label38" runat="server" Text="Instagram" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Reddit Arama Komut-->
<div class="komut2"> 
<asp:ImageButton ID="ImageButton17" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="2018_social_media_popular_app_logo_reddit-512.png" OnClick="ImageButton7_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label39" runat="server" Text=".r" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label40" runat="server" Text="Reddit" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Ekşi Sözlük Arama Komut-->
<div class="komut1">
<asp:ImageButton ID="ImageButton18" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="ilogo_fbv2.png" OnClick="ImageButton8_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label41" runat="server" Text=".eksi" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label42" runat="server" Text="Ekşi Sözlük" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Twitter Arama Komut-->
<div class="komut2"> 
<asp:ImageButton ID="ImageButton19" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="image%20(1).png" OnClick="ImageButton9_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label43" runat="server" Text=".t" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label44" runat="server" Text="Twitter" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Wikipedia Arama Komut-->
<div class="komut1"> 
<asp:ImageButton ID="ImageButton20" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="1200px-Wikipedia-logo-v2.svg.png" OnClick="ImageButton10_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label45" runat="server" Text=".wiki" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label46" runat="server" Text="Wikipedia Search" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Yaay Arama Komut-->
<div class="komut2"> 
<asp:ImageButton ID="ImageButton21" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="unnamed.png" OnClick="ImageButton11_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label47" runat="server" Text=".y" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label48" runat="server" Text="Yaay" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>

<!--Quora Arama Komut-->
<div class="komut1"> 
<asp:ImageButton ID="ImageButton22" runat="server" style="width:40px; height:40px; float:left; outline:none;" ImageUrl="185976.png" OnClick="ImageButton12_Click" />&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label49" runat="server" Text=".q" Font-Bold="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
<asp:Label ID="Label50" runat="server" Text="Quora" Font-Italic="true" Font-Size="Small" ForeColor="#517BBA" CssClass="öneritxt"></asp:Label>
</div>
</asp:Panel>
<br />
<asp:Label ID="Label12" runat="server" Text="Label" Font-Size="Small"></asp:Label>
</div>

<%--<input type="image" src="/Icons/burger_icon.png" class="ayarlar" onclick="Show()"/>--%>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/burger_icon.png" CssClass="ayarlar" OnClick="ImageButton1_Click"/>
<asp:ImageButton ID="ProfilePic" runat="server" CssClass="login" OnClick="ProfilePic_Click"/>
<asp:Button ID="Button1" runat="server" Text="<%$Resources:Default, Destek %>"  CssClass="destek" ForeColor="Black" BackColor="Transparent" BorderStyle="None" OnClick="Button3_Click"/>
<asp:Button ID="Button2" runat="server" Text="<%$Resources:Default, Oturum %>"  CssClass="login" ForeColor="Black" BackColor="SkyBlue" BorderStyle="None" OnClick="Button2_Click1"/>

<div id="Kontrol" runat="server" class="kontrol">
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat" OnClick="ImageButton2_Click"/>
<asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, Kontrol %>" ForeColor="#517BBA" ></asp:Label>
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Tema %>" ForeColor="#517BBA"></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
<asp:ListItem Text="<%$Resources:Default, Night %>" Value="Night"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Klasik %>" Value="Klasik"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Karanlık %>" Value="Dark"></asp:ListItem>
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="<%$Resources:Default, Lang %>" ForeColor="#517BBA"></asp:Label>
<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
<asp:ListItem Text="<%$Resources:Default, İngilizce %>" Value="en-US"></asp:ListItem>
<asp:ListItem Text="<%$Resources:Default, Türkçe %>" Value="tr-TR"></asp:ListItem>
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
<asp:Label ID="Label18" runat="server" Text="<%$Resources:Default, Artado1 %>" ForeColor="#517BBA"></asp:Label> &nbsp;&nbsp;
<asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
<asp:ListItem Value="Google">Google</asp:ListItem>
<asp:ListItem Value="Artado">Artado</asp:ListItem>
<asp:ListItem Value="Bing">Bing</asp:ListItem>
<asp:ListItem Value="Yahoo">Yahoo</asp:ListItem>
<asp:ListItem Value="Petal">Petal Search</asp:ListItem>
<asp:ListItem Value="Baidu">Baidu</asp:ListItem>
<asp:ListItem Value="Youtube">Youtube</asp:ListItem>
<asp:ListItem Value="İzlesene">İzlesene</asp:ListItem>
<asp:ListItem Value="Github">Github</asp:ListItem>
<asp:ListItem Value="Scholar">Google Scholar</asp:ListItem>
<asp:ListItem Value="Base">BASE</asp:ListItem>
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
<a href="/Celer" style="text-decoration:none;"><asp:Label ID="Label9" runat="server" Text="Celer Browser"></asp:Label></a>
<br />
<br />
<a href="/Updates" style="text-decoration:none;"><asp:Label ID="Label11" runat="server" Text="<%$Resources:Default, Güncelleme %>"></asp:Label></a>
<br />
<br />
<a href="/Privacy" style="text-decoration:none;"><asp:Label ID="Label25" runat="server" Text="<%$Resources:Default, Politika %>"></asp:Label></a>
<br />
<br />
<a href="https://github.com/ardatdev/artadosearch-source" style="text-decoration:none;"><asp:Label ID="Label16" runat="server" Text="Github"></asp:Label></a>
</div>
</ContentTemplate>
</asp:UpdatePanel>
    <style>
        @media screen and (min-width: 600px) {
            .shortcut1 {
                float: left;
                margin-right: 50px;
                margin-left: 150px;
                margin-bottom: 20px;
                text-decoration: none;
            }
            .shortcut2 {
                float: left;
                margin-right: 50px;
                margin-bottom: 20px;
                text-decoration: none
            }
            .shortcut3 {
                float: left;
                margin-right: 50px;
                margin-right: 150px;
                margin-bottom: 20px;
                text-decoration: none
            }
        }
        @media screen and (min-width: 100px) and (max-width: 600px) {
            #shortcuts{
                text-align:center;
                margin-right:auto;
                margin-left:auto;
                max-width:330px;
            }
            #shortcuts a{
                float: left;
                margin-right: 18px;
                margin-bottom: 20px;
                text-decoration: none
            }
            #shortcuts1{
                text-align:center;
                margin-left:25px;
            }
        }
    </style>

<asp:Panel ID="Journal" runat="server">
    <script type="text/javascript">
        var d, h, m, s, animate;
        function init() {
            d = new Date();
            h = d.getHours();
            m = d.getMinutes();
            s = d.getSeconds();
            clock();
        };
        function clock() {
            s++;
            if (s == 60) {
                s = 0;
                m++;
                if (m == 60) {
                    m = 0;
                    h++;
                    if (h == 24) {
                        h = 0;
                    }
                }
            }
            $('sec', s);
            $('min', m);
            $('hr', h);
            animate = setTimeout(clock, 1000);
        };
        function $(id, val) {
            if (val < 10) {
                val = '0' + val;
            }
            document.getElementById(id).innerHTML = val;
        };
        window.onload = init;
    </script>
<asp:Panel ID="Time" runat="server" CssClass="left">
    <asp:Label ID="Label22" runat="server" Text="<%$Resources:Default, Saat %>" Font-Size="Large"></asp:Label>
    <br />
    <div style="font-size:x-large">
            <span id="hr">00</span>
    <span> : </span>
    <span id="min">00</span>
    <span> : </span>
    <span id="sec">00</span>
    </div>
</asp:Panel>

<asp:Panel ID="HavaDurumu" runat="server" CssClass="right" BorderStyle="Groove"> 
<asp:Label ID="City" runat="server" Text='' Font-Size="Large"></asp:Label>
<br />
<asp:Image ID="HavaImg" runat="server" CssClass="ınfoimage" Width="100px" Height="100px"/>
<asp:Label ID="SıcaklıkTxt" runat="server" Text='' Font-Size="Larger" Font-Bold="true"></asp:Label>&nbsp;
<asp:Label ID="DurumTxt" runat="server" Text='' Font-Size="Medium"></asp:Label>
<br />
<asp:Label ID="Min" runat="server" Text='' Font-Size="Medium"></asp:Label>
<br />
<asp:Label ID="Max" runat="server" Text='' Font-Size="Medium"></asp:Label>
<br />
<asp:Label ID="Hissedilen" runat="server" Text='' Font-Size="Medium"></asp:Label>
<br />
<asp:Label ID="Doğuş" runat="server" Text='' Font-Size="Medium"></asp:Label>
<br />
<asp:Label ID="Batış" runat="server" Text='' Font-Size="Medium"></asp:Label>
</asp:Panel>
<asp:Panel ID="Panel4" runat="server" CssClass="left" BorderStyle="Groove">
<asp:Label ID="Label17" runat="server" Text="<%$Resources:Default, Bilgi Kutusu %>" Font-Size="Large"></asp:Label>
<asp:DataList ID="InfoBox" runat="server">
<ItemTemplate>
<asp:Label ID="title" runat="server" Text='<%# Eval("InfoTitle") %>' Font-Size="Larger" Font-Bold="true"></asp:Label>
<asp:Image ID="Pic" runat="server" src='<%# Eval("Pic") %>' CssClass="ınfoimage"/>
<br />
<asp:Label ID="Label17" runat="server" Text='<%# Eval("Category") %>' Font-Size="Small"></asp:Label>
<br />
<br />
<asp:Label ID="Label8" runat="server" Text='<%# Eval("Info") %>' Font-Size="Medium"></asp:Label>
<br /> 
<a href='<%# Eval("InfoLink") %>' target="_blank" rel="nofollow"><asp:Label ID="Label9" runat="server" Text="Daha fazla" Font-Size="Small"></asp:Label></a>
</ItemTemplate>
</asp:DataList>
</asp:Panel>
<asp:Panel ID="ShortManifest" runat="server" CssClass="right" BorderStyle="Groove"> 
<asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, Manifesto1 %>" Font-Bold="true" Font-Size="Large"></asp:Label><br />
<asp:Label ID="Label23" runat="server" Text="<%$Resources:Default, Manifesto2 %>"></asp:Label>
</asp:Panel>
</asp:Panel>
</div>
</form>
</body>
</html>