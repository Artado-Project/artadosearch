using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.HttpCookie cookie2 = HttpContext.Current.Request.Cookies["Journal"];
        if (cookie2 != null && cookie2.Value != null)
        {
            if (cookie2.Value == "true")
            {
                CheckBox1.Checked = true;
            }
            else
            {
                CheckBox1.Checked = false;
            }
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/artado_searchv2.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/artado_searchv2.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/artado_searchv3.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/artado_searchv3.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/LGBT/artado_searchv2_lgbt.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/LGBT/artado_searchv2_lgbt.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/tr/artado_searchv2_tr.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/tr/artado_searchv2_tr.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/fr/artado_searchv2_fr.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/fr/artado_searchv2_fr.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/de/artado_searchv2_de.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/de/artado_searchv2_de.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/uk/artado_searchv2_uk.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/uk/artado_searchv2_uk.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/islam/islam.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/islam/islam.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["icon"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();

            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/oldies/old.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("icon");
            cookie.Value = "/Icons/oldies/old.png";
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["background"];

        if (arama_çubugu.Text == "" && arama_çubugu.Text.Length <= 0)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("background");
                cookie.Value = arama_çubugu.Text;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("background");
                cookie.Value = arama_çubugu.Text;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies["Journal"];
        if (CheckBox1.Checked == false)
        {
            if (cookie != null && cookie.Value != null)
            {
                cookie.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(cookie);

                System.Web.HttpCookie cookie2 = new System.Web.HttpCookie("Journal");
                cookie2.Value = "false";
                cookie2.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie2);
                CheckBox1.Checked = false;
            }
        }
        else
        {
            System.Web.HttpCookie cookie2 = new System.Web.HttpCookie("Journal");
            cookie2.Value = "true";
            cookie2.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie2);
            CheckBox1.Checked = true;
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies["Journal"];
        System.Web.HttpCookie cookie2 = HttpContext.Current.Request.Cookies["background"];
        System.Web.HttpCookie cookie3 = HttpContext.Current.Request.Cookies["icon"];
        if (cookie != null && cookie.Value != null)
        {
            cookie.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(cookie);
        }

        if (cookie2 != null && cookie2.Value != null)
        {
            cookie2.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(cookie2);
        }

        if (cookie3 != null && cookie3.Value != null)
        {
            cookie3.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(cookie3);
        }
    }
}