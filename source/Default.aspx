<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="text.css" rel="stylesheet" media="screen"/>
    <link href="bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Search - Reklamsız ve Sade Arama Motoru</title>
</head>
<body style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">

         <!--Arda Tahtacı tarafından tasarlanmış,programlanmış ve yayınlanmıştır.-->
        <a href="<%#("default.aspx")%>Anasayfa"></a>

         <div style="width:800px" class="container">
        </div>

        <div id="arama" class="orta">
            <img alt="" class="auto-style1" src="Adsız.png"  />
            <br />
            BETA
            <br />

            <asp:Panel ID="Panel1" runat="server" CssClass="arama" BorderStyle="Outset">
            <asp:TextBox ID="arama_çubugu" placeholder="İnterneti Keşfet!" runat="server" TextMode="Search"  BorderStyle="None" autofocus></asp:TextBox>
         <asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
         <asp:ImageButton ID="Voice" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/voice-search.png" Width="19px"  BorderStyle="None" OnClick="Voice_Click"/>
                </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" CssClass="asistan" BorderStyle="Outset">
                <asp:Label ID="Label5" runat="server" Text="Asistan ve sesle arama çok yakında sizlerle!" ForeColor="#517BBA" Font-Size="Small" Font-Bold="true"></asp:Label>
            </asp:Panel>

         <h2>&nbsp;</h2>
         <h2>&nbsp;</h2>
            <asp:Label ID="Label2" runat="server" Text="Reklamsız ve Güvenli Arama Motoru"></asp:Label>

            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/indir (6) (1).png" CssClass="ayarlar" OnClick="ImageButton1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Oturum Aç"  CssClass="oturum" ForeColor="White" OnClick="Button2_Click"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol"  CssClass="destek" ForeColor="White" OnClick="Button3_Click" />

            <asp:Panel ID="Kontrol" runat="server" CssClass="kontrol" BorderStyle="Outset" BackColor="black">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/indir (7).png" CssClass="kapat" OnClick="ImageButton2_Click"/>
                <asp:Label ID="Label7" runat="server" Text="Kontrol Paneli" ></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Temalar: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                 <asp:ListItem>Modern</asp:ListItem>
                 <asp:ListItem>Klasik</asp:ListItem>
                 <asp:ListItem>Karanlık</asp:ListItem>
                 <asp:ListItem>Sanatçı</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            <a href="/SonuçEkle"><asp:Label ID="Label3" runat="server" Text="Sonuç Ekle" ></asp:Label></a>
                <br />
                <br />
            <a href="ÖzelKomutlar"><asp:Label ID="Label4" runat="server" Text="Özel Komutlar"></asp:Label></a>
                <br />
                <br />
            <a href="/Hakkımızda"><asp:Label ID="Label6" runat="server" Text="Hakkımızda"></asp:Label></a>
                <br />
                <br />
            <a href="/İletişim"><asp:Label ID="Label10" runat="server" Text="İletişim"></asp:Label></a>
                <br />
                <br />
            <a href="/Blog"><asp:Label ID="Label8" runat="server" Text="Blog"></asp:Label></a>
                <br />
                <br />
            <a href="/Gazete"><asp:Label ID="Label9" runat="server" Text="Gazete"></asp:Label></a>
                <br />
                <br />
            <a href="/Güncellemeler"><asp:Label ID="Label11" runat="server" Text="Güncelleme Notları"></asp:Label></a>
            </asp:Panel>
         </div>

        <asp:Panel ID="Panel2" runat="server">
        <div id="des1" class="des1" >
            <div class="dlabel">
            <img alt="" class="polis" src="polisartalio2.png"  />  
            <br />
            <br />
            <br />
            <asp:Label ID="Başlık" runat="server" Text="Neden ArtadoSearch kullanmalıyım?" Font-Size="XX-Large" Font-Bold="true" ForeColor="White"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Açıklama" runat="server" Text="ArtadoSearch, sizi takip etmez. Verilerinizi toplamaz. Size rahatsız edici reklamlar göstermez. Size en iyi hizmeti sunmayı hedefler. ArtadoSearch güvenlidir, güvenilirdir." Font-Size="X-Large" Font-Bold="true" ForeColor="White"></asp:Label>
            </div>
        </div>
            </asp:Panel>

    </form>
</body>
</html>
