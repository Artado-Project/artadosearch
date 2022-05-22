<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updates.aspx.cs" Inherits="Topluluk_Servisler_Home_Updates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Updates.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Güncelleme Notları</title>
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
            <div style="background-color:antiquewhite; padding: 5px 5px 5px 5px; border-top-left-radius: 5px;  border-top-right-radius: 5px;   border-bottom-left-radius: 5px; border-bottom-right-radius: 5px;">
                <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Dikkat %>" Font-Bold="true"></asp:Label> 
            </div>
            <br />
            <h2>Güncelleme Notları</h2>
            <div id="beta" style="margin-bottom:100px;margin-top:20px;">
                <h3>Artado Beta 1.1 Güncellemesi - 20 Ağustos 2021</h3>
                Sonunda beklenen Beta 1.1 güncellemesini yayınladık. Bu güncelleme ile arama servisimiz neredeyse tamamlandı ve gerçekten bir ekosistem oluşturmaya başladık.
                Her geçen gün daha çok gelişiyoruz. Bu gidişle 2022 ortalarında Beta sürecinden çıkıp tam sürüm haline gelmeyi planlıyoruz. Tabi bu arama ve bir kaç servis için geçerli. Diğer servislerimiz belli bir süre daha beta sürecinde kalabilir.
                Bu güncelleme ile eklenenler kısaca şöyle; arayüz güncellendi, kısayollar eklendi, diğer arama motorlarının sonuçları eklendi, My Account sistemi kullanıcılara sunuldu, ArtadoBot beta test sürecine geçti ve arama dışındaki diğer servislerimiz de geliştirilmeye başlandı.
                <br />
                <br />
                <h5>Diğer Arama Motorlarının Sonuçları</h5>
                Belki de bu güncelleme ile eklenen en iyi özellik bu olabilir. Çünkü bu özellik sayesinde 7 arama motorunun veya sitenin -Github bir arama motoru değil- sonuçlarını gizliliğinizi kaybetmeden ve rahatsız edici, sonuçları bozan reklamlara maruz kalmadan görüntüleyebiliryosunuz. Bu özellik bir proxy ve reklam engelleyicinin karışımı gibi bir şey. Gelin nasıl çalıştığına bakalım.
                <br />
                <br />
                <img src="../../../images/Update_image1.png" />
                <br />
                <br />
                Yukarda gördüğünüz gibi bir arama yapıyorsunuz ve hangi arama motorunun sonuçlarını görmek istediğinizi seçiyorsunuz. Siz bunlardan birini seçince Artado o arama motoruna anonim bir istek yolluyor ve sonuçları alıyor. Sonra aldığı sonuçlardan reklamları görünmez yapıp kullanıcıya sunuyor. Reklamlar, CSS ile görünmez yapılıyor. Yaptığı istek tamamen anonim olduğundan kişiselleştirilmiş sonuçları almıyorsunuz. Bu özellik Google ve Artado sonuçları için geçerli değildir. Google sonuçları için Google'ın CSE teknolojisi kullanılıyor. Artado sonuçları ise direk kendi veri tabanımızdan geliyor.
                <br />
                <br />
                <h5>Vitrin ve Haberler</h5>
                Artado'da artık Vitrin ve Haberler bölümümüz var! Vitrin'de aramanızla ilgili ürünleri, Haberler bölümünde ise son dakika haberleri görebilirsiniz.
                <br />
                <br />
                <img src="../../../images/ayakkabı%20-%20Arta.png" style="margin-bottom:50px; height:500px;"/>
                <img src="../../../images/Haberler - Artado.png" style="margin-bottom:50px; height:500px;"/>
                <h5>Artado My Account</h5>
                Artado My Account hala tüm dilleri desteklemiyor. Şu anda sadece Türkçe desteği var. My Account sayesinde tüm Artado servislerini ve My Account servisini kullanan 3. parti parti servisleri tek hesap ile kullanabileceksiniz. My Account'da hiç bir veriniz izinsiz bir şekilde hiç bir 3. parti servise veya kişiye verilmez. Kullanıcıların şifreleri, şifreleme algoritması ile şifrelenerek kaydedilir.
                <br />
                <br />
                <h5>Kısayollar</h5>
                Ana sayfaya artık kısayollar eklendi. Bu kısayolların amacı diğer servislerimizi de tanıtmak ve sadece bir arama motoru değil bir ekosistem kurmaya çalıştığımızı göstermek. Şu anda sadece Proxy servisi çalışıyor fakat diğer servislerin çoğu kullanıma hazır veya temelleri tamamlandı.
                Bitmemiş bir servisi kullanıcıya sunmak istemediğimden bir yakında sayfası oluşturdum. Çok yakında o servislerinde açıldığını göreceksiniz.
                <br />
                <br />
                Bu yeniliklerin yanında ArtadoBot ve bahsetmediğim bir kaç özellik daha var. ArtadoBot hala tamamen bitmedi ama bitmeye çok yaklaştı. Çalışır durumda fakat yeterli değil. Onunla ilgili haberleri de ilerde paylaşacağım. Takipte kalın!
            </div>

            <h3>31 Mayıs ve Haziran Güncellemesi - 06.06.2021</h3>
            Artado Search 1 yaşına girdi bu yüzden büyük yenilemeler yapıldı (31 Mayıs 2021). 
            <br />31 Mayıs'ta yayınladığım güncelleme biraz eksikti bu yüzden bir kaç gün boyunca eksikleri giderdim. 6 Haziran'da yayınladığım son güncelleme ile 31 Mayıs güncellemesinin eksikleri giderildi ve yeni şeyler eklendi.
            <br />
            <br />
            -Sıralama filtreleri eklendi.
            <br />
            -Bilgi kutuları ve bilgi sonuçlarının sayısı artırıldı. 
            <br />
            -Karanlık tema yenilendi ve varsayılan tema oldu.
            <br />
            -Artado Forum açıldı.
            <br />
            -Sesle ve görselle arama teknolojileri üzerinde çalışıyorum. Tam bitmediğinden dolayı bu özellikler yayınlanmadı.
            <br />
            -Yeni arama algoritmaları üzerinde çalışıyorum. Onlarda yakında bitecek.
            <br />
            -Forum açıldığından dolayı burayı güncellemeyi bırakmayı düşünüyorum. Fakat burayı bir arşiv olarak kullanabilirim.
            <br />
            -Tasarım hataları giderildi.
            <br />
            -Artado Photon(web tarayıcısı) için bekleme listesi oluşturuldu. Listeye katılarak Artado Photon'u ilk deneyenlerden biri olabilirsiniz. Katılmak için <a href="/Photon">buraya tıklayın.</a>
            <br />
            <br />
            <br />
            <h3>Nisan-Mayıs Güncellemesi - 08.05.2021</h3>
            Genellikle burayı çok uzun sürelerde güncelliyorum. Buraya yazdığım güncellemeler 1-2 ay içinde yayınlanan güncellemelerdir.
            <br />
            -Ana Sayfa güncellendi.
            <br />
            -Logo yenilendi.
            <br />
            -15 dil desteği eklendi
            <br />
            Eklenen diller:
            <br />
            &nbsp &nbsp &nbsp &nbsp -Türkçe
            <br />
            &nbsp &nbsp &nbsp &nbsp -İngilizce
            <br />
            &nbsp &nbsp &nbsp &nbsp -Fransızca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Almanca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Azerbaycan Türkçesi
            <br />
            &nbsp &nbsp &nbsp &nbsp -İtalyanca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Rusça
            <br />
            &nbsp &nbsp &nbsp &nbsp -Çince
            <br />
            &nbsp &nbsp &nbsp &nbsp -İspanyolca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Portekizce
            <br />
            &nbsp &nbsp &nbsp &nbsp -Korece
            <br />
            &nbsp &nbsp &nbsp &nbsp -Japonca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Macarca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Bulgarca
            <br />
            &nbsp &nbsp &nbsp &nbsp -Boşnakça
            <br />
            <br />
            -Hava durumu eklendi. 6 ülke ve 180'den fazla şehrin hava durumu verisini gösterebiliyor.
            <br />
            -Puan sistemi eklendi.
            <br />
            -19.04.2021 tarihinde yaşadığımız veri kaybından sonra botlarımızı geliştirdik. Artık eski halimizden bile daha çok sonuç gösteriyoruz.
            <br />
            -Görsel arama geliştirildi.
            <br />
            -Sayfalama eklendi. Artık tek sayfada 10 sonuç görüyorsunuz.
            <br />
            -Geri Bildirim kısmı kaldırıldı. İlerde eklenebilir.
            <br />
            -Film arama eklendi.
            <br />
            -Akademik arama eklendi. 
            <br />
            -Bilgi kutularının sayıları her gün dahada artıyor. Hedefimiz sadece bir arama motorundan daha çok bilgi tabanlı bir arama motoru olmak.
            <br />
            -Blockchain teknolojisine yönelik çalışmalara başladık. İlerde bununla ilgili haberler vereceğiz.
            <br />
            -Sözlük arama kaldırıldı. Yerine Bilgi arama eklendi. Aslında aynı şeyler sadece adları değişti.
            <br />
            -Mobil cihazlar için uyumluluk artırıldı.
            <br />
            <br />
            <br />

            <h3>Mart Güncellemesi - 31.03.2021</h3>
            Uzun süredir bu sayfayı güncellemiyordum. Burayı Beta sürecine geçtikten sonra güncelleyecektim sonra çok fazla oldu güncelleyem dedim. Bir ayda bir sürü şey eklendi.
            <br />
            -Ana Sayfa güncellendi.
            <br />
            -Uyumluluk artırıldı.
            <br />
            -Hız artırıldı.
            <br />
            -Algoritma yenilendi. Artık daha fazla sonuç çıkıyor.
            <br />
            -Puan sistemi eklendi.
            <br />
            -Görsel arama ve Sözlük arama test sürecine geçildi. 
            <br />
            -Botlar yenilendi. Artık daha fazla sonuç çekiyorlar.
            <br />
            -Botlar, Sözlük arama ile entegre edildi.
            <br />
            -Geri Bildirim kısmı taşındı. Artık yukardan ulaşabilirsiniz.
            <br />
            -Bir kaç sayfa eklendi.
            <br />
            -Sayfa çevirme özelliği eklendi. Not: Bu özellikte kendi servisimizi kullanmıyoruz. Web Translator servisinden yardım alıyoruz.
            <br />
            -Bilgi kutucukları eklendi.
            <br />
            -Hesap makinesi gibi özellikler eklendi.
            <br />
            -Güvenlik açıkları giderildi.
            <br />
            ve daha bir sürü şey eklendi.
                        <br />
            <br />
            <br />


            <h3>Mini Şubat Güncellemesi - 11.02.2021</h3>
            -Arama çubuğu yenilendi
            <br />
            -Çoğu cihazlarla uyumluluk artırıldı. Artık Tabletlerde de Artado Search kullanabilir.
            <br />
            -02.02.2021 tarihinde yayınlanan Şubat Güncellemesi ile gelen hatalar düzeltildi. 
            <br />
            -Temalar yenilendi. 
            <br />
            -<a href="https://discord.gg/baj29VBkfp">Discord sunucumuzdan</a> veya <a href="/Topluluk/Servisler/İletişim/İletişim.aspx">İletişim</a> sayfasından karşılaştığınız hataları bize bildirebilirsiniz.
            <br />
            -Artado Gazete ve Blog yakında aktifleşecektir. Gazeteye şimdiden abone olursanız ilerleyen günlerde gelişmelerden anında haberdar olabilirsiniz.
            <br />
            -Ana sayfa yenilendi.
            <br />
            <br />
            <br />

            <h3>Şubat Güncellemesi - 02.02.2021</h3>
            -Hakkımızda sayfası yapıldı.
            <br />
            -İletişim sayfası yapıldı.
            <br />
            -Ana sayfa güncellendi.
            <br />
            -Gazete güncellendi.
            <br />
            -Site ekle özelliği güncellendi artık adı Sonuç Ekle.
            <br />
            -Sanatçı Teması eklendi.
            <br />
            -Güncelleme Notları eklendi.
            <br />
            -Bilgi Kutucukları güncellendi. Yakında herkes Sonuç Ekle sayfasından Bilgi Kutucuğu ekleyebilecek. Şu anda 4 tane Bilgi Kutucuğu aktif. Atatürk, Bill Gates, Aaron Swartz aramaları yaparak aktif olan Bilgi Kutucuklarını kullanabilirsiniz.
           <asp:Panel ID="Panel2" runat="server" CssClass="ads">
                <asp:Label ID="Label2" runat="server" Text="Reklam Alanı"></asp:Label>
            </asp:Panel>
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
