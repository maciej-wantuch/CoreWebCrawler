using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace CoreWebCrawler
{
    public class DataBaseUtils
    {
        static SqliteConnection dbConnection;

        static void DBinitalize(){

            dbConnection = new SqliteConnection("Data Source=db.sqlite;Version=3;");

            dbConnection.Open();

            string sql = "create table trinkets (productName varchar(400), productPrice varchar(60), productDiscount varchar(60))";
            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        static void DBwrite(string productName, string productPrice, string productDiscount){

            dbConnection.Open();

            string sql = "insert into trinkets (productName, productPrice, productDiscount) values (@pN, @pP, @pD)";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            command.Parameters.AddWithValue("pN", productName);
            command.Parameters.AddWithValue("pP", productPrice);
            command.Parameters.AddWithValue("pD", productDiscount);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        static void DBread(){

            dbConnection.Open();

            string sql = "select * from trinkets";

            SqliteCommand command = new SqliteCommand(sql, dbConnection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                Console.WriteLine(string.Format("Name: {0, -300} Price: {1, -60} Discount: {2, -60}", reader["productName"], reader["productPrice"], reader["productDiscount"]));

            dbConnection.Close();
        }

        static void DBdelete(){
            File.Delete("db.sqlite");
        }
    }
}
