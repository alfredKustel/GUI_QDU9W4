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
    }
}
