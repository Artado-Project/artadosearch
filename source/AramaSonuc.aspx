<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AramaSonuc.aspx.cs" Inherits="AramaSonuc" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="AramaSonuc.css" rel="stylesheet" />
    <link href="bootstrap-4.5.3-dist/css/bootstrap.min.css" rel="stylesheet" />
     <link rel= "shortcut icon" href="/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Search - Reklamsız ve Sade Arama Motoru</title>
</head>
<body>
    <form id="form1" runat="server">

        <div style= "margin-bottom:20px" class="üstkısım">
            <asp:Panel ID="Panel2" runat="server" CssClass="arama2" BorderStyle="Outset">
                 <asp:TextBox ID="arama_çubugu2" runat="server" CssClass="textbox" BorderStyle="None" TextMode="Search" OnTextChanged="arama_çubugu2_TextChanged"></asp:TextBox>
        <asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
         <asp:ImageButton ID="Voice" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/voice-search.png" Width="19px"  BorderStyle="None"/>
                </asp:Panel>
            <asp:ImageButton ID="Image1" runat="server" CssClass="image" ImageUrl="~/AS-Icon2.png" OnClick="Image1_Click1"  /> 
            <br />
            <br />
            <asp:Button ID="Web" runat="server" Text="Web" CssClass="web" BorderStyle="None" BackColor="Transparent" OnClick="Web_Click"/>
            <asp:Button ID="Görsel" runat="server" Text="Görsel" CssClass="görsel" BorderStyle="None" BackColor="Transparent" OnClick="Görsel_Click"/>
            <asp:Button ID="Sözlük" runat="server" Text="Sözlük" CssClass="sözlük" BorderStyle="None" BackColor="Transparent" OnClick="Sözlük_Click"/>
            <asp:Button ID="Müzik" runat="server" Text="Müzik" CssClass="müzik" BorderStyle="None" BackColor="Transparent" OnClick="Müzik_Click"/>
            <hr class="çizgi"/>
             </div>


        <div style="margin-left:50px;">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label>
        </div>

        <div id="İletişim" class="iletişim">
            <asp:Label ID="İletişimBaşlık" runat="server" Text="Teşekkür ederiz!" Font-Size="Larger" Font-Bold="true" ForeColor="#517BBA"></asp:Label>
            <br />
            <asp:Label ID="İletişimAçıklama" runat="server" Text="ArtadoSearch'ı ilk kullanan kişilerden birisiniz. Bize neleri beğenip neleri beğenmediğinizi anlatırsanız size daha iyi bir hizmet sunmamızda katkı sağlarsınız." Font-Size="Medium" ForeColor="#517BBA"></asp:Label>
            <br /> 
            <asp:TextBox ID="Mail" runat="server" PlaceHolder="E-posta" BackColor="White" BorderStyle="Outset"></asp:TextBox>
            <br />
            <br />
            <textarea id="Deneyim" runat="server" placeholder="Deneyiminizi anlatın" cols="20" rows="2" ></textarea>
            <asp:Button ID="Gönder" runat="server" Text="Gönder" OnClick="Gönder_Click" />
            <asp:Label ID="Sonuc" runat="server" Text="" Font-Size="Small" Font-Bold="true"></asp:Label>
        </div>

        <div>
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Outset" CssClass="panel">
                <asp:Image ID="Image2" runat="server" CssClass="panelimage"/>
                <asp:Label ID="Ad" runat="server" Text="Aaron Swartz" Font-Bold="true"></asp:Label>
                <br />
                <asp:Label ID="Meslek" runat="server" Text="Amerikalı bilgisayar programcısı, bilişimci, yazar ve aktivist" Font-Size="Small"></asp:Label>
                <br />
                <asp:Label ID="Doğum" runat="server" Text="1986-2013"></asp:Label>
            </asp:Panel>
        </div>


        <div class="sonuclar">
             <asp:Panel ID="WebArama" runat="server" class="webarama">
            <asp:Repeater runat="server" ID="rptAramaSonuclari" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Label2" runat="server" ><%# Eval("Title") %></asp:Label></a> <br/>
                        <%# Eval("Link") %> <br />
                        <%# Eval("Content1") %>
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                  <asp:Label ID="Label3" runat="server" Text="ArtadoSearch hala geliştirildiğinden dolayı veri tabanımız kısıtlı. Aramanızın başına .g komutunu koyarak güvenli arama yapabilirsiniz veya Ek Sonuçlar kısmına bakabilirsiniz." ></asp:Label>
            <br />
            <br />
            </asp:Panel> 

            <asp:Panel ID="EkSonuclar" runat="server" >

                <asp:Label ID="Label4" runat="server" Text="Ek Sonuçlar" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <hr class="çizgid"/>

                <asp:Panel ID="EkSonuclar1" runat="server" CssClass="sonuc">
                        <asp:Label ID="EkBaşlık" runat="server" Text="" Font-Size="Medium"></asp:Label>
                    <br />
                    <br />
                        Ek Sonuçlar Bakımdadır.
                    <br />
                </asp:Panel>                                           
            </asp:Panel>
            
          

            <asp:Panel ID="GörselArama" runat="server" class="webarama">
                <asp:Label ID="GörselMetin" runat="server" Text="Görsel Arama Yakında Aktif olacaktır!" Font-Bold="true" Font-Size="X-Large" CssClass="yakında"></asp:Label>
                   </asp:Panel>

            <asp:Panel ID="SözlükArama" runat="server" class="webarama">
                <h3 style="text-align:center;">Sözlük Arama</h3>
                <asp:Repeater runat="server" ID="sözlüksonuc" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <%# Eval("Kelime") %> <br />
                        <%# Eval("Anlam") %>
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                   </asp:Panel>
            
            <asp:Panel ID="MüzikArama" runat="server" class="webarama">
                <asp:Label ID="MüzikMetin" runat="server" Text="Müzik Arama Yakında Aktif olacaktır!" Font-Bold="true" Font-Size="X-Large" CssClass="yakında"></asp:Label>
                   </asp:Panel>
        </div>
             

    </form>
</body>
</html>
