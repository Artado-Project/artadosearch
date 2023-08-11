using Newtonsoft.Json.Linq;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;

namespace artadosearch
{
    public class GetWiki
    {
        public static Wiki Get(string query)
        {
            try
            {
                System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
                string lang = culture.TwoLetterISOLanguageName;

                string url = "https://" + lang + ".wikipedia.org/api/rest_v1/page/summary/" + query;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonstring = reader.ReadToEnd();

                dynamic json = JValue.Parse(jsonstring);

                Wiki wiki = new Wiki();
                wiki.Title = json.title;
                wiki.Img = json.thumbnail.source;
                wiki.Url = json.content_urls.desktop.page;
                wiki.Category = json.description;
                wiki.Summary = json.extract;
                return wiki;
            }
            catch
            {
                return null;
            }
        }
    }
}