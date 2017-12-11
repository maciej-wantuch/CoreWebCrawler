using CoreWebCrawler;

namespace ConsoleApplicationCrawler
{
    class Program
    {
        static void Main()
        {

            //DataBaseUtils.DBinitalize();

            DataBaseUtils.LinquSeedQuery();

            Spider.GetContent();

            DataBaseUtils.LinqReadQuery();

            //DataBaseUtils.DBreadBunnies();

            //DataBaseUtils.DBread();

            //DataBaseUtils.DBreadAscending();

            //DataBaseUtils.DBreadDescending();

            //DataBaseUtils.DBdelete();

        }

    }

}