using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.ServiceModel.PeerResolvers;
using System.Net.Mail;
using CsQuery.ExtensionMethods;
using HtmlAgilityPack;
using System.Web.Routing;
using System.Web.Mvc;
using System.Text;
using System.Net.Http;
using System.Security.Policy;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;
using Google.Cloud.Translation.V2;

public partial class AramaSonuc : System.Web.UI.Page
{

    private static string theme2;
    static double a, b;
    static string d;

    PagedDataSource pdsakademik = new PagedDataSource();
    PagedDataSource pds = new PagedDataSource();
    DataTable dt = new DataTable(); 

    Stopwatch watch = new Stopwatch();

    string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    public string admn = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

    public void Start()
    {
        System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
        string lang = kultur.TwoLetterISOLanguageName;
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection conadmin = new SqlConnection(admn);
        
        string url = Request.Url.Query;

        if (url.StartsWith("?i=<"))
        {
            Response.Redirect("/Home?i=+");
        }

        string aranan = Request.QueryString["i"];

        Page.Title = aranan + " - Artado Search";
        arama_çubugu2.Attributes.Add("Value", aranan);
        aranan = aranan.Trim();

        //Google Araması
        int google;
        google = aranan.ToLower().IndexOf(".g");

        //Reddit Araması
        int reddit; 
        reddit = aranan.ToLower().IndexOf(".r");

        //Instagram Araması
        int insta;
        insta = aranan.ToLower().IndexOf(".i");

        //Youtube Araması
        int yt;
        yt = aranan.ToLower().IndexOf(".yt");

        //Vikipedi Araması
        int wiki;
        wiki = aranan.ToLower().IndexOf(".wiki");

        //DuckDuckGO Araması
        int ddg;
        ddg = aranan.ToLower().IndexOf(".ddg");

        //Ekşi Sözlük Araması
        int eksi;
        eksi = aranan.ToLower().IndexOf(".eksi");

        //Twitter Araması
        int t;
        t = aranan.ToLower().IndexOf(".t");

        //Yaay Araması
        int y;
        y = aranan.ToLower().IndexOf(".y");

        //Quora Araması
        int q;
        q = aranan.ToLower().IndexOf(".q");

        if(aranan.StartsWith(".g") || aranan.StartsWith(".r") || aranan.StartsWith(".i") || aranan.StartsWith(".yt") || aranan.StartsWith(".ddg") || aranan.StartsWith(".eksi") || aranan.StartsWith(".t") || aranan.StartsWith(".y") || aranan.StartsWith(".q") || aranan.StartsWith(".wiki"))
        {
            if (google >= 0)
            {
                string yenikelime = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://www.google.com/search?hl=tr&q=" + yenikelime);
            }
            else if (reddit >= 0)
            {
                string subreddit = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://www.reddit.com/r/" + subreddit);
            }
            else if (insta >= 0)
            {
                string iprofile = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://www.instagram.com/" + iprofile);
            }
            else if (yt >= 0)
            {
                string ytarama = aranan.Substring(4, aranan.Length - 4);
                Response.Redirect("https://www.youtube.com/results?search_query=" + ytarama);
            }
            else if (ddg >= 0)
            {
                string ddgarama = aranan.Substring(5, aranan.Length - 5);
                Response.Redirect("https://duckduckgo.com/?q=" + ddgarama);
            }
            else if (eksi >= 0)
            {
                string eksiarama = aranan.Substring(5, aranan.Length - 5);
                Response.Redirect("https://eksisozluk.com/?q=" + eksiarama);
            }
            else if (t >= 0)
            {
                string tarama = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://twitter.com/search?q=" + tarama);
            }
            else if (y >= 0)
            {
                string yarama = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://yaay.com.tr/search?q=" + yarama);
            }
            else if (q >= 0)
            {
                string qarama = aranan.Substring(3, aranan.Length - 3);
                Response.Redirect("https://www.quora.com/search?q=" + qarama);
            }
            else if (wiki >= 0)
            {
                string wikiarama = aranan.Substring(5, aranan.Length - 5);
                Response.Redirect("https://tr.wikipedia.org/w/index.php?search=" + wikiarama);
            }
        }

        string[] s;
        s = aranan.Split(' ');

        Google_R.Visible = true;
        Artado_R.Visible = true;
        Bing_R.Visible = true;
        Yahoo_R.Visible = true;
        Petal_R.Visible = true;
        Youtube_R.Visible = false;
        İzlesene_R.Visible = false;
        Github_R.Visible = false;
        Scholar_R.Visible = false;
        Base_R.Visible = false;
        BNews_R.Visible = false;


        WebArama.Visible = true;
        Panel3.Visible = true;
        Panel4.Visible = true;
        Panel5.Visible = true;
        Panel6.Visible = true;
        GörselArama.Visible = false;
        SözlükArama.Visible = false;
        MüzikArama.Visible = false;
        Panel3.Visible = false;
        Makaleler.Visible = false;
        Panel11.Visible = false;

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        watch.Start();

        //Sözlük Öneri
        foreach (string kelime in s)
        {
            PagedDataSource pdssoz = new PagedDataSource();
            SqlDataAdapter adpsoz = new SqlDataAdapter("select *, Anlam from dbo.Sözlük where Kelime Like @aranan", baglanti);
            adpsoz.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@aranan",
                Value = "%" + kelime + "%",
            });
            DataTable dtınfo = new DataTable();
            adpsoz.Fill(dtınfo);
            pdssoz.DataSource = dtınfo.DefaultView;
            pdssoz.AllowPaging = true;
            pdssoz.PageSize = 1;
            SozlukOneri.DataSource = pdssoz;
            SozlukOneri.DataBind();
        }
        if (SozlukOneri.Items.Count == 0)
        {
            Panel6.Visible = false;
        }

        //Showcase
        foreach (string kelime in s)
        {
            PagedDataSource pdssoz = new PagedDataSource();
            SqlDataAdapter adpsoz = new SqlDataAdapter("select * from dbo.Ürünler where Title Like @aranan or Source Like @aranan", baglanti);
            adpsoz.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@aranan",
                Value = "%" + kelime + "%",
            });
            DataTable dtınfo = new DataTable();
            adpsoz.Fill(dtınfo);
            pdssoz.DataSource = dtınfo.DefaultView;
            pdssoz.AllowPaging = true;
            pdssoz.PageSize = 10;
            Ürünler.DataSource = pdssoz;
            Ürünler.DataBind();
        }
        if (Ürünler.Items.Count < 3)
        {
            Showcase.Visible = false;
        }
        Ürünler.RepeatColumns = 20;

        //Bilgi Kutusu Arama
        PagedDataSource pdsinfo = new PagedDataSource();
        if (pds.IsFirstPage)
        {
            Panel11.Visible = false;
            if (cookielang != null && cookielang.Value != null)
            {
                if (cookielang.Value == "tr-TR")
                {
                    PagedDataSource pdssoz = new PagedDataSource();
                    SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='tr'", baglanti);
                    adpınfo.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@aranan",
                        Value = "%" + aranan + "%",
                    });
                    DataTable dtınfo = new DataTable();
                    adpınfo.Fill(dtınfo);
                    pdsinfo.DataSource = dtınfo.DefaultView;
                    pdsinfo.AllowPaging = true;
                    pdsinfo.PageSize = 1;
                    InfoBox.DataSource = pdsinfo;
                    InfoBox.DataBind();

                    if (InfoBox.Items.Count > 0)
                    {
                        //Bilgi Kutusu Onay Yazısı
                        Label onaytxt = InfoBox.Items[0].FindControl("OnayTxt") as Label;
                        Label title = InfoBox.Items[0].FindControl("title") as Label;
                        Panel onaypanel = InfoBox.Items[0].FindControl("Onay") as Panel;
                        SqlCommand sqlcmd = new SqlCommand("select Onay from dbo.Infos where InfoTitle=@aranan", baglanti);
                        sqlcmd.Parameters.AddWithValue("@aranan", title.Text);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        string onay = sqlcmd.ExecuteScalar().ToString();
                        if (baglanti.State.ToString() == "Open")
                        {
                            baglanti.Close();
                            SqlConnection.ClearPool(baglanti);
                        }

                        if (onay == "Waiting")
                        {
                            onaypanel.Visible = true;
                            onaytxt.Text = "Bu bilgi kutusu daha onaylanmadı.";
                        }
                        else
                        {
                            onaypanel.Visible = false;
                        }
                    }
                }
                else
                {
                    PagedDataSource pdssoz = new PagedDataSource();
                    SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='en'", baglanti);
                    adpınfo.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@aranan",
                        Value = "%" + aranan + "%",
                    });
                    DataTable dtınfo = new DataTable();
                    adpınfo.Fill(dtınfo);
                    pdsinfo.DataSource = dtınfo.DefaultView;
                    pdsinfo.AllowPaging = true;
                    pdsinfo.PageSize = 1;
                    InfoBox.DataSource = pdsinfo;
                    InfoBox.DataBind();

                    if (InfoBox.Items.Count > 0)
                    {
                        //Bilgi Kutusu Onay Yazısı
                        Label onaytxt = InfoBox.Items[0].FindControl("OnayTxt") as Label;
                        Label title = InfoBox.Items[0].FindControl("title") as Label;
                        Panel onaypanel = InfoBox.Items[0].FindControl("Onay") as Panel;
                        SqlCommand sqlcmd = new SqlCommand("select Onay from dbo.Infos where InfoTitle=@aranan", baglanti);
                        sqlcmd.Parameters.AddWithValue("@aranan", title.Text);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        string onay = sqlcmd.ExecuteScalar().ToString();
                        if (baglanti.State.ToString() == "Open")
                        {
                            baglanti.Close();
                            SqlConnection.ClearPool(baglanti);
                        }

                        if (onay == "Waiting")
                        {
                            onaypanel.Visible = true;
                            onaytxt.Text = "This infobox has not been confirmed yet.";
                        }
                        else
                        {
                            onaypanel.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if (lang == "tr".ToLower())
                {
                    PagedDataSource pdssoz = new PagedDataSource();
                    SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='tr'", baglanti);
                    adpınfo.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@aranan",
                        Value = "%" + aranan + "%",
                    });
                    DataTable dtınfo = new DataTable();
                    adpınfo.Fill(dtınfo);
                    pdsinfo.DataSource = dtınfo.DefaultView;
                    pdsinfo.AllowPaging = true;
                    pdsinfo.PageSize = 1;
                    InfoBox.DataSource = pdsinfo;
                    InfoBox.DataBind();

                    if (InfoBox.Items.Count > 0)
                    {
                        //Bilgi Kutusu Onay Yazısı
                        Label onaytxt = InfoBox.Items[0].FindControl("OnayTxt") as Label;
                        Label title = InfoBox.Items[0].FindControl("title") as Label;
                        Panel onaypanel = InfoBox.Items[0].FindControl("Onay") as Panel;
                        SqlCommand sqlcmd = new SqlCommand("select Onay from dbo.Infos where InfoTitle=@aranan", baglanti);
                        sqlcmd.Parameters.AddWithValue("@aranan", title.Text);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        string onay = sqlcmd.ExecuteScalar().ToString();
                        if (baglanti.State.ToString() == "Open")
                        {
                            baglanti.Close();
                            SqlConnection.ClearPool(baglanti);
                        }

                        if (onay == "Waiting")
                        {
                            onaypanel.Visible = true;
                            onaytxt.Text = "Bu bilgi kutusu daha onaylanmadı.";
                        }
                        else
                        {
                            onaypanel.Visible = false;
                        }
                    }
                }
                else
                {
                    PagedDataSource pdssoz = new PagedDataSource();
                    SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='en'", baglanti);
                    adpınfo.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@aranan",
                        Value = "%" + aranan + "%",
                    });
                    DataTable dtınfo = new DataTable();
                    adpınfo.Fill(dtınfo);
                    pdsinfo.DataSource = dtınfo.DefaultView;
                    pdsinfo.AllowPaging = true;
                    pdsinfo.PageSize = 1;
                    InfoBox.DataSource = pdsinfo;
                    InfoBox.DataBind();

                    if (InfoBox.Items.Count > 0)
                    {
                        //Bilgi Kutusu Onay Yazısı
                        Label onaytxt = InfoBox.Items[0].FindControl("OnayTxt") as Label;
                        Label title = InfoBox.Items[0].FindControl("title") as Label;
                        Panel onaypanel = InfoBox.Items[0].FindControl("Onay") as Panel;
                        SqlCommand sqlcmd = new SqlCommand("select Onay from dbo.Infos where InfoTitle=@aranan", baglanti);
                        sqlcmd.Parameters.AddWithValue("@aranan", title.Text);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        string onay = sqlcmd.ExecuteScalar().ToString();
                        if (baglanti.State.ToString() == "Open")
                        {
                            baglanti.Close();
                            SqlConnection.ClearPool(baglanti);
                        }

                        if (onay == "Waiting")
                        {
                            onaypanel.Visible = true;
                            onaytxt.Text = "This infobox has not been confirmed yet.";
                        }
                        else
                        {
                            onaypanel.Visible = false;
                        }
                    }
                }
            }
            if (InfoBox.Items.Count == 0)
            {
                //InfoBoxes from Wikipedia

                Panel4.Visible = false;
                //Panel11.Visible = true;
                //string wikiurl = "https://" + lang + ".wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=" + aranan;
                //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(wikiurl.Trim());
                //request.Referer = "https://" + lang + ".wikipedia.org/";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                //WebResponse response = request.GetResponse();
                //StreamReader reader = new StreamReader(response.GetResponseStream());

                //string json = reader.ReadToEnd();

                //string hrefurl = "https://" + lang + ".wikipedia.org/wiki/" + aranan;

                //JsonSerializer ser = new JsonSerializer();
                //Result result = ser.Deserialize<Result>(new JsonTextReader(reader));

                //foreach (Page page in result.query.pages.Values)
                //    Label18.Text = page.extract;

                //reader.Close();
                //response.Close();
            }
        }
        else
        {
            Panel4.Visible = false;
        }

        System.Web.HttpCookie cookieweb = HttpContext.Current.Request.Cookies["WebResults"];

        if (cookieweb != null && cookieweb.Value != null)
        {
            try
            {
                if (cookieweb.Value == "Artado")
                {
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = true;
                    Filtre.Visible = true;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    PageSelect.Visible = true;
                    Text.Visible = true;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = false;

                    Artado_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button1.Attributes.Add("style", "color: black;");

                    //Web arama
                    if (WebArama.Visible == true && rptAramaSonuclari.Visible == true)
                    {
                        foreach (string kelime in s)
                        {
                            if (DropDownList1.SelectedValue == "Alaka")
                            {
                                SqlDataAdapter adp = new SqlDataAdapter("select *, Title from dbo.Sonuçlar where Title Like @aranan or Content1 Like @aranan or Keywords Like @aranan", baglanti);
                                adp.SelectCommand.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@aranan",
                                    Value = "%" + kelime + "%",
                                });
                                DataTable dt = new DataTable();
                                adp.Fill(dt);
                                pds.DataSource = dt.DefaultView;
                                pds.AllowPaging = true;
                                pds.PageSize = 10;
                                int currentPage;
                                if (Request.QueryString["page"] != null)
                                {
                                    currentPage = Int32.Parse(Request.QueryString["page"]);
                                    if (currentPage < 1)
                                    {
                                        currentPage = 1;
                                    }
                                }
                                else
                                {
                                    currentPage = 1;
                                }
                                pds.CurrentPageIndex = currentPage - 1;
                                Label2.Text = "Sayfa: " + currentPage + " / " + pds.PageCount;
                                if (currentPage <= 1)
                                {
                                    HyperLink1.Visible = false;
                                }
                                if (!pds.IsFirstPage)
                                {
                                    HyperLink1.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                                }
                                if (!pds.IsLastPage)
                                {
                                    HyperLink2.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                                }
                                rptAramaSonuclari.DataSource = pds;
                                rptAramaSonuclari.DataBind();
                            }
                            else if (DropDownList1.SelectedValue == "Puan")
                            {
                                SqlDataAdapter adp = new SqlDataAdapter("select *, Title from dbo.Sonuçlar where Title Like @aranan or Content1 Like @aranan or Keywords Like @aranan order by Rank desc", baglanti);
                                adp.SelectCommand.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@aranan",
                                    Value = "%" + kelime + "%",
                                });
                                DataTable dt = new DataTable();
                                adp.Fill(dt);
                                pds.DataSource = dt.DefaultView;
                                pds.AllowPaging = true;
                                pds.PageSize = 10;
                                int currentPage;
                                if (Request.QueryString["page"] != null)
                                {
                                    currentPage = Int32.Parse(Request.QueryString["page"]);
                                }
                                else
                                {
                                    currentPage = 1;
                                }
                                pds.CurrentPageIndex = currentPage - 1;
                                Label2.Text = "Sayfa: " + currentPage + " / " + pds.PageCount;
                                if (!pds.IsFirstPage)
                                {
                                    HyperLink1.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                                }
                                if (!pds.IsLastPage)
                                {
                                    HyperLink2.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                                }
                                rptAramaSonuclari.DataSource = pds;
                                rptAramaSonuclari.DataBind();
                            }
                            else
                            {
                                SqlDataAdapter adp = new SqlDataAdapter("select *, Title from dbo.Sonuçlar where Title Like @aranan or Content1 Like @aranan or Keywords Like @aranan", baglanti);
                                adp.SelectCommand.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@aranan",
                                    Value = "%" + kelime + "%",
                                });
                                DataTable dt = new DataTable();
                                adp.Fill(dt);
                                pds.DataSource = dt.DefaultView;
                                pds.AllowPaging = true;
                                pds.PageSize = 10;
                                int currentPage;
                                if (Request.QueryString["page"] != null)
                                {
                                    currentPage = Int32.Parse(Request.QueryString["page"]);
                                }
                                else
                                {
                                    currentPage = 1;
                                }
                                pds.CurrentPageIndex = currentPage - 1;
                                Label2.Text = "Sayfa: " + currentPage + " / " + pds.PageCount;
                                if (!pds.IsFirstPage)
                                {
                                    HyperLink1.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                                }
                                if (!pds.IsLastPage)
                                {
                                    HyperLink2.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                                }
                                rptAramaSonuclari.DataSource = pds;
                                rptAramaSonuclari.DataBind();
                            }
                        }
                    }
                }
                else if (cookieweb.Value == "Google")
                {
                    Google_R.Attributes.Add("style", "background-color: white; color: black;");
                    Google_B.Attributes.Add("style", "color: black;");
                    Google.Visible = true;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = true;
                    OtherResults.Visible = false;
                }
                else if (cookieweb.Value == "Bing")
                {
                    Bing_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button2.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }
                    string bing = "https://www.bing.com/search?q=" + aranan + "&qs=n&sp=-1&pq=" + aranan + "&sc=8-6&sk=&cvid=E61D587280A143E4B2B331964F17D6C8&first=" + currentPage;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                    request.Referer = "https://www.bing.com/";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    int results1 = htmlText.IndexOf("<ol id=\"b_results\" class=\"\">".ToLower()) + 28;
                    int results2 = htmlText.Substring(results1).IndexOf("</ol>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage <= 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 8);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 8);
                }
                else if (cookieweb.Value == "Yahoo")
                {
                    Yahoo_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button3.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = true;
                    DropDownList1.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    Sort.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 0;
                    }
                    string github = "https://search.yahoo.com/search?p=" + aranan + "&b=" + currentPage + 0;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    string a = "https://search.yahoo.com/search";
                    int href = htmlText.IndexOf(a);
                    while (href >= 0)
                    {
                        htmlText = htmlText.Replace("https://search.yahoo.com/search", "/search");
                        if (a.Length < htmlText.Length)
                        {
                            href = htmlText.IndexOf(a, a.Length);
                        }
                        else
                        {
                            href = -1;
                        }
                    }
                    try
                    {
                        int results1 = htmlText.IndexOf("<div id=\"results\"><style type=\"text/css\">") + 0;
                        int results2 = htmlText.Substring(results1).IndexOf("</div></div><div id=\"right\"></div>");
                        string resulttext = htmlText.Substring(results1, results2);
                        ResultsTxt.Text = resulttext;
                    }
                    catch
                    {
                        int results1 = htmlText.IndexOf("<div id=\"left\">") + 0;
                        int results2 = htmlText.Substring(results1).IndexOf("</ol></div>");
                        string resulttext = htmlText.Substring(results1, results2);
                        ResultsTxt.Text = resulttext;
                    }

                    if (currentPage < 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                }
                else if (cookieweb.Value == "Petal")
                {
                    Petal_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button4.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = true;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    Panel4.Visible = false;
                    Panel11.Visible = false;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }
                    string bing = "https://petalsearch.com/search?query=" + aranan + "&channel=all&locale=" + ScholarFiltre.SelectedValue + "&sregion=" + lang + "&from=PCweb&ps=10&pn=" + currentPage;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                    request.Referer = "https://petalsearch.com";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    int results1 = htmlText.IndexOf("<section class=\"el-container content-nav\" data-v-5f34523e>".ToLower()) + 109;
                    int results2 = htmlText.Substring(results1).IndexOf("</section>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage <= 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                }
                else
                {
                    Google_R.Attributes.Add("style", "background-color: white; color: black;");
                    Google_B.Attributes.Add("style", "color: black;");
                    Google.Visible = true;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = true;
                    OtherResults.Visible = false;

                    HttpCookie cookie = new HttpCookie("WebResults");
                    cookie.Value = "Google";
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
            catch (Exception error)
            {
                Google.Visible = false;
                rptAramaSonuclari.Visible = false;
                Filtre.Visible = false;
                PageSelect.Visible = false;
                Text.Visible = false;
                GoogleImage.Visible = false;
                ResultsTxt.Visible = true;
                ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。<br/><br/> Hata Mesajı: " + error;
            }
        }
        else
        {
            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = "Google";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());

            Google_R.Attributes.Add("style", "background-color: white; color: black;");
            Google_B.Attributes.Add("style", "color: black;");
            Google.Visible = true;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = true;
            OtherResults.Visible = false;
        }

        int sonuçlar = rptAramaSonuclari.Items.Count * pds.PageCount;

        //if (pds.IsFirstPage && Panel4.Visible == true)
        //{
        //    Label title = InfoBox.Items[0].FindControl("title") as Label;
        //    Suggestions.RepeatColumns = 3;
        //    if (cookielang != null && cookielang.Value != null)
        //    {
        //        PagedDataSource pdssoz = new PagedDataSource();
        //        SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='" + cookielang + "' or Info Like @aranan and where not InfoTitle='" + title.Text + "'", baglanti);
        //        adpınfo.SelectCommand.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@aranan",
        //            Value = "%" + aranan + "%",
        //        });
        //        DataTable dtınfo = new DataTable();
        //        adpınfo.Fill(dtınfo);
        //        pdsinfo.DataSource = dtınfo.DefaultView;
        //        pdsinfo.AllowPaging = true;
        //        pdsinfo.PageSize = 3;
        //        Suggestions.DataSource = pdsinfo;
        //        Suggestions.DataBind();
        //        if (Suggestions.Items.Count == 0)
        //        {
        //            Panel10.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        PagedDataSource pdssoz = new PagedDataSource();
        //        SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos where InfoTitle Like @aranan and Lang='" + cookielang + "' or Info Like @aranan and not InfoTitle='" + title.Text + "'", baglanti);
        //        adpınfo.SelectCommand.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@aranan",
        //            Value = "%" + aranan + "%",
        //        });
        //        DataTable dtınfo = new DataTable();
        //        adpınfo.Fill(dtınfo);
        //        pdsinfo.DataSource = dtınfo.DefaultView;
        //        pdsinfo.AllowPaging = true;
        //        pdsinfo.PageSize = 3;
        //        Suggestions.DataSource = pdsinfo;
        //        Suggestions.DataBind();
        //        if (Suggestions.Items.Count == 0)
        //        {
        //            Panel10.Visible = false;
        //        }
        //    }
        //    if (Suggestions.Items.Count <= 3)
        //    {
        //        Panel10.Visible = false;
        //    }
        //}
        //else
        //{
        //    Panel10.Visible = false;
        //}
        Panel10.Visible = false;

        //Haberler
        foreach (string kelime in s)
        {
            PagedDataSource pdssoz = new PagedDataSource();
            SqlDataAdapter adpsoz = new SqlDataAdapter("select * from dbo.News where Title Like @aranan order by Date desc", baglanti);
            adpsoz.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@aranan",
                Value = "%" + kelime + "%",
            });
            DataTable dtınfo = new DataTable();
            adpsoz.Fill(dtınfo);
            pdssoz.DataSource = dtınfo.DefaultView;
            pdssoz.AllowPaging = true;
            pdssoz.PageSize = 1;
            News_Results.DataSource = pdssoz;
            News_Results.DataBind();
        }
        if (News_Results.Items.Count == 0)
        { 
            News.Visible = false;
        }

        //Arananı veritabanına kaydediyor
        string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

        if (cookielang != null && cookielang.Value != null)
        {
            SqlConnection baglantiistek = new SqlConnection(admin);
            if (baglantiistek.State == ConnectionState.Closed)
                baglantiistek.Open();
            string istek = "insert into dbo.Arananlar(Kelime, Lang, Date, Source) values (@Kelime, @Lang, @Date, @Source)";
            SqlCommand komut = new SqlCommand(istek, baglantiistek);
            komut.Parameters.AddWithValue("@Kelime", "[anon]");
            komut.Parameters.AddWithValue("@Lang", cookielang.Value);
            komut.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
            komut.Parameters.AddWithValue("@Source", cookieweb.Value);
            komut.ExecuteNonQuery();
            baglantiistek.Close();
        }
        else
        {
            SqlConnection baglantiistek = new SqlConnection(admin);
            if (baglantiistek.State == ConnectionState.Closed)
                baglantiistek.Open();
            string istek = "insert into dbo.Arananlar(Kelime, Lang, Date, Source) values (@Kelime, @Lang, @Date, @Source)";
            SqlCommand komut = new SqlCommand(istek, baglantiistek);
            komut.Parameters.AddWithValue("@Kelime", "[anon]");
            komut.Parameters.AddWithValue("@Lang", lang);
            komut.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
            komut.Parameters.AddWithValue("@Source", cookieweb.Value);
            komut.ExecuteNonQuery();
            baglantiistek.Close();
        }

        int dolar;
        dolar = aranan.Trim().ToLower().IndexOf("dolar");

        int euro;
        euro = aranan.Trim().ToLower().IndexOf("euro");

        int sterlin;
        sterlin = aranan.Trim().ToLower().IndexOf("sterlin");

        int love;
        love = aranan.Trim().ToLower().IndexOf("i love you");

        //Dolar
        if (aranan.ToLower() == "dolar" || dolar >= 0)
        {
            Panel1.Visible = true;
            Image2.ImageUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fcdn.onlinewebfonts.com%2Fsvg%2Fdownload_60944.png&f=1&nofb=1";
            Ad.Text = "Amerikan Doları / Türk Lirası";
            Meslek.Text = "1 Dolar";

            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolartxt = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));

                Doğum.Text = dolartxt.ToString() + " Türk Lirası";
            }
            catch
            {
                Doğum.Text = "Veri bulunamadı. Detarlar için <a href=http://www.tcmb.gov.tr/kurlar/today.xml> buraya tıklayınız </a>";
            }

        }
        else if (aranan.ToLower() == "euro" || euro >= 0)
        {
            Panel1.Visible = true;
            Image2.ImageUrl = "https://thelongandshort.org/assets/images/_articleImageFullWidth/Symbols_euro.png";
            Ad.Text = "Euro / Türk Lirası";
            Meslek.Text = "1 Euro";

            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal eurotxt = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                Doğum.Text = eurotxt.ToString() + " Türk Lirası";
            }
            catch
            {
                Doğum.Text = "Veri bulunamadı. Detarlar için <a href=http://www.tcmb.gov.tr/kurlar/today.xml> buraya tıklayınız </a>";
            }
        }
        else if (aranan.ToLower() == "sterlin" || sterlin >= 0)
        {
            Panel1.Visible = true;
            Image2.ImageUrl = "https://seeklogo.com/images/G/great-britain-pound-gbp-logo-4E3D714CFB-seeklogo.com.png";
            Ad.Text = "Sterlin / Türk Lirası";
            Meslek.Text = "1 Sterlin";

            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal sterlintxt = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

                Doğum.Text = sterlintxt.ToString() + " Türk Lirası";
            }
            catch
            {
                Doğum.Text = "Veri bulunamadı. Detarlar için <a href=http://www.tcmb.gov.tr/kurlar/today.xml> buraya tıklayınız </a>";
            }
        }
        else if (aranan.ToLower() == "i love you" || love >= 0)
        {
            Panel1.Visible = true;
            Image2.ImageUrl = "/Icons/my-love.png";
            Ad.Text = "I love you too";
            Meslek.Text = "<3";
        }
        else if (aranan.ToLower() == "seni seviyorum")
        {
            Panel1.Visible = true;
            Image2.ImageUrl = "/Icons/my-love.png";
            Ad.Text = "Bende seni seviyorum!";
            Meslek.Text = "<3";
        }
        else
        {
            Panel1.Visible = false;
        }

        if (aranan == "hesap makinesi".Trim().ToLower())
        {
            Panel5.Visible = true;
        }
        else
        {
            Panel5.Visible = false;
        }

        int ıpcontrol;
        ıpcontrol = aranan.IndexOf(" IP");

        int ıpcontrol2;
        ıpcontrol2 = aranan.IndexOf(" ip");

        if (ıpcontrol >= 0 || ıpcontrol2 >= 0 || aranan == "what is my ip?")
        {
            IPPanel.Visible = true;
            var ipAddress = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                IP.Text = ipAddress;
            }
            else if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
                IP.Text = ipAddress;
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                ipAddress = HttpContext.Current.Request.UserHostName;
                IP.Text = ipAddress;
            }
        }
        else
        {
            IPPanel.Visible = false;
        }

        int hava = aranan.ToLower().IndexOf("hava");
        int hava2 = aranan.ToLower().IndexOf("weather");
        int hava3 = aranan.ToLower().IndexOf("wetter");
        int hava4 = aranan.ToLower().IndexOf("conditions météorologiques");
        int hava5 = aranan.ToLower().IndexOf("Погода");
        int hava6 = aranan.ToLower().IndexOf("天气");
        if (hava >= 0 || hava2 >= 0 || hava3 >= 0 || hava4 >= 0 || hava5 >= 0 )
        {
            string api = "2f0a475faa72b7ade6066d6279ee5ca5";

            var ipAddress = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                ipAddress = HttpContext.Current.Request.UserHostName;
            }

            City.Text = "Istanbul";

            if (cookielang != null && cookielang.Value != null)
            {
                try
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + City.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    WeatherImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    Weathertext.Text = sicaklik + " ºC";
                    Weathertext2.Text = durum;
                    Feels_Like.Text = "Hissedilen Sıcaklık :  " + feels_like + "ºC";
                }
                catch
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + "Istanbul" + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    WeatherImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    Weathertext.Text = sicaklik + " ºC";
                    Weathertext2.Text = durum;
                    Feels_Like.Text = "Hissedilen Sıcaklık :  " + feels_like + "ºC";
                    City.Text = "Istanbul";
                }
            }
            else
            {
                try
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + City.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    WeatherImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    Weathertext.Text = sicaklik + " ºC";
                    Weathertext2.Text = durum;
                    Feels_Like.Text = "Hissedilen Sıcaklık :  " + feels_like + "ºC";
                }
                catch
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + "Istanbul" + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    WeatherImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    Weathertext.Text = sicaklik + " ºC";
                    Weathertext2.Text = durum;
                    Feels_Like.Text = "Hissedilen Sıcaklık :  " + feels_like + "ºC";
                    City.Text = "Istanbul";
                }
            }

            if (cookielang != null && cookielang.Value != null)
            {
                if (Ülkeler.Text == "Türkiye")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerTR.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerEN.Visible = false;
                    İllerTR.Visible = true;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "İngiltere")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerEN.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = true;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Fransa")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerFR.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = true;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Almanya")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerDE.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = true;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Azerbaycan")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerAZ.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = true;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "KKTC")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerKKTC.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = true;
                }
            }
            else
            {
                if (Ülkeler.Text == "Türkiye")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerTR.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerEN.Visible = false;
                    İllerTR.Visible = true;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "İngiltere")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerEN.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = true;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Fransa")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerFR.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = true;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Almanya")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerDE.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = true;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "Azerbaycan")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerAZ.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = true;
                    İllerKKTC.Visible = false;
                }
                else if (Ülkeler.Text == "KKTC")
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + İllerKKTC.Text + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
                    XDocument Hava = XDocument.Load(havabaglanti);
                    var sunrise = Hava.Descendants("sun").ElementAt(0).Attribute("rise").Value;
                    var sunset = Hava.Descendants("sun").ElementAt(0).Attribute("set").Value;
                    var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var minsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
                    var maxsicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
                    var feels_like = Hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var durum = Hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                    İllerTR.Visible = false;
                    İllerEN.Visible = false;
                    İllerFR.Visible = false;
                    İllerDE.Visible = false;
                    İllerAZ.Visible = false;
                    İllerKKTC.Visible = true;
                }
            }
        }
        else
        {
            HavaDurumu.Visible = false;
            Panel8.Visible = false;
        }

        if (Panel1.Visible == true)
        {
            Panel6.Visible = false;
        }

        //int translate;
        //translate = aranan.IndexOf("çeviri");
        //if (translate >= 0)
        //{
        //    Translate.Visible = true;
        //}
        //else
        //{

        //}
        Translate.Visible = false;

        

        Web.ForeColor = System.Drawing.Color.BlueViolet;
        Web.Font.Bold = true;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        //Güvenlik
        for (int i = 0; i < rptAramaSonuclari.Items.Count; i++)
        {
            Label http = rptAramaSonuclari.Items[i].FindControl("Link") as Label;
            Image danger = rptAramaSonuclari.Items[i].FindControl("danger") as Image;
            danger.Visible = false;
            if (http.Text.StartsWith("https://"))
            {
                danger.Visible = false;
            }
            else
            {
                danger.Visible = true;
            }
        }

        //Favicon
        for (int i = 0; i < rptAramaSonuclari.Items.Count; i++)
        {
            Image favicon = rptAramaSonuclari.Items[i].FindControl("Image4") as Image;
            favicon.Visible = false;
            if (favicon.ImageUrl == null || favicon.ImageUrl.Length == 0)
            {
                favicon.Visible = false;
            }
            else
            {
                favicon.Visible = true;
            }
        }

        //Popüler Sonuçlar
        for (int i = 0; i < rptAramaSonuclari.Items.Count; i++)
        {
            SqlConnection baglanti2 = new SqlConnection(con);
            baglanti2.Open();
            Label http = rptAramaSonuclari.Items[i].FindControl("Link") as Label;
            Panel popular = rptAramaSonuclari.Items[i].FindControl("Popular") as Panel;
            int rank;
            SqlCommand sqlcmd = new SqlCommand("select Rank from dbo.Sonuçlar where Link='" + http.Text + "'", baglanti2);
            rank = Convert.ToInt32(sqlcmd.ExecuteScalar());

            if (rank > 120)
            {
                popular.Visible = true;
            }
            else
            {
                popular.Visible = false;
            }
            baglanti2.Close();
        }

        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " sonuç bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

                Page.MetaDescription = "Artado Search Türkiye - Yerli, Reklamsız, Gizliliğe Önem Veren, Güvenli ve Sade Tasarımlı Arama Motoru";
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " sonuç bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                Page.MetaDescription = "Artado Search - Anonymous and secure search engine";
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

                Page.MetaDescription = "Artado Search France - Moteur de recherche anonyme et sécurisé";
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");

                Page.MetaDescription = "Artado Search Deutschland - Anonyme und sichere Suchmaschine";
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-AU");

                Page.MetaDescription = "Artado Search Azerbaijan - Anonim və təhlükəsiz axtarış sistemi";
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");

                Page.MetaDescription = "Artado Search Italy - Motore di ricerca anonimo e sicuro";
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

                Page.MetaDescription = "Artado Search Russia - анонимная и безопасная поисковая система";
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CHS");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");

                Page.MetaDescription = "Artado Search China - 匿名和安全的搜索引擎";
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

                Page.MetaDescription = "Artado Search Spain - Buscador anónimo y seguro";
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");

                Page.MetaDescription = "Artado Search Portugal - Motor de pesquisa anónimo e seguro";
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-KR");

                Page.MetaDescription = "Artado Search 대한민국 - 익명의 안전한 검색 엔진";
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (lang == "jp".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");

                Page.MetaDescription = "Artado Search Japan - 匿名で安全な検索エンジン";
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");

                Page.MetaDescription = "Artado Search Hungary - Névtelen és biztonságos kereső";
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

                Page.MetaDescription = "Artado Search Bulgaria - Анонимна и сигурна търсачка";
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-BZ");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-BZ");

                Page.MetaDescription = "Artado Search Bosna i Hercegovina - Anonimna i sigurna pretraživač";
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                Page.MetaDescription = "Anonymous and secure search engine";
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
        watch.Stop();
        baglanti.Close();

        for (int i = 0; i < rptAramaSonuclari.Items.Count; i++)
        {
            Label title = rptAramaSonuclari.Items[i].FindControl("Title") as Label;
            int prn = title.Text.ToLower().IndexOf("porn");
            if (prn >= 0)
            {
                if (cookielang != null && cookielang.Value != null)
                {
                    if (cookielang.Value == "tr-TR")
                    {
                        title.Text = "[Uygunsuz İçerik]";
                    }
                    else if (cookielang.Value == "en-US")
                    {
                        title.Text = "[Inappropriate Content]";
                    }
                    else if (cookielang.Value == "fr-FR")
                    {
                        title.Text = "[Contenu Inapproprié]";
                    }
                    else if (cookielang.Value == "de-DE")
                    {
                        title.Text = "[Unpassender Inhalt]";
                    }
                    else if (cookielang.Value == "en-AU")
                    {
                        title.Text = "[Uyğun Olmayan Məzmun]";
                    }
                    else if (cookielang.Value == "it-IT")
                    {
                        title.Text = "[Contenuto Inappropriato]";
                    }
                    else if (cookielang.Value == "ru-RU")
                    {
                        title.Text = "[Неприемлемое содержание]";
                    }
                    else if (cookielang.Value == "zh-CHS")
                    {
                        title.Text = "[不适当的内容]";
                    }
                    else if (cookielang.Value == "es-ES")
                    {
                        title.Text = "[Contenido inapropiado]";
                    }
                    else if (cookielang.Value == "pt-PT")
                    {
                        title.Text = "[Conteúdo inapropriado]";
                    }
                    else if (cookielang.Value == "ko-KR")
                    {
                        title.Text = "[부적절한 콘텐츠]";
                    }
                    else if (cookielang.Value == "ja-JP")
                    {
                        title.Text = "【不適切な内容】";
                    }
                    else if (cookielang.Value == "hu-HU")
                    {
                        title.Text = "[Nem megfelelő tartalom]";
                    }
                    else if (cookielang.Value == "bg-BG")
                    {
                        title.Text = "[Неподходящо съдържание]";
                    }
                    else if (cookielang.Value == "en-BZ")
                    {
                        title.Text = "[Neprimjeren sadržaj]";
                    }
                    else
                    {
                        title.Text = "[Inappropriate Content]";
                    }
                }
                else
                {
                    if (lang == "tr".ToLower())
                    {
                        title.Text = "[Uygunsuz İçerik]";
                    }
                    else if (lang == "en".ToLower())
                    {
                        title.Text = "[Inappropriate Content]";
                    }
                    else if (lang == "fr".ToLower())
                    {
                        title.Text = "[Contenu Inapproprié]";
                    }
                    else if (lang == "de".ToLower())
                    {
                        title.Text = "[Unpassender Inhalt]";
                    }
                    else if (lang == "az".ToLower())
                    {
                        title.Text = "[Uyğun Olmayan Məzmun]";
                    }
                    else if (lang == "it".ToLower())
                    {
                        title.Text = "[Contenuto Inappropriato]";
                    }
                    else if (lang == "ru".ToLower())
                    {
                        title.Text = "[Неприемлемое содержание]";
                    }
                    else if (lang == "zh".ToLower())
                    {
                        title.Text = "[不适当的内容]";
                    }
                    else if (lang == "es".ToLower())
                    {
                        title.Text = "[Contenido inapropiado]";
                    }
                    else if (lang == "pr".ToLower())
                    {
                        title.Text = "[Conteúdo inapropriado]";
                    }
                    else if (lang == "ko".ToLower())
                    {
                        title.Text = "[부적절한 콘텐츠]";
                    }
                    else if (lang == "jp".ToLower())
                    {
                        title.Text = "【不適切な内容】";
                    }
                    else if (lang == "hu".ToLower())
                    {
                        title.Text = "[Nem megfelelő tartalom]";
                    }
                    else if (lang == "bg".ToLower())
                    {
                        title.Text = "[Неподходящо съдържание]";
                    }
                    else if (lang == "bs".ToLower())
                    {
                        title.Text = "[Neprimjeren sadržaj]";
                    }
                    else
                    {
                        title.Text = "[Inappropriate Content]";
                    }
                }
            }
        }
    }

    public void Image()
    {
        //Görsel Arama
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(", ", "").Replace(": ", "").Replace(". ", "").Replace("; ", "").Replace(" için ", "").Replace(" ile ", "");
        s = aranan.Split(' ');

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Google_R.Visible = true;
        Artado_R.Visible = true;
        Bing_R.Visible = false;
        Yahoo_R.Visible = false;
        Petal_R.Visible = false;
        Youtube_R.Visible = false;
        İzlesene_R.Visible = false;
        Github_R.Visible = false;
        Scholar_R.Visible = false;
        Base_R.Visible = false;
        BNews_R.Visible = false;

        System.Web.HttpCookie cookieimg = HttpContext.Current.Request.Cookies["ImageResults"];

        if(cookieimg != null && cookieimg.Value != null)
        {
            if (cookieimg.Value == "Artado")
            {
                Artado_R.Attributes.Add("style", "background-color: white; color: black;");
                Button1.Attributes.Add("style", "color: black;");
                GoogleImage.Visible = false;
                GorselSonuclar.Visible = true;
            }
            else if (cookieimg.Value == "Google")
            {
                Google_R.Attributes.Add("style", "background-color: white; color: black;");
                Google_B.Attributes.Add("style", "color: black;");
                GorselSonuclar.Visible = false;
                GoogleImage.Visible = true;
                Text.Visible = false;
            }
            else
            {
                Google_R.Attributes.Add("style", "background-color: white; color: black;");
                Google_B.Attributes.Add("style", "color: black;");
                GorselSonuclar.Visible = false;
                GoogleImage.Visible = true;
                Text.Visible = false;
                HttpCookie cookie = new HttpCookie("ImageResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else
        {
            Google_R.Attributes.Add("style", "background-color: white; color: black;");
            Google_B.Attributes.Add("style", "color: black;");
            GorselSonuclar.Visible = false;
            GoogleImage.Visible = true;
            Text.Visible = false;
            HttpCookie cookie = new HttpCookie("ImageResults");
            cookie.Value = "Google";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        WebArama.Visible = false;
        GörselArama.Visible = true;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;

        if (GorselSonuclar.Visible == true)
        {
            foreach (string kelime in s)
            {
                SqlDataAdapter adpgorsel = new SqlDataAdapter("select *, GörselLink from dbo.Görseller where GorselTitle Like '%" + kelime + "%'", baglanti);
                DataTable dtgorsel = new DataTable();
                adpgorsel.Fill(dtgorsel);
                GorselSonuclar.DataSource = dtgorsel;
                GorselSonuclar.DataBind();
            }
            if (Request.Browser.IsMobileDevice == true)
            {
                GorselSonuclar.RepeatColumns = 1;
            }
            else
            {
                GorselSonuclar.RepeatColumns = 5;
            }
        }

        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.BlueViolet;
        Görsel.Font.Bold = true;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        int sonuçlar = GorselSonuclar.Items.Count;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + "immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + "개의 이미지 찾음";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekunde";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 이미지 찾음";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Videos()
    {
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(", ", "").Replace(": ", "").Replace(". ", "").Replace("; ", "").Replace(" için ", "").Replace(" ile ", "");
        s = aranan.Split(' ');

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Google_R.Visible = false;
        Artado_R.Visible = false;
        Bing_R.Visible = false;
        Yahoo_R.Visible = false;
        Petal_R.Visible = false;
        Youtube_R.Visible = true;
        İzlesene_R.Visible = true;
        Github_R.Visible = false;
        Scholar_R.Visible = false;
        Base_R.Visible = false;
        BNews_R.Visible = false;

        System.Web.HttpCookie cookievid = HttpContext.Current.Request.Cookies["VideoResults"];

        try
        {
            if(cookievid!=null && cookievid.Value != null)
            {
                if (cookievid.Value == "Youtube")
                {
                    Youtube_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button5.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }
                    string bing = "https://www.youtube.com/results?search_query=" + aranan;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                    request.Referer = "https://www.youtube.com/";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    int results1 = htmlText.IndexOf("<ytd-item-section-renderer class=\"style-scope ytd-section-list-renderer\" use-height-hack=\"\">".ToLower()) + 92;
                    int results2 = htmlText.Substring(results1).IndexOf("</ytd-item-section-renderer>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage <= 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 8);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 8);
                }
                else if (cookievid.Value == "İzlesene")
                {
                    İzlesene_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button6.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }
                    string bing = "https://search.izlesene.com/?kelime=" + aranan;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                    request.Referer = "https://www.izlesene.com/";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    int results1 = htmlText.IndexOf("<article role=\"main\" style=\"padding:0!important;\">".ToLower()) + 50;
                    int results2 = htmlText.Substring(results1).IndexOf("</article>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage <= 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 8);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 8);
                }
            }
            else
            {
                İzlesene_R.Attributes.Add("style", "background-color: white; color: black;");
                Button6.Attributes.Add("style", "color: black;");
                HttpCookie cookie = new HttpCookie("VideoResults");
                cookie.Value = "İzlesene";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
                Google.Visible = false;
                rptAramaSonuclari.Visible = false;
                Filtre.Visible = false;
                PageSelect.Visible = false;
                Text.Visible = false;
                ScholarFiltre.Visible = false;
                Lang.Visible = false;
                GoogleImage.Visible = false;
                OtherResults.Visible = true;
                int currentPage;
                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 1;
                }
                string bing = "https://search.izlesene.com/?kelime=" + aranan;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                request.Referer = "https://www.izlesene.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<article role=\"main\" style=\"padding:0!important;\">".ToLower()) + 50;
                int results2 = htmlText.Substring(results1).IndexOf("</article>");
                string resulttext = htmlText.Substring(results1, results2);
                ResultsTxt.Text = resulttext;

                if (currentPage <= 1)
                {
                    HyperLink5.Visible = false;
                }
                else
                {
                    HyperLink5.Visible = true;
                    HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 8);
                }

                HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 8);
            }
        }
        catch (Exception error)
        {
            Google.Visible = false;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = false;
            ResultsTxt.Visible = true;
            ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。<br/><br/> Hata Mesajı: " + error;
        }
        WebArama.Visible = true;
        GörselArama.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;


        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.BlueViolet;
        Video.Font.Bold = true;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        int sonuçlar = GorselSonuclar.Items.Count;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + "immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + "개의 이미지 찾음";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekunde";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 이미지 찾음";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void News_R()
    {
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(", ", "").Replace(": ", "").Replace(". ", "").Replace("; ", "").Replace(" için ", "").Replace(" ile ", "");
        s = aranan.Split(' ');

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Google_R.Visible = false;
        Artado_R.Visible = false;
        Bing_R.Visible = false;
        Yahoo_R.Visible = false;
        Petal_R.Visible = false;
        Youtube_R.Visible = false;
        İzlesene_R.Visible = false;
        Github_R.Visible = false;
        Scholar_R.Visible = false;
        Base_R.Visible = false;
        BNews_R.Visible = false;

        System.Web.HttpCookie cookienews = HttpContext.Current.Request.Cookies["NewsResults"];

        try
        {
            if (cookienews != null && cookienews.Value != null)
            {
                if (cookienews.Value == "Bing")
                {
                    Bing_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button2.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }
                    string bing = "https://www.bing.com/news/search?q=" + aranan;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                    request.Referer = "https://www.bing.com/";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    int results1 = htmlText.IndexOf("<main class=\"main\">".ToLower()) + 19;
                    int results2 = htmlText.Substring(results1).IndexOf("</main>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;
                    HyperLink5.Visible = false;
                    HyperLink6.Visible = false;
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("NewsResults");
                    cookie.Value = "Bing";
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie("NewsResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        catch (Exception error)
        {
            Google.Visible = false;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = false;
            ResultsTxt.Visible = true;
            ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。<br/><br/> Hata Mesajı: " + error;
        }
        WebArama.Visible = true;
        GörselArama.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;


        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.BlueViolet;
        News_button.Font.Bold = true;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        int sonuçlar = GorselSonuclar.Items.Count;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + "immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + "개의 이미지 찾음";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekunde";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 이미지 찾음";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Social_R()
    {
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(", ", "").Replace(": ", "").Replace(". ", "").Replace("; ", "").Replace(" için ", "").Replace(" ile ", "");
        s = aranan.Split(' ');

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        System.Web.HttpCookie cookiesoc = HttpContext.Current.Request.Cookies["SocialResults"];

        try
        {
            if (cookiesoc.Value == "Reddit")
            {
                Google.Visible = false;
                rptAramaSonuclari.Visible = false;
                Filtre.Visible = false;
                PageSelect.Visible = false;
                Text.Visible = false;
                ScholarFiltre.Visible = false;
                Lang.Visible = false;
                GoogleImage.Visible = false;
                OtherResults.Visible = true;
                int currentPage;
                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 20;
                }
                string bing = "https://old.reddit.com/search/?q=" + aranan + "&type=ps&sort=top&counts=" + currentPage;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                request.Referer = "https://old.reddit.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<div class=\"contents\"><div class=\" search-result search-result-link has-thumbnail has-linkflair \"".ToLower()) + 97;
                int results2 = htmlText.Substring(results1).IndexOf("</a></div></div></div>");
                string resulttext = htmlText.Substring(results1, results2);
                ResultsTxt.Text = resulttext;
                HyperLink5.Visible = false;
                HyperLink6.Text = "More";
                HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 10);
            }
            else
            {
                cookiesoc.Value = "Reddit";
                Google.Visible = false;
                rptAramaSonuclari.Visible = false;
                Filtre.Visible = false;
                PageSelect.Visible = false;
                Text.Visible = false;
                ScholarFiltre.Visible = false;
                Lang.Visible = false;
                GoogleImage.Visible = false;
                OtherResults.Visible = true;
                int currentPage;
                if (Request.QueryString["page"] != null)
                {
                    currentPage = Int32.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 20;
                }
                string bing = "https://old.reddit.com/search/?q=" + aranan + "&type=ps&sort=top&counts=" + currentPage;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                request.Referer = "https://old.reddit.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<div class=\"contents\"><div class=\" search-result search-result-link has-thumbnail has-linkflair \"".ToLower()) + 97;
                int results2 = htmlText.Substring(results1).IndexOf("</a></div></div></div>"); string resulttext = htmlText.Substring(results1, results2);
                ResultsTxt.Text = resulttext;
                HyperLink5.Visible = false;
                HyperLink6.Text = "More";
                HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 10);
            }
        }
        catch (Exception error)
        {
            Google.Visible = false;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = false;
            ResultsTxt.Visible = true;
            ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。<br/><br/> Hata Mesajı: " + error;
        }
        WebArama.Visible = true;
        GörselArama.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;


        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.BlueViolet;
        News_button.Font.Bold = true;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        int sonuçlar = GorselSonuclar.Items.Count;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + "immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + "개의 이미지 찾음";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekunde";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 이미지 찾음";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Info()
    {
        //Sözlük Arama
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(",", "").Replace(":", "").Replace(".", "").Replace(";", "").Replace("için", "").Replace("ile", "");
        s = aranan.Split(' ');

        foreach (string kelime in s)
        {
            int ek;
            ek = kelime.ToLower().IndexOf("ler");

            if (ek >= 0)
            {
                string yenikelime = kelime.Substring(0, kelime.Length - 3);

                SqlDataAdapter adpsoz = new SqlDataAdapter("select *, Anlam from dbo.Sözlük where Kelime Like '%" + yenikelime + "%'", baglanti);
                DataTable dtsoz = new DataTable();
                adpsoz.Fill(dtsoz);
                sözlüksonuc.DataSource = dtsoz;
                sözlüksonuc.DataBind();
            }
            else
            {
                SqlDataAdapter adpsoz = new SqlDataAdapter("select *, Anlam from dbo.Sözlük where Kelime Like '%" + kelime + "%'", baglanti);
                DataTable dtsoz = new DataTable();
                adpsoz.Fill(dtsoz);
                sözlüksonuc.DataSource = dtsoz;
                sözlüksonuc.DataBind();
            }
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Artado_R.Attributes.Add("style", "background-color: white; color: black;");
        Button1.Attributes.Add("style", "color: black;");

        SözlükArama.Visible = true;
        GörselArama.Visible = false;
        WebArama.Visible = false;
        MüzikArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;

        buttons_r.Visible = false;

        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.BlueViolet;
        Sözlük.Font.Bold = true;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        int sonuçlar = sözlüksonuc.Items.Count;
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " sonuç bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " bilgi bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Movie()
    {
        //Film Arama
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(",", "").Replace(":", "").Replace(".", "").Replace(";", "").Replace("için", "").Replace("ile", "");
        s = aranan.Split(' ');

        foreach (string kelime in s)
        {
            SqlDataAdapter adpınfo = new SqlDataAdapter("select * from dbo.Films where Name Like '%" + kelime + "%' or Actors Like '%" + kelime + "%'", baglanti);
            DataTable dtınfo = new DataTable();
            adpınfo.Fill(dtınfo);
            Filmler.DataSource = dtınfo;
            Filmler.DataBind();
        }

        SözlükArama.Visible = false;
        GörselArama.Visible = false;
        WebArama.Visible = false;
        MüzikArama.Visible = true;

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Artado_R.Attributes.Add("style", "background-color: white; color: black;");
        Button1.Attributes.Add("style", "color: black;");

        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;
        buttons_r.Visible = false;

        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = true;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.BlueViolet;
        Film.Font.Bold = true;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        int sonuçlar = Filmler.Items.Count;
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " sonuç bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " film bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void it()
    {
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(", ", "").Replace(": ", "").Replace(". ", "").Replace("; ", "").Replace(" için ", "").Replace(" ile ", "");
        s = aranan.Split(' ');

        //Boş Arama engelleme
        if (aranan == "")
        {
            Response.Redirect("Home?empty=true");
        }

        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        Google_R.Visible = false;
        Artado_R.Visible = true;
        Bing_R.Visible = false;
        Yahoo_R.Visible = false;
        Petal_R.Visible = false;
        Youtube_R.Visible = false;
        İzlesene_R.Visible = false;
        Github_R.Visible = true;
        Scholar_R.Visible = false;
        Base_R.Visible = false;
        BNews_R.Visible = false;

        System.Web.HttpCookie cookieit = HttpContext.Current.Request.Cookies["ITResults"];

        try
        {
            if(cookieit != null && cookieit.Value != null)
            {
                //Artado Forum
                if (cookieit.Value == "Artado")
                {
                    Artado_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button1.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = true;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = false;
                    Text.Visible = false;

                    //Web arama
                    foreach (string kelime in s)
                    {
                        SqlDataAdapter adp = new SqlDataAdapter("select * from dbo.Questions where Title Like @aranan order by ID desc", baglanti);
                        adp.SelectCommand.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@aranan",
                            Value = "%" + kelime + "%",
                        });
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        pds.DataSource = dt.DefaultView;
                        pds.AllowPaging = true;
                        pds.PageSize = 100;
                        int currentPage;
                        if (Request.QueryString["page"] != null)
                        {
                            currentPage = Int32.Parse(Request.QueryString["page"]);
                            if (currentPage < 1)
                            {
                                currentPage = 1;
                            }
                        }
                        else
                        {
                            currentPage = 1;
                        }
                        pds.CurrentPageIndex = currentPage - 1;
                        Label2.Text = "Sayfa: " + currentPage + " / " + pds.PageCount;
                        if (currentPage <= 1)
                        {
                            HyperLink1.Visible = false;
                        }
                        if (!pds.IsFirstPage)
                        {
                            HyperLink1.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                        }
                        if (!pds.IsLastPage)
                        {
                            HyperLink2.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                        }
                        Sorular.DataSource = pds;
                        Sorular.DataBind();
                    }
                    HyperLink5.Visible = false;
                    HyperLink6.Visible = false;
                }
                else if (cookieit.Value == "Github")
                {
                    Github_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button7.Attributes.Add("style", "color: black;");
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 0;
                    }
                    string github = "https://github.com/search?p=" + currentPage + "&q=" + aranan + "&type=Repositories";
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    string a = "href=\"/";
                    int href = htmlText.IndexOf(a);
                    while (href >= 0)
                    {
                        htmlText = htmlText.Replace("\"/", "\"https://github.com/");
                        if (a.Length < htmlText.Length)
                        {
                            href = htmlText.IndexOf(a, a.Length);
                        }
                        else
                        {
                            href = -1;
                        }
                    }
                    int results1 = htmlText.IndexOf("<ul class=\"repo-list\">") + 22;
                    int results2 = htmlText.Substring(results1).IndexOf("</ul>");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage < 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("ITResults");
                    cookie.Value = "Github";
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ITResults");
                cookie.Value = "Github";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        catch (Exception error)
        {
            Google.Visible = false;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = false;
            ResultsTxt.Visible = true;
            ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。<br/><br/> Hata Mesajı: " + error;
        }
        WebArama.Visible = true;
        GörselArama.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;


        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.BlueViolet;
        IT.Font.Bold = true;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;

        int sonuçlar = GorselSonuclar.Items.Count;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + "immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + "개의 이미지 찾음";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekunde";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " görsel bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " images trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Bilder in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " şəkil tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " immagini trovate in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " изображений найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " imágenes encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " imagens encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 이미지 찾음";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "枚の画像が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " kép található " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " изображение намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " slika pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " images found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Academic()
    {
        Google_R.Visible = false;
        Artado_R.Visible = true;
        Bing_R.Visible = false;
        Yahoo_R.Visible = false;
        Petal_R.Visible = false;
        Youtube_R.Visible = false;
        İzlesene_R.Visible = false;
        Github_R.Visible = false;
        Scholar_R.Visible = true;
        Base_R.Visible = true;
        BNews_R.Visible = false;

        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        //Akademik Arama
        SqlConnection baglanti = new SqlConnection(con);
        string aranan = Request.QueryString["i"];
        string[] s;
        aranan = aranan.Replace(",", "").Replace(":", "").Replace(".", "").Replace(";", "").Replace("için", "").Replace("ile", "");
        s = aranan.Split(' ');
        arama_çubugu2.Attributes.Add("Value", aranan);
        Page.Title = aranan + " - Artado Search";

        System.Web.HttpCookie cookieaca = HttpContext.Current.Request.Cookies["AcademicResults"];

        try
        {
            if (cookieaca != null && cookieaca.Value != null)
            {
                if (cookieaca.Value == "Artado")
                {
                    Artado_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button1.Attributes.Add("style", "color: black;");
                    SözlükArama.Visible = false;
                    GörselArama.Visible = false;
                    WebArama.Visible = false;
                    MüzikArama.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel6.Visible = false;
                    Makaleler.Visible = true;
                    HavaDurumu.Visible = false;
                    Translate.Visible = false;
                    Panel1.Visible = false;
                    IPPanel.Visible = false;
                    Google.Visible = false;
                    Showcase.Visible = false;
                    News.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel8.Visible = false;
                    Filtre.Visible = false;

                    PagedDataSource pdsakademik = new PagedDataSource();
                    foreach (string kelime in s)
                    {
                        int ek;
                        ek = kelime.ToLower().IndexOf("ler");

                        if (ek >= 0)
                        {
                            string yenikelime = kelime.Substring(0, kelime.Length - 3);

                            //Makale Arama
                            SqlDataAdapter adp = new SqlDataAdapter("select *, Title from dbo.Articles where Title Like '%" + yenikelime + "%' or Description Like '%" + yenikelime + "%' order by Rank desc", baglanti);
                            DataTable dt = new DataTable();
                            pdsakademik.DataSource = dt.DefaultView;
                            pdsakademik.AllowPaging = true;
                            pdsakademik.PageSize = 10;
                            int currentPage;
                            if (Request.QueryString["page"] != null)
                            {
                                currentPage = Int32.Parse(Request.QueryString["mpage"]);
                            }
                            else
                            {
                                currentPage = 1;
                            }
                            pdsakademik.CurrentPageIndex = currentPage - 1;
                            Label5.Text = "Sayfa: " + currentPage + " / " + pdsakademik.PageCount;
                            if (!pdsakademik.IsFirstPage)
                            {
                                HyperLink3.NavigateUrl = "search?i=" + aranan + "&theme=" + Page.Theme + "&mpage=" + (currentPage - 1);
                            }
                            if (!pdsakademik.IsLastPage)
                            {
                                HyperLink4.NavigateUrl = "search?i=" + aranan + "&theme=" + Page.Theme + "&mpage=" + (currentPage + 1);
                            }
                            AkademikSonuçlar.DataSource = pdsakademik;
                            AkademikSonuçlar.DataBind();
                        }
                        else
                        {
                            //Makale Arama
                            SqlDataAdapter adp = new SqlDataAdapter("select *, Title from dbo.Articles where Title Like '%" + kelime + "%' or Description Like '%" + kelime + "%' order by Rank desc", baglanti);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            pdsakademik.DataSource = dt.DefaultView;
                            pdsakademik.AllowPaging = true;
                            pdsakademik.PageSize = 10;
                            int currentPage;
                            if (Request.QueryString["page"] != null)
                            {
                                currentPage = Int32.Parse(Request.QueryString["mpage"]);
                            }
                            else
                            {
                                currentPage = 1;
                            }
                            pdsakademik.CurrentPageIndex = currentPage - 1;
                            Label5.Text = "Sayfa: " + currentPage + " / " + pdsakademik.PageCount;
                            if (!pdsakademik.IsFirstPage)
                            {
                                HyperLink3.NavigateUrl = "search?i=" + aranan + "&theme=" + Page.Theme + "&mpage=" + (currentPage - 1);
                            }
                            if (!pdsakademik.IsLastPage)
                            {
                                HyperLink4.NavigateUrl = "search?i=" + aranan + "&theme=" + Page.Theme + "&mpage=" + (currentPage + 1);
                            }
                            AkademikSonuçlar.DataSource = pdsakademik;
                            AkademikSonuçlar.DataBind();
                        }
                    }
                }
                else if (cookieaca.Value == "Scholar")
                {
                    Scholar_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button8.Attributes.Add("style", "color: black;");
                    if (cookielang != null && cookielang.Value != null)
                    {
                        if (cookielang.Value == "en-AU")
                        {
                            ScholarFiltre.SelectedValue = "az";
                        }
                        else if (cookielang.Value == "en-BZ")
                        {
                            ScholarFiltre.SelectedValue = "ba";
                        }
                        else
                        {
                            ScholarFiltre.SelectedValue = cookielang.Value;
                        }
                    }
                    else
                    {
                        try
                        {
                            ScholarFiltre.SelectedValue = lang;
                        }
                        catch
                        {
                            ScholarFiltre.SelectedValue = "en-US";
                        }
                    }
                    SözlükArama.Visible = false;
                    GörselArama.Visible = false;
                    Makaleler.Visible = false;
                    MüzikArama.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel6.Visible = false;
                    HavaDurumu.Visible = false;
                    Translate.Visible = false;
                    Panel1.Visible = false;
                    IPPanel.Visible = false;
                    Google.Visible = false;
                    Showcase.Visible = false;
                    News.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel8.Visible = false;
                    Filtre.Visible = false;
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = true;
                    DropDownList1.Visible = false;
                    Sort.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;

                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 0;
                    }
                    string github = "https://scholar.google.com/scholar?start=" + currentPage + "&q=" + aranan + "&hl=" + ScholarFiltre.SelectedValue;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    string a = "href=\"/";
                    int href = htmlText.IndexOf(a);
                    while (href >= 0)
                    {
                        htmlText = htmlText.Replace("\"/", "\"https://scholar.google.com/");
                        if (a.Length < htmlText.Length)
                        {
                            href = htmlText.IndexOf(a, a.Length);
                        }
                        else
                        {
                            href = -1;
                        }
                    }
                    int results1 = htmlText.IndexOf("<div id=\"gs_res_ccl_mid\">") + 25;
                    int results2 = htmlText.Substring(results1).IndexOf("</div><div id=\"gs_res_ccl_bot\">");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage < 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                }
                else if (cookieaca.Value == "Base")
                {
                    Base_R.Attributes.Add("style", "background-color: white; color: black;");
                    Button9.Attributes.Add("style", "color: black;");
                    SözlükArama.Visible = false;
                    GörselArama.Visible = false;
                    Makaleler.Visible = false;
                    MüzikArama.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel6.Visible = false;
                    HavaDurumu.Visible = false;
                    Translate.Visible = false;
                    Panel1.Visible = false;
                    IPPanel.Visible = false;
                    Google.Visible = false;
                    Showcase.Visible = false;
                    News.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel8.Visible = false;
                    Filtre.Visible = false;
                    Google.Visible = false;
                    rptAramaSonuclari.Visible = false;
                    Filtre.Visible = true;
                    DropDownList1.Visible = false;
                    ScholarFiltre.Visible = false;
                    Lang.Visible = false;
                    Sort.Visible = false;
                    PageSelect.Visible = false;
                    Text.Visible = false;
                    GoogleImage.Visible = false;
                    OtherResults.Visible = true;
                    int currentPage;
                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 0;
                    }
                    string github = "https://www.base-search.net/Search/Results?lookfor=" + aranan + "&type=all&page=" + currentPage;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string htmlText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    string a = "href=\"/";
                    int href = htmlText.IndexOf(a);
                    while (href >= 0)
                    {
                        htmlText = htmlText.Replace("\"/", "\"https://www.base-search.net/");
                        if (a.Length < htmlText.Length)
                        {
                            href = htmlText.IndexOf(a, a.Length);
                        }
                        else
                        {
                            href = -1;
                        }
                    }
                    int results1 = htmlText.IndexOf("<div id=\"hit-list\">") + 19;
                    int results2 = htmlText.Substring(results1).IndexOf("<div class=\"row\" id=\"all-hits-export-row\">");
                    string resulttext = htmlText.Substring(results1, results2);
                    ResultsTxt.Text = resulttext;

                    if (currentPage < 1)
                    {
                        HyperLink5.Visible = false;
                    }
                    else
                    {
                        HyperLink5.Visible = true;
                        HyperLink5.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage - 1);
                    }

                    HyperLink6.NavigateUrl = "search?i=" + aranan + "&page=" + (currentPage + 1);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("AcademicResults");
                    cookie.Value = "Base";
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie("AcademicResults");
                cookie.Value = "Base";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        catch
        {
            Google.Visible = false;
            rptAramaSonuclari.Visible = false;
            Filtre.Visible = false;
            PageSelect.Visible = false;
            Text.Visible = false;
            GoogleImage.Visible = false;
            ResultsTxt.Visible = true;
            ResultsTxt.Text = "Upps! Bir hata oluştu.<br/><br/> Upps! Something went wrong.<br/><br/> Opps! Etwas ist schief gelaufen.<br/><br/> Oups! Quelque chose s'est mal passé.<br/><br/> Ой! Что-то пошло не так.<br/><br/> 出问题了。";
        }

        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.BlueViolet;
        Akademik.Font.Bold = true;

        //int sonuçlar = AkademikSonuçlar.Items.Count * pdsakademik.Count;

        int sonuçlar = AkademikSonuçlar.Items.Count;
        if (cookielang != null && cookielang.Value != null)
        {
            if (cookielang.Value == "tr-TR")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " makale bulundu";
            }
            else if (cookielang.Value == "en-US")
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (cookielang.Value == "fr-FR")
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (cookielang.Value == "de-DE")
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (cookielang.Value == "en-AU")
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (cookielang.Value == "it-IT")
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (cookielang.Value == "ru-RU")
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (cookielang.Value == "zh-CHS")
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (cookielang.Value == "es-ES")
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "pt-PT")
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (cookielang.Value == "ko-KR")
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (cookielang.Value == "ja-JP")
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (cookielang.Value == "hu-HU")
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (cookielang.Value == "bg-BG")
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (cookielang.Value == "en-BZ")
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyede " + sonuçlar + " makale bulundu";
            }
            else if (lang == "en".ToLower())
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
            else if (lang == "fr".ToLower())
            {
                Label1.Text = sonuçlar + " résultats trouvés en " + watch.Elapsed.Seconds + " seconde";
            }
            else if (lang == "de".ToLower())
            {
                Label1.Text = sonuçlar + " Ergebnisse in " + watch.Elapsed.Seconds + " Sekunde gefunden";
            }
            else if (lang == "az".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " saniyədə " + sonuçlar + " nəticə tapıldı";
            }
            else if (lang == "it".ToLower())
            {
                Label1.Text = sonuçlar + " risultati trovati in " + watch.Elapsed.Seconds + " secondi";
            }
            else if (lang == "ru".ToLower())
            {
                Label1.Text = sonuçlar + " результатов найдено за " + watch.Elapsed.Seconds + " секунд";
            }
            else if (lang == "zh".ToLower())
            {
                Label1.Text = sonuçlar + "秒内找到" + watch.Elapsed.Seconds + "个结果";
            }
            else if (lang == "es".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados en " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "pt".ToLower())
            {
                Label1.Text = sonuçlar + " resultados encontrados em " + watch.Elapsed.Seconds + " segundos";
            }
            else if (lang == "ko".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + " 초 안에 " + sonuçlar + " 개의 결과를 찾았습니다";
            }
            else if (lang == "jp".ToLower())
            {
                Label1.Text = watch.Elapsed.Seconds + "秒で" + sonuçlar + "件の結果が見つかりました";
            }
            else if (lang == "hu".ToLower())
            {
                Label1.Text = sonuçlar + " találat " + watch.Elapsed.Seconds + " másodperc alatt";
            }
            else if (lang == "bg".ToLower())
            {
                Label1.Text = sonuçlar + " резултата намерени за " + watch.Elapsed.Seconds + " секунди";
            }
            else if (lang == "bs".ToLower())
            {
                Label1.Text = sonuçlar + " rezultata pronađeno u " + watch.Elapsed.Seconds + " sekundi";
            }
            else
            {
                Label1.Text = sonuçlar + " results found in " + watch.Elapsed.Seconds + " second";
            }
        }
    }

    public void Feedback_P()
    {
        string aranan = Request.QueryString["i"];

        Page.Title = aranan + " - Artado Search";
        arama_çubugu2.Attributes.Add("Value", aranan);
        aranan = aranan.Trim();

        buttons_r.Visible = false;
        WebArama.Visible = false;
        GörselArama.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Makaleler.Visible = false;
        HavaDurumu.Visible = false;
        Translate.Visible = false;
        Panel1.Visible = false;
        IPPanel.Visible = false;
        Google.Visible = false;
        Showcase.Visible = false;
        News.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel8.Visible = false;
        Filtre.Visible = false;
        Text.Visible = false;

        Web.ForeColor = System.Drawing.Color.LightBlue;
        Web.Font.Bold = false;

        Görsel.ForeColor = System.Drawing.Color.LightBlue;
        Görsel.Font.Bold = false;

        Sözlük.ForeColor = System.Drawing.Color.LightBlue;
        Sözlük.Font.Bold = false;

        Video.ForeColor = System.Drawing.Color.LightBlue;
        Video.Font.Bold = false;

        News_button.ForeColor = System.Drawing.Color.LightBlue;
        News_button.Font.Bold = false;

        Film.ForeColor = System.Drawing.Color.LightBlue;
        Film.Font.Bold = false;

        IT.ForeColor = System.Drawing.Color.LightBlue;
        IT.Font.Bold = false;

        Müzik.ForeColor = System.Drawing.Color.LightBlue;
        Müzik.Font.Bold = false;

        Akademik.ForeColor = System.Drawing.Color.LightBlue;
        Akademik.Font.Bold = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        if (aranan == null)
        {
            aranan = Request.QueryString["q"];
            if (aranan == null)
            {
                aranan = Request.QueryString["p"];
                if (aranan == null)
                {
                    aranan = Request.QueryString["ei"];
                }
            }
            Response.Redirect("search?i=" + aranan + "&page=1");
        }

        System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
        string lang = kultur.TwoLetterISOLanguageName;
        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection baglanti2 = new SqlConnection(admn);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        string botdetect = Request.UserAgent;
        int bot = botdetect.IndexOf("bot".Trim().ToLower());
        if (bot >= 0)
        {
            Response.Redirect("/");
        }

        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            if(old.Value == "/Icons/artado_searchv2.png")
            {
                Image1.Src = "/Icons/android-chrome-192x192.png";
            }
            else if(old.Value == "/Icons/artado_searchv3.png")
            {
                Image1.Src = "/Icons/artadov3-colorful-icon.png";
            }
            else if (old.Value == "/Icons/LGBT/artado_searchv2_lgbt.png")
            {
                Image1.Src = "/Icons/LGBT/artadov3-lgbt.png";
            }
            else if (old.Value == "/Icons/tr/artado_searchv2_tr.png")
            {
                Image1.Src = "/Icons/tr/artadov3_tr2.png";
            }
            else if (old.Value == "/Icons/fr/artado_searchv2_fr.png")
            {
                Image1.Src = "/Icons/fr/artado_fr.png";
            }
            else if (old.Value == "/Icons/de/artado_searchv2_de.png")
            {
                Image1.Src = "/Icons/de/artado_de.png";
            }
            else if (old.Value == "/Icons/uk/artado_searchv2_uk.png")
            {
                Image1.Src = "/Icons/uk/artado-uk.png";
            }
            else if (old.Value == "/Icons/islam/islam.png")
            {
                Image1.Src = "/Icons/islam/artado_islam.png";
            }
            else if (old.Value == "/Icons/oldies/old.png")
            {
                Image1.Src = "/Icons/oldies/old-icon.png";
            }
        }
        else
        {
            Image1.Src = "/Icons/android-chrome-192x192.png";
        }

        string type = Request.QueryString["type"];

        if (type == "web")
            Start();
        else if (type == "image")
            Image();
        else if (type == "video")
            Videos();
        else if (type == "news")
            News_R();
        else if (type == "social")
            Social_R();
        else if (type == "info")
            Info();
        else if (type == "movie")
            Movie();
        else if (type == "it")
            it();
        else if (type == "academic")
            Academic();
        else if (type == "feedback")
            Feedback_P();
        else
            Start();
    }
    protected override void InitializeCulture()
    {
        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else
        {
            System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string kulturDilKod = kultur.TwoLetterISOLanguageName;
        }

        base.InitializeCulture();
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Night";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];

        int sharp = arama_çubugu2.Text.IndexOf("#");
        int ok1 = arama_çubugu2.Text.IndexOf("<");
        int ok2 = arama_çubugu2.Text.IndexOf(">");

        string schange = arama_çubugu2.Text.Replace("#", "%23");
        string okc1 = arama_çubugu2.Text.Replace("<", "%3C");
        string okc2 = arama_çubugu2.Text.Replace("'", " ");

        if (ok1 >= 0)
        {
            Response.Redirect("/search?i=" + okc1.Trim() + "&type=" + type);
        }
        else if (ok2 >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim() + "&type=" + type);
        }
        else if (sharp >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim() + "&type=" + type);
        }
        else
        {
            Response.Redirect("/search?i=" + arama_çubugu2.Text.Trim() + "&type=" + type);
        }
    }

    protected void Web_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=web");
    }

    protected void Görsel_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=image");
    }

    protected void Sözlük_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=info");
    }

    protected void Müzik_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=movie");
    }

    protected void Akademik_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=academic");
    }

    protected void Button20_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=video");
    }

    protected void Button21_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=news");
    }

    protected void Button22_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=social");
    }

    protected void Button23_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=it");
    }

    protected void rptAramaSonuclari_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.Redirect("url.aspx");
    }

    protected void Gönder_Click(object sender, EventArgs e)
    {
        try
        {
            int mailsembol;
            mailsembol = Mail.Text.IndexOf("@");
            if (Mail.Text.EndsWith(".com") || mailsembol >= 0)
            {
                //Geri Bildirimi veritabanına kaydediyor
                SqlConnection baglantiistek = new SqlConnection(admn);
                if (baglantiistek.State == ConnectionState.Closed)
                    baglantiistek.Open();
                string istek = "insert into Feedbacks(MailAdress, Feedback) values (@MailAdress,@Feedback)";
                SqlCommand komut = new SqlCommand(istek, baglantiistek);
                komut.Parameters.AddWithValue("@MailAdress", Mail.Text);
                komut.Parameters.AddWithValue("@Feedback", Deneyim.InnerText);
                komut.ExecuteNonQuery();

                Sonuc.Text = "<br/>" + "Geri bildiriminiz için teşekkür ederiz.";
            }
            else
            {
                Sonuc.Text = "E-postanızı kontrol ediniz.";
            }

        }
        catch (Exception hata)
        {
            Sonuc.Text = "<br/>" + "Üzgünüz bir sorun oluştu. Sorunu bize <a href='https://twitter.com/intent/tweet?text=Bir%20sorunum%20var!%20@ArtadoL%20Sorun:" + hata + "'>Twitter<a/> veya <a href='/İletişim'>başka platformlardan<a/> bildirebilirsiniz.";
        }
    }

    protected void Image1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/");
    }

    protected void Feedback_Click(object sender, EventArgs e)
    {
        string aranan = Request.QueryString["i"];

        Response.Redirect("/search?i=" + aranan + "&type=feedback");
    }

    protected void Button17_Click(object sender, EventArgs e)
    {

    }

    protected void Google_B_Click(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];

        if (type == "web")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "image")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["ImageResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("ImageResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ImageResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "academic")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["AcademicResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("AcademicResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("AcademicResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Google";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];

        if (type == "web")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "image")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["ImageResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("ImageResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ImageResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "academic")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["AcademicResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("AcademicResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("AcademicResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "it")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["ITResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("ITResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ITResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Artado";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];

        if (type == "web")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else if (type == "news")
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["NewsResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("NewsResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("NewsResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
        else
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("WebResults");
                cookie.Value = "Bing";
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = "Yahoo";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = "Yahoo";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = "Petal";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = "Petal";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["VideoResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("VideoResults");
            cookie.Value = "Youtube";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("VideoResults");
            cookie.Value = "Youtube";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["VideoResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("VideoResults");
            cookie.Value = "İzlesene";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("VideoResults");
            cookie.Value = "İzlesene";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["ITResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("ITResults");
            cookie.Value = "Github";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("ITResults");
            cookie.Value = "Github";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["AcademicResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("AcademicResults");
            cookie.Value = "Base";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("AcademicResults");
            cookie.Value = "Base";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
}

class WikiInfos
{
    public string title { get; set; }
    public string extract { get; set; }

}

public class Result
{
    public Query query { get; set; }
}

public class Query
{
    public Dictionary<string, Page> pages { get; set; }
}

public class Page
{
    public string extract { get; set; }
}