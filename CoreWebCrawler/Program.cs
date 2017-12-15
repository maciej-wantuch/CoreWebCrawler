using CoreWebCrawler;

namespace ConsoleApplicationCrawler
{
    class Program
    {
        static void Main()
        {
            DataBaseUtils.SeedDataBase();

            Spider.GetContent();

            ////DataBaseUtils.ReadFromDataBase();

            DataBaseUtils.ReadFromDataBaseFiltered();

            //DataBaseUtils.DeleteDataBase();

            Mailer.SendMail();
        }

    }

}