using EDVC1J_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EDVC1J_HFT_2022232.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestaurantDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
                                |DataDirectory|\RestaurantDb.mdf;
                                Integrated Security=True");
        }
    }
}
