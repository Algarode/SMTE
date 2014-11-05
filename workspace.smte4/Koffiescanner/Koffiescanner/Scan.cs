using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data;

namespace Koffiescanner
{
    class Scan
    {
        public List<Place> places = new List<Place>();
        public List<Coffeelocation> coffeelocations = new List<Coffeelocation>();
        public List<Reactie> reacties = new List<Reactie>();

        const string HTML_SPACE_PATTERN = "&nbsp;";
        const string HTML_TAG_PATTERN = "<.*?>";

        private string prijs = "";
        private string kwaliteit = "";
        private string afstand = "";
        private string smaken = "";
        private string bediening = "";

        public List<Place> fetchPlaces(string html)
        {
            places.Clear();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlAgilityPack.HtmlNodeCollection nodecollection = doc.DocumentNode.SelectNodes("//ul[@class='steden']//li");

            foreach (HtmlAgilityPack.HtmlNode node in nodecollection)
            {
                var place = node.SelectSingleNode("a").InnerText;

                place = place.Replace(HTML_TAG_PATTERN, String.Empty);
                place = place.Replace(HTML_SPACE_PATTERN, "-");

                places.Add(new Place(place));

                Database.insert("INSERT INTO smed_locaties(naam) VALUES('" + place + "')");
            }

            return places;
        }

        public List<Coffeelocation> fetchCoffeelocations(string html)
        {
            coffeelocations.Clear();
            int i = 1;
            int rank = 1;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlAgilityPack.HtmlNodeCollection nodecollection = doc.DocumentNode.SelectNodes("//ul[@id='spotList']//li");

            foreach (HtmlAgilityPack.HtmlNode node in nodecollection)
            {
                if (node.SelectSingleNode("//li[@class='rank-" + i + "']") == null)
                {
                    return null;
                }

                if (i >= 10)
                {
                    rank = Convert.ToInt32(node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='ranking ranking-2digits']//h1").InnerText);
                }
                else
                {
                    rank = Convert.ToInt32(node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='ranking']//h1").InnerText);
                }

                var naam = node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='spotdetails']//h2").InnerText.Replace("&amp;", "&").Replace("&#039;", "\\'").Replace("&eacute;", "é");

                var adresTelefoon = node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='spotdetails']//address").InnerText.Replace("&#039;", "\\'").Replace("'", "\\'").Split('|');
                var telefoon = "";

                var adresStad = adresTelefoon[0].Split(',');

                var adres = adresStad[0].Replace("\n", String.Empty).Replace("\t", String.Empty);
                var stad = adresStad[1].Replace("/t", "");

                if (adresTelefoon.Length < 2)
                {
                    telefoon = "";
                }
                else
                {
                    telefoon = adresTelefoon[1].Replace("telefoon:", String.Empty).Replace("\t", String.Empty).Replace("-", "").Replace(" ", "");
                }
                
                var score = "";
                
                var scoreNode = node.SelectSingleNode("//li[@class='rank-" + i + "']//div[@class='spotaverage']");

                if (scoreNode == null)
                {
                    score = "0.0";
                }
                else
                {
                    score = node.SelectSingleNode("//li[@class='rank-" + i + "']//div[@class='spotaverage']//p[@class='averagenumber']//span[@class='getal']").InnerText.Replace(",", ".");
                }

                WebClient webClient = new WebClient();
                var data = webClient.DownloadString("https://maps.googleapis.com/maps/api/geocode/json?address=" + adres + ", " + stad);
                JObject o = JObject.Parse(data);

                var lat = "";
                var lon = "";

                if (data.Contains("ZERO_RESULTS"))
                {
                    lat = "";
                    lon = "";
                }
                else
                {
                    lat = o["results"][0]["geometry"]["location"]["lat"].ToString();
                    lon = o["results"][0]["geometry"]["location"]["lng"].ToString();
                }

