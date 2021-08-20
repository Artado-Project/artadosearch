<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DestekVeri.aspx.cs" Inherits="DestekVeri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Servisler/Home/About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Sonuç Ekle - Artado Search</title>
</head>
<body style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">
       <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="/IMG_074.png" CssClass="image" />
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
            <asp:Label ID="Label10" runat="server" Text="Web Sonucu Ekle" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="Eklemek istediğiniz sitenin URL adresini girin. Onaylama süreci bitince eklediğiniz site sonuçlarda gözükecektir."></asp:Label> 
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="URL girin" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>
           <asp:Button ID="Button1" runat="server" Text="Onayla" OnClick="Button1_Click" /><asp:Label ID="Sonuc1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Bilgi Sonucu Ekle" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="Bilgi sonuçları sözlük sitelerinde ki entry sistemi gibidir. Herkes tarafından yazılabilir. Onaylama süreci yoktur. Eğer eklediğiniz sonuç uygunsuz bulunursa silinecektir."></asp:Label> 
            <br />
            <br />
            <asp:TextBox ID="TitleText" runat="server" placeholder="Başlık" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Bir şeyler yaz..." BackColor="Transparent" Width="300px" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Onayla" OnClick="Button2_Click" /><asp:Label ID="Sonuc2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Bilgi Kutusu Ekle" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label6" runat="server" Text="Bilgi kutuları arama yapıldığında yan tarafta veya üstte çıkan kutulardır. Bilgi kutuları, bilgi sonuçlarına göre daha ansiklopedik bilgiler içermektedir. Bilgi kutularına 3 tane kaynak eklemek zorundasınız. Eklediğiniz bilgi kutuları onaylandıktan sonra sonuçlarda gözükür. Her konu için tek bilgi kutusu yazılabilir. Aşağıdaki tüm alanlar doldurulmalıdır."></asp:Label> 
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Başlık" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Kategori" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox6" runat="server" placeholder="Görsel Bağlantısı" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Açıklama" BackColor="Transparent" Width="300px" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox7" runat="server" placeholder="Kaynak ismi" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox8" runat="server" placeholder="Kaynak bağlantısı" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox9" runat="server" placeholder="Kaynak ismi" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox0" runat="server" placeholder="Kaynak bağlantısı" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox11" runat="server" placeholder="Kaynak ismi" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox12" runat="server" placeholder="Kaynak bağlantısı" BackColor="Transparent" Width="300px" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
           <asp:Label ID="Label7" runat="server" Text="Dil: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="tr">Türkçe</asp:ListItem>
                <asp:ListItem Value="en">İngilizce</asp:ListItem>
                <asp:ListItem Value="de">Almanca</asp:ListItem>
                <asp:ListItem Value="fr">Fransızca</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button3" runat="server" Text="Onayla" OnClick="Button3_Click" /><asp:Label ID="Sonuc3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
         
    </form>
</body>
</html>
