﻿using Microsoft.EntityFrameworkCore;

namespace CoreWebCrawler
{
    public class TrinketsContext : DbContext
    {
        public DbSet<Trinket> Trinkets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
        }
    }
}
