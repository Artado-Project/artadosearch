using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;

namespace artadosearch
{
    public class GetMovies
    {
        public static string key = Configs.api_pass;

        public static Movie Get(string q)
        {
            Movie movie = new Movie();
            try
            {
                string url = "http://www.omdbapi.com/?t=" + q + "&apikey=" + key;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonstring = reader.ReadToEnd();

                JObject rotten = JObject.Parse(jsonstring);
                JArray ratings = (JArray)rotten["Ratings"];
                string rottenTomatoesRating = "";

                foreach (var rating in ratings)
                {
                    if (rating["Source"].ToString() == "Rotten Tomatoes")
                    {
                        rottenTomatoesRating = rating["Value"].ToString();
                        break;
                    }
                }

                dynamic json = JValue.Parse(jsonstring);
                movie.Title = json.Title;
                movie.Year = json.Year;
                movie.Rated = json.Rated;
                movie.Release = json.Release;
                movie.Runtime = json.Runtime;
                movie.Genre = json.Genre;
                movie.Director = json.Director;
                movie.Writer = json.Writer;
                movie.Actors = json.Actors;
                movie.Plot = json.Plot;
                movie.Lang = json.Language;
                movie.Country = json.Country;
                movie.Awards = json.Awards;
                movie.Img = json.Poster;
                movie.IMDB = json.imdbRating;
                movie.Rotten = rottenTomatoesRating;
                movie.MetaScore = json.Metascore;
                movie.BoxOffice = json.BoxOffice;

                return movie;
            }
            catch
            {
                return null;
            }
        }
    }
}