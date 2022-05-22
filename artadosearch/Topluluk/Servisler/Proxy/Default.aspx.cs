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