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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity
                    .HasMany(restaurant => restaurant.WorkingChefs)
                    .WithOne(workingchef => workingchef.Restaurant)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity
                    .HasMany(restaurant => restaurant.Menu)
                    .WithOne(receipts => receipts.Restaurant)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Chef>(entity =>
            {
                entity
                    .HasOne(chef => chef.Restaurant)
                    .WithMany(restaurant => restaurant.WorkingChefs)
                    .HasForeignKey(chef => chef.RestaurantID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Chef>(entity =>
            {
                entity
                    .HasMany(chef => chef.Specialities)
                    .WithOne(receipt => receipt.Chef)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity
                    .HasOne(receipt => receipt.Restaurant)
                    .WithMany(restaurant => restaurant.Menu)
                    .HasForeignKey(receipt => receipt.RestaurantID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity
                    .HasOne(receipt => receipt.Chef)
                    .WithMany(chef => chef.Specialities)
                    .HasForeignKey(receipt => receipt.ChefID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
