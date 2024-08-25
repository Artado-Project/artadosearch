using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json;

namespace artadosearch
{
    public partial class Default : System.Web.UI.Page
    {
        //Connection Strings
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
        string search = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();

        //Passwords
        string api_pass = Configs.api_pass;
        string pass = Configs.enc_pass;
        string api = Configs.api_url;

        protected void Page_Load(object sender, EventArgs e)
        {
            searchinput.Attributes.Add("placeholder", Resources.Langs.Slogan);

            //Custom Themes, Extensions, Logos etc
            try
            {
                //Custom Trial
                string p = Request.QueryString["p"];

                //Profiles
                string profile = Request.QueryString["profile"];

                if (p != null)
                {
                    string type = ArtadoSql.Select("Genre", "Products", "ID", p, con, "string");

                    if (type == "Theme")
                    {
                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        Page.Header.Controls.Add(
                            new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\" />"));
                    }
                    else if(type == "Extension")
                    {
                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        homepage.Controls.Add(
                             new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\"></script>"));
                    }
                    else if(type == "Logo")
                    {
                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        Image1.Src = "https://devs.artado.xyz/" + path;
                    }

                    save.Visible = true;
                }
                else if (profile != null)
                {
                    try
                    {
                        save.Visible = true;

                        string iconp;
                        string customico;
                        string custom_theme;
                        string custom_css;
                        string ext_p;
                        string bg;

                        #region Get the values
                        //Icon
                        try
                        {
                            iconp = ArtadoSql.Select("icon", "Profiles", "profile_id", profile, search, "string");
                        }
                        catch
                        {
                            iconp = null;
                        }

                        //Custom Icon
                        try
                        {
                            customico = ArtadoSql.Select("custom_icon", "Profiles", "profile_id", profile, search, "string");
                        }
                        catch
                        {
                            customico = null;
                        }

                        //Custom Theme
                        try
                        {
                            custom_theme = ArtadoSql.Select("custom_themes", "Profiles", "profile_id", profile, search, "string");
                            HttpCookie old = HttpContext.Current.Request.Cookies["temp_theme"];
                            if (old != null && old.Value != null)
                            {
                                old.Expires = DateTime.UtcNow.AddDays(-1);
                                Response.Cookies.Add(old);
                                Session.Abandon();
                            }

                            HttpCookie cookie = new HttpCookie("temp_theme");
                            cookie.Value = custom_theme;
                            Response.Cookies.Add(cookie);

                            foreach (string item in cookie.Values)
                            {
                                string path = cookie.Values[item];
                                Page.Header.Controls.Add(
                                     new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\" />"));
                            }
                        }
                        catch
                        {
                            custom_theme = null;
                        }

                        //Custom CSS
                        try
                        {
                            custom_css = ArtadoSql.Select("custom_css", "Profiles", "profile_id", profile, search, "string");
                        }
                        catch
                        {
                            custom_css = null;
                        }

                        //Extensions
                        try
                        {
                            ext_p = ArtadoSql.Select("extensions", "Profiles", "profile_id", profile, search, "string");
                        }
                        catch
                        {
                            ext_p = null;
                        }

                        //Background
                        try
                        {
                            bg = ArtadoSql.Select("background_image", "Profiles", "profile_id", profile, search, "string");
                        }
                        catch
                        {
                            bg = null;
                        }
                        #endregion

                        if (iconp != null)
                        {
                            switch (iconp)
                            {
                                case "default":
                                    Image1.Src = "/images/android-chrome-192x192.png";
                                    break;

                                case "colorful":
                                    Image1.Src = "/images/artadov3-colorful-icon.png";
                                    break;

                                case "old":
                                    Image1.Src = "/images/oldies/old-icon.png";
                                    break;

                                default:
                                    Image1.Src = "/images/android-chrome-192x192.png";
                                    break;
                            }
                        }
                        if (customico != null)
                        {
                            Image1.Src = "https://devs.artado.xyz/" + customico;
                        }
                        if (custom_theme != null)
                        {
                            Page.Header.Controls.Add(
                                new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + custom_theme) + "\" />"));
                        }
                        if (custom_css != null)
                        {
                            Page.Header.Controls.Add(
                                 new System.Web.UI.LiteralControl("<style>" + Server.UrlDecode(custom_css) + "</style>"));
                        }
                        if (ext_p != null)
                        {
                            Page.Header.Controls.Add(
                                 new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + ext_p) + "\"></script>"));
                        }
                        if (bg != null)
                        {
                            homepage.Attributes.Add("style", "background:url(" + bg + ") no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;");
                        }
                    }
                    catch(Exception err)
                    {
                        Response.Write(err.Message);
                    }
                }
                else
                {
                    save.Visible = false;

                    //Theme Creator Mode
                    string creator = Request.QueryString["creator"];
                    if(creator != null)
                    {
                        homepage.Controls.Add(
                                 new System.Web.UI.LiteralControl("<script src=\"/js/creator.js\"></script>"));
                        theme_creator.Visible = true;
                    }
                    else
                    {
                        theme_creator.Visible = false;
                    }

                    //Custom Theme
                    HttpCookie custom = HttpContext.Current.Request.Cookies["CustomTheme"];
                    if (custom != null && custom.Value != null)
                    {
                        foreach (string item in custom.Values)
                        {
                            string path = custom.Values[item];
                            Page.Header.Controls.Add(
                                 new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\" />"));
                        }
                    }

                    //Extension
                    HttpCookie ext = HttpContext.Current.Request.Cookies["Extension"];
                    if (ext != null && ext.Value != null)
                    {
                        foreach (string item in ext.Values)
                        {
                            string path = ext.Values[item];
                            homepage.Controls.Add(
                                 new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\"></script>"));
                        }
                    }

                    //Custom Icons
                    HttpCookie icon = HttpContext.Current.Request.Cookies["CustomIcon"];
                    if (icon != null && icon.Value != null)
                    {
                        Image1.Src = "https://devs.artado.xyz/" + icon.Value;
                    }

                    //Custom CSS
                    HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
                    if (customcss != null && customcss != null)
                    {
                        Page.Header.Controls.Add(
                                 new System.Web.UI.LiteralControl("<style>" + Server.UrlDecode(customcss.Value) + "</style>"));
                    }

                    ////Custom JS
                    //HttpCookie customjs = HttpContext.Current.Request.Cookies["CustomJS"];
                    //if (customjs != null && customjs != null)
                    //{
                    //    Page.Header.Controls.Add(
                    //             new System.Web.UI.LiteralControl("<script>" + Server.UrlDecode(customjs.Value) + "</script>"));
                    //}
                }

                //sorry guys we need money :(
                #region Ads
                HttpCookie ads_cookie = HttpContext.Current.Request.Cookies["Ads"];
                //Personalized Ads
                if (ads_cookie == null || ads_cookie.Value == "Enable")
                {
                    HttpCookie ad_id = new HttpCookie("ad_id");
                    string id;
                    if (ad_id != null && ad_id.Value != null)
                    {
                        id = ad_id.Value;
                    }
                    else if (Session["ad_id"] != null)
                    {
                        id = Session["ad_id"].ToString();
                    }
                    else
                    {
                        id = Guid.NewGuid().ToString();
                        Session["ad_id"] = id;
                    }

                    //Region (we use lang instead)
                    string[] userLanguages = Request.UserLanguages;
                    string primaryLanguage = userLanguages != null && userLanguages.Length > 0 ? userLanguages[0] : "us";
                    string countrycode = primaryLanguage.Length > 3 &&
                                         (primaryLanguage.StartsWith("en") || primaryLanguage.StartsWith("de") || primaryLanguage.StartsWith("zh"))
                                         ? primaryLanguage.Substring(3).ToLower() : primaryLanguage.Substring(0, 2);

                    if (countrycode == "cn")
                    {
                        countrycode = "ch";
                    }

                    HttpWebRequest request;
                    if (countrycode == "us" || countrycode == "gb" || countrycode == "de" || countrycode == "at" || countrycode == "ch" || countrycode == "tr")
                    {
                        request = (HttpWebRequest)HttpWebRequest.Create("https://tiles.takernd.com/api/tiles?count=5&deviceId=" + id + "&countryCode=" + countrycode);
                        try
                        {
                            request.Method = "GET";
                            request.Accept = "application/json";
                            request.Headers.Add("Authorization", "Bearer 626ce7c0d65c670c9a6f1637e7a6f00da57d0adf");
                            WebResponse response = request.GetResponse();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            string jsonstring = reader.ReadToEnd();

                            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JObject.Parse(jsonstring)["data"].ToString());
                            Tiles.DataSource = dt;
                            Tiles.DataBind();
                        }
                        catch (Exception ex)
                        {
                            sponsors.Visible = false;
                        }
                    }
                    else
                    {
                        request = (HttpWebRequest)HttpWebRequest.Create("https://tiles.takernd.com/api/tiles?count=5&deviceId=" + id + "&countryCode=" + countrycode);
                        request.Method = "GET";
                        request.Accept = "application/json";
                        request.Headers.Add("Authorization", "Bearer 626ce7c0d65c670c9a6f1637e7a6f00da57d0adf");
                        WebResponse response = request.GetResponse();
                        sponsors.Visible = false;
                    }
                }
                else
                {
                    sponsors.Visible = false;
                }
                #endregion
            }
            catch
            {
                save.Visible = false;
            }
        }

        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            System.Web.HttpCookie cookie3 = HttpContext.Current.Request.Cookies["WebResults"];
            if (cookie3 != null && cookie3.Value != null)
            {
                Results.SelectedValue = cookie3.Value;
            }
            else
            {
                Results.SelectedValue = "All";
            }

            System.Web.HttpCookie sug = HttpContext.Current.Request.Cookies["Suggestions"];
            if (sug != null && sug.Value != null)
            {
                Suggestions.SelectedValue = sug.Value;
            }
            else
            {
                Suggestions.SelectedValue = "ddg";
            }

            System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
            System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string lang = kultur.TwoLetterISOLanguageName;

            if (cookielang != null && cookielang.Value != null)
            {
                Languages.SelectedValue = cookielang.Value;
            }
            else
            {
                Languages.SelectedValue = lang;
            }

            HttpCookie customicon = HttpContext.Current.Request.Cookies["CustomIcon"];
            HttpCookie old = HttpContext.Current.Request.Cookies["Icon"];
            if (customicon == null)
            {
                if (old != null && old.Value != null)
                {
                    switch (old.Value)
                    {
                        case "default":
                            Image1.Src = "/images/android-chrome-192x192.png";
                            break;

                        case "og":
                            Image1.Src = "/images/oldies/og/android-chrome-192x192.png";
                            break;

                        case "colorful":
                            Image1.Src = "/images/artadov3-colorful-icon.png";
                            break;

                        case "old":
                            Image1.Src = "/images/oldies/old-icon.png";
                            break;

                        default:
                            Image1.Src = "/images/android-chrome-192x192.png";
                            break;
                    }
                }
                else
                {
                    Image1.Src = "/images/android-chrome-192x192.png";
                }
            }

            HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
            if (old2 != null && old2.Value != null)
            {
                homepage.Attributes.Add("style", "background:url(" + old2.Value + ") no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;");
            }

            string profile = Request.QueryString["profile"];
            if (profile != null)
            {
                string themep;
                //Theme
                try
                {
                    themep = ArtadoSql.Select("theme", "Profiles", "profile_id", profile, search, "string");
                }
                catch
                {
                    themep = null;
                }

                if (themep != null)
                {
                    Page.Theme = themep;
                }
            }
            else
            {
                //Normal Themes
                HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
                if (cookie0 != null && cookie0.Value != null)
                {
                    Page.Theme = cookie0.Value;
                    Themes.SelectedValue = cookie0.Value;
                }
                else
                {
                    Page.Theme = "Default";
                    Themes.SelectedValue = "Default";
                }
            }
        }

        protected void Themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCookie("Theme", Themes.SelectedValue);
            Response.Redirect("/");
        }

        protected void Languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Lang"];
            if (old != null && old.Value != null)
            {
                CreateCookie("Lang", Languages.SelectedValue);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                CreateCookie("Lang", Languages.SelectedValue);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Languages.SelectedValue);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Languages.SelectedValue);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void Results_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCookie("WebResults", Results.SelectedValue);
        }

        protected void Search(object sender, EventArgs e)
        {
            Response.Redirect("/search?i=" + HttpUtility.UrlEncode(searchinput.Text));
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://myacc.artado.xyz/?name=" + api);
        }

        public void CreateCookie(string name, string value)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies[name];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
            }
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            string p = Request.QueryString["p"];
            string profile = Request.QueryString["profile"];

            if (p != null)
            {
                try
                {
                    string type = ArtadoSql.Select("Genre", "Products", "ID", p, con, "string");

                    if (type == "Theme")
                    {
                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        HttpCookie cookie = HttpContext.Current.Request.Cookies["CustomTheme"];
                        if (cookie == null)
                        {
                            cookie = new HttpCookie("CustomTheme");
                        }
                        cookie.Values.Add("theme" + Guid.NewGuid(), path);
                        cookie.Expires = DateTime.UtcNow.AddDays(360);
                        Response.Cookies.Add(cookie);
                        Page.Response.Redirect("/");
                    }
                    else if (type == "Extension")
                    {
                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        HttpCookie cookie = HttpContext.Current.Request.Cookies["Extension"];
                        if (cookie == null)
                        {
                            cookie = new HttpCookie("Extension");
                        }
                        cookie.Values.Add("ext" + Guid.NewGuid(), path);
                        cookie.Expires = DateTime.UtcNow.AddDays(360);
                        Response.Cookies.Add(cookie);
                        Page.Response.Redirect("/");
                    }
                    else if (type == "Logo")
                    {
                        HttpCookie ext = HttpContext.Current.Request.Cookies["CustomIcon"];
                        if (ext != null)
                        {
                            ext.Expires = DateTime.UtcNow.AddDays(-1);
                            Response.Cookies.Add(ext);
                        }

                        string version = ArtadoSql.Select("WinFolder", "Products", "ID", p, con, "string");
                        string path = ArtadoSql.Select("Path", "Versions", "ID", version, con, "string");

                        HttpCookie cookie = new HttpCookie("CustomIcon");
                        cookie.Value = path;
                        cookie.Expires = DateTime.UtcNow.AddDays(360);
                        Response.Cookies.Add(cookie);
                        Page.Response.Redirect("/");
                    }
                }
                catch
                {
                    Response.Redirect("/");
                }
            }
            else if(profile != null)
            {
                try
                {
                    string iconp;
                    string customico;
                    string custom_theme;
                    string custom_css;
                    string ext_p;
                    string bg;
                    string categs;
                    string themep;


                    #region Get the values
                    //Icon
                    try
                    {
                        iconp = ArtadoSql.Select("icon", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        iconp = null;
                    }

                    //Theme
                    try
                    {
                        themep = ArtadoSql.Select("theme", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        themep = null;
                    }

                    //Custom Icon
                    try
                    {
                        customico = ArtadoSql.Select("custom_icon", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        customico = null;
                    }

                    //Custom Theme
                    try
                    {
                        custom_theme = ArtadoSql.Select("custom_themes", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        custom_theme = null;
                    }

                    //Custom CSS
                    try
                    {
                        custom_css = ArtadoSql.Select("custom_css", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        custom_css = null;
                    }

                    //Extensions
                    try
                    {
                        ext_p = ArtadoSql.Select("extensions", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        ext_p = null;
                    }

                    //Background
                    try
                    {
                        bg = ArtadoSql.Select("background_image", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        bg = null;
                    }

                    //Categories
                    try
                    {
                        categs = ArtadoSql.Select("background_image", "Profiles", "profile_id", profile, search, "string");
                    }
                    catch
                    {
                        categs = null;
                    }
                    #endregion

                    if (iconp != null)
                    {
                        CreateCookie("Icon", iconp);
                    }
                    if (customico != null)
                    {
                        CreateCookie("CustomIcon", customico);
                    }
                    if (themep != null)
                    {
                        CreateCookie("Theme", themep);
                    }
                    if (custom_theme != null)
                    {
                        CreateCookie("CustomTheme", custom_theme);
                    }
                    if (custom_css != null)
                    {
                        CreateCookie("CustomCSS", custom_css);
                    }
                    if (ext_p != null)
                    {
                        CreateCookie("Extension", ext_p);
                    }
                    if (bg != null)
                    {
                        CreateCookie("background", bg);
                    }
                    if (categs != null)
                    {
                        CreateCookie("Categories", categs);
                    }
                    Response.Redirect("/");
                }
                catch
                {
                    Response.Redirect("/");
                }
            }
        }

        protected void no_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("/");
        }

        protected void Suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCookie("suggestions", Suggestions.SelectedValue);
            Response.Redirect("/");
        }
    }
}