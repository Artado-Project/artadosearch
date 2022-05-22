using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_PhotonApp_App : System.Web.UI.Page
{
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    string con2 = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();

    int habersayı = 10;

    string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
    SqlConnection baglanti = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
        string lang = kultur.TwoLetterISOLanguageName;
        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection baglanti2 = new SqlConnection(con2);

        HttpCookie id = HttpContext.Current.Request.Cookies["id"];
        if (id != null && id.Value != null && baglanti2 != null)
        {
            ProfilePic.Visible = true;
            Button2.Visible = false;
            string sorgu2 = "SELECT Image FROM dbo.Users where PassID='" + id.Value + "' ";
            string image;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            baglanti2.Open();
            image = (string)komut2.ExecuteScalar();
            baglanti2.Close();
            ProfilePic.ImageUrl = "/images/" + image;
        }
        else
        {
            ProfilePic.Visible = false;
            Button2.Visible = true;
        }

        HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
        if (old2 != null && old2.Value != null)
        {
            bdy1.Attributes.Add("style", "background:url(" + old2.Value + ") no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;");
        }

        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        Label12.Visible = false;

        Kontrol.Visible = false;

        if (cookielang != null && cookielang.Value != null)
        {
            ddlanguage.Text = cookielang.Value;
        }

        baglanti.Open();
        string sorgu = "SELECT LastCheck from arda.News order by Date desc";
        SqlCommand komut42 = new SqlCommand(sorgu, baglanti);
        DateTime check = (DateTime)komut42.ExecuteScalar();
        int comp = Convert.ToInt32(DateTime.UtcNow.Subtract(check).TotalMinutes);
        if (comp > 30)
        {
            //HttpWebRequest request29 = (HttpWebRequest)HttpWebRequest.Create("http://localhost:52941/Bot?mode=news".Trim());
        }

        PagedDataSource pdssoz = new PagedDataSource();
        SqlDataAdapter adpsoz = new SqlDataAdapter("select * from arda.News order by Date desc", baglanti);
        DataTable dtınfo = new DataTable();
        adpsoz.Fill(dtınfo);
        pdssoz.DataSource = dtınfo.DefaultView;
        pdssoz.AllowPaging = true;
        pdssoz.PageSize = habersayı;
        News_Results.DataSource = pdssoz;
        News_Results.DataBind();
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

    protected void Page_PreInit(object sender, EventArgs e)
    {
        HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie0 != null && cookie0.Value != null)
        {
            DropDownList1.SelectedValue = cookie0.Value;
        }

        HttpCookie old2 = HttpContext.Current.Request.Cookies["background"];
        if (old2 != null && old2.Value != null)
        {
            bdy1.Attributes.Add("style", "background:url(" + old2.Value + "); background-size:cover; background-repeat:no-repeat; background-position: center;");
        }

        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Klasik";
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        int sharp = arama_çubugu.Text.IndexOf("#");
        int ok1 = arama_çubugu.Text.IndexOf("<");
        int ok2 = arama_çubugu.Text.IndexOf(">");
        int i = arama_çubugu.Text.IndexOf("İ");
        int ş = arama_çubugu.Text.ToLower().IndexOf("ş");

        string schange = arama_çubugu.Text.Replace("#", "%23");
        string okc1 = arama_çubugu.Text.Replace("<", "<");
        string okc2 = arama_çubugu.Text.Replace("'", " ");
        string ic = arama_çubugu.Text.Replace("İ", "%C4%B0");
        string şc = arama_çubugu.Text.ToLower().Replace("ş", "%C5%9F");

        if (ok1 >= 0)
        {
            Label12.Visible = true;
            Label12.Text = "Tehlikeli arama yaptınız!";
            Label12.ForeColor = System.Drawing.Color.Red;
        }
        else if (ok2 >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim());
        }
        else if (sharp >= 0)
        {
            Response.Redirect("/search?i=" + schange.Trim());
        }
        else if (i >= 0)
        {
            Response.Redirect("/search?i=" + ic.Trim());
        }
        else if (ş >= 0)
        {
            Response.Redirect("/search?i=" + şc.Trim());
        }
        else
        {
            Response.Redirect("/search?i=" + arama_çubugu.Text);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["Theme"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);

            HttpCookie cookie = new HttpCookie("Theme");
            cookie.Value = DropDownList1.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Response.Cookies.Add(old);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
        else
        {
            HttpCookie cookie = new HttpCookie("Theme");
            cookie.Value = DropDownList1.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = true;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Mail");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Donate");
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie old = HttpContext.Current.Request.Cookies["Lang"];
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
            Server.Transfer(Request.Path);
        }
        else
        {
            Session["language"] = ddlanguage.SelectedValue;
            //Sets the cookie that is to be used by Global.asax
            HttpCookie cookie = new HttpCookie("Lang");
            cookie.Value = ddlanguage.SelectedValue;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            //Set the culture and reload for immediate effect.
            //Future effects are handled by Global.asax
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlanguage.SelectedValue);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlanguage.SelectedValue);
            if (cookie.Value == "tr-TR") { Session["ddindex"] = 0; }
            else if (cookie.Value == "en-US") { Session["ddindex"] = 1; }
            else if (cookie.Value == "fr-FR") { Session["ddindex"] = 2; }
            else if (cookie.Value == "de-DE") { Session["ddindex"] = 3; }
            else if (cookie.Value == "en-AU") { Session["ddindex"] = 4; }
            else if (cookie.Value == "it-IT") { Session["ddindex"] = 5; }
            else if (cookie.Value == "ru-RU") { Session["ddindex"] = 6; }
            else if (cookie.Value == "zh-CHS") { Session["ddindex"] = 7; }
            else if (cookie.Value == "es-ES") { Session["ddindex"] = 8; }
            else if (cookie.Value == "prt-pT") { Session["ddindex"] = 9; }
            else if (cookie.Value == "ko-KR") { Session["ddindex"] = 10; }
            else if (cookie.Value == "ja-JP") { Session["ddindex"] = 11; }
            else if (cookie.Value == "hu-HU") { Session["ddindex"] = 12; }
            else if (cookie.Value == "bg-BG") { Session["ddindex"] = 13; }
            else if (cookie.Value == "en-BZ") { Session["ddindex"] = 14; }
            Server.Transfer(Request.Path);
        }
        Response.Redirect("/");
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("/Account?mode=register&url=/");
    }

    protected void ProfilePic_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Account?mode=settings");
    }
}