<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Blank.aspx.cs" Inherits="Blank_Blank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<link href="/Blank/style.css" rel="stylesheet" />
<link rel="shortcut icon" href="Icons/favicon.ico" />
<script type="text/javascript" src="/js/default.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta charset="utf-8"/>
<link rel="apple-touch-icon" href="Icons/apple-touch-icon.png"/>
<link rel="apple-touch-startup-image" href="Icons/apple-touch-icon.png"/>
<link rel="icon" sizes="192x192" href="Icons/android-chrome-192x192.png"/>
<meta name="theme-color" content="#000000"/>
<meta name="apple-mobile-web-app-capable" content="yes"/>
<meta name="apple-mobile-web-app-status-bar-style" content="black-translucent"/>
<link rel="manifest" href="Icons/site.manifest"/>
<link href="https://www.artadosearch.com/BlankApp" rel="canonical"/>
<meta name="keywords" content="özgür, sosyal ağ, sosyal medya, yerli sosyal medya, anonim, artado, yerli sosyal ağ"/>
<meta name="description" content="Blank ile özgürce paylaşım yap!" />
<meta property="og:title" content="Blank - Özgür Sosyal Ağ" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artadosearch.com/BlankApp" />
<meta property="og:description" name="description" class="swiftype" content="Blank ile özgürce paylaşım yap!"/>
    <title>Blank_ - Özgür Sosyal Ağ</title>
</head>
<body>
    <form id="form1" runat="server">
                <div>
            <img src="/Blank/Icons/blank.png" class="img"/>
            <asp:Label ID="Label4" runat="server" Text="Test" ForeColor="White" Font-Size="Large"></asp:Label>

            <asp:Panel ID="GirişPanel" runat="server">
                <div class="buttons">
                    <asp:Button ID="Button3" runat="server" Text="<%$Resources:Default, Oturum %>" BackColor="Red" ForeColor="White" BorderStyle="None" OnClick="Button3_Click"/>
                </div>
            </asp:Panel>
            <style>
                #ProfilePic{
                    height: 35px;
                }
            </style>
            <asp:ImageButton ID="ProfilePic" runat="server" CssClass="buttons" OnClick="ProfilePic_Click"/>

            <asp:Panel ID="Mesaj" runat="server">
                <div class="buttons">
                    <asp:Label ID="Label6" runat="server" Text="" ForeColor="white"></asp:Label>
                </div>
            </asp:Panel>
        </div>
        <br />        

        <div id="test" runat="server" class="panel">
            <asp:Label ID="testtxt" runat="server" Text="Blank'e hoşgeldin!" ForeColor="White"></asp:Label>
        </div>

        <asp:Panel ID="Akış" runat="server" style="margin-bottom:50px;">
             <div class="panel">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Ne düşünüyorsun?" ForeColor="White" CssClass="textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Paylaş" BackColor="#0c0c0c" ForeColor="White" OnClick="Button1_Click"/>
                <br />
                <asp:Label ID="Label3" runat="server" Text="" ForeColor="White"></asp:Label>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="akış">
                        <asp:Label ID="Label1" runat="server" Text='Blank_' Font-Size="Small" ForeColor="Red"></asp:Label><br />
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("Post") %>' ForeColor="White"></asp:Label><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
     </asp:Panel>

      <asp:Panel ID="Keşfet" runat="server">
          <asp:Panel ID="Post" runat="server">
              <div class="panel">
                <asp:TextBox ID="TextBox5" runat="server" placeholder="Ne düşünüyorsun? (maks. 1000 karakter)" ForeColor="White" CssClass="textbox" MaxLength="1000" ValidateRequestMode="Enabled"></asp:TextBox>
                <asp:Button ID="Button9" runat="server" Text="Paylaş" BackColor="#0c0c0c" ForeColor="White" OnClick="Button9_Click"/>
                <br />
                <asp:Label ID="Label8" runat="server" Text="" ForeColor="White"></asp:Label>
            </div>
          </asp:Panel>

            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                <ItemTemplate>
                    <div class="akış">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Username") %>' Font-Size="Small" ForeColor="Red"></asp:Label><br />
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("Post") %>' ForeColor="White"></asp:Label><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
     </asp:Panel>              

     <asp:Panel ID="Kullanıcı" runat="server">
         <div style="margin-top:30px; color:white; height:1000px;" class="panel">
             <h5>Blank'ı kullanmak için belirli koşulları sağlamalısın.</h5>
         Blank'ın kullanım şartları diğer Artado Software ürünleri/hizmetleri için geçerli değildir. Blank üzerinden paylaşım yaparak bu koşulları sağladığınızı ve topluluk kurallarımızı kabul etmiş olursunuz.
         <br />
         <br />
         <h5>1. Blank üzerinden kimler paylaşım yapabilir?</h5>
         1. En az 13 yaşındaysanız,
         <br />
         2. Topluluk Kuralları'mıza aykırı davranmıyorsanız,
         <br />
         Blank üzerinden paylaşım yapabilir ve hesap açabilirsiniz.
         <br />
         <br />
         <h5>Topluluk Kuralları ve Şikayet Durumları</h5>
         1- Blank üzerinden paylaşım yaparak ve hesap açarak paylaştığınız gönderilerin sorumluluğunu alırsınız. Blank üzerinden paylaşım yapan hiç bir gönderiden Blank(bundan sonra Artado Software veya biz diye de hitap edilebilir) sorumlu değildir.
         <br />
         2- Herhangi bir gönderiyi şikayet etmek istiyorsanız artadoyazilim@gmail.com aderisi ile bizimle iletişime geçebilirsiniz. Şikayet edilen gönderiler Artado Software tarafından değerlendirilir ve uygun görülürse gönderi kaldırılır. ŞİKAYETİN GEÇERLİ SAYILMASI İÇİN GÖNDERİNİN EKRAN GÖRÜNTÜLERİNİ artadoyazilim@gmail.com ADRESİNE ATILMASI GEREKMEKTEDİR.
         <br />
         3- Herhangi bir kişiye hakaret etmek yasaktır. Hakaret içiren gönderiler şikayet edilmesi durumunda kaldırılacaktır.
         <br />
         4- Artado Software, şikayet durumlarında gönderi sahibinin verilerini veremez çünkü herhangi bir veri toplanmamaktadır. Eğer şikayet edilen gönderi Keşfet bölümünden atıldıysa uygun görülmesi halinde gönderi ve hesap silinir.
         <br />
         5- Artado Software, sizden asla hesap bilgilerinizi, kişisel bilgilerinizi, banka veya kimlik bilgilerinizi istemez.
         <br />
         6- Herhangi bir telif hakkı durumunda artadoyazilim@gmail.com adresine ulaşırsanız gerekli işlemler Artado Software tarafından yapılır.
             <br />
             <br />
         Ekstra notlar;
         Bu Şartları zaman zaman gözden geçirebiliriz ve yenileyebiliriz.
             <br />
             <br />
             -Artado Software Ekibi
         </div>
     </asp:Panel>     
    </form>
</body>
</html>
