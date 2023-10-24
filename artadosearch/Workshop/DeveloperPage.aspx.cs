using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                    desctxt.Text = "About me: " + desc;
                    img.Src = "https://devs.artado.xyz/Upload/profiles/" + logo;

                    System.Diagnostics.Debug.WriteLine("c: " + ArtadoSql.SelectInt("PassID", "Devs", "URL", dev, con).ToString());
                    GetProduct.ProductsDev(Projects, ArtadoSql.SelectInt("PassID", "Devs", "URL", dev, con).ToString());
                }
            }
            catch
            {

            }
        }

        protected void Search(object sender, EventArgs e)
        {
            Response.Redirect("/workshop?i=" + HttpUtility.UrlPathEncode(searchinput.Text));
        }
    }
}