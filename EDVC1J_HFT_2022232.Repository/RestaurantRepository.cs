using EDVC1J_HFT_2022232.Data;
using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Repository
{
    public class RestaurantRepository :IRestaurantRepository
    {
        RestaurantDbContext dataBase;
        public RestaurantRepository(RestaurantDbContext database)
        {
            dataBase = database;
        }

        public void Create(Restaurant restaurant)
        {
            dataBase.Restaurants.Add(restaurant);
            dataBase.SaveChanges();
        }

        public Restaurant Read(int id)
        {
            return
                dataBase.Restaurants.FirstOrDefault(t => t.ID == id);
        }

        public IQueryable<Restaurant> GetAll()
        {
            return dataBase.Restaurants;
        }

        public void Delete(int id)
        {
            var restaurantToDelete = Read(id);
            dataBase.Restaurants.Remove(restaurantToDelete);
            dataBase.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            var restaurantToUpdate = Read(restaurant.ID);
            restaurantToUpdate.ID = restaurant.ID;
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.WorkingChefs = restaurant.WorkingChefs;
            restaurantToUpdate.Menu = restaurant.Menu;
            dataBase.SaveChanges();
        }
    }
}
