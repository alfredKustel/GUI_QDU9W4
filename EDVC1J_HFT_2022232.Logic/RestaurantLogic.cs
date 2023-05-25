using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Logic
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
