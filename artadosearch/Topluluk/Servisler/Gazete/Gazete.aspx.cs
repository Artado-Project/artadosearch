using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Gazete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void InitializeCulture()
    {
        string lang;
        string useragent = Request.UserAgent.ToLower();
        int detect = useragent.IndexOf("bot".ToLower());

        if (detect >= 0)
        {
            lang = "en";
        }
        else
        {
            lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);
        }

        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else if (lang != null && lang.Length > 0)
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            SqlConnection baglanti = new SqlConnection(admin);
            int mailsembol;
            mailsembol = arama_çubugu.Text.IndexOf("@");
            if (arama_çubugu.Text.EndsWith(".com") || mailsembol >= 0)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string mailekle = "insert into MailList(Mail) values (@Mail)";
                SqlCommand komut = new SqlCommand(mailekle, baglanti);
                komut.Parameters.AddWithValue("@Mail", arama_çubugu.Text);
                komut.ExecuteNonQuery();
                Sonuc.Text = "Abone olduğunuz için teşekkür ederiz.";
            }
            else
            {
                Sonuc.Text = "E-postanızı kontrol edin";
            }

        }
        catch(Exception hata)
        {
            Sonuc.Text = "<br/>" + "Üzgünüz bir sorun oluştu. Sorunu bize <a href='https://twitter.com/intent/tweet?text=Bir%20sorunum%20var!%20@ArtadoL%20Sorun:" + hata + "'>Twitter<a/> veya <a href='/İletişim'>başka platformlardan<a/> bildirebilirsiniz.";
        }
    }

    protected void Anasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ArtadoSoft/Home");
    }

    protected void Hakkımızda_Click(object sender, EventArgs e)
    {
        Response.Redirect("/About");
    }

    protected void İletişim_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Contact");
    }

    protected void Blog_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Forum");
    }

    protected void DestekOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Support");
    }
}