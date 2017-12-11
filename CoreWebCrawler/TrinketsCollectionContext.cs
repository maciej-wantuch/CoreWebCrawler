using Microsoft.EntityFrameworkCore;

namespace CoreWebCrawler
{
    public class TrinketsCollectionContext : DbContext
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDiscount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite;");
        }
    }
}
