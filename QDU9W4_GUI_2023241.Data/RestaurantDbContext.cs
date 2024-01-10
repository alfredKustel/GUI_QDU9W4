using QDU9W4_GUI_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace QDU9W4_GUI_2023241.Data
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("restaurant");
            }

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

            Restaurant sushisei = new Restaurant() { ID = 1, Name = "Sushi Sei" };
            Restaurant pinoccio = new Restaurant() { ID = 2, Name = "Pinoccio" };
            Restaurant peep = new Restaurant() { ID = 3, Name = "Pesti Pipi" };

            Chef taku = new Chef() { ID = 1, Name = "Takumi Aldini", Age = 20, RestaurantID = sushisei.ID };
            Chef tado = new Chef() { ID = 2, Name = "Franco De Milan", Age = 19, RestaurantID = sushisei.ID };
            Chef yuki = new Chef() { ID = 3, Name = "Yukihira Soma", Age = 21, RestaurantID = sushisei.ID };
            Chef kris = new Chef() { ID = 4, Name = "Németh Krisztián", Age = 25, RestaurantID = peep.ID };
            Chef mario = new Chef() { ID = 5, Name = "Super Mario", Age = 20, RestaurantID = pinoccio.ID };

            Receipt carb = new Receipt() { ID = 1, Name = "Carbonara", Price = 1400, ChefID = taku.ID, RestaurantID = sushisei.ID };
            Receipt aljaspeep = new Receipt() { ID = 2, Name = "Aljas Pipi", Price = 1590, ChefID = kris.ID, RestaurantID = peep.ID };
            Receipt luxburi = new Receipt() { ID = 3, Name = "SunEater Burger", Price = 4000, ChefID = kris.ID, RestaurantID = peep.ID };
            Receipt carbonara = new Receipt() { ID = 4, Name = "Carbonara a la spagetti", Price = 4000, ChefID = tado.ID, RestaurantID = sushisei.ID };

            modelBuilder.Entity<Restaurant>().HasData(sushisei, pinoccio, peep);
            modelBuilder.Entity<Chef>().HasData(taku, tado, yuki, kris, mario);
            modelBuilder.Entity<Receipt>().HasData(carb, aljaspeep, luxburi,carbonara);
        }
    }
}
