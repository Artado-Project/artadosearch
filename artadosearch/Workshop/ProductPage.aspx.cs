using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Workshop
{
    public partial class ProductPPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = RouteData.Values["id"].ToString();

                string name = GetProduct.Info("Name", id);
                if(name == null)
                {
                    Response.Redirect("/workshop");
                }
                else
                {
                    //Connection Strings
                    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

                    string dev = GetProduct.Info("Developer", id);
                    string desc = GetProduct.Info("Description", id);
                    string source = GetProduct.Info("Gameplay", id);
                    string logo = GetProduct.Info("Logo", id);
                    string devurl = ArtadoSql.Select("URL", "Devs", "Name", dev, con, "string");

                    Page.Title = name + " - Artado Workshop";
                    Page.MetaDescription = desc + " - Customize Artado as you want";
                    Page.MetaKeywords = "open source, open source search engine, linux, foss, foss search engine, arama, arama motoru, customize, customizable" +
                        "yerli, artado, gizlilik, milli, türk yapımı, güvenli, açık kaynak, reklamsız, reklamsız arama motoru, search, search engine, " +
                        "privacy, security, tarayıcı, browser, celer";

                    nametxt.Text = name;
                    devtxt.Text = dev;
                    desctxt.Text = desc;
                    dev_a.HRef = "/workshop/dev/" + devurl;
                    img.Src = "https://devs.artado.xyz/Upload/Images/" + logo;
                    source_a.HRef = source;
                    a_use.HRef = "/?p=" + id;

                    #region Screenshots
                    var img1 = GetProduct.Info("Image1", id);
                    string img2;
                    string img3;
                    string img4;
                    string img5;

                    try
                    {
                        img2 = GetProduct.Info("Image2", id);
                    }
                    catch
                    {
                        img2 = null;
                    }
                    try
                    {
                        img3 = GetProduct.Info("Image3", id);
                    }
                    catch
                    {
                        img3 = null;
                    }
                    try
                    {
                        img4 = GetProduct.Info("Image4", id);
                    }
                    catch
                    {
                        img4 = null;
                    }
                    try
                    {
                        img5 = GetProduct.Info("Image5", id);
                    }
                    catch
                    {
                        img5 = null;
                    }


                    img_1.Src = "https://devs.artado.xyz/Upload/Images/" + img1;
                    if(img2 != null)
                    {
                        img_2.Src = "https://devs.artado.xyz/Upload/Images/" + img2;
                    }
                    else
                    {
                        img_2.Visible = false;
                        dot2.Visible = false;
                    }
                    if (img3 != null)
                    {
                        img_3.Src = "https://devs.artado.xyz/Upload/Images/" + img3;
                    }
                    else
                    {
                        img_3.Visible = false;
                        dot3.Visible = false;
                    }
                    if (img4 != null)
                    {
                        img_4.Src = "https://devs.artado.xyz/Upload/Images/" + img4;
                    }
                    else
                    {
                        img_4.Visible = false;
                        dot4.Visible = false;
                    }
                    if (img5 != null)
                    {
                        img_5.Src = "https://devs.artado.xyz/Upload/Images/" + img5;
                    }
                    else
                    {
                        img_5.Visible = false;
                        dot5.Visible = false;
                    }
                    #endregion
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

        protected void Theme_Click(object sender, EventArgs e)
        {
            CreateCookie("Workshop", "Theme");
        }

        protected void Ext_Click(object sender, EventArgs e)
        {
            CreateCookie("Workshop", "Extension");
        }

        protected void Logo_Click(object sender, EventArgs e)
        {
            CreateCookie("Workshop", "Logo");
        }

        //Creates Cookie
        public void CreateCookie(string name, string value)
        {
            HttpCookie old = HttpContext.Current.Request.Cookies[name];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }
    }
}