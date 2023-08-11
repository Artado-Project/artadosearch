using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace artadosearch
{

    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //for (int i = 1; i <= 22; i++)
            //{
            //    SqlConnection baglanti = new SqlConnection(admin);
            //    baglanti.Open();
            //    string sorgu = "SELECT Mail FROM MailList where MailID='" + i + "'";
            //    string title;
            //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
            //    title = komut.ExecuteScalar().ToString();
            //    Label4.Text = title;
            //    baglanti.Close();

            //    //Mail Confirmation
            //    MailMessage msg = new MailMessage();
            //    msg.Subject = "Hesabınızı Onaylayın - Artado My Account";
            //    msg.From = new MailAddress("noreply@artadosearch.com", "Artado My Account");
            //    msg.To.Add(new MailAddress(Mail.Text));
            //    msg.IsBodyHtml = true;
            //    msg.Body = "<td style=\"text-align:center\"><h5>Artado Hesabım onay kodunuz:</h5><h4>" + code2 + "</h4></td>";

            //    SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
            //    NetworkCredential AccountInfo = new NetworkCredential("noreply@artadosearch.com", "artado2520");
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = AccountInfo;
            //    smtp.EnableSsl = true;

            //    smtp.Send(msg);
            //}
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
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
            Sonuc.Text = clearText;
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
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
            Sonuc.Text = cipherText;
            return cipherText;
        }

        protected void Şifrele_Click(object sender, EventArgs e)
        {
            //TextBox1.Text.Replace("a", "DGDfhgxf3hcj4jhxhchx3hlıugip9gjhkYF8UTF7½");
            //TextBox1.Text.Replace("b", "TSRjhhyfug5c65vbo7t98I7TUJI7uıhuökkvgkfh½");
            //TextBox1.Text.Replace("c", "YRDTFG54rt98ıu98guetf76t9b6dad97twetd8et½");
            //TextBox1.Text.Replace("d", "jydrtfugıh6RFTg23cTy7yfu7U56HDTFyfguhljk½");
            //TextBox1.Text.Replace("e", "isghdxfhgjkI765YTUdvefbgnhjg8GISDFGGV8gj½");

            Encrypt(TextBox1.Text);
        }

        protected void Çöz_Click(object sender, EventArgs e)
        {
            string pwdHashed = SecurityHelper.HashPassword(TextBox1.Text, Salt.Text, 10101, 70);
            Hashed.Text = Decrypt(TextBox1.Text); ;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string github = "https://www.artadosearch.com/About";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string htmlText = reader.ReadToEnd();
            reader.Close();
            response.Close();
        }
    }

    public class SecurityHelper
    {
        public static string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}
