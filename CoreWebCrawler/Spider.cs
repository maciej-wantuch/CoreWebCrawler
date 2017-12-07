using System;
using System.Data.SQLite;
using System.Linq;
using HtmlAgilityPack;

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

            SQLiteConnection.CreateFile("lol.sqlite");

            SQLiteConnection lol_dbConnection;

            lol_dbConnection = new SQLiteConnection("Data Source=lol.sqlite;Version=3;");
            lol_dbConnection.Open();

            String sql = "CREATE TABLE zonk (name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, lol_dbConnection);

            sql = "insert into highscores (name, score) values ('Me', 3000)";
            command = new SQLiteCommand(sql, lol_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, lol_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, lol_dbConnection);
            command.ExecuteNonQuery();

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, lol_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, lol_dbConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);

            return array;
        }

    }

    public class trinkets
    {
        public String pName { get; set; }
        public String pPrice { get; set; }
        public String pRelease { get; set; }
    }
}