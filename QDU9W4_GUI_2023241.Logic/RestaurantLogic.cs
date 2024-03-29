﻿using QDU9W4_GUI_2023241.Models;
using QDU9W4_GUI_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Logic
{
    public class RestaurantLogic : IRestaurantLogic
    {
        IRestaurantRepository RestaurantRepository;
        public RestaurantLogic(IRestaurantRepository restaurantRepository)
        {
            RestaurantRepository = restaurantRepository;
        }

        public void Create(Restaurant restaurant)
        {
            RestaurantRepository.Create(restaurant);
        }

        public Restaurant Read(int id)
        {
            return RestaurantRepository.Read(id);
        }

        public IQueryable<Restaurant> GetAll()
        {
            return RestaurantRepository.GetAll();
        }

        public void Delete(int id)
        {
            RestaurantRepository.Delete(id);
        }

        public void Update(Restaurant restaurant)
        {
            RestaurantRepository.Update(restaurant);
        }

        public IEnumerable<Restaurant> UnderstaffedRestaurant()
        {
            var result = RestaurantRepository.GetAll().Where(x => x.Name.Equals("Pinoccio") && x.WorkingChefs.Count <= 1);
            return result;
        }
    }
}
