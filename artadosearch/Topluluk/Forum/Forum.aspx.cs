using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Forum_Forum : System.Web.UI.Page
{
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

    PagedDataSource pds = new PagedDataSource();
    DataTable dt = new DataTable();
    HttpCookie old = HttpContext.Current.Request.Cookies["id"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Post.Visible = false;
        Kayıt.Visible = false;
        In.Visible = false;
        Soru.Visible = false;
        Yanıt.Visible = false;

        SqlConnection baglanti = new SqlConnection(con);

        if (baglanti.State.ToString() == "Open")
        {
            baglanti.Close();
        }
        else
        {
            baglanti.Open();
        }

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

            SqlDataAdapter adpanswer = new SqlDataAdapter("select * from arda.Answers where QID='"+ ID + "'", baglanti);
            DataTable dta = new DataTable();
            adpanswer.Fill(dta);
            pds.DataSource = dta.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            int acurrentPage;
            if (Request.QueryString["page"] != null)
            {
                acurrentPage = Int32.Parse(Request.QueryString["page"]);
            }
            else
            {
                acurrentPage = 1;
            }
            pds.CurrentPageIndex = acurrentPage - 1;
            Label1.Text = "Sayfa: " + acurrentPage + " / " + pds.PageCount;
            if (!pds.IsFirstPage)
            {
                HyperLink3.NavigateUrl = "forum?page=" + (acurrentPage - 1);
            }
            if (!pds.IsLastPage)
            {
                HyperLink4.NavigateUrl = "forum?page=" + (acurrentPage + 1);
            }
            Cevaplar.DataSource = pds;
            Cevaplar.DataBind();
        }
        else 
        {
            Soru.Visible = false;
        }

        if (old != null && old.Value != null)
        {
            LogIn.Visible = false;
            Button1.Visible = true;
            Button4.Visible = true;
            Label3.Visible = true;
            Label3.Text = "Hoşgeldin " + old.Value;
            string sorgu2 = "SELECT UserID FROM arda.Users where Username='" + old.Value + "' ";
            int username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (int)komut2.ExecuteScalar();
            Label3.NavigateUrl = "/forum?userid=" + username;
            baglanti.Close();
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
            baglanti.Open();
            string sorgu2 = "SELECT Username FROM arda.Users where UserID='" + UserID + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (string)komut2.ExecuteScalar();
            User.Text = username;

            string sorgu5 = "SELECT Date FROM arda.Users where UserID='" + UserID + "' ";
            string date;
            SqlCommand komut3 = new SqlCommand(sorgu5, baglanti);
            date = (string)komut3.ExecuteScalar();
            JoinDate.Text = date + " tarihinde foruma katıldı.";

            string sorgu3 = "SELECT Bio FROM arda.Users where UserID='" + UserID + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
            detail = (string)komut4.ExecuteScalar();
            Bio.Text = detail;
            baglanti.Close();
        }
        else if (UsernameID != null)
        {
            Profil.Visible = true;
            Soru.Visible = false;
            SorularPanel.Visible = false;
            baglanti.Open();
            string sorgu2 = "SELECT Username FROM arda.Users where Username='" + UsernameID + "' ";
            string username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (string)komut2.ExecuteScalar();
            User.Text = username;

            string sorgu5 = "SELECT Date FROM arda.Users where Username='" + UsernameID + "' ";
            string date;
            SqlCommand komut3 = new SqlCommand(sorgu5, baglanti);
            date = (string)komut3.ExecuteScalar();
            JoinDate.Text = date + " tarihinde foruma katıldı.";

            string sorgu3 = "SELECT Bio FROM arda.Users where Username='" + UsernameID + "' ";
            string detail;
            SqlCommand komut4 = new SqlCommand(sorgu3, baglanti);
            detail = (string)komut4.ExecuteScalar();
            Bio.Text = detail;
            baglanti.Close();
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
            HyperLink1.NavigateUrl = "forum?page=" + (currentPage - 1);
        }
        if (!pds.IsLastPage)
        {
            HyperLink2.NavigateUrl = "forum?page=" + (currentPage + 1);
        }
        Sorular.DataSource = pds;
        Sorular.DataBind();

        baglanti.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://artadosearch.com");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        In.Visible = true;
        Kayıt.Visible = false;
        Post.Visible = false;
        Soru.Visible = false;
        SorularPanel.Visible = false;
        Button1.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Kayıt.Visible = true;
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
        Kayıt.Visible = false;
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(con);
        baglanti.Open();
        SqlCommand control = new SqlCommand("select * from arda.Users where Username='" + TextBox1.Text + "'", baglanti);
        SqlDataReader reading = control.ExecuteReader();

        if (reading.Read())
        {
            Uyarı.Text = "Bu kullanıcı adı alınmış.";
        }
        else
        {
            HttpCookie cookie = new HttpCookie("id");
            cookie.Value = TextBox1.Text;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Label3.Visible = true;
            Label3.Text = "Hoşgeldin " + cookie.Value;
            string istek = "insert into arda.Users(Username, Password, Bio, Date) values (@Username, @Password, @Bio, @Date)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Bio", BioText.Text);
            cmd.Parameters.AddWithValue("@Date", DateTime.UtcNow.ToString());
            cmd.ExecuteNonQuery();
            Response.Redirect("/Forum");
        }
        baglanti.Close();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(con);
        baglanti.Open();
        SqlCommand control = new SqlCommand("select * from arda.Users where Username='" + TextBox3.Text + "' and Password='"+ TextBox4.Text +"'", baglanti);
        SqlDataReader reading = control.ExecuteReader();

        if (reading.Read())
        {
            HttpCookie cookie = new HttpCookie("id");
            cookie.Value = TextBox3.Text;
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            Label3.Visible = true;
            Label3.Text = "Hoşgeldin " + cookie.Value;
        }
        else
        {
            In.Visible = true;
            Label4.Text = "Kullanıcı adı veya şifre yanlış!";
        }
        baglanti.Close();
        Response.Redirect("/Forum");
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        In.Visible = false;
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
            baglanti.Open();

            string sorgu2 = "SELECT UserID FROM arda.Users where Username='" + old.Value + "' ";
            int username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (int)komut2.ExecuteScalar();

            string istek = "insert into arda.Questions(Title, Detail, Username, Date, Answers, Views, UserID) values (@Title, @Detail, @Username, @Date, @Answers, @Views, @UserID)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@Title", TitleText.Text);
            cmd.Parameters.AddWithValue("@Detail", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Username", old.Value);
            cmd.Parameters.AddWithValue("@Date", DateTime.UtcNow.ToString());
            cmd.Parameters.AddWithValue("@Answers", 0);
            cmd.Parameters.AddWithValue("@Views", 0);
            cmd.Parameters.AddWithValue("@UserID", username);
            cmd.ExecuteNonQuery();
            baglanti.Close();
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
            baglanti.Open();

            string sorgu2 = "SELECT UserID FROM arda.Users where Username='" + old.Value + "' ";
            int username;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            username = (int)komut2.ExecuteScalar();

            string istek = "insert into arda.Answers(QID, Username, Date, Answer) values (@QID, @Username, @Date, @Answer)";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@QID", ID);
            cmd.Parameters.AddWithValue("@Username", old.Value);
            cmd.Parameters.AddWithValue("@Date", DateTime.UtcNow.ToString());
            cmd.Parameters.AddWithValue("@Answer", TextBox7.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("update arda.Questions set Answers+=1 where ID='" + ID + "'", baglanti);
            cmd2.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("Forum?id=" + ID);
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Yanıt.Visible = false;
    }
}