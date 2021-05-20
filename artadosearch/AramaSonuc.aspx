<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AramaSonuc.aspx.cs" Inherits="AramaSonuc" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="AramaSonuc.css" rel="stylesheet" />
    <link href="bootstrap-4.5.3-dist/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="shortcut icon" href="/Icons/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Search - Reklamsız ve Sade Arama Motoru</title>
</head>
<body>
    <form id="form1" runat="server">

        <div style= "margin-bottom:20px" class="üstkısım">
            <asp:Panel ID="Panel2" runat="server" CssClass="arama2" BorderStyle="Outset">
                 <asp:TextBox ID="arama_çubugu2" runat="server" CssClass="textbox" BorderStyle="None" TextMode="Search" ValidateRequestMode="Disabled" ></asp:TextBox>
        <asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
         <asp:ImageButton ID="Voice" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/voice-search.png" Width="19px"  BorderStyle="None"/>
                </asp:Panel>
            <asp:ImageButton ID="Image1" runat="server" CssClass="image" ImageUrl="Icons/android-chrome-192x192.png" OnClick="Image1_Click1"  /> 
            <br />
            <br />
            <asp:Button ID="Web" runat="server" Text="Web" CssClass="web" BorderStyle="None" BackColor="Transparent" OnClick="Web_Click"/>
            <asp:Button ID="Görsel" runat="server" Text="<%$Resources:Default, Görsel %>" CssClass="görsel" BorderStyle="None" BackColor="Transparent" OnClick="Görsel_Click"/>
            <asp:Button ID="Sözlük" runat="server" Text="<%$Resources:Default, Sözlük %>" CssClass="sözlük" BorderStyle="None" BackColor="Transparent" OnClick="Sözlük_Click"/>
            <asp:Button ID="Müzik" runat="server" Text="<%$Resources:Default, Film %>" CssClass="müzik" BorderStyle="None" BackColor="Transparent" OnClick="Müzik_Click"/>
            <asp:Button ID="Akademik" runat="server" Text="<%$Resources:Default, Akademik %>" CssClass="akademik" BorderStyle="None" BackColor="Transparent" OnClick="Akademik_Click"/>
                <hr class="çizgi"/>
             </div>


        <div style="margin-left:50px;">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label>
        </div>


        <asp:Panel ID="Panel3" runat="server" BorderStyle="Groove" class="iletişim">
            <asp:Label ID="İletişimBaşlık" runat="server" Text="Teşekkür ederiz!" Font-Size="Larger" Font-Bold="true" ForeColor="#517BBA"></asp:Label>
            <br />
            <asp:Label ID="İletişimAçıklama" runat="server" Text="ArtadoSearch'ı ilk kullanan kişilerden birisiniz. Bize neleri beğenip neleri beğenmediğinizi anlatırsanız size daha iyi bir hizmet sunmamızda katkı sağlarsınız." Font-Size="Medium" ForeColor="#517BBA"></asp:Label>
            <br /> 
            <asp:TextBox ID="Mail" runat="server" PlaceHolder="E-posta" BackColor="White" BorderStyle="Outset" ViewStateMode="Disabled"></asp:TextBox>
            <br />
            <br />
            <textarea id="Deneyim" runat="server" placeholder="Deneyiminizi anlatın" cols="20" rows="2" maxlenght="500"></textarea>
            <asp:Button ID="Gönder" runat="server" Text="Gönder" OnClick="Gönder_Click" />
            <asp:Label ID="Sonuc" runat="server" Text="" Font-Size="Small" Font-Bold="true"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="Panel1" runat="server" BorderStyle="Outset" CssClass="panel">
                <asp:Image ID="Image2" runat="server" CssClass="panelimage"/>
                <asp:Label ID="Ad" runat="server" Text="" Font-Bold="true"></asp:Label>
                <br />
                <asp:Label ID="Meslek" runat="server" Text="" Font-Size="Small"></asp:Label>
                <br />
                <asp:Label ID="Doğum" runat="server" Text=""></asp:Label>
            </asp:Panel>

         <asp:Panel ID="Panel4" runat="server" CssClass="ınfo" BorderStyle="Groove">
            <asp:DataList ID="InfoBox" runat="server">
                <ItemTemplate>
                        <asp:Label ID="title" runat="server" Text='<%# Eval("InfoTitle") %>' Font-Size="Larger" Font-Bold="true"></asp:Label>
                        <asp:Image ID="Pic" runat="server" src='<%# Eval("Pic") %>' CssClass="ınfoimage"/>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Info") %>' Font-Size="Medium"></asp:Label>
                        <br /> 
                        <a href='<%# Eval("InfoLink") %>' target="_blank"><asp:Label ID="Label9" runat="server" Text="Daha fazla" Font-Size="Small"></asp:Label></a>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>

         <asp:Panel ID="HavaDurumu" runat="server" CssClass="ınfo" BorderStyle="Groove"> 
             <asp:DropDownList ID="Ülkeler" runat="server" AutoPostBack="True">
                 <asp:ListItem>Türkiye</asp:ListItem>
                 <asp:ListItem>İngiltere</asp:ListItem>
                 <asp:ListItem>Fransa</asp:ListItem>
                 <asp:ListItem>Almanya</asp:ListItem>
                 <asp:ListItem>Azerbaycan</asp:ListItem>
                 <asp:ListItem>KKTC</asp:ListItem>
             </asp:DropDownList>
             <br />
             <br />
             <asp:DropDownList ID="İllerTR" runat="server" AutoPostBack="True">
                 <asp:ListItem>Ankara</asp:ListItem>
                 <asp:ListItem>Adana</asp:ListItem>
                 <asp:ListItem>Adıyaman</asp:ListItem>
                 <asp:ListItem>Afyonkarahisar</asp:ListItem>
                 <asp:ListItem>Ağrı</asp:ListItem>
                 <asp:ListItem>Aksaray</asp:ListItem>
                 <asp:ListItem>Amasya</asp:ListItem>
                 <asp:ListItem>Antalya</asp:ListItem>
                 <asp:ListItem>Ardahan</asp:ListItem>
                 <asp:ListItem>Artvin</asp:ListItem>
                 <asp:ListItem>Aydın</asp:ListItem>
                 <asp:ListItem>Balıkesir</asp:ListItem>
                 <asp:ListItem>Bartın</asp:ListItem>
                 <asp:ListItem>Batman</asp:ListItem>
                 <asp:ListItem>Bayburt</asp:ListItem>
                 <asp:ListItem>Bilecik</asp:ListItem>
                 <asp:ListItem>Bingöl</asp:ListItem>
                 <asp:ListItem>Bitlis</asp:ListItem>
                 <asp:ListItem>Bolu</asp:ListItem>
                 <asp:ListItem>Burdur</asp:ListItem>
                 <asp:ListItem>Bursa</asp:ListItem>
                 <asp:ListItem>Çanakkale</asp:ListItem>
                 <asp:ListItem>Çankırı</asp:ListItem>
                 <asp:ListItem>Çorum</asp:ListItem>
                 <asp:ListItem>Denizli</asp:ListItem>
                 <asp:ListItem>Diyarbakır</asp:ListItem>
                 <asp:ListItem>Düzce</asp:ListItem>
                 <asp:ListItem>Edirne</asp:ListItem>
                 <asp:ListItem>Elazığ</asp:ListItem>
                 <asp:ListItem>Erzincan</asp:ListItem>
                 <asp:ListItem>Erzurum</asp:ListItem>
                 <asp:ListItem>Eskişehir</asp:ListItem>
                 <asp:ListItem>Gaziantep</asp:ListItem>
                 <asp:ListItem>Giresun</asp:ListItem>
                 <asp:ListItem>Gümüşhane</asp:ListItem>
                 <asp:ListItem>Hakkari</asp:ListItem>
                 <asp:ListItem>Hatay</asp:ListItem>
                 <asp:ListItem>Iğdır</asp:ListItem>
                 <asp:ListItem>Isparta</asp:ListItem>
                 <asp:ListItem>İstanbul</asp:ListItem>
                 <asp:ListItem>İzmir</asp:ListItem>
                 <asp:ListItem>Kahramanmaraş</asp:ListItem>
                 <asp:ListItem>Karabük</asp:ListItem>
                 <asp:ListItem>Karaman</asp:ListItem>
                 <asp:ListItem>Kars</asp:ListItem>
                 <asp:ListItem>Kastamonu</asp:ListItem>
                 <asp:ListItem>Kayseri</asp:ListItem>
                 <asp:ListItem>Kırıkkale</asp:ListItem>
                 <asp:ListItem>Kırşehir</asp:ListItem>
                 <asp:ListItem>Kilis</asp:ListItem>
                 <asp:ListItem>Kocaeli</asp:ListItem>
                 <asp:ListItem>Konya</asp:ListItem>
                 <asp:ListItem>Kütahya</asp:ListItem>
                 <asp:ListItem>Malatya</asp:ListItem>
                 <asp:ListItem>Manisa</asp:ListItem>
                 <asp:ListItem>Mardin</asp:ListItem>
                 <asp:ListItem>Mersin</asp:ListItem>
                 <asp:ListItem>Muğla</asp:ListItem>
                 <asp:ListItem>Muş</asp:ListItem>
                 <asp:ListItem>Nevşehir</asp:ListItem>
                 <asp:ListItem>Niğde</asp:ListItem>
                 <asp:ListItem>Ordu</asp:ListItem>
                 <asp:ListItem>Osmaniye</asp:ListItem>
                 <asp:ListItem>Rize</asp:ListItem>
                 <asp:ListItem>Sakarya</asp:ListItem>
                 <asp:ListItem>Siirt</asp:ListItem>
                 <asp:ListItem>Sinop</asp:ListItem>
                 <asp:ListItem>Sivas</asp:ListItem>
                 <asp:ListItem>Şanlıurfa</asp:ListItem>
                 <asp:ListItem>Şırnak</asp:ListItem>
                 <asp:ListItem>Tekirdağ</asp:ListItem>
                 <asp:ListItem>Tokat</asp:ListItem>
                 <asp:ListItem>Trabzon</asp:ListItem>
                 <asp:ListItem>Tunceli</asp:ListItem>
                 <asp:ListItem>Uşak</asp:ListItem>
                 <asp:ListItem>Van</asp:ListItem>
                 <asp:ListItem>Yalova</asp:ListItem>
                 <asp:ListItem>Yozgat</asp:ListItem>
                 <asp:ListItem>Zonguldak</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerEN" runat="server" AutoPostBack="True">
                 <asp:ListItem>London</asp:ListItem>
                 <asp:ListItem>Belfast</asp:ListItem>
                 <asp:ListItem>Belvedere</asp:ListItem>
                 <asp:ListItem>Bexley</asp:ListItem>
                 <asp:ListItem>Bournemouth</asp:ListItem>
                 <asp:ListItem>Bromley</asp:ListItem>
                 <asp:ListItem>Brighton</asp:ListItem>
                 <asp:ListItem>Cambridge</asp:ListItem>
                 <asp:ListItem>Cardiff</asp:ListItem>
                 <asp:ListItem>Cheltenham</asp:ListItem>
                 <asp:ListItem>Coventry</asp:ListItem>
                 <asp:ListItem>Doncaster</asp:ListItem>
                 <asp:ListItem>Dover</asp:ListItem>
                 <asp:ListItem>Durham</asp:ListItem>
                 <asp:ListItem>Edinburgh</asp:ListItem>
                 <asp:ListItem>Edmonton</asp:ListItem>
                 <asp:ListItem>Exeter</asp:ListItem>
                 <asp:ListItem>Fyfield</asp:ListItem>
                 <asp:ListItem>Glasgow</asp:ListItem>
                 <asp:ListItem>Greenwich</asp:ListItem>
                 <asp:ListItem>Grimsby</asp:ListItem>
                 <asp:ListItem>Harpenden</asp:ListItem>
                 <asp:ListItem>Inverness</asp:ListItem>
                 <asp:ListItem>Leeds</asp:ListItem>
                 <asp:ListItem>Lincoln</asp:ListItem>
                 <asp:ListItem>Newham</asp:ListItem>
                 <asp:ListItem>Longford</asp:ListItem>
                 <asp:ListItem>Luton</asp:ListItem>
                 <asp:ListItem>Manchester</asp:ListItem>
                 <asp:ListItem>Merthyr Tydfil</asp:ListItem>
                 <asp:ListItem>Oldham</asp:ListItem>
                 <asp:ListItem>Oxford</asp:ListItem>
                 <asp:ListItem>Peterborough</asp:ListItem>
                 <asp:ListItem>Poole</asp:ListItem>
                 <asp:ListItem>Reading</asp:ListItem>
                 <asp:ListItem>Southampton</asp:ListItem>
                 <asp:ListItem>Southend-on-Sea</asp:ListItem>
                 <asp:ListItem>Southgate</asp:ListItem>
                 <asp:ListItem>St Albans</asp:ListItem>
                 <asp:ListItem>Stansted</asp:ListItem>
                 <asp:ListItem>Stoke-on-Trent</asp:ListItem>
                 <asp:ListItem>Stratford-upon-Avon</asp:ListItem>
                 <asp:ListItem>Swanscombe</asp:ListItem>
                 <asp:ListItem>Wallington</asp:ListItem>
                 <asp:ListItem>Waltham Cross</asp:ListItem>
                 <asp:ListItem>Waltham Forest</asp:ListItem>
                 <asp:ListItem>Watford</asp:ListItem>
                 <asp:ListItem>Welling</asp:ListItem>
                 <asp:ListItem>Wembley</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerFR" runat="server" AutoPostBack="True">
                 <asp:ListItem>Paris</asp:ListItem>
                 <asp:ListItem>Marsilya</asp:ListItem>
                 <asp:ListItem>Lyon</asp:ListItem>
                 <asp:ListItem>Toulouse</asp:ListItem>
                 <asp:ListItem>Nice</asp:ListItem>
                 <asp:ListItem>Nantes</asp:ListItem>
                 <asp:ListItem>Strasbourg</asp:ListItem>
                 <asp:ListItem>Montpellier</asp:ListItem>
                 <asp:ListItem>Bordeaux</asp:ListItem>
                 <asp:ListItem>Lille</asp:ListItem>
                 <asp:ListItem>Rennes</asp:ListItem>
                 <asp:ListItem>Reims</asp:ListItem>
                 <asp:ListItem>Le Havre</asp:ListItem>
                 <asp:ListItem>Saint-Étienne</asp:ListItem>
                 <asp:ListItem>Toulon</asp:ListItem>
                 <asp:ListItem>Grenoble</asp:ListItem>
                 <asp:ListItem>Dijon</asp:ListItem>
                 <asp:ListItem>Angers</asp:ListItem>
                 <asp:ListItem>Villeurbanne</asp:ListItem>
                 <asp:ListItem>Saint-Denis</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerDE" runat="server" AutoPostBack="True">
                 <asp:ListItem>Berlin</asp:ListItem>
                 <asp:ListItem>Bayern</asp:ListItem>
                 <asp:ListItem>Baden-Württemberg</asp:ListItem>
                 <asp:ListItem>Nordrhein-Westfalen</asp:ListItem>
                 <asp:ListItem>Hessen</asp:ListItem>
                 <asp:ListItem>Sachsen</asp:ListItem>
                 <asp:ListItem>Niedersachsen</asp:ListItem>
                 <asp:ListItem>Rheinland-Pfalz</asp:ListItem>
                 <asp:ListItem>Thüringen</asp:ListItem>
                 <asp:ListItem>Brandenburg</asp:ListItem>
                 <asp:ListItem>Sachsen-Anhalt</asp:ListItem>
                 <asp:ListItem>Mecklenburg-Vorpommern</asp:ListItem>
                 <asp:ListItem>Schleswig-Holstein</asp:ListItem>
                 <asp:ListItem>Saarland</asp:ListItem>
                 <asp:ListItem>Bremen</asp:ListItem>
                 <asp:ListItem>Hamburg</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerAZ" runat="server" AutoPostBack="True">
                 <asp:ListItem>Bakü</asp:ListItem>
                 <asp:ListItem>Ağdam</asp:ListItem>
                 <asp:ListItem>Ağdaş</asp:ListItem>
                 <asp:ListItem>Ağstafa</asp:ListItem>
                 <asp:ListItem>Ağsu</asp:ListItem>
                 <asp:ListItem>Astara</asp:ListItem>
                 <asp:ListItem>Aran</asp:ListItem>
                 <asp:ListItem>Naxçıvan</asp:ListItem>
                 <asp:ListItem>Şuşa</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerKKTC" runat="server" AutoPostBack="True">
                 <asp:ListItem>Lefkoşa</asp:ListItem>
                 <asp:ListItem>Gazimağusa</asp:ListItem>
                 <asp:ListItem>Girne</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;&nbsp;
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

        <!--Sözlük Öneri-->
       <asp:Panel ID="Panel6" runat="server" CssClass="sözlüköneri" BorderStyle="None">
            <asp:DataList ID="SozlukOneri" runat="server">
                <ItemTemplate>
                   <asp:Panel ID="Sonuclar" runat="server">
                        <asp:Label ID="title" runat="server" Text='<%# Eval("Kelime") %>' Font-Size="Larger" Font-Bold="true"></asp:Label> 
                       <br />
                       <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Anlam") %>' Font-Size="Medium"></asp:Label>
                   </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>

       <!--IP Adresi-->
       <asp:Panel ID="IPPanel" runat="server" CssClass="sözlüköneri" BorderStyle="None">
            <asp:Label ID="title" runat="server" Text='<%$Resources:Default, IP %>' Font-Size="Larger" Font-Bold="true"></asp:Label> 
            <br />
            <br />
            <asp:Label ID="IP" runat="server" Text='' Font-Size="Medium"></asp:Label> &nbsp &nbsp
            <asp:Label ID="Label9" runat="server" Text='<%$Resources:Default, Uyarı %>' Font-Size="Small"></asp:Label>
        </asp:Panel>

        <!--Hesap Makinesi-->
        <asp:Panel ID="Panel5" runat="server" GroupingText="Hesap Makinesi" CssClass="hesap"
            Width="280px">
            <table class="style1">
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TextBox1" runat="server" Height="60px" Width="250px"
                            CssClass="kutu"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button16" runat="server" Height="60px" Text="C" Width="60px" OnClick="Button16_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="Button10" runat="server" Height="60px" 
                            Text="/" Width="60px" OnClick="B10_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button11" runat="server" Height="60px" 
                            Text="*" Width="60px" OnClick="B11_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button12" runat="server" Height="60px" 
                            Text="-" Width="60px" OnClick="B12_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button7" runat="server" Height="60px" 
                            Text="7" Width="60px" OnClick="B7_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button8" runat="server" Height="60px" 
                            Text="8" Width="60px" OnClick="B8_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button9" runat="server" Height="60px" 
                            Text="9" Width="60px" OnClick="B9_Click" />
                    </td>
                    <td rowspan="2">
                        <asp:Button ID="Button13" runat="server" Height="120px" 
                            Text="+" Width="60px" OnClick="B13_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button4" runat="server" Height="60px" 
                            Text="4" Width="60px" OnClick="B4_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Height="60px" 
                            Text="5" Width="60px" OnClick="B5_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Height="60px" 
                            Text="6" Width="60px" OnClick="B6_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="60px" 
                            Text="1" Width="60px" OnClick="B1_Click1" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Height="60px" 
                            Text="2" Width="60px" OnClick="B2_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Height="60px" 
                            Text="3" Width="60px" OnClick="B3_Click" />
                    </td>
                    <td rowspan="2">
                        <asp:Button ID="Button14" runat="server" Height="120px"
                            Text="=" Width="60px" OnClick="B14_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button15" runat="server" Height="60px" 
                            Text="0" Width="199px" OnClick="B15_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>


        <!--Web Arama-->
        <div class="sonuclar">
             <asp:Panel ID="WebArama" runat="server" class="webarama">
            <asp:Repeater runat="server" ID="rptAramaSonuclari" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <asp:Panel ID="Popular" runat="server">
                            <asp:Label ID="Label11" runat="server" Text="Popüler" Font-Size="Small"></asp:Label>
                            <br />
                        </asp:Panel>
                        <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> &nbsp;
                        <a href="https://www.translatetheweb.com/?ref=SERP&br=ro&mkt=tr-TR&dl=en&lp=Auto_TR&a=<%# Eval("Link") %>" rel="nofollow" target="_blank"> <asp:Label ID="Label6" runat="server" Text='Bu sayfayı çevir' Font-Size="Small"></asp:Label></a> <br/>
                        <asp:Image ID="danger" runat="server" ImageUrl="/tehlıke.png" CssClass="danger"/>
                        <asp:Label ID="Link" runat="server" FontSize="Small" Text='<%# Eval("Link") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                        <asp:Label ID="Label3" runat="server" FontSize="Small" Text='<%# Eval("Content1") %>' Font-Size="Small"></asp:Label><br />
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                 <div style="text-align:center;">
                  <asp:Panel ID="PageSelect" runat="server">
                     <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label"></asp:Label>            
                     <br />
                     <asp:HyperLink ID="HyperLink1" runat="server">Önceki Sayfa</asp:HyperLink>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:HyperLink ID="HyperLink2" runat="server">Sonraki Sayfa</asp:HyperLink>
                 </asp:Panel>
                </div>
                 </asp:Panel>
                 </div>


        <!--Görsel Arama-->
            <asp:Panel ID="GörselArama" runat="server" class="webarama">
                <asp:DataList runat="server" ID="GorselSonuclar">
                    <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="görselsonuc">
                        <asp:Image ID="Image3" runat="server" src='<%# Eval("GörselLink") %>' CssClass="gorsel"/> <br />
                        <a href="url.aspx?Link=<%# Eval("AsılLink") %>" rel="nofollow"> <asp:Label ID="Label4" runat="server" Text='<%# Eval("GorselTitle") %>' Font-Size="Small"></asp:Label></a>
                   </asp:Panel>
                </ItemTemplate>
                </asp:DataList>
                   </asp:Panel>


        <!--Sözlük Arama-->
        <div class="sonuclar">
              <asp:Panel ID="SözlükArama" runat="server" class="webarama">
                <asp:Repeater runat="server" ID="sözlüksonuc" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <%# Eval("Kelime") %> <br />
                        <%# Eval("Anlam") %><br />
                        <a href="https://nedirara.com/" target="_blank" rel="nofollow"><asp:Label ID="Label9" runat="server" Text="Kaynak: Nedirara.com" Font-Size="Small"/></a>
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                   </asp:Panel>
        </div>
            

        <!--Film Arama-->
            <div class="sonuclar">
                <asp:Panel ID="MüzikArama" runat="server" class="webarama">
                <asp:Repeater runat="server" ID="Filmler" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <asp:Image ID="Image2" runat="server" CssClass="panelimage" ImageUrl='<%# Eval("Pic") %>'/>
                        <asp:Label ID="Title" runat="server" Text='<%# Eval("Name") %>' Font-Size="Large"></asp:Label> &nbsp;
                        <asp:Label ID="Year" runat="server" FontSize="Small" Text='<%# Eval("Year") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                        <asp:Label ID="Actors" runat="server" FontSize="Small" Text='<%# Eval("Actors") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Score" runat="server" FontSize="Small" Text='<%# Eval("Score") %>' Font-Size="Medium"></asp:Label><br />
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
          </asp:Panel>
            </div>


        <!--Akademik Arama-->
          <div class="sonuclar">
             <asp:Panel ID="Makaleler" runat="server" class="webarama">
            <asp:Repeater runat="server" ID="AkademikSonuçlar" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="akademiksonuc">
                        <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> &nbsp;
                        <a href="https://www.translatetheweb.com/?ref=SERP&br=ro&mkt=tr-TR&dl=en&lp=Auto_TR&a=<%# Eval("Link") %>" rel="nofollow" target="_blank"> <asp:Label ID="Label6" runat="server" Text='Bu sayfayı çevir' Font-Size="Small"></asp:Label></a> <br/>
                        <asp:Label ID="Link" runat="server" FontSize="Small" Text='<%# Eval("Link") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                        <asp:Label ID="Desc" runat="server" FontSize="Small" Text='<%# Eval("Description") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Label7" runat="server" FontSize="Small" Text='Yazarlar: ' Font-Size="Small"></asp:Label>
                        <asp:Label ID="Label4" runat="server" FontSize="Small" Text='<%# Eval("Author") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Label10" runat="server" FontSize="Small" Text='Yıl: ' Font-Size="Small"></asp:Label>
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                 <div style="text-align:center;">
                  <asp:Panel ID="Panel9" runat="server">
                     <asp:Label ID="Label5" runat="server" Text="Label" CssClass="label"></asp:Label>            
                     <br />
                     <asp:HyperLink ID="HyperLink3" runat="server">Önceki Sayfa</asp:HyperLink>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:HyperLink ID="HyperLink4" runat="server">Sonraki Sayfa</asp:HyperLink>
                 </asp:Panel>
                 </div>

            </asp:Panel> 
        </div>

	<div class="footer">
	</div>
    </form>
</body>
</html>
