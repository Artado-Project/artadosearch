<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Topluluk_Servisler_Home_Games" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Games.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Oyunlarımız</title>
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

        <div class="içerik">
            <h2>Oyunlarımız</h2>
            <br /> 
            <a href="https://play.google.com/store/apps/details?id=com.Artado.BombSpace">Bomb!Space</a>
            <br />
            Bomb!Space, Artado Software tarafından yapılmış ilk yapımdır. Bomb!Space serisinin ilk oyunudur. Oyunu Google Play Store'dan indirebilirsiniz.
            <br />
            Çıkış Tarihi: 25 Eylül 2019
            <br />
            <br />
            <br />

            <a href="https://play.google.com/store/apps/details?id=com.ArtadoYazlm.Milovat">Milovat (Beta)</a>
            <br />
            Game Jam sırasında yapılmış bir 2D platform oyunudur. Geliştirme süreci bitmemiştir.  Oyunu Google Play Store'dan indirebilirsiniz.
            <br />
            <br />
            Oyunun Açıklaması:
            <br />
            <br />
            Hayatının aşkını kaybeden karakterimize yardım edin! Sevenleri birleştirin! Oyunumuzun 3 farklı sonu vardır.Oyunumuz Beta düzeyindedir. Bu yüzden oynanış süresi kısadır.Sizin yorumlarınız ile oyunumuzu geliştireceğiz.
            <br />
            <br /> 
            Çıkış Tarihi: 4 Haziran 2020
            <br />
            <br />
            <br />

            <a href="https://play.google.com/store/apps/details?id=com.Artado.BombSpaceENIX">Bomb!Space ENIX</a>
            <br />
            Bomb!Space serisinin ikinci oyunudur.  Oyunu Google Play Store'dan indirebilirsiniz.
            <br />
            <br />
            Oyunun Açıklaması:
            <br />
            <br />
            İşte karşınızda yeni Bomb!Space sürümü Bomb!Space ENIX! Bir Artado Yazılım klasiği olan Bomb!Space'in yepyeni bir versiyonu. Oynanış,tasarım ve diğer birçok şeyi değiştirdik ve sizin için en iyi hale getirdik.
            <br />
            <br />
            ÖZELLİKLER
            <br />
           -Geliştirilmiş oynanış mekanikleri
            <br />
           -İngilizce ve Türkçe dil desteği
            <br />
           -Sınırsız uzay macerası!
            <br />
            <br />
            <br />

           NASIL OYNANIR?
            <br />
            <br />
           -Parmağınız ile veya ekranın sağ ve sol kısımlarına basarak geminizi koruyabilirsiniz.
            <br />
           -Ekrana dokunduğunuzda ateş edeceksiniz.
            <br />
            <br /> 
            Çıkış Tarihi: 2 Temmuz 2020
            <br />
            <br />
            <br />


             <a href="https://play.google.com/store/apps/details?id=com.ArtadoYazlm.BombSpaceRUN">Bomb!Space RUN</a>
            <br />
            Bomb!Space serisinin üçüncü oyunudur. İlk iki oyundan farklı bir tarz denenmiştir. Oyunu Google Play Store'dan indirebilirsiniz.
            <br />
            <br />
            Oyunun Açıklaması:
            <br />
            <br />
            Bomb!Space serisinin yeni üyesi Bomb!Space RUN karşınızda! Bomb!Space serisinin Space Shooter türünde olmayan tek oyunu Bomb!Space RUN'ı şimdi indirin!
            <br />
            <br />
            Bomb!Space RUN Hikayesi
            <br />
            <br />
            Bomb!Space RUN'ın hikayesi 2. sezonun sonundan sonra yani Bomb!Space ENIX'den hemen sonrada geçmektedir. 2. sezon ile ulaştığımız Algian gezegeninin zorlu koşullarında hayatta kalmaya çalışıyoruz.
            <br />
            <br />
            <br />
            Oynanış:
            <br />
            <br />
            Ekranın sağ ve sol kısımlarına basarak sağ ve sola gidebilirsiniz. Kayalardan ve dağlardan kaçının. Detaylı oynanış için Öğretici kısmını oynayabilirsiniz.
            <br />
            <br /> 
            Çıkış Tarihi: 26 Temmuz 2020
            <br />
            <br />
            <br />

            <a href="https://artadosoftware.itch.io/lex">Lex</a>
            <br />
            Bir FPS Runner tarzı oyun olan Lex, Artado Sofftware tarafından PC platformuna geliştirilen ilk oyundur.
            <br />
            <br />
            Oyunun Açıklaması:
            <br />
            <br />
            Tamamıyla Türk yapımı olan oyunumuzu şimdi indirin! Bir FPS Runner tarzı oyun olan Lex sizi eğlenceye çağırıyor.Can sıkıntısından öldüğünüz zamanlarda Lex'le eğlenin. Hemde düşük bir ücret karşılığında! Sürekli güncellemeler ve eklentiler ile sizi kendine bağlayacak. 
            <br />
            <br />
            Bir Artado Yazılım yapımıdır.
            <br />
            <br /> 
            Çıkış Tarihi: 26 Nisan 2020
            <br />
            <br />
            <br />

            <a href="https://artadosoftware.itch.io/armedo">Armedo</a>
            <br />
            Armedo, hikaye ve strateji tabanlı RPG (Rol yapma) öğeleriyle 2D Piksel Sanat tasarımlarıyla tasarlanmış bir ülke yönetimi oyunudur. Geliştirme süreci devam etmektedir. Geliştirilmesine yeterli destek bulunamamsı sonra ara verilmiştir. Windows, MAC ve Linux cihazlarda oynanabilir.
            <br />
            <br />
            Oyunun Açıklaması:
            <br />
            <br />
           Dünyada yaşanan felaketlerin ardından insan nüfusu büyük ölçüde azalmış ve dünyanın birçok yeri zehirlenmiştir. Kalan insan nüfusu Bolan Körfezi'nde toplandı ve insanlığı yeniden canlandırmak için Dünya Barış Meclisi'ni kurdu, ancak ardından gelen kargaşanın ardından Dünya Barış Meclisi bölünmeye başladı. Büyük bir iç savaştan sonra, insanlık 4 ülkeye bölündü.
            <br />
            <br />
           Siz bu dört ülkeden birini seçiyorsunuz ve 100 gün boyunca iktidarınızı kaybetmeden ülkeyi yönetmeye çalışıyorsunuz.
            <br />
            <br />
            BETA 1.0 sürümünde desteklenen diller:
            <br />
            <br />
           -İngilizce
            <br />
           -Türkçe
            <br />
            <br /> 
            Çıkış Tarihi: 28 Ağustos 2020
            <br />
            <br />
            <br />
             <asp:Panel ID="Panel1" runat="server" CssClass="ads">
                <asp:Label ID="Label1" runat="server" Text="Reklam Alanı"></asp:Label>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
