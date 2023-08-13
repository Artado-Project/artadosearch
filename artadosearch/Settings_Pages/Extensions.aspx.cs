using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Settings_Pages
{
    public partial class Extensions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Basics.Attributes.Add("class", "sidebar-item");
            Themes_Button.Attributes.Add("class", "sidebar-item");
            Extensions_Button.Attributes.Add("class", "sidebar-item active");
            Profiles.Attributes.Add("class", "sidebar-item");

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

            if (!IsPostBack)
            {
                if (ext != null && ext.Values != null)
                {
                    List<string> list = new List<string>();

                    foreach (string item in ext.Values)
                    {
                        if (item != null)
                        {
                            string path = HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpUtility.UrlDecode(ext.Values[item])));

                            int id = ArtadoSql.SelectInt("ProductID", "Versions", "Path", path, con);
                            string name = ArtadoSql.Select("Name", "Products", "ID", id.ToString(), con, "string");

                            list.Add(name);
                        }
                    }

                    extensions_list.DataSource = list;
                    extensions_list.DataBind();

                    for (int i = 0; i < extensions_list.Items.Count; i++)
                    {
                        Label title = extensions_list.Items[i].FindControl("text") as Label;
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

            //HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomJS"];
            //if (customcss != null && customcss != null)
            //{
            //    js.Value = Server.UrlDecode(customcss.Value);
            //}

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

        protected void extensions_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int t = e.Item.ItemIndex;

            //Delete the value from cookie
            HttpCookie custom = HttpContext.Current.Request.Cookies["Extension"];
            string value = custom.Values.Keys[t];
            custom.Values.Remove(value);
            custom.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(custom);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }

        protected void themes_list_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        //protected void Apply_Click(object sender, EventArgs e)
        //{
        //    HttpCookie old = HttpContext.Current.Request.Cookies["CustomJS"];
        //    if (js.Value != string.Empty)
        //    {
        //        if (old != null && old.Value != null)
        //        {
        //            old.Expires = DateTime.UtcNow.AddDays(-1);
        //            Response.Cookies.Add(old);
        //            Session.Abandon();
        //        }
        //        HttpCookie cookie = new HttpCookie("CustomJS");
        //        cookie.Value = Server.UrlEncode(js.Value);
        //        cookie.Expires = DateTime.UtcNow.AddDays(360);
        //        Response.Cookies.Add(cookie);
        //        Page.Response.Redirect(Page.Request.Url.ToString());
        //    }
        //    else
        //    {
        //        if (old != null && old.Value != null)
        //        {
        //            old.Expires = DateTime.UtcNow.AddDays(-1);
        //            Response.Cookies.Add(old);
        //            Session.Abandon();
        //        }
        //    }
        //}

        protected void Profiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Profiles");
        }
    }
}