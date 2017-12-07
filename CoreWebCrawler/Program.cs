using CoreWebCrawler;

namespace ConsoleApplicationCrawler
{
    class Program
    {
        static void Main()
        {

            DataBaseUtils.DBinitalize();

            Spider.GetContent();

            DataBaseUtils.DBread();

            DataBaseUtils.DBdelete();

        }

    }

}