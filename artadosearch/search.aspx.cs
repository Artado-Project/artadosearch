using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.DynamicData;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using artadosearch.Settings_Pages;
using Resources;
using System.Collections;
using System.Security.Policy;
using System.Threading.Tasks;

namespace artadosearch
{
    public partial class search : System.Web.UI.Page
    {
        Task<bool> tor = Security.CheckTor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = Request.QueryString["i"] ?? Request.QueryString["q"];
                if (string.IsNullOrEmpty(query)) return;

                if (Bangs.BangSearch(query) == null)
                {
                    string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString;

                    searchinput.Attributes.Add("value", query);
                    Page.Title = HttpUtility.HtmlEncode(query) + " - Artado Search";

                    // Simplify Link generation using a loop
                    for (int i = 0; i <= 90; i += 10)
                    {
                        var link = FindControl("Link" + (i / 10 + 1)) as HtmlAnchor;
                        if (link != null) link.HRef = string.Format("/search?q={0}&p={1}", query, i);
                    }

                    HttpCookie source = HttpContext.Current.Request.Cookies["WebResults"];
                    HttpCookie video_source = HttpContext.Current.Request.Cookies["VideoResults"];
                    HttpCookie aca_source = HttpContext.Current.Request.Cookies["AcademicResults"];

                    // Categories Buttons
                    CategoriesButtons();

                    string type = Request.QueryString["type"] ?? "web";

                    Wiki wiki = GetWiki.Get(query);
                    Movie movie = null;

                    var handlers = new Dictionary<string, Action>
                    {
                        { "web", () => Web(query, source, wiki, movie) },
                        { "image", () => Image(query) },
                        { "video", () => Videos(query, video_source) },
                        { "news", () => News(query) },
                        { "info", () => ShowInfo() },
                        { "movie", () => ShowMovie() },
                        { "it", () => ShowIT() },
                        { "academic", () => Academic(query, aca_source) }
                    };

                    if (handlers.ContainsKey(type))
                    {
                        handlers[type].Invoke();
                    }
                    else
                    {
                        Web(query, source, wiki, movie);
                    }

                    MovieWidget.Visible = false;

                    ApplyCustomizations();
                }
                else
                {
                    Response.Redirect(Bangs.BangSearch(query));
                }
            }
        }

        private void ShowInfo()
        {
            artado.Visible = true;
            web_results.Visible = false;
            infocard.Visible = false;
            image_results.Visible = false;

            in1.Attributes.Add("style", "color: #1266f1 !important;");
            in2.Attributes.Add("style", "color: #1266f1 !important;");
            in3.Attributes.Add("style", "color: #1266f1 !important;");
            A7.Attributes.Add("style", "color: #1266f1 !important;");
        }

        private void ShowMovie()
        {
            artado.Visible = true;
            web_results.Visible = false;
            infocard.Visible = false;
            image_results.Visible = false;

            m1.Attributes.Add("style", "color: #1266f1 !important;");
            m2.Attributes.Add("style", "color: #1266f1 !important;");
            m3.Attributes.Add("style", "color: #1266f1 !important;");
            A8.Attributes.Add("style", "color: #1266f1 !important;");
        }

        private void ShowIT()
        {
            artado.Visible = true;
            web_results.Visible = false;
            infocard.Visible = false;
            image_results.Visible = false;

            it1.Attributes.Add("style", "color: #1266f1 !important;");
            it2.Attributes.Add("style", "color: #1266f1 !important;");
            it3.Attributes.Add("style", "color: #1266f1 !important;");
            A9.Attributes.Add("style", "color: #1266f1 !important;");
        }

        private void ApplyCustomizations()
        {
            // Custom Theme
            var custom = HttpContext.Current.Request.Cookies["CustomTheme"];
            if (custom?.Value != null)
            {
                foreach (string item in custom.Values)
                {
                    string path = custom.Values[item];
                    Page.Header.Controls.Add(new System.Web.UI.LiteralControl($"<link rel=\"stylesheet\" type=\"text/css\" href=\"{ResolveUrl("https://devs.artado.xyz/" + path)}\" />"));
                }
            }

            // Extension
            var ext = HttpContext.Current.Request.Cookies["Extension"];
            if (ext?.Value != null)
            {
                foreach (string item in ext.Values)
                {
                    string path = ext.Values[item];
                    searchpage.Controls.Add(new System.Web.UI.LiteralControl($"<script src=\"{ResolveUrl("https://devs.artado.xyz/" + path)}\"></script>"));
                }
            }

            // Custom Icons
            var icon = HttpContext.Current.Request.Cookies["CustomIcon"];
            if (icon?.Value != null)
            {
                Image1.Src = "https://devs.artado.xyz/" + icon.Value;
            }

            // Custom CSS
            var customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
            if (customcss?.Value != null)
            {
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl($"<style>{Server.UrlDecode(customcss.Value)}</style>"));
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
            string type = Request.QueryString["type"];
            if (type == null)
                type = "web";
            Response.Redirect("/search?i=" + HttpUtility.UrlEncode(searchinput.Text) + "&type=" + type);
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
        //All
        protected void All_Click(object sender, EventArgs e)
        {
            CreateCookie("WebResults", "All");
        }

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
        public async void Web(string query, HttpCookie source, Wiki wiki, Movie movie)
        {
            web_results.Visible = true;
            image_results.Visible = false;

            w1.Attributes.Add("style", "color: #1266f1 !important;");
            w2.Attributes.Add("style", "color: #1266f1 !important;");
            w3.Attributes.Add("style", "color: #1266f1 !important;");
            A.Attributes.Add("style", "color: #1266f1 !important;");

            int currentPage = 0;
            if (Request.QueryString["p"] != null)
            {
                currentPage = int.Parse(Request.QueryString["p"]);
            }

            HttpCookie proxy = HttpContext.Current.Request.Cookies["Proxy"];
            HttpCookie ads_cookie = HttpContext.Current.Request.Cookies["Ads"];

            #region Personalized Ads
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

            System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string lang = kultur.TwoLetterISOLanguageName;
            #endregion

            string url = string.Empty;

            if (source != null && source.Value != null)
            {
                switch (source.Value)
                {
                    case "All":
                        AllWeb(query, currentPage, ads_cookie, countrycode, lang, id, proxy);
                        break;

                    case "Google":
                        Google_B.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

                        try
                        {
                            google.Visible = false;
                            others.Visible = false;
                            languageDropDown.Visible = false;
                            artado.Visible = true;
                            att.Visible = false;

                            url = string.Empty;

                            if (proxy != null && proxy.Value != null)
                            {
                                string cacheKey = string.Format("{0}_{1}_{2}", query, "google", currentPage);

                                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                                if (cache_memo != null)
                                {
                                    DataTable results = new DataTable();

                                    results.Columns.Add("Title", typeof(string));
                                    results.Columns.Add("Description", typeof(string));
                                    results.Columns.Add("DisplayUrl", typeof(string));
                                    results.Columns.Add("Url", typeof(string));
                                    results.Columns.Add("Source", typeof(string));

                                    List<Result> all_results = cache_memo;

                                    foreach (var result in all_results)
                                    {
                                        results.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                                    }

                                    AllResults.DataSource = results;
                                    AllResults.DataBind();
                                }
                                else
                                {
                                    url = proxy.Value + "api?q=" + query + "&number=" + currentPage + "&source=google";
                                    DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                                    AllResults.DataSource = results;
                                    AllResults.DataBind();
                                }
                            }
                            else
                            {
                                string cacheKey = string.Format("{0}_{1}_{2}", query, "google", currentPage);

                                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                                if (cache_memo != null)
                                {
                                    DataTable results = new DataTable();

                                    results.Columns.Add("Title", typeof(string));
                                    results.Columns.Add("Description", typeof(string));
                                    results.Columns.Add("DisplayUrl", typeof(string));
                                    results.Columns.Add("Url", typeof(string));
                                    results.Columns.Add("Source", typeof(string));

                                    List<Result> all_results = cache_memo;

                                    foreach (var result in all_results)
                                    {
                                        results.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                                    }

                                    AllResults.DataSource = results;
                                    AllResults.DataBind();
                                }
                                else if(await tor == false)
                                {
                                    int maxRetries = 3;
                                    int attempt = 0;

                                    while (attempt < maxRetries)
                                    {
                                        try
                                        {
                                            string sql_url = "SELECT TOP (1) Url FROM Proxies ORDER BY NEWID();";

                                            //Connection String
                                            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
                                            SqlConnection connection = new SqlConnection(con);
                                            SqlCommand command = new SqlCommand(sql_url, connection);
                                            connection.Open();
                                            string proxy_url = (string)command.ExecuteScalar();

                                            url = proxy_url + "api?q=" + query + "&number=" + currentPage + "&source=google";
                                            DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                                            AllResults.DataSource = results;
                                            AllResults.DataBind();
                                            break;
                                        }
                                        catch
                                        {
                                            attempt++;
                                        }
                                    }
                                }

                                if (AllResults.Items.Count == 0)
                                {
                                    Google_B.Font.Bold = true;
                                    google.Visible = true;
                                    googlejs.Visible = true;
                                    others.Visible = false;
                                    artado.Visible = false;

                                    GoogleToken.ChangeToken();
                                }
                            }
                        }
                        catch
                        {
                            Google_B.Font.Bold = true;
                            google.Visible = true;
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
                        pages.Visible = false;

                        Button1.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

                        if (ads_cookie == null || ads_cookie.Value == "Enable")
                        {
                            DataTable allads = Ads.dt(Ads.Json(countrycode, lang, query, id), query, id);
                            if (allads != null && allads.Rows.Count >= 1)
                            {
                                DataTable ads = allads.AsEnumerable().Take(2).CopyToDataTable();
                                Sponsors.DataSource = ads;
                                Sponsors.DataBind();
                            }
                        }

                        //Result lang
                        HttpCookie cookie = HttpContext.Current.Request.Cookies["result_lang"];

                        if (cookie != null && cookie.Value != null)
                        {
                            artado_results.DataSource = ResultsClass.Artado(query, 20, cookie.Value, "desc");
                        }
                        else
                        {
                            artado_results.DataSource = ResultsClass.Artado(query, 20, null, "desc");
                        }
                        artado_results.DataBind();
                        break;

                    case "Bing":
                        Button2.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

                        google.Visible = false;
                        others.Visible = false;
                        languageDropDown.Visible = false;
                        artado.Visible = true;
                        att.Visible = false;

                        if (proxy != null && proxy.Value != null)
                        {
                            string cacheKey = string.Format("{0}_{1}_{2}", query, "bing", currentPage);

                            var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                            if (cache_memo != null)
                            {
                                DataTable bingresults = new DataTable();

                                bingresults.Columns.Add("Title", typeof(string));
                                bingresults.Columns.Add("Description", typeof(string));
                                bingresults.Columns.Add("DisplayUrl", typeof(string));
                                bingresults.Columns.Add("Url", typeof(string));
                                bingresults.Columns.Add("Source", typeof(string));

                                List<Result> all_results = cache_memo;

                                foreach (var result in all_results)
                                {
                                    bingresults.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                                }

                                AllResults.DataSource = bingresults;
                                AllResults.DataBind();
                            }
                            else
                            {
                                url = proxy.Value + "api?q=" + query + "&number=" + currentPage + "&source=bing";
                                DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                                AllResults.DataSource = results;
                                AllResults.DataBind();
                            }
                        }
                        else
                        {
                            string cacheKey = string.Format("{0}_{1}_{2}", query, "bing", currentPage);

                            var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                            if (cache_memo != null)
                            {
                                DataTable bingresults = new DataTable();

                                bingresults.Columns.Add("Title", typeof(string));
                                bingresults.Columns.Add("Description", typeof(string));
                                bingresults.Columns.Add("DisplayUrl", typeof(string));
                                bingresults.Columns.Add("Url", typeof(string));
                                bingresults.Columns.Add("Source", typeof(string));

                                List<Result> all_results = cache_memo;

                                foreach (var result in all_results)
                                {
                                    bingresults.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                                }

                                AllResults.DataSource = bingresults;
                                AllResults.DataBind();
                            }
                            else
                            {
                                try // Try to connect from the Artado server without a proxy
                                {
                                    DataTable results = new DataTable();

                                    results.Columns.Add("Title", typeof(string));
                                    results.Columns.Add("Description", typeof(string));
                                    results.Columns.Add("DisplayUrl", typeof(string));
                                    results.Columns.Add("Url", typeof(string));
                                    results.Columns.Add("Source", typeof(string));

                                    List<Result> all_results = await ResultsClass.GetBing(query, currentPage);

                                    foreach (var result in all_results)
                                    {
                                        results.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                                    }

                                    AllResults.DataSource = results;
                                    AllResults.DataBind();
                                }
                                catch //If Artado server is not availabe, use a proxy
                                {
                                    int maxRetries = 3;
                                    int attempt = 0;

                                    while (attempt < maxRetries)
                                    {
                                        try
                                        {
                                            string sql_url = "SELECT TOP (1) Url FROM Proxies ORDER BY NEWID();";

                                            //Connection String
                                            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
                                            SqlConnection connection = new SqlConnection(con);
                                            SqlCommand command = new SqlCommand(sql_url, connection);
                                            connection.Open();
                                            string proxy_url = (string)command.ExecuteScalar();

                                            url = proxy_url + "api?q=" + query + "&number=" + currentPage + "&source=bing";
                                            DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                                            AllResults.DataSource = results;
                                            AllResults.DataBind();
                                            break;
                                        }
                                        catch
                                        {
                                            attempt++;
                                        }
                                    }
                                }

                            }

                            if (AllResults.Items.Count == 0)
                            {
                                others.Visible = true;
                                otherstxt.Text = "Proxy error. Please check the proxy settings.<br/> Proxy URL: " + url;
                            }
                        }
                        break;

                    case "Yahoo":
                        Button3.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;
                        pages.Visible = false;

                        Button3.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                    case "Youtube":
                        Button5.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;
                        pages.Visible = false;

                        Button5.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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
                        pages.Visible = false;

                        Button6.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                    case "Scholar":
                        Button8.Font.Bold = true;
                        google.Visible = false;
                        others.Visible = true;
                        artado.Visible = false;
                        pages.Visible = false;

                        Button8.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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
                        pages.Visible = false;

                        Button9.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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
                        pages.Visible = false;

                        Button10.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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
                        AllWeb(query, currentPage, ads_cookie, countrycode, lang, id, proxy);
                        break;
                }
            }
            else
            {
                AllWeb(query, currentPage, ads_cookie, countrycode, lang, id, proxy);
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

            ////Get OMDb Data
            //if (movie == null)
            //{
            //    MovieWidget.Visible = false;
            //}
            //else
            //{
            //    MovieWidget.Visible = true;
            //    Poster.Src = movie.Img;
            //    MovieTitle.Text = movie.Title;
            //    Rated.Text = movie.Rated;
            //    Year.Text = movie.Year;
            //    Runtime.Text = movie.Runtime;
            //    Genre.Text = movie.Genre;
            //    Plot.Text = movie.Plot;
            //    Director.Text = movie.Director;
            //    Writer.Text = movie.Writer;
            //    Actors.Text = movie.Actors;
            //    Awards.Text = movie.Awards;
            //    BoxOffice.Text = movie.BoxOffice;
            //}
            MovieWidget.Visible = false;
        }

        public async void AllWeb(string query, int currentPage, HttpCookie ads_cookie, string countrycode, string lang, string id, HttpCookie proxy)
        {
            All.Font.Bold = true;
            google.Visible = false;
            others.Visible = false;
            languageDropDown.Visible = false;
            artado.Visible = true;
            att.Visible = false;

            All.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

            string url = string.Empty;

            if (currentPage == 0)
            {
                artado_results.DataSource = ResultsClass.Artado(query, 3, null, "asc");
                artado_results.DataBind();
            }

            if (ads_cookie == null || ads_cookie.Value == "Enable")
            {
                DataTable allads = Ads.dt(Ads.Json(countrycode, lang, query, id), query, id);
                if (allads != null && allads.Rows.Count >= 1)
                {
                    DataTable ads = allads.AsEnumerable().Take(2).CopyToDataTable();
                    Sponsors.DataSource = ads;
                    Sponsors.DataBind();
                }
            }

            if (proxy != null && proxy.Value != null) // If a proxy is setuped
            {
                string cacheKey = string.Format("{0}_{1}_{2}", query, "all", currentPage);

                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                if (cache_memo != null)
                {
                    DataTable results = new DataTable();

                    results.Columns.Add("Title", typeof(string));
                    results.Columns.Add("Description", typeof(string));
                    results.Columns.Add("DisplayUrl", typeof(string));
                    results.Columns.Add("Url", typeof(string));
                    results.Columns.Add("Source", typeof(string));

                    List<Result> all_results = cache_memo;

                    foreach (var result in all_results)
                    {
                        results.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                    }

                    AllResults.DataSource = results;
                    AllResults.DataBind();
                }
                else
                {
                    url = proxy.Value + "api?q=" + query + "&number=" + currentPage + "&source=all";
                    DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                    artadosearch.Cache.Save(results, currentPage); // cache the results

                    AllResults.DataSource = results;
                    AllResults.DataBind();
                }

                if (AllResults.Items.Count == 0)
                {
                    others.Visible = true;
                    otherstxt.Text = "Proxy error. Please check the proxy settings.<br/> Proxy URL: " + url;
                }
            }
            else if(await tor == false)
            {
                string cacheKey = string.Format("{0}_{1}_{2}", query, "all", currentPage);

                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);

                if (cache_memo != null) //Check if memo cache has results
                {
                    DataTable results = new DataTable();

                    results.Columns.Add("Title", typeof(string));
                    results.Columns.Add("Description", typeof(string));
                    results.Columns.Add("DisplayUrl", typeof(string));
                    results.Columns.Add("Url", typeof(string));
                    results.Columns.Add("Source", typeof(string));

                    List<Result> all_results = cache_memo;

                    foreach (var result in all_results)
                    {
                        results.Rows.Add(result.Title, result.Description, result.DisplayUrl, result.Url, result.Source);
                    }

                    AllResults.DataSource = results;
                    AllResults.DataBind();
                }
                else
                {
                    //Try to connect to a random proxy
                    int maxRetries = 3;
                    int attempt = 0;

                    while (attempt < maxRetries)
                    {
                        try
                        {
                            string sql_url = "SELECT TOP (1) Url FROM Proxies ORDER BY NEWID();";

                            //Connection String
                            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
                            SqlConnection connection = new SqlConnection(con);
                            SqlCommand command = new SqlCommand(sql_url, connection);
                            connection.Open();
                            string proxy_url = (string)command.ExecuteScalar();

                            url = proxy_url + "api?q=" + query + "&number=" + currentPage + "&source=all";
                            DataTable results = ResultsClass.ConvertJsonToDataTable(ResultsClass.GetProxy(url));

                            artadosearch.Cache.Save(results, currentPage); // cache the results

                            AllResults.DataSource = results;
                            AllResults.DataBind();
                            break;
                        }
                        catch
                        {
                            attempt++;
                        }
                    }
                }

                if (AllResults.Items.Count == 0) // If the main server and the proxies do not answer try the cache
                {
                    DataTable cache_results = artadosearch.Cache.Get(query);
                    if (cache_results.Rows.Count >= 8 && currentPage == 0) //First check if the DB cache has any results
                    {
                        AllResults.DataSource = cache_results;
                        AllResults.DataBind();
                    }
                    else // DB Cache didn't worked out? use Google with JS
                    {
                        Google_B.Font.Bold = true;
                        google.Visible = true;
                        googlejs.Visible = true;
                        others.Visible = false;
                        artado.Visible = false;

                        GoogleToken.ChangeToken();
                    }
                }
            }
        }
        public void Image(string query)
        {
            web_results.Visible = false;
            artado.Visible = false;
            image_results.Visible = true;
            infocard.Visible = false;

            i1.Attributes.Add("style", "color: #1266f1 !important;");
            i2.Attributes.Add("style", "color: #1266f1 !important;");
            i3.Attributes.Add("style", "color: #1266f1 !important;");
            A4.Attributes.Add("style", "color: #1266f1 !important;");
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

            v1.Attributes.Add("style", "color: #1266f1 !important;");
            v2.Attributes.Add("style", "color: #1266f1 !important;");
            v3.Attributes.Add("style", "color: #1266f1 !important;");
            A5.Attributes.Add("style", "color: #1266f1 !important;");

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

                        Button5.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                        Button6.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                        Button6.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                Button6.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

            n1.Attributes.Add("style", "color: #1266f1 !important;");
            n2.Attributes.Add("style", "color: #1266f1 !important;");
            n3.Attributes.Add("style", "color: #1266f1 !important;");
            A6.Attributes.Add("style", "color: #1266f1 !important;");
            buttons_r.Visible = false;

            int currentPage;
            Button10.Font.Bold = true;
            google.Visible = false;
            others.Visible = true;
            artado.Visible = false;

            Button10.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

            a1.Attributes.Add("style", "color: #1266f1 !important;");
            a2.Attributes.Add("style", "color: #1266f1 !important;");
            a3.Attributes.Add("style", "color: #1266f1 !important;");
            a10.Attributes.Add("style", "color: #1266f1 !important;");

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

                        Button8.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                        Button9.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                        Button9.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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

                Button9.Attributes.Add("style", "color: #1266f1 !important; border-color: #1266f1;");

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
    }
}
