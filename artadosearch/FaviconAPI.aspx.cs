using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch
{
    public partial class FaviconAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Replace {q} with your desired query or URL parameter
            string query = Request.QueryString["q"];

            // Construct the URL for the image
            string imageUrl = $"https://www.google.com/s2/favicons?domain={query}&sz=16";

            // Download the image from the URL
            byte[] imageData;
            using (WebClient webClient = new WebClient())
            {
                imageData = webClient.DownloadData(imageUrl);
            }

            // Set the image data as the source for the Image control
            if (imageData != null && imageData.Length > 0)
            {
                Response.ContentType = "image/png";
                Response.BinaryWrite(imageData);
            }
        }
    }
}