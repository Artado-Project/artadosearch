<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Topluluk_Servisler_Home_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Hakkımızda - Artado Search</title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="../../../IMG_074.png" CssClass="image" />
            <br />
            <br />
            <asp:Button ID="Anasayfa" runat="server" Text="Anasayfa" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="Hakkımızda" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="İletişim" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="Blog" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="Destek Ol" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div class="içerik">
            <h2>Hakkımızda</h2>
            2018 yılında Arda Tahtacı tarafından kurulan Artado Software, hem mobil hem de bilgisayar platformlarında oyun, uygulama ve yazılım geliştiren Türkiye merkezli bir topluluktur. Artado Software, bir çok projesi ile interneti daha iyi bir yer haline getirmek için çabalamaktadır. Biz internetin özgür, anonim ve gizliliğe saygılı bir ortam olması için çabalıyoruz. Artado sadece bir kişi tarafından kurulan bir kurum değildir. Artado bir topluluktur ve topluluk ile birlikte gelişen yazılımlar üretmektedir. 
            <br />
            <br />


            <h3 >Artado Search Hakkında</h3>
            Artado Search sizi reklamsız ve en güvenli şekilde bilgiye ulaştırmayı hedefler. Artado Search geliştirilmeye 2020 Mayıs ayında başlanmış, 2020 sonuna doğruda test aşamasına geçmiştir. Artado Search, Artado Manifestosunu tanır ve ona göre hareket etmektedir. Kullanıcıların gizliliğine, özgürlüğüne ve anonimliğine saygı duyar ve onu korur.
            <br />
            <br />


            <h3>Rahatsız Edici Reklamlar Yok!</h3>
            Artado Search'de sizi takip eden ve aramanızı engelleyen reklamlar yok. Sadece organik sonuçlar var.
            <br />
            <br />
            Peki kazançımızı nereden kazanıyoruz? 
            <br />
            Kazançlarımızı bu sayfada olduğu gibi göze batmayan reklamlar ve ek servsiler ile kazanıyoruz. Bu servislerin belli bir gideri olduğundan dolayı bunları yapmak zorundayız ama arama kısmında hiç bir şekilde reklam yoktur ve asla olmayacaktır.
            <br />
            <br />

            <h3>Gizlilik, Güvenlik ve Toplanan Veriler</h3>
            Artado Search'de hareketleriniz izlenmez ve hareketlerinizi izleyenler engellenir. Artado Search'de sizin bize verdiğiniz kişisel veriler(E-posta bilgileri) dışında hiç bir kişisel veri toplanmaz. Sadece aradığınız veriler toplanır ve isimsiz şekilde veri tabanlarımızda saklanır. Bu veriyi toplamamızın tek amacı arama sonuçlarının kalitesini arttırmaktır.
            <br />
            <br />

            <h3>Açık Kaynak</h3>
            Artado Search ve diğer bir çok servisimiz açık kaynak kodludur. Böylece topluluktaki insanlar servislerimizin gelişmesinde katkıda bulunabilmektedir. Açık kaynak olmamızın en büyük avantajı kullanıcı gizliliğini koruduğumuzu göstermesidir. 
            <br />
            <br />

            <h3>Sadelik ve Tasarım</h3>
            Artado Search size en iyi şekilde hizmet etmek için sade bir şekilde tasarlanmış ve seçilebilir 4 tema eklenmiştir. Varsayılan Tema, Modern Temadır fakat siz isterseniz Klasik,Karanlık veya Mozaik Temayı seçebilirsiniz. Seçtiğiniz Tema yaklaşık 24 saat(bazı durumlarda daha az) boyunca sizin varsayılan temanız olur. 24 saat sonra varsayılan tema yine Modern Tema olur isterseniz temanızı tekrar değiştirebilirsiniz.
            <br />
            <br />

            <h3>Tamamıyla Kendi Verimiz</h3>
            Artado Search'ın kendi veri tabanı ve kendi interneti tarayan bot hizmetleri vardır. Botlarımız internette gezer ve sonuçları veri tabanına kaydeder. Botlarımız, siteleri belli kriterlere göre puanlayarak veri tabanımıza kaydetmektedir.
            <br />
            <br />

            <h3>Hedeflerimiz</h3>
            Bizim en büyük hedefimiz interneti herkesin özgürce bilgi alışverişi yapabildiği, kişisel verilere saygı duyulan ve fikirlerin herhangi bir sansüre maruz bırakılmadan ifade edilebildiği bir yer haline getirmektir. Bu amaç üzerinde yazılımlar ve servisler geliştiririz. Geliştirdiğimiz bir çok servis açık kaynak kodludur. Böylece toplulukta ki insanlarda yazılımların ve servislerin gelişmesinde katkı gösterebilir.
            <br />
            <br />

            <h3>Özel Teşekkür</h3>
            Aratdo Search geliştirme sürecinde yaptığı katkılardan dolayı İsmail Şenönder'e ve projenin ilerleyişi sürecinde bana en büyük desteği sunan Artado Topluluğu'na teşekkür ederim. 
            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" CssClass="ads">
                <asp:Label ID="Label2" runat="server" Text="Reklam Alanı"></asp:Label>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
