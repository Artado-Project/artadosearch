<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="Topluluk_Servisler_Home_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Bağış Yap!</title>
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
            <h2 style="text-align:center;">Bağış Yap</h2>
            <br />
            <div style="text-align:center;">
                Artado projelerinde de aynı diğer açık kaynaklı projelerde olduğu gibi en büyük gelirimiz -hatta tek gelirimiz- kullanıcıların bağışlarıdır. Artado Search gibi projelerimizin devam edebilmesi için az da olsa bir gelir etmek zorundayız.
                Bir çok projemiz reklamsız olarak hizmet vermekte ve biz bunun böyle devam etmesini istiyoruz ama bunun için en azından giderlerimizin küçükte olsa bir kısmını karşılamamız gerekiyor. Aksi takdirde projelerimizde reklamlar olacak veya projelerimiz hizmet vermeye devam edemeyecek.
                Peki neden projelerimize reklam koymaktan çekiniyoruz? Bunun 2 sebebi var. İlk sebebimiz tasarımı ve hizmet kalitesini bozmayacak şekilde reklam koymanın gerçekten zor olması. İkincisi ise reklamveren bulamamız. Bulsak bile bu sefer kullanıcı gizliliği ile ilgili sıkıntılar doğuyor.
                Kullanıcı gizliliği ve hizmet kalitesi bizim için vazgeçilemez. Bu yüzden sizin bağışlarınız, projelerin gelişmesi ve devam etmesi için önemli.
            </div>
            <br />
            <br />
            <div id="kreosus" data-id="1736" style="text-align:center;"></div>

           <script>(function(d, s, id) {
            var js, kjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s);
            js.id = id;
            js.src = 'https://kreosus.com/public/iframe/js/iframe-api.js';
            kjs.parentNode.insertBefore(js, kjs);
            }(document, 'script', 'kreosus-iframe-api'));
           </script>
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
