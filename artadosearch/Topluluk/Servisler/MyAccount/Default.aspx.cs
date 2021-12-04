using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

public partial class Topluluk_MyAccount_Default : System.Web.UI.Page
{
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();
    string con2 = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
    HttpCookie old = HttpContext.Current.Request.Cookies["id"];
    SqlConnection baglanti = new SqlConnection();
    SqlConnection baglanti2 = new SqlConnection();

    Random random = new Random();
    Random random1 = new Random();
    int code1;
    static int code2;
    int passid1;
    static int passid2;

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "key";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "key";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        code1 = random1.Next(100000, 999999);
        passid1 = random.Next(1000, 99999999);

        baglanti.ConnectionString = con;
        baglanti2.ConnectionString = con2;

        if (baglanti.State.ToString() == "Open")
        {
            baglanti.Close();
            SqlConnection.ClearPool(baglanti);
        }

        Uyarı.Visible = false;
        Label9.Visible = false;

        string mode = Request.QueryString["mode"];

        if (mode == "register")
        {
            main_signin.Visible = true;
            signin.Visible = true;
            Mail_Onay.Visible = false;
            signin2.Visible = false;
            signin3.Visible = false;

            login1.Visible = false;
            login2.Visible = false;

            main_profile.Visible = false;
            goodbye.Visible = false;
        }
        else if (mode == "settings")
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            main_profile.Visible = true;
            goodbye.Visible = false;

            main_signin.Visible = false;
            signin.Visible = false;
            Mail_Onay.Visible = false;
            signin2.Visible = false;
            signin3.Visible = false;

            login1.Visible = false;
            login2.Visible = false;

            string sorgu3 = "SELECT Username FROM dbo.Users where PassID='" + old.Value + "' ";
            string username;
            SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            username = (string)komut3.ExecuteScalar();

            string sorgu4 = "SELECT Mail FROM dbo.Users where PassID='" + old.Value + "' ";
            string mail;
            SqlCommand komut4 = new SqlCommand(sorgu4, baglanti);
            mail = (string)komut4.ExecuteScalar();

            string sorgu5 = "SELECT Bio FROM dbo.Users where PassID='" + old.Value + "' ";
            string bio;
            SqlCommand komut5 = new SqlCommand(sorgu5, baglanti);
            bio = (string)komut5.ExecuteScalar();

