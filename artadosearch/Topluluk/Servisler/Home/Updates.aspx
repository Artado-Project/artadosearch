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
            <asp:Button ID="Anasayfa" runat="server" Text="Anasayfa" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="Hakkımızda" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="İletişim" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="Blog" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="Destek Ol" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div class="içerik">
            <h2>Güncelleme Notları</h2>
            <h5>Gelen öneriler üzerine böyle bir sayfa açmaya karar verdim. Blog tamamen açılana kadar bu sayfadan güncellemeler ile nelerin eklendiği yazılacaktır. Önerileriniz için teşekkür ederiz sizin sayenizde her gün daha çok gelişiyoruz.</h5>
            <br />
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
