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
        url.MapPageRoute("blog", "Soon", "~/Topluluk/Servisler/Yakında/Soon.aspx");
        url.MapPageRoute("photon", "Celer", "~/Topluluk/Servisler/Gazete/Gazete.aspx");
        url.MapPageRoute("photonapp", "Photon/Home", "~/Topluluk/Servisler/PhotonApp/App.aspx");
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
        url.MapPageRoute("privacy", "Privacy", "~/Topluluk/Servisler/Home/Privacy.aspx");
        url.MapPageRoute("forum", "Forum", "~/Topluluk/Servisler/Forum/Forum.aspx");
        url.MapPageRoute("forum-post", "Forum/posts/{post}", "~/Topluluk/Servisler/Forum/Forum.aspx");
        url.MapPageRoute("forum-users", "Forum/users/{user}", "~/Topluluk/Servisler/Forum/Forum.aspx");
        url.MapPageRoute("bot", "Bot", "~/ArtadoBot/Bot.aspx");
        url.MapPageRoute("settings", "Settings", "~/Settings.aspx");
        url.MapPageRoute("accounts", "Account", "~/Topluluk/Servisler/MyAccount/Default.aspx");
        url.MapPageRoute("proxy", "Proxy", "~/Topluluk/Servisler/Proxy/Default.aspx");
        url.MapPageRoute("proxyback", "Proxy/Run", "~/Topluluk/Servisler/Proxy/Proxy_Back.aspx");
        url.MapPageRoute("beyt", "Beyt", "~/Topluluk/Servisler/Beyt/Default.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
        adres(RouteTable.Routes);

    }

    public void Application_BeginRequest(Object sender, EventArgs e)
    {
        // Code that runs on application startup                                                            
        //HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        //if (cookielang != null && cookielang.Value != null)
        //{
        //    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        //}

        HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
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