                Coffeelocation coffeeLocation = new Coffeelocation(naam, rank, adres, stad, telefoon, score);

                coffeelocations.Add(coffeeLocation);

                Database.insert("INSERT INTO smed_koffielocaties(rank, naam, adres, stad, telefoon, score, lat, lon) VALUES('" + rank + "', '" + naam + "', '" + adres + "', '" + stad + "', '" + telefoon + "', '" + score + "', '" + lat + "', '" + lon + "')");

                this.fillSmedExtra(naam, score);

                i++;

                Thread.Sleep(210);
            }

            return coffeelocations;
        }

        public List<Reactie> fetchComments(string html, string name)
        {
            reacties.Clear();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            if (html != null)
            {
                doc.LoadHtml(html);

                if (html.Contains("review hreview"))
                {
                    HtmlAgilityPack.HtmlNodeCollection nodecollection = doc.DocumentNode.SelectNodes("//div[@id='reviews']//div[@class='review hreview ']");
                    foreach (HtmlAgilityPack.HtmlNode node in nodecollection)
                    {
                        if (node.SelectSingleNode("//div[@id='" + node.Id + "']//div//blockquote//p[@class='description']").InnerText.Trim() != "")
                        {
                            var naam = node.SelectSingleNode("//div[@id='" + node.Id + "']//div[@class='row']//div[@class='review-text-section']//div[@class='reviewer vcard']//a").InnerText;
                            var commentaar = node.SelectSingleNode("//div[@id='" + node.Id + "']//div//blockquote//p[@class='description']").InnerText;

                            naam = naam.Replace("'", "\\'");
                            commentaar = commentaar.Replace("\t", String.Empty).Replace("&iuml;", "ï").Replace("'", "\\'").Replace("&amp;", "&").Replace("&#039;", "\\'").Replace("&eacute;", "é").Replace("&oacute;", "ó");

                            Reactie reactie = new Reactie(naam, commentaar);

                            reacties.Add(reactie);

                            int locatieid = 0;

                            DataTable dt = Database.select("SELECT id FROM smed_koffielocaties WHERE naam='" + name + "'");
                            if (dt.Rows.Count > 0)
                            {
                                locatieid = Convert.ToInt32(dt.Rows[0][0]);
                            }

                            Database.insert("INSERT INTO smed_reacties(locatieid, naam, commentaar) VALUES('" + locatieid + "', '" + naam + "', '" + commentaar + "')");
                        }
                    }
                }
                else
                {
                    return reacties;
                }
            }
            else
            {
                return reacties;
            }

            return reacties;
        }

        private void fillSmedExtra(string naam, string score)
        {
            this.generateRandomScores(score);

            Database.insert("INSERT INTO smed_extra(prijs, kwaliteit, afstand, smaken, bediening) VALUES('" + prijs + "', '" + kwaliteit + "', '" + afstand + "', '" + smaken + "', '" + bediening + "')");
        }

        private void generateRandomScores(string score)
        {
            Random random = new Random();

            int scoreOutput = Convert.ToInt32(score.Replace(".", String.Empty));

            if (scoreOutput == 00)
            {
                prijs = "00";
                kwaliteit = "00";
                afstand = "00";
                smaken = "00";
                bediening = "00";
            }
            else if (scoreOutput == 10)
            {
                prijs = "100";
                kwaliteit = "100";
                afstand = "100";
                smaken = "100";
                bediening = "100";
            }
            else
            {
                prijs = random.Next((scoreOutput - 2), (scoreOutput + 2)).ToString();
                kwaliteit = random.Next((scoreOutput - 2), (scoreOutput + 2)).ToString();
                afstand = random.Next((scoreOutput - 2), (scoreOutput + 2)).ToString();
                smaken = random.Next((scoreOutput - 2), (scoreOutput + 2)).ToString();
                bediening = random.Next((scoreOutput - 2), (scoreOutput + 2)).ToString();
            }
        }
    }
}