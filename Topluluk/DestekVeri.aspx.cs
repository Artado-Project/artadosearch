using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DestekVeri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public string link;

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection baglanti = new SqlConnection(@"workstation id=ArtadoSearchTest.mssql.somee.com;packet size=4096;user id=artadosoft_SQLLogin_1;pwd=wxc1vmxdpy;data source=ArtadoSearchTest.mssql.somee.com;persist security info=False;initial catalog=ArtadoSearchTest");

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string titleveri = "insert into Eklenenler2(Eklenen) values (@Eklenen)";
            SqlCommand komut = new SqlCommand(titleveri, baglanti);
            komut.Parameters.AddWithValue("@Eklenen", TextBox3.Text);
            komut.ExecuteNonQuery();
            SonucMesajı.Text = "Teşekkür ederiz. Sonuç onaylandıktan sonra gösterilecektir.";

            int mailsembol;
            mailsembol = TextBox2.Text.IndexOf("@");
            if (TextBox2.Text.EndsWith(".com") || mailsembol >= 0)
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;


                string kime = TextBox2.Text;
                string konu = "Teşekkürler! - Artado Search";
                string icerik = "Merhaba " + TextBox1.Text + "<br/>" + "Artado Search'e destek olduğun için teşekkür ederiz. Eklediğin sonuç yakın zamanda onaylanacak ve gösterilecektir." + "<br/>" + "<br/>" + "İyi günler!" + "<br/>" + "Artado Software";

                sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("artadoyazilim@gmail.com");
                mail.To.Add(kime);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);

                SmtpClient sc2 = new SmtpClient();
                sc2.Port = 587;
                sc2.Host = "smtp.gmail.com";
                sc2.EnableSsl = true;

                string kime2 = "artadoyazilim@gmail.com";
                string konu2 = "Destek Olundu! - Artado Search";
                string icerik2 = "Ad Soyad: " + TextBox1.Text + "<br>" + "E-posta: " + TextBox2.Text + "<br/>" + "Eklenen Sonuç: " + TextBox3.Text;

                sc2.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
                MailMessage mail2 = new MailMessage();
                mail2.From = new MailAddress("artadoyazilim@gmail.com");
                mail2.To.Add(kime2);
                mail2.Subject = konu2;
                mail2.IsBodyHtml = true;
                mail2.Body = icerik2;
                sc2.Send(mail2);
            }
            else
            {
                SonucMesajı.Text = "E-postanızı kontrol ediniz.";
            }
        }

        catch(Exception hata)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            string kime = "artadoyazilim@gmail.com";
            string konu = "Ciddi Hata(Sonuç Ekle) - Artado Search";
            string icerik = "Ciddi Hata Mesajı: " + hata + "<br>" + "Mail: " + TextBox2.Text;

            sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("artadoyazilim@gmail.com");
            mail.To.Add(kime);
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);
        }
    }


   
}


