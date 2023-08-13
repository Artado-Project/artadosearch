using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Settings
{
    public partial class Themes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Basics.Attributes.Add("class", "sidebar-item");
            Themes_Button.Attributes.Add("class", "sidebar-item active");
            Extensions.Attributes.Add("class", "sidebar-item");
            Profiles.Attributes.Add("class", "sidebar-item");

            themes_page.Visible = true;

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
                    Page.Header.Controls.Add(
                         new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\"></script>"));
                }
            }

            if (!IsPostBack)
            {
                if (custom != null && custom.Values != null)
                {
                    List<string> list = new List<string>();

                    foreach (string item in custom.Values)
                    {
                        if(item != null)
                        {
                            string path = HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpUtility.UrlDecode(custom.Values[item])));

                            int id = ArtadoSql.SelectInt("ProductID", "Versions", "Path", path, con);
                            string name = ArtadoSql.Select("Name", "Products", "ID", id.ToString(), con, "string");

                            list.Add(name);
                        }
                    }

                    themes_list.DataSource = list;
                    themes_list.DataBind();

                    for (int i = 0; i < themes_list.Items.Count; i++)
                    {
                        Label title = themes_list.Items[i].FindControl("text") as Label;
                        title.Text = list[i];
                    }
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


            HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
            if (customcss != null && customcss != null)
            {
                css.Value = Server.UrlDecode(customcss.Value);
            }

            //System.Web.HttpCookie cookie3 = HttpContext.Current.Request.Cookies["WebResults"];
            //if (cookie3 != null && cookie3.Value != null)
            //{
            //    Results.SelectedValue = cookie3.Value;
            //}
        }

        protected void Basics_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings");
        }

        protected void Themes_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Themes");
        }

        protected void themes_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
  
            int t = e.Item.ItemIndex;

            //Delete the value from cookie
            HttpCookie custom = HttpContext.Current.Request.Cookies["CustomTheme"];
            string value = custom.Values.Keys[t];
            custom.Values.Remove(value);
            custom.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(custom);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }

        protected void themes_list_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies["CustomCSS"];
            if(css.Value != string.Empty)
            {
                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();
                }
                HttpCookie cookie = new HttpCookie("CustomCSS");
                cookie.Value = Server.UrlEncode(css.Value);
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();
                }
            }
        }

        protected void Extensions_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Extensions");
        }

        protected void Profiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Profiles");
        }
    }
}