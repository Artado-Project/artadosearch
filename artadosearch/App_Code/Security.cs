using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace artadosearch
{
    public class Security
    {
        /* 
        There has been many bot/DDOS attacks to Artado from Tor network. 
        That's why we are adding a Tor connection checker.
        We are not against using Tor, we support the idea
        but we have to take precautions because Artado can't
        stay live with the attacks. We tried to use Cloudflare
        and it did help a lot, but still many requests are 
        passing through. You can still use Artado from Tor, 
        but you can't connect to main server for other 
        search engines results and can't be connected to a 
        random proxy from our database. You can use other 
        search engines' results with setting up a proxy or
        can use the Google results with Javascript. You can 
        still use Artado results too.
        */

        private static readonly HttpClient client = new HttpClient();

        // Function to check if the IP address is a Tor exit node
        async static Task<bool> IsTorExitNode(string ip, string exitNodesListUrl)
        {
            // Download the list of Tor exit nodes
            var response = await client.GetAsync(exitNodesListUrl);
            string exitNodes = await response.Content.ReadAsStringAsync();

            // Check if the IP address is in the list
            return exitNodes.Contains(ip);
        }

        public async static Task<bool> CheckTor()
        {
            // Get the real client IP address
            string clientIP = GetClientIP();

            // URL of the Tor exit nodes list
            string torExitNodesUrl = "https://check.torproject.org/torbulkexitlist";

            Task<bool> tor = IsTorExitNode(clientIP, torExitNodesUrl);

            // Check if the IP address is a Tor exit node
            if (await tor)
            {
                // If the IP address is a Tor exit node, save it to Suspect.txt
                string filename = System.Web.HttpContext.Current.Server.MapPath("~/Suspect.txt");
                string data = string.Format("Date: {0}\nIP : {1}\n\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), clientIP);

                // Append to the file
                File.AppendAllText(filename, data);

                return true;
            }
            else
            {
                return false;
            }
        }

        // Function to get the real client IP address
        protected static string GetClientIP()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CF_CONNECTING_IP"]; // For Cloudflare
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; // For other proxy services
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.UserHostAddress; // Default
            }
            return ip;
        }
    }
}