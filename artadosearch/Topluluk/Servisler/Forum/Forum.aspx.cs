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

        string Url = Request.RawUrl;
        int post = Url.IndexOf("posts".ToLower());

        int UserID = Url.IndexOf("users".ToLower());

        string UsernameID = Request.QueryString["User"];


        if (post >= 0)
        {
            Soru.Visible = true;
            SorularPanel.Visible = false;
            Yanıt.Visible = false;
            Button1.Visible = false;
            Url = RouteData.Values["post"].ToString();

            SqlCommand cmd2 = new SqlCommand("update dbo.Questions set Views+=1 where ID='" + Url + "'", baglanti);
            cmd2.ExecuteNonQuery();

            string sorgu = "SELECT Title FROM dbo.Questions where ID='" + Url + "' ";
            string title;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            title = (string)komut.ExecuteScalar();
            Title.Text = title;

            string sorgu2 = "SELECT Username FROM dbo.Questions where ID='" + Url + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (string)komut2.ExecuteScalar();
            Username.Text = username;

            string sorgu5 = "SELECT Date FROM dbo.Questions where ID='" + Url + "' ";
            string date;
            SqlCommand komut3 = new SqlCommand(sorgu5, baglanti);
            date = (string)komut3.ExecuteScalar();
            Date.Text = date;

            string sorgu3 = "SELECT Detail FROM dbo.Questions where ID='" + Url + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
            detail = (string)komut4.ExecuteScalar();
            Detail.Text = detail;

            string sorgu4 = "SELECT Views FROM dbo.Questions where ID='" + Url + "' ";
            int view;
            SqlCommand komut5 = new SqlCommand(sorgu4, baglanti);
            view = (int)komut5.ExecuteScalar();
            View.Text = view + " görüntülenme";

            string sorgu6 = "SELECT Answers FROM dbo.Questions where ID='" + Url + "' ";
            int answer;
            SqlCommand komut6 = new SqlCommand(sorgu6, baglanti);
            answer = (int)komut6.ExecuteScalar();
            Answers.Text = answer + " cevap";

            SqlDataAdapter adpanswer = new SqlDataAdapter("select * from dbo.Answers where QID='"+ Url + "'", baglanti);
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

            Page.Title = title + " - Artado Forum";
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
            Label3.NavigateUrl = "/Forum/users/" + username2.Trim();
        }
        else
        {
            LogIn.Visible = true;
            Button1.Visible = false;
            Button4.Visible = false;
        }

        if (UserID >= 0)
        {
            Profil.Visible = true;
            Soru.Visible = false;
            SorularPanel.Visible = false;

            Url = RouteData.Values["user"].ToString();

            string sorgu2 = "SELECT Username FROM dbo.Users where Username='" + Url + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
            username = (string)komut2.ExecuteScalar();
            User.Text = username;

            string sorgu3 = "SELECT Bio FROM dbo.Users where Username='" + Url + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti2);
            detail = (string)komut4.ExecuteScalar();
            Bio.Text = detail;

            Page.Title = username + " - Kullanıcı - Artado Forum";

            SqlDataAdapter adp2 = new SqlDataAdapter("select * from dbo.Questions where Username='" + username + "' and BlogPost='f' order by ID desc", baglanti);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            Profil_Questions.DataSource = dt2;
            Profil_Questions.DataBind();
        }
        else
        {
            Profil.Visible = false;
        }

        SqlDataAdapter adp = new SqlDataAdapter("select * from dbo.Questions where BlogPost='f' order by ID desc", baglanti);
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
        HttpCookie cookie = HttpContext.Current.Request.Cookies["Theme"];
        if (cookie != null && cookie.Value != null)
        {
            Page.Theme = cookie.Value;
        }
        else
        {
            Page.Theme = "Night";
        }
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
        if (TitleText.Text.Trim() == "" || editortxt.InnerText.Trim() == "")
        {
            Label5.Text = "Boş gönderi atamazsın!";
            Post.Visible = true;
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

            string istek = "insert into dbo.Questions(Title, Detail, Username, Date, Answers, Views, UserID, BlogPost) values (@Title, @Detail, @Username, @Date, @Answers, @Views, @UserID, @BlogPost)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@Title", TitleText.Text);
            cmd.Parameters.AddWithValue("@Detail", editortxt.InnerText);
            cmd.Parameters.AddWithValue("@Username", username2);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
            cmd.Parameters.AddWithValue("@Answers", 0);
            cmd.Parameters.AddWithValue("@Views", 0);
            cmd.Parameters.AddWithValue("@UserID", username);
            cmd.Parameters.AddWithValue("@BlogPost", "f");
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
        string ID = Request.RawUrl;
        ID = RouteData.Values["post"].ToString();
        if (editortxt2.InnerText.Trim() == "")
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
            cmd.Parameters.AddWithValue("@Answer", editortxt2.InnerText);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("update dbo.Questions set Answers+=1 where ID='" + ID + "'", baglanti);
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
            Response.Redirect("/Forum/posts/" + ID);
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