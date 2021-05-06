<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void adres(RouteCollection url)
    {
        url.MapPageRoute("default", "Anasayfa", "~/default.aspx");
        url.MapPageRoute("search", "arama", "~/AramaSonuc.aspx");
        url.MapPageRoute("home", "ArtadoSoft/Anasayfa", "~/Topluluk/Servisler/Home/Home.aspx");
        url.MapPageRoute("about", "Hakkımızda", "~/Topluluk/Servisler/Home/About.aspx");
        url.MapPageRoute("support", "DestekOl", "~/Topluluk/Servisler/Home/Support.aspx");
        url.MapPageRoute("contact", "İletişim", "~/Topluluk/Servisler/İletişim/İletişim.aspx");
        url.MapPageRoute("updates", "Güncellemeler", "~/Topluluk/Servisler/Home/Updates.aspx");
        url.MapPageRoute("add", "SonuçEkle", "~/Topluluk/DestekVeri.aspx");
        url.MapPageRoute("command", "ÖzelKomutlar", "~/Topluluk/Tanıtım/OzelKomutlar.aspx");
        url.MapPageRoute("blog", "Blog", "~/Topluluk/Servisler/Yakında/Soon.aspx");
        url.MapPageRoute("news", "Gazete", "~/Topluluk/Servisler/Gazete/Gazete.aspx");
        url.MapPageRoute("mail", "Mail", "~/Topluluk/Servisler/Mail/Mail.aspx");
        url.MapPageRoute("mailabout", "Mail/Hakkımızda", "~/Topluluk/Servisler/Mail/Mail_About.aspx");
        url.MapPageRoute("games", "Oyunlarımız", "~/Topluluk/Servisler/Home/Games.aspx");
        url.MapPageRoute("services", "Servislerimiz", "~/Topluluk/Servisler/Home/Services.aspx");
        url.MapPageRoute("asistant", "Asistan/Anasayfa", "~/Topluluk/Servisler/Asistan/Anasayfa.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
        adres(RouteTable.Routes);

    }

    void Application_End(object sender, EventArgs e)
    {
        // Uygulama kapanışında çalışan kod

    }

    void Application_Error(object sender, EventArgs e)
    {
        // İşlenmemiş bir hata oluştuğunda çalışan kod

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Yeni bir oturum başlatıldığında çalışan kod

    }

    void Session_End(object sender, EventArgs e)
    {
        // Oturum bittiğinde çalışan kod
        // Not: Session_End olayı yalnızca sessionstate modu
        // Web.config dosyasında InProc olarak ayarlandığında başlatılır. Oturum modu StateServer 
        // veya SQLServer olarak ayarlanırsa, olay başlatılmaz.

    }

</script>
