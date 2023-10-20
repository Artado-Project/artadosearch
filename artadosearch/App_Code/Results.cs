using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace artadosearch
{
    public class ResultsClass
    {
        public static string Bing(string query, int currentPage)
        {
            try
            {
                string bing = "https://www.bing.com/search?q=" + query + "&qs=n&sp=-1&pq=" + query + "&sc=8-6&sk=&cvid=E61D587280A143E4B2B331964F17D6C8&first=" + currentPage;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                request.Referer = "https://www.bing.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<ol id=\"b_results\" class=\"\">".ToLower()) + 28;
                int results2 = htmlText.Substring(results1).IndexOf("</ol>");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string Yahoo(string query, int currentPage)
        {
            try
            {
                string url = "https://search.yahoo.com/search?p=" + query + "&b=" + currentPage + 0;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                string a = "https://search.yahoo.com/search";
                int href = htmlText.IndexOf(a);
                while (href >= 0)
                {
                    htmlText = htmlText.Replace("https://search.yahoo.com/search", "/search");
                    if (a.Length < htmlText.Length)
                    {
                        href = htmlText.IndexOf(a, a.Length);
                    }
                    else
                    {
                        href = -1;
                    }
                }
                try
                {
                    int results1 = htmlText.IndexOf("<div id=\"results\"><style type=\"text/css\">") + 0;
                    int results2 = htmlText.Substring(results1).IndexOf("</div></div><div id=\"right\"></div>");
                    string resulttext = htmlText.Substring(results1, results2);
                    return resulttext;
                }
                catch
                {
                    int results1 = htmlText.IndexOf("<div id=\"left\">") + 0;
                    int results2 = htmlText.Substring(results1).IndexOf("</ol></div>");
                    string resulttext = htmlText.Substring(results1, results2);
                    return resulttext;
                }
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string Youtube(string query, int currentPage)
        {
            try
            {
                string url = "https://www.youtube.com/results?search_query=" + query;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
                request.Referer = "https://www.youtube.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<ytd-item-section-renderer class=\"style-scope ytd-section-list-renderer\" use-height-hack=\"\">".ToLower()) + 92;
                int results2 = htmlText.Substring(results1).IndexOf("</ytd-item-section-renderer>");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string Izlesene(string query, int currentPage)
        {
            try
            {
                string url = "https://search.izlesene.com/?kelime=" + query;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
                request.Referer = "https://www.izlesene.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<article role=\"main\" style=\"padding:0!important;\">".ToLower()) + 50;
                int results2 = htmlText.Substring(results1).IndexOf("</article>");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }


        //Github Results are no longer available.
        public static string Github(string query, int currentPage)
        {
            try
            {
                string github = "https://github.com/search?p=" + currentPage + "&q=" + query + "&type=Repositories";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(github.Trim());
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                string a = "href=\"/";
                int href = htmlText.IndexOf(a);
                while (href >= 0)
                {
                    htmlText = htmlText.Replace("\"/", "\"https://github.com/");
                    if (a.Length < htmlText.Length)
                    {
                        href = htmlText.IndexOf(a, a.Length);
                    }
                    else
                    {
                        href = -1;
                    }
                }
                int results1 = htmlText.IndexOf("<div class=\"Box-sc-g0xbh4-0 ilUINK\">") + 36;
                int results2 = htmlText.Substring(results1).IndexOf("</div>");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string Scholar(string query, int currentPage)
        {
            try
            {
                string url = "https://scholar.google.com/scholar?start=" + currentPage + "&q=" + query /*+ "&hl=" + ScholarFiltre.SelectedValue*/;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                string a = "href=\"/";
                int href = htmlText.IndexOf(a);
                while (href >= 0)
                {
                    htmlText = htmlText.Replace("\"/", "\"https://scholar.google.com/");
                    if (a.Length < htmlText.Length)
                    {
                        href = htmlText.IndexOf(a, a.Length);
                    }
                    else
                    {
                        href = -1;
                    }
                }
                int results1 = htmlText.IndexOf("<div id=\"gs_res_ccl_mid\">") + 25;
                int results2 = htmlText.Substring(results1).IndexOf("</div><div id=\"gs_res_ccl_bot\">");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string Base(string query, int currentPage)
        {
            try
            {
                string url = "https://www.base-search.net/Search/Results?lookfor=" + query + "&type=all&page=" + currentPage;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                string a = "href=\"/";
                int href = htmlText.IndexOf(a);
                while (href >= 0)
                {
                    htmlText = htmlText.Replace("\"/", "\"https://www.base-search.net/");
                    if (a.Length < htmlText.Length)
                    {
                        href = htmlText.IndexOf(a, a.Length);
                    }
                    else
                    {
                        href = -1;
                    }
                }
                int results1 = htmlText.IndexOf("<div id=\"hit-list\">") + 19;
                int results2 = htmlText.Substring(results1).IndexOf("<div class=\"row\" id=\"all-hits-export-row\">");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string BingNews(string query, int currentPage)
        {
            try
            {
                string bing = "https://www.bing.com/news/search?q=" + query;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(bing.Trim());
                request.Referer = "https://www.bing.com/";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string htmlText = reader.ReadToEnd();
                reader.Close();
                response.Close();
                int results1 = htmlText.IndexOf("<main class=\"main\">".ToLower()) + 19;
                int results2 = htmlText.Substring(results1).IndexOf("</main>");
                string resulttext = htmlText.Substring(results1, results2);
                return resulttext;
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public static string PriEco(string query, int num, string safe, string lang)
        {
            try
            {
                string apikey = Configs.resultapi;
                string url;
                if (lang != null)
                {
                    url = "https://search.jojoyou.org/api/?api=" + apikey + "&q=" + query + "&lang=" + lang + "&num=" + num + "&safe=" + safe;
                }
                else
                {
                    url = "https://search.jojoyou.org/api/?api=" + apikey + "&q=" + query + "&num=" + num + "&safe=" + safe;
                }
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonstring = reader.ReadToEnd();

                return jsonstring;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable Artado(string query, int num, string lang)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection connection = new SqlConnection(con);

            SqlDataAdapter adp;
            if(lang != null)
            {
                adp = new SqlDataAdapter("select TOP (10) * from artadoco_admin.WebResults where (Title Like @q or Description Like @q or Keywords Like @q) and Lang Like @Lang order by Rank desc", connection);
                adp.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Lang",
                    Value = "%" + lang + "%",
                });
            }
            else
            {
                adp = new SqlDataAdapter("select TOP (10) * from artadoco_admin.WebResults where Title Like @q or Description Like @q or Keywords Like @q order by Rank desc", connection);
            }
            adp.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@q",
                Value = "%" + query + "%",
            });
            string cmd = adp.ToString();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}