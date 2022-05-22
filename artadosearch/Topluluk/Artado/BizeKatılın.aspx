<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BizeKatılın.aspx.cs" Inherits="Topluluk_Artado_BizeKatılın" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="BizeKatılın.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Özgür İnternet'e hoşgeldin!</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <img src="./../IMG_074.png" class="image" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Artado Search" class="button" OnClick="Button1_Click" BorderStyle="None"/>
            <asp:Button ID="Button2" runat="server" Text="Hakkında" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol" class="button2" OnClick="Button3_Click" BorderStyle="None"/>
        </div>

        <div style="text-align:center; max-width:500px; margin-left:auto; margin-right:auto;">
            <br />
            <h1>Özgür İnternet'e hoşgeldin!</h1>
            <h2>Artado ile artık gizliliğini geri kazandın! Bizi seçerek interneti özgürleştirmemize yardım ettiğin için teşekkür ederiz. Sadece bir kaç adım kaldı. Ondan sonra tamamen Artado'ya geçmiş olacaksın!</h2>
            <br />
            <br />
            <br />
        </div>

         <div class="search_txt">
            <img src="/Topluluk/Artado/Arama.jpg" class="search"/>
                Artado'yu kendi tarayıcınızda varsayılan yapmak için aşağıdakileri uygulayın. Bu işlem biraz uğraştırabilir eğer yapamazsanız cihazınıza tarayıcılarımızdan birini indirebilirsiniz.
                <h4>Chrome ve diğer tarayıcılar için:</h4>
                <h4>Ayarlar > Arama Motoru > Arama Motorlarını Yönet > Artado > Üç noktaya tıklayın > Varsayılan yap</h4>
                <h4>Mozilla Firefox için:</h4>
                <h4>Artado Search <a href="/Home">ana sayfasına</a> gidin > Üst tarafta yer alan adres çubuğundaki üç noktaya tıklayın > Arama Motoru ekle</h4>
                <h4>Daha sonra Seçenekler sayfasına gidin > Arama > Varsayılan arama motoru > Artado'yu seçin</h4>
            <br />
            </div>

        <div class="photon_txt">
            <img src="/Topluluk/Artado/Orion_Logo.jpg" class="photon"/>
                <h3>Artado Photon tarayıcısını mobil cihazınıza indirin!</h3>
                Artado Photon, mobil cihazlara göre tasarlanmış, açık kaynak kodlu, güvenli, anonim bir internet tarayıcısıdır. Yakın bir zamanda Google Play ve App Store üzerinden indirebileceksiniz.
                <h4>Anonim Gezinti</h4>
                Artado Photon, kendi içinde olan proxy servisi sayesinde internette özgürce dolaşabilir ve sansürlenen sitelere girebilirsimiz.
                <h4>Rahatsız edici reklamlardan kurtulun!</h4>
                Artado Photon'un kendine ait bir reklam engelliyicisi vardır. Bu reklam engelliyici sayesinde rahatsız edici reklamlardan kurtulabilirsiniz.
            <br />
            <br />
            <br />
            <br />
            <br />
            </div>

        <div class="search_txt">
            <img src="/Topluluk/Artado/Browser.jpg" class="search"/>
                <h2>Z1DE Browser'ı bilgisayarınıza indirin!</h2>
                Z1DE Browser, Z1DE Software tarafından geliştirilen, varsayılan arama motoru Artado olan bir masaüstü internet tarayıcısıdır. Gizliliğinize, anonimliğinize ve özgürlüğünüze saygı duyar. Hala geliştirilmektedir. Yakın bir zamanda Beta sürümü yayınlanacaktır.
                <h4>Artado Tarafından Önerilir</h4>
                Z1DE Browser, Artado Manifestosuna uyar. Artado Photon ile benzer özellikler içermektedir.
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </div>

            <div style="text-align:center;">
                 Artado Software 2021
                <br />
                <h5>Güvenli, Anonim ve Özgür!</h5>
            </div>    
    </form>
</body>
</html>
