using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Proxy_Proxy_Back : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];

        if (url != null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Trim());
            request.UserAgent = "ArtadoBot Proxy";
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string htmlText = reader.ReadToEnd();
            reader.Close();
            response.Close();
            string a = "href=\"/";
            int link = htmlText.IndexOf(a);
            while (link >= 0)
            {
                htmlText = htmlText.Replace("\"/", "\"" + url);
                if (a.Length < htmlText.Length)
                {
                    link = htmlText.IndexOf(a, a.Length);
                }
                else
                {
                    link = -1;
                }
            }

            Web_Context.Text = htmlText;
        }
    }
}