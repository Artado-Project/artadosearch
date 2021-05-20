<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="Topluluk_Servisler_Home_Support" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Support.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Destek Ol - Artado Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="spread">
            <asp:Image ID="Image" runat="server" ImageUrl="/Icons/artado_searchv2.png" CssClass="image" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Destek Ol" ForeColor="White" Font-Size="XX-Large" ></asp:Label>
            <hr style="background-color:white; width:300px;"/>
            <h4 class="txt">Yakınlarınız ile paylaşın!</h4>
            <h5 class="txt2" >Arkadaşlarınıza, ailenize ve tanıdıklarınıza Artado Search'ı anlatın. İnsanlar ile paylaşın. Ne kadar çok insana ulaşmamızı sağlarsanız o kadar çok gelişiriz. </h5>
            <asp:Button ID="Button1" runat="server" Text="Artado Search'ı paylaş" class="but1" BorderStyle="None" ForeColor="#517BBA" OnClick="Button1_Click" Font-Size="Small"/>
        </div>


        <div class="database">
            <h4 class="txt3">Sonuçlarımızı geliştirmeye yardım edin!</h4>
            <h5 class="txt4" >Sonuç ekle özelliği sayesinde Artado Search'ın geliştirilmesine yardım edebilirsiniz. Eklediğiniz bağlantı onay veri tabanımıza eklenir ve yöneticiler tarafından onaylandıktan sonra kullanıcıya gösterilir.</h5>
            <asp:Button ID="Button2" runat="server" Text="Sonuç Ekle" class="but2" BorderStyle="None" ForeColor="White" OnClick="Button2_Click"/>
        </div>

        <div class="news">
            <asp:Image ID="Image1" runat="server" ImageUrl="../../../AdsızGazete.png" CssClass="image" />
            <br />
            <h4 class="txt">Gazetemiz ile güncellemelerden anında haberdar olun!</h4>
            <h5 class="txt2" >Artado Gazete'ye abone olarak hakkımızdaki gelişmelerden anında haberdar olabilirsiniz. Düzenli olarak gelişmeler hakkında e-posta alacaksınız.</h5>
            <asp:Button ID="Button3" runat="server" Text="Abone Ol" class="but1" BorderStyle="None" ForeColor="#517BBA" OnClick="Button3_Click"/>
        </div>

         <div class="donate">
            <h4 class="txt3"="color:#517BBA; margin-top:100px;">Bize maddi olarak yardım edebilirsiniz.</h4>
            <h5 class="txt4" >Artado Search size en iyi hizmeti sunmak için reklamsız olarak tasarlandı. Sadece yan servislerde rahatsız etmeyecek şekilde reklamlar bulunmaktadır ama arama kısmında hiç bir reklam yoktur. Sizler sayesinde Artado Search ayakta durabilmektedir. Bağışlarınız bizin için çok önemlidir. Eğer bize bağış yapacak bütçeniz yoksa yukarıdakileri yapmanız bizim için en az bağışlar kadar önemlidir.</h5>
            <asp:Button ID="Button4" runat="server" Text="Bağış yap" class="but2" BorderStyle="None" ForeColor="White" OnClick="Button4_Click"/>
        </div>
    </form>
</body>
</html>
