using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using Microsoft.Data.SqlClient;

/// <summary>
/// AutoComplete için özet açıklama
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{

    public AutoComplete()
    {

        //Tasarlanmış bileşenleri kullanıyorsanız şu satırı açıklamadan çıkarın
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<string> GetSearchs(string search)
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
        List<string> searchs = new List<string>();
        using(SqlConnection baglanti = new SqlConnection(con))
        {
            SqlCommand cmd = new SqlCommand("select Kelime from arda.Arananlar where Kelime Like @Search", baglanti);

            Microsoft.Data.SqlClient.SqlParameter parameter = new SqlParameter("@Search", search);
            cmd.Parameters.Add(search);
            baglanti.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                searchs.Add(rdr["Kelime"].ToString());
            }
        }
        return searchs;
    }

}
