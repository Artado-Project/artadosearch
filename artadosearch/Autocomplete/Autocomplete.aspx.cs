using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Autocomplete
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        private static readonly HttpClient httpClient = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString["q"];
            string acSource = Request.Cookies["suggestions"]?.Value;

            if (!string.IsNullOrEmpty(q))
            {
                if (acSource == "Artado")
                {
                    string jsonStr = GetDataAsJson(HttpUtility.HtmlEncode(q));
                    Response.ContentType = "application/json";
                    Response.Write(jsonStr);
                }
                else
                {
                    string jsonStr;
                    try
                    {
                        jsonStr = GetDuckDuckGoDataAsync(HttpUtility.HtmlEncode(q));
                    }
                    catch
                    {
                        jsonStr = GetDataAsJson(HttpUtility.HtmlEncode(q));
                    }
                    Response.ContentType = "application/json";
                    Response.Write(jsonStr);
                }
                Response.End();
            }
        }

        public string GetDuckDuckGoDataAsync(string q)
        {
            string url = $"https://duckduckgo.com/ac/?q={q}";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string data = reader.ReadToEnd();
            return data;
        }

        public string GetDataAsJson(string q)
        {
            //Connection String
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT TOP (20) * FROM Autocomplete WHERE Keyword LIKE @Keyword";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + q + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader[i];
                            }
                            data.Add(row);
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}