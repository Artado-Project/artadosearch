using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Workshop
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string q = Request.QueryString["i"];

            //try
            //{
            //    if (q != null)
            //    {
            //        searchinput.Attributes.Add("value", q);
            //        GetProduct.Products(Projects, "Workshop", q);
            //    }
            //    else
            //    {
            //        HttpCookie genre = HttpContext.Current.Request.Cookies["Workshop"];

            //        if (genre.Value != null)
            //        {
            //            GetProduct.Products(Projects, genre.Value, null);

            //            switch (genre.Value)
            //            {
            //                case "Theme":
            //                    Theme.Font.Bold = true;
            //                    break;
            //                case "Extension":
            //                    Ext.Font.Bold = true;
            //                    break;
            //                case "Logo":
            //                    Logo.Font.Bold = true;
            //                    break;
            //                default:
            //                    Theme.Font.Bold = false;
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            GetProduct.Products(Projects, "Theme", null);
            //            Theme.Font.Bold = true;
            //        }
            //    }
            //}
            //catch
            //{
            //    GetProduct.Products(Projects, "Theme", null);
            //    Theme.Font.Bold = true;
            //}
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