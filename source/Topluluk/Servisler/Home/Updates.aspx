<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updates.aspx.cs" Inherits="Topluluk_Servisler_Home_Updates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Updates.css" rel="stylesheet" />
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
            <h3>Gelen öneriler üzerine böyle bir sayfa açmaya karar verdik. Blog tamamen açılana kadar bu sayfadan güncellemeler ile nelerin eklendiği yazılacaktır. Önerileriniz için teşekkür ederiz sizin sayenizde her gün daha çok gelişiyoruz.</h3>
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
