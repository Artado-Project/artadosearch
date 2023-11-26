using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artadosearch
{
    public class Weather
    {
        public static bool CheckWeather(string query)
        {
            // Convert the query to lowercase for case-insensitive comparison
            string lowercaseQuery = query.ToLower();

            // Define an array of keywords related to weather in different languages
            Dictionary<string, string[]> weatherKeywords = new Dictionary<string, string[]>
            {
                {"English", new string[] {"weather"}},
                {"Turkish", new string[] {"hava durumu"}},
                {"Spanish", new string[] {"tiempo", "clima"}},
                {"French", new string[] {"météo"}},
                {"German", new string[] {"wetter"}},
                {"Italian", new string[] {"meteo"}},
                {"Dutch", new string[] {"weer"}},
                {"Portuguese", new string[] {"tempo"}},
                {"Russian", new string[] {"погода"}},
                {"Chinese", new string[] {"天气"}},
                {"Japanese", new string[] {"天気"}},
                {"Korean", new string[] {"날씨"}},
                {"Arabic", new string[] {"الطقس"}},
                {"Hindi", new string[] {"मौसम"}},
                {"Bengali", new string[] {"আবহাওয়া"}},
                {"Urdu", new string[] {"موسم"}},
                {"Indonesian", new string[] {"cuaca"}},
                {"Vietnamese", new string[] {"thời tiết"}},
                {"Thai", new string[] {"สภาพอากาศ"}},
                {"Greek", new string[] {"καιρός"}},
                {"Swedish", new string[] {"väder"}},
                {"Norwegian", new string[] {"vær"}},
                {"Finnish", new string[] {"sää"}},
                {"Danish", new string[] {"vejr"}},
                {"Polish", new string[] {"pogoda"}},
                {"Czech", new string[] {"počasí"}},
                {"Hungarian", new string[] {"időjárás"}},
                {"Romanian", new string[] {"vremea"}},
                {"Slovak", new string[] {"počasie"}},
                {"Bulgarian", new string[] {"време"}},
                {"Croatian", new string[] {"vrijeme"}},
                {"Estonian", new string[] {"ilm"}},
                {"Hebrew", new string[] {"מזג אוויר"}},
                {"Icelandic", new string[] {"veður"}},
                {"Irish", new string[] {"aimsir"}},
                {"Latvian", new string[] {"laiks"}},
                {"Lithuanian", new string[] {"oras"}},
                {"Malay", new string[] {"cuaca"}},
                {"Maltese", new string[] {"ilma"}},
                {"Serbian", new string[] {"vreme"}},
                {"Slovenian", new string[] {"vreme"}},
                {"Ukrainian", new string[] {"погода"}},
                {"Albanian", new string[] {"moti"}},
                {"Macedonian", new string[] {"време"}},
                {"Georgian", new string[] {"ამინდი"}},
                {"Kazakh", new string[] {"жаңау"}},
                {"Kyrgyz", new string[] {"жаңылык"}},
                {"Mongolian", new string[] {"цаг агаар"}},
                {"Tajik", new string[] {"обҳо"}},
                {"Turkmen", new string[] {"hawa"}},
                {"Uzbek", new string[] {"ob-havo"}}
            };

            // Check if the query contains any of the weather keywords
            foreach (var languageKeywords in weatherKeywords)
            {
                foreach (string keyword in languageKeywords.Value)
                {
                    if (lowercaseQuery.Contains(keyword.ToLower()))
                    {
                        return true; // Return true if a weather keyword is found
                    }
                }
            }

            return false; // Return false if no weather keyword is found
        }
    }
}