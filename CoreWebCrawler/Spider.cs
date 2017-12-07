using System;
using System.Data.SQLite;
using System.Linq;
using HtmlAgilityPack;
using Microsoft.Data.Sqlite;

namespace ConsoleApplicationCrawler
{
    public class Spider
    {
        public static trinkets[] GetContent(String Rstring)
        {
            String sString = "";
            var doc = new HtmlDocument();
            doc.LoadHtml(Rstring);

            HtmlNodeCollection prodCollection = doc.DocumentNode.SelectNodes("//td[contains(@class, 'product_box')]");
            var prodNameCollection = prodCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_name')]"));
            var prodPriceCollection = prodCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_price')]"));
            var prodReleaseDateCollection = prodCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_day')]"));

            int pCp = prodCollection.Count;

            trinkets[] array = new trinkets[pCp];

            do
            {
                array[pCp - 1] = new trinkets()
                {
                    pName = prodNameCollection.ElementAt(pCp - 1).InnerText,
                    pPrice = prodPriceCollection.ElementAt(pCp - 1).InnerText,
                    pRelease = prodReleaseDateCollection.ElementAt(pCp - 1).InnerText
                };
                pCp--;

            } while (pCp > 0);

        }

    }

    public class trinkets
    {
        public String pName { get; set; }
        public String pPrice { get; set; }
        public String pRelease { get; set; }
    }
}