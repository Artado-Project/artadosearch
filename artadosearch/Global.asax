<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void adres(RouteCollection url)
    {
        url.MapPageRoute("default", "Home", "~/default.aspx");
        url.MapPageRoute("search", "search", "~/AramaSonuc.aspx");
        url.MapPageRoute("home", "ArtadoSoft/Home", "~/Topluluk/Servisler/Home/Home.aspx");
        url.MapPageRoute("about", "About", "~/Topluluk/Servisler/Home/About.aspx");
        url.MapPageRoute("support", "Support", "~/Topluluk/Servisler/Home/Support.aspx");
        url.MapPageRoute("contact", "Contact", "~/Topluluk/Servisler/İletişim/İletişim.aspx");
        url.MapPageRoute("updates", "Updates", "~/Topluluk/Servisler/Home/Updates.aspx");
        url.MapPageRoute("add", "AddResult", "~/Topluluk/DestekVeri.aspx");
        url.MapPageRoute("command", "Commands", "~/Topluluk/Tanıtım/OzelKomutlar.aspx");
        url.MapPageRoute("blog", "Blog", "~/Topluluk/Servisler/Yakında/Soon.aspx");
        url.MapPageRoute("news", "Newspaper", "~/Topluluk/Servisler/Gazete/Gazete.aspx");
        url.MapPageRoute("mail", "Mail", "~/Topluluk/Servisler/Mail/Mail.aspx");
        url.MapPageRoute("mailabout", "Mail/Hakkımızda", "~/Topluluk/Servisler/Mail/Mail_About.aspx");
        url.MapPageRoute("games", "Games", "~/Topluluk/Servisler/Home/Games.aspx");
        url.MapPageRoute("services", "Services", "~/Topluluk/Servisler/Home/Services.aspx");
        url.MapPageRoute("asistant", "Asistan/Home", "~/Topluluk/Servisler/Asistan/Anasayfa.aspx");
        url.MapPageRoute("asistantabout", "Asistan/About", "~/Topluluk/Servisler/Asistan/Asistan_About.aspx");
        url.MapPageRoute("blank", "BlankApp", "~/Blank/Blank.aspx");
        url.MapPageRoute("manifest", "Manifest", "~/Topluluk/Servisler/Home/Manifest.aspx");
        url.MapPageRoute("artado", "Welcome", "~/Topluluk/Artado/BizeKatılın.aspx");
        url.MapPageRoute("donate", "Donate", "~/Topluluk/Servisler/Home/Donate.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
        adres(RouteTable.Routes);

    }

    public void Application_BeginRequest(Object sender, EventArgs e)
    {
        // Code that runs on application startup                                                            
        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-Us");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-Us");
        }
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
