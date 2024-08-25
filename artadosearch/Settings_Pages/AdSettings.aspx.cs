using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Settings_Pages
{
    public partial class AdSettings : System.Web.UI.Page
    {
        //Connection Strings
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Basics.Attributes.Add("class", "sidebar-item");
            Themes_Button.Attributes.Add("class", "sidebar-item");
            Extensions.Attributes.Add("class", "sidebar-item");
            ProxyButton.Attributes.Add("class", "sidebar-item");
            Profiles.Attributes.Add("class", "sidebar-item");
            Ads.Attributes.Add("class", "sidebar-item active");

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
            }
            else
            {
                Page.Theme = "Default";
            }

            HttpCookie cookie = HttpContext.Current.Request.Cookies["Ads"];
            if (cookie != null && cookie.Value != null)
            {
                ad_active.SelectedValue = cookie.Value;
            }
            else
            {
                ad_active.SelectedValue = "Enable";
            }

            //Ad ID
            HttpCookie ad_id = HttpContext.Current.Request.Cookies["ad_id"];
            string id;
            if (ad_id != null && ad_id.Value != null)
            {
                id = ad_id.Value;
                CheckBox1.Checked = true;
            }
            else if (Session["ad_id"] != null)
            {
                id = Session["ad_id"].ToString();
            }
            else
            {
                id = Guid.NewGuid().ToString();
                Session["ad_id"] = id;
            }

            id_txt.Text = "Your Ad ID: " + id;
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

        protected void ad_active_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["Ads"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Ads");
                cookie.Value = ad_active.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Ads");
                cookie.Value = ad_active.SelectedValue;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["ad_id"];
            if (CheckBox1.Checked == true)
            {
                HttpCookie cookie = new HttpCookie("ad_id");
                cookie.Value = Session["ad_id"].ToString();
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();
            }
        }

        protected void Sync_Click(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["ad_id"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("ad_id");
                cookie.Value = ID_input.Value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ad_id");
                cookie.Value = ID_input.Value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }
    }
}