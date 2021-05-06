<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Topluluk_Servisler_Home_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="About.css" rel="stylesheet" />
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
            2018 yılında kurulan Artado Software, hem mobil hem de bilgisayar platformlarında oyun, uygulama ve yazılım geliştiren Türkiye merkezli bir ekiptir. Özellikle Artado Search adlı arama motoru projemiz ile tanınırız.
            <br />
            <br />


            <h3 >Artado Search Hakkında</h3>
            Artado Search sizi reklamsız ve en güvenli şekilde bilgiye ulaştırmayı hedefler. Artado Search geliştirilmeye 2020 Mayıs ayında başlanmış, 2020 sonuna doğruda test aşamasına geçmiştir. Artado Search hala test aşamasındadır. Yakında test aşaması bitecek ve Beta aşamasına geçilecektir. Test aşaması halka açık bir şekilde yürütülmektedir böylece kullanıcılar canlı olarak gelişmeyi görebilmektedir. Herhangi bir aksaklık olmazsa Artado Search Beta aşamasına 2021 Şubat ayında geçilecektir.
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

            <h3>Sadelik ve Tasarım</h3>
            Artado Search size en iyi şekilde hizmet etmek için sade bir şekilde tasarlanmış ve seçilebilir 4 tema eklenmiştir. Varsayılan Tema, Modern Temadır fakat siz isterseniz Klasik,Karanlık veya Mozaik Temayı seçebilirsiniz. Seçtiğiniz Tema yaklaşık 24 saat(bazı durumlarda daha az) boyunca sizin varsayılan temanız olur. 24 saat sonra varsayılan tema yine Modern Tema olur isterseniz temanızı tekrar değiştirebilirsiniz.
            <br />
            <br />

            <h3>Yerlilik</h3>
            Not: Normalde Artado Search'ın yerli olmasıyla değil kalitesi ile öne çıkmasını istiyoruz ama yalan haberler ve iftiraları engellemek için bu kısmı yazmak gerektiğine karar verdik.
            <br />
            <br />
            Artado Search tamamen Arda Tahtacı tarafından tasarlanmış,programlanmış ve yayınlanmıştır. Türkiye'de geliştirilmiştir. Sunuclar farklı ülkededir ama zaten önemli bir kişisel veri toplamadığımızdan bunun fazla önemi yoktur. Artado Search kar amacı ile yapılmamıştır. Arama kısmı dışında(arama kısmında hiç bir şekilde reklam yoktur.) koyulan reklamlar giderleri karşılayabilmek içindir.
            <br />
            <br />
            Artado Search'ın kendi veri tabanı ve kendi interneti tarayan bot hizmetleri vardır. (Botlar aktif değildir. Bot servisi geliştirilmektedir. Bu sürede başka bir sistem tarafından kendi veri tabanımızı büyütmekteyiz. Bu sistemde tarafımızca yazılmıştır.)  Sadece Ek Sonuçlar kısmında aradığınızı kendi sonuçlarımızda bulamazsanız diye başka arama motorlarından veriler çekilir.
            <br />
            <br />

            <h3>Hedeflerimiz</h3>
            İlk iki yıl(2021-2022) Türkiye Arama Motoru pazarında %0.5 veya altı bir paya ulaşmayı hedefliyoruz. Sonraki bir yıl ise %0.5 ve %1 arası bir pazar hedefimiz var. 2024 ile 2026 yıllarında %5 pay üstü hedefimiz var. 2026'dan 2030'a kadar Türkiye pazarının en az yarısını almayı hedefliyoruz. 2030'a kadar Türkiye kendi arama motorunu dünyaya pazarlayabilecek konuma gelmesini hedefliyoruz. Türkiye pazarından sonra Avrupa'da %10 civarı Azerbaycan'da ise %40 paya ulaşmak hedefimiz. 
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
