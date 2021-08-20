<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manifest.aspx.cs" Inherits="Topluluk_Servisler_Home_Manifest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Manifesto.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Manifestosu</title>
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
            <h1>Artado Manifestosu</h1>
            <br />
            <h4>Günümüzde internet en büyük iletişim ve bilgi alışveriş aracı. İnternet sayesinde yeni insanlarla tanışabiliyor, yeni bilgiler öğrenebiliyor ve tecrübelerimizi insanlarla paylaşabiliyoruz. İnternet şu ana kadar insan ırkının yaptığı en büyük icatlardan biridir. İnternet hayatımızı kolaylaştırıyor. Ne yazık ki bu büyük icada herkes özgürce erişememekte. Biz internetin herkes tarafından özgürce erişebilmesini istiyoruz. İnternet hiç bir güç veya otorite tarafından kısıtlanmamalı. 
            İnternetteki bilgi birikimine özgürce erişebilmek bireylerin hakkıdır. </h4>

            <br />
            <br />
            <h1>Biz herkesin özgürce bilgi alışverişi yapabildiği, kişisel verilere saygı duyulan ve fikirlerin herhangi bir sansüre maruz bırakılmadan ifade edilebildiği bir interneti savunuyoruz.</h1>
            <br />
            <br />
            <br />
            <h2>Neden Özgür İnternet?</h2>
            İnsanların herhangi bir şeyi en hızlı ve en etkili olarak sadece internet üzerinden paylaşabilir. İnternet sayesinde çok hızlı bir şekilde milyonlar ile iletişim kurabilirsiniz. İnternet, halkın sesinin en iyi şekilde çıkarabileceği araçtır. Bu yüzden internet herkes tarafından özgürce erişebilmelidir.
            <br />
            <br />
            Fikir özgürlüğü, demokrasinin temellerinden biridir. Demokrasi ile yönetilen ülkelerde fikir özgürlüğünün kısıtlanması, demokrasiye ve halka ihanettir. Fikir özgürlüğü, sadece demokratik ülkelerde değil bütün insanlık çapında bir hak olmalıdır. İnternet bu hakkın yerine getirlebilmesi için bir araçtır. Bu aracı kısıtlamak bireyin en temel haklarından birini yok saymaktır. 
           <br />
           <br />
           <br />
            <h2>Anonimlik</h2>
            İnternetin bireylere kattığı en önemli şeylerden biride anonimliktir ama anonimlik suistimal edilip kötüye kullanılabiliyor. Bunun çözümü interneti kısıtlamak veya anonimliği tamamen kaldırmak değildir. Bunun en temel ve kesin çözümü eğitim ve adaleti sağlamaktır.
            <br />
            <br />
            Fikir özgürlüğünü iyi bir şekilde sağlanan eğitimli bir birey anonimliğe ihtiyaç duymaz. Çünkü fikirlerini düzgünce belirttiğinde başına bir şey gelmeyeceğini bilir ve iyi bir eğitim aldığından anonimliği kötüye kullanmaz. Anonim bir şekilde fikir belirten bireyler genelde fikir özgürlüğü olmayan bireylerdir. Birey, başına kötü şeyler gelebileceğinden anonim bir şekilde fikir belirttir. Bunu önlemek isteyen otoritereler anonimliği kaldırmaya veya interneti kısıtlamaya çalışır.
            <br />
            <br />
            İnternetin sunduğu anonim kimlikler fikir özgürlüğü olmayan bireyler için fikir özgürlüğü sağlar.
                       <br />
           <br />
           <br />
            <h2>Gizlilik Hakkı</h2>
            Bireylerin en temel haklarından biride gizliliktir. Bireylerin kişisel verileri, internet üzerinden kullandıkları araçlar ile toplanmamalıdır. Bireyin kişisel verisi ona özeldir ve ondan izinsiz bir şekilde alınması suçtur. Artado olarak bireylerin kişisel verilerine saygı duyuyoruz ve internette özgürce gezinmek ve kişisel verileri korumak için çaba gösteriyoruz. Bireyler, kişisel verilerini korumak için doğru araçları seçme sorumluluğundadır.
                       <br />
           <br />
           <br />
            <h2>İnterneti Daha Güzel Bir Yer Yapmak İçin</h2>
            İnternet yukardaki 3 maddede yazılanlar uygulandığında gerçekten güzel bir yer olacaktır. 21. yüzyılda internet hem bir eğlence ağı, hem de bir iletişim ağıdır. İnternet, insanlığın gelişmesi için en önemli etkenlerden biridir. Artado olarak yukardaki maddeleri destekliyor ve sizi de desteklemeye davet ediyoruz. İnternet, birlik olduğumuzda daha güzel bir yer olacaktır! 
            <br />
            <br />
            <br />
            <div id="destekle" style="text-align:center; color:white;">
                <style>
                    #Button1{
                        border-top-left-radius: 10px;
        border-top-right-radius: 10px;
        border-bottom-left-radius: 10px;
        border-bottom-right-radius: 10px;
        width: 150px;
        height: 50px;
        background-color: #517BBA;
        font-family: Bahnschrift;
                    }
                </style>
                <asp:Button ID="Button1" runat="server" Text="Destekle!" ForeColor="White" BorderColor="White" OnClick="Button1_Click"/>
            </div>
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
