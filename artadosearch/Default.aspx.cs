using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Xml.Linq;
using SpeechLib;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    public string lang;
    public string theme;
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    string con2 = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection baglanti2 = new SqlConnection(con2);

        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            DropDownList1.SelectedValue = cookie.Value;
        }

        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            Image1.ImageUrl = old.Value;
        }
        else
        {
            Image1.ImageUrl = "/Icons/artado_searchv2.png";
        }

        HttpCookie id = HttpContext.Current.Request.Cookies["id"];
        if (id != null && id.Value != null)
        {
            ProfilePic.Visible = true;
            Button2.Visible = false;
            string sorgu2 = "SELECT Image FROM dbo.Users where PassID='" + id.Value + "' ";
            string image;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            baglanti2.Open();
            image = (string)komut2.ExecuteScalar();
            baglanti2.Close();
            ProfilePic.ImageUrl = "/images/" + image;
        }
        else
        {
            ProfilePic.Visible = false;
            Button2.Visible = true;
        }

        HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
        if (old2 != null && old2.Value != null)
        {
            bdy1.Attributes.Add("style", "background:url(" + old2.Value + ") no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;");
        }

        System.Web.HttpCookie cookie2 = HttpContext.Current.Request.Cookies["Journal"];
        if (cookie2 != null && cookie2.Value != null)
        {
            if (cookie2.Value == "true")
            {
                Journal.Visible = true;
                footer.Visible = true;
            }
            else
            {
                Journal.Visible = false;
                footer.Visible = false;
            }
        }
        else
        {
            Journal.Visible = false;
            footer.Visible = false;
        }

        Label12.Visible = false;
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        Kontrol.Visible = false;

        komutlar.Visible = false;

        Araçlar.Visible = false;

        Ses.Visible = false;

        string hata = Request.QueryString["hata"];
        string empty = Request.QueryString["empty"];

        if (empty == "true")
        {
            Label12.Visible = true;
            Label12.Text = "Boş arama yaptınız!";
            Label12.ForeColor = System.Drawing.Color.Red;
        }

        if (cookielang != null && cookielang.Value != null)
        {
            ddlanguage.Text = cookielang.Value;
        }

        if (!Page.IsPostBack)
        {
            if (Session["ddindex"] != null)
            {
                ddlanguage.SelectedValue = Session["ddindex"].ToString();
                ddlanguage.SelectedIndex = Convert.ToInt32(Session["ddindex"].ToString());
            }
            else
            {
                ddlanguage.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
            }
        }

        if (Journal.Visible == true)
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

            string location = "http://api.ipinfodb.com/v3/ip-city/?key=827d056c355bcb601ce33da0280d1e8e583a0cc6b213e06908cc15844f64a9bb&ip=" + ipAddress + "&format=xml";
            XmlTextReader oku = new XmlTextReader(location);
            try
            {
                while (oku.Read())
                {
                    if (oku.NodeType == XmlNodeType.Element)
                    {
                        switch (oku.Name)
                        {
                            case "regionName":
                                City.Text = Convert.ToString(oku.ReadString());
                                break;
                        }
                    }
                }
                oku.Close();
            }
            catch
            {

            }

            if (cookielang != null && cookielang.Value != null)
            {
                try
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + City.Text + "&mode=xml&lang=" + cookielang + "&units=metric&appid=" + api;
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
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
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
                    HavaImg.ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
                    SıcaklıkTxt.Text = sicaklik + " ºC";
                    DurumTxt.Text = durum;
                    Min.Text = "Minimum Sıcaklık :   " + minsicaklik + "ºC";
                    Max.Text = "Maksimum Sıcaklık :   " + maxsicaklik + "ºC";
                    Hissedilen.Text = "Hissedilen Sıcaklık :   " + feels_like + "ºC";

                    Doğuş.Text = "Güneş Doğuşu :   " + sunrise;
                    Batış.Text = "Güneş Batışı :   " + sunset;
                    HavaDurumu.Visible = true;
                }
                catch
                {
                    string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + "Istanbul" + "&mode=xml&lang=" + lang + "&units=metric&appid=" + api;
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
                    City.Text = "Istanbul";
                }
            }

            //Bilgi Kutusu Arama
            PagedDataSource pdsinfo = new PagedDataSource();
            SqlDataAdapter adpınfo = new SqlDataAdapter("select *, InfoLink from dbo.Infos order by InfoID desc", baglanti);
            DataTable dtınfo = new DataTable();
            adpınfo.Fill(dtınfo);
            pdsinfo.DataSource = dtınfo.DefaultView;
            pdsinfo.AllowPaging = true;
            pdsinfo.PageSize = 1;
            InfoBox.DataSource = pdsinfo;
            InfoBox.DataBind();
            if (InfoBox.Items.Count == 0)
            {
                Panel4.Visible = false;
            }
        }
    }


    protected override void InitializeCulture()
    {
        lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);

        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            }
            else if (lang == "en".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else if (lang == "fr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            }
            else if (lang == "de".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            }
            else if (lang == "az".ToLower() || lang == "Lt-az".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-AU");
            }
            else if (lang == "it".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
            }
            else if (lang == "ru".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            }
            else if (lang == "zh".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CHS");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            }
            else if (lang == "es".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            else if (lang == "pz".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
            }
            else if (lang == "ko".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-KR");
            }
            else if (lang == "ja".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
            }
            else if (lang == "hu".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
            }
            else if (lang == "bg".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");
            }
            else if (lang == "bs".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-BZ");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-BZ");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }

        }
        base.InitializeCulture();
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie0 != null && cookie0.Value != null)
        {
            DropDownList1.SelectedValue = cookie0.Value;
        }

        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            Image1.ImageUrl = old.Value;
        }
        else
        {
            Image1.ImageUrl = "/Icons/artado_searchv2.png";
        }

        HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
        if (old2 != null && old2.Value != null)
        {
            bdy1.Attributes.Add("style", "background:url(" + old2.Value + "); background-size:cover; background-repeat:no-repeat; background-position: center;");
        }

        System.Web.HttpCookie cookie2 = HttpContext.Current.Request.Cookies["Journal"];
        if (cookie2 != null && cookie2.Value != null)
        {
            if (cookie2.Value == "true")
            {
                Journal.Visible = false;
                footer.Visible = false;
            }
            else
            {
                Journal.Visible = true;
                footer.Visible = true;
            }
        }

        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Dark";
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        int sharp = arama_çubugu.Text.IndexOf("#");
        int ok1 = arama_çubugu.Text.IndexOf("<");
        int ok2 = arama_çubugu.Text.IndexOf(">");
        int i = arama_çubugu.Text.IndexOf("İ");
        int ş = arama_çubugu.Text.ToLower().IndexOf("ş");

        string schange = arama_çubugu.Text.Replace("#", "%23");
        string okc1 = arama_çubugu.Text.Replace("<", "<");
        string okc2 = arama_çubugu.Text.Replace("'", " ");
        string ic = arama_çubugu.Text.Replace("İ", "%C4%B0");
        string şc = arama_çubugu.Text.ToLower().Replace("ş", "%C5%9F");

        if (ok1 >= 0)
        {
            Label12.Visible = true;
            Label12.Text = "Tehlikeli arama yaptınız!";
            Label12.ForeColor = System.Drawing.Color.Red;
        }
        else if (ok2 >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim());
        }
        else if (sharp >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim());
        }
        else if (i >= 0)
        {
            Response.Redirect("/search?i=" + ic.Trim());
        }
        else if (ş >= 0)
        {
            Response.Redirect("/search?i=" + şc.Trim());
        }
        else
        {
            Response.Redirect("/search?i=" + arama_çubugu.Text);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["Theme"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
            Server.Transfer(Request.Path);

            HttpCookie cookie = new HttpCookie("Theme");
            cookie.Value = DropDownList1.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("Theme");
            cookie.Value = DropDownList1.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = true;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Mail");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Donate");
    }

    public void listener_Reco(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
    {
        string heard = Result.PhraseInfo.GetText(0, -1, true);
        Text.Text = heard;
    }

    protected void Voice_Click(object sender, ImageClickEventArgs e)
    {
        Label12.Visible = true;
        Label12.Text = "Bu özellik çok yakında aktif olacaktır.";
        Label12.ForeColor = System.Drawing.Color.Red;
    }

    protected void Command_Click(object sender, ImageClickEventArgs e)
    {
        komutlar.Visible = true;
        Araçlar.Visible = false;
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".ddg";
        komutlar.Visible = true;
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".g";
        komutlar.Visible = true;
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".yt";
        komutlar.Visible = true;
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".i";
        komutlar.Visible = true;
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".r";
        komutlar.Visible = true;
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".eksi";
        komutlar.Visible = true;
    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".t";
        komutlar.Visible = true;
    }

    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".wiki";
        komutlar.Visible = true;
    }

    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".y";
        komutlar.Visible = true;
    }

    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".q";
        komutlar.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Welcome");
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["Lang"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
            Server.Transfer(Request.Path);
        }
        else
        {
            Session["language"] = ddlanguage.SelectedValue;
            //Sets the cookie that is to be used by Global.asax
            HttpCookie cookie = new HttpCookie("Lang");
            cookie.Value = ddlanguage.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            //Set the culture and reload for immediate effect.
            //Future effects are handled by Global.asax
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlanguage.SelectedValue);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlanguage.SelectedValue);
            if (cookie.Value == "tr-TR") { Session["ddindex"] = 0; } 
            else if (cookie.Value == "en-US") { Session["ddindex"] = 1; } 
            else if (cookie.Value == "fr-FR") { Session["ddindex"] = 2; } 
            else if (cookie.Value == "de-DE") { Session["ddindex"] = 3; } 
            else if (cookie.Value == "en-AU") { Session["ddindex"] = 4; }
            else if (cookie.Value == "it-IT") { Session["ddindex"] = 5; }
            else if (cookie.Value == "ru-RU") { Session["ddindex"] = 6; }
            else if (cookie.Value == "zh-CHS") { Session["ddindex"] = 7; }
            else if (cookie.Value == "es-ES") { Session["ddindex"] = 8; }
            else if (cookie.Value == "prt-pT") { Session["ddindex"] = 9; }
            else if (cookie.Value == "ko-KR") { Session["ddindex"] = 10; }
            else if (cookie.Value == "ja-JP") { Session["ddindex"] = 11; }
            else if (cookie.Value == "hu-HU") { Session["ddindex"] = 12; }
            else if (cookie.Value == "bg-BG") { Session["ddindex"] = 13; }
            else if (cookie.Value == "en-BZ") { Session["ddindex"] = 14; }
            Server.Transfer(Request.Path);
        }
        Response.Redirect("/");
    }

    protected void Tools_Click(object sender, ImageClickEventArgs e)
    {
        komutlar.Visible = false;
        Araçlar.Visible = true;
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("/Account?mode=register&url=/");
    }

    protected void ProfilePic_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Account?mode=settings");
    }
}


