using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Workshop
{
    public partial class Defaukt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString["i"];

            try
            {
                if (q != null)
                {
                    searchinput.Attributes.Add("value", q);
                    GetProduct.Products(Projects, "Workshop", q);
                }
                else
                {
                    HttpCookie genre = HttpContext.Current.Request.Cookies["Workshop"];

                    if (genre.Value != null)
                    {
                        GetProduct.Products(Projects, genre.Value, null);

                        switch (genre.Value)
                        {
                            case "Theme":
                                Theme.Font.Bold = true;
                                break;
                            case "Extension":
                                Ext.Font.Bold = true;
                                break;
                            case "Logo":
                                Logo.Font.Bold = true;
                                break;
                            default:
                                Theme.Font.Bold = false;
                                break;
                        }
                    }
                    else
                    {
                        GetProduct.Products(Projects, "Theme", null);
                        Theme.Font.Bold = true;
                    }
                }
            }
            catch
            {
                GetProduct.Products(Projects, "Theme", null);
                Theme.Font.Bold = true;
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
    }
}