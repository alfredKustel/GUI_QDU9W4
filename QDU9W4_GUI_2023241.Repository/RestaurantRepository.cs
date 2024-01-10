using QDU9W4_GUI_2023241.Data;
using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Repository
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
            var old = Read(restaurant.ID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(restaurant));
                }
            }
            dataBase.SaveChanges();
        }
    }
}
