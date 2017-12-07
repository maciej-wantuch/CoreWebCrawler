using System;
using System.IO;
using System.Net;

namespace ConsoleApplicationCrawler
{
    class Program
    {
        static void Main()
        {
            WebRequest myWebRequest;
            WebResponse myWebResponse;
            String URL = "http://slist.amiami.com/top/search/list3?s_condition_flg=1&s_sortkey=preowned&pagemax=50";

            myWebRequest = WebRequest.Create(URL);
            myWebResponse = myWebRequest.GetResponse();

            Stream streamResponse = myWebResponse.GetResponseStream();

            StreamReader sreader = new StreamReader(streamResponse ?? throw new ArgumentNullException($"404 Poor Man"));
            String rstring = sreader.ReadToEnd();

            var products = Spider.GetContent(rstring);


            foreach (var product in products)
            {
                Console.WriteLine(product.pName);
            }

        }

    }

}