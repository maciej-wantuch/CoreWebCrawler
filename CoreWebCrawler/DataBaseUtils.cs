using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace CoreWebCrawler
{
    public static class DataBaseUtils
    {
        static SqliteConnection dbConnection;

        public static void DBinitalize()
        {

            dbConnection = new SqliteConnection("Data Source=db.sqlite;");

            dbConnection.Open();

            string sql = "create table trinkets (productName varchar(400), productPrice real, productDiscount varchar(60))";
            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        public static void DBwrite(string productName, double productPrice, string productDiscount)
        {

            dbConnection.Open();

            string sql = "insert into trinkets (productName, productPrice, productDiscount) values (@pN, @pP, @pD)";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            command.Parameters.AddWithValue("pN", productName);
            command.Parameters.AddWithValue("pP", productPrice);
            command.Parameters.AddWithValue("pD", productDiscount);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        public static void DBread()
        {

            dbConnection.Open();

            string sql = "select * from trinkets";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", reader["productName"], reader["productPrice"], reader["productDiscount"]));

            dbConnection.Close();
        }

        public static void DBreadAscending()
        {
            dbConnection.Open();

            string sql = "select * from trinkets order by productPrice asc";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", reader["productName"], reader["productPrice"], reader["productDiscount"]));

            dbConnection.Close();
        }

        public static void DBreadDescending()
        {
            dbConnection.Open();

            string sql = "select * from trinkets order by productPrice desc";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", reader["productName"], reader["productPrice"], reader["productDiscount"]));

            dbConnection.Close();
        }

        public static void DBdelete()
        {
            File.Delete("db.sqlite");
        }
    }
}
