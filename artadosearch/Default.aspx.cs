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
    public string lang = "a";
    public string theme = "a";
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    string con2 = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
        string lang = kultur.TwoLetterISOLanguageName;
        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection baglanti2 = new SqlConnection(con2);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        string api = "2f0a475faa72b7ade6066d6279ee5ca5";

        City.Text = "Istanbul";

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
                HavaDurumu.Visible = true;
                City.Text = "Istanbul";
            }
        }
        else if (lang != null)
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
                HavaDurumu.Visible = true;
                City.Text = "Istanbul";
            }
        }
        else
        {
            string havabaglanti = "http://api.openweathermap.org/data/2.5/weather?q=" + "Istanbul" + "&mode=xml&lang=" + "en" + "&units=metric&appid=" + api;
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
            HavaDurumu.Visible = true;
            City.Text = "Istanbul";
        }

        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            if(old.Value == "/Icons/artado_searchv2.png")
            {
                Image1.ImageUrl = "/Icons/android-chrome-192x192.png";
            }
            else if(old.Value == "/Icons/artado_searchv3.png")
            {
                Image1.ImageUrl = "/Icons/artadov3-colorful-icon.png";
            }
            else if (old.Value == "/Icons/LGBT/artado_searchv2_lgbt.png")
            {
                Image1.ImageUrl = "/Icons/LGBT/artadov3-lgbt.png";
            }
            else if (old.Value == "/Icons/tr/artado_searchv2_tr.png")
            {
                Image1.ImageUrl = "/Icons/tr/artadov3_tr2.png";
            }
            else if (old.Value == "/Icons/fr/artado_searchv2_fr.png")
            {
                Image1.ImageUrl = "/Icons/fr/artado_fr.png";
            }
            else if (old.Value == "/Icons/de/artado_searchv2_de.png")
            {
                Image1.ImageUrl = "/Icons/de/artado_de.png";
            }
            else if (old.Value == "/Icons/uk/artado_searchv2_uk.png")
            {
                Image1.ImageUrl = "/Icons/uk/artado-uk.png";
            }
            else if (old.Value == "/Icons/islam/islam.png")
            {
                Image1.ImageUrl = "/Icons/islam/artado_islam.png";
            }
            else if (old.Value == "/Icons/oldies/old.png")
            {
                Image1.ImageUrl = "/Icons/oldies/old-icon.png";
            }
        }
        else
        {
            Image1.ImageUrl = "/Icons/android-chrome-192x192.png";
        }

        HttpCookie id = HttpContext.Current.Request.Cookies["id"];
        if (id != null && id.Value != null && baglanti2 != null)
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

        Label12.Visible = false;

        Kontrol.Attributes.Add("style", "display: none;");

        komutlar.Visible = false;

        Araçlar.Visible = false;

        ////Google CSE without direct connection to Google in client-side
        //string hourpath = Server.MapPath("/hour.txt");
        //string hourMinute = DateTime.Now.ToString("HH");

        //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:52941/hour.txt".Trim());
        //WebResponse response = request.GetResponse();
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //string hour = reader.ReadToEnd();

        //int lastcheck = Convert.ToInt16(hour);
        //int now = Convert.ToInt16(hourMinute);

        //if (lastcheck + 3 < now)
        //    cse();
        //else
        //    File.WriteAllText(hourpath, hourMinute);
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
            lang = kultur.TwoLetterISOLanguageName;

            if (lang == "tr".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            }
            else if (lang == "en".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else if (lang == "fr".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            }
            else if (lang == "de".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            }
            else if (lang == "az".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-AU");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-AU");
            }
            else if (lang == "it".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("it-IT");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");
            }
            else if (lang == "ru".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            }
            else if (lang == "zh".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CHS");
            }
            else if (lang == "es".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            }
            else if (lang == "pt".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-PT");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-PT");
            }
            else if (lang == "ko".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko-KR");
            }
            else if (lang == "jp".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("jp-JP");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("jp-JP");
            }
            else if (lang == "hu".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hu-HU");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hu-HU");
            }
            else if (lang == "bg".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bg-BG");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");
            }
            else if (lang == "bs".ToLower())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-BZ");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-BZ");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
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
            if (old.Value == "/Icons/artado_searchv2.png")
            {
                Image1.ImageUrl = "/Icons/android-chrome-192x192.png";
            }
            else if (old.Value == "/Icons/artado_searchv3.png")
            {
                Image1.ImageUrl = "/Icons/artadov3-colorful-icon.png";
            }
            else if (old.Value == "/Icons/LGBT/artado_searchv2_lgbt.png")
            {
                Image1.ImageUrl = "/Icons/LGBT/artadov3-lgbt.png";
            }
            else if (old.Value == "/Icons/tr/artado_searchv2_tr.png")
            {
                Image1.ImageUrl = "/Icons/tr/artadov3_tr2.png";
            }
            else if (old.Value == "/Icons/fr/artado_searchv2_fr.png")
            {
                Image1.ImageUrl = "/Icons/fr/artado_fr.png";
            }
            else if (old.Value == "/Icons/de/artado_searchv2_de.png")
            {
                Image1.ImageUrl = "/Icons/de/artado_de.png";
            }
            else if (old.Value == "/Icons/uk/artado_searchv2_uk.png")
            {
                Image1.ImageUrl = "/Icons/uk/artado-uk.png";
            }
            else if (old.Value == "/Icons/islam/islam.png")
            {
                Image1.ImageUrl = "/Icons/islam/artado_islam.png";
            }
            else if (old.Value == "/Icons/oldies/old.png")
            {
                Image1.ImageUrl = "/Icons/oldies/old-icon.png";
            }
        }
        else
        {
            Image1.ImageUrl = "/Icons/android-chrome-192x192.png";
        }

        HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
        if (old2 != null && old2.Value != null)
        {
            bdy1.Attributes.Add("style", "background:url(" + old2.Value + "); background-size:cover; background-repeat:no-repeat; background-position: center;");
        }

        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Night";
        }

        System.Web.HttpCookie cookie3 = HttpContext.Current.Request.Cookies["WebResults"];
        if (cookie3 != null && cookie3.Value != null)
        {
            DropDownList3.SelectedValue = cookie3.Value;
        }

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
        string lang = kultur.TwoLetterISOLanguageName;

        if (cookielang != null && cookielang.Value != null)
        {
            DropDownList2.SelectedValue = cookielang.Value;
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                DropDownList2.SelectedValue = "tr-TR";
            }
            else if (lang == "en".ToLower())
            {
                DropDownList2.SelectedValue = "en-US";
            }
            else if (lang == "fr".ToLower())
            {
                DropDownList2.SelectedValue = "fr-FR";
            }
            else if (lang == "de".ToLower())
            {
                DropDownList2.SelectedValue = "de-DE";
            }
            else if (lang == "az".ToLower())
            {
                DropDownList2.SelectedValue = "en-AU";
            }
            else if (lang == "it".ToLower())
            {
                DropDownList2.SelectedValue = "it-IT";
            }
            else if (lang == "ru".ToLower())
            {
                DropDownList2.SelectedValue = "ru-RU";
            }
            else if (lang == "zh".ToLower())
            {
                DropDownList2.SelectedValue = "zh-CHS";
            }
            else if (lang == "es".ToLower())
            {
                DropDownList2.SelectedValue = "es-ES";
            }
            else if (lang == "pt".ToLower())
            {
                DropDownList2.SelectedValue = "pt-PT";
            }
            else if (lang == "ko".ToLower())
            {
                DropDownList2.SelectedValue = "ko-KR";
            }
            else if (lang == "jp".ToLower())
            {
                DropDownList2.SelectedValue = "jp-JP";
            }
            else if (lang == "hu".ToLower())
            {
                DropDownList2.SelectedValue = "hu-HU";
            }
            else if (lang == "bg".ToLower())
            {
                DropDownList2.SelectedValue = "bg-BG";
            }
            else if (lang == "bs".ToLower())
            {
                DropDownList2.SelectedValue = "en-BZ";
            }
            else
            {
                DropDownList2.SelectedValue = "en-US";
            }
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
        Kontrol.Attributes.Add("style", "display: block;");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Attributes.Add("style", "display: none;");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Mail");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Donate");
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

            HttpCookie cookie = new HttpCookie("Lang");
            cookie.Value = DropDownList2.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            Session["language"] = DropDownList2.SelectedValue;
            HttpCookie cookie = new HttpCookie("Lang");
            cookie.Value = DropDownList2.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(DropDownList2.SelectedValue);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(DropDownList2.SelectedValue);
            if (cookie.Value == "tr") { Session["ddindex"] = 0; }
            else if (cookie.Value == "en") { Session["ddindex"] = 1; }
            else if (cookie.Value == "fr") { Session["ddindex"] = 2; }
            else if (cookie.Value == "de") { Session["ddindex"] = 3; }
            else if (cookie.Value == "en") { Session["ddindex"] = 4; }
            else if (cookie.Value == "it") { Session["ddindex"] = 5; }
            else if (cookie.Value == "ru") { Session["ddindex"] = 6; }
            else if (cookie.Value == "zh") { Session["ddindex"] = 7; }
            else if (cookie.Value == "es") { Session["ddindex"] = 8; }
            else if (cookie.Value == "pt") { Session["ddindex"] = 9; }
            else if (cookie.Value == "ko") { Session["ddindex"] = 10; }
            else if (cookie.Value == "ja") { Session["ddindex"] = 11; }
            else if (cookie.Value == "hu") { Session["ddindex"] = 12; }
            else if (cookie.Value == "bg") { Session["ddindex"] = 13; }
            else if (cookie.Value == "en") { Session["ddindex"] = 14; }
        }
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

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["WebResults"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = DropDownList3.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("WebResults");
            cookie.Value = DropDownList3.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }


    //Google CSE without direct connection to Google in client-side
    public void cse()
    {
        string googlecse = "https://cse.google.com/cse.js?cx=160e826a9c5ebe821";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(googlecse.Trim());
        WebResponse response = request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string js = reader.ReadToEnd();
        string newjs = js.Replace("https://www.google.com/cse/static/element/%{versionDir}%{versionSlash}cse_element__%{lang}.js", "/js/google_cse.js");
        string path = Server.MapPath(@"/js/google.js");
        File.WriteAllText(path, newjs);

        string hourpath = Server.MapPath("/hour.txt");
        string hourMinute = DateTime.Now.ToString("HH");

        HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("http://localhost:52941/hour.txt".Trim());
        WebResponse response2 = request2.GetResponse();
        StreamReader reader2 = new StreamReader(response2.GetResponseStream());
        string hour = reader2.ReadToEnd();

        int lastcheck = Convert.ToInt16(hour);
        int now = Convert.ToInt16(hourMinute);

        if (lastcheck >= 24)
        {
            File.WriteAllText(hourpath, "0");
        }
        else
        {
            File.WriteAllText(hourpath, hourMinute);
        }
        
    }
}