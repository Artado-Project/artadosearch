using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using SpeechLib;

public partial class _Default : System.Web.UI.Page
{
    public string lang;
    public string theme;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label12.Visible = true;
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
        SqlConnection baglanti = new SqlConnection(con);
        baglanti.Open();
        string sorgu2 = "SELECT top 1 KelimeID FROM arda.Arananlar order by KelimeID desc";
        int aranan;
        SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
        aranan = (int)komut2.ExecuteScalar();
        string sorgu5 = "SELECT top 1 ID FROM arda.Sonuçlar order by ID desc";
        int date;
        SqlCommand komut3 = new SqlCommand(sorgu5, baglanti);
        date = (int)komut3.ExecuteScalar();
        string sorgu3 = "SELECT top 1 InfoID FROM arda.Infos order by InfoID desc";
        int detail;
        SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
        detail = (int)komut4.ExecuteScalar();
        Label12.Text = "2020 yılından itibaren " + aranan + " aramaya " + date + " sonuç ve " + detail + " bilgi sonucu ile yanıt verildi.";

        Kontrol.Visible = false;

        komutlar.Visible = false;

        Araçlar.Visible = false;

        Panel3.Visible = true;

        Ses.Visible = false;

        string hata = Request.QueryString["hata"];
        string empty = Request.QueryString["empty"];

        if (hata == "true")
        {
            Label5.Visible = true;
            Label5.Text = "Upss! Araman çok uzun. Lütfen tekrar dene.";
            Label5.ForeColor = System.Drawing.Color.Red; 
        }
        else if (empty == "true")
        {
            Label5.Visible = true;
            Label5.Text = "Boş arama yaptınız!";
            Label5.ForeColor = System.Drawing.Color.Red;
        }
        else if (arama_çubugu.Text.StartsWith("<"))
        {
            Label5.Visible = true;
            Label5.Text = "Tehlikeli arama yaptınız!";
            Label5.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            Panel3.Visible = false;
        }

        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
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
        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Dark";
        }


        theme = (string)Session["theme"];
        if ((theme != null) && (theme.Length != 0))
        {
            Page.Theme = theme;
            DropDownList1.SelectedValue = theme;
            HttpCookie themecookie = new HttpCookie("Theme");
            themecookie.Value = theme;
            themecookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(themecookie);
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
        string okc2 = arama_çubugu.Text.Replace(">", "gt;");
        string ic = arama_çubugu.Text.Replace("İ", "%C4%B0");
        string şc = arama_çubugu.Text.ToLower().Replace("ş", "%C5%9F");

        if (ok1 >= 0)
        {
            Label5.Visible = true;
            Label5.Text = "Tehlikeli arama yaptınız!";
            Label5.ForeColor = System.Drawing.Color.Red;
        }
        else if (ok2 >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim() + "&theme=" + Page.Theme + "&page=" + 1);
        }
        else if (sharp >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim() + "&theme=" + Page.Theme + "&page=" + 1);
        }
        else if (i >= 0)
        {
            Response.Redirect("/search?i=" + ic.Trim() + "&theme=" + Page.Theme + "&page=" + 1);
        }
        else if (ş >= 0)
        {
            Response.Redirect("/search?i=" + şc.Trim() + "&theme=" + Page.Theme + "&page=" + 1);
        }
        else
        {
            Response.Redirect("/search?i=" + arama_çubugu.Text + "&theme=" + Page.Theme + "&page=" + 1);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["theme"] = DropDownList1.SelectedItem.Value;
        Page.Response.Redirect(Page.Request.Url.ToString());
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
        Panel3.Visible = true;
        Label5.Visible = true;
        Label5.Text = "Bu özellik çok yakında aktif olacaktır.";
        Label5.ForeColor = System.Drawing.Color.Red;
    }

    protected void Command_Click(object sender, ImageClickEventArgs e)
    {
        komutlar.Visible = true;
        Panel3.Visible = false;
        Araçlar.Visible = false;
        Label12.Visible = false;
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".ddg";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".g";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".yt";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".i";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".r";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".eksi";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".t";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".wiki";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".y";
        komutlar.Visible = true;
        Panel3.Visible = false;
    }

    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        arama_çubugu.Text = ".q";
        komutlar.Visible = true;
        Panel3.Visible = false;
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
        Label12.Visible = false;
        Panel3.Visible = false;
        Araçlar.Visible = true;
    }
}


