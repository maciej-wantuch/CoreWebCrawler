using System;
using System.Linq;
using CoreWebCrawler;
using HtmlAgilityPack;

namespace ConsoleApplicationCrawler
{
    public class Spider
    {
        public static void GetContent(string Rstring)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(Rstring);

            HtmlNodeCollection productCollection = doc.DocumentNode.SelectNodes("//td[contains(@class, 'product_box')]");
            var productNameCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_name')]"));
            var productPriceCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_price')]"));
            var productDiscountCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//span[contains(@class, 'product_off')]"));

            int pCp = productCollection.Count;
            

            for (int i = 0; i < pCp; i++){
                DataBaseUtils.DBwrite();
            }

        }

    }

    public class trinkets
    {
        public String pName { get; set; }
        public String pPrice { get; set; }
        public String pRelease { get; set; }
    }
}

//prodOffCollection.ElementAt(i) != null ? prodOffCollection.ElementAt(i).InnerText : string.Empty;

//float itemCount = float.Parse(doc.DocumentNode.SelectSingleNode(".//p[contains(text(), 'items')]").InnerText.Remove(4));
            //return (float) Math.Ceiling(itemCount/maxItemsOnPage);
