using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.DynamicData;
using System.Web.Script.Serialization;

namespace artadosearch
{
    public class Ads
    {
        public static string Json(string country, string lang, string query, string id)
        {
            string[] keywords = query.Split(' ');

            var jsonDataObject = new
            {
                countryCode = country,
                languageCode = lang,
                query = query,
                keywords = keywords,
                withDescription = true,
                deviceId = id
            };

            string jsonData = new JavaScriptSerializer().Serialize(jsonDataObject);

            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://suggest-rc.takeads.com/api/v1/resolve");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Bearer 1858e8af3018f980696e0f967ea17aa7c1605da2";
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
                req.ContentLength = byteArray.Length;

                using (Stream dataStream = req.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response
                using (WebResponse response = req.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseText = reader.ReadToEnd();
                            return responseText;
                        }
                    }
                }
            }
            catch
            {
                return "noads";
            }
        }

        public static DataTable dt(string json, string query, string id)
        {
            if(json != "noads")
            {
                bool shouldRetry = true;
                int tries = 0;
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Keyword", typeof(string));
                dataTable.Columns.Add("DisplayUrl", typeof(string));
                dataTable.Columns.Add("Url", typeof(string));
                dataTable.Columns.Add("Hostname", typeof(string));
                dataTable.Columns.Add("Title", typeof(string));
                dataTable.Columns.Add("Description", typeof(string));
                dataTable.Columns.Add("Score", typeof(double));
                dataTable.Columns.Add("TrackingLink", typeof(string));
                dataTable.Columns.Add("ImageUrl", typeof(string));

                while (shouldRetry && tries <= 2)
                {
                    ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(json);

                    foreach (var resolution in response.resolutions)
                    {
                        if (resolution.data != null)
                        {
                            dataTable.Rows.Add(
                                resolution.keyword,
                                resolution.data.displayUrl,
                                resolution.data.url,
                                resolution.data.hostname,
                                resolution.data.title,
                                resolution.data.description,
                                resolution.data.score ?? 0.0, // Handle nullable double
                                resolution.data.trackingLink,
                                resolution.data.imageUrl
                            );
                        }
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        // Exit the loop
                        shouldRetry = false;
                    }
                    else
                    {
                        json = Ads.Json("us", "en", query, id);
                        dataTable.Clear();
                        tries++;
                    }
                }
                return dataTable;
            }
            else
            {
                return null;
            }
        }
    }

    public class Resolution
    {
        public string keyword { get; set; }
        public ResolutionData data { get; set; }
    }

    public class ResolutionData
    {
        public string displayUrl { get; set; }
        public string url { get; set; }
        public string hostname { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double? score { get; set; }
        public string trackingLink { get; set; }
        public string imageUrl { get; set; }
        public object imageQueryResult { get; set; }
    }

    public class Meta
    {
        public string countryCode { get; set; }
        public string languageCode { get; set; }
        public int searchLatency { get; set; }
        public int affiliationLatency { get; set; }
        public int? imageQueryLatency { get; set; }
        public Kms kms { get; set; }
    }

    public class Kms
    {
        public int searchLatency { get; set; }
        public int affiliationLatency { get; set; }
    }

    public class ApiResponse
    {
        public List<Resolution> resolutions { get; set; }
        public Meta meta { get; set; }
    }
}