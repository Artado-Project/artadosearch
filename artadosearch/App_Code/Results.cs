using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace artadosearch
{
    public class Result
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DisplayUrl { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
    }

    public class ResultsClass
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Result>> GetGoogle(string q, int n)
        {
            try
            {
                var results = new List<Result>();

                var response = await client.GetAsync("https://www.google.com/search?q=" + q + "&start=" + n);
                var html = await response.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                foreach (var productHTMLElement in doc.DocumentNode.SelectNodes("//div[@class='Gx5Zad fP1Qef xpd EtOod pkphOe']"))
                {
                    var titleNode = productHTMLElement.SelectSingleNode(".//div[@class='BNeawe vvjwJb AP7Wnd']");
                    var title = titleNode != null ? titleNode.InnerText : "";

                    var displayUrlNode = productHTMLElement.SelectSingleNode(".//div[@class='BNeawe UPmit AP7Wnd lRVwie']");
                    var displayUrl = displayUrlNode != null ? displayUrlNode.InnerText : "";

                    var UrlNode = productHTMLElement.SelectSingleNode(".//div[@class='egMi0 kCrYT']/a");
                    var url = UrlNode != null ? UrlNode.Attributes["href"].Value : "";

                    var descriptionNode = productHTMLElement.SelectSingleNode(".//div[@class='BNeawe s3v9rd AP7Wnd']");
                    var description = descriptionNode != null ? descriptionNode.InnerText : "";

                    var prefix = "/url?q=";
                    var suffix = "&sa=";
                    var newurl = string.Empty;

                    if (url.IndexOf(prefix) >= 0)
                    {
                        var startIndex = prefix.Length;
                        var endIndex = url.IndexOf(suffix);

                        newurl = url.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        newurl = url;
                    }

                    results.Add(new Result
                    {
                        Title = title,
                        Description = description,
                        DisplayUrl = displayUrl,
                        Url = newurl,
                        Source = "Google"
                    });
                }

                string cacheKey = string.Format("{0}_{1}_{2}", q, "google", n);
                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);
                if (cache_memo == null)
                    artadosearch.Cache.CacheResultsInMemo(q, "google", n, results);

                return results;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<Result>> GetBing(string q, int n)
        {
            try
            {
                var results = new List<Result>();

                var response = await client.GetAsync("https://www.bing.com/search?q=" + q + "&start=" + n);
                var html = await response.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                foreach (var productHTMLElement in doc.DocumentNode.SelectNodes("//li[@class='b_algo']"))
                {
                    var titleNode = productHTMLElement.SelectSingleNode(".//h2/a");
                    var title = titleNode != null ? titleNode.InnerText : "";

                    var displayUrlNode = titleNode != null ? titleNode.Attributes["href"] : null;
                    var displayUrl = displayUrlNode != null ? displayUrlNode.Value : "";

                    var descNode = productHTMLElement.SelectSingleNode(".//p[@class='b_lineclamp4 b_algoSlug']");
                    var desc = descNode != null ? descNode.InnerText : "";

                    var urlNospace = displayUrl.Replace(" ", "");
                    var url = urlNospace.Replace("\u203A", "/");

                    if (!Regex.IsMatch(url, @"^https?://", RegexOptions.IgnoreCase))
                    {
                        url = "https://" + url;
                    }

                    if (url.Contains("...") || displayUrl.Contains("..."))
                    {
                        url = url.Substring(0, url.IndexOf("..."));
                        displayUrl = displayUrl.Substring(0, displayUrl.IndexOf("..."));
                    }

                    if (!url.EndsWith("/"))
                    {
                        url += "/";
                    }

                    var description = desc.Length > 2 ? desc.Substring(2) : desc;

                    results.Add(new Result
                    {
                        Title = title,
                        Description = description,
                        DisplayUrl = displayUrl,
                        Url = url,
                        Source = "Bing"
                    });
                }

                string cacheKey = string.Format("{0}_{1}_{2}", q, "bing", n);
                var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);
                if (cache_memo == null)
                    artadosearch.Cache.CacheResultsInMemo(q, "bing", n, results);

                return results;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<Result>> GetAll(string q, int n, List<Result> json1, List<Result> json2)
        {
            var map = new Dictionary<string, Result>();

            //Adding items from json1
            foreach (var item in json1)
            {
                map[item.Title] = item;
            }

            //Adding items from json2
            foreach (var item in json2)
            {
                if (!map.ContainsKey(item.Title))
                {
                    map[item.Title] = item;
                }
            }

            var results = new List<Result>(map.Values);

            string cacheKey = string.Format("{0}_{1}_{2}", q, "all", n);
            var cache_memo = artadosearch.Cache.Get<List<Result>>(cacheKey);
            if (cache_memo == null)
                artadosearch.Cache.CacheResultsInMemo(q, "all", n, results);

            return results;
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

        public static DataTable Artado(string query, int num, string lang, string desc)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection connection = new SqlConnection(con);

            SqlDataAdapter adp;
            if (lang != null)
            {
                adp = new SqlDataAdapter("select TOP (" + num + ") * from artadoco_admin.WebResults where (Title Like @q or Description Like @q or Keywords Like @q) and Lang Like @Lang order by Rank " + desc, connection);
                adp.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Lang",
                    Value = "%" + lang + "%",
                });
            }
            else
            {
                adp = new SqlDataAdapter("select TOP (" + num + ") * from artadoco_admin.WebResults where Title Like @q or Description Like @q or Keywords Like @q order by Rank " + desc, connection);
            }
            adp.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@q",
                Value = "%" + query + "%",
            });
            DataTable dt = new DataTable();
            adp.Fill(dt);

            //Cache

            return dt;
        }

        public static string GetProxy(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            return json;
        }

        public static DataTable ConvertJsonToDataTable(string jsonString)
        {
            DataTable dataTable = new DataTable();

            // Deserialize JSON string into a list of dictionaries
            var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonString);

            if (list == null || list.Count == 0)
                return dataTable;

            // Create columns based on the keys of the first dictionary
            foreach (var key in list[0].Keys)
            {
                dataTable.Columns.Add(key);
            }

            // Populate the DataTable
            foreach (var dict in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (var key in dict.Keys)
                {
                    row[key] = dict[key];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}