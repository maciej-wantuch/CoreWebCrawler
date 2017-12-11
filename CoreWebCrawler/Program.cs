using CoreWebCrawler;

namespace ConsoleApplicationCrawler
{
    class Program
    {
        static void Main()
        {

            DataBaseUtils.DBinitalize();

            Spider.GetContent();

            DataBaseUtils.DBreadBunnies();

            //DataBaseUtils.DBread();

            //DataBaseUtils.DBreadAscending();

            //DataBaseUtils.DBreadDescending();

            DataBaseUtils.DBdelete();

        }

    }

}