using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artadosearch
{
    public class Bangs
    {
        static Dictionary<string, string> bangs = new Dictionary<string, string>
        {
            { "!g", "https://www.google.com/search?q=" },
            { "!w", "https://en.wikipedia.org/wiki/" },
            { "!yt", "https://www.youtube.com/results?search_query=" },
            { "!a", "https://www.amazon.com/s?k=" },
            { "!tw", "https://twitter.com/search?q=" },
            { "!fb", "https://www.facebook.com/search/top/?q=" },
            { "!r", "https://www.reddit.com/search?q=" },
            { "!gh", "https://github.com/search?q=" },
            { "!ama", "https://www.reddit.com/r/AMA/search?q=" },
            { "!d", "https://duckduckgo.com/?q=" },
            { "!imdb", "https://www.imdb.com/find?q=" },
            { "!ebay", "https://www.ebay.com/sch/i.html?_nkw=" },
            { "!netflix", "https://www.netflix.com/search?q=" },
            { "!maps", "https://www.google.com/maps/search/" },
            { "!p", "https://www.pinterest.com/search/pins/?q=" },
            { "!so", "https://stackoverflow.com/search?q=" },
            { "!gmail", "https://mail.google.com/mail/u/0/#search/" },
            { "!gnews", "https://news.google.com/search?q=" },
            { "!wp", "https://web.whatsapp.com/search?q=" },
            { "!img", "https://www.google.com/search?tbm=isch&q=" },
            { "!t", "https://www.tumblr.com/search/" },
            { "!dic", "https://www.dictionary.com/browse/" },
            { "!th", "https://thehackernews.com/search?q=" },
            { "!net", "https://www.netflix.com/search?q=" },
            { "!y", "https://www.yahoo.com/search?q=" },
            { "!q", "https://www.quora.com/search?q=" },
            { "!m", "https://medium.com/search?q=" },
            { "!eb", "https://www.etsy.com/search?q=" },
            { "!hr", "https://www.hackerrank.com/search?q=" },
            { "!cra", "https://www.craigslist.org/search/sss?query=" },
            { "!o", "https://outlook.live.com/mail/search/" },
            { "!drib", "https://dribbble.com/search?q=" },
            { "!it", "https://www.instagram.com/explore/tags/" },
            { "!gcal", "https://calendar.google.com/calendar/u/0/r/search?q=" },
            { "!sc", "https://soundcloud.com/search?q=" },
            { "!wol", "https://www.wolframalpha.com/input/?i=" },
            { "!mz", "https://moz.com/search?q=" },
            { "!npr", "https://www.npr.org/search?q=" },
            { "!ar", "https://www.airbnb.com/s/all?query=" },
            { "!cnn", "https://edition.cnn.com/search/?q=" },
            { "!bbc", "https://www.bbc.co.uk/search?q=" },
            { "!v", "https://vimeo.com/search?q=" },
            { "!tpb", "https://thepiratebay.org/search.php?q=" },
            { "!gdoc", "https://docs.google.com/document/u/0/?q=" },
            { "!wo", "https://wordpress.com/search/" },
            { "!rt", "https://www.rottentomatoes.com/search/?search=" },
            { "!ars", "https://arstechnica.com/search/?query=" },
            { "!ln", "https://www.linkedin.com/search/results/all/?keywords=" },
            { "!sl", "https://www.slideshare.net/search/slideshow?searchfrom=header&q=" },
            { "!hn", "https://news.ycombinator.com/item?id=" },
            { "!me", "https://www.meetup.com/find/events/?allMeetups=true&radius=5&userFreeform=" },
            { "!wik", "https://en.wikipedia.org/wiki/" },
            { "!ea", "https://www.etsy.com/search?q=" },
            { "!b", "https://www.bing.com/search?q=" },
            { "!pay", "https://www.paypal.com/webapps/mpp/home" },
            { "!dp", "https://www.dropbox.com/search/personal?query=" },
            { "!fc", "https://www.flickr.com/search/?text=" },
            { "!yelp", "https://www.yelp.com/search?find_desc=" },
            { "!vs", "https://vsco.co/search/people/" },
            { "!fm", "https://foursquare.com/explore?q=" },
            { "!gd", "https://www.google.com/drive/search?q=" },
            { "!sp", "https://open.spotify.com/search/results/" },
            { "!pg", "https://getpocket.com/explore/" },
            { "!ad", "https://www.adobe.com/products.html" },
            { "!gif", "https://giphy.com/search/" },
            { "!ibm", "https://www.ibm.com/search?lang=en&cc=us&q=" },
            { "!mf", "https://www.myfitnesspal.com/search?q=" },
            { "!sch", "https://scholar.google.com/scholar?q=" },
            { "!med", "https://www.medicinenet.com/script/main/alphaidx.asp?p=a_dict" },
            { "!az", "https://azure.microsoft.com/en-us/services/?q=" },
            { "!c", "https://www.cnet.com/search/?query=" },
            { "!ga", "https://analytics.google.com/analytics/web/#/report-home/a" },
            { "!md", "https://developer.mozilla.org/en-US/search?q=" },
            { "!al", "https://www.aliexpress.com/wholesale?SearchText=" }
        };

        public static string BangSearch(string query)
        {
            string[] queryParts = query.Split(' ');

            if (queryParts.Length > 1 && queryParts[0].StartsWith("!"))
            {
                if (bangs.ContainsKey(queryParts[0]))
                {
                    string newq = query.Replace(queryParts[0], null);

                    string baseUrl = bangs[queryParts[0]];
                    string searchString = Uri.EscapeDataString(string.Join(" ", newq.Trim()));
                    return baseUrl + searchString;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}