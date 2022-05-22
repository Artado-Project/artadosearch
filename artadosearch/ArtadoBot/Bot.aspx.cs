using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public partial class ArtadoBot_Bot : System.Web.UI.Page
{
    //Connection
    string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
    SqlConnection baglanti = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        baglanti.ConnectionString = admin;

        string mode = Request.QueryString["mode"];
        string url = Request.QueryString["url"];
        string source = Request.QueryString["source"];
        string lang = Request.QueryString["lang"];
        if(mode == "search")
        {
            for (int i = 1988; i < 3341; i++)
            {
                try
                {
                    string sorgu = "SELECT Link from arda.Sonuçlar where ID='" + i + "'";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    Bot((string)komut.ExecuteScalar().ToString());
                    SqlConnection.ClearPool(baglanti);
                    baglanti.Close();
                }
                catch
                {
                    i++;
                }
            }
        }
        else if (mode == "searchlike")
        {
            Bot(url);
        }
        else if (mode == "news")
        {
            //Türk Medyası
            getnews("https://www.milliyet.com.tr/", "Milliyet", "tr");
            getnews("https://www.haberturk.com/", "Habertürk", "tr");
            getnews("https://www.sozcu.com.tr/", "Sözcü", "tr");
            getnews("https://www.korkusuz.com.tr/", "Korkusuz", "tr");
            getnews("https://www.yenicaggazetesi.com.tr/", "Yeniçağ", "tr");
            getnews("https://www.cumhuriyet.com.tr/", "Cumhuriyet", "tr");
            getnews("https://www.milligazete.com.tr/", "Milli Gazete", "tr");
            getnews("https://www.birgun.net/", "BirGün", "tr");
            getnews("https://medyascope.tv/", "Medyascope", "tr");
            getnews("https://t24.com.tr/", "T24", "tr");
            getnews("https://tr.euronews.com/", "Euronews", "tr");

            //Ulusal Medya
            getnews("https://edition.cnn.com/", "CNN", "en");
            getnews("https://www.msn.com/en-us/news", "MSN", "en");
            getnews("https://www.theguardian.com/international", "Guardian", "en");
            getnews("https://www.bbc.com/news", "BBC", "en");
            getnews("https://www.nbcnews.com/", "NBC", "en");
            getnews("https://news.yahoo.com/", "Yahoo News", "en");
            getnews("https://nypost.com/", "New York Post", "en");
            getnews("https://www.washingtonpost.com/", "Washington Post", "en");
            getnews("https://www.euronews.com/", "Euronews", "en");
       
            //İtalyan Medya
            getnews("https://www.lercio.it/", "Lercio", "it");
            getnews("https://www.rainews.it/", "RaiNews", "it");
            getnews("https://it.euronews.com/", "Euronews", "it");
            getnews("https://www.ilpost.it/", "ilPost", "it");

            //Fransız Medyası
            getnews("https://www.france24.com/fr/", "France 24", "fr");
            getnews("https://www.francesoir.fr/", "FranceSoir", "fr");
            getnews("https://www.rfi.fr/fr/", "RFI", "fr");
            getnews("https://fr.euronews.com/", "Euronews", "fr");

            //Asya Medyası
            getnews("https://www.channelnewsasia.com/", "CNA", "en");
        }
        else if (mode == "news_widget")
        {
            BotforNews(url, source, lang);
        }
    }

    public void Bot(string url)
    {
        try
        {
            url = url.Trim();
            Link.Text = url;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
            request.UserAgent = "ArtadoBot";

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string htmlText = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //Robots.txt
            string metarobots = "<meta name=\"robots\" content=\"noindex\" />";
            string metarobots2 = "<meta name=\"robots\" content=\"noindex\"/>";
            string metarobots3 = "<meta name=\"robots\" content=\"noindex\">";

            int robocontrol = htmlText.IndexOf(metarobots);
            int robocontrol2 = htmlText.IndexOf(metarobots2);
            int robocontrol3 = htmlText.IndexOf(metarobots3);
            if (robocontrol >= 0 || robocontrol2 >= 0 || robocontrol3 >= 0)
            {
                Response.Write("Bu site indekslenemez. (Robots.txt)");
            }
            else
            {
                //Title
                int title = htmlText.IndexOf("<title>".ToLower()) + 7;
                int titleend = htmlText.Substring(title).IndexOf("</title>");
                string titletext = htmlText.Substring(title, titleend);
                Title.Text = titletext;

                SqlCommand cmd = new SqlCommand("select * from arda.Sonuçlar where Link='" + url + "' or Title='"+ titletext +"'", baglanti);
                SqlDataReader reading = cmd.ExecuteReader();
                if (reading.Read())
                {
                    reading.Close();
                    //Meta Description
                    string desc;
                    string metadesc = "<meta name=\"description\" content=\"";

                    int index = htmlText.IndexOf(metadesc);
                    try
                    {
                        if (index >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metadesc) + metadesc.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\"");
                            desc = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            desc = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        try
                        {
                            int baslangic = htmlText.IndexOf("<span>") + 6;
                            int bitis = htmlText.Substring(baslangic).IndexOf("</span>");
                            desc = htmlText.Substring(baslangic, bitis);
                        }
                        catch
                        {
                            Response.Write(hata);
                            desc = "";
                        }
                    }
                    Desc.Text = desc;

                    //Meta Keywords
                    string key;
                    string metakey = "<meta name=\"keywords\" content=\"";

                    int index2 = htmlText.IndexOf(metakey);
                    try
                    {
                        if (index2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metakey) + metakey.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            key = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            key = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        key = "";
                    }
                    Keywords.Text = key;

                    //Favicon
                    string favicon;
                    string metafavicon = "<link rel=\"shortcut icon\" href=\"";
                    string metafavicon2 = "<link rel=\"icon\" href=\"";

                    int index3 = htmlText.IndexOf(metafavicon);
                    int index3_2 = htmlText.IndexOf(metafavicon2);
                    try
                    {
                        if (index3 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon) + metafavicon.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.EndsWith("type=\"image/png"))
                            {
                                favicon = favicon.Replace("type=\"image/png", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim() + favicon.Trim();
                            }
                        }
                        else if (index3_2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon2) + metafavicon2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }

                            if (favicon.EndsWith("sizes=\"192x192\""))
                            {
                                favicon = favicon.Replace("sizes=\"192x192\"", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim() + favicon.Trim();
                            }
                        }
                        else
                        {
                            favicon = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        favicon = "";
                        Response.Write(hata);
                    }
                    Favicon.ImageUrl = favicon;

                    //Lang
                    string lang;
                    string htmllang = "<html lang=\"";
                    string htmllang2 = "<meta name=\"language\" content=\"";

                    int index4 = htmlText.IndexOf(htmllang);
                    int index4_1 = htmlText.IndexOf(htmllang2);
                    try
                    {
                        if (index4 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang) + htmllang.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else if(index4_1 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang2) + htmllang2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            lang = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        lang = "";
                    }
                    Lang.Text = lang;

                    //Ranking
                    int rank = 0;

                    string mobile = "<meta name=\"viewport\"";
                    int rankindex = htmlText.IndexOf(mobile);

                    if (rankindex >= 0)
                    {
                        rank += 10;
                    }

                    string css = "<link rel=\"stylesheet\"";
                    int rankindex2 = htmlText.IndexOf(css);

                    if (rankindex2 >= 0)
                    {
                        rank += 10;
                    }

                    string utf8 = "<meta charset=\"utf - 8\" />";
                    int rankindex3 = htmlText.IndexOf(utf8.ToLower());

                    if (rankindex3 >= 0)
                    {
                        rank += 10;
                    }

                    string js = "<script type=\"text/javascript\"";
                    int rankindex4 = htmlText.IndexOf(js.ToLower());

                    if (rankindex4 >= 0)
                    {
                        rank += 10;
                        js = "true";
                    }
                    else
                    {
                        js = "false";
                    }

                    string aspnet = "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\"";
                    int rankindex5 = htmlText.IndexOf(aspnet.ToLower());

                    if (rankindex5 >= 0)
                    {
                        rank += 10;
                        aspnet = "true";
                    }
                    else
                    {
                        aspnet = "false";
                    }

                    string com = ".com";
                    int rankindex6 = url.IndexOf(com);

                    string xyz = ".xyz";
                    int rankindex7 = url.IndexOf(xyz);

                    string gov = ".gov";
                    int rankindex8 = url.IndexOf(gov);

                    string org = ".org";
                    int rankindex9 = url.IndexOf(org);

                    string net = ".net";
                    int rankindex10 = url.IndexOf(net);

                    if (rankindex6 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex7 >= 0)
                    {
                        rank += 20;
                    }
                    else if (rankindex8 >= 0)
                    {
                        rank += 40;
                    }
                    else if (rankindex9 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex10 >= 0)
                    {
                        rank += 20;
                    }
                    else
                    {
                        rank -= 10;
                    }
                    //Category
                    string category = "site";

                    //For News
                    string news = "news";
                    int category1 = titletext.IndexOf(news);
                    string news_tr = "haberler";
                    int category2 = titletext.IndexOf(news_tr);
                    string news2 = "news";
                    int category3 = key.IndexOf(news2);
                    string news2_tr = "haber";
                    int category4 = key.IndexOf(news2_tr);
                    string news3 = "news";
                    int category5 = desc.IndexOf(news3);
                    string news3_tr = "haber";
                    int category6 = desc.IndexOf(news3_tr);

                    if (category1 >= 0 || category1 >= 0 || category3 >= 0 || category4 >= 0 || category5 >= 0 || category6 >= 0)
                    {
                        category = "news";
                    }

                    //For Videos
                    string video = "video";
                    int videocategory = desc.IndexOf(video);
                    int videocategory2 = key.IndexOf(video);
                    string yt = "youtube.com";
                    int ytcategory = url.IndexOf(yt);
                    string dailymotion = "dailymotion.com";
                    int dmcategory = url.IndexOf(dailymotion);
                    string izlesene = "izlesene.com";
                    int izlesenecategory = url.IndexOf(izlesene);
                    string ted = "ted.com";
                    int tedcategory = url.IndexOf(ted);
                    string open = "open-video.org";
                    int opencategory = url.IndexOf(open);
                    string ninegag = "9gag.com";
                    int gagcategory = url.IndexOf(ninegag);
                    string utreon = "utreon.com";
                    int utreoncategory = url.IndexOf(utreon);
                    string twitch = "twitch.tv";
                    int twitchcategory = url.IndexOf(twitch);

                    if (videocategory >= 0 || videocategory2 >= 0 || ytcategory >= 0 || dmcategory >= 0 || izlesenecategory >= 0 || tedcategory >= 0 || opencategory >= 0 || gagcategory >= 0 || utreoncategory >= 0 || twitchcategory >= 0)
                    {
                        category = "videos";
                    }

                    //For Social Media
                    string insta = "instagram.com";
                    int icategory = url.IndexOf(insta);
                    string tw = "twitter.com";
                    int twcategory = url.IndexOf(tw);
                    string r = "reddit.com";
                    int rcategory = url.IndexOf(r);
                    string fb = "facebook.com";
                    int fbcategory = url.IndexOf(fb);
                    string vk = "vk.com";
                    int vkcategory = url.IndexOf(vk);
                    string pin = "pinterest.com";
                    int pincategory = url.IndexOf(pin);
                    string tumblr = "tumblr.com";
                    int tumblrcategory = url.IndexOf(tumblr);
                    string qzone = "qzone.qq.com";
                    int qqcategory = url.IndexOf(qzone);
                    string quora = "quora.com";
                    int quoracategory = url.IndexOf(quora);
                    string kua = "kuaishou.com";
                    int kuacategory = url.IndexOf(kua);
                    string yaay = "yaay.com";
                    int ycategory = url.IndexOf(yaay);

                    if (icategory >= 0 || twcategory >= 0 || rcategory >= 0 || fbcategory >= 0 || vkcategory >= 0 || pincategory >= 0 || tumblrcategory >= 0 || qqcategory >= 0 || quoracategory >= 0 || kuacategory >= 0 || ycategory >= 0)
                    {
                        category = "social media";
                    }

                    //Save to database
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string istek = "update arda.Sonuçlar set Title = @Title, Link = @Link, Content1 = @Content1, Keywords = @Keywords, favicon = @favicon, Category = @Category, Date = @Date, Lang = @Lang, asp = @asp, js = @js where Link = '" + url + "'";
                    SqlCommand komut = new SqlCommand(istek, baglanti);
                    komut.Parameters.AddWithValue("@Title", titletext);
                    komut.Parameters.AddWithValue("@Link", url.Trim());
                    komut.Parameters.AddWithValue("@Content1", desc);
                    komut.Parameters.AddWithValue("@Keywords", key);
                    komut.Parameters.AddWithValue("@favicon", favicon);
                    komut.Parameters.AddWithValue("@Category", category);
                    komut.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    komut.Parameters.AddWithValue("@Lang", lang);
                    komut.Parameters.AddWithValue("@asp", aspnet);
                    komut.Parameters.AddWithValue("@js", js);
                    komut.ExecuteNonQuery();

                    //Links
                    List<string> links = new List<string>();

                    string a = "<a".ToLower();
                    string href = "href=\"".ToLower();
                    string nofollow = "nofollow".ToLower();

                    int index5 = htmlText.IndexOf(a);
                    int abaslangic = htmlText.IndexOf(a) + a.Length;
                    int abitis = htmlText.Substring(abaslangic).IndexOf("\"");
                    string atext = htmlText.Substring(abaslangic, abitis);

                    int aindex6 = atext.IndexOf(nofollow);
                    int index7 = atext.IndexOf(href);
                    try
                    {
                        while (index5 >= 0 & aindex6 < 0)
                        {
                            htmlText = htmlText.Substring(index5);

                            int baslangic = htmlText.IndexOf(href) + a.Length + href.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\"");
                            string test = htmlText.Substring(baslangic, bitis);
                            links.Add(test);

                            if (a.Length < htmlText.Length)
                            {
                                index5 = htmlText.IndexOf(a, a.Length);
                            }
                            else
                            {
                                index5 = -1;
                            }
                            ListBox1.DataSource = links;

                            //For other links
                            int index6 = test.IndexOf(nofollow);

                            SqlCommand cmd2 = new SqlCommand("select * from arda.Sonuçlar where Link='" + test + "'", baglanti);
                            SqlDataReader reading2 = cmd2.ExecuteReader();
                            if (reading2.Read())
                            {
                                reading2.Close();
                                return;
                            }
                            else
                            {
                                if (index6 >= 0)
                                {
                                    return;
                                }
                                else if (test.StartsWith("http"))
                                {
                                    Bot(test);
                                }
                                else if (test.StartsWith("/"))
                                {
                                    Bot(url + test);
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error);
                    }
                }
                else
                {
                    //Meta Description
                    string desc;
                    string metadesc = "<meta name=\"description\" content=\"";

                    int index = htmlText.IndexOf(metadesc);
                    try
                    {
                        if (index >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metadesc) + metadesc.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            desc = htmlText.Substring(baslangic, bitis);

                            if (desc.Length > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                                desc = htmlText.Substring(baslangic, bitis);
                            }

                            if (desc.Length > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\"/>");
                                desc = htmlText.Substring(baslangic, bitis);
                            }
                        }
                        else
                        {
                            desc = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        desc = "";
                    }
                    Desc.Text = desc;

                    //Meta Keywords
                    string key;
                    string metakey = "<meta name=\"keywords\" content=\"";

                    int index2 = htmlText.IndexOf(metakey);
                    try
                    {
                        if (index2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metakey) + metakey.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            key = htmlText.Substring(baslangic, bitis - baslangic);
                        }
                        else
                        {
                            key = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        key = "";
                    }
                    Keywords.Text = key;

                    //Favicon
                    string favicon;
                    string metafavicon = "<link rel=\"shortcut icon\" href=\"";
                    string metafavicon2 = "<link rel=\"icon\" href=\"";

                    int index3 = htmlText.IndexOf(metafavicon);
                    int index3_2 = htmlText.IndexOf(metafavicon2);
                    try
                    {
                        if (index3 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon) + metafavicon.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.EndsWith("type=\"image/png"))
                            {
                                favicon = favicon.Replace("type=\"image/png", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim()+ favicon.Trim();
                            }
                        }
                        else if (index3_2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon2) + metafavicon2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }

                            if (favicon.EndsWith("sizes=\"192x192\""))
                            {
                                favicon = favicon.Replace("sizes=\"192x192\"", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim() + favicon.Trim();
                            }
                        }
                        else
                        {
                            favicon = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        favicon = "";
                        Response.Write(hata);
                    }
                    Favicon.ImageUrl = favicon;

                    //Lang
                    string lang;
                    string htmllang = "<html lang=\"";
                    string htmllang2 = "<meta name=\"language\" content=\"";

                    int index4 = htmlText.IndexOf(htmllang);
                    int index4_1 = htmlText.IndexOf(htmllang2);
                    try
                    {
                        if (index4 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang) + htmllang.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else if (index4_1 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang2) + htmllang2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            lang = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        lang = "";
                    }
                    Lang.Text = lang;

                    //Ranking
                    int rank = 0;

                    string mobile = "<meta name=\"viewport\"";
                    int rankindex = htmlText.IndexOf(mobile);

                    if (rankindex >= 0)
                    {
                        rank += 10;
                    }

                    string css = "<link rel=\"stylesheet\"";
                    int rankindex2 = htmlText.IndexOf(css);

                    if (rankindex2 >= 0)
                    {
                        rank += 10;
                    }

                    string utf8 = "<meta charset=\"utf - 8\" />";
                    int rankindex3 = htmlText.IndexOf(utf8.ToLower());

                    if (rankindex3 >= 0)
                    {
                        rank += 10;
                    }

                    string js = "<script type=\"text/javascript\"";
                    int rankindex4 = htmlText.IndexOf(js.ToLower());

                    if (rankindex4 >= 0)
                    {
                        rank += 10;
                        js = "true";
                    }
                    else
                    {
                        js = "false";
                    }

                    string aspnet = "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\"";
                    int rankindex5 = htmlText.IndexOf(aspnet.ToLower());

                    if (rankindex5 >= 0)
                    {
                        rank += 10;
                        aspnet = "true";
                    }
                    else
                    {
                        aspnet = "false";
                    }

                    string com = ".com";
                    int rankindex6 = url.IndexOf(com);

                    string xyz = ".xyz";
                    int rankindex7 = url.IndexOf(xyz);

                    string gov = ".gov";
                    int rankindex8 = url.IndexOf(gov);

                    string org = ".org";
                    int rankindex9 = url.IndexOf(org);

                    string net = ".net";
                    int rankindex10 = url.IndexOf(net);

                    if (rankindex6 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex7 >= 0)
                    {
                        rank += 20;
                    }
                    else if (rankindex8 >= 0)
                    {
                        rank += 40;
                    }
                    else if (rankindex9 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex10 >= 0)
                    {
                        rank += 20;
                    }
                    else
                    {
                        rank -= 10;
                    }
                    //Category
                    string category = "site";

                    //For News
                    string news = "news";
                    int category1 = titletext.IndexOf(news);
                    string news_tr = "haberler";
                    int category2 = titletext.IndexOf(news_tr);
                    string news2 = "news";
                    int category3 = key.IndexOf(news2);
                    string news2_tr = "haber";
                    int category4 = key.IndexOf(news2_tr);
                    string news3 = "news";
                    int category5 = desc.IndexOf(news3);
                    string news3_tr = "haber";
                    int category6 = desc.IndexOf(news3_tr);

                    if (category1 >= 0 || category1 >= 0 || category3 >= 0 || category4 >= 0 || category5 >= 0 || category6 >= 0)
                    {
                        category = "news";
                    }

                    //For Videos
                    string video = "video";
                    int videocategory = desc.IndexOf(video);
                    int videocategory2 = key.IndexOf(video);
                    string yt = "youtube.com";
                    int ytcategory = url.IndexOf(yt);
                    string dailymotion = "dailymotion.com";
                    int dmcategory = url.IndexOf(dailymotion);
                    string izlesene = "izlesene.com";
                    int izlesenecategory = url.IndexOf(izlesene);
                    string ted = "ted.com";
                    int tedcategory = url.IndexOf(ted);
                    string open = "open-video.org";
                    int opencategory = url.IndexOf(open);
                    string ninegag = "9gag.com";
                    int gagcategory = url.IndexOf(ninegag);
                    string utreon = "utreon.com";
                    int utreoncategory = url.IndexOf(utreon);
                    string twitch = "twitch.tv";
                    int twitchcategory = url.IndexOf(twitch);

                    if (videocategory >= 0 || videocategory2 >= 0 || ytcategory >= 0 || dmcategory >= 0 || izlesenecategory >= 0 || tedcategory >= 0 || opencategory >= 0 || gagcategory >= 0 || utreoncategory >= 0 || twitchcategory >= 0)
                    {
                        category = "videos";
                    }

                    //For Social Media
                    string insta = "instagram.com";
                    int icategory = url.IndexOf(insta);
                    string tw = "twitter.com";
                    int twcategory = url.IndexOf(tw);
                    string r = "reddit.com";
                    int rcategory = url.IndexOf(r);
                    string fb = "facebook.com";
                    int fbcategory = url.IndexOf(fb);
                    string vk = "vk.com";
                    int vkcategory = url.IndexOf(vk);
                    string pin = "pinterest.com";
                    int pincategory = url.IndexOf(pin);
                    string tumblr = "tumblr.com";
                    int tumblrcategory = url.IndexOf(tumblr);
                    string qzone = "qzone.qq.com";
                    int qqcategory = url.IndexOf(qzone);
                    string quora = "quora.com";
                    int quoracategory = url.IndexOf(quora);
                    string kua = "kuaishou.com";
                    int kuacategory = url.IndexOf(kua);
                    string yaay = "yaay.com";
                    int ycategory = url.IndexOf(yaay);

                    if (icategory >= 0 || twcategory >= 0 || rcategory >= 0 || fbcategory >= 0 || vkcategory >= 0 || pincategory >= 0 || tumblrcategory >= 0 || qqcategory >= 0 || quoracategory >= 0 || kuacategory >= 0 || ycategory >= 0)
                    {
                        category = "social media";
                    }

                    //Save to database
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string istek = "insert into arda.Sonuçlar(Title, Link, Content1, Keywords, Rank, favicon, Category, Date, Lang, asp, js) values (@Title, @Link, @Content1, @Keywords, @Rank, @favicon, @Category, @Date, @Lang, @asp, @js)";
                    SqlCommand komut = new SqlCommand(istek, baglanti);
                    komut.Parameters.AddWithValue("@Title", titletext);
                    komut.Parameters.AddWithValue("@Link", url);
                    komut.Parameters.AddWithValue("@Content1", desc);
                    komut.Parameters.AddWithValue("@Keywords", key);
                    komut.Parameters.AddWithValue("@Rank", rank);
                    komut.Parameters.AddWithValue("@favicon", favicon);
                    komut.Parameters.AddWithValue("@Category", category);
                    komut.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    komut.Parameters.AddWithValue("@Lang", lang);
                    komut.Parameters.AddWithValue("@asp", aspnet);
                    komut.Parameters.AddWithValue("@js", js);
                    komut.ExecuteNonQuery();

                    //Links
                    List<string> links = new List<string>();

                    string a = "<a href=\"".ToLower();
                    string nofollow = "nofollow".ToLower();

                    int index5 = htmlText.IndexOf(a);
                    try
                    {
                        while (index5 >= 0)
                        {
                            htmlText = htmlText.Substring(index5);

                            int baslangic = htmlText.IndexOf(a) + a.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\"");
                            string test = htmlText.Substring(baslangic, bitis);
                            links.Add(test);

                            if (a.Length < htmlText.Length)
                            {
                                index5 = htmlText.IndexOf(a, a.Length);
                            }
                            else
                            {
                                index5 = -1;
                            }
                            ListBox1.DataSource = links;

                            //For other links
                            int index6 = test.IndexOf(nofollow);
                            SqlCommand cmd2 = new SqlCommand("select * from arda.Sonuçlar where Link='" + test + "'", baglanti);
                            SqlDataReader reading2 = cmd2.ExecuteReader();
                            if (reading2.Read())
                            {
                                reading2.Close();
                                return;
                            }
                            else
                            {
                                if (index6 >= 0)
                                {
                                    return;
                                }
                                else if (test.StartsWith("http"))
                                {
                                    Bot(test);
                                }
                                else if (test.StartsWith("/"))
                                {
                                    Bot(url + test);
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error);
                    }
                }
            }
        }
        catch (Exception hata)
        {
            Response.Write(hata.ToString());
        }
    }

    public void getnews(string url, string source, string lang)
    {
        SqlConnection baglanti = new SqlConnection(admin);
        baglanti.Open();
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
        request.UserAgent = "ArtadoBot News";
        WebResponse response = request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string htmlText = reader.ReadToEnd();
        reader.Close();
        response.Close();

        List<string> links = new List<string>();

        string a = "<a".ToLower();
        string href = "href=\"".ToLower();
        string nofollow = "nofollow".ToLower();

        int index5 = htmlText.IndexOf(a);
        int abaslangic = htmlText.IndexOf(a) + a.Length;
        int abitis = htmlText.Substring(abaslangic).IndexOf("\"");
        string atext = htmlText.Substring(abaslangic, abitis);

        int index6 = atext.IndexOf(nofollow);
        int index7 = atext.IndexOf(href);
        try
        {
            while (index5 >= 0 & index6 < 0)
            {
                htmlText = htmlText.Substring(index5);

                int baslangic = htmlText.IndexOf(href) + a.Length + href.Length;
                int bitis = htmlText.Substring(baslangic).IndexOf("\"");
                string test = htmlText.Substring(baslangic, bitis);
                links.Add(test);

                if (a.Length < htmlText.Length)
                {
                    index5 = htmlText.IndexOf(a, a.Length);
                }
                else
                {
                    index5 = -1;
                }

                //For other links
                int index8 = test.IndexOf(nofollow);
                SqlCommand cmd2 = new SqlCommand("select * from arda.Sonuçlar where Link='" + test + "'", baglanti);
                SqlDataReader reading2 = cmd2.ExecuteReader();
                if (reading2.Read())
                {
                    reading2.Close();
                    return;
                }
                else
                {
                    if (index8 >= 0)
                    {
                        return;
                    }
                    else if (test.StartsWith("http"))
                    {
                        BotforNews(test, source, lang);
                    }
                    else if (test.StartsWith("/"))
                    {
                        BotforNews(url + test, source, lang);
                    }
                }
            }
            baglanti.Close();
        }
        catch (Exception error)
        {
            Response.Write(error);
        }
    }

    public void BotforNews(string url, string source, string lang)
    {
        SqlConnection baglanti = new SqlConnection(admin);
        baglanti.Open();
        try
        {
            url = url.Trim();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
            request.UserAgent = "ArtadoBot";

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string htmlText = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //Robots.txt
            string metarobots = "<meta name=\"robots\" content=\"noindex\" />";
            string metarobots2 = "<meta name=\"robots\" content=\"noindex\"/>";
            string metarobots3 = "<meta name=\"robots\" content=\"noindex\">";

            int robocontrol = htmlText.IndexOf(metarobots);
            int robocontrol2 = htmlText.IndexOf(metarobots2);
            int robocontrol3 = htmlText.IndexOf(metarobots3);
            if (robocontrol >= 0 || robocontrol2 >= 0 || robocontrol3 >= 0)
            {

            }
            else
            {
                //Title
                int title = htmlText.IndexOf("<title>".ToLower()) + 7;
                int titleend = htmlText.Substring(title).IndexOf("</title>");
                string titletext = htmlText.Substring(title, titleend);

                SqlCommand cmd = new SqlCommand("select * from arda.Sonuçlar where Link='" + url + "' or Title='" + titletext + "'", baglanti);
                SqlDataReader reading = cmd.ExecuteReader();
                if (reading.Read())
                {
                    reading.Close();
                    //Meta Description
                    string desc;
                    string metadesc = "<meta name=\"description\" content=\"";

                    int index = htmlText.IndexOf(metadesc);
                    try
                    {
                        if (index >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metadesc) + metadesc.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\"");
                            desc = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            desc = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        try
                        {
                            int baslangic = htmlText.IndexOf("<span>") + 6;
                            int bitis = htmlText.Substring(baslangic).IndexOf("</span>");
                            desc = htmlText.Substring(baslangic, bitis);
                        }
                        catch
                        {
                            Response.Write(hata);
                            desc = "";
                        }
                    }

                    //Meta Keywords
                    string key;
                    string metakey = "<meta name=\"keywords\" content=\"";

                    int index2 = htmlText.IndexOf(metakey);
                    try
                    {
                        if (index2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metakey) + metakey.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            key = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            key = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        key = "";
                    }

                    //Favicon
                    string favicon;
                    string metafavicon = "<link rel=\"shortcut icon\" href=\"";
                    string metafavicon2 = "<link rel=\"icon\" href=\"";

                    int index3 = htmlText.IndexOf(metafavicon);
                    int index3_2 = htmlText.IndexOf(metafavicon2);
                    try
                    {
                        if (index3 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon) + metafavicon.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.EndsWith("type=\"image/png"))
                            {
                                favicon = favicon.Replace("type=\"image/png", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim() + favicon.Trim();
                            }
                        }
                        else if (index3_2 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(metafavicon2) + metafavicon2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            favicon = htmlText.Substring(baslangic, bitis);
                            int control = favicon.IndexOf(url);

                            if (favicon.StartsWith("http") || control >= 0)
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }

                            if (favicon.EndsWith("sizes=\"192x192\""))
                            {
                                favicon = favicon.Replace("sizes=\"192x192\"", "");
                            }
                            else if (favicon.EndsWith("type=\"image/x-icon"))
                            {
                                favicon = favicon.Replace("type=\"image/x-icon", "");
                            }

                            else if (favicon.StartsWith("//"))
                            {
                                favicon = htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("/"))
                            {
                                favicon = url.Trim() + htmlText.Substring(baslangic, bitis);
                            }
                            else if (favicon.StartsWith("./"))
                            {
                                favicon = favicon.Replace("\"", "");
                                favicon = url.Trim() + favicon.Trim();
                            }
                        }
                        else
                        {
                            favicon = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        favicon = "";
                        Response.Write(hata);
                    }

                    //Lang
                    string hlang;
                    string htmllang = "<html lang=\"";
                    string htmllang2 = "<meta name=\"language\" content=\"";

                    int index4 = htmlText.IndexOf(htmllang);
                    int index4_1 = htmlText.IndexOf(htmllang2);
                    try
                    {
                        if (index4 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang) + htmllang.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            hlang = htmlText.Substring(baslangic, bitis);
                        }
                        else if (index4_1 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang2) + htmllang2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            hlang = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            hlang = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        hlang = "";
                    }

                    //Ranking
                    int rank = 0;

                    string mobile = "<meta name=\"viewport\"";
                    int rankindex = htmlText.IndexOf(mobile);

                    if (rankindex >= 0)
                    {
                        rank += 10;
                    }

                    string css = "<link rel=\"stylesheet\"";
                    int rankindex2 = htmlText.IndexOf(css);

                    if (rankindex2 >= 0)
                    {
                        rank += 10;
                    }

                    string utf8 = "<meta charset=\"utf - 8\" />";
                    int rankindex3 = htmlText.IndexOf(utf8.ToLower());

                    if (rankindex3 >= 0)
                    {
                        rank += 10;
                    }

                    string js = "<script type=\"text/javascript\"";
                    int rankindex4 = htmlText.IndexOf(js.ToLower());

                    if (rankindex4 >= 0)
                    {
                        rank += 10;
                        js = "true";
                    }
                    else
                    {
                        js = "false";
                    }

                    string aspnet = "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\"";
                    int rankindex5 = htmlText.IndexOf(aspnet.ToLower());

                    if (rankindex5 >= 0)
                    {
                        rank += 10;
                        aspnet = "true";
                    }
                    else
                    {
                        aspnet = "false";
                    }

                    string com = ".com";
                    int rankindex6 = url.IndexOf(com);

                    string xyz = ".xyz";
                    int rankindex7 = url.IndexOf(xyz);

                    string gov = ".gov";
                    int rankindex8 = url.IndexOf(gov);

                    string org = ".org";
                    int rankindex9 = url.IndexOf(org);

                    string net = ".net";
                    int rankindex10 = url.IndexOf(net);

                    if (rankindex6 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex7 >= 0)
                    {
                        rank += 20;
                    }
                    else if (rankindex8 >= 0)
                    {
                        rank += 40;
                    }
                    else if (rankindex9 >= 0)
                    {
                        rank += 30;
                    }
                    else if (rankindex10 >= 0)
                    {
                        rank += 20;
                    }
                    else
                    {
                        rank -= 10;
                    }

                    //Save result to database
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string istek = "update arda.Sonuçlar set Title = @Title, Link = @Link, Content1 = @Content1, Keywords = @Keywords, favicon = @favicon, Category = @Category, Date = @Date, Lang = @Lang, asp = @asp, js = @js where Link = '" + url + "'";
                    SqlCommand komut = new SqlCommand(istek, baglanti);
                    komut.Parameters.AddWithValue("@Title", titletext);
                    komut.Parameters.AddWithValue("@Link", url.Trim());
                    komut.Parameters.AddWithValue("@Content1", desc);
                    komut.Parameters.AddWithValue("@Keywords", key);
                    komut.Parameters.AddWithValue("@favicon", favicon);
                    komut.Parameters.AddWithValue("@Category", "news");
                    komut.Parameters.AddWithValue("@Date", DateTime.UtcNow);
                    komut.Parameters.AddWithValue("@Lang", hlang);
                    komut.Parameters.AddWithValue("@asp", aspnet);
                    komut.Parameters.AddWithValue("@js", js);
                    komut.ExecuteNonQuery();

                    //Get news image
                    string image = "<img src=\"";
                    string alt = "alt=\"";

                    int index9 = htmlText.IndexOf(image);
                    int index10 = htmlText.IndexOf(alt);

                    try
                    {
                        if (index9 >= 0 & index10 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang) + htmllang.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else if (index4_1 >= 0)
                        {
                            int baslangic = htmlText.IndexOf(htmllang2) + htmllang2.Length;
                            int bitis = htmlText.Substring(baslangic).IndexOf("\" />");
                            if (bitis > 200)
                            {
                                bitis = htmlText.Substring(baslangic).IndexOf("\">");
                            }

                            lang = htmlText.Substring(baslangic, bitis);
                        }
                        else
                        {
                            lang = "";
                        }
                    }
                    catch (Exception hata)
                    {
                        Response.Write(hata);
                        lang = "";
                    }

                    //Save news to database
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string istek2 = "update arda.News set Title = @Title, Link = @Link, Source = @Source, Image = @Image, LastCheck = @LastCheck, Lang = @Lang where Link = '" + url + "'";
                    SqlCommand komut2 = new SqlCommand(istek2, baglanti);
                    komut.Parameters.AddWithValue("@Title", titletext);
                    komut.Parameters.AddWithValue("@Link", url.Trim());
                    komut.Parameters.AddWithValue("@Source", source);
                    komut.Parameters.AddWithValue("@Image", "image");
                    komut.Parameters.AddWithValue("@LastCheck", DateTime.UtcNow);
                    komut.Parameters.AddWithValue("@Lang", lang);
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();
        }
        catch (Exception hata)
        {
            Response.Write(hata.ToString());
        }
    }
}