using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koffiescanner
{
    class Scan
    {
        public List<Place> places = new List<Place>();
        public List<Coffeelocation> coffeelocations = new List<Coffeelocation>();

        const string HTML_SPACE_PATTERN = "&nbsp;";
        const string HTML_TAG_PATTERN = "<.*?>";

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

                var naam = node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='spotdetails']//h2").InnerText.Replace("&amp;", "&").Replace("&#039;", "'").Replace("&eacute;", "é");

                var adresTelefoon = node.SelectSingleNode("//li[@class='rank-" + i + "']//section[@class='spotdetails']//address").InnerText.Split('|');
                var telefoon = "";

                var adresStad = adresTelefoon[0].Split(',');

                var adres = adresStad[0].Replace("\n", String.Empty).Replace("\t", "");
                var stad = adresStad[1].Replace(" ", "");

                if (adresTelefoon.Length < 2)
                {
                    telefoon = "";
                }
                else
                {
                    telefoon = adresTelefoon[1].Replace("telefoon:", String.Empty).Replace("\t", String.Empty);
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

                Coffeelocation coffeeLocation = new Coffeelocation(naam, rank, adres, stad, telefoon, score);

                coffeelocations.Add(coffeeLocation);

                Database.insert("INSERT INTO koffielocaties(rank, naam, adres, stad, telefoon, score) VALUES(" + rank + ", " + naam + ", " + adres + ", " + stad + ", " + telefoon + ", " + score + ")");

                i++;
            }

            return coffeelocations;
        }
    }
}