            Label13.Text = username;
            Label14.Text = mail;
            Label16.Text = bio;
            baglanti.Close();
        }
        else
        {
            main_signin.Visible = true;
            Mail_Onay.Visible = false;
            signin2.Visible = false;
            signin3.Visible = false;

            login1.Visible = false;
            login2.Visible = false;

            main_profile.Visible = false;
            goodbye.Visible = false;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        baglanti.ConnectionString = con;

        if (Username.Text == null || Username.Text == "" || Username.Text.Length <= 0 || Mail.Text == null || Mail.Text == "" || Mail.Text.Length <= 0 || Password.Text == null || Password.Text == "" || Password.Text.Length <= 0)
        {
            Uyarı.Visible = true;
            Uyarı.Text = "Lütfen tüm alanların dolu olduğundan emin olun.";
        }
        else
        {
            string EncryptionKey = "key";
            byte[] clearBytes = Encoding.Unicode.GetBytes(Password.Text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    Password.Text = Convert.ToBase64String(ms.ToArray());
                }
            }
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand control = new SqlCommand("select * from dbo.Users where Username='" + Username.Text + "' or Mail='" + Mail.Text + "'", baglanti);
            SqlDataReader reading = control.ExecuteReader();

            if (reading.Read())
            {
                Uyarı.Visible = true;
                Uyarı.Text = "Bu kullanıcı adı veya e-posta adresi alınmış.";
            }
            else
            {

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                passid2 = passid1;
                string istek = "insert into dbo.Users(Username, Password, Mail, PassID, Image, Bio) values (@Username, @Password, @Mail, @PassID, @Image, @Bio)";
                SqlCommand cmd = new SqlCommand(istek, baglanti);
                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.Parameters.AddWithValue("@Mail", Mail.Text);
                cmd.Parameters.AddWithValue("@PassID", passid2);
                cmd.Parameters.AddWithValue("@Bio", " ");
                cmd.Parameters.AddWithValue("@Image", "image.png");
                cmd.ExecuteNonQuery();

                code2 = code1;

                //Mail Confirmation
                MailMessage msg = new MailMessage();
                msg.Subject = "Hesabınızı Onaylayın - Artado My Account";
                msg.From = new MailAddress("noreply@artadosearch.com", "Artado My Account");
                msg.To.Add(new MailAddress(Mail.Text));
                msg.IsBodyHtml = true;
                msg.Body = "<td style=\"text-align:center\"><h5>Artado Hesabım onay kodunuz:</h5><h4>"+ code2 +"</h4></td>";

                SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
                NetworkCredential AccountInfo = new NetworkCredential("noreply@artadosearch.com", "artado2520");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(msg);
                }
                catch
                {
                    Uyarı.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz.";
                }

                signin.Visible = false;
                Mail_Onay.Visible = true;
                signin2.Visible = false;
                signin3.Visible = false;
            }
        }
    }
     
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }
        string istek = "update dbo.Users set Bio=@Bio where PassID='" + passid2 + "'";
        SqlCommand cmd = new SqlCommand(istek, baglanti);
        cmd.Parameters.AddWithValue("@Bio", Bio.InnerText);
        cmd.ExecuteNonQuery();
        signin.Visible = false;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }
        string istek = "update dbo.Users set Mail2=@Mail2, Password2=@Password2 where PassID='" + passid2 + "'";
        SqlCommand cmd = new SqlCommand(istek, baglanti);
        cmd.Parameters.AddWithValue("@Mail2", Mail2.Text);
        cmd.Parameters.AddWithValue("@Password2", Pass2.Text);
        cmd.ExecuteNonQuery();

        string url = Request.QueryString["url"];
        if (url != null)
        {
            Response.Redirect(url);
        }
        else
        {
            Response.Redirect("https://www.artadosearch.com/");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        signin.Visible = false;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = true;
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (CodeTxt.Text == code2.ToString())
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();
            }
            HttpCookie cookie = new HttpCookie("id");
            cookie.Value = passid2.ToString();
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);
            string istek = "update dbo.Users set Validation=@Validation where PassID='" + passid2 + "'";
            SqlCommand cmd = new SqlCommand(istek, baglanti);
            cmd.Parameters.AddWithValue("@Validation", "true");
            cmd.ExecuteNonQuery();

            signin.Visible = false;
            Mail_Onay.Visible = false;
            signin2.Visible = true;
            signin3.Visible = false;
        }
        else
        {
            Label7.Text = "Kod yanlış lütfen tekrar deneyiniz!";
            signin.Visible = false;
            Mail_Onay.Visible = true;
            signin2.Visible = false;
            signin3.Visible = false;
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        code2 = code1;
        //Mail Confirmation
        MailMessage msg = new MailMessage();
        msg.Subject = "Hesabınızı Onaylayın - Artado My Account";
        msg.From = new MailAddress("noreply@artadosearch.com", "Artado My Account");
        msg.To.Add(new MailAddress(Mail.Text));
        msg.IsBodyHtml = true;
        msg.Body = "<td style=\"text-align:center\"><h5>Artado Hesabım onay kodunuz:</h5><h4>" + code2 + "</h4></td>";

        SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
        NetworkCredential AccountInfo = new NetworkCredential("noreply@artadosearch.com", "artado2520");
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = AccountInfo;
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(msg);
        }
        catch
        {
            Uyarı.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz.";
        }

        signin.Visible = false;
        Mail_Onay.Visible = true;
        signin2.Visible = false;
        signin3.Visible = false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];
        if (url != null)
        {
            Response.Redirect(url);
        }
        else
        {
            Response.Redirect("https://www.artadosearch.com/");
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }
        string sorgu5 = "SELECT Password FROM dbo.Users where Username='" + TextBox1.Text + "' ";
        string password;
        SqlCommand komut = new SqlCommand(sorgu5, baglanti);
        password = (string)komut.ExecuteScalar();

        string EncryptionKey = "key";
        byte[] cipherBytes = Convert.FromBase64String(password);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                password = Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        SqlCommand control = new SqlCommand("select * from dbo.Users where Username='" + TextBox1.Text + "'", baglanti);
        SqlDataReader reading = control.ExecuteReader();

        if (reading.Read() && password == TextBox3.Text)
        { 
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sorgu2 = "SELECT PassID FROM dbo.Users where Username='" + TextBox1.Text + "' ";
            int id;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            id = (int)komut2.ExecuteScalar();

            string sorgu3 = "SELECT Mail FROM dbo.Users where Username='" + TextBox1.Text + "' ";
            string mail;
            SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            mail = (string)komut3.ExecuteScalar();

            code2 = code1;

            //Mail Confirmation
            string browser = Request.Browser.Browser;
            string ip = Request.UserHostAddress;

            MailMessage msg = new MailMessage();
            msg.Subject = "Hesabınıza Giriş Yapıldı - Artado My Account";
            msg.From = new MailAddress("noreply@artadosearch.com", "Artado My Account");
            msg.To.Add(new MailAddress(mail));
            msg.IsBodyHtml = true;
            msg.Body = "<td style=\"text-align:center\"><h5>Artado Hesabınıza şu cihazdan giriş yapıldı:</h5><h4>" + "Tarayıcı: " + browser + "<br/> IP Adresi: " + ip + "<br/> <h5>Lütfen giriş yapanın siz olduğunu onaylamak için bu kodu kullanın:</h5><h4>" + code2 + "</h4> <h6>Eğer giriş yapan siz değilseniz bu e-postayı görmezden gelin.</h6> </td>";

            SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
            NetworkCredential AccountInfo = new NetworkCredential("noreply@artadosearch.com", "artado2520");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(msg);
            }
            catch
            {
                Label9.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz.";
            }

            main_signin.Visible = false;
            signin.Visible = false;
            Mail_Onay.Visible = false;
            signin2.Visible = false;
            signin3.Visible = false;

            login1.Visible = false;
            login2.Visible = true;
        }
        else
        {
            Label9.Visible = true;
            Label9.Text = "Kullanıcı adı veya şifre yanlış!";
            main_signin.Visible = false;

            login1.Visible = true;
            login2.Visible = false;
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == code2.ToString())
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string sorgu2 = "SELECT PassID FROM dbo.Users where Username='" + TextBox1.Text + "' ";
            int id;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            id = (int)komut2.ExecuteScalar();

            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();
            }
            HttpCookie cookie = new HttpCookie("id");
            cookie.Value = id.ToString();
            cookie.Expires = DateTime.UtcNow.AddDays(360);
            Response.Cookies.Add(cookie);

            string url = Request.QueryString["url"];
            if (url != null)
            {
                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("https://www.artadosearch.com/");
            }
        }
        else
        {
            Label12.Text = "Kod yanlış lütfen tekrar deneyiniz!";
            main_signin.Visible = false;

            login1.Visible = false;
            login2.Visible = true;
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        main_signin.Visible = false;
        signin.Visible = true;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = false;

        login1.Visible = true;
        login2.Visible = false;
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
        }
        Response.Redirect("/Account?mode=register&url=/Account?mode=settings");
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        main_profile.Visible = false;
        goodbye.Visible = true;

        main_signin.Visible = false;
        signin.Visible = false;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = false;

        login1.Visible = false;
        login2.Visible = false;
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        main_profile.Visible = true;
        goodbye.Visible = false;

        main_signin.Visible = false;
        signin.Visible = false;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = false;

        login1.Visible = false;
        login2.Visible = false;
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }

        string istek = "delete from dbo.Users where PassID='" + old.Value + "'";
        SqlCommand cmd = new SqlCommand(istek, baglanti);
        cmd.ExecuteNonQuery();
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }

        if (baglanti2.State == ConnectionState.Closed)
        {
            baglanti2.Open();
        }

        string sorgu3 = "SELECT Username FROM dbo.Users where PassID='" + old.Value + "' ";
        string username;
        SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
        username = (string)komut3.ExecuteScalar();

        string istek = "delete from dbo.Users where PassID='" + old.Value + "'";
        SqlCommand cmd = new SqlCommand(istek, baglanti);
        cmd.ExecuteNonQuery();

        string istek2 = "delete from arda.Questions where Username='" + username + "'";
        SqlCommand cmd2 = new SqlCommand(istek2, baglanti2);
        cmd2.ExecuteNonQuery();

        string istek3 = "delete from dbo.Answers where Username='" + username + "'";
        SqlCommand cmd3 = new SqlCommand(istek3, baglanti2);
        cmd3.ExecuteNonQuery();

        if (old != null && old.Value != null)
        {
            old.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(old);
            Session.Abandon();
        }

        Response.Redirect("/Account?mode=register&url=/Account?mode=settings");
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        string browser = Request.Browser.Browser;
        string ip = Request.UserHostAddress;

        string sorgu3 = "SELECT Mail FROM dbo.Users where Username='" + TextBox1.Text + "' ";
        string mail;
        SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
        if (baglanti.State == ConnectionState.Closed)
        {
            baglanti.Open();
        }
        mail = (string)komut3.ExecuteScalar();

        code2 = code1;
        //Mail Confirmation
        MailMessage msg = new MailMessage();
        msg.Subject = "Hesabınıza Giriş Yapıldı - Artado My Account";
        msg.From = new MailAddress("noreply@artadosearch.com", "Artado My Account");
        msg.To.Add(new MailAddress(mail));
        msg.IsBodyHtml = true;
        msg.Body = "<td style=\"text-align:center\"><h5>Artado Hesabınıza şu cihazdan giriş yapıldı:</h5><h4>" + "Tarayıcı: " + browser + "<br/> IP Adresi: " + ip + "<br/> <h5>Lütfen giriş yapanın siz olduğunu onaylamak için bu kodu kullanın:</h5><h4>" + code2 + "</h4> <h6>Eğer giriş yapan siz değilseniz bu e-postayı görmezden gelin.</h6> </td>";

        SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
        NetworkCredential AccountInfo = new NetworkCredential("noreply@artadosearch.com", "artado2520");
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = AccountInfo;
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(msg);
        }
        catch
        {
            Label9.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz.";
        }
        main_signin.Visible = false;
        signin.Visible = false;
        Mail_Onay.Visible = false;
        signin2.Visible = false;
        signin3.Visible = false;

        login1.Visible = false;
        login2.Visible = true;
    }
}