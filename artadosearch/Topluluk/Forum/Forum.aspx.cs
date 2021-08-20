using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Forum_Forum : System.Web.UI.Page
{
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
    string con2 = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();

    string username2;

    PagedDataSource pds = new PagedDataSource();
    DataTable dt = new DataTable();
    HttpCookie old = HttpContext.Current.Request.Cookies["id"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Post.Visible = false;
        Soru.Visible = false;
        Yanıt.Visible = false;

        SqlConnection baglanti = new SqlConnection(con);
        SqlConnection baglanti2 = new SqlConnection(con2);
        baglanti.Open();
        baglanti2.Open();

        string ID = Request.QueryString["ID"];

        string UserID = Request.QueryString["UserID"];  

        string UsernameID = Request.QueryString["User"];


        if (ID != null)
        {
            Soru.Visible = true;
            SorularPanel.Visible = false;
            Yanıt.Visible = false;
            Button1.Visible = false;

            SqlCommand cmd2 = new SqlCommand("update arda.Questions set Views+=1 where ID='" + ID + "'", baglanti);
            cmd2.ExecuteNonQuery();

            string sorgu = "SELECT Title FROM arda.Questions where ID='"+ ID +"' ";
            string title;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            title = (string)komut.ExecuteScalar();
            Title.Text = title;

            string sorgu2 = "SELECT Username FROM arda.Questions where ID='" + ID + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (string)komut2.ExecuteScalar();
            Username.Text = username;

            string sorgu5 = "SELECT Date FROM arda.Questions where ID='" + ID + "' ";
            string date;
            SqlCommand komut3 = new SqlCommand(sorgu5, baglanti);
            date = (string)komut3.ExecuteScalar();
            Date.Text = date;

            string sorgu3 = "SELECT Detail FROM arda.Questions where ID='" + ID + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
            detail = (string)komut4.ExecuteScalar();
            Detail.Text = detail;

            string sorgu4 = "SELECT Views FROM arda.Questions where ID='" + ID + "' ";
            int view;
            SqlCommand komut5 = new SqlCommand(sorgu4, baglanti);
            view = (int)komut5.ExecuteScalar();
            View.Text = view + " görüntülenme";

            string sorgu6 = "SELECT Answers FROM arda.Questions where ID='" + ID + "' ";
            int answer;
            SqlCommand komut6 = new SqlCommand(sorgu6, baglanti);
            answer = (int)komut6.ExecuteScalar();
            Answers.Text = answer + " cevap";

            SqlDataAdapter adpanswer = new SqlDataAdapter("select * from dbo.Answers where QID='"+ ID + "'", baglanti);
            DataTable dta = new DataTable();
            adpanswer.Fill(dta);
            pds.DataSource = dta.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            int acurrentPage;
            if (Request.QueryString["answers"] != null)
            {
                acurrentPage = Int32.Parse(Request.QueryString["answers"]);
            }
            else
            {
                acurrentPage = 1;
            }
            pds.CurrentPageIndex = acurrentPage - 1;
            Label1.Text = "Sayfa: " + acurrentPage + " / " + pds.PageCount;
            if (!pds.IsFirstPage)
            {
                HyperLink3.NavigateUrl = "/forum?id=" + ID + "&answers=" + (acurrentPage - 1);
            }
            if (!pds.IsLastPage)
            {
                HyperLink4.NavigateUrl = "/forum?id=" + ID + "&answers=" + (acurrentPage + 1);
            }
            Cevaplar.DataSource = pds;
            Cevaplar.DataBind();

            Page.Title = title;
        }
        else 
        {
            Soru.Visible = false;
        }

        if (old != null && old.Value != null)
        {
            string sorgu24 = "SELECT Username FROM dbo.Users where PassID='" + old.Value + "' ";
            SqlCommand komut42 = new SqlCommand(sorgu24, baglanti2);
            username2 = (string)komut42.ExecuteScalar();

            LogIn.Visible = false;
            Button1.Visible = true;
            Button4.Visible = true;
            Label3.Visible = true;
            Label3.Text = "Hoşgeldin " + username2;
            string sorgu2 = "SELECT UserID FROM dbo.Users where PassID=" + old.Value + "";
            int userid;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            userid = (int)komut2.ExecuteScalar();
            Label3.NavigateUrl = "/forum?userid=" + userid;
        }
        else
        {
            LogIn.Visible = true;
            Button1.Visible = false;
            Button4.Visible = false;
        }

        if (UserID != null)
        {
            Profil.Visible = true;
            Soru.Visible = false;
            SorularPanel.Visible = false;
            string sorgu2 = "SELECT Username FROM dbo.Users where UserID='" + UserID + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            username = (string)komut2.ExecuteScalar();
            User.Text = username;

            string sorgu3 = "SELECT Bio FROM dbo.Users where UserID='" + UserID + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti2);
            detail = (string)komut4.ExecuteScalar();
            Bio.Text = detail;

            Page.Title = username + " - Kullanıcı";

            SqlDataAdapter adp2 = new SqlDataAdapter("select * from arda.Questions where Username='" + username + "' order by ID desc", baglanti);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            Profil_Questions.DataSource = dt2;
            Profil_Questions.DataBind();
        }
        else if (UsernameID != null)
        {
            Profil.Visible = true;
            Soru.Visible = false;
            SorularPanel.Visible = false;
            string sorgu2 = "SELECT Username FROM dbo.Users where Username='" + UsernameID + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (string)komut2.ExecuteScalar();
            User.Text = username;

            string sorgu3 = "SELECT Bio FROM dbo.Users where Username='" + UsernameID + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
            detail = (string)komut4.ExecuteScalar();
            Bio.Text = detail;
        }
        else
        {
            Profil.Visible = false;
        }

        SqlDataAdapter adp = new SqlDataAdapter("select * from arda.Questions order by ID desc", baglanti);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.PageSize = 10;
        int currentPage;
        if (Request.QueryString["page"] != null)
        {
            currentPage = Int32.Parse(Request.QueryString["page"]);
        }
        else
        {
            currentPage = 1;
        }
        pds.CurrentPageIndex = currentPage - 1;
        Label2.Text = "Sayfa: " + currentPage + " / " + pds.PageCount;
        if (!pds.IsFirstPage)
        {
            HyperLink1.NavigateUrl = "/forum?page=" + (currentPage - 1);
        }
        if (!pds.IsLastPage)
        {
            HyperLink2.NavigateUrl = "/forum?page=" + (currentPage + 1);
        }
        Sorular.DataSource = pds;
        Sorular.DataBind();
        if (baglanti.State.ToString() == "Open")
        {
            baglanti.Close();
            SqlConnection.ClearPool(baglanti);
        }
        if (baglanti2.State.ToString() == "Open")
        {
            baglanti2.Close();
            SqlConnection.ClearPool(baglanti2);
        }
    }

    protected override void InitializeCulture()
    {
        string lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2);
        System.Web.HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];

        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else
        {
            if (lang == "tr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            }
            else if (lang == "en".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else if (lang == "fr".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            }
            else if (lang == "de".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            }
            else if (lang == "az".ToLower() || lang == "Lt-az".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-AU");
            }
            else if (lang == "it".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
            }
            else if (lang == "ru".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            }
            else if (lang == "zh".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CHS");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            }
            else if (lang == "es".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            else if (lang == "pz".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
            }
            else if (lang == "ko".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-KR");
            }
            else if (lang == "ja".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
            }
            else if (lang == "hu".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
            }
            else if (lang == "bg".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");
            }
            else if (lang == "bs".ToLower())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-BZ");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-BZ");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }

        }
        base.InitializeCulture();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://artadosearch.com");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Account?mode=register&url=/Forum");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Post.Visible = false;
        Soru.Visible = false;
        SorularPanel.Visible = false;
        Button1.Visible = false;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Forum");
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Post.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Yanıt.Visible = true;
    }

    protected void iptal_Click(object sender, EventArgs e)
    {
        Post.Visible = false;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
    }

    protected void Button9_Click(object sender, EventArgs e)
    {

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TitleText.Text.Trim() == "" || TextBox5.Text.Trim() == "")
        {
            Label5.Text = "Boş gönderi atamazsın!";
            Post.Visible = false;
        }
        else
        {
            SqlConnection baglanti = new SqlConnection(con);
            SqlConnection baglanti2 = new SqlConnection(con2);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            if (baglanti2.State == ConnectionState.Closed)
            {
                baglanti2.Open();
            }

            string sorgu2 = "SELECT UserID FROM dbo.Users where PassID='" + old.Value + "' ";
            int username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            username = (int)komut2.ExecuteScalar();

            string istek = "insert into arda.Questions(Title, Detail, Username, Date, Answers, Views, UserID) values (@Title, @Detail, @Username, @Date, @Answers, @Views, @UserID)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@Title", TitleText.Text);
            cmd.Parameters.AddWithValue("@Detail", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Username", username2);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
            cmd.Parameters.AddWithValue("@Answers", 0);
            cmd.Parameters.AddWithValue("@Views", 0);
            cmd.Parameters.AddWithValue("@UserID", username);
            cmd.ExecuteNonQuery();
            if (baglanti.State.ToString() == "Open")
            {
                baglanti.Close();
                SqlConnection.ClearPool(baglanti);
            }
            if (baglanti2.State.ToString() == "Open")
            {
                baglanti2.Close();
                SqlConnection.ClearPool(baglanti2);
            }
            Response.Redirect("/Forum");
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        if (TextBox7.Text.Trim() == "")
        {
            Label6.Text = "Boş gönderi atamazsın!";
        }
        else
        {
            SqlConnection baglanti = new SqlConnection(con);
            SqlConnection baglanti2 = new SqlConnection(con2);
            if (baglanti2.State == ConnectionState.Closed)
            {
                baglanti2.Open();
            }
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string sorgu2 = "SELECT UserID FROM dbo.Users where PassID='" + old.Value + "' ";
            int username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            username = (int)komut2.ExecuteScalar();

            string istek = "insert into dbo.Answers(QID, Username, Date, Answer) values (@QID, @Username, @Date, @Answer)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@QID", ID);
            cmd.Parameters.AddWithValue("@Username", username2);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
            cmd.Parameters.AddWithValue("@Answer", TextBox7.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("update arda.Questions set Answers+=1 where ID='" + ID + "'", baglanti);
            cmd2.ExecuteNonQuery();
            if (baglanti.State.ToString() == "Open")
            {
                baglanti.Close();
                SqlConnection.ClearPool(baglanti);
            }
            if (baglanti2.State.ToString() == "Open")
            {
                baglanti2.Close();
                SqlConnection.ClearPool(baglanti2);
            }
            Response.Redirect("Forum?id=" + ID);
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Yanıt.Visible = false;
    }

    protected void Close_Click(object sender, EventArgs e)
    {
        old.Expires = DateTime.UtcNow.AddDays(-1);
        Response.Cookies.Add(old);
        LogIn.Visible = true;
        Button1.Visible = false;
        Button4.Visible = false;
        Label3.Visible = false;
    }
}