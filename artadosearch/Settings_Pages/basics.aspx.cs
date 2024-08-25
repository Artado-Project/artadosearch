using artadosearch.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch
{
    public partial class settings1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Custom Theme
            HttpCookie custom = HttpContext.Current.Request.Cookies["CustomTheme"];
            if (custom != null && custom.Value != null)
            {
                foreach (string item in custom.Values)
                {
                    string path = custom.Values[item];
                    Page.Header.Controls.Add(
                         new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\" />"));
                }
            }

            //Extension
            HttpCookie ext = HttpContext.Current.Request.Cookies["Extension"];
            if (ext != null && ext.Value != null)
            {
                foreach (string item in ext.Values)
                {
                    string path = ext.Values[item];
                    bdy1.Controls.Add(
                             new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\"></script>"));
                }
            }

            //Custom CSS
            HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
            if (customcss != null && customcss != null)
            {
                Page.Header.Controls.Add(
                         new System.Web.UI.LiteralControl("<style>" + Server.UrlDecode(customcss.Value) + "</style>"));
            }

            ////Custom JS
            //HttpCookie customjs = HttpContext.Current.Request.Cookies["CustomJS"];
            //if (customjs != null && customjs != null)
            //{
            //    Page.Header.Controls.Add(
            //             new System.Web.UI.LiteralControl("<script>" + Server.UrlDecode(customjs.Value) + "</script>"));
            //}

            Basics.Attributes.Add("class", "sidebar-item active");
            Themes_Button.Attributes.Add("class", "sidebar-item");
            Extensions.Attributes.Add("class", "sidebar-item");
            Profiles.Attributes.Add("class", "sidebar-item");
            Proxy.Attributes.Add("class", "sidebar-item");
            Ads.Attributes.Add("class", "sidebar-item");
        }

        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Normal Themes
            HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
            if (cookie0 != null && cookie0.Value != null)
            {
                Page.Theme = cookie0.Value;
                select_themes.SelectedValue = cookie0.Value;
            }
            else
            {
                Page.Theme = "Default";
                select_themes.SelectedValue = "Default";
            }


            //System.Web.HttpCookie cookie3 = HttpContext.Current.Request.Cookies["WebResults"];
            //if (cookie3 != null && cookie3.Value != null)
            //{
            //    Results.SelectedValue = cookie3.Value;
            //}

            System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
            System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string lang = kultur.TwoLetterISOLanguageName;

            if (cookielang != null && cookielang.Value != null)
            {
                Languages.SelectedValue = cookielang.Value;
            }
            else
            {
                Languages.SelectedValue = lang;
            }

            //Logo
            HttpCookie logo = HttpContext.Current.Request.Cookies["Icon"];
            if (logo != null && logo.Value != null)
            {
                Logos.SelectedValue = logo.Value;
            }
            else
            {
                Logos.SelectedValue = "Default";
            }

            //Categories
            HttpCookie tabs = HttpContext.Current.Request.Cookies["Categories"];
            if (tabs != null && tabs.Value != null)
            {
                position.SelectedValue = tabs.Value;
            }
            else
            {
                position.SelectedValue = "top";
            }

            //Background
            HttpCookie url_cookie = HttpContext.Current.Request.Cookies["Background"];
            if (url_cookie != null && url_cookie.Value != null)
            {
                url.Value = url_cookie.Value;
            }
        }

        protected void Themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Theme"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Theme");
                cookie.Value = select_themes.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Theme");
                cookie.Value = select_themes.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void Languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Lang"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Lang");
                cookie.Value = Languages.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Lang");
                cookie.Value = Languages.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Languages.SelectedValue);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Languages.SelectedValue);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void position_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Categories"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Categories");
                cookie.Value = position.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Categories");
                cookie.Value = position.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void Logos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Icon"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Icon");
                cookie.Value = Logos.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Icon");
                cookie.Value = Logos.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Background"];
            if (url.Value != string.Empty)
            {
                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();

                    HttpCookie cookie = new HttpCookie("Background");
                    cookie.Value = url.Value;
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("Background");
                    cookie.Value = url.Value;
                    cookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(cookie);
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
            else
            {
                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();
                    Page.Response.Redirect(Page.Request.Url.ToString());
                }
            }
        }

        protected void Basics_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings");
        }

        protected void Themes_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Themes");
        }

        protected void Extensions_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Extensions");
        }

        protected void Profiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Profiles");
        }

        protected void Proxy_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Proxy");
        }

        protected void Ads_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Ads");
        }
    }
}