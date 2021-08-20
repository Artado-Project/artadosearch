using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Proxy_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];
        if (url != null)
        {
            try
            {
                Home.Visible = false;
                Proxy.Visible = true;

                Web_Page.Src = "/Proxy/Run?url=" + url;
            }
            catch(Exception error)
            {
                Web_Page.InnerText = "Bir hata oluştu. Hata: " + error;
            }
        }
        else
        {
            Home.Visible = true;
            Proxy.Visible = false;
        }
    }

    protected override void InitializeCulture()
    {
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

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
    }

    protected void Search_Click(object sender, ImageClickEventArgs e)
    {
        if (arama_çubugu.Text.StartsWith("http"))
        {
            Response.Redirect("/proxy?url=" + arama_çubugu.Text);
        }
        else
        {
            Response.Redirect("/proxy?url=" + "http://" + arama_çubugu.Text);
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (arama_çubugu2.Text.StartsWith("http"))
        {
            Response.Redirect("/proxy?url=" + arama_çubugu2.Text);
        }
        else
        {
            Response.Redirect("/proxy?url=" + "http://" + arama_çubugu2.Text);
        }
    }
}