using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Workshop
{
    public partial class DeveloperPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string dev = RouteData.Values["dev"].ToString();

                //Connection Strings
                string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

                string name = ArtadoSql.Select("Name", "Devs", "URL", dev, con, "string");
                if (name == null)
                {
                    Response.Redirect("/workshop");
                }
                else
                {

                    string devurl = ArtadoSql.Select("Name", "Devs", "URL", dev, con, "string");
                    string desc = ArtadoSql.Select("Description", "Devs", "URL", dev, con, "string");
                    string logo = ArtadoSql.Select("Logo", "Devs", "URL", dev, con, "string");

                    Page.Title = name + " - Artado Workshop";
                    Page.MetaDescription = desc + " - Developer in Artado";
                    Page.MetaKeywords = "open source, open source search engine, linux, foss, foss search engine, arama, arama motoru, customize, customizable" +
                        "yerli, artado, gizlilik, milli, türk yapımı, güvenli, açık kaynak, reklamsız, reklamsız arama motoru, search, search engine, " +
                        "privacy, security, tarayıcı, browser, celer";

                    nametxt.Text = name;
                    desc = "About me: " + desc.Replace("\n", "<br />");
                    string regex = @"(\b(https?|ftp|file):\/\/([-A-Z0-9+&@#%?=~_|!:,.;]*)[-A-Z0-9+&@#%?\/=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])";
                    Regex r = new Regex(regex, RegexOptions.IgnoreCase);
                    desctxt.InnerHtml = r.Replace(desc, "<a href=\"$1\" target =\"_blank\">$1</a>");
                    img.Src = "https://devs.artado.xyz/Upload/profiles/" + logo;

                    System.Diagnostics.Debug.WriteLine("c: " + ArtadoSql.SelectInt("PassID", "Devs", "URL", dev, con).ToString());
                    GetProduct.ProductsDev(Projects, ArtadoSql.SelectInt("PassID", "Devs", "URL", dev, con).ToString());
                }
            }
            catch
            {

            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie customicon = HttpContext.Current.Request.Cookies["CustomIcon"];
            HttpCookie old = HttpContext.Current.Request.Cookies["Icon"];
            if (customicon == null)
            {
                if (old != null && old.Value != null)
                {
                    switch (old.Value)
                    {
                        case "default":
                            Image1.Src = "/images/android-chrome-192x192.png";
                            break;

                        case "colorful":
                            Image1.Src = "/images/artadov3-colorful-icon.png";
                            break;

                        case "old":
                            Image1.Src = "/images/oldies/old-icon.png";
                            break;

                        default:
                            Image1.Src = "/images/android-chrome-192x192.png";
                            break;
                    }
                }
                else
                {
                    Image1.Src = "/images/android-chrome-192x192.png";
                }
            }

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
        }


        protected void Search(object sender, EventArgs e)
        {
            Response.Redirect("/workshop?i=" + HttpUtility.UrlPathEncode(searchinput.Text));
        }

        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }
    }
}