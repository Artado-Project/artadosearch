using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Home_About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void Anasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Home");
    }

    protected void Hakkımızda_Click(object sender, EventArgs e)
    {
        Response.Redirect("/About");
    }

    protected void İletişim_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Contact");
    }

    protected void Blog_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Forum");
    }

    protected void DestekOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Donate");
    }
}