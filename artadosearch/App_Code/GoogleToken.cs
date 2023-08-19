using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Xml;


namespace artadosearch
{
    public class GoogleToken
    {
        public static void ChangeToken()
        {
            //Get hour.txt
            DateTime hour = File.GetLastWriteTime(System.Web.HttpContext.Current.Server.MapPath("/hour.txt"));
            TimeSpan limit = TimeSpan.FromHours(5);

            if ((DateTime.Now - hour) > limit)
            {
                //Get the google.js for old token
                string tokenfile = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("/js/google.js"));

                //Get the old token
                int results1 = tokenfile.IndexOf("\"cse_token\": \"") + 14;
                int results2 = tokenfile.Substring(results1).IndexOf("\",");
                string token = tokenfile.Substring(results1, results2);

                //Renew the token
                tokenfile = tokenfile.Replace(token, GetToken());
                File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("/js/google.js"), tokenfile);

                //Change the last time that gets the token
                File.SetLastWriteTime(System.Web.HttpContext.Current.Server.MapPath("/hour.txt"), DateTime.Now);
            }
        }

        //Get new token
        public static string GetToken()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://cse.google.com/cse.js?cx=160e826a9c5ebe821");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tokenfile = reader.ReadToEnd();
            reader.Close();
            response.Close();

            int results1 = tokenfile.IndexOf("\"cse_token\": \"") + 14;
            int results2 = tokenfile.Substring(results1).IndexOf("\",");
            string token = tokenfile.Substring(results1, results2);

            return token;
        }
    }
}