using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Encodings.Web;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace artadosearch
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = Request.QueryString["i"];
                if (query == null)
                {
                    query = Request.QueryString["q"];
                }

                if (query != null && query != string.Empty)
                {
                    //Connection String
                    string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();

                    searchinput.Attributes.Add("value", query);
                    Page.Title = HttpUtility.HtmlEncode(query) + " - Artado Search";

                    HttpCookie source = HttpContext.Current.Request.Cookies["WebResults"];
                    HttpCookie video_source = HttpContext.Current.Request.Cookies["VideoResults"];
                    HttpCookie aca_source = HttpContext.Current.Request.Cookies["AcademicResults"];

                    //Categories Buttons
                    CategoriesButtons();

                    string type = Request.QueryString["type"];

                    //Get the Wikipedia Data
                    Wiki wiki = GetWiki.Get(query);

                    switch (type)
                    {
                        //Web Results
                        case "web":
                            Web(query, source, wiki);
                            break;

                        case "image":
                            Image(query);
                            break;

                        case "video":
                            Videos(query, video_source);
                            break;

                        case "news":
                            News(query);
                            break;

                        case "info":
                            artado.Visible = true;
                            web_results.Visible = false;
                            infocard.Visible = false;
                            image_results.Visible = false;

                            in1.Attributes.Add("style", "color: black !important;");
                            in2.Attributes.Add("style", "color: black !important;");
                            in3.Attributes.Add("style", "color: black !important;");
                            A7.Attributes.Add("style", "color: black !important;");
                            break;

                        case "movie":
                            artado.Visible = true;
                            web_results.Visible = false;
                            infocard.Visible = false;
                            image_results.Visible = false;

                            m1.Attributes.Add("style", "color: black !important;");
                            m2.Attributes.Add("style", "color: black !important;");
                            m3.Attributes.Add("style", "color: black !important;");
                            A8.Attributes.Add("style", "color: black !important;");
                            break;

                        case "it":
                            artado.Visible = true;
                            web_results.Visible = false;
                            infocard.Visible = false;
                            image_results.Visible = false;

                            it1.Attributes.Add("style", "color: black !important;");
                            it2.Attributes.Add("style", "color: black !important;");
                            it3.Attributes.Add("style", "color: black !important;");
                            A9.Attributes.Add("style", "color: black !important;");
                            break;

                        case "academic":
                            Academic(query, aca_source);
                            break;

                        default:
                            Web(query, source, wiki);
                            break;
                    }

                    #region Save Search
                    System.Globalization.CultureInfo cul = System.Threading.Thread.CurrentThread.CurrentUICulture;
                    string lang = cul.TwoLetterISOLanguageName;
                    string pref_lang;
                    HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
                    DateTime dateTime = DateTime.UtcNow.Date;
                    string date = dateTime.ToString("dd/MM/yyyy");
                    string web_source;

                    if(source != null)
                    {
                        web_source = source.Value;
                    }
                    else
                    {
                        web_source = "Google";
                    }

                    if (cookielang != null)
                    {
                        pref_lang = cookielang.Value;
                    }
                    else
                    {
                        pref_lang = lang;
                    }

                    if(web_source != "Artado")
                    {
                        SqlConnection connection = new SqlConnection(con);
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        string istek = "insert into Searchs(preferred_lang, date, source) values (@preferred_lang, @date, @source)";
                        SqlCommand cmd = new SqlCommand(istek, connection);
                        cmd.Parameters.AddWithValue("@preferred_lang", pref_lang);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@source", web_source);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    #endregion

                    #region Customization
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
                            searchpage.Controls.Add(
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

                    //Custom JS
                    //HttpCookie customjs = HttpContext.Current.Request.Cookies["CustomJS"];
                    //if (customjs != null && customjs != null)
                    //{
                    //    Page.Header.Controls.Add(
                    //             new System.Web.UI.LiteralControl("<script>" + Server.UrlDecode(customjs.Value) + "</script>"));
                    //}
                    #endregion
                }
                else
                {
                    Response.Redirect("/");
                }
            }
        }

        //Language Settings
        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
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

            //Normal Themes
            HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
            if (cookie0 != null && cookie0.Value != null)
            {
                Page.Theme = cookie0.Value;
            }
            else
            {
                Page.Theme = "Default";
            }

            //Result lang
            HttpCookie cookie = HttpContext.Current.Request.Cookies["result_lang"];
            if (cookie != null && cookie.Value != null)
            {
                languageDropDown.SelectedValue = cookie.Value;
            }

            System.Web.HttpCookie cat_cookie = HttpContext.Current.Request.Cookies["Categories"];
            if (cat_cookie != null && cat_cookie.Value != null)
            {
                switch (cat_cookie.Value)
                {
                    case "top":
                        classic_tabs.Visible = true;
                        left_tabs.Visible = false;
                        right_tabs.Visible = false;
                        bottom_tabs.Visible = false;
                        break;

                    case "left":
                        classic_tabs.Visible = false;
                        left_tabs.Visible = true;
                        right_tabs.Visible = false;
                        bottom_tabs.Visible = false;
                        break;

                    case "right":
                        classic_tabs.Visible = false;
                        left_tabs.Visible = false;
                        right_tabs.Visible = true;
                        bottom_tabs.Visible = false;
                        break;

                    case "bottom":
                        classic_tabs.Visible = false;
                        left_tabs.Visible = false;
                        right_tabs.Visible = false;
                        bottom_tabs.Visible = true;
                        break;

                    default:
                        classic_tabs.Visible = true;
                        left_tabs.Visible = false;
                        right_tabs.Visible = false;
                        bottom_tabs.Visible = false;
                        break;
                }
            }
            else
            {
                classic_tabs.Visible = true;
                left_tabs.Visible = false;
                right_tabs.Visible = false;
                bottom_tabs.Visible = false;
            }
        }

       
        protected void Search(object sender, EventArgs e)
        {
            Response.Redirect("/search?i=" + HttpUtility.UrlEncode(searchinput.Text));
        }

        //Passwords
        string api_pass = Configs.api_pass;
        string pass = Configs.enc_pass;
        string api = Configs.api_url;
        protected void SignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://myacc.artado.xyz/?name=" + api);
        }

        #region Search Buttons
        //Google
        protected void Google_B_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "Google");
        }

        //Artado
        protected void Button1_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "Artado");
        }

        //Bing
        protected void Button2_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "Bing");
        }

        //Yahoo
        protected void Button3_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "Yahoo");
        }

        //Youtube
        protected void Button5_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "web":
                    CreateCookie("WebResults", "Youtube");
                    break;

                case "video":
                    CreateCookie("VideoResults", "Youtube");
                    break;

                default:
                    CreateCookie("WebResults", "Youtube");
                    break;
            }
        }

        //Izlesene
        protected void Button6_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "web":
                    CreateCookie("WebResults", "Izlesene");
                    break;

                case "video":
                    CreateCookie("VideoResults", "Izlesene");
                    break;

                default:
                    CreateCookie("WebResults", "Izlesene");
                    break;
            }
        }

        //Github
        protected void Button7_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "Github");
        }

        //Scholar
        protected void Button8_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "web":
                    CreateCookie("WebResults", "Scholar");
                    break;

                case "academic":
                    CreateCookie("AcademicResults", "Scholar");
                    break;

                default:
                    CreateCookie("WebResults", "Scholar");
                    break;
            }
        }

        //BASE
        protected void Button9_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "web":
                    CreateCookie("WebResults", "BASE");
                    break;

                case "academic":
                    CreateCookie("AcademicResults", "BASE");
                    break;

                default:
                    CreateCookie("WebResults", "BASE");
                    break;
            }
        }

        //Bing News
        protected void Button10_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "News");
        }


        //Categories Button
        public void CategoriesButtons()
        {
            string q = Request.QueryString["i"];

            if (q == null)
            {
                q = Request.QueryString["q"];
            }

            w1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=web");
            i1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=image");
            v1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=video");
            n1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=news");
            in1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=info");
            m1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=movie");
            it1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=it");
            a1.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=academic");

            w2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=web");
            i2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=image");
            v2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=video");
            n2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=news");
            in2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=info");
            m2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=movie");
            it2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=it");
            a2.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=academic");

            w3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=web");
            i3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=image");
            v3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=video");
            n3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=news");
            in3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=info");
            m3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=movie");
            it3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=it");
            a3.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=academic");

            A.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=web");
            A4.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=image");
            A5.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=video");
            A6.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=news");
            A7.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=info");
            A8.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=movie");
            A9.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=it");
            a10.HRef = HttpUtility.UrlPathEncode("/search?i=" + q.Replace("\"", "%22") + "&type=academic");
        }

        //Creates Cookie
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
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        #endregion

        #region Results
        //Web Results
        public void Web(string query, HttpCookie source, Wiki wiki)
        {
            web_results.Visible = true;
            image_results.Visible = false;

            w1.Attributes.Add("style", "color: black !important;");
            w2.Attributes.Add("style", "color: black !important;");
            w3.Attributes.Add("style", "color: black !important;");
            A.Attributes.Add("style", "color: black !important;");

            int currentPage;
            if (source != null && source.Value != null)
            {
                switch (source.Value)
                {
                    case "Google":
                        try
                        {
                            Google_B.Font.Bold = true;
                            google.Visible = true;
                            google_server.Visible = true;
                            googlejs.Visible = false;
                            others.Visible = false;
                            artado.Visible = false;

                            //Result lang
                            HttpCookie lang = HttpContext.Current.Request.Cookies["result_lang"];

                            if (lang != null && lang.Value != null)
                            {
                                google_server.DataSource = ResultsClass.Google(query, lang.Value);
                            }
                            else
                            {
                                google_server.DataSource = ResultsClass.Google(query, null);
                            }
                            google_server.DataBind();
                        }
                        catch
                        {
                            Google_B.Font.Bold = true;
                            google.Visible = true;
                            google_server.Visible = false;
                            googlejs.Visible = true;
                            others.Visible = false;
                            artado.Visible = false;

                            GoogleToken.ChangeToken();
                        }
                        break;

                    case "Artado":
                        Button1.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = false;
                        artado.Visible = true;

                        //Result lang
                        HttpCookie cookie = HttpContext.Current.Request.Cookies["result_lang"];
                        //Safe Search
                        HttpCookie safe = HttpContext.Current.Request.Cookies["safe"];
                        string safeS;
                        if (safe != null && safe.Value != null)
                        {
                            safeS = safe.Value;
                        }
                        else
                        {
                            safeS = "Off";
                        }

                        if (cookie != null && cookie.Value != null)
                        {
                            suggestions.DataSource = ResultsClass.Artado(query, 0, cookie.Value);
                        }
                        else
                        {
                            suggestions.DataSource = ResultsClass.Artado(query, 0, null);
                        }
                        suggestions.DataBind();
                        break;

                    case "Bing":
                        Button2.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Bing(query, currentPage);
                        break;

                    case "Yahoo":
                        Button3.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Yahoo(query, currentPage);
                        break;

                    case "Petal": //Petal Results are no longer available.
                        CreateCookie("WebResults", "Google");
                        break;

                    case "Youtube":
                        Button5.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Youtube(query, currentPage);
                        break;

                    case "Izlesene":
                        Button6.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Izlesene(query, currentPage);
                        break;

                    case "Github": //Github Results are no longer available.
                        CreateCookie("WebResults", "Google");
                        break;

                    case "Scholar":
                        Button8.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Scholar(query, currentPage);
                        break;

                    case "BASE":
                        Button9.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Base(query, currentPage);
                        break;

                    case "News":
                        Button10.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.BingNews(query, currentPage);
                        break;

                    default:
                        try
                        {
                            Google_B.Font.Bold = true;
                            google.Visible = true;
                            google_server.Visible = true;
                            googlejs.Visible = false;
                            others.Visible = false;
                            artado.Visible = false;

                            //Result lang
                            HttpCookie lang = HttpContext.Current.Request.Cookies["result_lang"];

                            if (lang != null && lang.Value != null)
                            {
                                google_server.DataSource = ResultsClass.Google(query, lang.Value);
                            }
                            else
                            {
                                google_server.DataSource = ResultsClass.Google(query, null);
                            }
                            google_server.DataBind();
                        }
                        catch
                        {
                            Google_B.Font.Bold = true;
                            google.Visible = true;
                            google_server.Visible = false;
                            googlejs.Visible = true;
                            others.Visible = false;
                            artado.Visible = false;

                            GoogleToken.ChangeToken();
                        }
                        break;
                }
            }
            else
            {
                try
                {
                    Google_B.Font.Bold = true;
                    google.Visible = true;
                    google_server.Visible = true;
                    googlejs.Visible = false;
                    others.Visible = false;
                    artado.Visible = false;

                    //Result lang
                    HttpCookie lang = HttpContext.Current.Request.Cookies["result_lang"];

                    if (lang != null && lang.Value != null)
                    {
                        google_server.DataSource = ResultsClass.Google(query, lang.Value);
                    }
                    else
                    {
                        google_server.DataSource = ResultsClass.Google(query, null);
                    }
                    google_server.DataBind();
                }
                catch
                {
                    Google_B.Font.Bold = true;
                    google.Visible = true;
                    google_server.Visible = false;
                    googlejs.Visible = true;
                    others.Visible = false;
                    artado.Visible = false;

                    GoogleToken.ChangeToken();
                }
            }

            //Get the Wikipedia Data
            if (wiki == null)
            {
                infocard.Visible = false;
            }
            else
            {
                infocard.Visible = true;
                title.Text = wiki.Title;
                Img.ImageUrl = wiki.Img;
                Category.Text = wiki.Category;
                Summary.Text = wiki.Summary;
                more.HRef = wiki.Url;
            }
        }

        public void Image(string query)
        {
            web_results.Visible = false;
            artado.Visible = false;
            image_results.Visible = true;
            infocard.Visible = false;

            i1.Attributes.Add("style", "color: black !important;");
            i2.Attributes.Add("style", "color: black !important;");
            i3.Attributes.Add("style", "color: black !important;");
            A4.Attributes.Add("style", "color: black !important;");
            buttons_r.Visible = false;
        }

        public void Videos(string query, HttpCookie cookie)
        {
            web_results.Visible = true;
            image_results.Visible = false;
            infocard.Visible = false;

            Google_B.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;
            Button8.Visible = false;
            Button9.Visible = false;
            Button10.Visible = false;

            v1.Attributes.Add("style", "color: black !important;");
            v2.Attributes.Add("style", "color: black !important;");
            v3.Attributes.Add("style", "color: black !important;");
            A5.Attributes.Add("style", "color: black !important;");

            int currentPage;
            if (cookie != null && cookie.Value != null)
            {
                switch (cookie.Value)
                {
                    case "Youtube":
                        Button5.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Youtube(query, currentPage);
                        break;

                    case "Izlesene":
                        Button6.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Izlesene(query, currentPage);
                        break;

                    default:
                        Button6.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 1;
                        }

                        otherstxt.Text = ResultsClass.Izlesene(query, currentPage);
                        break;
                }
            }
            else
            {
                Button6.Font.Bold = true;
                google.Visible = false;
                others.Visible = true;
                artado.Visible = false;

                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 1;
                }

                otherstxt.Text = ResultsClass.Izlesene(query, currentPage);
            }
        }

        public void News(string query)
        {
            web_results.Visible = true;
            image_results.Visible = false;
            infocard.Visible = false;

            n1.Attributes.Add("style", "color: black !important;");
            n2.Attributes.Add("style", "color: black !important;");
            n3.Attributes.Add("style", "color: black !important;");
            A6.Attributes.Add("style", "color: black !important;");
            buttons_r.Visible = false;

            int currentPage;
            Button10.Font.Bold = true;
            google.Visible = false;
            others.Visible = true;
            artado.Visible = false;

            if (Request.QueryString["page"] != null)
            {
                currentPage = Int32.Parse(Request.QueryString["page"]);
            }
            else
            {
                currentPage = 1;
            }

            otherstxt.Text = ResultsClass.BingNews(query, currentPage);
        }

        public void Academic(string query, HttpCookie cookie)
        {
            web_results.Visible = true;
            image_results.Visible = false;
            infocard.Visible = false;

            Google_B.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button8.Visible = true;
            Button9.Visible = true;
            Button10.Visible = false;

            a1.Attributes.Add("style", "color: black !important;");
            a2.Attributes.Add("style", "color: black !important;");
            a3.Attributes.Add("style", "color: black !important;");
            a10.Attributes.Add("style", "color: black !important;");

            int currentPage;
            if (cookie != null && cookie.Value != null)
            {
                switch (cookie.Value)
                {
                    case "Scholar":
                        Button8.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Scholar(query, currentPage);
                        break;

                    case "BASE":
                        Button9.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Base(query, currentPage);
                        break;

                    default:
                        Button9.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;

                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                        }
                        else
                        {
                            currentPage = 0;
                        }

                        otherstxt.Text = ResultsClass.Base(query, currentPage);
                        break;
                }
            }
            else
            {
                Button9.Font.Bold = true;
                google.Visible = false;
                others.Visible = true;
                artado.Visible = false;

                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 0;
                }

                otherstxt.Text = ResultsClass.Base(query, currentPage);
            }
        }
        #endregion

        protected void languageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCookie("result_lang", languageDropDown.SelectedValue);
        }

        protected void SafeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCookie("safe", SafeSearch.SelectedValue);
        }
    }
}
